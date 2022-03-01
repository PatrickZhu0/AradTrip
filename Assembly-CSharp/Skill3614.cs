using System;

// Token: 0x020044CC RID: 17612
public class Skill3614 : BeSkill
{
	// Token: 0x06018826 RID: 100390 RVA: 0x007A6AB2 File Offset: 0x007A4EB2
	public Skill3614(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018827 RID: 100391 RVA: 0x007A6ABC File Offset: 0x007A4EBC
	public override void OnInit()
	{
		base.OnInit();
	}

	// Token: 0x06018828 RID: 100392 RVA: 0x007A6AC4 File Offset: 0x007A4EC4
	public override void OnStart()
	{
		this.SetJumpBack();
	}

	// Token: 0x06018829 RID: 100393 RVA: 0x007A6ACC File Offset: 0x007A4ECC
	protected void SetJumpBack()
	{
		if (BattleMain.IsModePvP(base.battleType))
		{
			return;
		}
		this.canPressJumpBackCancel = true;
	}
}
