using AgroBay.Core.Data;
using AgroBay.Core.Mapping;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class UserProductReviewService : IUserProductReviewService
  {
    private IUserProductReviewRepository _repoReview;
    private IUserProductRepository _repoProduct;
    public UserProductReviewService(IUserProductRepository userProductRepository,
      IUserProductReviewRepository userProductReviewRepository)
    {
      _repoProduct = userProductRepository;
      _repoReview = userProductReviewRepository;
    }


    public DataUserReview Get(int id)
    {
      var review = _repoReview.Get(id);
      var product = _repoProduct.Get(review.UserProductId);
      DataUserReview dataUserReview = new DataUserReview()
      {
        UserProduct = product,
        UserProductReview = review
      };
      return dataUserReview;
    }

    public IEnumerable<DataUserReview> GetAll()
    {
      List<DataUserReview> datareviews = new List<DataUserReview>();
      var review = _repoReview.GetAll();
      foreach (var item in review)
      {
        var datareview = Get(item.id);
        datareviews.Add(datareview);

      }


      return datareviews;
    }

    public UserProductReview Add(FormUserProductReviewViewModel input)
    {
      ProductRatingMapper productRatingMapper = new ProductRatingMapper();
      var review = productRatingMapper.GetProductRatingMapper(input);
      return review;
    }

    public UserProductReview Edit(FormUserProductReviewViewModel input)
    {
      ProductRatingMapper productRatingMapper = new ProductRatingMapper();
      var review = productRatingMapper.GetProductRatingMapper(input);
      return review;
    }

    public UserProductReview Delete(UserProductReview review)
    {
      var answer = _repoReview.Delete(review);
      return answer;
    }
  }
}
