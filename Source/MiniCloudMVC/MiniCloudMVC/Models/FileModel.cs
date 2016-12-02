using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Model;
using File = Model.File;

namespace MiniCloudMVC.Models
{
    public class FileModel
    {
        static string existingBucketName = "itbw8minicloud";
        private DateTime Expiration = DateTime.Now.AddHours(36);
        private AmazonS3Client client = new AmazonS3Client(Amazon.RegionEndpoint.EUCentral1);

        public FileModel()
        {
                
        }

        public FileModel(string path, string fileName, string userId)
        {
            Path = path;
            FileName = fileName;
            OwnerId = userId;
        }

        public string FileName { get; set; }

        public string FileOwner { get; set; }

        public string Path { get; set; }

        public string FileLink { get; set; }

        public string Size { get; set; }

        public DateTime CreationDate { get; set; }

        public string OwnerId { get; set; }

        public void Upload()
        {
            try
            {
                var fileTransferUtility = new TransferUtility(client);

                fileTransferUtility.Upload(Path, existingBucketName, FileName);

                DownloadMetaDataFromAmazon();
            }
            catch (AmazonS3Exception s3Exception)
            {
                Console.WriteLine(s3Exception.Message, s3Exception.InnerException);
            }
        }

        private void DownloadMetaDataFromAmazon()
        {
            var request = new GetObjectMetadataRequest
            {
                Key = FileName,
                BucketName = existingBucketName
            };

            var response = client.GetObjectMetadata(request);

            UploadMetaDataToSql(response);
        }

        private void UploadMetaDataToSql(GetObjectMetadataResponse response)
        {
            using (var context = new MiniCloudEntities())
            {
                var file = new File
                {
                    Name = FileName,
                    FileSizeInByte = response.ContentLength.ToString(),
                    CreationDate = response.LastModified,
                    Uri = GetS3Url(),
                    OwnerId = OwnerId
                };

                context.Files.Add(file);
                context.SaveChanges();
            }
        }

        public string GetS3Url()
        {
            var linkrequest = new GetPreSignedUrlRequest
            {
                BucketName = existingBucketName,
                Key = FileName,
                Expires = Expiration,
                Protocol = Protocol.HTTP
            };

            var linkResponse = client.GetPreSignedURL(linkrequest);

            return linkResponse;
        }
    }
}