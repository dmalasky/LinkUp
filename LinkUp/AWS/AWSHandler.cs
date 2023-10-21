using Amazon.S3.Transfer;
using Amazon.S3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using ThreadNetwork;
using System.ComponentModel;
using MetalPerformanceShaders;
using Amazon.S3.Model;

namespace LinkUp
{
	internal static class AWSHandler
	{
		const string bucketName = "linkup-user-data"; // Replace with your bucket name
		const string s3FolderPath = "folder-in-s3"; // Replace with your desired S3 folder key name
		static Amazon.RegionEndpoint amazonServer = Amazon.RegionEndpoint.USEast1;

		static async void UploadSingle(string filePath)
		{
			var s3Client = new AmazonS3Client(amazonServer); // Replace with your desired region
			var fileTransferUtility = new TransferUtility(s3Client);
			
			var keyName = Path.Combine(s3FolderPath, Path.GetFileName(filePath));
			await fileTransferUtility.UploadAsync(filePath, bucketName, keyName);
			
		}
		static void UploadMultiple(List<string> fileList)
		{
			foreach (var file in fileList)
			{
				UploadSingle(file);
			}
		}

		private static async Task<Amazon.S3.Model.ListObjectsResponse> GetObjectsAsync(string folderToSearch)
		{
			var s3Client = new AmazonS3Client(amazonServer);
			return await s3Client.ListObjectsAsync(bucketName, folderToSearch);
		}
		public static List<string> GetObjectsInCloudFolder(string folderToSearch)
		{
			ListObjectsResponse s3Objects = GetObjectsAsync(folderToSearch).Result;
			List<string> fileNames = s3Objects.S3Objects.Select(o => o.Key).ToList();
			return fileNames;
		}

		static async void DownloadSingle(string folder, string filename)
		{
			var s3Client = new AmazonS3Client(amazonServer); // Replace with your desired region
			var fileTransferUtility = new TransferUtility(s3Client);

			await fileTransferUtility.DownloadAsync(folder, bucketName, filename);
			Console.WriteLine($"File {filename} downloaded to {folder} from the bucket.");
		}

		static void DownloadMultiple(string folder, List<string> fileList)
		{
			foreach(var file in fileList)
				DownloadSingle(folder, file);
		}
	}
}