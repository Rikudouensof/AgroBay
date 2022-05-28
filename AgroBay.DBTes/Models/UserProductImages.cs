using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserProductImages
  {
    public int id { get; set; }

    public string ImageUrl { get; set; }

    public DateTime DateAdded { get; set; }

    public UserProduct UserProduct { get; set; }

    public int UserProductId { get; set; }
  }
}
