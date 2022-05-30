using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
  public interface IUserProductService
  {
    Task<UserProduct> Add(FormUserProductViewModel input);
    UserProduct Delete(UserProduct userProduct);
    Task<UserProduct> Edit(FormUserProductViewModel input);
    DataUserProductViewModel Get(int id);
    IEnumerable<DataUserProductViewModel> GetAll();
  }
}