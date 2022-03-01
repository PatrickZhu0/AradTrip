using System;

// Token: 0x020044A4 RID: 17572
public class Skill2510 : BeSkill
{
	// Token: 0x06018729 RID: 100137 RVA: 0x007A0E32 File Offset: 0x0079F232
	public Skill2510(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601872A RID: 100138 RVA: 0x007A0E47 File Offset: 0x0079F247
	public override void OnInit()
	{
	}

	// Token: 0x0601872B RID: 100139 RVA: 0x007A0E4C File Offset: 0x0079F24C
	public override void OnClickAgain()
	{
		if (this.skillPhase > 0)
		{
			if (base.IsCanceled() || base.owner.GetPosition().z > VInt.Float2VIntValue(0.1f))
			{
				return;
			}
			base.owner.CancelSkill(this.skillID, true);
			this.UseNextSkill();
		}
	}

	// Token: 0x0601872C RID: 100140 RVA: 0x007A0EAB File Offset: 0x0079F2AB
	public override void OnStart()
	{
		this.skillPhase = 1;
	}

	// Token: 0x0601872D RID: 100141 RVA: 0x007A0EB4 File Offset: 0x0079F2B4
	private void UseNextSkill()
	{
		if (base.owner.HasSkill(this.nextSkillID))
		{
			base.owner.delayCaller.DelayCall(100, delegate
			{
				base.owner.UseSkill(this.nextSkillID, true);
			}, 0, 0, false);
		}
	}

	// Token: 0x0601872E RID: 100142 RVA: 0x007A0EEE File Offset: 0x0079F2EE
	public override void OnCancel()
	{
		this.skillPhase = 0;
	}

	// Token: 0x0601872F RID: 100143 RVA: 0x007A0EF7 File Offset: 0x0079F2F7
	public override void OnFinish()
	{
		this.OnCancel();
	}

	// Token: 0x04011A38 RID: 72248
	protected int nextSkillID = 2511;

	// Token: 0x04011A39 RID: 72249
	protected int skillPhase;
}
