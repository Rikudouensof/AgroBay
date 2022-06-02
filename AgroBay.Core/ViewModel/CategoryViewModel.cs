using AgroBay.Core.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AgroBay.Core.ViewModel
{
  public class CategoryViewModel
  {


  }

  public class DataCategoryViewModel
  {
    public Category Category { get; set; }

    public PurposeDivision Division { get; set; }

  }


  public class FormCategoryViewModel
  {

    public int Id { get; set; }

    [Display(Name="Name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Description")]
    [Required]
    public string Description { get; set; }

    [Display(Name = "Division")]
    [Required]
    public int PurposeDivisionId { get; set; }


    [Required]
    [Display(Name = "Image")]
    public IFormFile File { get; set; }
  }
}
