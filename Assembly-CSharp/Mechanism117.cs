using System;

// Token: 0x020042DF RID: 17119
internal class Mechanism117 : BeMechanism
{
	// Token: 0x06017B07 RID: 97031 RVA: 0x0074D050 File Offset: 0x0074B450
	public Mechanism117(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017B08 RID: 97032 RVA: 0x0074D05C File Offset: 0x0074B45C
	public override void OnInit()
	{
		this.radiusRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.speedRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x04011060 RID: 69728
	public int radiusRate;

	// Token: 0x04011061 RID: 69729
	public int speedRate;
}
