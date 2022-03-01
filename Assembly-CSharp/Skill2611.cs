using System;
using GameClient;

// Token: 0x0200443F RID: 17471
public class Skill2611 : Skill1512
{
	// Token: 0x06018432 RID: 99378 RVA: 0x0078E571 File Offset: 0x0078C971
	public Skill2611(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018433 RID: 99379 RVA: 0x0078E57B File Offset: 0x0078C97B
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("2611") == InputManager.SlideSetting.SLIDE);
	}
}
