using AgroBay.Core.Data;
using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class SubCategoryService
  {

    private AgroBayDbContext _db;
    public SubCategoryService(AgroBayDbContext subCategory)
    {
      _db = subCategory;
    }


    public SubCategory Get(int id)
    {
      var subCategory = _db.SubCategories.First(c => c.Id == id);
      return subCategory;
    }

    public IEnumerable<SubCategory> GetAll()
    {
      var subCategory = _db.SubCategories;
      return subCategory;
    }

    public SubCategory Add(SubCategory division)
    {
      _db.SubCategories.Add(division);
      _db.SaveChanges();
      return division;
    }

    public SubCategory Edit(SubCategory subCategory)
    {
      _db.SubCategories.Update(subCategory);
      _db.SaveChanges();
      return subCategory;
    }

    public SubCategory Delete(SubCategory subCategory)
    {
      _db.SubCategories.Remove(subCategory);
      _db.SaveChanges();
      return subCategory;
    }
  }
}
