using System;

// Token: 0x020044C6 RID: 17606
public class Skill3502 : BeSkill
{
	// Token: 0x060187FC RID: 100348 RVA: 0x007A60D6 File Offset: 0x007A44D6
	public Skill3502(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187FD RID: 100349 RVA: 0x007A60E0 File Offset: 0x007A44E0
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x060187FE RID: 100350 RVA: 0x007A60E8 File Offset: 0x007A44E8
	public override void OnStart()
	{
		base.OnStart();
		if (!base.owner.paladinAttackCharge)
		{
			this.charge = false;
		}
	}
}
