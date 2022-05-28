using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  public class MessageViewModel
  {
  }

  public class FormMessageViewModel
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Text { get; set; }

    public DateTime When { get; set; }


    public IFormFile File { get; set; }

    public string UserId { get; set; }
  }
}
