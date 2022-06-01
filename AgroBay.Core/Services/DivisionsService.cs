using AgroBay.Core.Constants;
using AgroBay.Core.Constants.Interface;
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
    public class Divisions_Service : IDivisions_Service
    {
        private IDivisions_Repository _repDiv;
        private IHostingEnvironment _env;
    private IAzureDataKeys _azureDataKeys;
    private IStorageService _azStorageService;
    public Divisions_Service(IDivisions_Repository divisions_Repository,
          IHostingEnvironment env,
          IStorageService storage,
      IAzureDataKeys azureDataKeys
      )
    {
            _repDiv = divisions_Repository;
            _env = env;
      _azStorageService = storage;
      _azureDataKeys = azureDataKeys;
    }


        public PurposeDivision Get(int id)
        {
            var division = _repDiv.Get(id);
            return division;
        }

        public IEnumerable<PurposeDivision> GetAll()
        {
            var divisions = _repDiv.GetAll();
            return divisions;
        }

        public async Task<PurposeDivision> Add(FormPurposeDivisionViewModel input)
        {
            DivisionMapper divMaper = new DivisionMapper();
            var division = divMaper.GetDivision(input);
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
                    return division;
                }

                if (input.File is not null)
                {

                    var fileName = input.File.FileName;
                    var blobname = _azureDataKeys.GetStorageArguement().Pictures;
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
                    uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueName);

                    var file = new FileStream(filePath, FileMode.Create);
                    input.File.CopyTo(file);
                    var url = _azStorageService.UploadFileToStorage(file, fileName, blobname);
                    division.ImageUrl = await url;
                }
            }
            catch
            {
                return division;
            }


            _repDiv.Add(division);
            return division;
        }

        public async Task<PurposeDivision> Edit(FormPurposeDivisionViewModel input)
        {
            DivisionMapper divMaper = new DivisionMapper();
            var division = divMaper.GetDivision(input);
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
                    return division;
                }

                if (input.File is not null)
                {

                    var fileName = input.File.FileName;
                    var blobname = _azureDataKeys.GetStorageArguement().Pictures;
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "Uploads");
                    uniqueName = Guid.NewGuid().ToString() + "_" + input.File.FileName;
                    filePath = Path.Combine(uploadsFolder, uniqueName);

                    var file = new FileStream(filePath, FileMode.Create);
                    input.File.CopyTo(file);
                    var url = _azStorageService.UploadFileToStorage(file, fileName, blobname);
                    division.ImageUrl = await url;
                }
            }
            catch
            {
                return division;
            }
            _repDiv.Edit(division);

            return division;
        }

        public PurposeDivision Delete(PurposeDivision division)
        {
            _repDiv.Delete(division);
            return division;
        }
    }
}
