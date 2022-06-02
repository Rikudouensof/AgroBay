using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  public class UserProductAddressViewModel
  {
  }

  public class DataUserAdressViewModel
  {
    public UserAdress UserAdress { get; set; }

    public User User { get; set; }

  }

  public class FormUserProductAddressViewModel
  {
    public int Id { get; set; }


    [Required]
    public string Name { get; set; }


    [Required]
    public string Address { get; set; }

    [Display(Name = "Map Link")]
    [Required]
    public string MapUrl { get; set; }

    [Display(Name = "Map Link")]
    [Required]
    public string UserId { get; set; }
  }
}
