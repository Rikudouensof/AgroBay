using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class Product
  {

    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }

    [Required]
    public string ImageUrl { get; set; }
    [Required]
    public string Description { get; set; }

    [MaxLength(128), MinLength(25)]
    [Display(Name = "Short Description")]
    public string ShortDescription { get; set; }

    public virtual SubCategory SubCategory { get; set; }

    [Display(Name = "Sub-Category")]
    public int SubCategoryId { get; set; }
  }
}
