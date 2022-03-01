using System;

// Token: 0x02004303 RID: 17155
internal class Mechanism127 : BeMechanism
{
	// Token: 0x06017BC0 RID: 97216 RVA: 0x00751B91 File Offset: 0x0074FF91
	public Mechanism127(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017BC1 RID: 97217 RVA: 0x00751B9C File Offset: 0x0074FF9C
	public override void OnInit()
	{
		this.attackNum = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.radiusRate = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x040110F8 RID: 69880
	public int attackNum;

	// Token: 0x040110F9 RID: 69881
	public int radiusRate;
}
