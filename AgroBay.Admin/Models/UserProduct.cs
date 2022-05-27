using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Admin.Model
{
  public class UserProduct
  {
    [Key]
    public int id { get; set; }

    public Product Product { get; set; }
    public int ProductId { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
  }
}
