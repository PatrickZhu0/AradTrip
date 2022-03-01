using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using ProtoTable;
using UnityEngine;

// Token: 0x02004145 RID: 16709
public sealed class BeActorAIManager : BeAIManager
{
	// Token: 0x06016CA7 RID: 93351 RVA: 0x006FE278 File Offset: 0x006FC678
	private void RemoveHandles()
	{
		if (this.handleList != null)
		{
			for (int i = 0; i < this.handleList.Count; i++)
			{
				this.handleList[i].Remove();
			}
			this.handleList.Clear();
		}
	}

	// Token: 0x06016CA8 RID: 93352 RVA: 0x006FE2C8 File Offset: 0x006FC6C8
	public override void Start()
	{
		base.Start();
		this.updateActionTimeAcc = this.thinkTerm;
		this.updateDestionTimeAcc = this.changeDestinationTerm;
		this.updateEventTimeAcc = this.eventTerm;
		this.updateFindTargetAcc = this.findTargetTerm;
		if (this.isAPC)
		{
			this.run = true;
		}
		this.RemoveHandles();
		this.handleList.Add(this.owner.RegisterEvent(BeEventType.onGrabbed, delegate(object[] args)
		{
			if (this.owner.pauseAI)
			{
				return;
			}
			base.StopCurrentCommand();
			this.owner.SetAttackButtonState(ButtonState.RELEASE, true);
			if (this.owner.isPkRobot)
			{
				this.pkRobotWander = true;
				this.ResetDestinationSelect();
			}
		}));
		this.handleList.Add(this.owner.RegisterEvent(BeEventType.onHit, delegate(object[] args)
		{
			if (this.owner.pauseAI)
			{
				return;
			}
			if (args[4] != null)
			{
				int id = (int)args[4];
				EffectTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EffectTable>(id, string.Empty, string.Empty);
				if (tableItem != null && tableItem.IsFriendDamage > 0)
				{
					return;
				}
			}
			if (this.owner.isPkRobot && this.owner.stateController != null && !this.owner.stateController.CanBeBreakAction())
			{
				return;
			}
			base.StopCurrentCommand();
			if (this.owner.isPkRobot)
			{
				this.pkRobotWander = true;
				this.ResetDestinationSelect();
			}
			this.ThinkTarget(true);
			this.owner.SetAttackButtonState(ButtonState.RELEASE, true);
			if (this.aiTarget == null && args[2] != null)
			{
				BeActor beActor = args[2] as BeActor;
				if (beActor != null && beActor.GetCamp() != this.owner.GetCamp() && !beActor.IsSkillMonster())
				{
					this.aiTarget = beActor;
				}
			}
		}));
		this.handleList.Add(this.owner.RegisterEvent(BeEventType.onCastSkillFinish, delegate(object[] args)
		{
			this.ResetDestinationSelect();
			int monsterInDaze = (int)args[0];
			this.SetMonsterInDaze(monsterInDaze);
		}));
	}

	// Token: 0x06016CA9 RID: 93353 RVA: 0x006FE390 File Offset: 0x006FC790
	public override void Update(int deltaTime)
	{
		if (this.state == BeAIManager.State.RUNNING && this.currentCommand != null && this.currentCommand.IsAlive())
		{
			this.currentCommand.Tick(deltaTime);
		}
		if (this.state == BeAIManager.State.RUNNING)
		{
			if (!this.dazeFlag)
			{
				this.lastAction = -1;
				this.UpdateThinkTarget(deltaTime);
				if (!this.owner.IsInPassiveState() && this.owner.sgGetCurrentState() != 12)
				{
					if (this.currentCommand == null || this.currentCommand.cmdType != AI_COMMAND.SKILL)
					{
						this.UpdateThinkAction(deltaTime);
						this.UpdateDestinationSelect(deltaTime);
						if (this.forceFollow)
						{
							this.UpdateFollow(deltaTime);
						}
					}
				}
				this.UpdateEvent(deltaTime);
			}
			else
			{
				this.UpdateDaze(deltaTime);
			}
			base.UpdateTimer(deltaTime);
		}
		if (this.state == BeAIManager.State.RUNNING && this.owner.sgGetCurrentState() == 16)
		{
			base.Stop();
		}
	}

	// Token: 0x06016CAA RID: 93354 RVA: 0x006FE496 File Offset: 0x006FC896
	public override void PostUpdate(int deltaTime)
	{
		if (this.state == BeAIManager.State.RUNNING && this.owner.IsMonster() && !this.isAPC)
		{
			this.UpdateFaceTarget();
		}
	}

	// Token: 0x06016CAB RID: 93355 RVA: 0x006FE4C5 File Offset: 0x006FC8C5
	private void UpdateThinkTarget(int delta)
	{
		this.updateFindTargetAcc += delta;
		if (this.updateFindTargetAcc >= this.findTargetTerm)
		{
			this.updateFindTargetAcc -= this.findTargetTerm;
			this.ThinkTarget(true);
		}
	}

	// Token: 0x06016CAC RID: 93356 RVA: 0x006FE500 File Offset: 0x006FC900
	private void UpdateThinkAction(int delta)
	{
		this.updateActionTimeAcc += delta;
		if (this.updateActionTimeAcc >= this.thinkTerm)
		{
			this.updateActionTimeAcc -= this.thinkTerm;
			this.lastAction = this.ThinkAction();
			if (this.lastAction > -1)
			{
				this.DoAction(this.aiInputData);
			}
		}
	}

	// Token: 0x06016CAD RID: 93357 RVA: 0x006FE563 File Offset: 0x006FC963
	private void UpdateDaze(int delta)
	{
		if (!this.dazeFlag)
		{
			return;
		}
		this.dazeTime -= delta;
		if (this.dazeTime <= 0)
		{
			this.dazeFlag = false;
		}
	}

	// Token: 0x06016CAE RID: 93358 RVA: 0x006FE594 File Offset: 0x006FC994
	private void UpdateDestinationSelect(int delta)
	{
		this.updateDestionTimeAcc += delta;
		if (this.updateDestionTimeAcc >= this.changeDestinationTerm)
		{
			this.updateDestionTimeAcc -= this.changeDestinationTerm;
			if (this.lastAction <= -1)
			{
				int num = this.ThinkDestination();
				if (num != -1)
				{
					this.DoDestination(num, this.aiTarget, this.run);
				}
				else if (this.aiTarget != null)
				{
					this.DoIdle();
				}
				if (this.aiTarget == null && this.aiType != BeAIManager.AIType.NOATTACK)
				{
					num = this.ThinkFollow();
					if (num != -1)
					{
						this.DoDestination(num, this.followTarget, this.run);
					}
					else if (this.isAutoFight)
					{
						if (this.owner.CurrentBeScene.IsBossSceneClear())
						{
							ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
							if (clientSystemBattle != null)
							{
								clientSystemBattle.SetAutoFight(false);
							}
							this.owner.ResetMoveCmd();
							return;
						}
						if (this.owner.CurrentBeScene.state < BeSceneState.onClear)
						{
							return;
						}
						if (this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SKILL_LOADING_TYPE))
						{
							this.doorRadius = BeActorAIManager.distanceHalf;
						}
						else
						{
							this.transportDoor = this.owner.CurrentBeBattle.dungeonManager.GetDungeonDataManager().door;
							this.doorRadius = ((this.transportDoor != null) ? new VInt(this.transportDoor.GetRegionInfo().GetRadius()) : new VInt(1.2f));
						}
						VInt3 doorPosition = this.owner.CurrentBeScene.GetDoorPosition();
						VInt3 pos = doorPosition;
						bool flag = false;
						if (base.CheckDistance(doorPosition, this.doorRadius, 0))
						{
							if (BeClientSwitch.FunctionIsOpen(ClientSwitchType.AutoFightTriggerDoor))
							{
								if (this.owner.CurrentBeScene.CheckInDoorRange(this.owner))
								{
									this.owner.ResetMoveCmd();
									return;
								}
								flag = true;
							}
							else
							{
								flag = true;
							}
						}
						BeAIWalkCommand beAIWalkCommand = null;
						if (this.currentCommand != null)
						{
							beAIWalkCommand = (this.currentCommand as BeAIWalkCommand);
						}
						if (beAIWalkCommand != null && beAIWalkCommand.IsAlive())
						{
							return;
						}
						if (flag)
						{
							VInt3 posAroundDoor;
							if (this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SKILL_LOADING_TYPE))
							{
								posAroundDoor = base.GetPosAroundDoor(this.owner.CurrentBeScene, pos, VInt.one);
							}
							else
							{
								posAroundDoor = base.GetPosAroundDoor(this.owner.CurrentBeScene, pos, this.doorRadius + VInt.one);
							}
							doorPosition.x = posAroundDoor.x;
							doorPosition.y = posAroundDoor.y;
						}
						BeAIWalkCommand beAIWalkCommand2 = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
						if (this.owner.CurrentBeBattle.HasFlag(BattleFlagType.SKILL_LOADING_TYPE))
						{
							beAIWalkCommand2.Init(GlobalLogic.VALUE_1000, doorPosition, 0, true, false, true, false);
						}
						else
						{
							beAIWalkCommand2.Init(GlobalLogic.VALUE_1000, doorPosition, VInt.half, true, false, true, false);
						}
						base.ExecuteCommand(beAIWalkCommand2);
						return;
					}
					else if (this.idleMode == BeAIManager.IdleMode.IDLE)
					{
						this.DoIdle();
					}
					else if (this.idleMode == BeAIManager.IdleMode.WANDER)
					{
						this.DoDestination(5, null, this.run);
					}
				}
			}
		}
	}

	// Token: 0x06016CAF RID: 93359 RVA: 0x006FE8E8 File Offset: 0x006FCCE8
	private void UpdateEvent(int delta)
	{
		this.updateEventTimeAcc += delta;
		if (this.updateEventTimeAcc >= this.eventTerm)
		{
			this.updateEventTimeAcc -= this.eventTerm;
			int num = this.ThinkEvent();
			if (num != -1)
			{
				this.lastAction = num;
				this.DoAction(this.aiInputData);
			}
		}
	}

	// Token: 0x06016CB0 RID: 93360 RVA: 0x006FE948 File Offset: 0x006FCD48
	private void UpdateFollow(int delta)
	{
		this.updateFollowTimeAcc += delta;
		if (this.updateFollowTimeAcc >= this.followTerm)
		{
			this.updateFollowTimeAcc -= this.followTerm;
			int num = this.ThinkFollow();
			if (num != -1)
			{
				this.DoDestination(num, this.followTarget, true);
			}
		}
	}

	// Token: 0x06016CB1 RID: 93361 RVA: 0x006FE9A4 File Offset: 0x006FCDA4
	private void UpdateFaceTarget()
	{
		if (this.aiTarget != null && this.owner.stateController.CanTurnFace())
		{
			ActionState actionState = (ActionState)this.owner.sgGetCurrentState();
			if (actionState == ActionState.AS_WALK || actionState == ActionState.AS_RUN || actionState == ActionState.AS_IDLE)
			{
				if (this.owner.GetPosition().x < this.aiTarget.GetPosition().x + BeActorAIManager.distance01 && this.owner.GetFace())
				{
					this.owner.SetFace(false, true, false);
				}
				else if (this.owner.GetPosition().x > this.aiTarget.GetPosition().x + BeActorAIManager.distance01 && !this.owner.GetFace())
				{
					this.owner.SetFace(true, true, false);
				}
			}
		}
	}

	// Token: 0x06016CB2 RID: 93362 RVA: 0x006FEABC File Offset: 0x006FCEBC
	private void ThinkTarget(bool force = false)
	{
		if (this.aiTarget != null && (this.aiTarget.IsDead() || !this.owner.CurrentBeScene.HasEntity(this.aiTarget) || !this.aiTarget.stateController.CanBeTargeted()))
		{
			this.aiTarget = null;
		}
		if (this.aiTarget != null && !base.CheckDistance(this.aiTarget, VInt.NewVInt((long)this.chaseSight, (long)GlobalLogic.VALUE_1000), 0))
		{
			this.aiTarget = null;
		}
		if (this.aiTarget == null || (force && !this.targetUnchange))
		{
			BeActor beActor = this.FindTarget();
			if (beActor != null)
			{
				this.aiTarget = beActor;
			}
		}
	}

	// Token: 0x06016CB3 RID: 93363 RVA: 0x006FEB84 File Offset: 0x006FCF84
	public BeActor FindTarget()
	{
		if (this.assignAITarget != null)
		{
			return this.assignAITarget;
		}
		BeActor beActor = null;
		List<BeActor> list = ListPool<BeActor>.Get();
		this.owner.CurrentBeScene.FindTargets(list, this.owner, VInt.NewVInt(this.sight, GlobalLogic.VALUE_1000), false, this.filter);
		if (list.Count >= 1)
		{
			this.SortTarget(list);
			if (this.targetType == BeAIManager.TargetType.NEAREST)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].IsMonster() && list[i].attribute.autoFightNeedAttackFirst)
					{
						beActor = list[i];
						break;
					}
				}
				if (beActor == null)
				{
					beActor = list[0];
				}
			}
			else if (this.targetType == BeAIManager.TargetType.BOSS)
			{
				for (int j = 0; j < list.Count; j++)
				{
					if (list[j].IsMonster() && list[j].IsBoss())
					{
						beActor = list[j];
						break;
					}
				}
				if (beActor == null)
				{
					beActor = list[0];
				}
			}
			else if (this.targetType == BeAIManager.TargetType.Max_Resentment)
			{
				this.owner.CurrentBeScene.SortResentmentList(list);
				beActor = list[0];
			}
		}
		ListPool<BeActor>.Release(list);
		return beActor;
	}

	// Token: 0x06016CB4 RID: 93364 RVA: 0x006FECE8 File Offset: 0x006FD0E8
	private void SortTarget(List<BeActor> targets)
	{
		VInt3 position = this.owner.GetPosition();
		for (int i = 0; i < targets.Count; i++)
		{
			for (int j = i + 1; j < targets.Count; j++)
			{
				BeActor beActor = targets[i];
				BeActor beActor2 = targets[j];
				if (beActor2 != null && beActor != null)
				{
					int distance = beActor.GetDistance(this.owner);
					int distance2 = beActor2.GetDistance(this.owner);
					if (distance > distance2)
					{
						targets[i] = beActor2;
						targets[j] = beActor;
					}
					else if (distance == distance2 && beActor.GetPID() > beActor2.GetPID())
					{
						targets[i] = beActor2;
						targets[j] = beActor;
					}
				}
			}
		}
	}

	// Token: 0x06016CB5 RID: 93365 RVA: 0x006FEDBC File Offset: 0x006FD1BC
	private int ThinkFollow()
	{
		if (this.followTarget == null)
		{
			return -1;
		}
		if (base.CheckDistance(this.followTarget, VInt.one.i * 2, 0))
		{
			return -1;
		}
		if (base.FrameRandom.Range100() <= 20)
		{
			return 2;
		}
		return 4;
	}

	// Token: 0x06016CB6 RID: 93366 RVA: 0x006FEE14 File Offset: 0x006FD214
	private int ThinkAction()
	{
		if (this.aiTarget != null)
		{
			this.aiInputData = null;
			this.actionResult = -1;
			if (this.actionAgent != null)
			{
				base.UpdateAgent(this.actionAgent);
			}
			else
			{
				int num;
				if (this.isAutoFight)
				{
					num = this.ThinkAction_AutoFight();
				}
				else
				{
					num = this.ThinkAction_Monster();
				}
				if (num > -1)
				{
					BeAIManager.AttackInfo attackInfo = this.attackInfos[num];
					this.actionResult = 0;
					this.aiInputData = new AIInputData(attackInfo.skillID, 0, 0, 0);
				}
				else
				{
					this.actionResult = num;
				}
			}
			return this.actionResult;
		}
		return -1;
	}

	// Token: 0x06016CB7 RID: 93367 RVA: 0x006FEEBC File Offset: 0x006FD2BC
	private int ThinkDestination()
	{
		if (this.aiTarget != null || this.aiType == BeAIManager.AIType.NOATTACK)
		{
			this.destinationSelectResult = -1;
			if (this.destinationSelectAgent != null)
			{
				base.UpdateAgent(this.destinationSelectAgent);
			}
			else if (this.isAutoFight)
			{
				this.destinationSelectResult = this.ThinkDestination_AutoFight();
			}
			else
			{
				this.destinationSelectResult = this.ThinkDestination_Monster();
			}
			if (this.aiTarget != null && this.targetUnchange && this.owner.GetEntityData().isMonster)
			{
				this.destinationSelectResult = 0;
			}
			if (this.owner.isPkRobot && this.pkRobotWander)
			{
				this.destinationSelectResult = 9;
				this.pkRobotWander = false;
			}
			return this.destinationSelectResult;
		}
		return -1;
	}

	// Token: 0x06016CB8 RID: 93368 RVA: 0x006FEF8F File Offset: 0x006FD38F
	private bool CanAttackTarget(int passvieProb)
	{
		return this.aiTarget == null || !this.aiTarget.IsPassiveState() || base.FrameRandom.InRange(0, GlobalLogic.VALUE_100) < passvieProb;
	}

	// Token: 0x06016CB9 RID: 93369 RVA: 0x006FEFC8 File Offset: 0x006FD3C8
	private int ThinkAction_AutoFight()
	{
		int result = -1;
		for (int i = 0; i < this.attackInfos.Count; i++)
		{
			BeAIManager.AttackInfo attackInfo = this.attackInfos[i];
			if (attackInfo.enable && attackInfo.IsPointInRange(this.owner.GetPosition2(), this.aiTarget.GetPosition2(), this.owner.GetFace()) && base.FrameRandom.InRange(0, GlobalLogic.VALUE_100) < attackInfo.prob && base.CanUseSkill(attackInfo.skillID))
			{
				result = i;
				break;
			}
		}
		return result;
	}

	// Token: 0x06016CBA RID: 93370 RVA: 0x006FF06C File Offset: 0x006FD46C
	private int ThinkDestination_AutoFight()
	{
		return 0;
	}

	// Token: 0x06016CBB RID: 93371 RVA: 0x006FF070 File Offset: 0x006FD470
	private int ThinkAction_Monster()
	{
		int num = -1;
		bool flag = false;
		if (base.FrameRandom.InRange(0, GlobalLogic.VALUE_100) > this.warlike)
		{
			num = -2;
		}
		else
		{
			for (int i = 0; i < this.attackInfos.Count; i++)
			{
				BeAIManager.AttackInfo attackInfo = this.attackInfos[i];
				if (attackInfo.enable && attackInfo.IsPointInRange(this.owner.GetPosition2(), this.aiTarget.GetPosition2(), this.owner.GetFace()))
				{
					flag = true;
					if (base.FrameRandom.InRange(0, GlobalLogic.VALUE_100) < attackInfo.prob && base.CanUseSkill(attackInfo.skillID) && this.CanAttackTarget(attackInfo.attackPassiveProb))
					{
						num = i;
						break;
					}
				}
			}
		}
		if (flag && num == -1)
		{
			num = -2;
		}
		return num;
	}

	// Token: 0x06016CBC RID: 93372 RVA: 0x006FF160 File Offset: 0x006FD560
	private int GetRandAmong(int[] candicats)
	{
		int num = 0;
		for (int i = 0; i < candicats.Length; i++)
		{
			num += candicats[i];
		}
		int num2 = base.FrameRandom.InRange(0, num);
		int num3 = 0;
		for (int j = 0; j < candicats.Length; j++)
		{
			num3 += candicats[j];
			if (num2 <= num3)
			{
				return j;
			}
		}
		return -1;
	}

	// Token: 0x06016CBD RID: 93373 RVA: 0x006FF1C4 File Offset: 0x006FD5C4
	private int ThinkDestination_Monster()
	{
		int num = -1;
		if (this.lastAction == -2)
		{
			if (this.aiType == BeAIManager.AIType.MELEE)
			{
				if (base.CheckDistance(this.aiTarget, BeActorAIManager.distanceOneHalf, 1))
				{
					int randAmong = this.GetRandAmong(new int[]
					{
						this.idleRand,
						this.escapeRand,
						this.wanderRand,
						GlobalLogic.VALUE_50
					});
					if (randAmong != 0)
					{
						if (randAmong == 1)
						{
							num = 1;
						}
						else if (randAmong == 2)
						{
							num = 5;
						}
						else
						{
							num = 0;
						}
					}
				}
				else
				{
					int randAmong2 = this.GetRandAmong(new int[]
					{
						this.idleRand,
						GlobalLogic.VALUE_50
					});
					if (randAmong2 != 0)
					{
						if (randAmong2 == 1)
						{
							num = 0;
						}
					}
				}
			}
			else if (this.aiType == BeAIManager.AIType.RANGED)
			{
				if (base.CheckDistance(this.aiTarget, this.keepDistance, 1) || base.CheckDistance(this.aiTarget, BeActorAIManager.distanceOneHalf, 1))
				{
					int randAmong3 = this.GetRandAmong(new int[]
					{
						this.idleRand,
						this.escapeRand,
						this.wanderRand,
						this.yFirstRand,
						GlobalLogic.VALUE_30
					});
					if (randAmong3 != 0)
					{
						if (randAmong3 == 1)
						{
							num = 1;
						}
						else if (randAmong3 == 2)
						{
							num = 5;
						}
						else if (randAmong3 == 3)
						{
							num = 3;
						}
						else
						{
							num = 0;
						}
					}
				}
				else if (base.CheckDistance(this.aiTarget, BeActorAIManager.distanceOne.i * 2, 1))
				{
					int randAmong4 = this.GetRandAmong(new int[]
					{
						this.idleRand,
						this.wanderRand,
						GlobalLogic.VALUE_30
					});
					if (randAmong4 != 0)
					{
						if (randAmong4 == 1)
						{
							num = 5;
						}
						else if (randAmong4 == 2)
						{
							num = 0;
						}
					}
				}
				else
				{
					int randAmong5 = this.GetRandAmong(new int[]
					{
						this.idleRand,
						GlobalLogic.VALUE_50
					});
					if (randAmong5 != 0)
					{
						if (randAmong5 == 1)
						{
							num = 0;
						}
					}
				}
			}
		}
		else if (this.lastAction == -1)
		{
			if (this.aiType == BeAIManager.AIType.RANGED)
			{
				if (base.CheckDistance(this.aiTarget, this.keepDistance, 1))
				{
					if (base.CheckDistance(this.aiTarget, BeActorAIManager.distanceOneHalf, 1))
					{
						num = ((base.FrameRandom.Range100() >= 70) ? 1 : 6);
					}
					else
					{
						num = ((base.FrameRandom.Range100() >= 30) ? 1 : 6);
					}
				}
				else
				{
					num = ((base.FrameRandom.Range100() >= 50) ? 3 : 4);
				}
			}
			else if (this.aiType == BeAIManager.AIType.MELEE)
			{
				num = 0;
			}
		}
		if (num != -1)
		{
			this.lastDestination++;
			this.lastIdle = 0;
			if (this.lastDestination > this.maxWalkCount)
			{
				num = -1;
				this.lastDestination = 0;
			}
		}
		else
		{
			this.lastIdle++;
			if (this.lastIdle > this.maxIdleCount)
			{
				num = 1;
				this.lastIdle = 0;
			}
			this.lastDestination = 0;
		}
		return num;
	}

	// Token: 0x06016CBE RID: 93374 RVA: 0x006FF516 File Offset: 0x006FD916
	private int ThinkEvent()
	{
		this.actionResult = -1;
		if (this.eventAgent != null)
		{
			base.UpdateAgent(this.eventAgent);
			return this.actionResult;
		}
		return -1;
	}

	// Token: 0x06016CBF RID: 93375 RVA: 0x006FF540 File Offset: 0x006FD940
	private void DoAction(AIInputData inputData)
	{
		this.lastDestination = 0;
		this.lastIdle = 0;
		BeAISkillCommand beAISkillCommand = (BeAISkillCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.SKILL, this.owner);
		beAISkillCommand.Init(inputData);
		base.ExecuteCommand(beAISkillCommand);
	}

	// Token: 0x06016CC0 RID: 93376 RVA: 0x006FF584 File Offset: 0x006FD984
	public void DoDestination(int method, BeActor target, bool run = false)
	{
		if (this.isAPC && run && this.aiTarget != null && base.CheckDistanceWithX(this.aiTarget, BeActorAIManager.distanceOne.i * 2))
		{
			run = false;
		}
		VInt tolerance = VInt.one;
		if (this.owner != null && this.owner.IsProcessRecord())
		{
			RecordServer recordServer = this.owner.GetRecordServer();
			uint id = 142055301U;
			int[] entityRecordAttribute = this.owner.GetEntityRecordAttribute();
			string[] array = new string[2];
			int num = 0;
			BeAIManager.DestinationType destinationType = (BeAIManager.DestinationType)method;
			array[num] = destinationType.ToString();
			array[1] = this.owner.GetName();
			recordServer.Mark(id, entityRecordAttribute, array);
		}
		int value_ = GlobalLogic.VALUE_10000;
		BeAIWalkCommand beAIWalkCommand = null;
		if (method != -1)
		{
			BeAIManager.DestinationType destinationType2 = (BeAIManager.DestinationType)method;
			switch (destinationType2)
			{
			case BeAIManager.DestinationType.GO_TO_TARGET:
				if (!base.CheckDistance(this.aiTarget, VInt.Float2VIntValue(1.1f), 0))
				{
					VInt3 position = target.GetPosition();
					if (!this.owner.isMainActor)
					{
						position.x += ((position.x - this.owner.GetPosition().x <= 0) ? this.overlapOffset : (-this.overlapOffset));
						int num2 = base.FrameRandom.InRange(5000, 10000);
						int num3 = base.FrameRandom.InRange(5000, 10000);
						if (base.FrameRandom.Range100() > 50)
						{
							position.x += num2;
						}
						else
						{
							position.x -= num2;
						}
						if (base.FrameRandom.Range100() > 50)
						{
							position.y += num3;
						}
						else
						{
							position.y -= num3;
						}
					}
					if (this.owner != null && this.owner.IsProcessRecord())
					{
						this.owner.GetRecordServer().Mark(142055568U, new int[]
						{
							this.owner.m_iID,
							position.x,
							position.y,
							target.GetPosition().x,
							target.GetPosition().y,
							target.GetPosition().z,
							this.owner.GetPosition().x,
							this.owner.GetPosition().y,
							this.owner.GetPosition().z,
							this.owner.moveXSpeed.i,
							this.owner.moveYSpeed.i,
							this.owner.moveZSpeed.i,
							(!this.owner.GetFace()) ? 1 : 0,
							this.owner.attribute.GetHP(),
							this.owner.attribute.GetMP(),
							this.owner.GetAllStatTag(),
							this.owner.attribute.battleData.attack
						}, new string[]
						{
							this.owner.GetName(),
							destinationType2.ToString()
						});
					}
					tolerance = VInt.one.i / 2;
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(value_, position, tolerance, run, false, true, false);
				}
				else if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(142055311U, new int[]
					{
						this.owner.m_iID,
						target.GetPosition().x,
						target.GetPosition().y,
						target.GetPosition().z,
						this.owner.GetPosition().x,
						this.owner.GetPosition().y,
						this.owner.GetPosition().z,
						this.owner.moveXSpeed.i,
						this.owner.moveYSpeed.i,
						this.owner.moveZSpeed.i,
						(!this.owner.GetFace()) ? 1 : 0,
						this.owner.attribute.GetHP(),
						this.owner.attribute.GetMP(),
						this.owner.GetAllStatTag(),
						this.owner.attribute.battleData.attack
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				break;
			case BeAIManager.DestinationType.ESCAPE:
			{
				VInt3 walkBackPostion = base.GetWalkBackPostion();
				if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(142055307U, new int[]
					{
						this.owner.m_iID,
						walkBackPostion.x,
						walkBackPostion.y,
						this.owner.GetPosition().x,
						this.owner.GetPosition().y
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
				beAIWalkCommand.Init(value_, walkBackPostion, tolerance, run, false, false, false);
				break;
			}
			case BeAIManager.DestinationType.BYPASS_TRACK:
			{
				VInt3 position2 = target.GetPosition();
				if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(142055310U, new int[]
					{
						this.owner.m_iID,
						position2.x,
						position2.y,
						this.owner.GetPosition().x,
						this.owner.GetPosition().y
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				tolerance = VInt.one;
				beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
				beAIWalkCommand.Init(value_, position2, tolerance, run, false, false, true);
				break;
			}
			case BeAIManager.DestinationType.Y_FIRST:
				if (this.attackInfos.Count > 0)
				{
					BeAIManager.AttackInfo attackInfo = this.attackInfos[0];
					VInt3 position3 = this.owner.GetPosition();
					VInt3 position4 = this.aiTarget.GetPosition();
					if (Mathf.Abs(position3.x - position4.x) < attackInfo.front)
					{
						int num4 = base.FrameRandom.InRange(0, 10000) * ((base.FrameRandom.Range100() <= 50) ? -10000 : 10000);
						position3.y = position4.y + num4;
					}
					else
					{
						if (position4.x > position3.x)
						{
							position3.x = position3.x + attackInfo.front.i + base.FrameRandom.InRange(0, 20000);
						}
						else
						{
							position3.x = position3.x - attackInfo.front.i - base.FrameRandom.InRange(0, 20000);
						}
						position3.y = position4.y;
					}
					if (this.owner != null && this.owner.IsProcessRecord())
					{
						VInt3 vint = position3;
						this.owner.GetRecordServer().Mark(142055817U, new int[]
						{
							this.owner.m_iID,
							vint.x,
							vint.y,
							this.owner.GetPosition().x,
							this.owner.GetPosition().y
						}, new string[]
						{
							this.owner.GetName(),
							destinationType2.ToString()
						});
					}
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(GlobalLogic.VALUE_5000, position3, tolerance, run, false, true, false);
				}
				break;
			case BeAIManager.DestinationType.FOLLOW:
			{
				VInt3 position5 = this.owner.GetPosition();
				VInt3 position6 = target.GetPosition();
				position5.x += ((position6.x - position5.x <= 0) ? this.overlapOffset : (-this.overlapOffset));
				long num5 = 20000L;
				bool flag = false;
				if ((long)Mathf.Abs(position5.x - position6.x) > num5)
				{
					VFactor f = new VFactor((long)base.FrameRandom.InRange(0, 11), 10L);
					flag = true;
					if (position6.x > position5.x)
					{
						position5.x = position6.x - (int)num5 * f;
					}
					else
					{
						position5.x = position6.x + (int)num5 * f;
					}
					position5.y = position6.y;
				}
				if ((long)Mathf.Abs(position5.y - position6.y) > num5)
				{
					VFactor f2 = new VFactor((long)base.FrameRandom.InRange(0, 11), 10L);
					flag = true;
					if (position6.y > position5.y)
					{
						position5.y = position6.y - (int)num5 * f2;
					}
					else
					{
						position5.y = position6.y + (int)num5 * f2;
					}
					position5.x = position6.x;
				}
				if (flag)
				{
					if (this.owner != null && this.owner.IsProcessRecord())
					{
						VInt3 vint2 = position5;
						this.owner.GetRecordServer().Mark(142055308U, new int[]
						{
							this.owner.m_iID,
							vint2.x,
							vint2.y
						}, new string[]
						{
							this.owner.GetName(),
							destinationType2.ToString()
						});
					}
					tolerance = VInt.one.i * 2;
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(GlobalLogic.VALUE_5000, position5, tolerance, run, false, true, false);
				}
				else if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(142055306U, new int[]
					{
						this.owner.m_iID
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				break;
			}
			case BeAIManager.DestinationType.WANDER:
			{
				VInt3 wanderPosition = base.GetWanderPosition();
				if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(142055309U, new int[]
					{
						this.owner.m_iID,
						wanderPosition.x,
						wanderPosition.y,
						this.owner.GetPosition().x,
						this.owner.GetPosition().y
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				tolerance = VInt.one.i / 2;
				beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
				beAIWalkCommand.Init(value_, wanderPosition, tolerance, run, false, true, false);
				break;
			}
			case BeAIManager.DestinationType.KEEP_DISTANCE:
			{
				VInt3 position7 = this.owner.GetPosition();
				VInt3 position8 = this.aiTarget.GetPosition();
				if (Mathf.Abs(position7.x - position8.x) < this.keepDistance)
				{
					bool flag2 = position8.x > position7.x;
					if (flag2 && !base.CanWalk(BeAIManager.MoveDir.LEFT) && Mathf.Abs(position7.x - position8.x) < VInt.one.i * 2)
					{
						flag2 = false;
					}
					if (!flag2 && !base.CanWalk(BeAIManager.MoveDir.RIGHT) && Mathf.Abs(position7.x - position8.x) < VInt.one.i * 2)
					{
						flag2 = true;
					}
					position7.x = ((!flag2) ? (position8.x + this.keepDistance.i) : (position8.x - this.keepDistance.i));
					if (this.owner != null && this.owner.IsProcessRecord())
					{
						VInt3 vint3 = position7;
						this.owner.GetRecordServer().Mark(142055305U, new int[]
						{
							this.owner.m_iID,
							vint3.x,
							vint3.y
						}, new string[]
						{
							this.owner.GetName(),
							destinationType2.ToString()
						});
					}
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(GlobalLogic.VALUE_5000, position7, tolerance, run, false, false, false);
				}
				break;
			}
			case BeAIManager.DestinationType.FINAL_DOOR:
			{
				VInt3 doorPosition = this.owner.CurrentBeScene.GetDoorPosition();
				if (doorPosition == VInt3.zero)
				{
					base.StopCurrentCommand();
				}
				else
				{
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(GlobalLogic.VALUE_10000, doorPosition, tolerance, run, false, false, false);
				}
				break;
			}
			case BeAIManager.DestinationType.WANDER_IN_CIRCLE:
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				this.owner.CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
				if (list.Count > 0)
				{
					BeActor beActor = list[0];
					VInt3 randomPos = base.GetRandomPos(beActor.GetPosition(), VInt.Float2VIntValue((float)this.radius / 1000f));
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(value_, randomPos, VInt.one.i / 5, run, false, true, false);
				}
				ListPool<BeActor>.Release(list);
				break;
			}
			case BeAIManager.DestinationType.WANDER_PKROBOT:
			{
				VInt3 pkRobotWanderPos = base.GetPkRobotWanderPos();
				if (this.owner != null && this.owner.IsProcessRecord())
				{
					this.owner.GetRecordServer().Mark(7837574U, new int[]
					{
						this.owner.m_iID,
						pkRobotWanderPos.x,
						pkRobotWanderPos.y,
						this.owner.GetPosition().x,
						this.owner.GetPosition().y
					}, new string[]
					{
						this.owner.GetName(),
						destinationType2.ToString()
					});
				}
				tolerance = VInt.one.i / 2;
				beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
				beAIWalkCommand.Init(value_, pkRobotWanderPos, tolerance, true, false, true, true);
				break;
			}
			case BeAIManager.DestinationType.MOVETO_LEFT_SCENEEDGE:
			{
				VInt3 position9 = this.owner.GetPosition();
				position9.x -= GlobalLogic.VALUE_10000;
				tolerance = VInt.one.i / 2;
				beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
				beAIWalkCommand.Init(value_, position9, tolerance, run, false, true, false);
				break;
			}
			case BeAIManager.DestinationType.GO_TO_TARGET2:
			{
				VInt3 position10 = this.owner.GetPosition();
				VInt3 position11 = target.GetPosition();
				if (!base.CheckDistance(this.aiTarget, VInt.Float2VIntValue(0.1f), 0))
				{
					tolerance = VInt.one.i / 2;
					beAIWalkCommand = (BeAIWalkCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.WALK, this.owner);
					beAIWalkCommand.Init(value_, position11, tolerance, run, false, true, false);
				}
				break;
			}
			}
			if (beAIWalkCommand != null)
			{
				BeAIWalkCommand beAIWalkCommand2 = beAIWalkCommand;
				if (beAIWalkCommand2 != null)
				{
					beAIWalkCommand2.destinationType = destinationType2;
				}
				beAIWalkCommand.SetDebugInfo("DoDestination: " + destinationType2.GetDescription(true));
			}
		}
		if (beAIWalkCommand != null)
		{
			BeAIWalkCommand beAIWalkCommand3 = this.currentCommand as BeAIWalkCommand;
			if (beAIWalkCommand3 != null && beAIWalkCommand3.IsAlive() && beAIWalkCommand3.destinationType == (BeAIManager.DestinationType)method && (!this.isAutoFight || beAIWalkCommand3.targetPos == beAIWalkCommand.targetPos))
			{
				base.BeAICommandPool.PutAICommand(beAIWalkCommand);
				return;
			}
			base.ExecuteCommand(beAIWalkCommand);
		}
	}

	// Token: 0x06016CC1 RID: 93377 RVA: 0x007007F2 File Offset: 0x006FEBF2
	public override void ResetThinkTarget()
	{
		this.updateFindTargetAcc = this.findTargetTerm + 1;
	}

	// Token: 0x06016CC2 RID: 93378 RVA: 0x00700802 File Offset: 0x006FEC02
	public override void ResetAction()
	{
		this.updateActionTimeAcc = this.thinkTerm + 1;
	}

	// Token: 0x06016CC3 RID: 93379 RVA: 0x00700812 File Offset: 0x006FEC12
	public override void ResetDestinationSelect()
	{
		this.updateDestionTimeAcc = this.changeDestinationTerm + 1;
	}

	// Token: 0x06016CC4 RID: 93380 RVA: 0x00700824 File Offset: 0x006FEC24
	public void DoIdle()
	{
		int dur = base.FrameRandom.InRange((long)((ulong)(this.idleDuration / 2)), (long)((ulong)(this.idleDuration * 2)));
		if (this.owner != null && this.owner.IsProcessRecord())
		{
			this.owner.GetRecordServer().Mark(142055303U, new int[]
			{
				this.owner.m_iID
			}, new string[]
			{
				this.owner.GetName()
			});
		}
		BeAIIdleCommand beAIIdleCommand = (BeAIIdleCommand)base.BeAICommandPool.GetAICommand(AI_COMMAND.IDLE, this.owner);
		beAIIdleCommand.Init(dur);
		base.ExecuteCommand(beAIIdleCommand);
	}

	// Token: 0x06016CC5 RID: 93381 RVA: 0x007008CD File Offset: 0x006FECCD
	public override void SetForceFollow(bool flag)
	{
		if (this.forceFollow == flag)
		{
			return;
		}
		this.forceFollow = flag;
		if (this.forceFollow)
		{
			this.updateFollowTimeAcc = this.followTerm;
		}
	}

	// Token: 0x06016CC6 RID: 93382 RVA: 0x00700900 File Offset: 0x006FED00
	private void SetMonsterInDaze(int skillId)
	{
		if (!this.owner.IsMonster())
		{
			return;
		}
		UnitTable monsterData = this.owner.GetEntityData().monsterData;
		if (monsterData.DazeTime == null || monsterData.DazeTimeLength <= 0)
		{
			return;
		}
		int num = this.GetDazeTime(monsterData, skillId);
		if (num <= 0)
		{
			return;
		}
		this.SetDazeTime(num);
	}

	// Token: 0x06016CC7 RID: 93383 RVA: 0x00700960 File Offset: 0x006FED60
	private void SetDazeTime(int time)
	{
		this.dazeFlag = true;
		this.dazeTime = time;
		this.updateFindTargetAcc += time;
		this.updateActionTimeAcc += time;
		this.updateDestionTimeAcc += time;
		this.updateEventTimeAcc += time;
	}

	// Token: 0x06016CC8 RID: 93384 RVA: 0x007009B4 File Offset: 0x006FEDB4
	private int GetDazeTime(UnitTable unitData, int skillId)
	{
		for (int i = 0; i < unitData.DazeTimeLength; i++)
		{
			UnionCell unionCell = unitData.DazeTimeArray(i);
			if (unionCell.fixInitValue == skillId)
			{
				return unionCell.fixLevelGrow;
			}
		}
		return -1;
	}

	// Token: 0x04010492 RID: 66706
	public int updateFindTargetAcc;

	// Token: 0x04010493 RID: 66707
	public int updateActionTimeAcc;

	// Token: 0x04010494 RID: 66708
	public int updateDestionTimeAcc;

	// Token: 0x04010495 RID: 66709
	public int updateEventTimeAcc;

	// Token: 0x04010496 RID: 66710
	public int updateFollowTimeAcc;

	// Token: 0x04010497 RID: 66711
	private int lastAction = -1;

	// Token: 0x04010498 RID: 66712
	private int lastDestination;

	// Token: 0x04010499 RID: 66713
	private int lastIdle;

	// Token: 0x0401049A RID: 66714
	private bool run;

	// Token: 0x0401049B RID: 66715
	private int dazeTime;

	// Token: 0x0401049C RID: 66716
	private bool dazeFlag;

	// Token: 0x0401049D RID: 66717
	private List<BeEventHandle> handleList = new List<BeEventHandle>();

	// Token: 0x0401049E RID: 66718
	private static readonly VInt distanceHalf = new VInt(0.5f);

	// Token: 0x0401049F RID: 66719
	private static readonly VInt distance01 = new VInt(0.1f);

	// Token: 0x040104A0 RID: 66720
	private ISceneTransportDoorData transportDoor;

	// Token: 0x040104A1 RID: 66721
	private VInt doorRadius;

	// Token: 0x040104A2 RID: 66722
	private static readonly VInt distanceOne = new VInt(1f);

	// Token: 0x040104A3 RID: 66723
	private static readonly VInt distanceOneHalf = new VInt(1.5f);
}
