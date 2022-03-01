using System;

// Token: 0x02004350 RID: 17232
public class Mechanism2026 : BeMechanism
{
	// Token: 0x06017DAE RID: 97710 RVA: 0x0075F88F File Offset: 0x0075DC8F
	public Mechanism2026(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06017DAF RID: 97711 RVA: 0x0075F8A4 File Offset: 0x0075DCA4
	public override void OnInit()
	{
		base.OnInit();
		this.singleHurtRateAdd = VFactor.NewVFactor(TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true), GlobalLogic.VALUE_1000);
	}

	// Token: 0x040112A6 RID: 70310
	public VFactor singleHurtRateAdd = VFactor.zero;
}
