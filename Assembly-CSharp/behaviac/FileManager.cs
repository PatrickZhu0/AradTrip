using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace behaviac
{
	// Token: 0x02004760 RID: 18272
	public class FileManager
	{
		// Token: 0x0601A43E RID: 107582 RVA: 0x00826482 File Offset: 0x00824882
		public FileManager()
		{
			FileManager.ms_instance = this;
		}

		// Token: 0x1700226B RID: 8811
		// (get) Token: 0x0601A43F RID: 107583 RVA: 0x00826490 File Offset: 0x00824890
		public static FileManager Instance
		{
			get
			{
				if (FileManager.ms_instance == null)
				{
					FileManager.ms_instance = new FileManager();
				}
				return FileManager.ms_instance;
			}
		}

		// Token: 0x0601A440 RID: 107584 RVA: 0x008264AC File Offset: 0x008248AC
		public virtual byte[] FileOpen(string filePath, string ext)
		{
			try
			{
				if (Application.platform == 7 || Application.platform == null)
				{
					if (ext == ".bson")
					{
						ext += ".bytes";
					}
					filePath += ext;
					return File.ReadAllBytes(filePath);
				}
				if (ext == ".bson")
				{
					filePath += ext;
				}
				int num = filePath.IndexOf("Resources");
				if (num != -1)
				{
					num += 10;
					string text = filePath.Substring(num);
					TextAsset textAsset = Resources.Load(text) as TextAsset;
					if (textAsset == null)
					{
						string text2 = string.Format("FileManager::FileOpen failed:'{0}' not loaded", filePath);
						return null;
					}
					return textAsset.bytes;
				}
				else
				{
					string text3 = string.Format("FileManager::FileOpen failed:'{0}' should be in /Resources", filePath);
				}
			}
			catch (Exception ex)
			{
				string text4 = string.Format("FileManager::FileOpen exception:'{0}'", filePath);
			}
			return null;
		}

		// Token: 0x0601A441 RID: 107585 RVA: 0x008265B4 File Offset: 0x008249B4
		public virtual void FileClose(string filePath, string ext, byte[] pBuffer)
		{
		}

		// Token: 0x0601A442 RID: 107586 RVA: 0x008265B8 File Offset: 0x008249B8
		public virtual List<byte[]> DirOpen(string szDir, string ext)
		{
			List<byte[]> list = new List<byte[]>();
			try
			{
				if (Application.platform == 7 || Application.platform == null)
				{
					string searchPattern = (!(ext == ".bson")) ? "*.xml" : "*.bson.bytes";
					string[] files = Directory.GetFiles(szDir, searchPattern, SearchOption.TopDirectoryOnly);
					foreach (string filePath in files)
					{
						byte[] item = this.FileOpen(filePath, string.Empty);
						list.Add(item);
					}
					return list;
				}
				int num = szDir.IndexOf("Resources");
				if (num != -1)
				{
					string text = szDir.Substring(num + 10);
					TextAsset[] array2 = Resources.LoadAll<TextAsset>(text);
					foreach (TextAsset textAsset in array2)
					{
						if (!string.IsNullOrEmpty(textAsset.name))
						{
							bool flag = textAsset.name.IndexOf(".bson") > -1;
							bool flag2 = ext == ".bson";
							if ((flag && flag2) || (!flag && !flag2))
							{
								byte[] bytes = textAsset.bytes;
								list.Add(bytes);
							}
						}
					}
					return list;
				}
			}
			catch (Exception ex)
			{
				string text2 = string.Format("FileManager::DirOpen exception:'{0}'", szDir);
			}
			return null;
		}

		// Token: 0x0601A443 RID: 107587 RVA: 0x0082673C File Offset: 0x00824B3C
		public virtual bool FileExist(string filePath, string ext)
		{
			return File.Exists(filePath + ext);
		}

		// Token: 0x040126FE RID: 75518
		private static FileManager ms_instance;
	}
}
