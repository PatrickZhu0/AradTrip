using System;

// Token: 0x020044D3 RID: 17619
public class Skill3701 : Skill3715
{
	// Token: 0x06018859 RID: 100441 RVA: 0x007A7EE8 File Offset: 0x007A62E8
	public Skill3701(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601885A RID: 100442 RVA: 0x007A7EF2 File Offset: 0x007A62F2
	public override void OnInit()
	{
		base.OnInit();
		this.cancelSetMonsterDead = false;
	}
}
