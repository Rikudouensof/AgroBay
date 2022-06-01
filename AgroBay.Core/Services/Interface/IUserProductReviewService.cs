using AgroBay.Core.Model;
using AgroBay.Core.ViewModel;

namespace AgroBay.Core.Services.Interface
{
  public interface IUserProductReviewService
  {
    UserProductReview Add(FormUserProductReviewViewModel input);
    UserProductReview Delete(UserProductReview review);
    UserProductReview Edit(FormUserProductReviewViewModel input);
    DataUserReview Get(int id);
    IEnumerable<DataUserReview> GetAll();
  }
}