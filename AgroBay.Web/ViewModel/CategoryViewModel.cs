using AgroBay.Core.Model;

namespace AgroBay.Web.ViewModel
{
  public class CategoryViewModel
  {


  }

  public class FileCategoryViewModel : Category
  {
        public IFormFile File { get; set; }
    }
}
