using System;

// Token: 0x020044FA RID: 17658
public class Skill5896 : BeSkill
{
	// Token: 0x0601892F RID: 100655 RVA: 0x007ACFA1 File Offset: 0x007AB3A1
	public Skill5896(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018930 RID: 100656 RVA: 0x007ACFAB File Offset: 0x007AB3AB
	public override bool CanUseSkill()
	{
		return base.CanUseSkill() && !base.owner.stateController.WillBeGrab();
	}
}
