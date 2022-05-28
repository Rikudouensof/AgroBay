
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class UserViewModel
  {
  }

  public class FormUserViewModel
  {
    public string Id { get; set; }

    public string UserName { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    public string DisplayName { get; set; }

    public string PhoneNumber { get; set; }


    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }


    [Display(Name = "First Name")]
    public string FirstName { get; set; }


    public string ImageName { get; set; }

    public IFormFile File { get; set; }


    [Display(Name = "Headquaters Address")]
    public string AddressInfoId { get; set; }



    [Display(Name = "Date Joined")]
    public DateTime DateJoined { get; set; }


    [Display(Name = "Last Name")]
    public DateTime LastOnline { get; set; }

    public string About { get; set; }
  }
}
