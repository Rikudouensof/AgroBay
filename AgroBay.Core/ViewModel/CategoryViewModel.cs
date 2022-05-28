using AgroBay.Core.Model;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace AgroBay.Core.ViewModel
{
  public class CategoryViewModel
  {


  }

  public class FormCategoryViewModel
  {

    public int Id { get; set; }

    public string Name { get; set; }


    public string Description { get; set; }



        public int PurposeDivisionId { get; set; }

        [Display(Name ="Image")]
        public IFormFile File { get; set; }
    }
}
