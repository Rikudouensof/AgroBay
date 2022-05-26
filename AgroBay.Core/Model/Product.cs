using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Model
{
  public class Product
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string MainImage { get; set; }

    public string Description { get; set; }

    [MaxLength(128), MinLength(25)]
    public string ShortDescription { get; set; }

    public SubCategory SubCategory { get; set; }
    public int SubCategoryId { get; set; }
  }
}
