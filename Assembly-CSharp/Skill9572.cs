using System;

// Token: 0x02004500 RID: 17664
public class Skill9572 : BeSkill
{
	// Token: 0x0601894B RID: 100683 RVA: 0x007AD6BC File Offset: 0x007ABABC
	public Skill9572(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601894C RID: 100684 RVA: 0x007AD6C8 File Offset: 0x007ABAC8
	public override void OnInit()
	{
		this.minCD = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.maxCD = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this._containAwakeAndBuffSkill = (TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true) != 0);
	}

	// Token: 0x0601894D RID: 100685 RVA: 0x007AD74C File Offset: 0x007ABB4C
	public override bool CanUseSkill()
	{
		if (!this._containAwakeAndBuffSkill)
		{
			return base.CanUseSkill() && Mechanism50.GetCanCooldownSkills(base.owner.GetOwner() as BeActor, this.minCD, this.maxCD, null);
		}
		return base.CanUseSkill() && Mechanism50.GetCanReduceCDSkills(base.owner.GetOwner() as BeActor, this.minCD, null);
	}

	// Token: 0x04011BB9 RID: 72633
	protected int minCD;

	// Token: 0x04011BBA RID: 72634
	protected int maxCD;

	// Token: 0x04011BBB RID: 72635
	protected bool _containAwakeAndBuffSkill;
}
