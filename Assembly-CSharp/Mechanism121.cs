using System;

// Token: 0x020042FD RID: 17149
internal class Mechanism121 : BeMechanism
{
	// Token: 0x06017BAA RID: 97194 RVA: 0x00751291 File Offset: 0x0074F691
	public Mechanism121(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BAB RID: 97195 RVA: 0x0075129B File Offset: 0x0074F69B
	public override void OnInit()
	{
		this.radiusRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x040110DD RID: 69853
	public int radiusRate;
}
