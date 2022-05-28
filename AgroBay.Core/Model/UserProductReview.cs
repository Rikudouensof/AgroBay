using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class UserProductReview
  {

    public int id { get; set; }

    public string Title { get; set; }

    public int Rating { get; set; }

    public string Description { get; set; }

    public UserProduct UserProduct { get; set; }

    public int UserProductId { get; set; }

    public DateTime DateSet { get; set; }
  }
}
