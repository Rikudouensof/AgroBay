using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Mapping
{
  internal class ProductRatingMapper
  {
    public UserProductReview GetProductRatingMapper(FormUserProductReviewViewModel input)
    {
      UserProductReview review = new UserProductReview()
      {
        DateSet = DateTime.Now,
        Description = input.Description,
        id = input.id,
        Rating = input.Rating,
        Title = input.Title,
        UserProductId = input.UserProductId
      };

      return review;
    }
  }
}
