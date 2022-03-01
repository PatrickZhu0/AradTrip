using System;
using System.Collections.Generic;
using behaviac;
using GameClient;
using GamePool;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x020040E8 RID: 16616
public class BTAgent : Agent
{
	// Token: 0x060169DF RID: 92639 RVA: 0x006D8F59 File Offset: 0x006D7359
	public void _set_radius(int value)
	{
		this.radius = value;
	}

	// Token: 0x060169E0 RID: 92640 RVA: 0x006D8F62 File Offset: 0x006D7362
	public int _get_radius()
	{
		return this.radius;
	}

	// Token: 0x060169E1 RID: 92641 RVA: 0x006D8F6A File Offset: 0x006D736A
	public void _set_regist_gameTime(List<int> value)
	{
		this.regist_gameTime = value;
	}

	// Token: 0x060169E2 RID: 92642 RVA: 0x006D8F73 File Offset: 0x006D7373
	public List<int> _get_regist_gameTime()
	{
		return this.regist_gameTime;
	}

	// Token: 0x060169E3 RID: 92643 RVA: 0x006D8F7B File Offset: 0x006D737B
	public void _set_zhaohuancishu(int value)
	{
		this.zhaohuancishu = value;
	}

	// Token: 0x060169E4 RID: 92644 RVA: 0x006D8F84 File Offset: 0x006D7384
	public int _get_zhaohuancishu()
	{
		return this.zhaohuancishu;
	}

	// Token: 0x060169E5 RID: 92645 RVA: 0x006D8F8C File Offset: 0x006D738C
	public void _set_regist_TimeUp(List<int> value)
	{
		this.regist_TimeUp = value;
	}

	// Token: 0x060169E6 RID: 92646 RVA: 0x006D8F95 File Offset: 0x006D7395
	public List<int> _get_regist_TimeUp()
	{
		return this.regist_TimeUp;
	}

	// Token: 0x060169E7 RID: 92647 RVA: 0x006D8FA0 File Offset: 0x006D73A0
	public void Action_ChangeFaceToTarget()
	{
		if (this.GetOwner() == null)
		{
			return;
		}
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager == null)
		{
			return;
		}
		if (beActorAIManager.aiTarget == null)
		{
			return;
		}
		bool bFace = this.GetOwner().GetPosition().x - beActorAIManager.aiTarget.GetPosition().x > 0;
		this.GetOwner().SetFace(bFace, false, false);
	}

	// Token: 0x060169E8 RID: 92648 RVA: 0x006D9014 File Offset: 0x006D7414
	public void Action_CounterAddUp(int index)
	{
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager != null)
		{
			beActorAIManager.CounterAddUp(index);
		}
	}

	// Token: 0x060169E9 RID: 92649 RVA: 0x006D903C File Offset: 0x006D743C
	public void Action_StartTimer(int timerId)
	{
		BeAIManager ai = this.GetAI();
		if (ai == null)
		{
			return;
		}
		if (timerId > 4)
		{
			Logger.LogErrorFormat("计时器编号超过最大数量:{0}", new object[]
			{
				timerId
			});
			return;
		}
		if (ai.TimerFalgArr[timerId])
		{
			return;
		}
		ai.TimerArr[timerId] = 0;
		ai.TimerFalgArr[timerId] = true;
	}

	// Token: 0x060169EA RID: 92650 RVA: 0x006D9098 File Offset: 0x006D7498
	public void Action_AssignAITarget(int monsterId, bool isCancel)
	{
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager != null)
		{
			if (isCancel)
			{
				beActorAIManager.ForceAssignAiTarget(null);
			}
			else
			{
				BeActor owner = this.GetOwner();
				List<BeActor> list = ListPool<BeActor>.Get();
				if (owner != null && owner.CurrentBeScene != null)
				{
					owner.CurrentBeScene.FindActorById2(list, monsterId, false);
				}
				if (list.Count > 0)
				{
					beActorAIManager.ForceAssignAiTarget(list[0]);
				}
				ListPool<BeActor>.Release(list);
			}
		}
	}

	// Token: 0x060169EB RID: 92651 RVA: 0x006D9118 File Offset: 0x006D7518
	public void Action_SetCounter(int index, int value)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			ai.SetCounter(index, value);
		}
	}

	// Token: 0x060169EC RID: 92652 RVA: 0x006D913C File Offset: 0x006D753C
	public void Action_StopTimer(int timerId)
	{
		BeAIManager ai = this.GetAI();
		if (ai == null)
		{
			return;
		}
		if (timerId > 4)
		{
			Logger.LogErrorFormat("计时器编号超过最大数量:{0}", new object[]
			{
				timerId
			});
			return;
		}
		ai.TimerFalgArr[timerId] = false;
		ai.TimerArr[timerId] = 0;
	}

	// Token: 0x060169ED RID: 92653 RVA: 0x006D918C File Offset: 0x006D758C
	public void Action_CreateBossPhaseChange(int phase)
	{
		TeamCopyPhaseBossInfo teamCopyPhaseBossInfo = new TeamCopyPhaseBossInfo();
		if (ClientApplication.playerinfo != null)
		{
			teamCopyPhaseBossInfo.raceId = ClientApplication.playerinfo.session;
		}
		BeActor owner = this.GetOwner();
		if (owner != null && owner.CurrentBeBattle != null && owner.CurrentBeBattle.dungeonManager != null)
		{
			BattlePlayer mainPlayer = owner.CurrentBeBattle.dungeonPlayerManager.GetMainPlayer();
			if (mainPlayer != null)
			{
				teamCopyPhaseBossInfo.roleId = mainPlayer.playerInfo.roleId;
			}
		}
		teamCopyPhaseBossInfo.curFrame = FrameSync.instance.curFrame;
		teamCopyPhaseBossInfo.phase = (uint)phase;
		if (owner != null && owner.attribute != null)
		{
			VFactor vfactor = new VFactor((long)(owner.attribute.GetHP() * 100), (long)owner.attribute.GetMaxHP());
			teamCopyPhaseBossInfo.bossBloodRate = (uint)vfactor.single;
			NetManager.Instance().SendCommand<TeamCopyPhaseBossInfo>(ServerType.GATE_SERVER, teamCopyPhaseBossInfo);
		}
	}

	// Token: 0x060169EE RID: 92654 RVA: 0x006D926E File Offset: 0x006D766E
	public void Action_RemoveAbnormalBuffs()
	{
		if (this.GetOwner() == null)
		{
			return;
		}
		if (this.GetOwner().buffController == null)
		{
			return;
		}
		this.GetOwner().buffController.RemoveAllAbnormalBuff();
	}

	// Token: 0x060169EF RID: 92655 RVA: 0x006D92A0 File Offset: 0x006D76A0
	public void Action_Summon(int monsterId, List<int> offset, bool useSummonerLevel, int level)
	{
		if (this.GetOwner() == null)
		{
			return;
		}
		if (this.GetOwner().CurrentBeScene == null)
		{
			return;
		}
		VInt3 vint = this.GetOwner().GetPosition();
		if (offset.Count > 0)
		{
			vint.x += VInt.NewVInt(offset[0], GlobalLogic.VALUE_1000).i;
			vint.y += VInt.NewVInt(offset[1], GlobalLogic.VALUE_1000).i;
			vint.z += VInt.NewVInt(offset[2], GlobalLogic.VALUE_1000).i;
		}
		int num = 1;
		if (useSummonerLevel && this.GetOwner().GetEntityData() != null)
		{
			num = this.GetOwner().GetEntityData().level;
		}
		if (level > 1)
		{
			num = level;
		}
		int z = vint.z;
		if (this.GetOwner().CurrentBeScene.IsInBlockPlayer(vint))
		{
			vint = BeAIManager.FindStandPositionNew(vint, this.GetOwner().CurrentBeScene, this.GetOwner().GetFace(), false, 50);
		}
		vint.z = z;
		this.GetOwner().CurrentBeScene.SummonMonster(monsterId + num * 100, vint, this.GetOwner().GetCamp(), null, false, 0, true, 0, false, false);
	}

	// Token: 0x060169F0 RID: 92656 RVA: 0x006D9408 File Offset: 0x006D7808
	public int Action_GetAlivePlayerNum()
	{
		int num = 0;
		if (this.GetOwner() != null && this.GetOwner().CurrentBeBattle != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers() != null)
		{
			List<BattlePlayer> allPlayers = this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != null && allPlayers[i].playerActor != null && !allPlayers[i].playerActor.IsDead())
				{
					num++;
				}
			}
		}
		return num;
	}

	// Token: 0x060169F1 RID: 92657 RVA: 0x006D94C8 File Offset: 0x006D78C8
	public int Action_GetMonsterAttributeByID(int monsterID, int attributeType)
	{
		BeScene currentBeScene = this.GetOwner().CurrentBeScene;
		if (currentBeScene != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			bool flag = this.GetOwner().CurrentBeScene.FindMonsterByID(list, monsterID, true);
			if (list.Count > 0 && list[0] != null && list[0].GetEntityData() != null && attributeType == 0)
			{
				return (int)(list[0].GetEntityData().GetHPRate().single * (float)GlobalLogic.VALUE_1000);
			}
			ListPool<BeActor>.Release(list);
		}
		return -1;
	}

	// Token: 0x060169F2 RID: 92658 RVA: 0x006D955C File Offset: 0x006D795C
	public void Action_RegisterEventNew(EventType eventType)
	{
		int typeIndex = (int)eventType;
		if (typeIndex >= this.handleArrNew.Length || this.handleArrNew[typeIndex] != null)
		{
			return;
		}
		BeEventType type = BeEventType.onEnterBattle;
		if (eventType == EventType.OnBackHit)
		{
			type = BeEventType.onBackHit;
		}
		else if (eventType == EventType.OnHurt)
		{
			type = BeEventType.onHurt;
		}
		else if (eventType == EventType.OnBeforeHit)
		{
			type = BeEventType.onBeforeHit;
		}
		else if (eventType == EventType.OnDead)
		{
			type = BeEventType.onDead;
		}
		else if (eventType == EventType.OnBeforeOtherHit)
		{
			type = BeEventType.onBeforeOtherHit;
		}
		BeEventHandle beEventHandle = this.GetOwner().RegisterEvent(type, delegate(object[] args)
		{
			if (typeIndex >= this.receiveEventNew.Length || this.receiveEventNew[typeIndex])
			{
				return;
			}
			this.receiveEventNew[typeIndex] = true;
		});
		this.handleArrNew[(int)eventType] = beEventHandle;
	}

	// Token: 0x060169F3 RID: 92659 RVA: 0x006D960C File Offset: 0x006D7A0C
	public bool Condition_HasReceiveEventNew(EventType eventType)
	{
		if (eventType >= (EventType)this.receiveEventNew.Length)
		{
			return false;
		}
		bool flag = this.receiveEventNew[(int)eventType];
		if (flag)
		{
			this.receiveEventNew[(int)eventType] = false;
		}
		return flag;
	}

	// Token: 0x060169F4 RID: 92660 RVA: 0x006D9644 File Offset: 0x006D7A44
	public bool Condition_HaveTargetInArea(int radius)
	{
		if (this.GetOwner() == null)
		{
			return false;
		}
		if (this.GetOwner().CurrentBeScene == null)
		{
			return false;
		}
		List<BeActor> toRelease = ListPool<BeActor>.Get();
		BeActor beActor = this.GetOwner().CurrentBeScene.FindTargetByPriority(this.GetOwner(), VInt.NewVInt(radius, GlobalLogic.VALUE_1000));
		if (beActor != null)
		{
			ListPool<BeActor>.Release(toRelease);
			return true;
		}
		ListPool<BeActor>.Release(toRelease);
		return false;
	}

	// Token: 0x060169F5 RID: 92661 RVA: 0x006D96B0 File Offset: 0x006D7AB0
	public bool Condition_IsAroundBossRomm()
	{
		if (this.GetOwner() == null || this.GetOwner().CurrentBeBattle == null)
		{
			return false;
		}
		TreasureMapBattle treasureMapBattle = this.GetOwner().CurrentBeBattle as TreasureMapBattle;
		return treasureMapBattle != null && treasureMapBattle.IsNearBoss();
	}

	// Token: 0x060169F6 RID: 92662 RVA: 0x006D96FC File Offset: 0x006D7AFC
	public int Condition_DungeonRecoverProcess(int dungeonId)
	{
		if (this.GetOwner() != null && this.GetOwner().CurrentBeBattle != null)
		{
			RaidBattle raidBattle = this.GetOwner().CurrentBeBattle as RaidBattle;
			if (raidBattle != null)
			{
				return raidBattle.GetDungeonRecoverProcess(dungeonId);
			}
		}
		return 0;
	}

	// Token: 0x060169F7 RID: 92663 RVA: 0x006D9744 File Offset: 0x006D7B44
	public int Condition_GetMonsterCount()
	{
		int result = 0;
		if (this.GetOwner() == null)
		{
			return result;
		}
		if (this.GetOwner().CurrentBeScene == null)
		{
			return result;
		}
		BeAllEnemyMonsterFilter beAllEnemyMonsterFilter = new BeAllEnemyMonsterFilter();
		beAllEnemyMonsterFilter.containSkillMonster = false;
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetOwner().CurrentBeScene.GetFilterTarget(list, beAllEnemyMonsterFilter, true);
		result = list.Count;
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x060169F8 RID: 92664 RVA: 0x006D97A8 File Offset: 0x006D7BA8
	public int Condition_GetTimerById(int timerId)
	{
		BeAIManager ai = this.GetAI();
		if (ai == null)
		{
			return 0;
		}
		if (timerId > 4)
		{
			Logger.LogErrorFormat("计时器编号超过最大数量:{0}", new object[]
			{
				timerId
			});
			return 0;
		}
		return ai.TimerArr[timerId];
	}

	// Token: 0x060169F9 RID: 92665 RVA: 0x006D97F0 File Offset: 0x006D7BF0
	public int Condition_GetCounter(int index)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			return ai.GetCounter(index);
		}
		return 0;
	}

	// Token: 0x060169FA RID: 92666 RVA: 0x006D9814 File Offset: 0x006D7C14
	public bool Condition_CheckYDis(int dis)
	{
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager != null && beActorAIManager.aiTarget != null)
		{
			int num = Mathf.Abs(this.GetOwner().GetPosition().y - beActorAIManager.aiTarget.GetPosition().y);
			return num <= dis;
		}
		return false;
	}

	// Token: 0x060169FB RID: 92667 RVA: 0x006D9874 File Offset: 0x006D7C74
	public bool Condition_HavePlayerUseAwakeSkill()
	{
		return this.GetOwner() != null && this.GetOwner().CurrentBeScene != null && this.GetOwner().CurrentBeScene.HavePlayerUseAwakeSkill();
	}

	// Token: 0x060169FC RID: 92668 RVA: 0x006D98A8 File Offset: 0x006D7CA8
	public bool Condition_JudgeMonsterCount(int monsterId, int count)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetOwner().CurrentBeScene.FindMonsterByID(list, monsterId, true);
		bool result = list.Count >= count;
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x060169FD RID: 92669 RVA: 0x006D98E4 File Offset: 0x006D7CE4
	public bool Condition_ServerNotify(behaviac.ServerNotifyMessageId dungeonMsgType)
	{
		if (this.GetOwner() == null || this.GetOwner().CurrentBeBattle == null)
		{
			return false;
		}
		if (dungeonMsgType > behaviac.ServerNotifyMessageId.None)
		{
			RaidBattle raidBattle = this.GetOwner().CurrentBeBattle as RaidBattle;
			if (raidBattle != null)
			{
				return raidBattle.CheckServerNotify((int)dungeonMsgType);
			}
		}
		return false;
	}

	// Token: 0x060169FE RID: 92670 RVA: 0x006D9938 File Offset: 0x006D7D38
	private bool Condition_IsTimeUp(int time, int timeId)
	{
		if (time < 0 || timeId >= this.regist_TimeUp.Count)
		{
			Logger.LogErrorFormat("timerId is out of Range {0}", new object[]
			{
				timeId
			});
			return false;
		}
		if (this.GetOwner() == null)
		{
			return false;
		}
		BeScene currentBeScene = this.GetOwner().CurrentBeScene;
		if (currentBeScene != null)
		{
			if (this.regist_TimeUp[timeId] == 0)
			{
				this.regist_TimeUp[timeId] = currentBeScene.GameTime;
			}
			if (currentBeScene.GameTime - this.regist_TimeUp[timeId] >= time)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060169FF RID: 92671 RVA: 0x006D99D8 File Offset: 0x006D7DD8
	public bool Condition_HasMechanism(BE_Target targetType, BE_Equal operation, int mechanismID)
	{
		BeActor beActor = this.GetOwner();
		if (targetType == BE_Target.Enemy)
		{
			beActor = this.GetAI().aiTarget;
		}
		if (beActor == null)
		{
			return false;
		}
		BeMechanism mechanism = beActor.GetMechanism(mechanismID);
		bool flag = mechanism != null && mechanism.isRunning;
		if (operation == BE_Equal.NotEqual)
		{
			flag = !flag;
		}
		return flag;
	}

	// Token: 0x06016A00 RID: 92672 RVA: 0x006D9A2C File Offset: 0x006D7E2C
	public bool Condition_IsPlayerHasBuff(int buffId)
	{
		if (this.GetOwner() != null && this.GetOwner().CurrentBeBattle != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers() != null)
		{
			List<BattlePlayer> allPlayers = this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BattlePlayer battlePlayer = allPlayers[i];
				if (battlePlayer != null && battlePlayer.playerActor != null)
				{
					if (battlePlayer.playerActor.isSpecialMonster)
					{
						if (battlePlayer.playerActor.GetOwner() != null)
						{
							BeActor beActor = battlePlayer.playerActor.GetOwner() as BeActor;
							if (beActor != null && beActor.buffController != null)
							{
								if (beActor.buffController.HasBuffByID(buffId) != null)
								{
									return true;
								}
							}
						}
					}
					else if (battlePlayer.playerActor.buffController != null && battlePlayer.playerActor.buffController.HasBuffByID(buffId) != null)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06016A01 RID: 92673 RVA: 0x006D9B5C File Offset: 0x006D7F5C
	public bool Condition_ServerNotifyEx(int dungeonID)
	{
		if (this.GetOwner() == null || this.GetOwner().CurrentBeBattle == null)
		{
			return false;
		}
		RaidBattle raidBattle = this.GetOwner().CurrentBeBattle as RaidBattle;
		return raidBattle != null && raidBattle.CheckServerNotifyEx(dungeonID);
	}

	// Token: 0x06016A02 RID: 92674 RVA: 0x006D9BA8 File Offset: 0x006D7FA8
	public void Action_AddBuff(BE_Target targetType, int buffID, int buffTime, int buffLevel, int buffAttack)
	{
		BeActor beActor = this.GetOwner();
		if (targetType == BE_Target.Enemy)
		{
			beActor = this.GetAI().aiTarget;
		}
		if (beActor != null)
		{
			beActor.buffController.TryAddBuff(buffID, buffTime, buffLevel, 1000, buffAttack, false, null, 0, 0, null);
		}
	}

	// Token: 0x06016A03 RID: 92675 RVA: 0x006D9BF4 File Offset: 0x006D7FF4
	public void Action_AttackTargetByID(List<int> targetIds)
	{
		BeAIManager ai = this.GetAI();
		if (ai == null)
		{
			return;
		}
		if (this.monsterIDFilter == null)
		{
			this.monsterIDFilter = new BeMonsterIDFilter(targetIds);
		}
		else
		{
			this.monsterIDFilter.Init(targetIds);
		}
		ai.TargetFilter = this.monsterIDFilter;
	}

	// Token: 0x06016A04 RID: 92676 RVA: 0x006D9C44 File Offset: 0x006D8044
	public void Action_DoDestinationSelect(DestinationType destinationType)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			BeAIManager.DestinationType destinationSelectResult = BeAIManager.DestinationType.IDLE;
			switch (destinationType)
			{
			case DestinationType.GO_TO_TARGET:
				destinationSelectResult = BeAIManager.DestinationType.GO_TO_TARGET;
				break;
			case DestinationType.IDLE:
				destinationSelectResult = BeAIManager.DestinationType.IDLE;
				break;
			case DestinationType.ESCAPE:
				destinationSelectResult = BeAIManager.DestinationType.ESCAPE;
				break;
			case DestinationType.BYPASS_TRACK:
				destinationSelectResult = BeAIManager.DestinationType.BYPASS_TRACK;
				break;
			case DestinationType.Y_FIRST:
				destinationSelectResult = BeAIManager.DestinationType.Y_FIRST;
				break;
			case DestinationType.FOLLOW:
				destinationSelectResult = BeAIManager.DestinationType.FOLLOW;
				break;
			case DestinationType.WANDER:
				destinationSelectResult = BeAIManager.DestinationType.WANDER;
				break;
			case DestinationType.KEEP_DISTANCE:
				destinationSelectResult = BeAIManager.DestinationType.KEEP_DISTANCE;
				break;
			case DestinationType.FINAL_DOOR:
				destinationSelectResult = BeAIManager.DestinationType.FINAL_DOOR;
				break;
			case DestinationType.WANDER_IN_CIRCLE:
				destinationSelectResult = BeAIManager.DestinationType.WANDER_IN_CIRCLE;
				ai.monsterID = this.monsterID;
				ai.radius = this.radius;
				break;
			case DestinationType.WANDER_PKROBOT:
				destinationSelectResult = BeAIManager.DestinationType.WANDER_PKROBOT;
				break;
			case DestinationType.MOVETO_LEFT_SCENEEDGE:
				destinationSelectResult = BeAIManager.DestinationType.MOVETO_LEFT_SCENEEDGE;
				break;
			case DestinationType.GO_TO_TARGET2:
				destinationSelectResult = BeAIManager.DestinationType.GO_TO_TARGET2;
				break;
			}
			ai.destinationSelectResult = (int)destinationSelectResult;
		}
	}

	// Token: 0x06016A05 RID: 92677 RVA: 0x006D9D20 File Offset: 0x006D8120
	public void Action_EnemyNumberOfInAttackArea(int front, int back, int top, int down)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			int num = ai.EnemyNumberOfInAttackArea(front, back, top, down);
			this.SetLastResult(num);
		}
	}

	// Token: 0x06016A06 RID: 92678 RVA: 0x006D9D50 File Offset: 0x006D8150
	public int Action_GenRandom()
	{
		int result = 0;
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			int num = this.FrameRandom.InRange(0, 101);
			this.SetLastResult(num);
			result = num;
			if (this.GetOwner() != null && this.GetOwner().IsProcessRecord())
			{
				BeActor owner = this.GetOwner();
				this.GetOwner().GetRecordServer().Mark(7890550U, new int[]
				{
					owner.m_iID
				}, new string[]
				{
					owner.GetName()
				});
			}
		}
		return result;
	}

	// Token: 0x06016A07 RID: 92679 RVA: 0x006D9DDC File Offset: 0x006D81DC
	public void Action_MonsterNumberOfInArea(int front, int back, int top, int down, List<int> monsterIDs)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			int num = ai.MonsterInArea(front, back, top, down, monsterIDs.ToArray(), true);
			this.SetLastResult(num);
		}
	}

	// Token: 0x06016A08 RID: 92680 RVA: 0x006D9E14 File Offset: 0x006D8214
	public void Action_MonsterNumberOfInAreaByCamp(int front, int back, int top, int bottom, List<int> monsterIds, bool isEnemy)
	{
		BeAIManager ai = this.GetAI();
		if (ai != null)
		{
			int num = ai.MonsterInArea(front, back, top, bottom, monsterIds.ToArray(), isEnemy);
			this.SetLastResult(num);
		}
	}

	// Token: 0x06016A09 RID: 92681 RVA: 0x006D9E4C File Offset: 0x006D824C
	public void Action_RegisterEvent(EventType eventType)
	{
		if (this.handle == null)
		{
			BeEventType type = BeEventType.onEnterBattle;
			if (eventType == EventType.OnHurt)
			{
				type = BeEventType.onHurt;
			}
			else if (eventType == EventType.OnBackHit)
			{
				type = BeEventType.onBackHit;
			}
			else if (eventType == EventType.OnBeforeHit)
			{
				type = BeEventType.onBeforeHit;
			}
			else if (eventType == EventType.OnDead)
			{
				type = BeEventType.onDead;
			}
			else if (eventType == EventType.OnBeforeOtherHit)
			{
				type = BeEventType.onBeforeOtherHit;
			}
			this.handle = this.GetOwner().RegisterEvent(type, delegate(object[] args)
			{
				this.receivedEvent = true;
			});
		}
	}

	// Token: 0x06016A0A RID: 92682 RVA: 0x006D9ECC File Offset: 0x006D82CC
	public void Action_RegisterOtherEvent(EventType eventType, int monsterID)
	{
		if (this.otherHandle == null)
		{
			BeActor beActor = this.GetOwner();
			if (monsterID == 0)
			{
				return;
			}
			List<BeActor> list = ListPool<BeActor>.Get();
			beActor.CurrentBeScene.FindMonsterByID(list, monsterID, true);
			if (list.Count <= 0)
			{
				ListPool<BeActor>.Release(list);
				return;
			}
			beActor = list[0];
			ListPool<BeActor>.Release(list);
			BeEventType type = BeEventType.onEnterBattle;
			if (eventType == EventType.OnHurt)
			{
				type = BeEventType.onHurt;
			}
			else if (eventType == EventType.OnBackHit)
			{
				type = BeEventType.onBackHit;
			}
			else if (eventType == EventType.OnBeforeHit)
			{
				type = BeEventType.onBeforeHit;
			}
			else if (eventType == EventType.OnDead)
			{
				type = BeEventType.onDead;
			}
			else if (eventType == EventType.OnBeforeOtherHit)
			{
				type = BeEventType.onBeforeOtherHit;
			}
			this.otherHandle = beActor.RegisterEvent(type, delegate(object[] args)
			{
				this.receivedEvent = true;
			});
		}
	}

	// Token: 0x06016A0B RID: 92683 RVA: 0x006D9F94 File Offset: 0x006D8394
	public void Action_RemoveBuff(BE_Target targetType, int buffID)
	{
		BeActor beActor = this.GetOwner();
		if (targetType == BE_Target.Enemy)
		{
			beActor = this.GetAI().aiTarget;
		}
		if (beActor != null)
		{
			beActor.buffController.RemoveBuff(buffID, 0, 0);
		}
	}

	// Token: 0x06016A0C RID: 92684 RVA: 0x006D9FD0 File Offset: 0x006D83D0
	public void Action_ShowHeadText(string text, float durTime, int style)
	{
		BeActor owner = this.GetOwner();
		if (style == 0)
		{
			owner.m_pkGeActor.ShowHeadDialog(text, false, false, false, false, durTime, false);
		}
		else if (style == 1)
		{
			owner.m_pkGeActor.ShowHeadDialog(text, false, false, false, true, durTime, false);
		}
		else if (style == 2)
		{
			SystemNotifyManager.SysDungeonSkillTip(text, durTime, false);
		}
	}

	// Token: 0x06016A0D RID: 92685 RVA: 0x006DA031 File Offset: 0x006D8431
	public void Action_UnRegistEvent(EventType eventType)
	{
		if (this.handle != null)
		{
			this.receivedEvent = false;
			this.handle.Remove();
			this.handle = null;
		}
	}

	// Token: 0x06016A0E RID: 92686 RVA: 0x006DA058 File Offset: 0x006D8458
	public EBTStatus Action_WaitGameTime(int waitTime, int timerId)
	{
		if (timerId < 0 || timerId >= this.regist_gameTime.Count)
		{
			Logger.LogErrorFormat("timerId is out of Range {0}", new object[]
			{
				timerId
			});
			return EBTStatus.BT_SUCCESS;
		}
		if (this.GetOwner() == null)
		{
			return EBTStatus.BT_INVALID;
		}
		BeScene currentBeScene = this.GetOwner().CurrentBeScene;
		if (currentBeScene == null)
		{
			return EBTStatus.BT_INVALID;
		}
		if (this.regist_gameTime[timerId] == 0)
		{
			this.regist_gameTime[timerId] = currentBeScene.GameTime;
		}
		if (currentBeScene.GameTime - this.regist_gameTime[timerId] >= waitTime)
		{
			this.regist_gameTime[timerId] = 0;
			return EBTStatus.BT_SUCCESS;
		}
		return EBTStatus.BT_RUNNING;
	}

	// Token: 0x06016A0F RID: 92687 RVA: 0x006DA108 File Offset: 0x006D8508
	public bool Condition_CanUseSkill(int skillID)
	{
		BeAIManager ai = this.GetAI();
		return ai != null && ai.CanUseSkill(skillID);
	}

	// Token: 0x06016A10 RID: 92688 RVA: 0x006DA12C File Offset: 0x006D852C
	public bool Condition_CheckHasBuff(BE_Target target, BE_Equal operation, int buffID)
	{
		bool flag = this.HasBuff(buffID, target);
		if (operation == BE_Equal.NotEqual)
		{
			flag = !flag;
		}
		return flag;
	}

	// Token: 0x06016A11 RID: 92689 RVA: 0x006DA150 File Offset: 0x006D8550
	public bool Condition_CheckHPMP(HMType type, BE_Operation operation, float value)
	{
		bool result = false;
		BeActor owner = this.GetOwner();
		if (owner != null)
		{
			VFactor vfactor = VFactor.zero;
			VFactor vfactor2 = VFactor.zero;
			switch (type)
			{
			case HMType.HP:
				vfactor = new VFactor((long)owner.GetEntityData().GetHP(), 1L);
				vfactor2 = VFactor.NewVFactorF(value, 1);
				break;
			case HMType.HP_PERCENT:
				vfactor = owner.GetEntityData().GetHPRate();
				vfactor2 = VFactor.NewVFactorF(value, 100);
				break;
			case HMType.MP:
				vfactor = new VFactor((long)owner.GetEntityData().GetMP(), 1L);
				vfactor2 = VFactor.NewVFactorF(value, 1);
				break;
			case HMType.MP_PERCENT:
				vfactor = owner.GetEntityData().GetMPRate();
				vfactor2 = VFactor.NewVFactorF(value, 100);
				break;
			}
			switch (operation)
			{
			case BE_Operation.LessThan:
				result = (vfactor < vfactor2);
				break;
			case BE_Operation.LessThanOrEqualTo:
				result = (vfactor <= vfactor2);
				break;
			case BE_Operation.EqualTo:
				result = (vfactor == vfactor2);
				break;
			case BE_Operation.NotEqualTo:
				result = (vfactor2 != vfactor);
				break;
			case BE_Operation.GreaterThanOrEqualTo:
				result = (vfactor >= vfactor2);
				break;
			case BE_Operation.GreaterThan:
				result = (vfactor > vfactor2);
				break;
			}
		}
		return result;
	}

	// Token: 0x06016A12 RID: 92690 RVA: 0x006DA280 File Offset: 0x006D8680
	public bool Condition_CheckInPassive(BE_Target target, BE_Passive passive)
	{
		bool flag = this.IsInPassive(target);
		return (passive == BE_Passive.InPassive && flag) || (passive == BE_Passive.NotInPassive && !flag);
	}

	// Token: 0x06016A13 RID: 92691 RVA: 0x006DA2B4 File Offset: 0x006D86B4
	public bool Condition_CheckIsUsingSkill(int skillID)
	{
		BeAIManager ai = this.GetAI();
		return ai != null && ai.CheckUseSkill(skillID);
	}

	// Token: 0x06016A14 RID: 92692 RVA: 0x006DA2D8 File Offset: 0x006D86D8
	public bool Condition_CheckLastResult(BE_Operation operation, int value)
	{
		bool result = false;
		switch (operation)
		{
		case BE_Operation.LessThan:
			result = (this.lastResult < value);
			break;
		case BE_Operation.LessThanOrEqualTo:
			result = (this.lastResult <= value);
			break;
		case BE_Operation.EqualTo:
			result = (this.lastResult == value);
			break;
		case BE_Operation.NotEqualTo:
			result = (this.lastResult != value);
			break;
		case BE_Operation.GreaterThanOrEqualTo:
			result = (this.lastResult >= value);
			break;
		case BE_Operation.GreaterThan:
			result = (this.lastResult > value);
			break;
		}
		return result;
	}

	// Token: 0x06016A15 RID: 92693 RVA: 0x006DA370 File Offset: 0x006D8770
	public bool Condition_CheckLevel(BE_Target target, BE_Operation operation, int level)
	{
		int level2 = this.GetLevel(target);
		switch (operation)
		{
		case BE_Operation.LessThan:
			return level2 < level;
		case BE_Operation.LessThanOrEqualTo:
			return level2 <= level;
		case BE_Operation.EqualTo:
			return level2 == level;
		case BE_Operation.NotEqualTo:
			return level2 != level;
		case BE_Operation.GreaterThanOrEqualTo:
			return level2 >= level;
		case BE_Operation.GreaterThan:
			return level2 > level;
		default:
			return false;
		}
	}

	// Token: 0x06016A16 RID: 92694 RVA: 0x006DA404 File Offset: 0x006D8804
	public bool Condition_CheckState(BE_Target target, BE_Equal operation, BE_State state)
	{
		BE_State state2 = this.GetState(target);
		return (operation == BE_Equal.Equal && state2 == state) || (operation == BE_Equal.NotEqual && state2 != state);
	}

	// Token: 0x06016A17 RID: 92695 RVA: 0x006DA43C File Offset: 0x006D883C
	public bool Condition_GetRandom(float succeedRandom)
	{
		ushort num = this.FrameRandom.Range100();
		int roundInt = VFactor.NewVFactor(IntMath.Float2Int(succeedRandom, 1000), 10).roundInt;
		return (int)num <= roundInt;
	}

	// Token: 0x06016A18 RID: 92696 RVA: 0x006DA47C File Offset: 0x006D887C
	public bool Condition_HasReceiveEvent(EventType EventType)
	{
		bool result = this.receivedEvent;
		if (this.receivedEvent)
		{
			this.receivedEvent = false;
		}
		return result;
	}

	// Token: 0x06016A19 RID: 92697 RVA: 0x006DA4A4 File Offset: 0x006D88A4
	public bool Condition_HaveSkill(int skillId)
	{
		BeAIManager ai = this.GetAI();
		return ai != null && ai.owner != null && ai.owner.HasSkill(skillId);
	}

	// Token: 0x06016A1A RID: 92698 RVA: 0x006DA4DC File Offset: 0x006D88DC
	public bool Condition_IsHaveMonster(int monsterID)
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetOwner().CurrentBeScene.FindMonsterByID(list, monsterID, true);
		bool result = list.Count > 0;
		ListPool<BeActor>.Release(list);
		return result;
	}

	// Token: 0x06016A1B RID: 92699 RVA: 0x006DA514 File Offset: 0x006D8914
	public bool Condition_IsSelfInCircle()
	{
		List<BeActor> list = ListPool<BeActor>.Get();
		this.GetOwner().CurrentBeScene.FindMonsterByID(list, this.monsterID, true);
		if (list.Count > 0)
		{
			BeActor beActor = list[0];
			VInt vint = IntMath.Float2IntWithFixed((float)this.radius / 1000f, 10000L, 100L, MidpointRounding.ToEven);
			int magnitude = (this.GetOwner().GetPosition() - beActor.GetPosition()).magnitude;
			ListPool<BeActor>.Release(list);
			return magnitude <= vint.i;
		}
		ListPool<BeActor>.Release(list);
		return false;
	}

	// Token: 0x06016A1C RID: 92700 RVA: 0x006DA5B4 File Offset: 0x006D89B4
	public bool Condition_IsTargetInAttackArea(int front, int back, int top, int down)
	{
		BeAIManager ai = this.GetAI();
		return ai != null && ai.IsTargetInAttackArea(front, back, top, down);
	}

	// Token: 0x06016A1D RID: 92701 RVA: 0x006DA5DC File Offset: 0x006D89DC
	public bool Condition_XDis(BE_Operation compare, int dis)
	{
		if (this.GetOwner() == null)
		{
			return false;
		}
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager == null)
		{
			return false;
		}
		if (beActorAIManager.aiTarget == null)
		{
			return false;
		}
		int num = Mathf.Abs(this.GetOwner().GetPosition().x - beActorAIManager.aiTarget.GetPosition().x);
		if (compare == BE_Operation.GreaterThan)
		{
			return num > dis;
		}
		if (compare == BE_Operation.GreaterThanOrEqualTo)
		{
			return num >= dis;
		}
		if (compare == BE_Operation.LessThan)
		{
			return num < dis;
		}
		if (compare == BE_Operation.LessThanOrEqualTo)
		{
			return num <= dis;
		}
		return compare == BE_Operation.EqualTo && num == dis;
	}

	// Token: 0x06016A1E RID: 92702 RVA: 0x006DA686 File Offset: 0x006D8A86
	public bool Conditon_IsDayTime()
	{
		return this.GetOwner() != null && this.GetOwner().CurrentBeScene != null && this.GetOwner().CurrentBeScene.IsDayTime();
	}

	// Token: 0x06016A1F RID: 92703 RVA: 0x006DA6B8 File Offset: 0x006D8AB8
	public bool Condition_isTargetIsCircleArea(int innerFront, int innerBack, int innerTop, int innerBottom, int outerFront, int outerBack, int outerTop, int outerBottom)
	{
		BeAIManager ai = this.GetAI();
		return ai != null && ai.IsTargetInConcentricCircles(innerFront, innerBack, innerTop, innerBottom, outerFront, outerBack, outerTop, outerBottom);
	}

	// Token: 0x06016A20 RID: 92704 RVA: 0x006DA6E8 File Offset: 0x006D8AE8
	public bool Condition_IsPlayerAround(int radius)
	{
		BeActor owner = this.GetOwner();
		if (owner != null && owner.CurrentBeBattle != null && owner.CurrentBeBattle.dungeonPlayerManager != null)
		{
			List<BattlePlayer> allPlayers = owner.CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers == null)
			{
				return false;
			}
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					int distance = playerActor.GetDistance(owner);
					VInt b = VInt.NewVInt(radius, GlobalLogic.VALUE_1000);
					if (distance <= b)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x06016A21 RID: 92705 RVA: 0x006DA794 File Offset: 0x006D8B94
	public bool Condition_IsAroundHorizontalEdge(int dist, bool faceRelated, bool sameFace)
	{
		BeActor owner = this.GetOwner();
		if (owner == null)
		{
			return false;
		}
		int num = Math.Abs(owner.CurrentBeScene.logicXSize.x - owner.GetPosition().x);
		int num2 = Math.Abs(owner.CurrentBeScene.logicXSize.y - owner.GetPosition().x);
		if (!faceRelated)
		{
			return dist >= num || dist >= num2;
		}
		if (sameFace)
		{
			return (!owner.GetFace()) ? (dist >= num2) : (dist >= num);
		}
		return (!owner.GetFace()) ? (dist >= num) : (dist >= num2);
	}

	// Token: 0x06016A22 RID: 92706 RVA: 0x006DA858 File Offset: 0x006D8C58
	public void Action_DoAction(ref List<Input> inputs, bool isPVPAI)
	{
		BeAIManager ai = this.GetAI();
		if (ai == null)
		{
			return;
		}
		if (this.warAlike > -1 && this.FrameRandom.InRange(0, GlobalLogic.VALUE_100) > this.warAlike)
		{
			return;
		}
		AIInputData aiinputData = new AIInputData();
		for (int i = 0; i < inputs.Count; i++)
		{
			aiinputData.AddInput(inputs[i]);
			if (inputs[i].pressTime > 0)
			{
				aiinputData.AddInput(inputs[i].skillID, inputs[i].pressTime, inputs[i].pressTime, 0, false);
			}
		}
		ai.actionResult = 0;
		if (!isPVPAI && BeUtility.AddComboSkill(ai, aiinputData, this.GetOwner()))
		{
			return;
		}
		ai.aiInputData = aiinputData;
	}

	// Token: 0x06016A23 RID: 92707 RVA: 0x006DA940 File Offset: 0x006D8D40
	public bool Condition_PlayerHaveBuff(int buffID)
	{
		if (this.GetOwner() != null && this.GetOwner().CurrentBeBattle != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager != null && this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers() != null)
		{
			List<BattlePlayer> allPlayers = this.GetOwner().CurrentBeBattle.dungeonPlayerManager.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != null && allPlayers[i].playerActor != null && allPlayers[i].playerActor.buffController != null && allPlayers[i].playerActor.buffController.HasBuffByID(buffID) != null)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06016A24 RID: 92708 RVA: 0x006DAA18 File Offset: 0x006D8E18
	public bool Condition_AtLeastOneSkillInCD(List<int> skillIdArr)
	{
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager == null)
		{
			return false;
		}
		for (int i = 0; i < skillIdArr.Count; i++)
		{
			if (!beActorAIManager.CanUseSkill(skillIdArr[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016A25 RID: 92709 RVA: 0x006DAA68 File Offset: 0x006D8E68
	public bool Condition_AtLeastOneSkillCanUse(List<int> skillIdArr)
	{
		BeActorAIManager beActorAIManager = this.GetAI() as BeActorAIManager;
		if (beActorAIManager == null)
		{
			return false;
		}
		for (int i = 0; i < skillIdArr.Count; i++)
		{
			if (beActorAIManager.CanUseSkill(skillIdArr[i]))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06016A26 RID: 92710 RVA: 0x006DAAB8 File Offset: 0x006D8EB8
	public void Action_ResetTime(int timeID)
	{
		if (this.GetOwner() != null)
		{
			if (timeID < 0 || timeID >= this.regist_gameTime.Count)
			{
				return;
			}
			BeScene currentBeScene = this.GetOwner().CurrentBeScene;
			this.regist_gameTime[timeID] = currentBeScene.GameTime;
		}
	}

	// Token: 0x17001F02 RID: 7938
	// (get) Token: 0x06016A27 RID: 92711 RVA: 0x006DAB07 File Offset: 0x006D8F07
	private FrameRandomImp FrameRandom
	{
		get
		{
			return this.GetOwner().FrameRandom;
		}
	}

	// Token: 0x06016A28 RID: 92712 RVA: 0x006DAB14 File Offset: 0x006D8F14
	public void SetWarAlike(int val)
	{
		this.warAlike = val;
	}

	// Token: 0x06016A29 RID: 92713 RVA: 0x006DAB1D File Offset: 0x006D8F1D
	public void SetLastResult(int value)
	{
		this.lastResult = value;
	}

	// Token: 0x06016A2A RID: 92714 RVA: 0x006DAB26 File Offset: 0x006D8F26
	public BeEntity GetEntity()
	{
		return (this.buff == null) ? this.entity : this.buff.owner;
	}

	// Token: 0x06016A2B RID: 92715 RVA: 0x006DAB49 File Offset: 0x006D8F49
	public void SetEntity(BeEntity e)
	{
		this.entity = e;
	}

	// Token: 0x06016A2C RID: 92716 RVA: 0x006DAB54 File Offset: 0x006D8F54
	public BeAIManager GetAI()
	{
		BeAIManager result = null;
		if (this.entity != null)
		{
			result = this.entity.aiManager;
		}
		return result;
	}

	// Token: 0x06016A2D RID: 92717 RVA: 0x006DAB7B File Offset: 0x006D8F7B
	public BeActor GetOwner()
	{
		return this.entity as BeActor;
	}

	// Token: 0x06016A2E RID: 92718 RVA: 0x006DAB88 File Offset: 0x006D8F88
	private bool HasBuff(int buffID, BE_Target target)
	{
		BeActor beActor;
		if (target == BE_Target.Enemy)
		{
			beActor = this.GetAI().aiTarget;
		}
		else
		{
			beActor = this.GetOwner();
		}
		return beActor != null && beActor.buffController.HasBuffByID(buffID) != null;
	}

	// Token: 0x06016A2F RID: 92719 RVA: 0x006DABD0 File Offset: 0x006D8FD0
	private bool IsInPassive(BE_Target target)
	{
		BeEntity aiTarget;
		if (target == BE_Target.Enemy)
		{
			aiTarget = this.GetAI().aiTarget;
		}
		else
		{
			aiTarget = this.GetEntity();
		}
		return aiTarget != null && aiTarget.GetStateGraph().CurrentStateHasTag(7);
	}

	// Token: 0x06016A30 RID: 92720 RVA: 0x006DAC14 File Offset: 0x006D9014
	public int GetLevel(BE_Target target)
	{
		int result = 0;
		BeEntity aiTarget;
		if (target == BE_Target.Enemy)
		{
			aiTarget = this.GetAI().aiTarget;
		}
		else
		{
			aiTarget = this.GetEntity();
		}
		if (aiTarget != null)
		{
			result = aiTarget.GetEntityData().GetLevel();
		}
		return result;
	}

	// Token: 0x06016A31 RID: 92721 RVA: 0x006DAC58 File Offset: 0x006D9058
	private BE_State GetState(BE_Target target)
	{
		BE_State result = BE_State.NONE;
		BeEntity aiTarget;
		if (target == BE_Target.Enemy)
		{
			aiTarget = this.GetAI().aiTarget;
		}
		else
		{
			aiTarget = this.GetEntity();
		}
		if (aiTarget != null)
		{
			ActionState currentState = (ActionState)aiTarget.GetStateGraph().GetCurrentState();
			switch (currentState)
			{
			case ActionState.AS_IDLE:
				result = BE_State.IDLEE;
				break;
			default:
				switch (currentState)
				{
				case ActionState.AS_CASTSKILL:
					result = BE_State.SKILL;
					break;
				case ActionState.AS_GRAPED:
					result = BE_State.GRAPED;
					break;
				case ActionState.AS_DEAD:
					result = BE_State.DEAD;
					break;
				default:
					if (aiTarget.HasTag(4))
					{
						result = BE_State.DAODI;
					}
					else if (aiTarget.HasTag(1))
					{
						result = BE_State.FUKONG;
					}
					break;
				}
				break;
			case ActionState.AS_WALK:
			case ActionState.AS_RUN:
				result = BE_State.WALK;
				break;
			case ActionState.AS_HURT:
				result = BE_State.BEIJI;
				break;
			case ActionState.AS_JUMP:
				result = BE_State.JUMP;
				break;
			}
		}
		return result;
	}

	// Token: 0x17001F03 RID: 7939
	// (get) Token: 0x06016A32 RID: 92722 RVA: 0x006DAD2C File Offset: 0x006D912C
	private static string FilePath
	{
		get
		{
			string str = "/Resources/Data/AI/behaviac/exported";
			if (Application.platform == 7)
			{
				return Application.dataPath + str;
			}
			if (Application.platform == 2)
			{
				return Application.dataPath + str;
			}
			return "Assets" + str;
		}
	}

	// Token: 0x06016A33 RID: 92723 RVA: 0x006DAD78 File Offset: 0x006D9178
	private bool InitBehavic()
	{
		Workspace.Instance.FilePath = BTAgent.FilePath;
		Workspace.Instance.FileFormat = Workspace.EFileFormat.EFF_cs;
		for (int i = 0; i < 8; i++)
		{
			this.regist_gameTime.Add(0);
		}
		for (int j = 0; j < 8; j++)
		{
			this.regist_TimeUp.Add(0);
		}
		return true;
	}

	// Token: 0x06016A34 RID: 92724 RVA: 0x006DADDC File Offset: 0x006D91DC
	private bool InitPlayer(string treeName)
	{
		bool flag = base.btload(treeName);
		if (flag)
		{
			base.btsetcurrent(treeName);
		}
		return flag;
	}

	// Token: 0x06016A35 RID: 92725 RVA: 0x006DADFF File Offset: 0x006D91FF
	public bool Init(string treeName)
	{
		this.InitData();
		this.InitBehavic();
		return this.InitPlayer(treeName);
	}

	// Token: 0x06016A36 RID: 92726 RVA: 0x006DAE18 File Offset: 0x006D9218
	private void InitData()
	{
		int length = Enum.GetValues(typeof(EventType)).Length;
		this.handleArrNew = new BeEventHandle[length];
		this.receiveEventNew = new bool[length];
	}

	// Token: 0x06016A37 RID: 92727 RVA: 0x006DAE52 File Offset: 0x006D9252
	public void Tick()
	{
		if (Global.Settings.debugNewAutofightAI)
		{
			Workspace.Instance.DebugUpdate();
		}
		this.btexec();
	}

	// Token: 0x040101C1 RID: 65985
	public int bianshen;

	// Token: 0x040101C2 RID: 65986
	public bool buffRemoved;

	// Token: 0x040101C3 RID: 65987
	public int compare;

	// Token: 0x040101C4 RID: 65988
	public int lastResult;

	// Token: 0x040101C5 RID: 65989
	public int mojiankuilei;

	// Token: 0x040101C6 RID: 65990
	public int monsterID;

	// Token: 0x040101C7 RID: 65991
	private int radius;

	// Token: 0x040101C8 RID: 65992
	private List<int> regist_gameTime = new List<int>(0);

	// Token: 0x040101C9 RID: 65993
	public int shifacishu;

	// Token: 0x040101CA RID: 65994
	public int shifangjineng;

	// Token: 0x040101CB RID: 65995
	public int shifangjineng2;

	// Token: 0x040101CC RID: 65996
	public int shifangjineng3;

	// Token: 0x040101CD RID: 65997
	public int shouhufanshang;

	// Token: 0x040101CE RID: 65998
	public int zhaohuan;

	// Token: 0x040101CF RID: 65999
	private int zhaohuancishu;

	// Token: 0x040101D0 RID: 66000
	private List<int> regist_TimeUp = new List<int>(0);

	// Token: 0x040101D1 RID: 66001
	public BeEntity entity;

	// Token: 0x040101D2 RID: 66002
	public BeBuff buff;

	// Token: 0x040101D3 RID: 66003
	public BeEventHandle handle;

	// Token: 0x040101D4 RID: 66004
	public BeEventHandle otherHandle;

	// Token: 0x040101D5 RID: 66005
	public bool receivedEvent;

	// Token: 0x040101D6 RID: 66006
	private BeMonsterIDFilter monsterIDFilter;

	// Token: 0x040101D7 RID: 66007
	private BeEventHandle[] handleArrNew;

	// Token: 0x040101D8 RID: 66008
	private bool[] receiveEventNew;

	// Token: 0x040101D9 RID: 66009
	private int warAlike = -1;
}
