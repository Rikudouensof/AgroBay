using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Tasks
{
  public class CustomMail
  {
    private async static Task SendAMailAsync(MailCredential message, EmailArguement credential )
    {
      #region formatter
      string text = string.Format("{0}: {1}", message.Subject, message.Body);

      #endregion

      MailMessage msg = new MailMessage();
      msg.From = new MailAddress(credential.Email);
      msg.To.Add(new MailAddress(message.Destination));
      msg.Subject = message.Subject;
      msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(message.Body, null, MediaTypeNames.Text.Html));
      msg.IsBodyHtml = true;
      //  msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

      SmtpClient smtpClient = new SmtpClient(credential.Website, Convert.ToInt32(587));
      System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(credential.Email, credential.Password);
      smtpClient.UseDefaultCredentials = false;
      smtpClient.Credentials = credentials;
      smtpClient.EnableSsl = false;
      smtpClient.Send(msg);
    }
  }

  public class EmailArguement
  {
    public string Email { get; set; }
    public string Website { get; set; }

    public string Password { get; set; }
  }

  public class MailCredential
  {

    public string Destination { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
  }
}
