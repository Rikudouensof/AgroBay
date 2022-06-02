using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class Category
  {

    [Key]
    public int Id { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string Name { get; set; }


    [Display(Name = "Image Link")]
    public string ImageUrl { get; set; }

    [Display(Name = "Description")]
    public string Description { get; set; }


    public virtual PurposeDivision PurposeDivision { get; set; }

    [Display(Name = "Division")]
    public int PurposeDivisionId { get; set; }

  }
}
