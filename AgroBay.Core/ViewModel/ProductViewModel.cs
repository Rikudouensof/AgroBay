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
  internal class ProductViewModel
  {
  }

  public class FormProductViewModel
  {
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "File")]
    [Required]
    public IFormFile File { get; set; }


    [Display(Name = "File")]
    [Required]
    public string Description { get; set; }

    [Display(Name = "Short Description")]
    [Required]
    [MaxLength(128), MinLength(25)]
    public string ShortDescription { get; set; }

    [Display(Name = "Sub Category")]
    [Required]
    public int SubCategoryId { get; set; }
  }

  public class DataProductViewModel : DataSubCategoryViewModel
  {
    public Product Product { get; set; }

    
  }
}
