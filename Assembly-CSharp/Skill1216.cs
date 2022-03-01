using System;
using GameClient;

// Token: 0x02004440 RID: 17472
public class Skill1216 : Skill1204
{
	// Token: 0x06018434 RID: 99380 RVA: 0x0078E59B File Offset: 0x0078C99B
	public Skill1216(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018435 RID: 99381 RVA: 0x0078E5A5 File Offset: 0x0078C9A5
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1216") == InputManager.SlideSetting.SLIDE);
	}
}
