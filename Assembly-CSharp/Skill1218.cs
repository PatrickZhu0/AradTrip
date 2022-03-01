using System;
using GameClient;

// Token: 0x0200443E RID: 17470
public class Skill1218 : Skill1512
{
	// Token: 0x06018430 RID: 99376 RVA: 0x0078E547 File Offset: 0x0078C947
	public Skill1218(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018431 RID: 99377 RVA: 0x0078E551 File Offset: 0x0078C951
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1218") == InputManager.SlideSetting.SLIDE);
	}
}
