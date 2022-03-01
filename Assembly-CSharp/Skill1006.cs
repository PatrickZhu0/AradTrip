using System;

// Token: 0x02004427 RID: 17447
public class Skill1006 : MoveCtrlSkill
{
	// Token: 0x060183B7 RID: 99255 RVA: 0x0078BC52 File Offset: 0x0078A052
	public Skill1006(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x17002010 RID: 8208
	// (get) Token: 0x060183B8 RID: 99256 RVA: 0x0078BC5C File Offset: 0x0078A05C
	protected override bool SettingSwitch
	{
		get
		{
			return base.owner.floatShotSwitch;
		}
	}
}
