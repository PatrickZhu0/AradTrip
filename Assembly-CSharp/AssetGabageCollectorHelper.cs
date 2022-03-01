using System;
using UnityEngine;

// Token: 0x020000AB RID: 171
public class AssetGabageCollectorHelper : Singleton<AssetGabageCollectorHelper>
{
	// Token: 0x0600038B RID: 907 RVA: 0x0001A5DA File Offset: 0x000189DA
	public override void Init()
	{
		this._ResetConfig();
	}

	// Token: 0x0600038C RID: 908 RVA: 0x0001A5E4 File Offset: 0x000189E4
	public void Update()
	{
		this.m_CurUpdateCnt++;
		this.m_FrameCount++;
		if (this.UPDATE_STEP == this.m_CurUpdateCnt)
		{
			bool flag = false;
			int num = (this.m_AutoTickCount.Length >= this.m_CurTickCount.Length) ? this.m_CurTickCount.Length : this.m_AutoTickCount.Length;
			int i = 0;
			int num2 = num;
			while (i < num2)
			{
				if (this.m_AutoTickCount[i] != 0 && this.m_AutoTickEnable[i])
				{
					if (this.m_AutoTickCount[i] <= this.m_CurTickCount[i] && this.m_FrameCount > this.GC_FRAME_CNT)
					{
						flag = true;
						MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
					}
				}
				i++;
			}
			if (flag)
			{
				int j = 0;
				int num3 = this.m_CurTickCount.Length;
				while (j < num3)
				{
					this.m_CurTickCount[j] = 0;
					j++;
				}
				this.m_FrameCount = 0;
			}
			this.m_CurUpdateCnt = 0;
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0001A6F4 File Offset: 0x00018AF4
	public void AddGCPurgeTick(AssetGCTickType tickType)
	{
		if (tickType < (AssetGCTickType)this.m_CurTickCount.Length)
		{
			this.m_CurTickCount[(int)tickType]++;
		}
	}

	// Token: 0x0600038E RID: 910 RVA: 0x0001A724 File Offset: 0x00018B24
	public void SetGCPurgeEnable(AssetGCTickType tickType, bool enable)
	{
		if (tickType < (AssetGCTickType)this.m_AutoTickEnable.Length)
		{
			this.m_AutoTickEnable[(int)tickType] = enable;
		}
	}

	// Token: 0x0600038F RID: 911 RVA: 0x0001A74C File Offset: 0x00018B4C
	public void _ResetConfig()
	{
		int i = 0;
		int num = this.m_CurTickCount.Length;
		while (i < num)
		{
			this.m_CurTickCount[i] = 0;
			i++;
		}
		int j = 0;
		int num2 = this.m_AutoTickEnable.Length;
		while (j < num2)
		{
			this.m_AutoTickEnable[j] = false;
			j++;
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x0001A7A4 File Offset: 0x00018BA4
	public void LoadGCConfig()
	{
		this._ResetConfig();
	}

	// Token: 0x06000391 RID: 913 RVA: 0x0001A7B8 File Offset: 0x00018BB8
	private byte[] _LoadConfig(string configFile)
	{
		byte[] result = null;
		try
		{
			if (!FileArchiveAccessor.LoadFileInPersistentFileArchive(configFile, out result))
			{
				Debug.LogError("Load GC config file from persistent path has failed!");
				if (!FileArchiveAccessor.LoadFileInLocalFileArchive(configFile, out result))
				{
					Debug.LogError("Load GC config file from streaming path has failed!");
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogErrorFormat("Load GC config file exception:{0}!", new object[]
			{
				ex.Message
			});
		}
		return result;
	}

	// Token: 0x04000368 RID: 872
	protected readonly int UPDATE_STEP = 5;

	// Token: 0x04000369 RID: 873
	protected readonly int GC_FRAME_CNT = 1500;

	// Token: 0x0400036A RID: 874
	protected int m_CurUpdateCnt;

	// Token: 0x0400036B RID: 875
	protected int m_FrameCount;

	// Token: 0x0400036C RID: 876
	protected int[] m_CurTickCount = new int[3];

	// Token: 0x0400036D RID: 877
	protected int[] m_AutoTickCount = new int[3];

	// Token: 0x0400036E RID: 878
	protected bool[] m_AutoTickEnable = new bool[3];
}
