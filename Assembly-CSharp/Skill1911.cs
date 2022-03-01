using System;

// Token: 0x02004474 RID: 17524
public class Skill1911 : BeSkill
{
	// Token: 0x060185D6 RID: 99798 RVA: 0x00797496 File Offset: 0x00795896
	public Skill1911(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060185D7 RID: 99799 RVA: 0x007974A0 File Offset: 0x007958A0
	public override void OnWeaponChange()
	{
		base.OnWeaponChange();
		BDEntityActionInfo actionInfoBySkillID = base.owner.GetActionInfoBySkillID(this.skillID);
		if (actionInfoBySkillID != null)
		{
			this.charge = base.owner.GetActionInfoBySkillID(this.skillID).useCharge;
			this.chargeConfig = actionInfoBySkillID.chargeConfig;
		}
	}
}
