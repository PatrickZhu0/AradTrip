using System;

// Token: 0x02004428 RID: 17448
public class Skill1104 : MoveCtrlSkill
{
	// Token: 0x060183B9 RID: 99257 RVA: 0x0078BC69 File Offset: 0x0078A069
	public Skill1104(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x17002011 RID: 8209
	// (get) Token: 0x060183BA RID: 99258 RVA: 0x0078BC73 File Offset: 0x0078A073
	protected override bool SettingSwitch
	{
		get
		{
			return base.owner.headShotSwitch;
		}
	}
}
