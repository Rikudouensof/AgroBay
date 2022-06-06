namespace AgroBay.Core.Services.Interface
{
  public interface IStorageService
  {
    Task<string> DeleteFile(StorageArguement storageArguement, string fileName);
    string UploadFileToStorage(Stream fileStream, string fileName, string blobName);
  }
}