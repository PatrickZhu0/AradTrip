using System;
using System.Collections.Generic;

// Token: 0x02004433 RID: 17459
public class Skill1100 : BeSkill
{
	// Token: 0x060183E3 RID: 99299 RVA: 0x0078C697 File Offset: 0x0078AA97
	public Skill1100(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183E4 RID: 99300 RVA: 0x0078C6A4 File Offset: 0x0078AAA4
	public sealed override void OnPostInit()
	{
		base.OnPostInit();
		this.DoEffect(true);
		this.effectSkills = BeSkill.GetEffectSkills(this.skillData.ValueD, base.level);
		this.attackSpeed = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.normalAttackSpeedAdd = TableManager.GetValueFromUnionCell(this.skillData.ValueB[0], base.level, true);
		this.normalAttackAtttackAdd = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
		this.DoEffect(false);
	}

	// Token: 0x060183E5 RID: 99301 RVA: 0x0078C74C File Offset: 0x0078AB4C
	private void DoEffect(bool restore = false)
	{
		if (base.owner.GetEntityData() != null)
		{
			BeEntityData entityData = base.owner.GetEntityData();
			if (this.attackSpeed != 0)
			{
				entityData.SetAttributeValue(AttributeType.attackSpeed, (!restore) ? this.attackSpeed : (-this.attackSpeed), true);
			}
			if (this.effectSkills == null)
			{
				return;
			}
			for (int i = 0; i < this.effectSkills.Count; i++)
			{
				BeSkill skill = base.owner.GetSkill(this.effectSkills[i]);
				if (skill != null)
				{
					if (!restore)
					{
						BeSkill beSkill = skill;
						beSkill.skillSpeedFactor += this.normalAttackSpeedAdd;
						skill.attackAddRate += this.normalAttackAtttackAdd;
					}
					else
					{
						BeSkill beSkill2 = skill;
						beSkill2.skillSpeedFactor -= this.normalAttackSpeedAdd;
						skill.attackAddRate -= this.normalAttackAtttackAdd;
					}
				}
			}
		}
	}

	// Token: 0x040117F4 RID: 71668
	private List<int> effectSkills;

	// Token: 0x040117F5 RID: 71669
	private int attackSpeed;

	// Token: 0x040117F6 RID: 71670
	private int normalAttackSpeedAdd;

	// Token: 0x040117F7 RID: 71671
	private int normalAttackAtttackAdd;
}
