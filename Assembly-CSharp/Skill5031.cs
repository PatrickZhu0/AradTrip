using System;
using GameClient;

// Token: 0x020044D6 RID: 17622
internal class Skill5031 : BeSkill
{
	// Token: 0x06018878 RID: 100472 RVA: 0x007A83FF File Offset: 0x007A67FF
	public Skill5031(int sid, int skillLevel) : base(sid, skillLevel)
	{
	}

	// Token: 0x06018879 RID: 100473 RVA: 0x007A8419 File Offset: 0x007A6819
	public override void OnInit()
	{
		base.OnInit();
		this.pressDeltaTime = TableManager.GetValueFromUnionCell(this.skillData.ValueA[0], base.level, true);
		if (this.pressDeltaTime == 0)
		{
			this.pressDeltaTime = 100;
		}
	}

	// Token: 0x0601887A RID: 100474 RVA: 0x007A8458 File Offset: 0x007A6858
	public override void OnStart()
	{
		base.OnStart();
		this.checkBeGraberFlag = false;
		this.checkLifeTime = true;
		this.pressFlag = false;
		this.timer = 0;
		this.grapTime = 0;
		if (BattleMain.IsModePvP(base.battleType) && BeClientSwitch.FunctionIsOpen(ClientSwitchType.XuanWuEndToFallProtect))
		{
			this.handleA = base.owner.RegisterEvent(BeEventType.onExcuteGrab, delegate(object[] args)
			{
				BeActor actor = (BeActor)args[1];
				if (actor != null && !actor.IsDead())
				{
					this.handleB = actor.RegisterEvent(BeEventType.onHurt, delegate(object[] args1)
					{
						int num = (int)args1[0];
						if (num != 0)
						{
							actor.SetTag(1, true);
							actor.protectManager.StartFallHurtCount();
						}
					});
				}
			});
		}
	}

	// Token: 0x0601887B RID: 100475 RVA: 0x007A84CC File Offset: 0x007A68CC
	public override void OnEnterPhase(int phase)
	{
		base.OnEnterPhase(phase);
		if (phase == 2 && base.owner.GrapedActorList.Count > 0)
		{
			this.beGraber = base.owner.GrapedActorList[0];
			this.checkBeGraberFlag = true;
		}
		else if (phase == 3)
		{
			this.checkBeGraberFlag = false;
			if (this.pressCount > 0 && this.beGraber != null)
			{
				this.beGraber.EndPressCount();
			}
		}
	}

	// Token: 0x0601887C RID: 100476 RVA: 0x007A8550 File Offset: 0x007A6950
	public override void OnUpdate(int iDeltime)
	{
		base.OnUpdate(iDeltime);
		if (this.checkBeGraberFlag)
		{
			this.timer += iDeltime;
			if (this.beGraber == null || this.beGraber.IsDead())
			{
				base.owner.sgSwitchStates(new BeStateData(0, 0));
			}
			if (this.beGraber != null && !this.beGraber.IsDead())
			{
				if (!this.pressFlag)
				{
					this.grapTime = base.owner.GetStateGraph().GetCurrentStateData().uiTimeOut;
					this.pressTotalCount = this.grapTime / (2 * this.pressDeltaTime);
					this.beGraber.StartPressCount(BeActor.QuickPressType.GRAP, base.owner);
					this.addPressCountEvent = this.beGraber.RegisterEvent(BeEventType.onGrabPressCountAdd, delegate(object[] args)
					{
						int[] array = (int[])args[0];
						if (array != null && array.Length > 0)
						{
							array[0] = 0;
						}
						if (!this.isPressInCD)
						{
							this.pressCount++;
							this.isPressInCD = true;
						}
					});
					this.pressFlag = true;
				}
				this.UpdatePressCD(iDeltime);
				if (this.grapTime > 0 && 2 * this.pressTotalCount * this.timer + this.pressCount * this.grapTime > 2 * this.pressTotalCount * this.grapTime)
				{
					this.beGraber.EndPressCount();
					base.owner.CancelSkill(this.skillID, false);
					base.owner.Locomote(new BeStateData(0, 0), true);
				}
			}
		}
		this.CheckMonsterLife();
	}

	// Token: 0x0601887D RID: 100477 RVA: 0x007A86B8 File Offset: 0x007A6AB8
	public override void OnCancel()
	{
		base.OnCancel();
		this.checkLifeTime = false;
		this.pressFlag = false;
		this.timer = 0;
		this.grapTime = 0;
		this.pressTotalCount = 20;
		this.pressCount = 0;
		this.pressDeltaTimeSec = 0;
		this.isPressInCD = false;
		this.ClearHandleEvent();
		if (this.beGraber != null)
		{
			this.beGraber.buffController.RemoveBuff(361212, 0, 0);
		}
	}

	// Token: 0x0601887E RID: 100478 RVA: 0x007A872C File Offset: 0x007A6B2C
	public override void OnFinish()
	{
		base.OnFinish();
		this.checkLifeTime = false;
		this.pressFlag = false;
		this.timer = 0;
		this.grapTime = 0;
		this.pressTotalCount = 20;
		this.pressCount = 0;
		this.pressDeltaTimeSec = 0;
		this.isPressInCD = false;
		this.ClearHandleEvent();
		if (this.beGraber != null)
		{
			this.beGraber.buffController.RemoveBuff(361212, 0, 0);
		}
	}

	// Token: 0x0601887F RID: 100479 RVA: 0x007A87A0 File Offset: 0x007A6BA0
	protected void CheckMonsterLife()
	{
		if (!this.checkLifeTime)
		{
			return;
		}
		if (base.owner == null)
		{
			return;
		}
		BeBuff beBuff = base.owner.buffController.HasBuffByID(12);
		if (beBuff == null)
		{
			return;
		}
		if (beBuff.duration - beBuff.runTime < GlobalLogic.VALUE_500)
		{
			BeBuff beBuff2 = beBuff;
			beBuff2.duration += GlobalLogic.VALUE_500;
		}
	}

	// Token: 0x06018880 RID: 100480 RVA: 0x007A8817 File Offset: 0x007A6C17
	private void UpdatePressCD(int iDeltaTime)
	{
		if (this.isPressInCD)
		{
			this.pressDeltaTimeSec += iDeltaTime;
			if (this.pressDeltaTimeSec >= this.pressDeltaTime)
			{
				this.pressDeltaTimeSec = 0;
				this.isPressInCD = false;
			}
		}
	}

	// Token: 0x06018881 RID: 100481 RVA: 0x007A8851 File Offset: 0x007A6C51
	private void ClearHandleEvent()
	{
		if (this.addPressCountEvent != null)
		{
			this.addPressCountEvent.Remove();
			this.addPressCountEvent = null;
		}
	}

	// Token: 0x04011B18 RID: 72472
	protected int pressDeltaTime = 100;

	// Token: 0x04011B19 RID: 72473
	protected bool checkBeGraberFlag;

	// Token: 0x04011B1A RID: 72474
	protected BeActor beGraber;

	// Token: 0x04011B1B RID: 72475
	private bool checkLifeTime;

	// Token: 0x04011B1C RID: 72476
	private bool pressFlag;

	// Token: 0x04011B1D RID: 72477
	private int timer;

	// Token: 0x04011B1E RID: 72478
	private int grapTime;

	// Token: 0x04011B1F RID: 72479
	private int pressCount;

	// Token: 0x04011B20 RID: 72480
	private int pressTotalCount = 20;

	// Token: 0x04011B21 RID: 72481
	private bool isPressInCD;

	// Token: 0x04011B22 RID: 72482
	private int pressDeltaTimeSec;

	// Token: 0x04011B23 RID: 72483
	private BeEventHandle addPressCountEvent;
}
