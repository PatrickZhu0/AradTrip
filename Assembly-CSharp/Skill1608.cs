using System;
using GameClient;

// Token: 0x02004449 RID: 17481
public class Skill1608 : Skill1512
{
	// Token: 0x06018447 RID: 99399 RVA: 0x0078EB3D File Offset: 0x0078CF3D
	public Skill1608(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018448 RID: 99400 RVA: 0x0078EB47 File Offset: 0x0078CF47
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("1608") == InputManager.SlideSetting.SLIDE);
	}
}
