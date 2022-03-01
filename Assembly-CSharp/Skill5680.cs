using System;

// Token: 0x020044F3 RID: 17651
public class Skill5680 : BeSkill
{
	// Token: 0x060188FF RID: 100607 RVA: 0x007ABDD6 File Offset: 0x007AA1D6
	public Skill5680(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018900 RID: 100608 RVA: 0x007ABDE0 File Offset: 0x007AA1E0
	public override void OnPostInit()
	{
		base.OnPostInit();
	}

	// Token: 0x06018901 RID: 100609 RVA: 0x007ABDE8 File Offset: 0x007AA1E8
	public override void OnStart()
	{
		base.OnStart();
	}

	// Token: 0x06018902 RID: 100610 RVA: 0x007ABDF0 File Offset: 0x007AA1F0
	public override void OnCancel()
	{
		base.OnCancel();
		this.StopSkill();
	}

	// Token: 0x06018903 RID: 100611 RVA: 0x007ABDFE File Offset: 0x007AA1FE
	public override void OnFinish()
	{
		this.StopSkill();
		base.OnFinish();
	}

	// Token: 0x06018904 RID: 100612 RVA: 0x007ABE0C File Offset: 0x007AA20C
	private void StopSkill()
	{
		if (this.partnerMonster != null)
		{
			this.partnerMonster.Locomote(new BeStateData(0, 0), true);
		}
		if (this.protectMonster != null)
		{
			this.protectMonster.DoDead(false);
		}
		this.protectMonster = null;
		this.partnerMonster = null;
	}

	// Token: 0x04011B8D RID: 72589
	public BeActor partnerMonster;

	// Token: 0x04011B8E RID: 72590
	public BeActor protectMonster;
}
