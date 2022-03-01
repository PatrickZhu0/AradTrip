using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LibZip
{
	// Token: 0x020001A6 RID: 422
	internal class LibZipFileReader
	{
		// Token: 0x06000DB4 RID: 3508 RVA: 0x00046F2C File Offset: 0x0004532C
		public static bool FileExist(string strZipFilePath)
		{
			if (LibZipFileReader.zip == IntPtr.Zero)
			{
				LibZipFileReader.zip = LibZip.zip_open(Application.dataPath, 0, IntPtr.Zero);
			}
			if (LibZipFileReader.zip == IntPtr.Zero)
			{
				Logger.LogError("zip package not found: " + Application.dataPath);
				return false;
			}
			string text = Path.Combine("assets", strZipFilePath);
			IntPtr intPtr = LibZip.zip_fopen(LibZipFileReader.zip, text, 0);
			if (intPtr == IntPtr.Zero)
			{
				Logger.LogError("zip file not found: " + Path.Combine(Application.dataPath, text));
				return false;
			}
			LibZip.zip_fclose(intPtr);
			return true;
		}

		// Token: 0x06000DB5 RID: 3509 RVA: 0x00046FDC File Offset: 0x000453DC
		public static bool Read(string strZipFilePath, ref byte[] outBuffer, ref long iBufferSize)
		{
			outBuffer = null;
			iBufferSize = 0L;
			if (LibZipFileReader.zip == IntPtr.Zero)
			{
				LibZipFileReader.zip = LibZip.zip_open(Application.dataPath, 0, IntPtr.Zero);
			}
			if (LibZipFileReader.zip == IntPtr.Zero)
			{
				Logger.LogError("zip package not found: " + Application.dataPath);
				return false;
			}
			string text = Path.Combine("assets", strZipFilePath);
			IntPtr intPtr = LibZip.zip_fopen(LibZipFileReader.zip, text, 0);
			if (intPtr == IntPtr.Zero)
			{
				Logger.LogError("zip file not found: " + Path.Combine(Application.dataPath, text));
				return false;
			}
			zip_stat zip_stat = default(zip_stat);
			LibZip.zip_stat(LibZipFileReader.zip, text, 0, ref zip_stat);
			outBuffer = new byte[zip_stat.size + 1L];
			outBuffer[(int)(checked((IntPtr)zip_stat.size))] = 0;
			iBufferSize = zip_stat.size + 1L;
			long num = LibZip.zip_fread(intPtr, outBuffer, zip_stat.size);
			LibZip.zip_fclose(intPtr);
			return true;
		}

		// Token: 0x06000DB6 RID: 3510 RVA: 0x000470E4 File Offset: 0x000454E4
		public static bool CompressFiles(string target, string[] files)
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
				LibZip.zip_close(intPtr);
				return false;
			}
			for (int i = 0; i < files.Length; i++)
			{
				if (File.Exists(files[i]))
				{
					byte[] array = File.ReadAllBytes(files[i]);
					IntPtr intPtr2 = LibZip.zip_source_buffer(intPtr, array, (long)array.Length, 0);
					if (IntPtr.Zero == intPtr2)
					{
						Logger.LogErrorFormat("[Zip] CompressFiles Read File fail {0}", new object[]
						{
							files[i]
						});
					}
					else
					{
						long num = LibZip.zip_file_add(intPtr, Path.GetFileName(files[i]), intPtr2, 8192);
						if (num < 0L)
						{
							Logger.LogErrorFormat("[Zip] CompressFiles Add File fail {0}", new object[]
							{
								files[i]
							});
						}
					}
				}
			}
			LibZip.zip_close(intPtr);
			return true;
		}

		// Token: 0x06000DB7 RID: 3511 RVA: 0x000471F8 File Offset: 0x000455F8
		public static bool UncompressAll(string zippath)
		{
			string directoryName = Path.GetDirectoryName(zippath);
			byte[] array = new byte[262144L];
			IntPtr intPtr = IntPtr.Zero;
			IntPtr intPtr2 = IntPtr.Zero;
			intPtr = LibZip.zip_open(zippath, 0, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				return false;
			}
			int num = LibZip.zip_get_num_files(intPtr);
			zip_stat zip_stat = default(zip_stat);
			for (int i = 0; i < num; i++)
			{
				if (LibZip.zip_stat_index(intPtr, (long)i, 0, ref zip_stat) == 0)
				{
					string text = Marshal.PtrToStringAnsi(zip_stat.name);
					if (text.EndsWith("/"))
					{
						string text2 = Path.Combine(directoryName, text);
					}
					else
					{
						intPtr2 = LibZip.zip_fopen_index(intPtr, (long)i, 0);
						if (intPtr2 == IntPtr.Zero)
						{
							Logger.LogError("open file fail " + zip_stat.name);
							return false;
						}
						string path = Path.Combine(directoryName, text);
						string directoryName2 = Path.GetDirectoryName(path);
						try
						{
							Directory.CreateDirectory(directoryName2);
						}
						catch (Exception ex)
						{
							Logger.LogError("create dir error " + ex.ToString());
						}
						FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
						long num2;
						while ((num2 = LibZip.zip_fread(intPtr2, array, 262144L)) > 0L)
						{
							try
							{
								fileStream.Write(array, 0, (int)num2);
							}
							catch (Exception ex2)
							{
								Logger.LogError("手机空间不足，建议清理后重试");
								break;
							}
						}
						fileStream.Close();
						LibZip.zip_fclose(intPtr2);
						intPtr2 = IntPtr.Zero;
					}
				}
			}
			LibZip.zip_close(intPtr);
			return true;
		}

		// Token: 0x06000DB8 RID: 3512 RVA: 0x000473A8 File Offset: 0x000457A8
		public static IEnumerator UncompressAllAsync(string zippath, int chunkSizeKB = 64, LibZipFileReader.ProgressReport report = null)
		{
			long BUFF_SIZE = (long)(1024 * chunkSizeKB);
			string sDataPath = Path.GetDirectoryName(zippath);
			byte[] bReadBuf = new byte[BUFF_SIZE];
			long iReadLen = 0L;
			IntPtr zipPtr = IntPtr.Zero;
			IntPtr filePtr = IntPtr.Zero;
			zipPtr = LibZip.zip_open(zippath, 0, IntPtr.Zero);
			if (report != null)
			{
				report(0.01f);
			}
			if (zipPtr == IntPtr.Zero)
			{
				yield break;
			}
			int iCount = LibZip.zip_get_num_files(zipPtr);
			zip_stat zipStat = default(zip_stat);
			for (int i = 0; i < iCount; i++)
			{
				report(0.01f + (float)i * 0.98f / (float)iCount);
				if (LibZip.zip_stat_index(zipPtr, (long)i, 0, ref zipStat) == 0)
				{
					string zipStatName = Marshal.PtrToStringAnsi(zipStat.name);
					if (zipStatName.EndsWith("/"))
					{
						string text = Path.Combine(sDataPath, zipStatName);
					}
					else
					{
						filePtr = LibZip.zip_fopen_index(zipPtr, (long)i, 0);
						if (filePtr == IntPtr.Zero)
						{
							Logger.LogError("open file fail " + zipStat.name);
						}
						else
						{
							string dstFileName = Path.Combine(sDataPath, zipStatName);
							string dirName = Path.GetDirectoryName(dstFileName);
							try
							{
								Directory.CreateDirectory(dirName);
							}
							catch (Exception ex)
							{
								Logger.LogError("create dir error " + ex.ToString());
							}
							FileStream fs = new FileStream(dstFileName, FileMode.Create, FileAccess.Write);
							while ((iReadLen = LibZip.zip_fread(filePtr, bReadBuf, BUFF_SIZE)) > 0L)
							{
								try
								{
									fs.Write(bReadBuf, 0, (int)iReadLen);
								}
								catch (Exception ex2)
								{
									Logger.LogError("手机空间不足，建议清理后重试");
									break;
								}
								yield return LibZipFileReader.WAIT_FOR_EOF;
							}
							LibZip.zip_fclose(filePtr);
							fs.Close();
							filePtr = IntPtr.Zero;
						}
					}
				}
			}
			LibZip.zip_close(zipPtr);
			report(1f);
			yield break;
		}

		// Token: 0x04000999 RID: 2457
		private static IntPtr zip = IntPtr.Zero;

		// Token: 0x0400099A RID: 2458
		public const string FULL_STORAGE_TIPS = "手机空间不足，建议清理后重试";

		// Token: 0x0400099B RID: 2459
		private static string TAG = "ZipFileReader";

		// Token: 0x0400099C RID: 2460
		private static WaitForEndOfFrame WAIT_FOR_EOF = new WaitForEndOfFrame();

		// Token: 0x020001A7 RID: 423
		// (Invoke) Token: 0x06000DBB RID: 3515
		public delegate void ProgressReport(float percentage);
	}
}
