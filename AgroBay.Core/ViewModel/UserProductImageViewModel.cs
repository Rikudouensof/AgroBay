using AgroBay.Core.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class UserProductImageViewModel
  {
  }

  public class DataProductImageViewModel
  {
    public UserProductImages ProductImage { get; set; }

    public UserProduct UserProduct { get; set; }
  }

  public class FormUserProductImageViewModel
  {
    public int id { get; set; }

    public IFormFile File { get; set; }



    public int UserProductId { get; set; }
  }
}
