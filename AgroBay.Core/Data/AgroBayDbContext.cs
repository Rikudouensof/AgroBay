using AgroBay.Core.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroBay.Core.Data;

public class AgroBayDbContext : IdentityDbContext<User>
{
  public AgroBayDbContext(DbContextOptions<AgroBayDbContext> options)
      : base(options)
  {

    
  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    base.OnModelCreating(builder);
    builder.Entity<Message>()
      .HasOne<User>(x => x.User)
      .WithMany(d => d.Messages)
      .HasForeignKey(d => d.UserId);
  }

  public DbSet<Category> Categories { get; set; }
  public DbSet<UserProduct> UserProducts { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<PurposeDivision> PurposeDivisions { get; set; }

  public DbSet<SubCategory> SubCategories { get; set; }

  public DbSet<Message> Messages { get; set; }

  public DbSet<UserAdress> UserAdresses { get; set; }

  public DbSet<UserProductImages> UserProductImages { get; set; }

  public DbSet<UserProductReview> UserProductReviews { get; set; }
}
