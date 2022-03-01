using System;

// Token: 0x020044B9 RID: 17593
public class Skill3018 : BeSkill
{
	// Token: 0x06018797 RID: 100247 RVA: 0x007A3E75 File Offset: 0x007A2275
	public Skill3018(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018798 RID: 100248 RVA: 0x007A3E80 File Offset: 0x007A2280
	private void ReleaseSkill()
	{
		Skill3017 skill = base.owner.GetSkill(3017) as Skill3017;
		if (skill != null)
		{
			skill.StartCD();
			skill.RemoveButtonEffect();
		}
		this.handle1.Remove();
		this.handle1 = null;
		this.handle2.Remove();
		this.handle2 = null;
	}

	// Token: 0x06018799 RID: 100249 RVA: 0x007A3EDC File Offset: 0x007A22DC
	public override void OnFinish()
	{
		base.owner.SetTag(2, true);
		this.handle1 = base.owner.RegisterEvent(BeEventType.onTouchGround, delegate(object[] args)
		{
			this.ReleaseSkill();
		});
		this.handle2 = base.owner.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
		{
			this.ReleaseSkill();
		});
	}

	// Token: 0x04011A96 RID: 72342
	private BeEventHandle handle1;

	// Token: 0x04011A97 RID: 72343
	private BeEventHandle handle2;
}
