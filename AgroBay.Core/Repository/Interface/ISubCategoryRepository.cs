using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface ISubCategoryRepository
  {
    SubCategory Add(SubCategory division);
    SubCategory Delete(SubCategory subCategory);
    SubCategory Edit(SubCategory subCategory);
    SubCategory Get(int id);
    IEnumerable<SubCategory> GetAll();
  }
}