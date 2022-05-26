using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ServiceModel.Web;


namespace AgroBay.Core.Services
{
  public class Maps
  {

    private void GetResponse(Uri uri, Action<Response> callback)
    {
      WebClient wc = new WebClient();
      wc.OpenReadCompleted += (o, a) =>
      {
        if (callback != null)
        {
          DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
          callback(ser.ReadObject(a.Result) as Response);
        }
      };
      wc.OpenReadAsync(uri);
    }

    private void GetPOSTResponse(Uri uri, string data, Action<Response> callback)
    {
      HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);

      request.Method = "POST";
      request.ContentType = "text/plain;charset=utf-8";

      System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
      byte[] bytes = encoding.GetBytes(data);

      request.ContentLength = bytes.Length;

      using (Stream requestStream = request.GetRequestStream())
      {
        // Send the data.  
        requestStream.Write(bytes, 0, bytes.Length);
      }

      request.BeginGetResponse((x) =>
      {
        using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(x))
        {
          if (callback != null)
          {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Response));
            callback(ser.ReadObject(response.GetResponseStream()) as Response);
          }
        }
      }, null);
    }

  }
}
