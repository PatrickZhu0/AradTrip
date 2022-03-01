using System;
using FBDungeonData;

// Token: 0x02004B4E RID: 19278
public class BattleDungeonConnectData : IDungeonConnectData
{
	// Token: 0x0601C531 RID: 116017 RVA: 0x0089BC8B File Offset: 0x0089A08B
	public BattleDungeonConnectData(FBDungeonData.DSceneDataConnect data)
	{
		this.mData = data;
		this.mSceneData = null;
		this.mSceneAreaPath = this.mData.Sceneareapath;
	}

	// Token: 0x0601C532 RID: 116018 RVA: 0x0089BCB2 File Offset: 0x0089A0B2
	public int GetAreaIndex()
	{
		return this.mData.Areaindex;
	}

	// Token: 0x0601C533 RID: 116019 RVA: 0x0089BCBF File Offset: 0x0089A0BF
	public int GetId()
	{
		return this.mData.Id;
	}

	// Token: 0x0601C534 RID: 116020 RVA: 0x0089BCCC File Offset: 0x0089A0CC
	public bool GetIsConnect(int i)
	{
		return this.mData.GetIsconnect(i);
	}

	// Token: 0x0601C535 RID: 116021 RVA: 0x0089BCDA File Offset: 0x0089A0DA
	public int GetIsConnectLength()
	{
		return this.mData.IsconnectLength;
	}

	// Token: 0x0601C536 RID: 116022 RVA: 0x0089BCE7 File Offset: 0x0089A0E7
	public int GetPositionX()
	{
		return this.mData.Positionx;
	}

	// Token: 0x0601C537 RID: 116023 RVA: 0x0089BCF4 File Offset: 0x0089A0F4
	public int GetPositionY()
	{
		return this.mData.Positiony;
	}

	// Token: 0x0601C538 RID: 116024 RVA: 0x0089BD01 File Offset: 0x0089A101
	public string GetSceneAreaPath()
	{
		return this.mSceneAreaPath;
	}

	// Token: 0x0601C539 RID: 116025 RVA: 0x0089BD09 File Offset: 0x0089A109
	public void SetSceneAreaPath(string path)
	{
		this.mSceneAreaPath = path;
	}

	// Token: 0x0601C53A RID: 116026 RVA: 0x0089BD12 File Offset: 0x0089A112
	public ISceneData GetSceneData()
	{
		return this.mSceneData;
	}

	// Token: 0x0601C53B RID: 116027 RVA: 0x0089BD1A File Offset: 0x0089A11A
	public bool IsBoss()
	{
		return this.mData.Isboss;
	}

	// Token: 0x0601C53C RID: 116028 RVA: 0x0089BD27 File Offset: 0x0089A127
	public bool IsEgg()
	{
		return this.mData.Isegg;
	}

	// Token: 0x0601C53D RID: 116029 RVA: 0x0089BD34 File Offset: 0x0089A134
	public bool IsNotHell()
	{
		return this.mData.Isnothell;
	}

	// Token: 0x0601C53E RID: 116030 RVA: 0x0089BD41 File Offset: 0x0089A141
	public bool IsStart()
	{
		return this.mData.Isstart;
	}

	// Token: 0x0601C53F RID: 116031 RVA: 0x0089BD4E File Offset: 0x0089A14E
	public byte GetTreasureType()
	{
		return this.mData.TreasureType;
	}

	// Token: 0x0601C540 RID: 116032 RVA: 0x0089BD5B File Offset: 0x0089A15B
	public void SetSceneData(ISceneData sceneData)
	{
		this.mSceneData = sceneData;
	}

	// Token: 0x0601C541 RID: 116033 RVA: 0x0089BD64 File Offset: 0x0089A164
	public int GetLinkAreaIndexesLength()
	{
		return this.mData.LinkAreaIndexLength;
	}

	// Token: 0x0601C542 RID: 116034 RVA: 0x0089BD71 File Offset: 0x0089A171
	public int GetLinkAreaIndex(int i)
	{
		return this.mData.GetLinkAreaIndex(i);
	}

	// Token: 0x040137E5 RID: 79845
	private FBDungeonData.DSceneDataConnect mData;

	// Token: 0x040137E6 RID: 79846
	private ISceneData mSceneData;

	// Token: 0x040137E7 RID: 79847
	private string mSceneAreaPath;
}
