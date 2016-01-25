using System;

namespace BlobTestDemo

{
    public class User
    {
        public string Name { get; set; }
        public string Uid { get; set; }
    }

    internal class Program
    {
        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        private static void Main(string[] args)
        {
            //   /*
            //     <add key="DataStorageConnectionString"
            //value="BlobEndpoint=https://jymstoredev.blob.core.chinacloudapi.cn/;QueueEndpoint=https://jymstoredev.queue.core.chinacloudapi.cn/;TableEndpoint=https://jymstoredev.table.core.chinacloudapi.cn/;AccountName=jymstoredev;AccountKey=1dCLRLeIeUlLAIBsS9rYdCyFg3UNU239MkwzNOj3BYbREOlnBmM4kfTPrgvKDhSmh6sRp2MdkEYJTv4Ht3fCcg==" />

            //   */
            //   // Retrieve storage account from connection string.
            //   //CloudStorageAccount storageAccount = CloudStorageAccount.Parse("BlobEndpoint=https://jymstoredev.blob.core.chinacloudapi.cn/;QueueEndpoint=https://jymstoredev.queue.core.chinacloudapi.cn/;TableEndpoint=https://jymstoredev.table.core.chinacloudapi.cn/;AccountName=jymstoredev;AccountKey=1dCLRLeIeUlLAIBsS9rYdCyFg3UNU239MkwzNOj3BYbREOlnBmM4kfTPrgvKDhSmh6sRp2MdkEYJTv4Ht3fCcg==");
            //   CloudStorageAccount storageAccount = CloudStorageAccount.Parse("DataStorageConnectionString");

            //   // Create the blob client.
            //   CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            //   // Retrieve reference to a previously created container.
            //   CloudBlobContainer container = blobClient.GetContainerReference("testdemo");

            //   for (int i = 0; i < 10; ++i)
            //   {
            //       // Retrieve reference to a blob named "myblob".
            //       CloudBlockBlob blockBlob = container.GetBlockBlobReference(Guid.NewGuid().ToString());

            //       // Create or overwrite the "myblob" blob with contents from a local file.
            //       using (var fileStream = File.OpenRead(@"path\test.txt"))
            //       {
            //           blockBlob.UploadFromStream(fileStream);
            //       }
            //       Console.WriteLine(i);
            //   }

            //for (int i = 0; i < 50; ++i)
            //{
            //    var i1 = i;
            //    Task.Run(async () => await
            //        AzureBlobStorageProvider.WriteToBlob("testdemo", i1.ToString(), new User
            //        {
            //            Uid = i1.ToString(),
            //            Name = Guid.NewGuid().ToString()
            //        }));

            //    Console.WriteLine(i);
            //}

            var container = AzureBlobStorageProvider.GetContainer("applogs-jym-web-dev-sms");
            foreach (var it in container.ListBlobs())
            {
                Console.WriteLine(it.Uri);
            }

            Console.ReadLine();
        }
    }
}