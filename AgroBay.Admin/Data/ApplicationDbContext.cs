using AgroBay.Admin.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroBay.Admin.Data
{
  public class ApplicationDbContext : IdentityDbContext<User>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Categories> Categories { get; set; }
    public DbSet<UserProduct> UserProducts { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<PurposeDivision> PurposeDivisions { get; set; }

    public DbSet<SubCategory> SubCategories { get; set; }
  }
}