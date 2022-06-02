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
  internal class UserProductViewModel
  {
  }

  public class DataUserProductViewModel : DataProductViewModel
  {
    public UserProduct ProductUser { get; set; }
  }

  public class FormUserProductViewModel
  {

    
    public int id { get; set; }

    [Display(Name = "Product")]
    [Required]
    public int ProductId { get; set; }

    [Display(Name = "User")]
    [Required]
    public string UserId { get; set; }

    [Display(Name = "Avaliable Quantity")]
    [Required]
    public string AvailableQuantity { get; set; }

    [Display(Name = "Upload File")]
    [Required]
    public IFormFile File { get; set; }



    [Display(Name = "IS Sold")]
    [Required]
    public bool isSold { get; set; }

    [Display(Name = "Product Name")]
    [Required]
    public string Name { get; set; }

    [Display(Name = "Price per Unit")]
    [Required]
    public string Price { get; set; }
  }
}
