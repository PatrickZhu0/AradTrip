using System;

// Token: 0x020044CD RID: 17613
public class Skill3615 : BeSkill
{
	// Token: 0x0601882A RID: 100394 RVA: 0x007A6AF0 File Offset: 0x007A4EF0
	public Skill3615(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x0601882B RID: 100395 RVA: 0x007A6AFA File Offset: 0x007A4EFA
	public override void OnInit()
	{
		base.OnInit();
		this.startSwitchId = "361501";
		this.endSwitchId = "361502";
	}

	// Token: 0x0601882C RID: 100396 RVA: 0x007A6B18 File Offset: 0x007A4F18
	public override void OnStart()
	{
		base.OnStart();
		this.handleA = base.owner.RegisterEvent(BeEventType.onSkillCurFrame, delegate(object[] args)
		{
			string a = (string)args[0];
			if (a == this.startSwitchId)
			{
				this.switchFlag = true;
				this.SwitchState();
			}
			else if (a == this.endSwitchId)
			{
				this.switchFlag = false;
				base.ResetButtonEffect();
			}
		});
	}

	// Token: 0x0601882D RID: 100397 RVA: 0x007A6B40 File Offset: 0x007A4F40
	public override void OnClickAgain()
	{
		base.OnClickAgain();
		if (!this.skillState.IsRunning() || !this.switchFlag)
		{
			return;
		}
		this.switchFlag = false;
		base.ResetButtonEffect();
		if (this.curPhase == 2)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
		else if (this.curPhase == 3)
		{
			((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
		}
	}

	// Token: 0x0601882E RID: 100398 RVA: 0x007A6BD8 File Offset: 0x007A4FD8
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		this.curPhase = phase;
	}

	// Token: 0x0601882F RID: 100399 RVA: 0x007A6BE8 File Offset: 0x007A4FE8
	protected void SwitchState()
	{
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		base.ChangeButtonEffect();
	}

	// Token: 0x06018830 RID: 100400 RVA: 0x007A6BF7 File Offset: 0x007A4FF7
	public override void OnCancel()
	{
		base.OnCancel();
		base.ResetButtonEffect();
	}

	// Token: 0x06018831 RID: 100401 RVA: 0x007A6C05 File Offset: 0x007A5005
	public override void OnFinish()
	{
		base.OnFinish();
		base.ResetButtonEffect();
	}

	// Token: 0x04011AE7 RID: 72423
	protected string startSwitchId;

	// Token: 0x04011AE8 RID: 72424
	protected string endSwitchId;

	// Token: 0x04011AE9 RID: 72425
	protected bool switchFlag;
}
