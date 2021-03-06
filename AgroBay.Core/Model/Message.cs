using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class Message
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Text { get; set; }

    public DateTime When { get; set; }

    public virtual User User { get; set; }

    public string ImageUrl { get; set; }

    public string UserId { get; set; }

  }
}
