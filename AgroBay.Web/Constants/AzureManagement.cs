using AgroBay.Core.Services;

namespace AgroBay.Web.Constants
{
    public interface IAzureManagement
    {
        StorageArguement GetArguement();
    }

    public class AzureManagement : IAzureManagement
    {
        private IConfiguration _config;
        public AzureManagement(IConfiguration configRoot)
        {
            _config = configRoot;
        }

        public StorageArguement GetArguement()
        {
            StorageArguement storageArguement = new StorageArguement()
            {
                AzureNameKeyKey = _config["AzureStorage:key_1"],
                AzureContainerName = _config["AzureStorage:name"]
            };

            return storageArguement;
        }


    }
}
