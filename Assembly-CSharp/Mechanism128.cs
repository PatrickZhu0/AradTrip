using System;

// Token: 0x02004304 RID: 17156
internal class Mechanism128 : BeMechanism
{
	// Token: 0x06017BC2 RID: 97218 RVA: 0x00751BF9 File Offset: 0x0074FFF9
	public Mechanism128(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BC3 RID: 97219 RVA: 0x00751C04 File Offset: 0x00750004
	public override void OnInit()
	{
		this.time = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.timeRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040110FA RID: 69882
	public int time;

	// Token: 0x040110FB RID: 69883
	public int timeRate;
}
