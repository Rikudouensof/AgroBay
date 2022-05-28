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

  public class FormUserProductImageViewModel
  {
    public int id { get; set; }

    public IFormFile File { get; set; }

    public DateTime DateAdded { get; set; }


    public int UserProductId { get; set; }
  }
}
