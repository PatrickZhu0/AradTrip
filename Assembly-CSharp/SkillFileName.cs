using System;

// Token: 0x02004138 RID: 16696
public class SkillFileName
{
	// Token: 0x06016B93 RID: 93075 RVA: 0x006EB642 File Offset: 0x006E9A42
	public SkillFileName(string filename, string parentPath)
	{
		this._initWithNameAndPath(filename, parentPath);
	}

	// Token: 0x06016B94 RID: 93076 RVA: 0x006EB654 File Offset: 0x006E9A54
	private void _initWithNameAndPath(string filename, string parentPath)
	{
		this.fullPath = parentPath + "/" + filename;
		if (filename.Contains("common", StringComparison.OrdinalIgnoreCase))
		{
			this.isCommon = true;
		}
		if (filename.Contains("pvp", StringComparison.OrdinalIgnoreCase))
		{
			this.isPvp = true;
		}
		if (filename.Contains("chiji", StringComparison.OrdinalIgnoreCase))
		{
			this.isChiji = true;
		}
		int num = filename.LastIndexOf("-");
		if (num != -1)
		{
			int num2 = 0;
			for (int i = num + 1; i < filename.Length; i++)
			{
				if (filename[i] < '0' || filename[i] > '9')
				{
					num2 = i;
					break;
				}
			}
			string text = filename.Substring(num + 1, num2 - num - 1);
			try
			{
				int num3 = Convert.ToInt32(text);
				this.weaponType = num3;
				filename = filename.Replace("-" + text, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("{0} parse weaponType error", new object[]
				{
					filename
				});
			}
		}
		string[] array = filename.Split(new char[]
		{
			'/'
		});
		this.folderName = array[0];
		this.lastName = array[array.Length - 1];
	}

	// Token: 0x040103F9 RID: 66553
	public string fullPath;

	// Token: 0x040103FA RID: 66554
	public bool isCommon;

	// Token: 0x040103FB RID: 66555
	public string folderName;

	// Token: 0x040103FC RID: 66556
	public string lastName;

	// Token: 0x040103FD RID: 66557
	public bool isPvp;

	// Token: 0x040103FE RID: 66558
	public string pvpPath;

	// Token: 0x040103FF RID: 66559
	public bool isChiji;

	// Token: 0x04010400 RID: 66560
	public string chijiPath;

	// Token: 0x04010401 RID: 66561
	public int indexForFB;

	// Token: 0x04010402 RID: 66562
	public int pvpIndexForFB;

	// Token: 0x04010403 RID: 66563
	public int chijiIndexForFB;

	// Token: 0x04010404 RID: 66564
	public int weaponType;
}
