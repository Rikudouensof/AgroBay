using AgroBay.Core.Repository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{


  internal class PurposeDivisionViewModel
  {
  }

  public class FormPurposeDivisionViewModel
  {

    public int? Id { get; set; }

    [Required]
    [Display(Name = "Title")]
    public string Name { get; set; }

    [Required]
    [Display(Name = "Division Image")]
    public IFormFile File { get; set; }
  }
}
