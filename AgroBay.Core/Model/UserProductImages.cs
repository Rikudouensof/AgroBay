using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserProductImages
  {
    [Key]
    public int id { get; set; }

    [Display(Name = "Image Link")]
    [Required]
    public string ImageUrl { get; set; }


    [Display(Name = "Date Added")]
    [Required]
    public DateTime DateAdded { get; set; }


    [Required]
    public UserProduct UserProduct { get; set; }

    [Display(Name = "My Product")]
    [Required]
    public int UserProductId { get; set; }
  }
}
