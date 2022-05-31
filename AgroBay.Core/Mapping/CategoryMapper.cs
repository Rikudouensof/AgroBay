using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  public class CategoryMapper
  {

    public Category GetCategory(FormCategoryViewModel input)
    {
      
      Category category = new Category()
      {
        Description = input.Description,
        PurposeDivisionId = input.PurposeDivisionId,
        Name = input.Name,
        Id = input.Id
      };

      return category;
    }


    public FormCategoryViewModel GetFormCategory(Category input)
    {

      FormCategoryViewModel category = new FormCategoryViewModel()
      {
        Description = input.Description,
        PurposeDivisionId = input.PurposeDivisionId,
        Name = input.Name,
        Id = input.Id
      };

      return category;
    }
  }
}
