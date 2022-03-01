using System;
using System.Collections.Generic;

// Token: 0x020044C8 RID: 17608
public class Skill3601 : BeSkill
{
	// Token: 0x06018803 RID: 100355 RVA: 0x007A6107 File Offset: 0x007A4507
	public Skill3601(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018804 RID: 100356 RVA: 0x007A6124 File Offset: 0x007A4524
	public override void OnInit()
	{
		base.OnInit();
		this.startSwitchId = "360101";
		this.endSwitchId = "360102";
		this.interruptIdList.Clear();
		if (this.skillData.ValueA.Count > 0)
		{
			for (int i = 0; i < this.skillData.ValueA.Count; i++)
			{
				this.interruptIdList.Add(TableManager.GetValueFromUnionCell(this.skillData.ValueA[i], base.level, true));
			}
		}
	}

	// Token: 0x06018805 RID: 100357 RVA: 0x007A61B7 File Offset: 0x007A45B7
	public override void OnStart()
	{
		base.OnStart();
		this.switchFlag = false;
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

	// Token: 0x06018806 RID: 100358 RVA: 0x007A61E8 File Offset: 0x007A45E8
	public override void OnClickAgain()
	{
		base.OnClickAgain();
		if (!this.skillState.IsRunning() || !this.switchFlag)
		{
			return;
		}
		if (this.curPhase == 2)
		{
			return;
		}
		base.ResetButtonEffect();
		((BeActorStateGraph)base.owner.GetStateGraph()).ExecuteNextPhaseSkill();
	}

	// Token: 0x06018807 RID: 100359 RVA: 0x007A6240 File Offset: 0x007A4640
	public override bool CanBeInterrupt(int skillId)
	{
		bool result = base.CanBeInterrupt(skillId);
		if (this.curPhase == 2 && base.owner.GetCurrentFrame() > this.interruptFrame && this.interruptIdList.Contains(skillId))
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06018808 RID: 100360 RVA: 0x007A628B File Offset: 0x007A468B
	protected void SwitchState()
	{
		this.skillButtonState = BeSkill.SkillState.WAIT_FOR_NEXT_PRESS;
		base.ChangeButtonEffect();
	}

	// Token: 0x06018809 RID: 100361 RVA: 0x007A629A File Offset: 0x007A469A
	public override void OnCancel()
	{
		base.OnCancel();
		base.ResetButtonEffect();
	}

	// Token: 0x0601880A RID: 100362 RVA: 0x007A62A8 File Offset: 0x007A46A8
	public override void OnFinish()
	{
		base.OnFinish();
		base.ResetButtonEffect();
	}

	// Token: 0x04011AD4 RID: 72404
	protected string startSwitchId;

	// Token: 0x04011AD5 RID: 72405
	protected string endSwitchId;

	// Token: 0x04011AD6 RID: 72406
	protected bool switchFlag;

	// Token: 0x04011AD7 RID: 72407
	private int interruptFrame = 8;

	// Token: 0x04011AD8 RID: 72408
	private List<int> interruptIdList = new List<int>();
}
