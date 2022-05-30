using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
  public interface IProductService
  {
    Task<Product> Add(FormProductViewModel input);
    Product Delete(Product product);
    Task<Product> Edit(FormProductViewModel input);
    DataProductViewModel Get(int id);
    IEnumerable<DataProductViewModel> GetAll();
  }
}