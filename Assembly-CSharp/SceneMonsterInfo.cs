using System;
using FBSceneData;
using ProtoTable;

// Token: 0x02004B56 RID: 19286
public class SceneMonsterInfo : SceneEntityInfo, ISceneMonsterInfoData
{
	// Token: 0x0601C574 RID: 116084 RVA: 0x0089C5D0 File Offset: 0x0089A9D0
	public SceneMonsterInfo(FBSceneData.DMonsterInfo data) : base(data.Super)
	{
		this.mData = data;
		this.mDestructInfo = new SceneDestructibleInfo(data.DestructInfo);
		this.mMonsterID = new MonsterID();
		this.mMonsterID.resID = this.mData.Super.Resid;
	}

	// Token: 0x0601C575 RID: 116085 RVA: 0x0089C628 File Offset: 0x0089AA28
	public override string GetModelPathByResID()
	{
		UnitTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<UnitTable>(base.GetResid(), string.Empty, string.Empty);
		if (tableItem == null)
		{
			return string.Empty;
		}
		ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
		if (tableItem2 == null)
		{
			return string.Empty;
		}
		return tableItem2.ModelPath;
	}

	// Token: 0x0601C576 RID: 116086 RVA: 0x0089C689 File Offset: 0x0089AA89
	public ISceneDestructibleInfoData GetDestructInfo()
	{
		return this.mDestructInfo;
	}

	// Token: 0x0601C577 RID: 116087 RVA: 0x0089C691 File Offset: 0x0089AA91
	public ISceneEntityInfoData GetEntityInfo()
	{
		return this;
	}

	// Token: 0x0601C578 RID: 116088 RVA: 0x0089C694 File Offset: 0x0089AA94
	public global::DMonsterInfo.FaceType GetFaceType()
	{
		return (global::DMonsterInfo.FaceType)this.mData.FaceType;
	}

	// Token: 0x0601C579 RID: 116089 RVA: 0x0089C6A2 File Offset: 0x0089AAA2
	public global::DMonsterInfo.FlowRegionType GetFlowRegionType()
	{
		return (global::DMonsterInfo.FlowRegionType)this.mData.FlowRegionType;
	}

	// Token: 0x0601C57A RID: 116090 RVA: 0x0089C6B0 File Offset: 0x0089AAB0
	public int GetFlushGroupID()
	{
		return this.mData.FlushGroupID;
	}

	// Token: 0x0601C57B RID: 116091 RVA: 0x0089C6BD File Offset: 0x0089AABD
	public int GetMonsterDiffcute()
	{
		return this.mMonsterID.monsterDiffcute;
	}

	// Token: 0x0601C57C RID: 116092 RVA: 0x0089C6CA File Offset: 0x0089AACA
	public int GetMonsterID()
	{
		return this.mMonsterID.monsterID;
	}

	// Token: 0x0601C57D RID: 116093 RVA: 0x0089C6D7 File Offset: 0x0089AAD7
	public int GetMonsterLevel()
	{
		return this.mMonsterID.monsterLevel;
	}

	// Token: 0x0601C57E RID: 116094 RVA: 0x0089C6E4 File Offset: 0x0089AAE4
	public int GetMonsterTypeID()
	{
		return this.mMonsterID.monsterID;
	}

	// Token: 0x0601C57F RID: 116095 RVA: 0x0089C6F1 File Offset: 0x0089AAF1
	public ISceneRegionInfoData GetRegionInfo()
	{
		return this.mRegionInfo;
	}

	// Token: 0x0601C580 RID: 116096 RVA: 0x0089C6F9 File Offset: 0x0089AAF9
	public int GetSwapDelay()
	{
		return this.mData.SwapDelay;
	}

	// Token: 0x0601C581 RID: 116097 RVA: 0x0089C706 File Offset: 0x0089AB06
	public int GetSwapNum()
	{
		return this.mData.SwapNum;
	}

	// Token: 0x0601C582 RID: 116098 RVA: 0x0089C713 File Offset: 0x0089AB13
	public global::DMonsterInfo.MonsterSwapType GetSwapType()
	{
		return (global::DMonsterInfo.MonsterSwapType)this.mData.SwapType;
	}

	// Token: 0x0601C583 RID: 116099 RVA: 0x0089C721 File Offset: 0x0089AB21
	public void SetMonsterID(int id)
	{
		this.mMonsterID.resID = id;
	}

	// Token: 0x040137F2 RID: 79858
	private FBSceneData.DMonsterInfo mData;

	// Token: 0x040137F3 RID: 79859
	private ISceneDestructibleInfoData mDestructInfo;

	// Token: 0x040137F4 RID: 79860
	private ISceneRegionInfoData mRegionInfo;

	// Token: 0x040137F5 RID: 79861
	private MonsterID mMonsterID;
}
