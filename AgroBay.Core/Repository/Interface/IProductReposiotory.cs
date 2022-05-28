using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IProductReposiotory
  {
    Product Add(Product product);
    Product Delete(Product product);
    Product Edit(Product product);
    Product Get(int id);
    IEnumerable<Product> GetAll();
  }
}