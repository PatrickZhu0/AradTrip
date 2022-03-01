using System;

// Token: 0x02004BD8 RID: 19416
[Serializable]
public class TileInsData : ITileInsData
{
	// Token: 0x0601C788 RID: 116616 RVA: 0x0089F81E File Offset: 0x0089DC1E
	public int GetTableID()
	{
		return this.TableID;
	}

	// Token: 0x0601C789 RID: 116617 RVA: 0x0089F826 File Offset: 0x0089DC26
	public int GetGUID()
	{
		return this.ID;
	}

	// Token: 0x0601C78A RID: 116618 RVA: 0x0089F82E File Offset: 0x0089DC2E
	public TilePos GetPosition()
	{
		return this.Position;
	}

	// Token: 0x0601C78B RID: 116619 RVA: 0x0089F836 File Offset: 0x0089DC36
	public int GetResID()
	{
		return this.ResID;
	}

	// Token: 0x04013AD9 RID: 80601
	public int ID;

	// Token: 0x04013ADA RID: 80602
	public int ResID;

	// Token: 0x04013ADB RID: 80603
	public TilePos Position;

	// Token: 0x04013ADC RID: 80604
	public int TableID;
}
