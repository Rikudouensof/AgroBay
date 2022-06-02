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
  public class UserProductRepository : IUserProductRepository
  {

    private AgroBayDbContext _db;
    public UserProductRepository(AgroBayDbContext userProduct)
    {
      _db = userProduct;
    }


    public UserProduct Get(int id)
    {
      var userProduct = _db.UserProducts.Include(u => u.Product).Include(u => u.User).First(c => c.id == id);
      _db.Entry<UserProduct>(userProduct).State = EntityState.Detached;
      return userProduct;
    }

    public IEnumerable<UserProduct> GetAll()
    {
      var userProducts = _db.UserProducts.Include(u => u.Product).Include(u => u.User);
      _db.Entry<IEnumerable<UserProduct>>(userProducts).State = EntityState.Detached;
      return userProducts;
    }

    public IEnumerable<UserProduct> GetAllList()
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
