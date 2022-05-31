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
    public class SubCategoryService : ISubCategoryService
    {

        private IHostingEnvironment _env;
        private IStorage _azStorageService;
        private ICategories_Repository _repoCat;
        private ISubCategoryRepository _repoSubCat;
        private IDivisions_Repository _repoDiv;
        public SubCategoryService(
          IHostingEnvironment hostingEnvironment,
          IStorage storage,
          ICategories_Repository categories_Repository,
          ISubCategoryRepository subCategoryRepository,
          IDivisions_Repository divisions_Repository

          )
        {
            _env = hostingEnvironment;
            _azStorageService = storage;
            _repoCat = categories_Repository;
            _repoSubCat = subCategoryRepository;
            _repoDiv = divisions_Repository;
        }


        public DataSubCategoryViewModel Get(int id)
        {
            var subCategory = _repoSubCat.Get(id);
            var category = _repoCat.Get(subCategory.CategoriesId);
            var division = _repoDiv.Get(category.Id);

            DataProductViewModel dataProductViewModel = new DataProductViewModel()
            {
                Division = division,
                Category = category,
                SubCategory = subCategory
            };
            return dataProductViewModel;
        }

        public IEnumerable<DataSubCategoryViewModel> GetAll()
        {
            var subCategory = _repoSubCat.GetAll();
            List<DataSubCategoryViewModel> dataSubCategoryViewModels = new List<DataSubCategoryViewModel>();

            foreach (var item in subCategory)
            {
                try
                {
                    var dataSubcat = Get(item.Id);
                    dataSubCategoryViewModels.Add(dataSubcat);
                }
                catch
                {

                }
            }



            return dataSubCategoryViewModels;

        }

        public async Task<SubCategory> Add(FormSubCategoryViewModel input)
        {
            SubCategoryMapper subCategoryMapper = new SubCategoryMapper();
            var subcategory = subCategoryMapper.GetSubCategory(input);

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
                    return subcategory;
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
                    subcategory.ImageUrl = await url;
                }
            }
            catch
            {
                return subcategory;
            }
            var asnswer = _repoSubCat.Add(subcategory);
            return asnswer;
        }

        public async Task<SubCategory> Edit(FormSubCategoryViewModel input)
        {
            SubCategoryMapper subCategoryMapper = new SubCategoryMapper();
            var subcategory = subCategoryMapper.GetSubCategory(input);

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
                    return subcategory;
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
                    subcategory.ImageUrl = await url;
                }
            }
            catch
            {
                return subcategory;
            }
            var anser = _repoSubCat.Edit(subcategory);
            return anser;
        }

        public SubCategory Delete(SubCategory subCategory)
        {
            var answer = _repoSubCat.Delete(subCategory);
            return answer;
        }
    }
}
