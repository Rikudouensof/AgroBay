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
  public class Categories_Repository : ICategories_Repository
  {
    private AgroBayDbContext _db;
    public Categories_Repository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public Category Get(int id)
    {
      var category = _db.Categories.Include(c => c.PurposeDivision).First(c => c.Id == id);
      _db.Entry<Category>(category).State = EntityState.Detached;
      return category;
    }

    public async Task<IEnumerable<Category>> GetAll()
    {
      var categories = _db.Categories.Include(c => c.PurposeDivision);
      
      _db.Entry<IEnumerable<Category>>(categories).State = EntityState.Detached;
      return categories;
    }
    public  IEnumerable<Category> GetAllList()
    {
      var categories = _db.Categories;
      return categories;
    }

    public Category Add(Category category)
    {
      _db.Categories.Add(category);
      _db.SaveChanges();
      return category;
    }

    public Category Edit(Category category)
    {
      _db.Categories.Update(category);
      _db.SaveChanges();
      return category;
    }

    public Category DeleteCategory(Category category)
    {
      _db.Categories.Remove(category);
      _db.SaveChanges();
      return category;
    }




  }
}
