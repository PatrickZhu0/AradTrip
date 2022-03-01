using System;
using System.IO;
using System.Text;
using LibZip;

namespace Tenmove
{
	// Token: 0x020001A8 RID: 424
	public class TMZipFile
	{
		// Token: 0x06000DBF RID: 3519 RVA: 0x00047764 File Offset: 0x00045B64
		public static bool FileExist(string zipFilePath, string strZipFilePath)
		{
			if (!TMFile.FileExist(zipFilePath))
			{
				Logger.LogErrorFormat("zip package not found: {0}", new object[]
				{
					zipFilePath
				});
				return false;
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = LibZip.zip_fopen(zero, strZipFilePath, 0);
			if (intPtr == IntPtr.Zero)
			{
				Logger.LogError("zip file not found: " + Path.Combine(zipFilePath, strZipFilePath));
				return false;
			}
			LibZip.zip_fclose(intPtr);
			return true;
		}

		// Token: 0x06000DC0 RID: 3520 RVA: 0x000477D4 File Offset: 0x00045BD4
		public static bool ReadAllText(string zipFilePath, string strZipFilePath, ref string ans)
		{
			byte[] bytes = null;
			long num = -1L;
			if (TMZipFile.Read(zipFilePath, strZipFilePath, ref bytes, ref num))
			{
				return false;
			}
			ans = Encoding.UTF8.GetString(bytes);
			return true;
		}

		// Token: 0x06000DC1 RID: 3521 RVA: 0x00047808 File Offset: 0x00045C08
		public static bool Read(string zipFilePath, string strZipFilePath, ref byte[] outBuffer, ref long iBufferSize)
		{
			outBuffer = TMZipFile.skEmptyBuffer;
			iBufferSize = 0L;
			if (!TMFile.FileExist(zipFilePath))
			{
				Logger.LogError("zip package not found: " + zipFilePath);
				return false;
			}
			IntPtr zero = IntPtr.Zero;
			IntPtr intPtr = LibZip.zip_fopen(zero, strZipFilePath, 0);
			if (intPtr == IntPtr.Zero)
			{
				Logger.LogError("zip file not found: " + Path.Combine(zipFilePath, strZipFilePath));
				return false;
			}
			long num = TMZipFile._GetZipRelativeFileSize(zero, strZipFilePath);
			outBuffer = new byte[num + 1L];
			outBuffer[(int)(checked((IntPtr)num))] = 0;
			iBufferSize = num + 1L;
			long num2 = LibZip.zip_fread(intPtr, outBuffer, num);
			LibZip.zip_fclose(intPtr);
			return true;
		}

		// Token: 0x06000DC2 RID: 3522 RVA: 0x000478AC File Offset: 0x00045CAC
		private static long _GetZipRelativeFileSize(IntPtr zipPtr, string relativePath)
		{
			zip_stat zip_stat = default(zip_stat);
			LibZip.zip_stat(zipPtr, relativePath, 0, ref zip_stat);
			return zip_stat.size;
		}

		// Token: 0x06000DC3 RID: 3523 RVA: 0x000478D4 File Offset: 0x00045CD4
		public static bool CompressFiles(string target, string root, string[] files)
		{
			if (files == null || files.Length == 0)
			{
				Logger.LogErrorFormat("[Zip] CompressFiles file list is empty", new object[0]);
				return false;
			}
			IntPtr intPtr = IntPtr.Zero;
			intPtr = LibZip.zip_open(target, 1, IntPtr.Zero);
			if (IntPtr.Zero == intPtr)
			{
				Logger.LogErrorFormat("[Zip] CompressFiles Open File fail {0}", new object[]
				{
					target
				});
				return false;
			}
			for (int i = 0; i < files.Length; i++)
			{
				TMZipFile.WriteOneFile2ZipSource(intPtr, root, files[i]);
			}
			LibZip.zip_close(intPtr);
			return true;
		}

		// Token: 0x06000DC4 RID: 3524 RVA: 0x00047964 File Offset: 0x00045D64
		public static bool WriteOneFile2ZipSource(IntPtr zipPtr, string root, string filePath)
		{
			if (!File.Exists(filePath))
			{
				return false;
			}
			if (IntPtr.Zero == zipPtr)
			{
				return false;
			}
			IntPtr intPtr = LibZip.zip_source_file(zipPtr, filePath, 0L, 0L);
			if (IntPtr.Zero == intPtr)
			{
				Logger.LogErrorFormat("[Zip] zip_source_file error {0}", new object[]
				{
					filePath
				});
				return false;
			}
			if (LibZip.zip_source_begin_write(intPtr) != 0)
			{
				Logger.LogErrorFormat("[Zip] zip_source_begin_write error {0}", new object[]
				{
					filePath
				});
				return false;
			}
			FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			long num = 0L;
			int num2;
			int num3;
			for (;;)
			{
				num2 = fileStream.Read(TMZipFile.skReadBuff, 0, TMZipFile.skReadBuffSize);
				if (num2 <= 0)
				{
					break;
				}
				num3 = LibZip.zip_source_write(intPtr, TMZipFile.skReadBuff, (long)num2);
				if (num3 != num2)
				{
					goto Block_6;
				}
				num += (long)num2;
			}
			string name = filePath.Substring(root.Length, filePath.Length - root.Length);
			long num4 = LibZip.zip_file_add(zipPtr, name, intPtr, 8192);
			if (num4 < 0L)
			{
				Logger.LogErrorFormat("[Zip] CompressFiles Add File fail {0}", new object[]
				{
					filePath
				});
				fileStream.Close();
				LibZip.zip_source_rollback_write(intPtr);
				return false;
			}
			fileStream.Close();
			LibZip.zip_source_commit_write(intPtr);
			return true;
			Block_6:
			Logger.LogErrorFormat("[Zip] zip_source_write write file size error {0}  {1} != {2}", new object[]
			{
				filePath,
				num2,
				num3
			});
			fileStream.Close();
			LibZip.zip_source_rollback_write(intPtr);
			return false;
		}

		// Token: 0x0400099D RID: 2461
		public const string FULL_STORAGE_TIPS = "手机空间不足，建议清理后重试";

		// Token: 0x0400099E RID: 2462
		private static byte[] skEmptyBuffer = new byte[0];

		// Token: 0x0400099F RID: 2463
		private static string TAG = "ZipFileReader";

		// Token: 0x040009A0 RID: 2464
		public static readonly int skReadBuffSize = 4096;

		// Token: 0x040009A1 RID: 2465
		private static byte[] skReadBuff = new byte[TMZipFile.skReadBuffSize];
	}
}
