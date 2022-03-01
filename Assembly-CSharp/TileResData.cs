using System;

// Token: 0x02004BE2 RID: 19426
[Serializable]
public class TileResData : ITileResData
{
	// Token: 0x0601C79C RID: 116636 RVA: 0x0089F91F File Offset: 0x0089DD1F
	public int GetDataAt(int idx)
	{
		if (idx < 0 || idx >= this.Data.Length)
		{
			return 0;
		}
		return this.Data[idx];
	}

	// Token: 0x0601C79D RID: 116637 RVA: 0x0089F940 File Offset: 0x0089DD40
	public int GetDataLength()
	{
		return this.Data.Length;
	}

	// Token: 0x0601C79E RID: 116638 RVA: 0x0089F94A File Offset: 0x0089DD4A
	public int GetID()
	{
		return this.ID;
	}

	// Token: 0x0601C79F RID: 116639 RVA: 0x0089F952 File Offset: 0x0089DD52
	public ETeamTileLayer GetTileLayer()
	{
		return this.Layer;
	}

	// Token: 0x0601C7A0 RID: 116640 RVA: 0x0089F95A File Offset: 0x0089DD5A
	public ETileLinkedType GetTileLinkedType()
	{
		return this.Link;
	}

	// Token: 0x0601C7A1 RID: 116641 RVA: 0x0089F962 File Offset: 0x0089DD62
	public string GetName()
	{
		return this.Name;
	}

	// Token: 0x0601C7A2 RID: 116642 RVA: 0x0089F96A File Offset: 0x0089DD6A
	public string GetPrefabPath()
	{
		return this.PrefabPath;
	}

	// Token: 0x0601C7A3 RID: 116643 RVA: 0x0089F972 File Offset: 0x0089DD72
	public ETeamTileType GetTileType()
	{
		return this.Type;
	}

	// Token: 0x04013B0F RID: 80655
	public string PrefabPath;

	// Token: 0x04013B10 RID: 80656
	public int ID;

	// Token: 0x04013B11 RID: 80657
	public string Name;

	// Token: 0x04013B12 RID: 80658
	public ETeamTileLayer Layer;

	// Token: 0x04013B13 RID: 80659
	public ETeamTileType Type;

	// Token: 0x04013B14 RID: 80660
	public ETileLinkedType Link;

	// Token: 0x04013B15 RID: 80661
	public int[] Data = EmptyArray<int>.Empty();
}
