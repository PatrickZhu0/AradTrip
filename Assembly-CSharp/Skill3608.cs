using System;
using GameClient;

// Token: 0x02004443 RID: 17475
public class Skill3608 : Skill1512
{
	// Token: 0x0601843D RID: 99389 RVA: 0x0078EACB File Offset: 0x0078CECB
	public Skill3608(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601843E RID: 99390 RVA: 0x0078EAD5 File Offset: 0x0078CED5
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("3608") == InputManager.SlideSetting.SLIDE);
	}
}
