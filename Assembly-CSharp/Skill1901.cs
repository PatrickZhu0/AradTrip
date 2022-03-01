using System;

// Token: 0x02004459 RID: 17497
public class Skill1901 : Skill1514
{
	// Token: 0x060184F2 RID: 99570 RVA: 0x00791BE8 File Offset: 0x0078FFE8
	public Skill1901(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060184F3 RID: 99571 RVA: 0x00791BF2 File Offset: 0x0078FFF2
	public override void OnInit()
	{
		base.OnInit();
		this._isYinluo = false;
	}
}
