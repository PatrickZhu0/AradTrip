using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using LibZip;
using UnityEngine;

// Token: 0x02000105 RID: 261
public class CFileManager
{
	// Token: 0x0600059D RID: 1437 RVA: 0x0002445C File Offset: 0x0002285C
	public static bool ClearDirectory(string fullPath)
	{
		bool result;
		try
		{
			string[] files = Directory.GetFiles(fullPath);
			for (int i = 0; i < files.Length; i++)
			{
				File.Delete(files[i]);
			}
			string[] directories = Directory.GetDirectories(fullPath);
			for (int j = 0; j < directories.Length; j++)
			{
				Directory.Delete(directories[j], true);
			}
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x000244D4 File Offset: 0x000228D4
	public static bool ClearDirectory(string fullPath, string[] fileExtensionFilter, string[] folderFilter)
	{
		bool result;
		try
		{
			if (fileExtensionFilter != null)
			{
				string[] files = Directory.GetFiles(fullPath);
				for (int i = 0; i < files.Length; i++)
				{
					if (fileExtensionFilter != null && fileExtensionFilter.Length > 0)
					{
						for (int j = 0; j < fileExtensionFilter.Length; j++)
						{
							if (files[i].Contains(fileExtensionFilter[j]))
							{
								CFileManager.DeleteFile(files[i]);
								break;
							}
						}
					}
				}
			}
			if (folderFilter != null)
			{
				string[] directories = Directory.GetDirectories(fullPath);
				for (int k = 0; k < directories.Length; k++)
				{
					if (folderFilter != null && folderFilter.Length > 0)
					{
						for (int l = 0; l < folderFilter.Length; l++)
						{
							if (directories[k].Contains(folderFilter[l]))
							{
								CFileManager.DeleteDirectory(directories[k]);
								break;
							}
						}
					}
				}
			}
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x000245D4 File Offset: 0x000229D4
	public static string CombinePath(string path1, string path2)
	{
		if (path1.LastIndexOf('/') != path1.Length - 1)
		{
			path1 += "/";
		}
		if (path2.IndexOf('/') == 0)
		{
			path2 = path2.Substring(1);
		}
		return path1 + path2;
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00024620 File Offset: 0x00022A20
	public static string CombinePaths(params string[] values)
	{
		if (values.Length <= 0)
		{
			return string.Empty;
		}
		if (values.Length == 1)
		{
			return CFileManager.CombinePath(values[0], string.Empty);
		}
		if (values.Length <= 1)
		{
			return string.Empty;
		}
		string text = CFileManager.CombinePath(values[0], values[1]);
		for (int i = 2; i < values.Length; i++)
		{
			text = CFileManager.CombinePath(text, values[i]);
		}
		return text;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0002468D File Offset: 0x00022A8D
	public static void CopyFile(string srcFile, string dstFile)
	{
		File.Copy(srcFile, dstFile, true);
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00024698 File Offset: 0x00022A98
	public static bool CreateDirectory(string directory)
	{
		if (CFileManager.IsDirectoryExist(directory))
		{
			return true;
		}
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				Directory.CreateDirectory(directory);
				result = true;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x000246F0 File Offset: 0x00022AF0
	public static bool DeleteDirectory(string directory)
	{
		if (!CFileManager.IsDirectoryExist(directory))
		{
			return true;
		}
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				Directory.Delete(directory, true);
				result = true;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00024748 File Offset: 0x00022B48
	public static bool DeleteFile(string filePath)
	{
		if (!CFileManager.IsFileExist(filePath))
		{
			return true;
		}
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				File.Delete(filePath);
				result = true;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060005A5 RID: 1445 RVA: 0x000247A0 File Offset: 0x00022BA0
	public static string EraseExtension(string fullName)
	{
		if (fullName == null)
		{
			return null;
		}
		int num = fullName.LastIndexOf('.');
		if (num > 0)
		{
			return fullName.Substring(0, num);
		}
		return fullName;
	}

	// Token: 0x060005A6 RID: 1446 RVA: 0x000247CF File Offset: 0x00022BCF
	public static string GetCachePath()
	{
		if (CFileManager.s_cachePath == null)
		{
			CFileManager.s_cachePath = Application.persistentDataPath;
		}
		return CFileManager.s_cachePath;
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x000247EA File Offset: 0x00022BEA
	public static string GetCachePath(string fileName)
	{
		return CFileManager.CombinePath(CFileManager.GetCachePath(), fileName);
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x000247F7 File Offset: 0x00022BF7
	public static string GetCachePathWithHeader(string fileName)
	{
		return CFileManager.GetLocalPathHeader() + CFileManager.GetCachePath(fileName);
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x0002480C File Offset: 0x00022C0C
	public static string GetExtension(string fullName)
	{
		int num = fullName.LastIndexOf('.');
		if (num > 0 && num + 1 < fullName.Length)
		{
			return fullName.Substring(num);
		}
		return string.Empty;
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00024844 File Offset: 0x00022C44
	public static int GetFileLength(string filePath)
	{
		if (!CFileManager.IsFileExist(filePath))
		{
			return 0;
		}
		int num = 0;
		int result;
		for (;;)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(filePath);
				result = (int)fileInfo.Length;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					result = 0;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x000248A4 File Offset: 0x00022CA4
	public static string GetFileMd5(string filePath)
	{
		if (!CFileManager.IsFileExist(filePath))
		{
			return string.Empty;
		}
		return BitConverter.ToString(CFileManager.s_md5Provider.ComputeHash(CFileManager.ReadFile(filePath))).Replace("-", string.Empty);
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x000248DB File Offset: 0x00022CDB
	public static string GetFullDirectory(string fullPath)
	{
		return Path.GetDirectoryName(fullPath);
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x000248E4 File Offset: 0x00022CE4
	public static string GetFullName(string fullPath)
	{
		if (fullPath == null)
		{
			return null;
		}
		int num = fullPath.LastIndexOf("/");
		if (num > 0)
		{
			return fullPath.Substring(num + 1, fullPath.Length - num - 1);
		}
		return fullPath;
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00024921 File Offset: 0x00022D21
	public static string GetIFSExtractPath()
	{
		if (CFileManager.s_ifsExtractPath == null)
		{
			CFileManager.s_ifsExtractPath = CFileManager.CombinePath(CFileManager.GetCachePath(), CFileManager.s_ifsExtractFolder);
		}
		return CFileManager.s_ifsExtractPath;
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00024946 File Offset: 0x00022D46
	private static string GetLocalPathHeader()
	{
		return "file://";
	}

	// Token: 0x060005B0 RID: 1456 RVA: 0x0002494D File Offset: 0x00022D4D
	public static string GetMd5(byte[] data)
	{
		return BitConverter.ToString(CFileManager.s_md5Provider.ComputeHash(data)).Replace("-", string.Empty);
	}

	// Token: 0x060005B1 RID: 1457 RVA: 0x0002496E File Offset: 0x00022D6E
	public static string GetMd5(string str)
	{
		return BitConverter.ToString(CFileManager.s_md5Provider.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", string.Empty);
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x00024999 File Offset: 0x00022D99
	public static string GetStreamingAssetsPathWithHeader(string fileName)
	{
		return Path.Combine(Application.streamingAssetsPath, fileName);
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x000249A6 File Offset: 0x00022DA6
	public static bool IsDirectoryExist(string directory)
	{
		return Directory.Exists(directory);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x000249AE File Offset: 0x00022DAE
	public static bool IsFileExist(string filePath)
	{
		return LibZipFileReader.FileExist(filePath);
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x000249B8 File Offset: 0x00022DB8
	public static byte[] ReadFileFromZip(string filePath)
	{
		if (LibZipFileReader.FileExist(filePath))
		{
			byte[] result = null;
			long num = 0L;
			if (LibZipFileReader.Read(filePath, ref result, ref num))
			{
				return result;
			}
		}
		return null;
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x000249E8 File Offset: 0x00022DE8
	public static byte[] ReadFile(string filePath)
	{
		if (CFileManager.IsFileExist(filePath))
		{
			byte[] array = null;
			int num = 0;
			for (;;)
			{
				try
				{
					array = File.ReadAllBytes(filePath);
				}
				catch (Exception ex)
				{
					array = null;
				}
				if (array != null && array.Length > 0)
				{
					break;
				}
				num++;
				if (num >= 3)
				{
					goto IL_3F;
				}
			}
			return array;
		}
		IL_3F:
		return null;
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00024A48 File Offset: 0x00022E48
	public static bool WriteFile(string filePath, byte[] data)
	{
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				File.WriteAllBytes(filePath, data);
				result = true;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					Logger.LogError("Write File " + filePath + " Error! Exception = " + ex.ToString());
					CFileManager.DeleteFile(filePath);
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x00024AB8 File Offset: 0x00022EB8
	public static bool WriteFile(string filePath, byte[] data, int offset, int length)
	{
		FileStream fileStream = null;
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite);
				fileStream.Write(data, offset, length);
				fileStream.Close();
				result = true;
				break;
			}
			catch (Exception ex)
			{
				if (fileStream != null)
				{
					fileStream.Close();
				}
				num++;
				if (num >= 3)
				{
					CFileManager.DeleteFile(filePath);
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x040004EE RID: 1262
	[CompilerGenerated]
	private static string s_cachePath = null;

	// Token: 0x040004EF RID: 1263
	public static string s_ifsExtractFolder = "Resources";

	// Token: 0x040004F0 RID: 1264
	private static string s_ifsExtractPath = null;

	// Token: 0x040004F1 RID: 1265
	private static MD5CryptoServiceProvider s_md5Provider = new MD5CryptoServiceProvider();

	// Token: 0x02000106 RID: 262
	// (Invoke) Token: 0x060005BB RID: 1467
	public delegate void DelegateOnOperateFileFail(string fullPath, enFileOperation fileOperation);
}
