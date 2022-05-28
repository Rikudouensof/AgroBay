using AgroBay.Core.Data;
using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class Categories_Repository
  {
    private AgroBayDbContext _db;
    public Categories_Repository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public Category Get(int id)
    {
      var category = _db.Categories.First(c => c.Id == id);
      return category;
    }

    public IEnumerable<Category> GetAll()
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
