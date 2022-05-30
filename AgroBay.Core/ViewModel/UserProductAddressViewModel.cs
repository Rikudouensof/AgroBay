using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
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

    public string Name { get; set; }

    public string Address { get; set; }

    public string MapUrl { get; set; }

    public string UserId { get; set; }
  }
}
