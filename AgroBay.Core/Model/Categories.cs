using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class Category
  {

    public int Id { get; set; }

    public string Name { get; set; }

    public string ImageUrl { get; set; }

    public string Description { get; set; }


    public PurposeDivision PurposeDivision { get; set; }

    public int PurposeDivisionId { get; set; }

  }
}
