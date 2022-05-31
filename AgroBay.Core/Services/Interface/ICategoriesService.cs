using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
    public interface ICategoriesService
    {
        Task<Category> AddAsync(FormCategoryViewModel input);
        Category DeleteCategory(Category category);
        Task<Category> Edit(FormCategoryViewModel input);
        DataCategoryViewModel Get(int id);
        IEnumerable<DataCategoryViewModel> GetAll();
    }
}