using System;

// Token: 0x0200442E RID: 17454
public class Skill1302 : Skill1015
{
	// Token: 0x060183CD RID: 99277 RVA: 0x0078C640 File Offset: 0x0078AA40
	public Skill1302(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183CE RID: 99278 RVA: 0x0078C64A File Offset: 0x0078AA4A
	public override void OnInit()
	{
		base.OnInit();
		this.addBuffFlag = "130201";
	}
}
