using System;
using GameClient;

// Token: 0x0200444B RID: 17483
public class Skill2010 : Skill1204
{
	// Token: 0x0601844A RID: 99402 RVA: 0x0078EB71 File Offset: 0x0078CF71
	public Skill2010(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601844B RID: 99403 RVA: 0x0078EB7B File Offset: 0x0078CF7B
	public override void OnInit()
	{
		base.OnInit();
		this.canSlide = (Singleton<SettingManager>.GetInstance().GetSlideMode("2010") == InputManager.SlideSetting.SLIDE);
	}

	// Token: 0x0601844C RID: 99404 RVA: 0x0078EB9B File Offset: 0x0078CF9B
	public override void OnPostInit()
	{
		base.OnPostInit();
		this.strValue = new string[]
		{
			"上",
			"前",
			"下"
		};
	}
}
