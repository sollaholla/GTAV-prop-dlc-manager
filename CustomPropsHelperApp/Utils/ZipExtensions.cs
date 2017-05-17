using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace CustomPropsHelperApp.Utils
{
	public static class ZipExtensions
	{
		public static ZipArchiveEntry CreateEntryFromFolder(this ZipArchive destination, string sourceFolderName, string entryName)
		{
			return CreateEntryFromFolder(destination, sourceFolderName, entryName, CompressionLevel.Fastest);
		}

		public static ZipArchiveEntry CreateEntryFromFolder(this ZipArchive destination, string sourceFolderName, string entryName, CompressionLevel compressionLevel)
		{
			string sourceFolderFullPath = Path.GetFullPath(sourceFolderName);
			string basePath = entryName + "/";

			var createdFolders = new HashSet<string>();

			var entry = destination.CreateEntry(basePath);
			createdFolders.Add(basePath);

			foreach (string dirFolder in Directory.EnumerateDirectories(sourceFolderName, "*.*", SearchOption.AllDirectories))
			{
				string dirFileFullPath = Path.GetFullPath(dirFolder);
				string relativePath = (basePath + dirFileFullPath.Replace(sourceFolderFullPath + Path.DirectorySeparatorChar, ""))
					.Replace(Path.DirectorySeparatorChar, '/');
				string relativePathSlash = relativePath + "/";

				if (!createdFolders.Contains(relativePathSlash))
				{
					destination.CreateEntry(relativePathSlash, compressionLevel);
					createdFolders.Add(relativePathSlash);
				}
			}

			foreach (string dirFile in Directory.EnumerateFiles(sourceFolderName, "*.*", SearchOption.AllDirectories))
			{
				string dirFileFullPath = Path.GetFullPath(dirFile);
				string relativePath = (basePath + dirFileFullPath.Replace(sourceFolderFullPath + Path.DirectorySeparatorChar, ""))
					.Replace(Path.DirectorySeparatorChar, '/');
				destination.CreateEntryFromFile(dirFile, relativePath, compressionLevel);
			}

			return entry;
		}
	}
}
