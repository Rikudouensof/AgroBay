using AgroBay.Core.Constants.Interface;
using AgroBay.Core.Services.Interface;
using Azure.Storage;
using Azure.Storage.Blobs;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{


  public class StorageService : IStorageService
  {
    private IAzureDataKeys _storageArguement;
    public StorageService(IAzureDataKeys azureDataKeys)
    {
      _storageArguement = azureDataKeys;

    }

    public  string UploadFileToStorage(Stream fileStream, string fileName,
                                                 string blobName)
    {

      var storageArguement = _storageArguement.GetStorageArguement();

      // Create a URI to the blob
      Uri blobUri = new Uri("https://" +
                            storageArguement.AzureContainerName +
                            ".blob.core.windows.net/" +
                            blobName +
                            "/" + fileName);

      // Create StorageSharedKeyCredentials object by reading
      // the values from the configuration (appsettings.json)
      StorageSharedKeyCredential storageCredentials =
          new StorageSharedKeyCredential(storageArguement.AzureContainerName, storageArguement.AzureNameKeyKey);

      // Create the blob client.
      BlobClient blobClient = new BlobClient(blobUri, storageCredentials);
      fileStream.Position = 0;
      // Upload the file
      var settings =  blobClient.Upload(fileStream);



      if (settings is not null)
      {
        return blobUri.AbsoluteUri;
      }
      else
      {
        return "upload failed";
      }
    }


    public async Task<string> DeleteFile(StorageArguement storageArguement, string fileName)
    {
      bool isSucessful = false;

      string blobstorageconnection = storageArguement.ConnectionString;
      string strContainerName = storageArguement.AzureContainerName;


      CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(blobstorageconnection);
      CloudBlobClient cloudBlobClient = cloudStorageAccount.CreateCloudBlobClient();

      CloudBlobContainer cloudBlobContainer = cloudBlobClient.GetContainerReference(strContainerName);
      var blob = cloudBlobContainer.GetBlobReference(fileName);
      var result = await blob.DeleteIfExistsAsync();
      return $"{fileName}, is deleted sucessfully";


    }
  }

  public class StorageArguement
  {
    public string AzureContainerName { get; set; }
    public string AzureNameKeyKey { get; set; }

    public string ConnectionString { get; set; }

    public string Video { get; set; }

    public string Pictures { get; set; }

    public string ProfilePicture { get; set; }
  }
}
