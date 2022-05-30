using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  internal class UserAddressMaping
  {

    public UserAdress GetUserAdress(FormUserProductAddressViewModel input)
    {
      UserAdress userAdress = new UserAdress()
      {
        Address = input.Address,
        UserId = input.UserId,
        Id = input.Id,
        MapUrl = input.MapUrl,
        Name = input.Name
      };

      return userAdress;
    }
  }
}
