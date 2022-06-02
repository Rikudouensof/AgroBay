using AgroBay.Core.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    [Display(Name = "File")]
    [Required]
    public IFormFile File { get; set; }

    [Display(Name = "My Product")]
    [Required]
    public int UserProductId { get; set; }
  }
}
