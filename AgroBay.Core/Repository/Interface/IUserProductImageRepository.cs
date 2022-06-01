using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IUserProductImageRepository
  {
    UserProductImages Add(UserProductImages userPImages);
    UserProductImages Delete(UserProductImages userPImages);
    UserProductImages Edit(UserProductImages division);
    UserProductImages Get(int id);
    IEnumerable<UserProductImages> GetAll();
    IEnumerable<UserProductImages> GetAllList();
  }
}