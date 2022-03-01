using System;

// Token: 0x0200425C RID: 16988
public class Mechanism1020 : BeMechanism
{
	// Token: 0x06017817 RID: 96279 RVA: 0x0073B56F File Offset: 0x0073996F
	public Mechanism1020(int mid, int lv) : base(mid, lv)
	{
	}

	// Token: 0x06017818 RID: 96280 RVA: 0x0073B57C File Offset: 0x0073997C
	public override void OnInit()
	{
		base.OnInit();
		this.curSkillID = TableManager.GetValueFromUnionCell(this.data.ValueA[0], this.level, true);
		this.skillID = TableManager.GetValueFromUnionCell(this.data.ValueB[0], this.level, true);
	}

	// Token: 0x06017819 RID: 96281 RVA: 0x0073B5DF File Offset: 0x007399DF
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (base.owner.sgGetCurrentState() == 14 && base.owner.GetCurSkillID() == this.curSkillID)
			{
				base.owner.UseSkill(this.skillID, false);
			}
		});
	}

	// Token: 0x0601781A RID: 96282 RVA: 0x0073B606 File Offset: 0x00739A06
	public override void OnDead()
	{
		base.OnDead();
	}

	// Token: 0x0601781B RID: 96283 RVA: 0x0073B60E File Offset: 0x00739A0E
	public override void OnFinish()
	{
		base.OnFinish();
	}

	// Token: 0x04010E4E RID: 69198
	private int curSkillID;

	// Token: 0x04010E4F RID: 69199
	private int skillID;
}
