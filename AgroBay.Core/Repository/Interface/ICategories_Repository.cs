using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface ICategories_Repository
  {
    Category Add(Category category);
    Category DeleteCategory(Category category);
    Category Edit(Category category);
    Category Get(int id);
    IEnumerable<Category> GetAll();
    IEnumerable<Category> GetAllList();
  }
}