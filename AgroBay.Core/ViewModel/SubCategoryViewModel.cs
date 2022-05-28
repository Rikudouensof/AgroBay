using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class SubCategoryViewModel
  {
  }


  public class FormSubCategoryViewModel
  {


    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }


    public IFormFile File { get; set; }


    public int CategoriesId { get; set; }
  }
}
