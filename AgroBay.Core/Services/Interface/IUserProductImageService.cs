using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
  public interface IUserProductImageService
  {
    Task<UserProductImages> Add(FormUserProductImageViewModel input);
    UserProductImages Delete(UserProductImages userPImages);
    Task<UserProductImages> Edit(FormUserProductImageViewModel input);
    DataProductImageViewModel Get(int id);
    IEnumerable<DataProductImageViewModel> GetAll();
  }
}