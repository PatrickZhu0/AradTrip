using System;

// Token: 0x02004434 RID: 17460
public class Skill1101 : Skill2522
{
	// Token: 0x060183E6 RID: 99302 RVA: 0x0078C9FE File Offset: 0x0078ADFE
	public Skill1101(int sid, int skillLevel) : base(sid, skillLevel)
	{
		this.effectId = 11010;
		this.attachEffectId = 10150;
		this.curFrameFlag = "110101";
		this.skillId = 1015;
	}

	// Token: 0x060183E7 RID: 99303 RVA: 0x0078CA34 File Offset: 0x0078AE34
	protected override int GetBulletNum()
	{
		Skill1015 skill = (Skill1015)base.owner.GetSkill(this.skillId);
		if (skill == null)
		{
			return 0;
		}
		return skill.GetLeftBulletNum();
	}

	// Token: 0x060183E8 RID: 99304 RVA: 0x0078CA68 File Offset: 0x0078AE68
	protected override void SetSilverBulletCount()
	{
		Skill1015 skill = (Skill1015)base.owner.GetSkill(this.skillId);
		if (skill == null)
		{
			return;
		}
		skill.ConsumBulletCount();
	}
}
