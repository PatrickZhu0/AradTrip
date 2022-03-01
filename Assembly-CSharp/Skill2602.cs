using System;

// Token: 0x020044AF RID: 17583
public class Skill2602 : BeSkill
{
	// Token: 0x06018745 RID: 100165 RVA: 0x007A1165 File Offset: 0x0079F565
	public Skill2602(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018746 RID: 100166 RVA: 0x007A117A File Offset: 0x0079F57A
	public override void OnInit()
	{
		this.speed = new VRate((float)TableManager.GetValueFromUnionCell(this.skillData.ValueE[0], base.level, true) / 1000f);
	}

	// Token: 0x06018747 RID: 100167 RVA: 0x007A11AB File Offset: 0x0079F5AB
	public override void OnStart()
	{
		base.OnStart();
		this.SetSkillSpeed();
	}

	// Token: 0x06018748 RID: 100168 RVA: 0x007A11BC File Offset: 0x0079F5BC
	private void SetSkillSpeed()
	{
		VRate a = GlobalLogic.VALUE_1000;
		a += this.speed;
		this.skillSpeed = this.skillData.Speed * a.factor;
	}

	// Token: 0x06018749 RID: 100169 RVA: 0x007A1203 File Offset: 0x0079F603
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2)
		{
			this.skillSpeed = this.skillData.Speed;
		}
	}

	// Token: 0x04011A43 RID: 72259
	private VRate speed = VRate.zero;
}
