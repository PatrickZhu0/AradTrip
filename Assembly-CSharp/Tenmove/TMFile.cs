using System;
using System.IO;

namespace Tenmove
{
	// Token: 0x020001A9 RID: 425
	public class TMFile
	{
		// Token: 0x06000DC7 RID: 3527 RVA: 0x00047AFF File Offset: 0x00045EFF
		public static bool FileExist(string path)
		{
			return File.Exists(path);
		}

		// Token: 0x06000DC8 RID: 3528 RVA: 0x00047B08 File Offset: 0x00045F08
		public static string[] GetFiles(string root, string filter = "*", bool isAllDirectories = true)
		{
			try
			{
				SearchOption searchOption = SearchOption.TopDirectoryOnly;
				if (isAllDirectories)
				{
					searchOption = SearchOption.AllDirectories;
				}
				return Directory.GetFiles(root, filter, searchOption);
			}
			catch (Exception ex)
			{
			}
			return new string[0];
		}

		// Token: 0x06000DC9 RID: 3529 RVA: 0x00047B50 File Offset: 0x00045F50
		public static bool ReadAllTextRelativeDataPath(string relativePath, out string content)
		{
			content = string.Empty;
			return false;
		}

		// Token: 0x06000DCA RID: 3530 RVA: 0x00047B5C File Offset: 0x00045F5C
		public static byte[] ReadAllBytes(string filePath)
		{
			if (File.Exists(filePath))
			{
				try
				{
					return File.ReadAllBytes(filePath);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat(ex.ToString(), new object[0]);
				}
			}
			return new byte[0];
		}

		// Token: 0x06000DCB RID: 3531 RVA: 0x00047BB0 File Offset: 0x00045FB0
		public static bool ReadAllText(string filePath, out string content)
		{
			if (File.Exists(filePath))
			{
				try
				{
					content = File.ReadAllText(filePath);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat(ex.ToString(), new object[0]);
				}
			}
			content = string.Empty;
			return false;
		}

		// Token: 0x06000DCC RID: 3532 RVA: 0x00047C04 File Offset: 0x00046004
		public static void WriteAllContents(string filePath, string content)
		{
			TMPathUtil.MakeParentRootExist(filePath);
			File.WriteAllText(filePath, content);
		}

		// Token: 0x06000DCD RID: 3533 RVA: 0x00047C13 File Offset: 0x00046013
		public static void AppendAllContents(string filePath, string content)
		{
			TMPathUtil.MakeParentRootExist(filePath);
			File.AppendAllText(filePath, content);
		}
	}
}
