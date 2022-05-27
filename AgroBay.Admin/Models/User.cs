using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Admin.Model
{
  public class User : IdentityUser
  {
    [Display(Name = "Display Name")]
    public string DisplayName { get; set; }


    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }


    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    public string ImageName { get; set; }

    [Display(Name = "Bing Map Info")]
    public string AddressInfoId { get; set; }



    [Display(Name = "Date Joined")]
    public DateTime DateJoined { get; set; }


    [Display(Name = "Last Name")]
    public DateTime LastOnline { get; set; }

    public string About { get; set; }


  }
}
