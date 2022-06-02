using AgroBay.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

    [Display(Name = "Title")]
    [Required]
    public string Title { get; set; }

    [Display(Name = "Rating")]
    [Required]
    public int Rating { get; set; }

    [Display(Name = "Description")]
    [Required]
    public string Description { get; set; }

    [Display(Name = "My Product")]
    [Required]
    public int UserProductId { get; set; }


  }
}
