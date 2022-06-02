using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class PurposeDivision
  {
    [Key]
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required]
    public string Name { get; set; }


    [Display(Name = "Image Link")]
    [Required]
    public string ImageUrl { get; set; }

  }
}
