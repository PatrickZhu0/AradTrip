using System;

// Token: 0x02004425 RID: 17445
public class Skill10000 : BeSkill
{
	// Token: 0x060183AF RID: 99247 RVA: 0x0078BB05 File Offset: 0x00789F05
	public Skill10000(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183B0 RID: 99248 RVA: 0x0078BB0F File Offset: 0x00789F0F
	public override void OnStart()
	{
		if (base.owner != null)
		{
		}
	}

	// Token: 0x060183B1 RID: 99249 RVA: 0x0078BB1C File Offset: 0x00789F1C
	public override void OnUpdate(int iDeltime)
	{
		if (base.button != null)
		{
			if (!this.CanForceUseSkill())
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onSummonAccompy, false);
			}
			else
			{
				base.button.AddEffect(ETCButton.eEffectType.onSummonAccompy, false);
			}
		}
	}

	// Token: 0x060183B2 RID: 99250 RVA: 0x0078BB5C File Offset: 0x00789F5C
	public override int GetCurrentCD()
	{
		return this.fixCD * (VRate.one - this.cdReduceRate).factor;
	}

	// Token: 0x060183B3 RID: 99251 RVA: 0x0078BB8C File Offset: 0x00789F8C
	public override bool CanForceUseSkill()
	{
		if (base.isCooldown)
		{
			if (base.button != null)
			{
				base.button.RemoveEffect(ETCButton.eEffectType.onSummonAccompy, false);
			}
			return false;
		}
		if (base.button != null)
		{
			base.button.AddEffect(ETCButton.eEffectType.onSummonAccompy, false);
		}
		return true;
	}

	// Token: 0x040117DA RID: 71642
	public int fixCD;
}
