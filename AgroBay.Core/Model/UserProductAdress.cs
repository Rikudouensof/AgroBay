using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserAdress
  {

    [Key]
    public int Id { get; set; }

    [Display(Name = "Name")]
    [Required]
    public string Name { get; set; }


    [Required]
    public string Address { get; set; }

    [Display(Name = "Map Link")]
    [Required]
    public string MapUrl { get; set; }


    public virtual User User { get; set; }

    [Display(Name = "User")]
    [Required]
    public string UserId { get; set; }
  }
}
