using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserProductReview
  {
    [Key]
    public int id { get; set; }

    [Display(Name = "Title")]
    [Required]
    public string Title { get; set; }

    [Display(Name = "Rating")]
    [Required]
    public int Rating { get; set; }

    [Display(Name = "Description")]
    [Required]
    public string Description { get; set; }


    public virtual UserProduct UserProduct { get; set; }

    [Display(Name = "My Product")]
    [Required]
    public int UserProductId { get; set; }


    [Display(Name = "Date Set")]
    [Required]
    public DateTime DateSet { get; set; }
  }
}
