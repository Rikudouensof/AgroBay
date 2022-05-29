using AgroBay.Core.Data;
using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class UserAddressService
  {
    private AgroBayDbContext _db;
    public UserAddressService(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public UserAdress Get(int id)
    {
      var address = _db.UserAdresses.First(c => c.Id == id);
      return address;
    }

    public IEnumerable<UserAdress> GetAll()
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

