using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Services.Samples.AzureUpload
{
    public class AzureUploadFile
    {
        private async Task<string> AzureStorageUploadSample(string fileName, IFormFile document)
        {
            var internalServerErrorMessage = "Erro ao tentar efetuar upload de arquivo";

            try
            {
                var BLOB_CONNECTION_STRING = Environment.GetEnvironmentVariable("BLOB_CONNECTION_STRING");
                var BLOB_CONTAINER_NAME = Environment.GetEnvironmentVariable("BLOB_CONTAINER_NAME");

                var hasErrors = new List<string>();

                if (BLOB_CONNECTION_STRING == null)
                    hasErrors.Add($"{nameof(BLOB_CONNECTION_STRING)} variável de ambiente não pode ser nula");

                if (BLOB_CONTAINER_NAME == null)
                    hasErrors.Add($"{nameof(BLOB_CONTAINER_NAME)} variável de ambiente não pode ser nula");

                if (hasErrors.Count > 0)
                    throw new InternalServerError(string.Join(" | ", hasErrors.ToArray()));

                var storageAccount = CloudStorageAccount.Parse(BLOB_CONNECTION_STRING);
                var myClient = storageAccount.CreateCloudBlobClient();
                var container = myClient.GetContainerReference(BLOB_CONTAINER_NAME);
                var blockBlob = container.GetBlockBlobReference(fileName);

                using (var fileStream = document.OpenReadStream())
                    await blockBlob.UploadFromStreamAsync(fileStream);

                return blockBlob.SnapshotQualifiedStorageUri.PrimaryUri.ToString();
            }
            catch (Exception e) when (!(e is BasicException))
            {
                throw new InternalServerError(internalServerErrorMessage);
            }
        }
    }
}
