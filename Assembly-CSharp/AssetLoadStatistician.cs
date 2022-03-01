using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x020000B1 RID: 177
public class AssetLoadStatistician : Singleton<AssetLoadStatistician>
{
	// Token: 0x060003A1 RID: 929 RVA: 0x0001AA7C File Offset: 0x00018E7C
	private void _DumpToFile()
	{
		if (this.m_DumpBuf.Count <= 0)
		{
			return;
		}
		FileStream fileStream = new FileStream(Path.Combine(Application.persistentDataPath, this.m_DumpFile), FileMode.Append, FileAccess.Write);
		StreamWriter streamWriter = new StreamWriter(fileStream);
		streamWriter.Flush();
		streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
		for (int i = 0; i < this.m_DumpBuf.Count; i++)
		{
			streamWriter.WriteLine(this.m_DumpBuf[i]);
		}
		streamWriter.Flush();
		streamWriter.Close();
		fileStream.Close();
		this.m_DumpBuf.Clear();
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x0001AB1A File Offset: 0x00018F1A
	private void _RecordLoadFile(string info)
	{
		if (this.m_DumpBuf.Count >= this.m_BufLineNum)
		{
			this._DumpToFile();
		}
		this.m_DumpBuf.Add(info);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x0001AB44 File Offset: 0x00018F44
	public void AddAssetProfile(string fileName, float ms, bool bundle, bool async)
	{
		if (!Global.Settings.profileAssetLoad)
		{
			return;
		}
		this._RecordLoadFile(string.Format("{0},{1},{2},{3},{4}", new object[]
		{
			DateTime.Now.ToString("hh:mm:ss:fff"),
			fileName,
			ms.ToString("0.000"),
			(!bundle) ? "Resource" : "AssetBundle",
			(!async) ? "Sync" : "Async"
		}));
	}

	// Token: 0x0400037A RID: 890
	private string m_DumpFile = "FileLoadProfile.csv";

	// Token: 0x0400037B RID: 891
	private List<string> m_DumpBuf = new List<string>();

	// Token: 0x0400037C RID: 892
	private int m_BufLineNum = 10;
}
