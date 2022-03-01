using System;

// Token: 0x02004470 RID: 17520
public class Skill1810 : BeSkill
{
	// Token: 0x060185C4 RID: 99780 RVA: 0x007970DE File Offset: 0x007954DE
	public Skill1810(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185C5 RID: 99781 RVA: 0x007970F3 File Offset: 0x007954F3
	public override void OnStart()
	{
		if (base.button != null)
		{
			base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
		}
	}

	// Token: 0x060185C6 RID: 99782 RVA: 0x00797114 File Offset: 0x00795514
	public override bool CanUseSkill()
	{
		bool flag = base.CanUseSkill();
		if (base.owner.buffController.HasBuffByID(this.m_CheckBuff) == null)
		{
			flag = false;
			if (base.button != null)
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onContinue, false);
			}
		}
		else if (base.button != null && flag)
		{
			base.button.AddEffect(ETCButton.eEffectType.onContinue, false);
		}
		return flag;
	}

	// Token: 0x060185C7 RID: 99783 RVA: 0x0079718D File Offset: 0x0079558D
	public override BeActor.SkillCannotUseType GetCannotUseType()
	{
		if (base.owner.buffController.HasBuffByID(this.m_CheckBuff) == null)
		{
			return BeActor.SkillCannotUseType.NO_CYZKJ;
		}
		return base.GetCannotUseType();
	}

	// Token: 0x04011962 RID: 72034
	protected int m_CheckBuff = 180013;
}
