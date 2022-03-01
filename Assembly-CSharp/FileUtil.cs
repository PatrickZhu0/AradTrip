using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using UnityEngine;

// Token: 0x020000ED RID: 237
public class FileUtil
{
	// Token: 0x060004E9 RID: 1257 RVA: 0x00021A3C File Offset: 0x0001FE3C
	public static string GetFileMD5(string filePath)
	{
		string text = string.Empty;
		if (FileUtil.FileExists(filePath) != -1L)
		{
			FileStream fileStream = File.OpenRead(filePath);
			MD5 md = MD5.Create();
			byte[] array = md.ComputeHash(fileStream);
			for (int i = 0; i < array.Length; i++)
			{
				text += array[i].ToString("x2");
			}
			fileStream.Close();
		}
		return text;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00021AAC File Offset: 0x0001FEAC
	public static IEnumerator GetFileMD5Async(string file)
	{
		FileUtil.md5 = string.Empty;
		if (FileUtil.FileExists(file) != -1L)
		{
			MD5 md5Hash = MD5.Create();
			md5Hash.Initialize();
			yield return FileUtil.WAIT_FOR_EOF;
			FileStream fs = File.OpenRead(file);
			yield return FileUtil.WAIT_FOR_EOF;
			long bytesRead = fs.Length;
			int byteRead = 0;
			byte[] output = new byte[FileUtil.buf.Length];
			while (fs.Position < fs.Length)
			{
				byteRead = fs.Read(FileUtil.buf, 0, FileUtil.buf.Length);
				md5Hash.TransformBlock(FileUtil.buf, 0, byteRead, output, 0);
				yield return FileUtil.WAIT_FOR_EOF;
			}
			md5Hash.TransformFinalBlock(FileUtil.buf, 0, 0);
			yield return FileUtil.WAIT_FOR_EOF;
			byte[] md5Data = md5Hash.Hash;
			for (int i = 0; i < md5Data.Length; i++)
			{
				FileUtil.md5 += md5Data[i].ToString("x2");
			}
			fs.Close();
		}
		yield break;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00021AC8 File Offset: 0x0001FEC8
	public static long GetFileBytes(string path)
	{
		long result = 0L;
		if (FileUtil.FileExists(path) != -1L)
		{
			FileInfo fileInfo = new FileInfo(path);
			result = fileInfo.Length;
		}
		return result;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x00021AF4 File Offset: 0x0001FEF4
	public static long FileExists(string path)
	{
		long result = -1L;
		if (File.Exists(path))
		{
			FileStream fileStream = File.OpenRead(path);
			result = fileStream.Length;
			fileStream.Close();
		}
		return result;
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x00021B24 File Offset: 0x0001FF24
	public static bool HasFile(string path)
	{
		return File.Exists(path);
	}

	// Token: 0x0400047E RID: 1150
	private static byte[] buf = new byte[262144];

	// Token: 0x0400047F RID: 1151
	private static WaitForEndOfFrame WAIT_FOR_EOF = new WaitForEndOfFrame();

	// Token: 0x04000480 RID: 1152
	public static string md5 = string.Empty;
}
