using Azure.Storage;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgroBay.Core.Services
{
  public class Storage
  {

    public static async Task<string> UploadFileToStorage(Stream fileStream, string fileName,
                                                 string blobName, StorageArguement storageArguement)
    {
      // Create a URI to the blob
      Uri blobUri = new Uri("https://" +
                            storageArguement.AzureStorageKeyName +
                            ".blob.core.windows.net/" +
                            blobName +
                            "/" + fileName);

      // Create StorageSharedKeyCredentials object by reading
      // the values from the configuration (appsettings.json)
      StorageSharedKeyCredential storageCredentials =
          new StorageSharedKeyCredential(storageArguement.AzureStorageKeyName, storageArguement.AzureStorageKeyName);

      // Create the blob client.
      BlobClient blobClient = new BlobClient(blobUri, storageCredentials);
      fileStream.Position = 0;
      // Upload the file
      await blobClient.UploadAsync(fileStream);



      if (await Task.FromResult(true))
      {
        return blobUri.AbsoluteUri;
      }
      else
      {
        return "upload failed";
      }
    }
  }

  public class StorageArguement
  {
    public string AzureStorageKeyName { get; set; }
    public string AzureNameKeyKey { get; set; }
  }
}
