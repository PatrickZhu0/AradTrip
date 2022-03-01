using System;

// Token: 0x02004100 RID: 16640
public class BDSkillWalkControl : BDEventBase
{
	// Token: 0x06016A70 RID: 92784 RVA: 0x006DD9C3 File Offset: 0x006DBDC3
	public BDSkillWalkControl(SkillWalkMode m, float speed, bool useSkillSpeed = false, float speed2 = 0f)
	{
		this.walkMode = m;
		this.walkPercent = VFactor.NewVFactorF(speed, 1000);
		this.useSkillSpeed = useSkillSpeed;
		this.walkPercent2 = VFactor.NewVFactorF(speed2, 1000);
	}

	// Token: 0x06016A71 RID: 92785 RVA: 0x006DD9FC File Offset: 0x006DBDFC
	public override void OnEvent(BeEntity pkEntity)
	{
		base.OnEvent(pkEntity);
		if (pkEntity.IsCastingSkill())
		{
			BeActor beActor = pkEntity as BeActor;
			if (beActor != null)
			{
				BeSkill currentSkill = beActor.GetCurrentSkill();
				if (currentSkill != null && !currentSkill.CanWalk())
				{
					if (this.useSkillSpeed)
					{
						this.walkPercent = currentSkill.GetWalkSpeedRate();
						this.walkPercent2 = currentSkill.GetWalkSpeedRate();
					}
					beActor.SetSkillWalkMode(this.walkMode, this.walkPercent, this.walkPercent2);
				}
			}
		}
	}

	// Token: 0x0401025D RID: 66141
	public SkillWalkMode walkMode;

	// Token: 0x0401025E RID: 66142
	public VFactor walkPercent;

	// Token: 0x0401025F RID: 66143
	public bool useSkillSpeed;

	// Token: 0x04010260 RID: 66144
	public VFactor walkPercent2;
}
