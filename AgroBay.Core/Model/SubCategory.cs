using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class SubCategory
  {

    [Key]
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }


    [Required]
    public string Description { get; set; }


    [Display(Name = "Image Link")]
    [Required]
    public string ImageUrl { get; set; }


  
    public virtual Category Categories { get; set; }

    [Display(Name = "Categories")]
    [Required]
    public int CategoriesId { get; set; }
  }
}
