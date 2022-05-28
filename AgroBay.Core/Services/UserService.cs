using AgroBay.Core.Data;
using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class UserRepository
  {
    private AgroBayDbContext _db;
    public UserRepository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }

    public User Get(string id)
    {
      var user = _db.Users.First(c => c.Id == id);
      return user;
    }

    public IEnumerable<User> GetAll()
    {
      var users = _db.Users;
      return users;
    }



    public User Edit(User user)
    {
      _db.Users.Update(user);
      _db.SaveChanges();
      return user;
    }





  }
}
