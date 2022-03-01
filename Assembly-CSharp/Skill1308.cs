using System;

// Token: 0x02004430 RID: 17456
public class Skill1308 : Skill1015
{
	// Token: 0x060183D1 RID: 99281 RVA: 0x0078C67A File Offset: 0x0078AA7A
	public Skill1308(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183D2 RID: 99282 RVA: 0x0078C684 File Offset: 0x0078AA84
	public override void OnInit()
	{
		base.OnInit();
		this.addBuffFlag = "130801";
	}
}
