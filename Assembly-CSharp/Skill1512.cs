using System;
using GameClient;

// Token: 0x02004448 RID: 17480
public class Skill1512 : Skill1204
{
	// Token: 0x06018444 RID: 99396 RVA: 0x0078E4F1 File Offset: 0x0078C8F1
	public Skill1512(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018445 RID: 99397 RVA: 0x0078E4FB File Offset: 0x0078C8FB
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1512") == InputManager.SlideSetting.SLIDE);
	}

	// Token: 0x06018446 RID: 99398 RVA: 0x0078E51B File Offset: 0x0078C91B
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.strValue = new string[]
		{
			"远",
			"中",
			"近"
		};
	}
}
