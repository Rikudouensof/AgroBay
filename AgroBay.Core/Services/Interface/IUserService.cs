using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
  public interface IUserService
  {
    Task<User> Edit(FormUserViewModel user);
    DataUserViewModel Get(string id);
    IEnumerable<DataUserViewModel> GetAll();
  }
}