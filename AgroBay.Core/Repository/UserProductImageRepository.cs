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
  public class UserProductImageRepository : IUserProductImageRepository
  {

    private AgroBayDbContext _db;
    public UserProductImageRepository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public UserProductImages Get(int id)
    {
      var userPImages = _db.UserProductImages.Include(u => u.UserProduct).First(c => c.id == id);
      _db.Entry<UserProductImages>(userPImages).State = EntityState.Detached;
      return userPImages;
    }

    public IEnumerable<UserProductImages> GetAll()
    {
      var userPImages = _db.UserProductImages.Include(u => u.UserProduct).OrderBy(m => m.DateAdded);
      foreach (var item in userPImages)
      {
        _db.Entry<UserProductImages>(item).State = EntityState.Detached;
      }
      return userPImages;
    }

    public IEnumerable<UserProductImages> GetAllList()
    {
      var userPImages = _db.UserProductImages;
      return userPImages;
    }

    public UserProductImages Add(UserProductImages userPImages)
    {
      _db.UserProductImages.Add(userPImages);
      _db.SaveChanges();
      return userPImages;
    }

    public UserProductImages Edit(UserProductImages division)
    {
      _db.UserProductImages.Update(division);
      _db.SaveChanges();
      return division;
    }

    public UserProductImages Delete(UserProductImages userPImages)
    {
      _db.UserProductImages.Remove(userPImages);
      _db.SaveChanges();
      return userPImages;
    }
  }
}
