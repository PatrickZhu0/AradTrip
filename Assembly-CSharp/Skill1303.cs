using System;

// Token: 0x0200442F RID: 17455
public class Skill1303 : Skill1015
{
	// Token: 0x060183CF RID: 99279 RVA: 0x0078C65D File Offset: 0x0078AA5D
	public Skill1303(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060183D0 RID: 99280 RVA: 0x0078C667 File Offset: 0x0078AA67
	public override void OnInit()
	{
		base.OnInit();
		this.addBuffFlag = "1303101";
	}
}
