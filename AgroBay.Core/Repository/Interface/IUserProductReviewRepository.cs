using AgroBay.Core.Model;

namespace AgroBay.Core.Repository.Interface
{
  public interface IUserProductReviewRepository
  {
    UserProductReview Add(UserProductReview review);
    UserProductReview Delete(UserProductReview review);
    UserProductReview Edit(UserProductReview review);
    UserProductReview Get(int id);
    IEnumerable<UserProductReview> GetAll();
  }
}