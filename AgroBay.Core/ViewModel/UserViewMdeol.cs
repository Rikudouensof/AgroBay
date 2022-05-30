
using AgroBay.Core.Model;
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
  

  public class DataUserViewModel
  {
    public User User { get; set; }
    public IEnumerable<DataUserProductViewModel> dataUserProductViewModels { get; set; }
  }

  public class FormUserViewModel
  {
    public string Id { get; set; }

    

    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string DisplayName { get; set; }
    
    [Required]
    public string PhoneNumber { get; set; }


    [Display(Name = "Last Name")]
    public string LastName { get; set; }


    [Display(Name = "Middle Name")]
    public string MiddleName { get; set; }


    [Display(Name = "First Name")]
    public string FirstName { get; set; }



    public IFormFile File { get; set; }


    [Display(Name = "Headquaters Address")]
    public string AddressInfoId { get; set; }



   
    public string About { get; set; }
  }
}
