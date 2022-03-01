using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

// Token: 0x0200414A RID: 16714
public sealed class BeActorStateGraph : BeStatesGraph
{
	// Token: 0x06016CF2 RID: 93426 RVA: 0x007021EC File Offset: 0x007005EC
	public override void InitStatesGraph()
	{
		BeStates rkStates = new BeStates(18, 2, delegate(BeStates state)
		{
			if (this.pkActor.HasAction(BeEntity.ActionConfigNames[23]))
			{
				this.pkActor.PlayAction(ActionType.ActionType_BIRTH, 1f, false);
				base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
			}
		}, delegate(BeStates pkState)
		{
			this.SwitchStates(new BeStateData(0, 0));
		}, null, null);
		this.AddStates2Graph(rkStates);
		BeStates beStates = new BeStates(0, 0, delegate(BeStates state)
		{
			this.pkActor.clickZSpeed = -VInt.Float2VIntValue(Global.Settings.clickForce);
			if ((this.pkActor.GetPosition().z > 0 && !this.pkActor.stateController.IgnoreGravity()) || this.pkActor.moveZSpeed != 0)
			{
				this.SwitchStates(new BeStateData(13, 0));
			}
			else
			{
				if (this.pkActor.IsDead())
				{
					this.pkActor.DoDead(false);
					return;
				}
				BeActorStateGraph beActorStateGraph = (BeActorStateGraph)state.pkGraph;
				BeActor pkActor2 = beActorStateGraph.pkActor;
				ActionType actionType = ActionType.ActionType_IDLE;
				if (pkActor2.isMainActor && pkActor2.CurrentBeScene.IsEnemyClear(pkActor2) && !pkActor2.GetEntityData().isSummonMonster)
				{
					actionType = ActionType.ActionType_SpecialIdle;
				}
				if (this.pkActor.buffController != null)
				{
					BeBuff beBuff = this.pkActor.buffController.HasBuffByID((!BattleMain.IsModePvP(this.pkActor.battleType)) ? 162209 : 162210);
					if (beBuff != null && !beBuff.state.IsDead())
					{
						actionType = ActionType.ActionType_SpecialIdle02;
					}
				}
				if (beActorStateGraph.m_lastState == 3 && pkActor2.HasAction(ActionType.ActionType_EndWalk) && pkActor2.m_cpkCurEntityActionInfo != null && pkActor2.m_cpkCurEntityActionInfo.moveName != BeEntity.ActionConfigNames[28])
				{
					int ms = pkActor2.PlayAction(ActionType.ActionType_EndWalk, 1f, false);
					pkActor2.delayCaller.DelayCall(ms, delegate
					{
						if (pkActor2.sgGetCurrentState() == 0)
						{
							pkActor2.PlayAction(actionType, 1f, false);
						}
					}, 0, 0, false);
				}
				else
				{
					pkActor2.PlayAction(actionType, 1f, false);
				}
				this.pkActor.SetTag(7, false);
				pkActor2.ClearMoveSpeed(7);
				this.pkActor.ResetWeight();
				if (this.pkActor.isFloating)
				{
					this.pkActor.RestoreFloating(false);
				}
				if (this.pkActor.stateController.HasBuffState(BeBuffStateType.STUN))
				{
					BeBuff buffByType = this.pkActor.buffController.GetBuffByType(BuffType.STUN);
					if (buffByType != null)
					{
						if (buffByType.buffData.TargetState.Length > 0)
						{
							this.pkActor.Locomote(new BeStateData(buffByType.buffData.TargetState[0], 0, 0, 0, 0, buffByType.GetLeftTime(), true), false);
						}
						else
						{
							Logger.LogErrorFormat("Actor pid {0} buffId {1} can not switch to Stun state", new object[]
							{
								this.pkActor.GetPID(),
								buffByType.buffData.ID
							});
						}
						this.pkActor.protectManager.ClearStandProtect();
					}
				}
			}
		}, null, null, null);
		BeStatesGraph.SGAddEventHandler2States(beStates, new BeEventsHandler(1, delegate(BeStates pkState)
		{
			if ((this.pkActor.moveXSpeed != 0 || this.pkActor.moveYSpeed != 0) && (this.pkActor.HasAction(ActionType.ActionType_WALK) || this.pkActor.HasAction(ActionType.ActionType_RUN)))
			{
				if (this.pkActor.isMainActor && !this.pkActor.hasDoublePress)
				{
					this.pkActor.ChangeRunMode(true);
				}
				this.SwitchStates(new BeStateData(3, 0));
			}
		}));
		this.AddStates2Graph(beStates);
		BeStates beStates2 = new BeStates(13, 2, delegate(BeStates state)
		{
			if (this.pkActor.moveZSpeed > 0)
			{
				if (this.pkActor.HasTag(1))
				{
					if (this.pkActor.GetPosition().z >= 8 * VInt.one.i)
					{
						this.pkActor.m_cpkCurEntityActionInfo = null;
					}
				}
				else
				{
					this.pkActor.PlayAction(ActionType.ActionType_RISE, 1f, false);
				}
			}
			else if (this.pkActor.HasTag(1))
			{
				if (this.pkActor.GetPosition().z >= 8 * VInt.one.i)
				{
					this.pkActor.m_cpkCurEntityActionInfo = null;
				}
			}
			else
			{
				this.pkActor.PlayAction(ActionType.ActionType_SINK, 1f, false);
			}
		}, null, null, delegate(BeStates state, int t)
		{
			if (this.pkActor.changeToNoBlock)
			{
				this.pkActor.changeToNoBlock = false;
				if (!this.pkActor.stateController.HasAbility(BeAbilityType.BLOCK))
				{
					this.pkActor.stateController.SetAbilityEnable(BeAbilityType.BLOCK, true);
				}
			}
		});
		BeStatesGraph.SGAddEventHandler2States(beStates2, new BeEventsHandler(3, delegate(BeStates pkState)
		{
			if (this.pkActor.HasTag(1))
			{
				this.pkActor.geLastTopZ = this.pkActor.GetPosition().fz;
			}
			else
			{
				if (!this.pkActor.HasTag(2))
				{
					this.pkActor.SetTag(2, true);
				}
				this.pkActor.PlayAction(ActionType.ActionType_SINK, 1f, false);
			}
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates2, new BeEventsHandler(4, delegate(BeStates state)
		{
			bool flag = this.pkActor.HasTag(1);
			bool flag2 = this.pkActor.HasTag(2);
			bool flag3 = this.pkActor.HasTag(4);
			if (flag)
			{
				if (flag3)
				{
					this.SwitchStates(new BeStateData(11, 0));
				}
				else
				{
					this.SwitchStates(new BeStateData(10, 0));
				}
			}
			else if (flag2)
			{
				this.pkActor.SetTag(2, false);
				int ms = this.pkActor.PlayAction(ActionType.ActionType_JumpDown, 1f, false);
				this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, false);
				this.pkActor.moveXSpeed = 0;
				this.pkActor.moveYSpeed = 0;
				this.pkActor.delayCaller.DelayCall(ms, delegate
				{
					this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
					if (this.pkActor.CurrentBeBattle != null && !this.pkActor.CurrentBeBattle.FunctionIsOpen(BattleFlagType.BudongmingwangHuixuantiBug))
					{
						if (!this.pkActor.IsGrabed())
						{
							this.LocomoteState();
						}
					}
					else
					{
						this.LocomoteState();
					}
				}, 0, 0, false);
			}
			else
			{
				this.LocomoteState();
			}
		}));
		this.AddStates2Graph(beStates2);
		BeStates beStates3 = new BeStates(3, 0, delegate(BeStates pkState)
		{
			this.pkActor.buffController.TriggerBuffs(BuffCondition.START_RUN, null, null);
			int num = 0;
			if (this.pkActor.HasAction(ActionType.ActionType_StartWalk))
			{
				num = this.pkActor.PlayAction(ActionType.ActionType_StartWalk, 1f, false);
			}
			if (num > 0)
			{
				this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, false);
				this.pkActor.delayCaller.DelayCall(num, delegate
				{
					this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
					if (this.pkActor.sgGetCurrentState() == 3)
					{
						this.pkActor.RefreshMoveSpeed();
					}
				}, 0, 0, false);
			}
			else
			{
				this.pkActor.RefreshMoveSpeed();
			}
		}, null, null, delegate(BeStates pkState, int iNewState)
		{
			if (iNewState != 5)
			{
				this.pkActor.ChangeRunMode(false);
			}
			if (this.pkActor.doublePressRun)
			{
				this.pkActor.doublePressRun = false;
				int buffID = 35;
				this.pkActor.buffController.RemoveBuff(buffID, 0, 0);
			}
		});
		BeStatesGraph.SGAddEventHandler2States(beStates3, new BeEventsHandler(1, delegate(BeStates pkState)
		{
			if (this.pkActor.moveXSpeed == 0 && this.pkActor.moveYSpeed == 0)
			{
				this.pkActor.ChangeRunMode(false);
				this.SwitchStates(new BeStateData(0, 0));
			}
			else
			{
				int num = (int)((!this.pkActor.IsRunning()) ? this.pkActor.walkAction : this.pkActor.runAction);
				if (this.m_iCurrentMoveState != num)
				{
					this.m_iCurrentMoveState = num;
					float aniSpeed = (!this.pkActor.IsRunning()) ? this.pkActor.walkSpeedFactor : this.pkActor.runSpeedFactor;
					this.pkActor.PlayAction((ActionType)this.m_iCurrentMoveState, aniSpeed, false);
				}
			}
		}));
		this.AddStates2Graph(beStates3);
		BeStates rkStates2 = new BeStates(5, 0, delegate(BeStates pkState)
		{
			this.pkActor.SetMoveSpeedZ(VInt.Float2VIntValue(Global.Settings.jumpForce));
			this.pkActor.SetTag(2, true);
			int ms = this.pkActor.PlayAction(ActionType.ActionType_JumpUp, 1f, false);
			this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, false);
			this.pkActor.moveYSpeed = 0;
			this.pkActor.delayCaller.DelayCall(ms, delegate
			{
				this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
				this.SwitchStates(new BeStateData(13, 0));
			}, 0, 0, false);
		}, null, null, null);
		this.AddStates2Graph(rkStates2);
		BeStates beStates4 = new BeStates(6, 3, delegate(BeStates pkState)
		{
			this.pkActor.SetMoveSpeedZ(VInt.NewVInt((long)Singleton<TableManager>.instance.gst.jumpBackSpeed[1], (long)GlobalLogic.VALUE_1000));
			this.pkActor.SetMoveSpeedXLocal(VInt.NewVInt((long)Singleton<TableManager>.instance.gst.jumpBackSpeed[0], (long)GlobalLogic.VALUE_1000));
			this.pkActor.SetMoveSpeedY(0);
			this.m_uiCurrentStatesTime = 0U;
			this.pkActor.PlayAction(ActionType.ActionType_DOWN, 1f, false);
		}, null, null, null);
		BeStatesGraph.SGAddEventHandler2States(beStates4, new BeEventsHandler(4, delegate(BeStates pkState)
		{
			this.LocomoteState();
		}));
		this.AddStates2Graph(beStates4);
		BeStates rkStates3 = new BeStates(9, 3, delegate(BeStates pkState)
		{
			if (this.pkActor.isFloating)
			{
				this.pkActor.RemoveFloating();
			}
			if (this.pkActor.HasTag(4))
			{
				this.pkActor.forceX = this.pkActor.forceX.i * VFactor.NewVFactorF(Global.Settings.fallgroundHitFactor, GlobalLogic.VALUE_1000);
				this.pkActor.forceY = this.pkActor.forceY.i * VFactor.NewVFactorF(Global.Settings.fallgroundHitFactor, GlobalLogic.VALUE_1000);
			}
			else if (this.pkActor.fallForGrab)
			{
				this.pkActor.PlayQueuedAction(new List<ActionType>
				{
					ActionType.ActionType_HURT,
					ActionType.ActionType_HURT1
				}, 1f);
			}
			else
			{
				this.pkActor.PlayQueuedAction(new List<ActionType>
				{
					ActionType.ActionType_HURT,
					ActionType.ActionType_HURT1,
					ActionType.ActionType_FALL_UP
				}, 1f);
			}
			if (this.pkActor.forceY == 0)
			{
				this.pkActor.forceY = VInt.Float2VIntValue(0.01f);
			}
			this.pkActor.SetMoveSpeedX(this.pkActor.forceX);
			this.pkActor.SetMoveSpeedZ(this.pkActor.forceY);
			this.pkActor.SetMoveSpeedY(0);
			this.pkActor.SetTag(1, true);
			this.pkActor.SetTag(2, false);
			this.SwitchStates(new BeStateData(13, 0));
			this.pkActor.protectManager.StartFallHurtCount();
			this.pkActor.protectManager.ClearStandProtect();
		}, null, null, delegate(BeStates state, int t)
		{
		});
		this.AddStates2Graph(rkStates3);
		BeStates beStates5 = new BeStates(10, 3, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(6);
			VInt[] array = new VInt[]
			{
				-this.pkActor.clickZSpeed.i * VFactor.NewVFactor(50, 100)
			};
			this.pkActor.TriggerEvent(BeEventType.onChangeClickForce, new object[]
			{
				array
			});
			this.pkActor.SetMoveSpeedZ(array[0]);
			this.m_uiCurrentStatesTime = 0U;
			if (!this.pkActor.HasTag(4))
			{
				this.pkActor.PlayAction(ActionType.ActionType_FALL_UP, 1f, false);
			}
			this.pkActor.SetTag(4, true);
			this.pkActor.protectManager.StartGroundHurtCount();
			this.pkActor.protectManager.ClearStandProtect();
			if (this.pkActor.geLastTopZ > Global.Settings.highFallHight)
			{
				this.pkActor.CurrentBeScene.currentGeScene.GetCamera().PlayShockEffect(Global.Settings.playerHighFallTouchGroundShockData);
			}
			base.SetCurrentStatesTimeout(GlobalLogic.VALUE_5000, false);
			MonoSingleton<AudioManager>.instance.PlaySound(1000);
		}, null, null, null);
		BeStatesGraph.SGAddEventHandler2States(beStates5, new BeEventsHandler(3, delegate(BeStates pkState)
		{
			if (!this.pkActor.HasTag(4))
			{
				this.pkActor.PlayAction(ActionType.ActionType_FALL_DOWN, 1f, false);
			}
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates5, new BeEventsHandler(4, delegate(BeStates pkState)
		{
			this.SwitchStates(new BeStateData(11, 0));
		}));
		this.AddStates2Graph(beStates5);
		BeStates rkStates4 = new BeStates(11, 3, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.PlayAction(ActionType.ActionType_FALL_GROUND, 1f, false);
			base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
			this.pkActor.SetTag(4, true);
			this.pkActor.protectManager.StartGroundHurtCount();
			this.pkActor.protectManager.ClearStandProtect();
			if (BattleMain.IsModePvP(this.pkActor.battleType) && this.pkActor.isLocalActor && this.pkActor.HasSkill(10001))
			{
				int cdleftTime = this.pkActor.GetSkill(10001).CDLeftTime;
				if (cdleftTime > 0)
				{
					this.pkActor.StartSpellBar(eDungeonCharactorBar.DunFuCD, cdleftTime, false, string.Empty, true);
				}
				else if (this.pkActor.CanUseSkill(10001))
				{
					this.pkActor.StartSpellBar(eDungeonCharactorBar.DunFuCD, 0, false, string.Empty, true);
				}
			}
		}, delegate(BeStates pkState)
		{
			if (this.pkActor.CanRoll())
			{
				this.SwitchStates(new BeStateData(20, 0));
			}
			else if (!this.pkActor.stateController.HasBuffState(BeBuffStateType.SLEEP))
			{
				this.SwitchStates(new BeStateData(17, 0));
			}
		}, delegate(BeStates pkState, int t)
		{
			if (this.m_uiCurrentStatesTime >= 180U && this.pkActor.CanUseDunfu())
			{
				this.SwitchStates(new BeStateData(17, 0));
			}
		}, delegate(BeStates pkState, int t)
		{
			if (BattleMain.IsModePvP(this.pkActor.battleType) && this.pkActor.isLocalActor)
			{
				this.pkActor.StopSpellBar(eDungeonCharactorBar.DunFuCD, true);
			}
		});
		this.AddStates2Graph(rkStates4);
		BeStates rkStates5 = new BeStates(20, 3, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.SetMoveSpeedXLocal(VInt.Float2VIntValue(Global.Settings.rollSpeed.x));
			this.pkActor.SetMoveSpeedY(VInt.Float2VIntValue(Global.Settings.rollSpeed.y));
			if (this.pkActor.HasAction(ActionType.ActionType_Roll))
			{
				this.pkActor.PlayAction(ActionType.ActionType_Roll, 1f, false);
				int currentActionDuration = this.pkActor.GetCurrentActionDuration();
				base.SetCurrentStatesTimeout(currentActionDuration, false);
				this.pkActor.buffController.TryAddBuff(32, currentActionDuration - GlobalLogic.VALUE_100, 1);
			}
			else if (this.pkActor.HasAction(ActionType.ActionType_WALK))
			{
				this.pkActor.PlayAction(ActionType.ActionType_WALK, 1f, false);
				int value_ = GlobalLogic.VALUE_1000;
				base.SetCurrentStatesTimeout(value_, false);
				this.pkActor.buffController.TryAddBuff(32, value_ - GlobalLogic.VALUE_100, 1);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_100, false);
			}
		}, delegate(BeStates pkState)
		{
			this.SwitchStates(new BeStateData(0, 0));
		}, null, null);
		this.AddStates2Graph(rkStates5);
		BeStates rkStates6 = new BeStates(17, 3, delegate(BeStates pkState)
		{
			if (this.pkActor.IsDead())
			{
				this.pkActor.DoDead(false);
				return;
			}
			this.pkActor.buffController.TriggerBuffs(BuffCondition.GETUP, null, null);
			this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, false);
			this.pkActor.SetTag(5, false);
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.PlayAction(ActionType.ActionType_Getup, 1f, false);
			base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
			this.pkActor.protectManager.ClearGroundProtect();
			this.pkActor.protectManager.DelayClearFallProtect();
			BattleType battleType = this.pkActor.battleType;
			if (battleType == BattleType.MutiPlayer || battleType == BattleType.PVP3V3Battle || battleType == BattleType.GuildPVP || battleType == BattleType.Training || battleType == BattleType.MoneyRewardsPVP || battleType == BattleType.ScufflePVP || battleType == BattleType.ChijiPVP)
			{
				this.pkActor.buffController.TryAddBuff(43, GlobalLogic.VALUE_700, 1);
			}
			if (this.pkActor.CanUseDunfu())
			{
				this.pkActor.StartDunfu();
			}
			if (this.pkActor.isInDunfu)
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_100000, false);
			}
			if (this.pkActor.GetEntityData() != null && this.pkActor.GetEntityData().getupID > 0 && (this.pkActor.GetEntityData().type == 3 || this.pkActor.GetEntityData().type == 1 || this.pkActor.GetEntityData().type == 2) && (int)this.pkActor.FrameRandom.Random((uint)GlobalLogic.VALUE_1000) < this.pkActor.GetEntityData().getupIDRand)
			{
				this.pkActor.UseSkill(this.pkActor.GetEntityData().getupID, true);
			}
		}, delegate(BeStates pkState)
		{
			base.ClearStateStack();
			BeStateData beStateData = new BeStateData(0, 0);
			base.PushState(ref beStateData);
			this.LocomoteState();
		}, delegate(BeStates state, int t)
		{
			if (this.pkActor.UpdateDunfu(t))
			{
				base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
			}
		}, delegate(BeStates state, int t)
		{
			this.pkActor.stateController.SetAbilityEnable(BeAbilityType.MOVE, true);
		});
		this.AddStates2Graph(rkStates6);
		BeStates rkStates7 = new BeStates(4, 3, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.FrozenStartDis = this.pkActor.GetPosition();
			if (this.pkActor.HasTag(4) && !pkState.isForceSwitch)
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_150, false);
			}
			else
			{
				this.pkActor.SetMoveSpeedX(this.pkActor.forceX);
				this.pkActor.SetMoveSpeedZ(this.pkActor.forceY);
				this.pkActor.hurtCount++;
				ActionType actionType = ActionType.ActionType_HURT + this.pkActor.hurtCount % 2;
				if (this.pkActor.HasAction(actionType))
				{
					this.pkActor.PlayAction(actionType, 1f, false);
					base.SetCurrentStatesTimeout(this.pkActor.m_cpkCurEntityActionInfo.fRealFramesTime, false);
				}
				else
				{
					base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
				}
				if (this.pkActor.GetPosition().z <= VInt.Float2VIntValue(0.0001f))
				{
					this.pkActor.protectManager.StartStandHurtCount();
				}
			}
		}, delegate(BeStates pkState)
		{
			this.LocomoteState();
		}, delegate(BeStates pkState, int s)
		{
			if (Mathf.Abs(this.pkActor.GetPosition().x - this.pkActor.FrozenStartDis.x) >= this.pkActor.FrozenDisMax)
			{
				this.pkActor.SetMoveSpeedX(0);
				this.pkActor.SetMoveSpeedZ(0);
			}
		}, delegate(BeStates pkStates, int s)
		{
			this.pkActor.FrozenStartDis = VInt3.zero;
		});
		this.AddStates2Graph(rkStates7);
		BeStates beStates6 = new BeStates(14, 3, delegate(BeStates pkState)
		{
			if (this.pkActor.IsProcessRecord())
			{
				this.pkActor.GetRecordServer().Mark(142055304U, new int[]
				{
					this.pkActor.m_iID,
					this.pkActor.m_iCurSkillID,
					this.pkActor.GetPosition().x,
					this.pkActor.GetPosition().y,
					this.pkActor.GetPosition().z,
					this.pkActor.moveXSpeed.i,
					this.pkActor.moveYSpeed.i,
					this.pkActor.moveZSpeed.i,
					(!this.pkActor.GetFace()) ? 0 : 1,
					this.pkActor.attribute.GetHP(),
					this.pkActor.attribute.GetMP(),
					this.pkActor.GetAllStatTag(),
					this.pkActor.attribute.battleData.attack
				}, new string[]
				{
					this.pkActor.GetName()
				});
			}
			this.pkActor.ClearGrapedEntity();
			this.pkActor.buffController.TriggerBuffs(BuffCondition.RELEASE_SKILL, null, null);
			this.pkActor.buffController.TriggerBuffs(BuffCondition.RELEASE_SEPCIFY_SKILL, null, this.pkActor.m_iCurSkillID);
			this.pkActor.ClearQueuedAction();
			this.pkActor.ResetSkillPhase(this.pkActor.m_iCurSkillID);
			int skillID = this.pkActor.GetSkillPhaseId();
			this.pkActor.StartSkill(this.pkActor.m_iCurSkillID);
			BeSkill skill = this.pkActor.GetSkill(this.pkActor.m_iCurSkillID);
			if (skill != null && skill.skillData != null && skill.skillData.SkillCategory != 1)
			{
				this.pkActor.buffController.TriggerBuffs(BuffCondition.RELEASE_SKILL_EXCEPT_NORMAL_ATTACK, null, null);
			}
			if (skill != null && skill.useInternalID)
			{
				skillID = skill.skillData.SwitchSkillID;
			}
			if (skill != null && skill.IsCanceled())
			{
				return;
			}
			this.pkActor.skillAttackScale = VFactor.one;
			bool flag = BattleMain.IsModePvP(this.pkActor.battleType);
			if (flag && skill != null)
			{
				this.pkActor.skillAttackScale = VFactor.NewVFactor((long)skill.GetPvpAttackScale(), (long)GlobalLogic.VALUE_1000);
			}
			if (skill != null && skill.specialOperate && this.pkActor.skillPhase == skill.operationConfig.changePhase)
			{
				if (skill.joystickMode == SkillJoystickMode.FREE && skill.innerState == BeSkill.InnerState.CHOOSE_TARGET)
				{
					skill.SetInnerState(BeSkill.InnerState.LAUNCH);
				}
				if (skill.joystickHasMove)
				{
					skillID = skill.operationConfig.changeSkillIDs[skill.specialChoice];
				}
				else if (!skill.useInternalID)
				{
					skillID = skill.operationConfig.changeSkillIDs[0];
				}
			}
			this.ExecuteSkill(skillID);
		}, delegate(BeStates pkState)
		{
			this.pkActor.TryReleaseGrapedEntity();
			this.ExecuteNextPhaseSkill();
		}, delegate(BeStates pkState, int s)
		{
			BeSkill skill = this.pkActor.GetSkill(this.pkActor.m_iCurSkillID);
			if (skill != null && skill.charge && this.pkActor.IsDead())
			{
				this.SwitchStates(new BeStateData(0, 0));
			}
			if (skill != null && this.pkActor.skillPhase == skill.chargeConfig.repeatPhase && !skill.charged && skill.pressDuration > skill.GetCurrentCharge())
			{
				skill.isCharging = false;
				skill.charged = true;
				if (skill.chargeConfig.buffInfo != 0)
				{
					bool playBuffAni = skill.chargeConfig.playBuffAni;
					this.pkActor.buffController.TryAddBuff(skill.chargeConfig.buffInfo, this.pkActor, playBuffAni, null, 0);
				}
				this.pkActor.m_pkGeActor.CreateEffect(skill.chargeConfig.effect, skill.chargeConfig.locator, 0f, new Vec3(0f, 0f, 0f), 1f, 1f, false, false, EffectTimeType.SYNC_ANIMATION, false);
			}
		}, delegate(BeStates pkState, int s)
		{
			this.pkActor.TryReleaseGrapedEntity();
			if (SwitchFunctionUtility.IsOpen(23) && s != 14)
			{
				this.pkActor.m_iPreSkillID = this.pkActor.GetCurSkillID();
			}
			BeSkill skill = this.pkActor.GetSkill(this.pkActor.m_iPreSkillID);
			if (skill != null && skill.skillState.IsRunning())
			{
				this.pkActor.CancelSkill(this.pkActor.m_iPreSkillID, true);
			}
		});
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(3, delegate(BeStates pkState)
		{
			if (this.pkActor.m_cpkCurEntityActionInfo != null && this.pkActor.m_cpkCurEntityActionInfo.triggerType == TriggerNextPhaseType.UPSTOP)
			{
				this.ExecuteNextPhaseSkill();
			}
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(4, delegate(BeStates pkState)
		{
			if (this.pkActor.m_cpkCurEntityActionInfo != null && this.pkActor.m_cpkCurEntityActionInfo.triggerType == TriggerNextPhaseType.TOUCHGROUND)
			{
				this.ExecuteNextPhaseSkill();
			}
			else
			{
				this.pkActor.DealSkillEvent(EventCommand.EVENT_COMMAND_TOUCHGROUND);
			}
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(5, delegate(BeStates pkState)
		{
			if (this.pkActor.m_cpkCurEntityActionInfo != null && this.pkActor.m_cpkCurEntityActionInfo.triggerType == TriggerNextPhaseType.RELEASE_BUTTON)
			{
				this.ExecuteNextPhaseSkill();
			}
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(6, delegate(BeStates pkState)
		{
			this.pkActor.DealSkillEvent(EventCommand.EVENT_COMMAND_PRESS_JOYSTICK);
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(7, delegate(BeStates pkState)
		{
			this.pkActor.DealSkillEvent(EventCommand.EVENT_COMMAND_RELEASE_JOYSTICK);
		}));
		BeStatesGraph.SGAddEventHandler2States(beStates6, new BeEventsHandler(8, delegate(BeStates pkState)
		{
			if (this.pkActor.m_cpkCurEntityActionInfo != null && this.pkActor.m_cpkCurEntityActionInfo.triggerType == TriggerNextPhaseType.PRESS_AGAIN)
			{
				this.ExecuteNextPhaseSkill();
			}
		}));
		this.AddStates2Graph(beStates6);
		BeStates rkStates8 = new BeStates(15, 7, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.TriggerEvent(BeEventType.onGrabbed, null);
			if (this.pkActor.isAbsorb)
			{
				VInt3 position = this.pkActor.GetPosition();
				VInt2 vint = new VInt2(this.pkActor.absorbTargetPos.x - position.x, this.pkActor.absorbTargetPos.y - position.y);
				this.pkActor.absorbPos = position;
				VInt2 vint2 = new VInt2(this.pkActor.absorbPos.x - this.pkActor.absorbTargetPos.x, this.pkActor.absorbPos.y - this.pkActor.absorbTargetPos.y);
				this.pkActor.absorbLen = vint2.magnitude;
				VInt2 vint3 = vint.NormalizeTo(this.pkActor.absorbSpeed.i);
				this.pkActor.SetMoveSpeedX(vint3.x);
				this.pkActor.SetMoveSpeedY(vint3.y);
			}
			if (this.pkActor.protectManager.IsAfterGetUpFallCounting())
			{
				this.pkActor.protectManager.ResetFallTime();
			}
		}, delegate(BeStates pkState)
		{
			this.pkActor.stateController.SetGrabStat(GrabState.NONE);
			this.pkActor.EndPressCount();
			this.pkActor.JugePositionAfterGrab();
			this.pkActor.Locomote(new BeStateData(9, 0, 0, VInt.Float2VIntValue(1f), 0, 300, false), true);
		}, delegate(BeStates pkState, int time)
		{
			if (this.pkActor.isAbsorb)
			{
				if (this.pkActor.moveXAcc == 0 && this.pkActor.moveYAcc == 0 && this.pkActor.moveXSpeed == 0 && this.pkActor.moveYSpeed == 0 && this.pkActor.GetStateGraph().GetCurrentStatesTime() > 3000U)
				{
					base.SetCurrentStatesTimeout(0, false);
				}
				VInt3 position = this.pkActor.GetPosition();
				VInt2 vint = new VInt2(this.pkActor.absorbPos.x - position.x, this.pkActor.absorbPos.y - position.y);
				if (this.pkActor.absorbLen <= vint.magnitude)
				{
					this.pkActor.isAbsorb = false;
					this.pkActor.ClearMoveSpeed(7);
				}
			}
			else
			{
				if (this.pkActor.GetGrabber() != null && !this.pkActor.GetGrabber().IsSuplexGrap)
				{
					BeActor grabber = this.pkActor.GetGrabber();
					BDGrabData grabData = this.pkActor.GetGrabData();
					VInt3 position2 = grabber.GetPosition();
					if (!this.pkActor.GetGrabber().grabPos && !grabData.notUseGrabSetPos && !this.pkActor.IsDead())
					{
						VInt3 vint2 = new VInt3(position2.x + VInt.Float2VIntValue(grabData.posx * (float)grabber._getFaceCoff()), position2.y, VInt.Float2VIntValue(grabData.posy));
						if (!grabData.notGrabToBlock || this.pkActor.CurrentBeScene == null || !this.pkActor.CurrentBeScene.IsInBlockPlayer(vint2))
						{
							this.pkActor.SetPosition(vint2, false, false, false);
						}
					}
				}
				if ((this.pkActor.GetGrabber() == null || (this.pkActor.GetGrabber() != null && (this.pkActor.GetGrabber().IsDead() || this.pkActor.GetGrabber().sgGetCurrentState() != 14))) && this.pkActor.GetStateGraph().GetCurrentStatesTime() > 3000U)
				{
					base.SetCurrentStatesTimeout(0, false);
				}
			}
		}, delegate(BeStates pkState, int time)
		{
			this.pkActor.stateController.SetGrabStat(GrabState.NONE);
			this.pkActor.EndPressCount();
		});
		this.AddStates2Graph(rkStates8);
		this.AddStates2Graph(new BeStates(16, 4, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			this.pkActor.EndGrap();
			this.pkActor.SetIsDead(true);
			if (this.pkActor.IsMonster() || this.pkActor.GetEntityData().isSummonMonster)
			{
				if (!this.pkActor.IsSkillMonster())
				{
					this.pkActor.GetEntityData().SetHP(-1);
				}
				if (this.pkActor.HasAction("Expdead2"))
				{
					if (this.pkActor.m_pkGeActor != null)
					{
						this.pkActor.m_pkGeActor.RemoveSurface(uint.MaxValue);
					}
					this.pkActor.PlayAction("Expdead2", 1f);
					base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
					return;
				}
				if (this.pkActor.HasAction("Expdead3"))
				{
					if (this.pkActor.m_pkGeActor != null)
					{
						this.pkActor.m_pkGeActor.RemoveSurface(uint.MaxValue);
						this.pkActor.m_pkGeActor.SetActorVisible(false);
					}
					this.pkActor.PlayAction("Expdead3", 1f);
					base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
					return;
				}
				if (this.pkActor.playedExpDead)
				{
					base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
					return;
				}
				int whiteTime = IntMath.Float2Int(Global.Settings.deadWhiteTime * (float)GlobalLogic.VALUE_1000);
				int num = 0;
				if (this.pkActor.IsBoss() && !this.pkActor.GetEntityData().isSummonMonster)
				{
					if (!this.pkActor.HasTag(4))
					{
						if (this.pkActor.HasAction(ActionType.ActionType_DEAD))
						{
							this.pkActor.PlayAction(ActionType.ActionType_DEAD, 1f, false);
							num = this.pkActor.GetCurrentActionDuration();
						}
						else if (this.pkActor.HasAction(ActionType.ActionType_FALL_GROUND))
						{
							this.pkActor.PlayAction(ActionType.ActionType_FALL_GROUND, 1f, false);
							num = this.pkActor.GetCurrentActionDuration();
						}
					}
					if (num > 0)
					{
						this.pkActor.delayCaller.DelayCall(num, delegate
						{
							if (this.pkActor.m_pkGeActor != null)
							{
								this.pkActor.m_pkGeActor.StopAction();
								this.pkActor.m_pkGeActor.ChangeSurface("死亡2", 0f, true, true);
							}
						}, 0, 0, false);
						base.SetCurrentStatesTimeout(num + GlobalLogic.VALUE_10, true);
					}
					else
					{
						if (this.pkActor.m_pkGeActor != null)
						{
							this.pkActor.m_pkGeActor.ChangeSurface("死亡2", 0f, true, true);
						}
						base.SetCurrentStatesTimeout(0, true);
					}
				}
				else
				{
					if (this.pkActor.IsSkillMonster())
					{
						this.pkActor.deadType = DeadType.NORMAL;
					}
					if (this.pkActor.deadType == DeadType.NORMAL)
					{
						if (!this.pkActor.HasTag(4))
						{
							if (this.pkActor.HasAction(ActionType.ActionType_DEAD))
							{
								this.pkActor.PlayAction(ActionType.ActionType_DEAD, 1f, false);
								num = this.pkActor.GetCurrentActionDuration();
							}
							else if (this.pkActor.HasAction(ActionType.ActionType_FALL_GROUND))
							{
								this.pkActor.PlayAction(ActionType.ActionType_FALL_GROUND, 1f, false);
								num = this.pkActor.GetCurrentActionDuration();
							}
						}
						if (num > 0)
						{
							this.pkActor.delayCaller.DelayCall(num, delegate
							{
								this.pkActor.m_pkGeActor.StopAction();
								this.pkActor.m_pkGeActor.ChangeSurface("死亡", (float)whiteTime / 1000f, true, true);
							}, 0, 0, false);
							base.SetCurrentStatesTimeout(num + whiteTime, true);
						}
						else
						{
							if (this.pkActor != null && this.pkActor.m_pkGeActor != null)
							{
								this.pkActor.m_pkGeActor.StopAction();
							}
							else if (this.pkActor == null)
							{
								Logger.LogErrorFormat("pkActor is null!!", new object[0]);
							}
							else if (this.pkActor != null && this.pkActor.m_pkGeActor == null)
							{
								Logger.LogErrorFormat("pkActor.m_pkGeActo is null!! {0}", new object[]
								{
									this.pkActor.GetName()
								});
							}
							this.pkActor.m_pkGeActor.ChangeSurface("死亡", (float)whiteTime / 1000f, true, false);
							base.SetCurrentStatesTimeout(num + whiteTime, true);
						}
						if (this.pkActor.buffController.HasBuffByID(66) == null)
						{
							VInt3 pos = this.pkActor.GetPosition();
							BeScene bescene = this.pkActor.CurrentBeScene;
							bescene.DelayCaller.DelayCall(num + whiteTime - GlobalLogic.VALUE_10, delegate
							{
								bescene.currentGeScene.CreateEffect(Global.Settings.normalDeadEffect, 0f, pos.vec3, 1f, 1f, false, false);
							}, 0, 0, false);
						}
					}
					else if (this.pkActor.deadType == DeadType.CRITICAL || this.pkActor.deadType == DeadType.IMMEDIATE)
					{
						int whiteTime2 = whiteTime;
						this.pkActor.ResetActionInfo();
						if (this.pkActor.m_pkGeActor != null)
						{
							this.pkActor.m_pkGeActor.StopAction();
							this.pkActor.m_pkGeActor.ChangeSurface("死亡", (float)whiteTime2 / 1000f, true, false);
						}
						string effect = string.Empty;
						if (this.pkActor.deadType == DeadType.CRITICAL)
						{
							effect = Global.Settings.critialDeadEffect;
						}
						else
						{
							effect = Global.Settings.immediateDeadEffect;
						}
						BeScene scene = this.pkActor.CurrentBeScene;
						scene.DelayCaller.DelayCall(num + whiteTime2 - GlobalLogic.VALUE_10, delegate
						{
							scene.currentGeScene.CreateEffect(effect, 0f, this.pkActor.GetPosition().vec3, 1f, 1f, false, false);
						}, 0, 0, false);
						if (this.pkActor.deadType != DeadType.CRITICAL)
						{
							if (this.pkActor.deadType == DeadType.IMMEDIATE)
							{
							}
						}
						base.SetCurrentStatesTimeout(num + whiteTime2, true);
					}
				}
			}
			else if (this.pkActor.HasAction(ActionType.ActionType_DEAD))
			{
				this.pkActor.PlayAction(ActionType.ActionType_DEAD, 1f, false);
				int value_ = GlobalLogic.VALUE_1000;
				base.SetCurrentStatesTimeout(value_, true);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
				this.pkActor.m_iEntityLifeState = 4;
			}
		}, delegate(BeStates pkState)
		{
			int[] array = new int[]
			{
				0
			};
			this.pkActor.TriggerEvent(BeEventType.onMarkRemove, new object[]
			{
				array
			});
			bool flag = array[0] == 0;
			array[0] = 0;
			this.pkActor.TriggerEvent(BeEventType.onBeforeAfterDead, new object[]
			{
				array
			});
			bool flag2 = array[0] == 0;
			if (flag2)
			{
				this.pkActor.TriggerEvent(BeEventType.onAfterDead, null);
			}
			if (flag)
			{
				if (this.pkActor.IsBoss() && !this.pkActor.GetEntityData().isSummonMonster)
				{
					this.pkActor.m_pkGeActor.SetFootIndicatorVisible(false);
					this.pkActor.m_pkGeActor.SetHeadInfoVisible(false);
					this.pkActor.m_pkGeActor.RemoveHPBar();
					if (this.pkActor.CurrentBeBattle != null && this.pkActor.CurrentBeBattle.dungeonManager != null && this.pkActor.CurrentBeBattle.dungeonManager.GetDungeonDataManager() != null)
					{
						bool flag3 = this.pkActor.CurrentBeBattle.dungeonManager.GetDungeonDataManager().IsBossArea();
						if (flag3)
						{
							this.pkActor.dontDelete = true;
						}
					}
				}
				this.pkActor.m_iEntityLifeState = 4;
			}
			if (this.pkActor.m_pkGeActor != null)
			{
				this.pkActor.m_pkGeActor.Clear(44);
			}
			this.pkActor.OnDead();
		}, null, null)
		{
			priority = 2,
			canCover = false
		});
		BeStates rkStates9 = new BeStates(19, 2, delegate(BeStates pkState)
		{
			this.pkActor.ClearMoveSpeed(7);
			if (this.pkActor.HasAction(ActionType.ActionType_WIN))
			{
				this.pkActor.PlayAction(ActionType.ActionType_WIN, 1f, false);
				base.SetCurrentStatesTimeout(this.pkActor.GetCurrentActionDuration(), false);
			}
			else
			{
				base.SetCurrentStatesTimeout(GlobalLogic.VALUE_10, false);
			}
		}, delegate(BeStates pkState)
		{
			this.SwitchStates(new BeStateData(0, 0));
		}, null, null);
		this.AddStates2Graph(rkStates9);
	}

	// Token: 0x06016CF3 RID: 93427 RVA: 0x00702650 File Offset: 0x00700A50
	public override void Locomote(BeStateData rkStateData, bool bForce = false)
	{
		rkStateData.isForceSwitch = bForce;
		int state = rkStateData._State;
		bool flag = false;
		switch (state)
		{
		case 4:
		case 9:
			this.pkActor.fallForGrab = (rkStateData._StateData != 0);
			this.pkActor.forceX = rkStateData._StateData2;
			this.pkActor.forceY = rkStateData._StateData3;
			if (this.pkActor.sgGetCurrentState() == 15 && !bForce)
			{
				goto IL_219;
			}
			if (this.pkActor.HasTag(4) && state == 4 && !bForce)
			{
				base.ResetCurrentStateTime();
				goto IL_219;
			}
			if (state == 4 && this.pkActor.stateController.HasBuffState(BeBuffStateType.STUN) && this.pkActor.sgGetCurrentState() == 4)
			{
				return;
			}
			flag = true;
			goto IL_219;
		case 13:
			this.pkActor.SetMoveSpeedXLocal(rkStateData._StateData2);
			this.pkActor.SetMoveSpeedZ(rkStateData._StateData3);
			flag = true;
			goto IL_219;
		case 14:
		{
			int stateData = rkStateData._StateData;
			if (this.pkActor.sgGetCurrentState() == 14)
			{
				this.pkActor.m_iPreSkillID = this.pkActor.m_iCurSkillID;
			}
			else
			{
				this.pkActor.m_iPreSkillID = stateData;
			}
			this.pkActor.m_iCurSkillID = stateData;
			flag = false;
			this.pkActor.sgSwitchStates(rkStateData);
			goto IL_219;
		}
		case 15:
			if (rkStateData._StateData > 0)
			{
				if (rkStateData._StateData == 20)
				{
					this.pkActor.sgPushState(new BeStateData(17, 0));
					this.pkActor.SetTag(4, true);
				}
				this.pkActor.PlayAction((ActionType)rkStateData._StateData, 1f, false);
			}
			else
			{
				this.pkActor.PlayAction(ActionType.ActionType_HURT, 1f, false);
			}
			flag = true;
			goto IL_219;
		}
		flag = true;
		IL_219:
		if (flag)
		{
			if (this.pkActor.sgGetCurrentState() == 14 && state != 14)
			{
				this.pkActor.m_iPreSkillID = this.pkActor.m_iCurSkillID;
			}
			this.pkActor.sgSwitchStates(rkStateData);
		}
	}

	// Token: 0x06016CF4 RID: 93428 RVA: 0x007028B8 File Offset: 0x00700CB8
	public void TriggerEvent()
	{
		if (this.pkActor.IsInMoveDirection())
		{
			this.FireEvents2CurrentStates(6);
		}
	}

	// Token: 0x06016CF5 RID: 93429 RVA: 0x007028D4 File Offset: 0x00700CD4
	public void ExecuteNextPhaseSkill()
	{
		BeSkill currentSkill = this.pkActor.GetCurrentSkill();
		if (currentSkill != null && currentSkill.IsCanceled())
		{
			return;
		}
		this.pkActor.buffController.ClearPhaseDelete();
		this.pkActor.ClearPhaseDelete();
		this.pkActor.ClearPhaseDeleteAudio();
		this.pkActor.UpdateFrame();
		int num = this.pkActor.GetSkillPhaseId();
		if (num < 0)
		{
			this.pkActor.FinishSkill(this.pkActor.m_iCurSkillID);
			this.LocomoteState();
		}
		else
		{
			BeSkill currentSkill2 = this.pkActor.GetCurrentSkill();
			if (currentSkill2 != null)
			{
				SkillWalkMode walkMode = (SkillWalkMode)currentSkill2.GetWalkMode();
				if (walkMode == SkillWalkMode.CHANGE_DIR)
				{
					this.pkActor.SetSkillWalkMode(walkMode, VFactor.zero, default(VFactor));
				}
				if (currentSkill2.charge)
				{
					if (this.pkActor.skillPhase != currentSkill2.chargeConfig.repeatPhase)
					{
						currentSkill2.isCharging = false;
					}
					if (currentSkill2.buttonState == ButtonState.PRESS && this.pkActor.skillPhase == currentSkill2.chargeConfig.repeatPhase)
					{
						currentSkill2.pressDuration = 0;
						currentSkill2.isCharging = true;
						if (!currentSkill2.hideSpellBar)
						{
							this.pkActor.StartSpellBar(eDungeonCharactorBar.Power, currentSkill2.GetCurrentCharge(), false, string.Empty, false);
						}
					}
					if (currentSkill2.buttonState == ButtonState.RELEASE && this.pkActor.skillPhase == currentSkill2.chargeConfig.repeatPhase)
					{
						this.ExecuteNextPhaseSkill();
						return;
					}
					if (this.pkActor.skillPhase == currentSkill2.chargeConfig.changePhase && (currentSkill2.pressDuration > currentSkill2.GetCurrentCharge() || currentSkill2.buttonState == ButtonState.PRESS) && currentSkill2.charged)
					{
						num = currentSkill2.chargeConfig.switchPhaseID;
						this.pkActor.StopSpellBar(eDungeonCharactorBar.Power, false);
					}
					if (this.pkActor.skillPhase == currentSkill2.chargeConfig.changePhase && !currentSkill2.charged)
					{
						this.pkActor.StopSpellBar(eDungeonCharactorBar.Power, true);
					}
				}
				if (currentSkill2.specialOperate && this.pkActor.skillPhase == currentSkill2.operationConfig.changePhase)
				{
					if (currentSkill2.joystickMode == SkillJoystickMode.FREE && currentSkill2.innerState == BeSkill.InnerState.CHOOSE_TARGET)
					{
						currentSkill2.SetInnerState(BeSkill.InnerState.LAUNCH);
					}
					num = currentSkill2.operationConfig.changeSkillIDs[currentSkill2.specialChoice];
				}
				if (currentSkill2.GetWalkMode() == 9 || currentSkill2.CurSkillWalkMode == 9)
				{
					this.pkActor.ResetCmdDirty();
				}
			}
			bool[] array = new bool[1];
			this.pkActor.TriggerEvent(BeEventType.onNextPhaseBeforeExecute, new object[]
			{
				array,
				num
			});
			if (array[0])
			{
				this.ExecuteNextPhaseSkill();
				return;
			}
			this.ExecuteSkill(num);
		}
	}

	// Token: 0x06016CF6 RID: 93430 RVA: 0x00702BA4 File Offset: 0x00700FA4
	public void ExecuteSkill(int skillID)
	{
		if (this.pkActor.IsProcessRecord())
		{
			this.pkActor.GetRecordServer().Mark(142056073U, new int[]
			{
				this.pkActor.m_iID,
				this.pkActor.m_iCurSkillID,
				skillID,
				this.pkActor.GetPosition().x,
				this.pkActor.GetPosition().y,
				this.pkActor.GetPosition().z,
				this.pkActor.moveXSpeed.i,
				this.pkActor.moveYSpeed.i,
				this.pkActor.moveZSpeed.i,
				(!this.pkActor.GetFace()) ? 0 : 1,
				this.pkActor.attribute.GetHP(),
				this.pkActor.attribute.GetMP(),
				this.pkActor.GetAllStatTag(),
				this.pkActor.attribute.battleData.attack
			}, new string[]
			{
				this.pkActor.GetName()
			});
		}
		this.pkActor.ClearMoveSpeed(3);
		int sID = skillID;
		float num = 1f;
		BeSkill currentSkill = this.pkActor.GetCurrentSkill();
		if (currentSkill != null)
		{
			num = currentSkill.GetSkillSpeedFactor().single;
			currentSkill.EnterPhase(this.pkActor.skillPhase);
			int[] array = new int[]
			{
				skillID
			};
			this.pkActor.TriggerEvent(BeEventType.onPreSetSkillAction, new object[]
			{
				array
			});
			if (array[0] != skillID)
			{
				sID = array[0];
			}
		}
		string actionNameBySkillID = this.pkActor.GetActionNameBySkillID(sID);
		if (actionNameBySkillID == null)
		{
			Logger.LogErrorFormat("name:{0} skillid:{1} skillphase:{2} 找不到技能id {3}的技能配置文件", new object[]
			{
				this.pkActor.GetName(),
				this.pkActor.m_iCurSkillID,
				this.pkActor.skillPhase,
				skillID
			});
		}
		this.m_uiCurrentStatesTime = 0U;
		if (currentSkill != null && currentSkill.skillData != null && this.pkActor.m_cpkEntityInfo != null && currentSkill.skillData.PhaseRelatedSpeed == 1)
		{
			BDEntityActionInfo bdentityActionInfo = null;
			if (this.pkActor.m_cpkEntityInfo._vkActionsMap.ContainsKey(actionNameBySkillID))
			{
				bdentityActionInfo = this.pkActor.m_cpkEntityInfo._vkActionsMap[actionNameBySkillID];
			}
			else
			{
				Logger.LogErrorFormat("curSkill Id {0} actionName {1} can't find", new object[]
				{
					currentSkill.skillID,
					actionNameBySkillID
				});
			}
			if (bdentityActionInfo != null && bdentityActionInfo.relatedAttackSpeed)
			{
				num = currentSkill.GetSkillSpeedFactor().single * ((float)bdentityActionInfo.attackSpeed / 1000f);
				if (num < 0.4f)
				{
					num = 0.4f;
				}
			}
			else
			{
				num = VFactor.NewVFactor(currentSkill.skillData.Speed, GlobalLogic.VALUE_1000).single;
			}
		}
		this.pkActor.PlayAction(actionNameBySkillID, num);
		if (this.pkActor.m_cpkCurEntityActionInfo == null)
		{
			return;
		}
		int fRealFramesTime = this.pkActor.m_cpkCurEntityActionInfo.fRealFramesTime;
		if (this.pkActor.m_cpkCurEntityActionInfo.useSpellBar)
		{
			int num2 = IntMath.Float2Int(this.pkActor.m_cpkCurEntityActionInfo.spellBarTime * (float)GlobalLogic.VALUE_1000);
			if ((float)num2 > 0f && num2 <= fRealFramesTime)
			{
				this.pkActor.StartSpellBar(eDungeonCharactorBar.Sing, num2, true, string.Empty, false);
			}
			else
			{
				this.pkActor.StartSpellBar(eDungeonCharactorBar.Sing, fRealFramesTime, true, string.Empty, false);
			}
		}
		base.SetCurrentStatesTimeout(fRealFramesTime, false);
		BeSkill currentSkill2 = this.pkActor.GetCurrentSkill();
		if (currentSkill2 != null && !currentSkill2.charge && currentSkill2.chargeConfig.repeatPhase > 0 && this.pkActor.skillPhase == currentSkill2.chargeConfig.repeatPhase)
		{
			base.SetCurrentStatesTimeout(IntMath.Float2Int(currentSkill2.chargeConfig.chargeMinDuration, GlobalLogic.VALUE_1000), true);
		}
		this.TriggerEvent();
	}

	// Token: 0x040104CF RID: 66767
	public BeActor pkActor;

	// Token: 0x040104D0 RID: 66768
	public int m_iStateData;

	// Token: 0x040104D1 RID: 66769
	public int m_iPreState;

	// Token: 0x040104D2 RID: 66770
	public VInt m_vMoveSpeed;

	// Token: 0x040104D3 RID: 66771
	public int m_iCurrentMoveState;
}
