using System;

// Token: 0x020044A5 RID: 17573
public class Skill2517 : Skill2522
{
	// Token: 0x06018731 RID: 100145 RVA: 0x007A0F29 File Offset: 0x0079F329
	public Skill2517(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018732 RID: 100146 RVA: 0x007A0F33 File Offset: 0x0079F333
	public override void OnStart()
	{
		this.curFrameFlag = "251701";
		this.effectId = ((!BattleMain.IsModePvP(base.owner.battleType)) ? 25170 : 25171);
		base.OnStart();
	}
}
