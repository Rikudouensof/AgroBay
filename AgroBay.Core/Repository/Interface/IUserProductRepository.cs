using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IUserProductRepository
  {
    UserProduct Add(UserProduct userProduct);
    UserProduct Delete(UserProduct userProduct);
    UserProduct Edit(UserProduct userProduct);
    UserProduct Get(int id);
    IEnumerable<UserProduct> GetAll();
  }
}