using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

// Token: 0x0200012A RID: 298
public class FileArchiveAccessor
{
	// Token: 0x0600087F RID: 2175 RVA: 0x0002DA92 File Offset: 0x0002BE92
	public static void SetFileArchivePath(string dataPath, string readOnlyPath, string readWritePath)
	{
		FileArchiveAccessor.DataPath = dataPath;
		FileArchiveAccessor.ReadOnlyPath = readOnlyPath;
		FileArchiveAccessor.ReadWritePath = readWritePath;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x0002DAA6 File Offset: 0x0002BEA6
	public static bool SaveFileInLocalFileArchive(string fileResRelative, byte[] data)
	{
		return false;
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x0002DAA9 File Offset: 0x0002BEA9
	public static bool SaveFileInLocalFileArchive(string fileResRelative, string data)
	{
		return false;
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x0002DAAC File Offset: 0x0002BEAC
	public static bool LoadFileInLocalFileArchive(string fileResRelative, out byte[] data)
	{
		return FileArchiveAccessor._LoadFileWithFileArchive(FileArchiveAccessor._GetLocalUrlProtocol(), fileResRelative, out data);
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x0002DABA File Offset: 0x0002BEBA
	public static bool LoadFileInLocalFileArchive(string fileResRelative, out string data)
	{
		return FileArchiveAccessor._LoadFileWithFileArchive(FileArchiveAccessor._GetLocalUrlProtocol(), fileResRelative, out data);
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x0002DAC8 File Offset: 0x0002BEC8
	public static bool SaveFileInPersistentFileArchive(string fileResRelative, byte[] data)
	{
		return FileArchiveAccessor._SaveFileWithFileArchive(FileArchiveAccessor._GetPersistentStreamPath(), fileResRelative, data);
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x0002DAD6 File Offset: 0x0002BED6
	public static bool SaveFileInPersistentFileArchive(string fileResRelative, string data)
	{
		return FileArchiveAccessor._SaveFileWithFileArchive(FileArchiveAccessor._GetPersistentStreamPath(), fileResRelative, data);
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x0002DAE4 File Offset: 0x0002BEE4
	public static bool LoadFileInPersistentFileArchive(string fileResRelative, out byte[] data)
	{
		return FileArchiveAccessor._LoadFileWithFileArchive(FileArchiveAccessor._GetPersistentUrlProtocol(), fileResRelative, out data);
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x0002DAF2 File Offset: 0x0002BEF2
	public static bool LoadFileInPersistentFileArchive(string fileResRelative, out string data)
	{
		return FileArchiveAccessor._LoadFileWithFileArchive(FileArchiveAccessor._GetPersistentUrlProtocol(), fileResRelative, out data);
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x0002DB00 File Offset: 0x0002BF00
	protected static bool _SaveFileWithFileArchive(string archivePath, string fileResRelative, byte[] data)
	{
		string text = Path.Combine(archivePath, fileResRelative);
		int num = 0;
		bool result;
		for (;;)
		{
			try
			{
				File.WriteAllBytes(text, data);
				result = true;
				break;
			}
			catch (Exception ex)
			{
				num++;
				if (num >= 3)
				{
					Logger.LogError("Write File " + text + " Error! Exception = " + ex.ToString());
					if (File.Exists(text))
					{
						File.Delete(text);
					}
					result = false;
					break;
				}
			}
		}
		return result;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x0002DB80 File Offset: 0x0002BF80
	protected static bool _SaveFileWithFileArchive(string archivePath, string fileResRelative, string data)
	{
		return FileArchiveAccessor._SaveFileWithFileArchive(archivePath, fileResRelative, Encoding.Default.GetBytes(data));
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x0002DB94 File Offset: 0x0002BF94
	protected static bool _LoadFileWithFileArchive(string archivePath, string fileResRelative, out byte[] data)
	{
		string text = Path.Combine(archivePath, fileResRelative);
		bool result = false;
		data = null;
		WWW www = new WWW(text);
		while (!www.isDone)
		{
		}
		if (string.IsNullOrEmpty(www.error))
		{
			List<byte> list = new List<byte>();
			list.AddRange(www.bytes);
			data = list.ToArray();
			result = true;
		}
		www.Dispose();
		return result;
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x0002DBF8 File Offset: 0x0002BFF8
	protected static bool _LoadFileWithFileArchive(string archivePath, string fileResRelative, out string data)
	{
		string text = Path.Combine(archivePath, fileResRelative);
		bool result = false;
		data = null;
		WWW www = new WWW(text);
		while (!www.isDone)
		{
		}
		if (string.IsNullOrEmpty(www.error))
		{
			data = www.text;
			result = true;
		}
		www.Dispose();
		return result;
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x0002DC4A File Offset: 0x0002C04A
	protected static string _GetLocalUrlProtocol()
	{
		return "jar:file://" + FileArchiveAccessor.DataPath + "!/assets/";
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x0002DC60 File Offset: 0x0002C060
	protected static string _GetPersistentUrlProtocol()
	{
		return "file://" + FileArchiveAccessor.ReadWritePath;
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x0002DC71 File Offset: 0x0002C071
	protected static string _GetLocalStreamPath()
	{
		return FileArchiveAccessor.ReadOnlyPath;
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x0002DC78 File Offset: 0x0002C078
	protected static string _GetPersistentStreamPath()
	{
		return FileArchiveAccessor.ReadWritePath;
	}

	// Token: 0x04000568 RID: 1384
	private static string DataPath = string.Empty;

	// Token: 0x04000569 RID: 1385
	private static string ReadOnlyPath = string.Empty;

	// Token: 0x0400056A RID: 1386
	private static string ReadWritePath = string.Empty;
}
