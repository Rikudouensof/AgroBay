using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Admin.Model
{
  public class SubCategory
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public Categories Categories { get; set; }

    public int CategoriesId { get; set; }
  }
}
