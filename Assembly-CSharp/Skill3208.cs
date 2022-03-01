using System;

// Token: 0x020044C2 RID: 17602
public class Skill3208 : BeSkill
{
	// Token: 0x060187D5 RID: 100309 RVA: 0x007A4FC5 File Offset: 0x007A33C5
	public Skill3208(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x060187D6 RID: 100310 RVA: 0x007A4FDA File Offset: 0x007A33DA
	public override void OnInit()
	{
	}

	// Token: 0x060187D7 RID: 100311 RVA: 0x007A4FDC File Offset: 0x007A33DC
	public override void OnStart()
	{
		this.handle = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string text = (string)args[0];
			if (text.Equals(this.frameFlag))
			{
				base.SetSkillSpeedWithSkillData();
			}
		});
	}

	// Token: 0x060187D8 RID: 100312 RVA: 0x007A4FFD File Offset: 0x007A33FD
	public override void OnCancel()
	{
		this.RemoveHandles();
	}

	// Token: 0x060187D9 RID: 100313 RVA: 0x007A5005 File Offset: 0x007A3405
	public override void OnFinish()
	{
		this.RemoveHandles();
	}

	// Token: 0x060187DA RID: 100314 RVA: 0x007A500D File Offset: 0x007A340D
	private void RemoveHandles()
	{
		if (this.handle != null)
		{
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x04011AB3 RID: 72371
	private BeEventHandle handle;

	// Token: 0x04011AB4 RID: 72372
	private string frameFlag = "320801";
}
