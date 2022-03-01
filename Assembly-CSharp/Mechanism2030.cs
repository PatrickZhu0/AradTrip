using System;

// Token: 0x02004354 RID: 17236
public class Mechanism2030 : BeMechanism
{
	// Token: 0x06017DBD RID: 97725 RVA: 0x0075FED1 File Offset: 0x0075E2D1
	public Mechanism2030(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DBE RID: 97726 RVA: 0x0075FEDB File Offset: 0x0075E2DB
	public override void OnInit()
	{
		base.OnInit();
		this.hurtMaxLimitAddRate = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
	}

	// Token: 0x040112B3 RID: 70323
	public int hurtMaxLimitAddRate;
}
