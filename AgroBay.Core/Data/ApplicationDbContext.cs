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

  public DbSet<Categories> Categories { get; set; }
  public DbSet<UserProduct> UserProducts { get; set; }

  public DbSet<Product> Products { get; set; }

  public DbSet<PurposeDivision> PurposeDivisions { get; set; }

  public DbSet<SubCategory> SubCategories { get; set; }

}
