using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IUserAddressRepository
  {
    UserAdress Add(UserAdress address);
    UserAdress Delete(UserAdress address);
    UserAdress Edit(UserAdress address);
    UserAdress Get(int id);
    IEnumerable<UserAdress> GetAll();

    IEnumerable<UserAdress> GetAllList();
  }
}