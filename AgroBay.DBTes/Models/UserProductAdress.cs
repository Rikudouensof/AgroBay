using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserAdress
  {
    public int Id { get; set; }
    public string Name { get; set; }

    public string Address { get; set; }

    public string MapUrl { get; set; }

    public User User { get; set; }
    public string UserId { get; set; }
  }
}
