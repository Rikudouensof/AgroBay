using AgroBay.Core.Constants;
using AgroBay.Core.Constants.Interface;
using AgroBay.Core.Repository;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services;
using AgroBay.Core.Services.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Dependency
{
  public static class AgroBayCoreDependency
  {

    public static IServiceCollection ImplementAgroBayCoreDependency
      (this IServiceCollection services)
    {

      //Repository
      services.AddTransient<ICategories_Repository, Categories_Repository>();
      services.AddTransient<IDivisions_Repository, Divisions_Repository>();
      services.AddTransient<IMessageRepository, MessageRepository>();
      services.AddTransient<IProductReposiotory, ProductReposiotory>();
      services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
      services.AddTransient<IUserAddressRepository, UserAddressRepository>();
      services.AddTransient<IUserProductImageRepository, UserProductImageRepository>();
      services.AddTransient<IUserProductReviewRepository, UserProductReviewRepository>();
      services.AddTransient<IUserProductRepository, UserProductRepository>();
      services.AddTransient<IUserRepository, UserRepository>();


      //Services
      services.AddScoped<ICategoriesService, CategoriesService>();
      services.AddScoped<IDivisions_Service, Divisions_Service>();
      //  services.AddScoped<object, MapService>();
      //services.AddScoped<object, MessageService>();
      services.AddScoped<IProductService, ProductService>();
      //  services.AddScoped<object, SearchSearvice>();
      services.AddTransient<IStorageService, StorageService>();
      services.AddScoped<ISubCategoryService, SubCategoryService>();
      services.AddScoped<IUserAddressService, UserAddressService>();
      services.AddScoped<IUserProductImageService, UserProductImageService>();
      services.AddScoped<IUserProductReviewService, UserProductReviewService>();
      services.AddScoped<IUserProductService, UserProductService>();
      services.AddScoped<IUserService, UserService>();


      //Constant
      services.AddScoped<IAzureDataKeys, AzureDataKeys>();
      
      return services;
    }

  }
}
