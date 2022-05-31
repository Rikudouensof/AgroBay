using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
    public interface ISubCategoryService
    {
        Task<SubCategory> Add(FormSubCategoryViewModel input);
        SubCategory Delete(SubCategory subCategory);
        Task<SubCategory> Edit(FormSubCategoryViewModel input);
        DataSubCategoryViewModel Get(int id);
        IEnumerable<DataSubCategoryViewModel> GetAll();
    }
}