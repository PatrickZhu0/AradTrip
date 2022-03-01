using System;
using GameClient;

// Token: 0x02004444 RID: 17476
public class Skill3600 : Skill1512
{
	// Token: 0x0601843F RID: 99391 RVA: 0x0078EAF5 File Offset: 0x0078CEF5
	public Skill3600(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018440 RID: 99392 RVA: 0x0078EAFF File Offset: 0x0078CEFF
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("3600") == InputManager.SlideSetting.SLIDE);
	}
}
