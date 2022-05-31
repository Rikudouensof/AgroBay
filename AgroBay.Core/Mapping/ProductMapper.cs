using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  public class ProductMapper
  {
    public Product GetProduct(FormProductViewModel input)
    {
      Product product = new Product()
      {
        Description = input.Description,
        ShortDescription = input.ShortDescription,
        Id = input.Id,
        Name = input.Name,
        SubCategoryId = input.SubCategoryId
      };

      return product;
    }


    public FormProductViewModel GetFormProduct(Product input)
    {
      FormProductViewModel product = new FormProductViewModel()
      {
        Description = input.Description,
        ShortDescription = input.ShortDescription,
        Id = input.Id,
        Name = input.Name,
        SubCategoryId = input.SubCategoryId
      };

      return product;
    }
  }
}
