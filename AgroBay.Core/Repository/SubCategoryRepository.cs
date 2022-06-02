using AgroBay.Core.Data;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class SubCategoryRepository : ISubCategoryRepository
  {

    private AgroBayDbContext _db;
    public SubCategoryRepository(AgroBayDbContext subCategory)
    {
      _db = subCategory;
    }


    public SubCategory Get(int id)
    {
      var subCategory = _db.SubCategories.Include(s => s.Categories).First(c => c.Id == id);
      _db.Entry<SubCategory>(subCategory).State = EntityState.Detached;
      return subCategory;
    }

    public IEnumerable<SubCategory> GetAll()
    {
      var subCategory = _db.SubCategories.Include(s => s.Categories);
      _db.Entry<IEnumerable<SubCategory>>(subCategory).State = EntityState.Detached;
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
