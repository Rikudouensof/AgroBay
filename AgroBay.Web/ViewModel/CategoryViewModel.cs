using AgroBay.Core.Model;
using System.ComponentModel.DataAnnotations;

namespace AgroBay.Web.ViewModel
{
  public class CategoryViewModel
  {


  }

  public class FileCategoryViewModel
  {

    public int Id { get; set; }

    public string Name { get; set; }


    public string Description { get; set; }



        public int PurposeDivisionId { get; set; }

        [Display(Name ="Image")]
        public IFormFile File { get; set; }
    }
}
