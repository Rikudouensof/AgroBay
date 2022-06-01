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
      services.AddScoped<ICategories_Repository, Categories_Repository>();
      services.AddScoped<IDivisions_Repository, Divisions_Repository>();
      services.AddScoped<IMessageRepository, MessageRepository>();
      services.AddScoped<IProductReposiotory, ProductReposiotory>();
      services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
      services.AddScoped<IUserAddressRepository, UserAddressRepository>();
      services.AddScoped<IUserProductImageRepository, UserProductImageRepository>();
      services.AddScoped<IUserProductReviewRepository, UserProductReviewRepository>();
      services.AddScoped<IUserProductRepository, UserProductRepository>();
      services.AddScoped<IUserRepository, UserRepository>();


      //Services
      services.AddScoped<ICategoriesService, CategoriesService>();
      services.AddScoped<IDivisions_Service, Divisions_Service>();
      //  services.AddScoped<object, MapService>();
      //services.AddScoped<object, MessageService>();
      services.AddScoped<IProductService, ProductService>();
      //  services.AddScoped<object, SearchSearvice>();
      services.AddScoped<IStorageService, StorageService>();
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
