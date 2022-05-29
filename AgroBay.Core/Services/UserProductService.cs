using AgroBay.Core.Data;
using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class UserProductService
  {

    private AgroBayDbContext _db;
    public UserProductService(AgroBayDbContext userProduct)
    {
      _db = userProduct;
    }


    public UserProduct Get(int id)
    {
      var userProduct = _db.UserProducts.First(c => c.id == id);
      return userProduct;
    }

    public IEnumerable<UserProduct> GetAll()
    {
      var userProducts = _db.UserProducts;
      return userProducts;
    }

    public UserProduct Add(UserProduct userProduct)
    {
      _db.UserProducts.Add(userProduct);
      _db.SaveChanges();
      return userProduct;
    }

    public UserProduct Edit(UserProduct userProduct)
    {
      _db.UserProducts.Update(userProduct);
      _db.SaveChanges();
      return userProduct;
    }

    public UserProduct Delete(UserProduct userProduct)
    {
      _db.UserProducts.Remove(userProduct);
      _db.SaveChanges();
      return userProduct;
    }
  }
}
