using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class ProductViewModel
  {
  }

  public class FormProductViewModel
  {
    public int Id { get; set; }

    public string Name { get; set; }


    public IFormFile Image { get; set; }

    public string Description { get; set; }

    [MaxLength(128), MinLength(25)]
    public string ShortDescription { get; set; }

    public int SubCategoryId { get; set; }
  }
}
