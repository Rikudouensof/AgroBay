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
  internal class SubCategoryViewModel
  {
  }


  public class FormSubCategoryViewModel
  {


    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Description { get; set; }

    [Display(Name = "File")]
    [Required]
    public IFormFile File { get; set; }

    [Display(Name = "Category Id")]
    [Required]
    public int CategoriesId { get; set; }
  }

  public class DataSubCategoryViewModel : DataCategoryViewModel
  {
    public SubCategory SubCategory { get; set; }

  
  }
}
