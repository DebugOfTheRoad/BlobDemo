using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlobTestDemo
{
    public static class AzureBlobStorageProvider
    {
        //public static async Task<IEnumerable<ListBlockItem>> ReadFromBlob(string containerName, string blockName, string connectStringKey = "DataStorageConnectionString")
        //{
        //    var blockBlob = GetContainer(containerName, connectStringKey).GetBlockBlobReference(blockName);
        //    return await blockBlob.DownloadBlockListAsync();
        //}
        public static IEnumerable<ListBlockItem> ReadFromBlob(string containerName, string blockName, string connectStringKey = "DataStorageConnectionString")
        {
            var blockBlob = GetContainer(containerName, connectStringKey).GetBlockBlobReference(blockName);
            return blockBlob.DownloadBlockList();
        }

        public static async Task WriteToBlob(string containerName, string blockName, object data, string connectStringKey = "DataStorageConnectionString")
        {
            var blockBlob = GetContainer(containerName, connectStringKey).GetBlockBlobReference(blockName);
            await blockBlob.UploadTextAsync(JsonConvert.SerializeObject(data));
        }

        #region private helper

        public static CloudBlobContainer GetContainer(string containerName, string connectStringKey = "DataStorageConnectionString")
        {
            var container = GetClient(connectStringKey).GetContainerReference(containerName);
            container.CreateIfNotExists();
            container.SetPermissions(
                new BlobContainerPermissions
                {
                    PublicAccess = BlobContainerPublicAccessType.Blob
                });
            return container;
        }

        private static string Configuration(string key = "DataStorageConnectionString")
        {
            return CloudConfigurationManager.GetSetting(key);
        }

        private static CloudStorageAccount GetAccount(string key = "DataStorageConnectionString")
        {
            return CloudStorageAccount.Parse(Configuration(key));
        }

        private static CloudBlobClient GetClient(string key = "DataStorageConnectionString")
        {
            return GetAccount(key).CreateCloudBlobClient();
        }

        #endregion private helper
    }
}