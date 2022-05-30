using AgroBay.Core.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class UserProductViewModel
  {
  }

  public class DataUserProductViewModel : DataProductViewModel
  {
    public UserProduct ProductUser { get; set; }
  }

  public class FormUserProductViewModel
  {

    [Key]
    public int id { get; set; }

    public int ProductId { get; set; }

    public string UserId { get; set; }



    public string AvailableQuantity { get; set; }



    public IFormFile File { get; set; }



    public bool isSold { get; set; }



    public string Price { get; set; }
  }
}
