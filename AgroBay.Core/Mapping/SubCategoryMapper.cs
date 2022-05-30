﻿using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  internal class SubCategoryMapper
  {
    public SubCategory GetSubCategory(FormSubCategoryViewModel input)
    {
      SubCategory subCategory = new SubCategory()
      {
        CategoriesId = input.CategoriesId,
        Id = input.Id,
        Name = input.Name,
        Description = input.Description,
        
      };

      return subCategory;
    }
  }
}
