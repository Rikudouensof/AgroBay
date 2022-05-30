using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  public class UserProductMapper
  {

    public UserProduct GetUserProduct(FormUserProductViewModel input)
    {
      UserProduct userProduct = new UserProduct()
      {
        AvailableQuantity = input.AvailableQuantity,
        id = input.id,
        isSold = input.isSold,
        ProductId = input.ProductId,
        Price = input.Price,
        UserId = input.UserId,

      };

      return userProduct;
    }



    
  }

}
