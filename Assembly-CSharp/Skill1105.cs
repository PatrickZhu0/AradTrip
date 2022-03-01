using System;
using System.Collections.Generic;

// Token: 0x02004436 RID: 17462
public class Skill1105 : BeSkill
{
	// Token: 0x060183F3 RID: 99315 RVA: 0x0078CD22 File Offset: 0x0078B122
	public Skill1105(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183F4 RID: 99316 RVA: 0x0078CD44 File Offset: 0x0078B144
	public override void OnInit()
	{
		base.OnInit();
		this.hitThroughRate = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		this.effectSkills.Clear();
		for (int i = 0; i < this.skillData.ValueB.Count; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(this.skillData.ValueB[i], base.level, true);
			this.effectSkills.Add(valueFromUnionCell);
		}
		this.weaponType = TableManager.GetValueFromUnionCell(this.skillData.ValueC[0], base.level, true);
	}

	// Token: 0x060183F5 RID: 99317 RVA: 0x0078CDF8 File Offset: 0x0078B1F8
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.RemoveHandle();
		this.DoEffect();
	}

	// Token: 0x060183F6 RID: 99318 RVA: 0x0078CE0C File Offset: 0x0078B20C
	private void DoEffect()
	{
		if (base.owner == null || base.owner.GetWeaponType() != this.weaponType)
		{
			return;
		}
		if (base.owner.buffController.HasBuffByID(1400326) != null)
		{
			this.hitThroughRate = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true) + new VRate(0.06f);
		}
		this.handler = base.owner.RegisterEvent(BeEventType.onAfterGenBullet, delegate(object[] args)
		{
			BeProjectile beProjectile = args[0] as BeProjectile;
			int castSkillID = base.owner.GetCastSkillID();
			if (beProjectile != null && this.effectSkills.Contains(castSkillID))
			{
				beProjectile.hitThroughFactor += this.hitThroughRate;
			}
		});
	}

	// Token: 0x060183F7 RID: 99319 RVA: 0x0078CEAB File Offset: 0x0078B2AB
	private void RemoveHandle()
	{
		if (this.handler != null)
		{
			this.handler.Remove();
			this.handler = null;
		}
	}

	// Token: 0x060183F8 RID: 99320 RVA: 0x0078CECA File Offset: 0x0078B2CA
	public override void OnWeaponChange()
	{
		this.OnPostInit();
	}

	// Token: 0x040117FB RID: 71675
	private VRate hitThroughRate = 0;

	// Token: 0x040117FC RID: 71676
	private List<int> effectSkills = new List<int>();

	// Token: 0x040117FD RID: 71677
	private BeEventHandle handler;

	// Token: 0x040117FE RID: 71678
	private int weaponType;
}
