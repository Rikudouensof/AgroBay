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
  public class UserAddressRepository : IUserAddressRepository
  {
    private AgroBayDbContext _db;
    public UserAddressRepository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public UserAdress Get(int id)
    {
      var address = _db.UserAdresses.Include(u => u.User).First(c => c.Id == id);
      _db.Entry<UserAdress>(address).State = EntityState.Detached;
      return address;
    }

    public IEnumerable<UserAdress> GetAll()
    {
      var address = _db.UserAdresses.Include(u => u.User).OrderBy(m => m.Name);
      foreach (var item in address)
      {
        _db.Entry<UserAdress>(item).State = EntityState.Detached;
      }
      return address;
    }

    public IEnumerable<UserAdress> GetAllList()
    {
      var address = _db.UserAdresses;
      return address;
    }

    public UserAdress Add(UserAdress address)
    {
      _db.UserAdresses.Add(address);
      _db.SaveChanges();
      return address;
    }

    public UserAdress Edit(UserAdress address)
    {
      _db.UserAdresses.Update(address);
      _db.SaveChanges();
      return address;
    }

    public UserAdress Delete(UserAdress address)
    {
      _db.UserAdresses.Remove(address);
      _db.SaveChanges();
      return address;
    }
  }
}

