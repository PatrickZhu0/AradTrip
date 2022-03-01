using System;
using behaviac;
using GameClient;

// Token: 0x02004118 RID: 16664
public class BeAISkillCommand : BeAICommand
{
	// Token: 0x06016AFF RID: 92927 RVA: 0x006E0A9E File Offset: 0x006DEE9E
	public BeAISkillCommand(BeEntity e) : base(e, "AISkillCommand")
	{
	}

	// Token: 0x06016B00 RID: 92928 RVA: 0x006E0AB7 File Offset: 0x006DEEB7
	public override void Reset(BeEntity e)
	{
		base.Reset(e);
		this.skillTimeAcc = 0;
		this.skillID = 0;
		this.inputSeq = null;
		this.inputExecuteCount = 0;
		this.handle = null;
		this.keepDistanceAcc = GlobalLogic.VALUE_200;
	}

	// Token: 0x06016B01 RID: 92929 RVA: 0x006E0AEE File Offset: 0x006DEEEE
	public void Init(AIInputData inputData)
	{
		this.cmdType = AI_COMMAND.SKILL;
		this.inputSeq = inputData;
		this.duraction = 10000;
	}

	// Token: 0x06016B02 RID: 92930 RVA: 0x006E0B0C File Offset: 0x006DEF0C
	public override void OnTick(int deltaTime)
	{
		if (this.inputSeq.inputs.Count <= 0 && !this.inputSeq.needKeepDistance)
		{
			this.duraction = 0;
			return;
		}
		this.skillTimeAcc += deltaTime;
		if (this.inputSeq.inputs.Count > 0 && this.skillTimeAcc >= this.inputSeq.inputs[0].delay)
		{
			this.skillTimeAcc -= this.inputSeq.inputs[0].delay;
			this.ExecuteInput(deltaTime);
		}
		if (this.inputSeq.needKeepDistance)
		{
			this.UpdateKeepDistanceMove(deltaTime);
		}
	}

	// Token: 0x06016B03 RID: 92931 RVA: 0x006E0BD4 File Offset: 0x006DEFD4
	public override void OnEnd()
	{
		base.OnEnd();
		BeActor beActor = this.entity as BeActor;
		if (beActor != null)
		{
			beActor.SetAttackButtonState(ButtonState.RELEASE, true);
		}
	}

	// Token: 0x06016B04 RID: 92932 RVA: 0x006E0C04 File Offset: 0x006DF004
	private void UpdateKeepDistanceMove(int deltaTime)
	{
		if (!this.inputSeq.lastInputData.moveInSkillState)
		{
			return;
		}
		if (this.entity == null)
		{
			return;
		}
		this.keepDistanceAcc += deltaTime;
		if (this.keepDistanceAcc < GlobalLogic.VALUE_200)
		{
			return;
		}
		this.keepDistanceAcc -= GlobalLogic.VALUE_200;
		int num = this.inputSeq.lastInputData.skillID;
		BeActor beActor = this.entity as BeActor;
		if (beActor == null || !beActor.IsCastingSkill())
		{
			this.inputSeq.needKeepDistance = false;
			return;
		}
		BeSkill currentSkill = beActor.GetCurrentSkill();
		if (currentSkill == null || (currentSkill.skillID != num && !currentSkill.walk))
		{
			this.inputSeq.needKeepDistance = false;
			return;
		}
		BeActorAIManager beActorAIManager = this.aiManager as BeActorAIManager;
		if (beActorAIManager != null)
		{
			if (beActor.CurrentBeScene == null)
			{
				return;
			}
			BeActor beActor2 = beActor.CurrentBeScene.FindTargetByPriority(beActor, VInt.NewVInt(beActorAIManager.sight, GlobalLogic.VALUE_1000));
			if (beActor2 != null)
			{
				VInt3 targetPos;
				bool keepDistancePos = BeUtility.GetKeepDistancePos(beActor2, beActor, this.inputSeq.lastInputData.moveKeepDistance, GlobalLogic.VALUE_3000, out targetPos);
				if (keepDistancePos)
				{
					this.aiManager.DoWalk(targetPos);
				}
			}
			else if (currentSkill != null && !currentSkill.IsCanceled() && currentSkill.canPressJumpBackCancel)
			{
				beActor.Locomote(new BeStateData(0, 0), false);
				this.inputSeq.needKeepDistance = false;
			}
		}
	}

	// Token: 0x06016B05 RID: 92933 RVA: 0x006E0D84 File Offset: 0x006DF184
	private void ExecuteInput(int deltaTime)
	{
		if (this.inputSeq.inputs.Count <= 0)
		{
			return;
		}
		Input lastInputData = this.inputSeq.inputs[0];
		this.inputSeq.lastInputData = lastInputData;
		this.inputSeq.inputs.RemoveAt(0);
		this.inputExecuteCount++;
		this.skillTimeAcc = 0;
		if (lastInputData.moveInSkillState)
		{
			this.inputSeq.needKeepDistance = true;
		}
		else
		{
			this.inputSeq.needKeepDistance = false;
		}
		int num = lastInputData.skillID;
		if (this.entity != null && num > 0)
		{
			BeEntity aiTarget = this.entity.aiManager.aiTarget;
			if (aiTarget != null && this.inputExecuteCount == 1)
			{
				this.entity.SetFace(aiTarget.GetPosition().x < this.entity.GetPosition().x, true, false);
			}
			BeActor actor = this.entity as BeActor;
			if (actor != null)
			{
				BeSkill skill = actor.GetSkill(num);
				if (actor.isPkRobot && lastInputData.PKRobotComboCheck)
				{
					bool flag = false;
					if (skill != null && skill.isCooldown)
					{
						flag = true;
					}
					if (aiTarget != null && (!aiTarget.HasTag(1) || aiTarget.HasTag(4)))
					{
						flag = true;
					}
					if (flag)
					{
						this.aiManager.StopCurrentCommand();
						this.aiManager.pkRobotWander = true;
						this.aiManager.ResetDestinationSelect();
						return;
					}
				}
				if (actor.aiManager != null && !actor.aiManager.CanAIUseSkill(num))
				{
					return;
				}
				bool flag2 = false;
				bool flag3 = actor.IsComboSkill(num);
				if (skill != null && flag3 && skill.comboSkillSourceID != num)
				{
					BeSkill currentSkill = actor.GetCurrentSkill();
					if (currentSkill != null)
					{
						flag2 = (currentSkill.comboSkillSourceID == skill.comboSkillSourceID);
					}
					if (lastInputData.randomChangeDirection)
					{
						actor.SetFace(actor.FrameRandom.Range100() >= 50, true, false);
					}
				}
				if (this.inputExecuteCount > 1 && !flag2 && num > 5 && !actor.aiManager.CanUseSkill(num))
				{
					bool flag4 = false;
					if (actor.sgGetCurrentState() == 14)
					{
						BeSkill skill2 = actor.GetSkill(num);
						if (skill2 != null && actor.GetCurSkillID() == num && skill2.buttonState != ButtonState.RELEASE)
						{
							flag4 = true;
						}
					}
					if (!flag4)
					{
						this.duraction = 0;
						return;
					}
				}
				if (!actor.aiManager.CanCost(num))
				{
					return;
				}
				if (actor.sgGetCurrentState() == 14)
				{
					BeSkill currentSkill2 = actor.GetCurrentSkill();
					BeSkill skill3 = actor.GetSkill(num);
					if (currentSkill2 != null && skill3 != null && !skill3.CanInterrupt(currentSkill2.skillID, false) && currentSkill2.comboSkillSourceID != skill3.comboSkillSourceID)
					{
						return;
					}
				}
				actor.ResetMoveCmd();
				if (lastInputData.skillID == 1)
				{
					if (actor.CanJump())
					{
						BeStateData rkStateData = new BeStateData(5, 0);
						actor.Locomote(rkStateData, false);
					}
				}
				else if (lastInputData.skillID == 2)
				{
					if (actor.CanJumpBack())
					{
						BeStateData rkStateData2 = new BeStateData(6, 0);
						actor.Locomote(rkStateData2, false);
					}
				}
				else if (lastInputData.skillID == 3)
				{
					actor.SetAttackButtonState(ButtonState.PRESS, true);
					if (lastInputData.PKRobotComboCheck)
					{
						actor.SetAttackCheckFlag(true);
					}
				}
				else if (lastInputData.skillID == 4)
				{
					actor.SetAttackButtonState(ButtonState.RELEASE, false);
					actor.SetAttackCheckFlag(false);
				}
				else if (lastInputData.skillID == 5)
				{
					if (actor.isLocalActor)
					{
						ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
						if (clientSystemBattle != null)
						{
							clientSystemBattle.UseDrug();
						}
					}
				}
				else if (lastInputData.skillID == 10000)
				{
					if (actor.CanUseSkill(lastInputData.skillID))
					{
						actor.UseHelpSkill();
					}
				}
				else if (lastInputData.specialChoice > 0)
				{
					BeSkill skill4 = actor.GetSkill(num);
					if (skill4 != null)
					{
						skill4.specialChoice = lastInputData.specialChoice - 1;
					}
					actor.UseSkill(num, false);
				}
				else
				{
					actor.SetAttackButtonState(ButtonState.RELEASE, false);
					bool flag5 = false;
					if (actor.sgGetCurrentState() == 14)
					{
						BeSkill skill5 = actor.GetSkill(num);
						if (skill5 != null && skill5.buttonState == ButtonState.RELEASE && actor.TriggerComboSkills(num))
						{
							return;
						}
						if (skill5 != null && actor.GetCurSkillID() == num)
						{
							if (skill5.buttonState == ButtonState.RELEASE)
							{
								skill5.SetButtonPressAgain();
								actor.GetStateGraph().FireEvents2CurrentStates(8);
								flag5 = true;
							}
							else
							{
								skill5.SetButtonRelease();
								actor.GetStateGraph().FireEvents2CurrentStates(5);
								flag5 = true;
							}
						}
					}
					if (!flag5)
					{
						actor.UseSkill(num, flag2);
						BeSkill skill6 = actor.GetSkill(num);
						if (skill6 != null && lastInputData.pressTime <= 0)
						{
							skill6.SetButtonRelease();
							if (skill6.joystickMode == SkillJoystickMode.FREE)
							{
								actor.delayCaller.DelayCall(100, delegate
								{
									actor.GetStateGraph().FireEvents2CurrentStates(5);
								}, 0, 0, false);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x040102DD RID: 66269
	public int skillTimeAcc;

	// Token: 0x040102DE RID: 66270
	public int skillID;

	// Token: 0x040102DF RID: 66271
	public AIInputData inputSeq;

	// Token: 0x040102E0 RID: 66272
	public int inputExecuteCount;

	// Token: 0x040102E1 RID: 66273
	public BeEventHandle handle;

	// Token: 0x040102E2 RID: 66274
	public int keepDistanceAcc = GlobalLogic.VALUE_200;
}
