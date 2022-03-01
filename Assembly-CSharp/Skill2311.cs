using System;

// Token: 0x020044A0 RID: 17568
public class Skill2311 : BeSkill
{
	// Token: 0x06018700 RID: 100096 RVA: 0x0079F55A File Offset: 0x0079D95A
	public Skill2311(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018701 RID: 100097 RVA: 0x0079F564 File Offset: 0x0079D964
	public override void OnPostInit()
	{
		this.canPressJumpBackCancel = false;
		this.startJumpBackCnacelFlag = "231100";
		this.endJumpBackCnacelFlag = "231101";
	}
}
