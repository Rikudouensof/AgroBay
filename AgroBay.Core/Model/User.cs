using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class User : IdentityUser
  {

    public User()
    {
      Messages = new HashSet<Message>();
    }

    


    [Display(Name = "Display Name")]
    public string DisplayName { get; set; }


    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }


    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    [Display(Name = "Image Link")]
    public string ImageUrl { get; set; }


    [Display(Name = "Headquaters Address")]
    public string AddressInfoId { get; set; }



    [Display(Name = "Date Joined")]
    public DateTime DateJoined { get; set; }


    [Display(Name = "Last Name")]
    public DateTime LastOnline { get; set; }

    [Display(Name = "About")]
    public string About { get; set; }

    public virtual ICollection<Message> Messages { get; set; }
  }
}
