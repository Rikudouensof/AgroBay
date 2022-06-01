using AgroBay.Core.Constants;
using AgroBay.Core.Data;
using AgroBay.Core.Mapping;
using AgroBay.Core.Model;
using AgroBay.Core.Repository.Interface;
using AgroBay.Core.Services.Interface;
using AgroBay.Core.ViewModel;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
    public class CategoriesService : ICategoriesService
    {
        private ICategories_Repository _repCat;
        private IDivisions_Repository _repDiv;
        private IHostingEnvironment _env;
        private IStorage _azStorageService;
        public CategoriesService(ICategories_Repository rep, IDivisions_Repository divisions_Repository, IHostingEnvironment env, IStorage storage)
        {
            _repCat = rep;
            _repDiv = divisions_Repository;
            _env = env;
            _azStorageService = storage;
        }


        public DataCategoryViewModel Get(int id)
        {

            var category = _repCat.Get(id);
            var division = _repDiv.Get(category.PurposeDivisionId);
            DataCategoryViewModel categoryViewModel = new DataCategoryViewModel()
            {
                Category = category,
                Division = division
            };
            return categoryViewModel;
        }

        public IEnumerable<DataCategoryViewModel> GetAll()
        {
            List<DataCategoryViewModel> listCategoryViewModel = new List<DataCategoryViewModel>();
            var categories = _repCat.GetAllList();

            foreach (var item in categories)
            {
                DataCategoryViewModel detailedCategoryViewModel = Get(item.Id);
                listCategoryViewModel.Add(detailedCategoryViewModel);

            }

            return listCategoryViewModel;
        }

        public async Task<Category> AddAsync(FormCategoryViewModel input)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            var category = categoryMapper.GetCategory(input);

            try
            {
                var iscorrectformat = false;
                string uniqueName = null;
                string filePath = null;
                FileInfo fi = new FileInfo(input.File.FileName);

                var actualextension = fi.Extension;
                var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
                foreach (var imageExtension in imageextensions)
                {
                    if (imageExtension == actualextension.ToUpper())
                    {
                        iscorrectformat = true;
                    }
                }
                if (iscorrectformat == false)
                {
                    return category;
                }

                if (input.File is not null)
                {

                    var fileName = input.File.FileName;
                    var blobname = AzureDataKeys.blob_background;
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
                    uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueName);

                    var file = new FileStream(filePath, FileMode.Create);
                    input.File.CopyTo(file);
                    var url = _azStorageService.UploadFileToStorage(file, fileName, blobname, AzureDataKeys.GetStorageArguement());
                    category.ImageUrl = await url;
                }
            }
            catch
            {
                return category;
            }
            var processedCategory = _repCat.Add(category);
            return category;
        }

        public async Task<Category> Edit(FormCategoryViewModel input)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            var category = categoryMapper.GetCategory(input);
            try
            {
                var iscorrectformat = false;
                string uniqueName = null;
                string filePath = null;
                FileInfo fi = new FileInfo(input.File.FileName);

                var actualextension = fi.Extension;
                var imageextensions = FileFormat.GetSupportedImageTypeExtensionsList();
                foreach (var imageExtension in imageextensions)
                {
                    if (imageExtension == actualextension.ToUpper())
                    {
                        iscorrectformat = true;
                    }
                }
                if (iscorrectformat == false)
                {
                    return category;
                }

                if (input.File is not null)
                {

                    var fileName = input.File.FileName;
                    var blobname = AzureDataKeys.blob_background;
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
                    uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueName);

                    var file = new FileStream(filePath, FileMode.Create);
                    input.File.CopyTo(file);
                    var url = _azStorageService.UploadFileToStorage(file, fileName, blobname, AzureDataKeys.GetStorageArguement());
                    category.ImageUrl = await url;
                }
            }
            catch
            {
                return category;
            }
            return category;
        }

        public Category DeleteCategory(Category category)
        {
            var deleted = _repCat.DeleteCategory(category);
            return deleted;
        }




    }
}
