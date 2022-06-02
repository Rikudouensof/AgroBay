using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserProduct
  {
    [Key]
    public int id { get; set; }


    
    public virtual Product Product { get; set; }


    [Display(Name = "Product")]
    [Required]
    public int ProductId { get; set; }



    public virtual User User { get; set; }

    [Display(Name = "User")]
    [Required]
    public string UserId { get; set; }

    [Required]
    public string Name { get; set; }

    [Display(Name = "Available Quantity")]
    [Required]
    public string AvailableQuantity { get; set; }

    [Display(Name = "Image Link")]
    [Required]
    public string ImageUrl { get; set; }

    [Display(Name = "Is Sold")]
    [Required]
    public bool isSold { get; set; }

    [Display(Name = "Price Per Unit")]
    [Required]
    public string Price { get; set; }
  }
}
