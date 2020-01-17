using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace StorageFileUpload
{
    public class AmazonS3UploadFile
    {
        private static AmazonS3Client _s3Client;
        private static string _AwsBucketName;

        public AmazonS3UploadFile()
        {
            /* Environment Variables to set (sample):
             * "AWS_ACCESS_KEY_ID": "--AKIA5J71TNDA53PISACAUXJ",
             * "AWS_SECRET_ACCESS_KEY": "KaPS/59PPOSUGm1SowWxu0iQFL5jPhJcBXZAPXQoQ89Vt",
             */

            var AwsBucketName = Environment.GetEnvironmentVariable("AWS_BUCKET_NAME");

            var hasErrors = new List<string>();

            if (AwsBucketName == null)
                hasErrors.Add($"{nameof(AwsBucketName)} variável de ambiente não pode ser nula");

            if (hasErrors.Count > 0)
                throw new InternalServerError(string.Join(" | ", hasErrors.ToArray()));

            _AwsBucketName = AwsBucketName;

            var credentials = new EnvironmentVariablesAWSCredentials();
            Amazon.RegionEndpoint region = Amazon.RegionEndpoint.USEast1;
            _s3Client = new AmazonS3Client(credentials, region);
        }

        public async Task<string> UploadDocument(string fileNameKey, IFormFile document)
        {
            return await AwsStorageUpload(fileNameKey, document);
        }

        public string GetDocumentUrl(string fileNameKey)
        {
            return AwsStorageGetUrl(fileNameKey);
        }

        private async Task<string> AwsStorageUpload(string fileNameKey, IFormFile docFile)
        {
            using (var fileToUpload = docFile.OpenReadStream())
            {
                var uploadRequest = new PutObjectRequest
                {
                    BucketName = _cashTagAwsBucketName,
                    InputStream = fileToUpload,
                    Key = fileNameKey
                };

                var response = await _s3Client.PutObjectAsync(uploadRequest);
                return fileNameKey;
            }
        }

        private string AwsStorageGetUrl(string fileNameKey)
        {
            var getObjectRequest = new GetPreSignedUrlRequest
            {
                BucketName = _cashTagAwsBucketName,
                Key = fileNameKey,
                Expires = DateTime.UtcNow.AddDays(1)
            };

            var url = _s3Client.GetPreSignedURL(getObjectRequest);
            return url;
        }
    }
}
