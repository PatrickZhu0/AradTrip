using System;
using System.Collections.Generic;
using GameClient;
using ProtoTable;

// Token: 0x020043B2 RID: 17330
public class Mechanism2118 : BeMechanism
{
	// Token: 0x06018096 RID: 98454 RVA: 0x0077611A File Offset: 0x0077451A
	public Mechanism2118(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06018097 RID: 98455 RVA: 0x00776148 File Offset: 0x00774548
	public override void OnInit()
	{
		this.m_gameType = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		for (int i = 0; i < this.data.ValueB.Length; i++)
		{
			this.m_countLevel.Add(TableManager.GetValueFromUnionCell(this.data.ValueB[i], this.level, true));
		}
		for (int j = 0; j < this.data.ValueC.Length; j++)
		{
			this.m_captionTipsID.Add(TableManager.GetValueFromUnionCell(this.data.ValueC[j], this.level, true));
		}
		for (int k = 0; k < this.data.ValueD.Length; k++)
		{
			this.m_contentTipsID.Add(TableManager.GetValueFromUnionCell(this.data.ValueD[k], this.level, true));
		}
		this.m_LimiteTime = TableManager.GetValueFromUnionCell(this.data.ValueE[0], this.level, true);
		this.m_isLessEqualComparor = (TableManager.GetValueFromUnionCell(this.data.ValueF[0], this.level, true) != 0);
		this.m_tipID = TableManager.GetValueFromUnionCell(this.data.ValueG[0], this.level, true);
		this.m_tipTimeLen = TableManager.GetValueFromUnionCell(this.data.ValueH[0], this.level, true);
	}

	// Token: 0x06018098 RID: 98456 RVA: 0x00776314 File Offset: 0x00774714
	public override void OnStart()
	{
		base.OnStart();
		TimeLimiteBattle timeLimiteBattle = base.owner.CurrentBeBattle as TimeLimiteBattle;
		if (timeLimiteBattle != null)
		{
			string[] array = new string[this.m_captionTipsID.Count];
			for (int i = 0; i < this.m_captionTipsID.Count; i++)
			{
				CommonTipsDesc tableItem = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(this.m_captionTipsID[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					array[i] = tableItem.Descs;
				}
			}
			string[] array2 = new string[this.m_contentTipsID.Count];
			for (int j = 0; j < this.m_contentTipsID.Count; j++)
			{
				CommonTipsDesc tableItem2 = Singleton<TableManager>.instance.GetTableItem<CommonTipsDesc>(this.m_contentTipsID[j], string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					array2[j] = tableItem2.Descs;
				}
			}
			timeLimiteBattle.SetDataInfo(this.m_gameType, this.m_LimiteTime, array, array2, this.m_countLevel.ToArray(), this.m_isLessEqualComparor, this.m_tipID, this.m_tipTimeLen);
		}
	}

	// Token: 0x04011515 RID: 70933
	private int m_gameType;

	// Token: 0x04011516 RID: 70934
	private List<int> m_countLevel = new List<int>();

	// Token: 0x04011517 RID: 70935
	private List<int> m_captionTipsID = new List<int>();

	// Token: 0x04011518 RID: 70936
	private List<int> m_contentTipsID = new List<int>();

	// Token: 0x04011519 RID: 70937
	private int m_LimiteTime;

	// Token: 0x0401151A RID: 70938
	private bool m_isLessEqualComparor;

	// Token: 0x0401151B RID: 70939
	private int m_tipID;

	// Token: 0x0401151C RID: 70940
	private int m_tipTimeLen;
}
