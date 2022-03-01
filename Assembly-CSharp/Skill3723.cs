using System;

// Token: 0x020044D2 RID: 17618
public class Skill3723 : Skill3715
{
	// Token: 0x06018857 RID: 100439 RVA: 0x007A7ECF File Offset: 0x007A62CF
	public Skill3723(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018858 RID: 100440 RVA: 0x007A7ED9 File Offset: 0x007A62D9
	public override void OnInit()
	{
		base.OnInit();
		this.cancelSetMonsterDead = false;
	}
}
