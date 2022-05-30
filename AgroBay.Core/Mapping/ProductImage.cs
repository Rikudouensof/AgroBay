using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  public class ProductImageMapper
  {
    public UserProductImages GetProdutImages(FormUserProductImageViewModel input)
    {
      UserProductImages images = new UserProductImages()
      {
        DateAdded = DateTime.Now,
        UserProductId = input.UserProductId
      };

      return images;
    }

  }
}
