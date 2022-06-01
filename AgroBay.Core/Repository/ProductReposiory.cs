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
  public class ProductReposiotory : IProductReposiotory
  {

    private AgroBayDbContext _db;
    public ProductReposiotory(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public Product Get(int id)
    {
      var product = _db.Products.Include(p => p.SubCategory).First(c => c.Id == id);
      return product;
    }

    public IEnumerable<Product> GetAll()
    {
      var product = _db.Products.Include(p => p.SubCategory);
      return product;
    }

    public IEnumerable<Product> GetAllList()
    {
      var product = _db.Products;
      return product;
    }

    public Product Add(Product product)
    {
      _db.Products.Add(product);
      _db.SaveChanges();
      return product;
    }

    public Product Edit(Product product)
    {
      _db.Products.Update(product);
      _db.SaveChanges();
      return product;
    }

    public Product Delete(Product product)
    {
      _db.Products.Remove(product);
      _db.SaveChanges();
      return product;
    }
  }
}
