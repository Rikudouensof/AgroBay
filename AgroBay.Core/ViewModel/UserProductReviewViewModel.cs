using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.ViewModel
{
  internal class UserProductReviewViewModel
  {
  }


  public class DataUserReview
  {

    public UserProductReview UserProductReview { get; set; }

    public UserProduct UserProduct { get; set; }
  }


  public class FormUserProductReviewViewModel
  {

    public int id { get; set; }

    public string Title { get; set; }

    public int Rating { get; set; }

    public string Description { get; set; }


    public int UserProductId { get; set; }


  }
}
