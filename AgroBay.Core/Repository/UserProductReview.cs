using AgroBay.Core.Data;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Repository
{
  public class UserProductReviewRepository : IUserProductReviewRepository
  {
    private AgroBayDbContext _db;
    public UserProductReviewRepository(AgroBayDbContext agroBayDbContext)
    {
      _db = agroBayDbContext;
    }


    public UserProductReview Get(int id)
    {
      var review = _db.UserProductReviews.Include(u => u.UserProduct).First(c => c.id == id);
      return review;
    }

    public IEnumerable<UserProductReview> GetAll()
    {
      var review = _db.UserProductReviews.Include(u => u.UserProduct);
      return review;
    }

    public UserProductReview Add(UserProductReview review)
    {
      _db.UserProductReviews.Add(review);
      _db.SaveChanges();
      return review;
    }

    public UserProductReview Edit(UserProductReview review)
    {
      _db.UserProductReviews.Update(review);
      _db.SaveChanges();
      return review;
    }

    public UserProductReview Delete(UserProductReview review)
    {
      _db.UserProductReviews.Remove(review);
      _db.SaveChanges();
      return review;
    }
  }
}
