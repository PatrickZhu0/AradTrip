using System;

// Token: 0x020042FF RID: 17151
internal class Mechanism123 : BeMechanism
{
	// Token: 0x06017BAF RID: 97199 RVA: 0x007513EA File Offset: 0x0074F7EA
	public Mechanism123(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BB0 RID: 97200 RVA: 0x007513F4 File Offset: 0x0074F7F4
	public override void OnInit()
	{
		this.hpRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x040110E2 RID: 69858
	public int hpRate;
}
