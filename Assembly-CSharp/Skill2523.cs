using System;

// Token: 0x020044A9 RID: 17577
public class Skill2523 : BeSkill
{
	// Token: 0x0601873D RID: 100157 RVA: 0x007A1093 File Offset: 0x0079F493
	public Skill2523(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601873E RID: 100158 RVA: 0x007A10B3 File Offset: 0x0079F4B3
	public override void OnInit()
	{
	}

	// Token: 0x0601873F RID: 100159 RVA: 0x007A10B8 File Offset: 0x0079F4B8
	public override void OnPostInit()
	{
		if (base.owner != null)
		{
			BeSkill skill = base.owner.GetSkill(this.nextSkillID);
			if (skill != null)
			{
				skill.level = base.level;
			}
			BeSkill skill2 = base.owner.GetSkill(this.sxtSkillID);
			if (skill2 != null)
			{
				skill2.pressMode = SkillPressMode.TWO_PRESS;
			}
		}
	}

	// Token: 0x04011A41 RID: 72257
	protected int sxtSkillID = 2510;

	// Token: 0x04011A42 RID: 72258
	protected int nextSkillID = 2511;
}
