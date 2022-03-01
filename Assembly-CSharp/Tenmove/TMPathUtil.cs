using System;
using System.IO;

namespace Tenmove
{
	// Token: 0x020001AA RID: 426
	public class TMPathUtil
	{
		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x06000DCF RID: 3535 RVA: 0x00047C2A File Offset: 0x0004602A
		// (set) Token: 0x06000DD0 RID: 3536 RVA: 0x00047C31 File Offset: 0x00046031
		public static string Root
		{
			get
			{
				return TMPathUtil.mRoot;
			}
			set
			{
				TMPathUtil.mRoot = value;
			}
		}

		// Token: 0x06000DD1 RID: 3537 RVA: 0x00047C3C File Offset: 0x0004603C
		public static void MakeParentRootExist(string filePath)
		{
			string fileName = Path.GetFileName(filePath);
			string rootPath = filePath.Remove(filePath.Length - fileName.Length, fileName.Length);
			TMPathUtil.CreateRootDir(rootPath);
		}

		// Token: 0x06000DD2 RID: 3538 RVA: 0x00047C70 File Offset: 0x00046070
		public static void CreateRootDir(string rootPath)
		{
			if (!Directory.Exists(rootPath))
			{
				Directory.CreateDirectory(rootPath);
			}
		}

		// Token: 0x06000DD3 RID: 3539 RVA: 0x00047C84 File Offset: 0x00046084
		public static string GetTypeRootPath(TMPathUtil.Type type)
		{
			string text = Path.Combine(TMPathUtil.mRoot, type.ToString());
			TMPathUtil.CreateRootDir(text);
			return text;
		}

		// Token: 0x06000DD4 RID: 3540 RVA: 0x00047CB0 File Offset: 0x000460B0
		public static string GetTypeRootPathWithFileName(TMPathUtil.Type type, string fileName)
		{
			string typeRootPath = TMPathUtil.GetTypeRootPath(type);
			return Path.Combine(typeRootPath, fileName);
		}

		// Token: 0x06000DD5 RID: 3541 RVA: 0x00047CCC File Offset: 0x000460CC
		private static string _SplitFileName(string filename)
		{
			string[] array = filename.Split(new char[]
			{
				'_'
			});
			if (array != null && array.Length > 0)
			{
				return array[0];
			}
			return string.Empty;
		}

		// Token: 0x06000DD6 RID: 3542 RVA: 0x00047D04 File Offset: 0x00046104
		public static string GetCurrentDateTime()
		{
			return DateTime.Now.ToString("yyyy-MM-dd_HHmmss");
		}

		// Token: 0x06000DD7 RID: 3543 RVA: 0x00047D24 File Offset: 0x00046124
		public static string CreateTypeNumberDir(TMPathUtil.Type type, ref string dirName)
		{
			string typeRootPath = TMPathUtil.GetTypeRootPath(type);
			string[] directories = Directory.GetDirectories(typeRootPath);
			if (string.IsNullOrEmpty(dirName))
			{
				int num = 0;
				for (int i = 0; i < directories.Length; i++)
				{
					int num2 = 0;
					if (int.TryParse(TMPathUtil._SplitFileName(Path.GetFileName(directories[i])), out num2) && num < num2)
					{
						num = num2;
					}
				}
				num++;
				dirName = string.Format("{0:D6}_{1}", num, TMPathUtil.GetCurrentDateTime());
			}
			string text = Path.Combine(typeRootPath, dirName);
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			return text;
		}

		// Token: 0x040009A2 RID: 2466
		private static string mRoot = "..";

		// Token: 0x020001AB RID: 427
		public enum Type
		{
			// Token: 0x040009A4 RID: 2468
			Logs,
			// Token: 0x040009A5 RID: 2469
			ScreenShots,
			// Token: 0x040009A6 RID: 2470
			Infos
		}
	}
}
