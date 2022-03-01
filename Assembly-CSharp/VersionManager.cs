using System;
using System.Collections;
using System.IO;
using System.Text;
using UnityEngine;
using XUPorterJSON;

// Token: 0x02000223 RID: 547
public class VersionManager : Singleton<VersionManager>
{
	// Token: 0x17000215 RID: 533
	// (get) Token: 0x06001230 RID: 4656 RVA: 0x00063073 File Offset: 0x00061473
	// (set) Token: 0x06001231 RID: 4657 RVA: 0x0006307B File Offset: 0x0006147B
	public string commitTime
	{
		get
		{
			return this.mCommitTime;
		}
		private set
		{
			this.mCommitTime = value;
		}
	}

	// Token: 0x06001232 RID: 4658 RVA: 0x00063084 File Offset: 0x00061484
	private string GetFilePath(bool persistentPath)
	{
		string text;
		if (persistentPath)
		{
			text = Utility.FormatString(Path.Combine(Application.persistentDataPath, "version.config"));
			if (CFileManager.IsFileExist(text))
			{
				return text;
			}
		}
		else
		{
			text = Utility.FormatString(Path.Combine(Application.streamingAssetsPath, "version.config"));
			if (CFileManager.IsFileExist(text))
			{
				return text;
			}
		}
		Logger.LogErrorFormat("{0} 不存在", new object[]
		{
			text
		});
		return string.Empty;
	}

	// Token: 0x06001233 RID: 4659 RVA: 0x000630FC File Offset: 0x000614FC
	private byte[] GetFileData(bool peresistent)
	{
		byte[] result = null;
		if (!peresistent)
		{
			result = CFileManager.ReadFileFromZip("version.config");
		}
		else
		{
			FileArchiveAccessor.LoadFileInPersistentFileArchive("version.config", out result);
		}
		return result;
	}

	// Token: 0x06001234 RID: 4660 RVA: 0x00063130 File Offset: 0x00061530
	public override void Init()
	{
		byte[] fileData = this.GetFileData(false);
		int num = 0;
		int num2 = 0;
		this._ParsePatchVersion(fileData, out num2, out num);
		byte[] fileData2 = this.GetFileData(true);
		int num3 = 0;
		int num4 = 0;
		this._ParsePatchVersion(fileData2, out num4, out num3);
		if (num4 > num2 && num3 >= num)
		{
			this.m_IsLocalNewer = false;
		}
		else
		{
			this.m_IsLocalNewer = true;
		}
		if (this.m_IsLocalNewer)
		{
			this._ParseVersionFromData(fileData);
		}
		else
		{
			this._ParseVersionFromData(fileData2);
		}
	}

	// Token: 0x06001235 RID: 4661 RVA: 0x000631B0 File Offset: 0x000615B0
	public void _ParsePatchVersion(byte[] data, out int cientShortVersion, out int clientVersion)
	{
		cientShortVersion = 0;
		clientVersion = 0;
		if (data != null)
		{
			string @string = Encoding.UTF8.GetString(data);
			Hashtable hashtable = MiniJSON.jsonDecode(@string) as Hashtable;
			try
			{
				cientShortVersion = int.Parse(hashtable["clientShortVersion"].ToString());
				clientVersion = int.Parse(hashtable["clientVersion"].ToString());
			}
			catch (Exception ex)
			{
				Logger.LogError("读version.config出错" + ex.ToString());
			}
		}
	}

	// Token: 0x06001236 RID: 4662 RVA: 0x00063240 File Offset: 0x00061640
	public void _ParseVersionFromData(byte[] data)
	{
		string @string = Encoding.UTF8.GetString(data);
		Hashtable hashtable = MiniJSON.jsonDecode(@string) as Hashtable;
		try
		{
			this.serverVersion = int.Parse(hashtable["serverVersion"].ToString());
			this.serverShortVersion = int.Parse(hashtable["serverShortVersion"].ToString());
			this.clientVersion = int.Parse(hashtable["clientVersion"].ToString());
			this.clientShortVersion = int.Parse(hashtable["clientShortVersion"].ToString());
			this.commitTime = hashtable["commitTime"].ToString().Trim();
			long secondsFromUtcStart = 0L;
			if (long.TryParse(this.commitTime, out secondsFromUtcStart))
			{
				this.commitTime = Utility.ToUtcTime2Local(secondsFromUtcStart).ToString("yyyy-MM-dd HH:mm:ss");
			}
			this.commitMessage = hashtable["commitMessage"].ToString();
			this.commitAuthor = hashtable["commitAuthor"].ToString();
			this.commitID = hashtable["commitID"].ToString();
		}
		catch (Exception ex)
		{
			Logger.LogError("读version.config出错");
		}
	}

	// Token: 0x06001237 RID: 4663 RVA: 0x00063384 File Offset: 0x00061784
	public override void UnInit()
	{
	}

	// Token: 0x06001238 RID: 4664 RVA: 0x00063388 File Offset: 0x00061788
	public string Version()
	{
		return string.Format("{0}.{1}.{2}.{3}", new object[]
		{
			this.serverVersion,
			this.serverShortVersion,
			this.clientVersion,
			this.clientShortVersion
		});
	}

	// Token: 0x06001239 RID: 4665 RVA: 0x000633DD File Offset: 0x000617DD
	public int ClientShortVersion()
	{
		return this.clientShortVersion;
	}

	// Token: 0x0600123A RID: 4666 RVA: 0x000633E5 File Offset: 0x000617E5
	public string VersionCommitTime()
	{
		return this.commitTime;
	}

	// Token: 0x0600123B RID: 4667 RVA: 0x000633F0 File Offset: 0x000617F0
	public uint ServerVersion()
	{
		uint num = (uint)this.serverVersion;
		num <<= 8;
		num += (uint)this.serverShortVersion;
		num <<= 16;
		return num + (uint)this.clientVersion;
	}

	// Token: 0x0600123C RID: 4668 RVA: 0x00063420 File Offset: 0x00061820
	public string Comment()
	{
		return string.Format("{0}.{1}.{2}", this.commitMessage, this.commitAuthor, this.commitID);
	}

	// Token: 0x04000C22 RID: 3106
	public int serverVersion;

	// Token: 0x04000C23 RID: 3107
	public int serverShortVersion;

	// Token: 0x04000C24 RID: 3108
	public int clientVersion;

	// Token: 0x04000C25 RID: 3109
	public int clientShortVersion;

	// Token: 0x04000C26 RID: 3110
	private string mCommitTime;

	// Token: 0x04000C27 RID: 3111
	public string commitMessage;

	// Token: 0x04000C28 RID: 3112
	public string commitAuthor;

	// Token: 0x04000C29 RID: 3113
	public string commitID;

	// Token: 0x04000C2A RID: 3114
	public bool m_ProceedHotUpdate;

	// Token: 0x04000C2B RID: 3115
	public bool m_IsLastest;

	// Token: 0x04000C2C RID: 3116
	public bool m_IsLocalNewer;
}
