using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IUserRepository
  {
    User Edit(User user);
    User Get(string id);
    IEnumerable<User> GetAll();
  }
}