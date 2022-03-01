using System;
using System.Collections.Generic;
using GameClient;
using GamePool;
using PathFinder;
using ProtoTable;
using UnityEngine;

// Token: 0x02004119 RID: 16665
[LoggerModel("AI")]
public class BeAIManager
{
	// Token: 0x06016B06 RID: 92934 RVA: 0x006E13C0 File Offset: 0x006DF7C0
	public BeAIManager()
	{
		this.sight = GlobalLogic.VALUE_4000;
		this.targetType = BeAIManager.TargetType.NEAREST;
		this.warlike = 50;
		this.aiState = BeAIManager.AIState.NONE;
	}

	// Token: 0x17001F10 RID: 7952
	// (get) Token: 0x06016B07 RID: 92935 RVA: 0x006E14C8 File Offset: 0x006DF8C8
	public BeAICommand currentCmd
	{
		get
		{
			return this.currentCommand;
		}
	}

	// Token: 0x17001F11 RID: 7953
	// (get) Token: 0x06016B08 RID: 92936 RVA: 0x006E14D0 File Offset: 0x006DF8D0
	public FrameRandomImp FrameRandom
	{
		get
		{
			return this.owner.FrameRandom;
		}
	}

	// Token: 0x17001F12 RID: 7954
	// (get) Token: 0x06016B09 RID: 92937 RVA: 0x006E14DD File Offset: 0x006DF8DD
	public TrailManagerImp TrailManager
	{
		get
		{
			return this.owner.CurrentBeBattle.TrailManager;
		}
	}

	// Token: 0x17001F13 RID: 7955
	// (get) Token: 0x06016B0A RID: 92938 RVA: 0x006E14EF File Offset: 0x006DF8EF
	public BeProjectilePoolImp BeProjectilePool
	{
		get
		{
			return this.owner.CurrentBeBattle.BeProjectilePool;
		}
	}

	// Token: 0x17001F14 RID: 7956
	// (get) Token: 0x06016B0B RID: 92939 RVA: 0x006E1501 File Offset: 0x006DF901
	public BeAICommandPoolImp BeAICommandPool
	{
		get
		{
			return this.owner.CurrentBeBattle.BeAICommandPool;
		}
	}

	// Token: 0x17001F15 RID: 7957
	// (get) Token: 0x06016B0C RID: 92940 RVA: 0x006E1513 File Offset: 0x006DF913
	// (set) Token: 0x06016B0D RID: 92941 RVA: 0x006E151B File Offset: 0x006DF91B
	public int[] TimerArr
	{
		get
		{
			return this.timerArr;
		}
		set
		{
			this.timerArr = value;
		}
	}

	// Token: 0x17001F16 RID: 7958
	// (get) Token: 0x06016B0E RID: 92942 RVA: 0x006E1524 File Offset: 0x006DF924
	// (set) Token: 0x06016B0F RID: 92943 RVA: 0x006E152C File Offset: 0x006DF92C
	public bool[] TimerFalgArr
	{
		get
		{
			return this.timerFlagArr;
		}
		set
		{
			this.timerFlagArr = value;
		}
	}

	// Token: 0x17001F17 RID: 7959
	// (set) Token: 0x06016B10 RID: 92944 RVA: 0x006E1538 File Offset: 0x006DF938
	public BeAIManager.TargetEntityType entityFilter
	{
		set
		{
			this.filter = new BeTargetEntityTypeFilter
			{
				targetEntityType = value
			};
		}
	}

	// Token: 0x17001F18 RID: 7960
	// (set) Token: 0x06016B11 RID: 92945 RVA: 0x006E1559 File Offset: 0x006DF959
	public IEntityFilter TargetFilter
	{
		set
		{
			this.filter = value;
		}
	}

	// Token: 0x06016B12 RID: 92946 RVA: 0x006E1562 File Offset: 0x006DF962
	public void Init(BeActor o)
	{
		this.state = BeAIManager.State.READY;
		this.owner = o;
	}

	// Token: 0x17001F19 RID: 7961
	// (get) Token: 0x06016B13 RID: 92947 RVA: 0x006E1572 File Offset: 0x006DF972
	public UnitTable tableData
	{
		get
		{
			return this.mTableData;
		}
	}

	// Token: 0x06016B14 RID: 92948 RVA: 0x006E157C File Offset: 0x006DF97C
	public void SetSkillsEnable(List<int> skillIDs, bool flag)
	{
		for (int i = 0; i < skillIDs.Count; i++)
		{
			for (int j = 0; j < this.attackInfos.Count; j++)
			{
				BeAIManager.AttackInfo attackInfo = this.attackInfos[j];
				if (attackInfo.skillID == skillIDs[i])
				{
					attackInfo.enable = flag;
					break;
				}
			}
		}
	}

	// Token: 0x06016B15 RID: 92949 RVA: 0x006E15E8 File Offset: 0x006DF9E8
	public bool CanAIUseSkill(int skillID)
	{
		for (int i = 0; i < this.attackInfos.Count; i++)
		{
			if (this.attackInfos[i].skillID == skillID)
			{
				return this.attackInfos[i].enable;
			}
		}
		return true;
	}

	// Token: 0x06016B16 RID: 92950 RVA: 0x006E163C File Offset: 0x006DFA3C
	public void EnableSkillDisAbleOthers(Dictionary<int, int> skillIDMap, bool flag = true)
	{
		for (int i = 0; i < this.attackInfos.Count; i++)
		{
			BeAIManager.AttackInfo attackInfo = this.attackInfos[i];
			if (skillIDMap.ContainsKey(attackInfo.skillID))
			{
				attackInfo.enable = flag;
			}
			else
			{
				attackInfo.enable = !flag;
			}
		}
	}

	// Token: 0x06016B17 RID: 92951 RVA: 0x006E169C File Offset: 0x006DFA9C
	public void SetAIInfo(UnitTable data, bool bForceUpdate = false)
	{
		this.mTableData = data;
		this.isAPC = (data.AIIsAPC != 0);
		this.sight = ((data.AISight != 0) ? data.AISight : GlobalLogic.VALUE_4000);
		this.chaseSight = ((data.AIChase != 0) ? data.AIChase : (this.sight * GlobalLogic.VALUE_3));
		this.warlike = ((data.AIWarlike != 0) ? data.AIWarlike : GlobalLogic.VALUE_50);
		this.thinkTerm = ((data.AIAttackDelay != 0) ? data.AIAttackDelay : GlobalLogic.VALUE_2000);
		this.findTargetTerm = ((data.AIThinkTargetTerm != 0) ? data.AIThinkTargetTerm : GlobalLogic.VALUE_2000);
		this.changeDestinationTerm = ((data.AIDestinationChangeTerm != 0) ? data.AIDestinationChangeTerm : GlobalLogic.VALUE_3000);
		this.keepDistance = VInt.NewVInt((long)data.AIKeepDistance, (long)GlobalLogic.VALUE_1000);
		this.followDistance = (float)data.AIFollowDistance / (float)GlobalLogic.VALUE_1000;
		this.targetType = (BeAIManager.TargetType)data.AITargetType[0];
		this.aiType = (BeAIManager.AIType)data.AICombatType;
		this.idleMode = (BeAIManager.IdleMode)data.AIIdleMode;
		if (Utility.IsStringValid(data.AIAttackKind[0]))
		{
			this.LoadAttackInfo(data.AIAttackKind);
		}
		this.idleRand = ((data.AIIdleRand != 0) ? data.AIIdleRand : 50);
		this.idleDuration = ((data.AIIdleDuration != 0) ? data.AIIdleDuration : GlobalLogic.VALUE_1000);
		this.escapeRand = ((data.AIEscapeRand != 0) ? data.AIEscapeRand : GlobalLogic.VALUE_50);
		this.walkBackRange = ((data.AIWalkBackRange != 0) ? data.AIWalkBackRange : Global.Settings.aiWAlkBackRange);
		this.wanderRange = ((data.AIWanderRange != 0) ? data.AIWanderRange : Global.Settings.aiWanderRange);
		this.wanderRand = ((data.AIWanderRand != 0) ? data.AIWanderRand : GlobalLogic.VALUE_50);
		this.yFirstRand = ((data.AIYFirstRand != 0) ? data.AIYFirstRand : GlobalLogic.VALUE_50);
		this.owner.walkSpeed = new VInt3(Global.Settings.monsterWalkSpeed) * ((float)data.WalkSpeed / (float)GlobalLogic.VALUE_100);
		this.owner.runSpeed = new VInt3(Global.Settings.monsterRunSpeed) * ((float)data.WalkSpeed / (float)GlobalLogic.VALUE_100);
		int num = (data.AICombatType != 1) ? Global.Settings.aiMaxWalkCmdCount : Global.Settings.aiMaxWalkCmdCount_RANGED;
		this.maxIdleCount = ((data.AIMaxIdleCmdCount != 0) ? data.AIMaxIdleCmdCount : Global.Settings.aiMaxIdleCmdcount);
		this.maxWalkCount = ((data.AIMaxWalkCmdCount != 0) ? data.AIMaxWalkCmdCount : num);
		if (this.reduceSpeed)
		{
			BeActor beActor = this.owner;
			beActor.walkSpeed.x = beActor.walkSpeed.x / GlobalLogic.VALUE_2;
			BeActor beActor2 = this.owner;
			beActor2.walkSpeed.y = beActor2.walkSpeed.y / GlobalLogic.VALUE_2;
			BeActor beActor3 = this.owner;
			beActor3.runSpeed.x = beActor3.runSpeed.x / GlobalLogic.VALUE_2;
			BeActor beActor4 = this.owner;
			beActor4.runSpeed.y = beActor4.runSpeed.y / GlobalLogic.VALUE_2;
		}
		this.sight = IntMath.Float2Int((float)this.sight * Global.Settings.monsterSightFactor);
		if (this.owner.GetEntityData() != null)
		{
			this.owner.GetEntityData().walkAnimationSpeedPercent = data.WalkAnimationSpeedPerent;
		}
		this.InitAgents(data.AIActionPath, data.AIDestinationSelectPath, data.AIEventPath, null);
		if (this.actionAgent != null)
		{
			this.actionAgent.SetWarAlike(this.warlike);
		}
	}

	// Token: 0x06016B18 RID: 92952 RVA: 0x006E1AB0 File Offset: 0x006DFEB0
	public void InitAgents(string action, string destination, string strEvent, string action2 = null)
	{
		if (Utility.IsStringValid(action))
		{
			this.actionAgent = this.InitAgent(action);
		}
		if (Utility.IsStringValid(action2))
		{
			this.actionAgent2 = this.InitAgent(action2);
		}
		if (Utility.IsStringValid(destination))
		{
			this.destinationSelectAgent = this.InitAgent(destination);
		}
		if (Utility.IsStringValid(strEvent))
		{
			this.eventAgent = this.InitAgent(strEvent);
		}
	}

	// Token: 0x06016B19 RID: 92953 RVA: 0x006E1B20 File Offset: 0x006DFF20
	public BTAgent InitAgent(string treeName)
	{
		BTAgent btagent = new BTAgent();
		bool flag = btagent.Init(treeName);
		if (flag)
		{
			btagent.SetEntity(this.owner);
			return btagent;
		}
		return null;
	}

	// Token: 0x06016B1A RID: 92954 RVA: 0x006E1B52 File Offset: 0x006DFF52
	public void DeinitAgent(ref BTAgent agent)
	{
		if (agent != null)
		{
			agent.SetEntity(null);
			agent.UnLoad();
			agent = null;
		}
	}

	// Token: 0x06016B1B RID: 92955 RVA: 0x006E1B6D File Offset: 0x006DFF6D
	public void UpdateAgent(BTAgent agent)
	{
		if (agent != null)
		{
			agent.Tick();
		}
	}

	// Token: 0x06016B1C RID: 92956 RVA: 0x006E1B7C File Offset: 0x006DFF7C
	public void LoadAttackInfo(IList<string> strInfos = null)
	{
		if (this.attackInfoLoaded)
		{
			return;
		}
		this.attackInfoLoaded = true;
		for (int i = 0; i < strInfos.Count; i++)
		{
			BeAIManager.AttackInfo attackInfo = new BeAIManager.AttackInfo(strInfos[i]);
			if (this.owner.HasSkill(attackInfo.skillID))
			{
				this.attackInfos.Add(attackInfo);
			}
		}
		this.ReorderAttackInfo();
		for (int j = 0; j < this.attackInfos.Count; j++)
		{
		}
	}

	// Token: 0x06016B1D RID: 92957 RVA: 0x006E1C04 File Offset: 0x006E0004
	public void ReorderAttackInfo()
	{
		this.attackInfos.Sort(delegate(BeAIManager.AttackInfo a, BeAIManager.AttackInfo b)
		{
			if (a.front.i == b.front.i)
			{
				return (a.skillID >= b.skillID) ? 1 : -1;
			}
			return (a.front.i >= b.front.i) ? 1 : -1;
		});
	}

	// Token: 0x06016B1E RID: 92958 RVA: 0x006E1C30 File Offset: 0x006E0030
	public void AddAttackProb(int prob)
	{
		for (int i = 0; i < this.attackInfos.Count; i++)
		{
			this.attackInfos[i].prob += prob;
		}
	}

	// Token: 0x06016B1F RID: 92959 RVA: 0x006E1C74 File Offset: 0x006E0074
	public virtual void Start()
	{
		this.state = BeAIManager.State.RUNNING;
		this.idleRand += this.FrameRandom.InRange(-GlobalLogic.VALUE_5, GlobalLogic.VALUE_5);
		this.escapeRand += this.FrameRandom.InRange(-GlobalLogic.VALUE_5, GlobalLogic.VALUE_5);
		this.wanderRand += this.FrameRandom.InRange(-GlobalLogic.VALUE_5, GlobalLogic.VALUE_5);
		this.owner.TriggerEvent(BeEventType.onAIStart, null);
	}

	// Token: 0x06016B20 RID: 92960 RVA: 0x006E1D02 File Offset: 0x006E0102
	public bool IsRunning()
	{
		return this.state == BeAIManager.State.RUNNING;
	}

	// Token: 0x06016B21 RID: 92961 RVA: 0x006E1D0D File Offset: 0x006E010D
	public void Stop()
	{
		if (this.state == BeAIManager.State.STOP)
		{
			return;
		}
		this.DoNothing();
		this.state = BeAIManager.State.STOP;
	}

	// Token: 0x06016B22 RID: 92962 RVA: 0x006E1D2C File Offset: 0x006E012C
	public void Remove()
	{
		if (this.state != BeAIManager.State.STOP)
		{
			this.Stop();
		}
		this.DeinitAgent(ref this.actionAgent);
		this.DeinitAgent(ref this.actionAgent2);
		this.DeinitAgent(ref this.eventAgent);
		this.DeinitAgent(ref this.destinationSelectAgent);
		this.owner = null;
		this.aiTarget = null;
		this.followTarget = null;
	}

	// Token: 0x06016B23 RID: 92963 RVA: 0x006E1D90 File Offset: 0x006E0190
	public virtual void Update(int deltaTime)
	{
	}

	// Token: 0x06016B24 RID: 92964 RVA: 0x006E1D92 File Offset: 0x006E0192
	public virtual void PostUpdate(int deltaTime)
	{
	}

	// Token: 0x06016B25 RID: 92965 RVA: 0x006E1D94 File Offset: 0x006E0194
	protected void UpdateTimer(int deltaTime)
	{
		for (int i = 0; i < this.timerArr.Length; i++)
		{
			if (this.timerFlagArr[i])
			{
				this.timerArr[i] += deltaTime;
			}
		}
	}

	// Token: 0x06016B26 RID: 92966 RVA: 0x006E1DE0 File Offset: 0x006E01E0
	public void ExecuteCommand(BeAICommand command)
	{
		if (this.currentCmd != null && this.currentCommand.IsAlive() && !this.currentCmd.IsCanClose())
		{
			return;
		}
		this.StopCurrentCommand();
		if (this.state == BeAIManager.State.RUNNING)
		{
			this.currentCommand = command;
			this.currentCommand.Execute();
			if (this.currentCommand != null)
			{
				this.owner.TriggerEvent(BeEventType.onExecuteAICmd, new object[]
				{
					this.currentCommand.cmdType
				});
			}
			this.lastCommand = this.currentCommand;
		}
		else
		{
			Logger.LogErrorFormat("ExecuteCommand error! manager state is {0}", new object[]
			{
				this.state.ToString()
			});
		}
	}

	// Token: 0x06016B27 RID: 92967 RVA: 0x006E1EA6 File Offset: 0x006E02A6
	public void StopCurrentCommand()
	{
		if (this.currentCommand != null && this.currentCommand.IsAlive())
		{
			this.currentCommand.End();
			this.currentCommand = null;
		}
	}

	// Token: 0x06016B28 RID: 92968 RVA: 0x006E1ED5 File Offset: 0x006E02D5
	public void ClrCurrentCommand()
	{
		this.currentCommand = null;
	}

	// Token: 0x06016B29 RID: 92969 RVA: 0x006E1EDE File Offset: 0x006E02DE
	public virtual void SetForceFollow(bool flag)
	{
	}

	// Token: 0x06016B2A RID: 92970 RVA: 0x006E1EE0 File Offset: 0x006E02E0
	public void SetTarget(BeActor target, bool targetUnchange = false)
	{
		this.aiTarget = target;
		this.targetUnchange = targetUnchange;
	}

	// Token: 0x06016B2B RID: 92971 RVA: 0x006E1EF0 File Offset: 0x006E02F0
	public void FindTarget(float radius)
	{
		if (this.aiTarget == null || (this.aiTarget != null && this.aiTarget.IsDead()))
		{
			this.aiTarget = this.owner.CurrentBeScene.FindTarget(this.owner, (VInt)radius);
		}
	}

	// Token: 0x06016B2C RID: 92972 RVA: 0x006E1F48 File Offset: 0x006E0348
	public void DoNothing()
	{
		if (this.currentCommand != null && this.currentCommand.cmdType != AI_COMMAND.NONE)
		{
			BeAICommand aicommand = this.BeAICommandPool.GetAICommand(AI_COMMAND.NONE, this.owner);
			this.ExecuteCommand(aicommand);
		}
	}

	// Token: 0x06016B2D RID: 92973 RVA: 0x006E1F8B File Offset: 0x006E038B
	public bool CheckDistanceWithX(BeActor target, VInt distance)
	{
		return this.CheckDistance(target, distance, 1);
	}

	// Token: 0x06016B2E RID: 92974 RVA: 0x006E1F98 File Offset: 0x006E0398
	public bool CheckDistance(BeActor target, VInt distance, int mode = 0)
	{
		VInt3 position = target.GetPosition();
		return this.CheckDistance(position, distance, mode);
	}

	// Token: 0x06016B2F RID: 92975 RVA: 0x006E1FB8 File Offset: 0x006E03B8
	public bool CheckDistance(VInt3 targetPos, VInt distance, int mode = 0)
	{
		VInt3 position = this.owner.GetPosition();
		bool flag = Mathf.Abs(targetPos.x - position.x) <= distance;
		bool flag2 = Mathf.Abs(targetPos.y - position.y) <= distance;
		if (mode == 1)
		{
			return flag;
		}
		if (mode == 2)
		{
			return flag2;
		}
		return flag && flag2;
	}

	// Token: 0x06016B30 RID: 92976 RVA: 0x006E2030 File Offset: 0x006E0430
	public VInt2 GetDistance()
	{
		VInt3 position = this.owner.GetPosition();
		VInt3 position2 = this.aiTarget.GetPosition();
		return new VInt2(Mathf.Abs(position.x - position2.x), Mathf.Abs(position.y - position2.y));
	}

	// Token: 0x06016B31 RID: 92977 RVA: 0x006E2082 File Offset: 0x006E0482
	public VInt3 GetTargetPosition()
	{
		return this.aiTarget.GetPosition();
	}

	// Token: 0x06016B32 RID: 92978 RVA: 0x006E208F File Offset: 0x006E048F
	public BeAIManager.AIMode GetAIMode()
	{
		return this.aiMode;
	}

	// Token: 0x06016B33 RID: 92979 RVA: 0x006E2097 File Offset: 0x006E0497
	public void SetAIMode(BeAIManager.AIMode mode)
	{
		this.aiMode = mode;
	}

	// Token: 0x06016B34 RID: 92980 RVA: 0x006E20A0 File Offset: 0x006E04A0
	public virtual void ResetThinkTarget()
	{
	}

	// Token: 0x06016B35 RID: 92981 RVA: 0x006E20A2 File Offset: 0x006E04A2
	public virtual void ResetAction()
	{
	}

	// Token: 0x06016B36 RID: 92982 RVA: 0x006E20A4 File Offset: 0x006E04A4
	public virtual void ResetDestinationSelect()
	{
	}

	// Token: 0x06016B37 RID: 92983 RVA: 0x006E20A8 File Offset: 0x006E04A8
	public bool CanWalk(BeAIManager.MoveDir dir)
	{
		if (dir == BeAIManager.MoveDir.DOWN)
		{
			return this.owner.CanMoveNext(false, false);
		}
		if (dir == BeAIManager.MoveDir.TOP)
		{
			return this.owner.CanMoveNext(false, true);
		}
		if (dir == BeAIManager.MoveDir.LEFT)
		{
			return this.owner.CanMoveNext(true, false);
		}
		return dir == BeAIManager.MoveDir.RIGHT && this.owner.CanMoveNext(true, true);
	}

	// Token: 0x06016B38 RID: 92984 RVA: 0x006E2109 File Offset: 0x006E0509
	public BeAIManager.MoveDir GetOppositeDir(BeAIManager.MoveDir dir)
	{
		return this.oppositeDir[(int)dir];
	}

	// Token: 0x06016B39 RID: 92985 RVA: 0x006E2114 File Offset: 0x006E0514
	private BeAIManager._Point GetNode()
	{
		BeAIManager._Point result;
		if (this.pointPool.Count > 0)
		{
			result = this.pointPool.Dequeue();
		}
		else
		{
			result = new BeAIManager._Point();
		}
		return result;
	}

	// Token: 0x06016B3A RID: 92986 RVA: 0x006E214C File Offset: 0x006E054C
	private void recycleNode(BeAIManager._Point node)
	{
		this.pointPool.Enqueue(node);
	}

	// Token: 0x06016B3B RID: 92987 RVA: 0x006E215C File Offset: 0x006E055C
	public bool DoPathFinding(DGrid start, DGrid end, List<int> steps)
	{
		byte[] mBlockInfo = this.owner.CurrentBeScene.mBlockInfo;
		int logicWidth = this.owner.CurrentBeScene.logicWidth;
		int logicHeight = this.owner.CurrentBeScene.logicHeight;
		int value_ = GlobalLogic.VALUE_100000;
		if (start.x == end.x && start.y == end.y)
		{
			steps.Clear();
			return true;
		}
		if (SwitchFunctionUtility.IsOpen(21))
		{
			start.x = Mathf.Clamp(start.x, 0, logicWidth - 1);
			start.y = Mathf.Clamp(start.y, 0, logicHeight - 1);
			end.x = Mathf.Clamp(end.x, 0, logicWidth - 1);
			end.y = Mathf.Clamp(end.y, 0, logicHeight - 1);
			if (this.owner.CurrentBeScene.IsInBlockPlayer(start) || this.owner.CurrentBeScene.IsInBlockPlayer(end))
			{
				return false;
			}
			PathHelper._start.Set(start.x, start.y);
			PathHelper._end.Set(end.x, end.y);
			return PathHelper._astar.Do(mBlockInfo, logicWidth, logicHeight, PathHelper._start, PathHelper._end, steps);
		}
		else
		{
			if (this.mq.Count > 0)
			{
				for (int i = 0; i < this.mq.Count; i++)
				{
					this.recycleNode(this.mq[i]);
				}
			}
			this.mq.Clear();
			DGrid dgrid = start;
			DGrid dgrid2 = end;
			start.x = Mathf.Clamp(dgrid.y, 0, logicHeight - 1);
			start.y = Mathf.Clamp(dgrid.x, 0, logicWidth - 1);
			end.x = Mathf.Clamp(dgrid2.y, 0, logicHeight - 1);
			end.y = Mathf.Clamp(dgrid2.x, 0, logicWidth - 1);
			for (int j = 0; j < logicHeight; j++)
			{
				for (int k = 0; k < logicWidth; k++)
				{
					BeAIManager.dp[j, k] = value_;
				}
			}
			for (int l = 0; l < logicHeight; l++)
			{
				for (int m = 0; m < logicWidth; m++)
				{
					BeAIManager.dp2[l, m] = value_;
				}
			}
			BeAIManager._Point node = this.GetNode();
			BeAIManager._Point point = this.GetNode();
			node.x = start.x;
			node.y = start.y;
			BeAIManager.dp[node.x, node.y] = 0;
			point.x = end.x;
			point.y = end.y;
			node.cnt = 0;
			this.mq.Add(node);
			bool flag = false;
			while (this.mq.Count > 0)
			{
				BeAIManager._Point point2 = this.mq[0];
				this.mq.RemoveAt(0);
				this.recycleNode(point2);
				if (point2.x == point.x && point2.y == point.y)
				{
					point = point2;
					flag = true;
					break;
				}
				for (int n = 0; n < 8; n++)
				{
					int num = point2.x + BeAIManager.DIR_VALUE[n, 0];
					int num2 = point2.y + BeAIManager.DIR_VALUE[n, 1];
					if (num >= 0 && num < logicHeight && num2 >= 0 && num2 < logicWidth && mBlockInfo[num * logicWidth + num2] == 0 && BeAIManager.dp[point2.x, point2.y] + 1 < BeAIManager.dp[num, num2])
					{
						BeAIManager.dp[num, num2] = BeAIManager.dp[point2.x, point2.y] + 1;
						BeAIManager.dp2[num, num2] = n;
						BeAIManager._Point node2 = this.GetNode();
						node2.x = num;
						node2.y = num2;
						node2.cnt = point2.cnt + 1;
						this.mq.Add(node2);
					}
				}
			}
			if (flag)
			{
				steps.Clear();
				int num3 = BeAIManager.dp2[point.x, point.y];
				int num4 = point.x;
				int num5 = point.y;
				int num6 = point.cnt - 1;
				while (num3 >= 0 && num3 < value_)
				{
					num4 -= BeAIManager.DIR_VALUE[num3, 0];
					num5 -= BeAIManager.DIR_VALUE[num3, 1];
					if (num3 == 2)
					{
						num3 = 3;
					}
					else if (num3 == 3)
					{
						num3 = 2;
					}
					else if (num3 == 4)
					{
						num3 = 6;
					}
					else if (num3 == 5)
					{
						num3 = 7;
					}
					else if (num3 == 6)
					{
						num3 = 4;
					}
					else if (num3 == 7)
					{
						num3 = 5;
					}
					steps.Insert(0, num3);
					if (num4 == start.x && num5 == start.y)
					{
						return true;
					}
					num3 = BeAIManager.dp2[num4, num5];
				}
				return true;
			}
			return false;
		}
	}

	// Token: 0x06016B3C RID: 92988 RVA: 0x006E26DC File Offset: 0x006E0ADC
	public void DoWalk(BeAIManager.MoveDir dir, bool reset = false)
	{
		if (reset)
		{
			this.owner.ResetMoveCmd();
		}
		switch (dir)
		{
		case BeAIManager.MoveDir.RIGHT:
			this.owner.ModifyMoveCmd(0, true);
			break;
		case BeAIManager.MoveDir.LEFT:
			this.owner.ModifyMoveCmd(1, true);
			break;
		case BeAIManager.MoveDir.TOP:
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeAIManager.MoveDir.DOWN:
			this.owner.ModifyMoveCmd(3, true);
			break;
		case BeAIManager.MoveDir.RIGHT_TOP:
			this.owner.ModifyMoveCmd(0, true);
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeAIManager.MoveDir.LEFT_TOP:
			this.owner.ModifyMoveCmd(1, true);
			this.owner.ModifyMoveCmd(2, true);
			break;
		case BeAIManager.MoveDir.RIGHT_DOWN:
			this.owner.ModifyMoveCmd(0, true);
			this.owner.ModifyMoveCmd(3, true);
			break;
		case BeAIManager.MoveDir.LEFT_DOWN:
			this.owner.ModifyMoveCmd(1, true);
			this.owner.ModifyMoveCmd(3, true);
			break;
		}
	}

	// Token: 0x06016B3D RID: 92989 RVA: 0x006E27EC File Offset: 0x006E0BEC
	public void DoWalk(VInt3 targetPos)
	{
		VInt3 position = this.owner.GetPosition();
		this.owner.ResetMoveCmd();
		int num = Mathf.Abs(targetPos.x - position.x);
		int num2 = Mathf.Abs(targetPos.y - position.y);
		BeAIManager.MoveDir moveDir = BeAIManager.MoveDir.COUNT;
		bool flag = false;
		if (targetPos.x > position.x)
		{
			moveDir = BeAIManager.MoveDir.RIGHT;
		}
		else if (targetPos.x < position.x)
		{
			moveDir = BeAIManager.MoveDir.LEFT;
		}
		if (this.CanWalk(moveDir))
		{
			flag = true;
			this.DoWalk(moveDir, false);
		}
		if (targetPos.y > position.y)
		{
			moveDir = BeAIManager.MoveDir.TOP;
		}
		else if (targetPos.y < position.y)
		{
			moveDir = BeAIManager.MoveDir.DOWN;
		}
		if (this.CanWalk(moveDir))
		{
			flag = true;
			this.DoWalk(moveDir, false);
		}
		BeAIManager.MoveDir moveDir2 = moveDir;
		if (!flag)
		{
			for (moveDir = (BeAIManager.MoveDir)this.FrameRandom.InRange(0, 4); moveDir == moveDir2; moveDir = (BeAIManager.MoveDir)this.FrameRandom.InRange(0, 4))
			{
			}
		}
		this.DoWalk(moveDir, false);
	}

	// Token: 0x06016B3E RID: 92990 RVA: 0x006E2908 File Offset: 0x006E0D08
	public VInt3 GetWalkBackPostion()
	{
		VInt3 position = this.owner.GetPosition();
		VInt3 position2 = this.owner.GetPosition();
		VInt vint = (int)((long)this.FrameRandom.InRange(0, this.walkBackRange) * 10000L);
		VInt vint2 = (int)((long)this.FrameRandom.InRange(0, this.walkBackRange) * 10000L);
		vint2 = ((this.FrameRandom.InRange(1, GlobalLogic.VALUE_100) <= GlobalLogic.VALUE_50) ? (-vint2) : vint2);
		position2.x += ((!this.owner.GetFace()) ? -1 : 1) * vint.i;
		if ((int)this.FrameRandom.Range100() > GlobalLogic.VALUE_50)
		{
			position2.y += vint2.i;
		}
		return position2;
	}

	// Token: 0x06016B3F RID: 92991 RVA: 0x006E29F0 File Offset: 0x006E0DF0
	public VInt3 GetWanderPosition()
	{
		VInt3 position = this.owner.GetPosition();
		VInt3 position2 = this.owner.GetPosition();
		int roundInt = VFactor.NewVFactor(this.owner.CurrentBeScene.logicXSize.y - this.owner.CurrentBeScene.logicXSize.x, 4).roundInt;
		VInt3 sceneCenterPosition = this.owner.CurrentBeScene.GetSceneCenterPosition();
		int num = 0;
		if (position.x < sceneCenterPosition.x - roundInt)
		{
			num = 1;
		}
		else if (position.x > sceneCenterPosition.x + roundInt)
		{
			num = -1;
		}
		int num2 = (int)((long)this.FrameRandom.InRange(-this.wanderRange + num, this.wanderRange + 1 + num) * 10000L);
		int num3 = (int)((long)this.FrameRandom.InRange(-this.wanderRange, this.wanderRange + 1) * 10000L);
		position2.x += num2;
		position2.y += num3;
		return position2;
	}

	// Token: 0x06016B40 RID: 92992 RVA: 0x006E2B0C File Offset: 0x006E0F0C
	public VInt3 GetPkRobotWanderPos()
	{
		VInt3 position = this.owner.GetPosition();
		VInt3 vint = VInt3.zero;
		if (this.aiTarget != null)
		{
			vint = this.aiTarget.GetPosition();
		}
		int num = 3 * VInt.one.i;
		VInt3 vint2 = vint;
		VInt3 vint3 = vint;
		VInt3 vint4 = vint;
		VInt3 vint5 = vint;
		vint2.x += num;
		vint2.y += num;
		vint3.x += num;
		vint3.y -= num;
		vint4.x -= num;
		vint4.y += num;
		vint5.x -= num;
		vint5.y -= num;
		VInt b = (position - vint2).magnitude;
		VInt3 vint6 = vint2;
		if ((position - vint3).magnitude < b)
		{
			b = (position - vint3).magnitude;
			vint6 = vint3;
		}
		if ((position - vint4).magnitude < b)
		{
			b = (position - vint4).magnitude;
			vint6 = vint4;
		}
		if ((position - vint5).magnitude < b)
		{
			b = (position - vint5).magnitude;
			vint6 = vint5;
		}
		if ((position - vint6).magnitude <= VInt.one.i)
		{
			int i = VInt.one.i;
			int num2 = this.FrameRandom.InRange(-i, i);
			int num3 = this.FrameRandom.InRange(-i, i);
			vint6.x += num2;
			vint6.y += num3;
		}
		return vint6;
	}

	// Token: 0x06016B41 RID: 92993 RVA: 0x006E2D28 File Offset: 0x006E1128
	public static VInt3 FindStandPosition(VInt3 pos, BeScene scene, bool faceLeft = false, bool noOtherEntity = false, int tryStep = 12)
	{
		if (scene == null)
		{
			return pos;
		}
		DGrid dgrid = scene.CalGridByPosition(pos);
		byte[] mBlockInfo = scene.mBlockInfo;
		int logicWidth = scene.logicWidth;
		int logicHeight = scene.logicHeight;
		BeAIManager.MoveDir moveDir = (!faceLeft) ? BeAIManager.MoveDir.RIGHT : BeAIManager.MoveDir.LEFT;
		BeAIManager.MoveDir moveDir2 = moveDir;
		DGrid grid = dgrid;
		int num = 0;
		int num2;
		int num3;
		for (;;)
		{
			num2 = dgrid.x + BeAIManager.DIR_VALUE2[(int)moveDir, 0] * num;
			num3 = dgrid.y + BeAIManager.DIR_VALUE2[(int)moveDir, 1] * num;
			num++;
			if (num2 >= 0 && num2 < logicWidth && num3 >= 0 && num3 < logicHeight && mBlockInfo[num3 * logicWidth + num2] == 0 && (!noOtherEntity || BeAIManager.HasOtherEntityInPosition(scene.CalPositionByGrid(new DGrid(num2, num3)), scene)))
			{
				break;
			}
			if (num2 < 0 || num2 >= logicWidth || num3 < 0 || num3 >= logicHeight || num >= tryStep)
			{
				if (num >= tryStep)
				{
					return pos;
				}
				if (moveDir == moveDir2)
				{
					moveDir = ((moveDir2 != BeAIManager.MoveDir.RIGHT) ? BeAIManager.MoveDir.RIGHT : BeAIManager.MoveDir.LEFT);
				}
				else
				{
					int num4 = (int)moveDir;
					num4 += 2;
					num4 %= 8;
					moveDir = (BeAIManager.MoveDir)num4;
					if (moveDir == moveDir2)
					{
						return pos;
					}
				}
			}
		}
		grid = new DGrid(num2, num3);
		return scene.CalPositionByGrid(grid);
	}

	// Token: 0x06016B42 RID: 92994 RVA: 0x006E2E94 File Offset: 0x006E1294
	public static VInt3 FindStandPositionNew(VInt3 pos, BeScene scene, bool faceLeft = false, bool noOtherEntity = false, int tryStep = 12)
	{
		if (scene == null)
		{
			return pos;
		}
		DGrid dgrid = scene.CalGridByPosition(pos);
		byte[] mBlockInfo = scene.mBlockInfo;
		int logicWidth = scene.logicWidth;
		int logicHeight = scene.logicHeight;
		BeAIManager.MoveDir moveDir = (!faceLeft) ? BeAIManager.MoveDir.RIGHT : BeAIManager.MoveDir.LEFT;
		BeAIManager.MoveDir moveDir2 = moveDir;
		DGrid grid = dgrid;
		int num = 0;
		int num2;
		int num3;
		for (;;)
		{
			num2 = dgrid.x + BeAIManager.DIR_VALUE2[(int)moveDir, 0] * num;
			num3 = dgrid.y + BeAIManager.DIR_VALUE2[(int)moveDir, 1] * num;
			if (num2 >= 0 && num2 < logicWidth && num3 >= 0 && num3 < logicHeight && mBlockInfo[num3 * logicWidth + num2] == 0 && (!noOtherEntity || BeAIManager.HasOtherEntityInPosition(scene.CalPositionByGrid(new DGrid(num2, num3)), scene)))
			{
				break;
			}
			int num4 = (int)moveDir;
			num4++;
			num4 %= 8;
			moveDir = (BeAIManager.MoveDir)num4;
			if (moveDir == moveDir2)
			{
				num++;
			}
			if (num > tryStep)
			{
				return pos;
			}
		}
		grid = new DGrid(num2, num3);
		return scene.CalPositionByGrid(grid);
	}

	// Token: 0x06016B43 RID: 92995 RVA: 0x006E2FB4 File Offset: 0x006E13B4
	public VInt3 GetPosAroundDoor(BeScene scene, VInt3 pos, VInt r)
	{
		DGrid dgrid = scene.CalGridByPosition(pos);
		byte[] mBlockInfo = scene.mBlockInfo;
		int logicWidth = scene.logicWidth;
		int logicHeight = scene.logicHeight;
		VInt2 logicGrild = scene.logicGrild;
		VInt3 vint = VInt3.zero;
		int num = r.i / logicGrild.x + 1;
		int num2 = BeAIManager.DIR_VALUE2.Length / 2;
		for (int i = 0; i < num2; i++)
		{
			int num3 = dgrid.x + BeAIManager.DIR_VALUE2[i, 0] * num;
			int num4 = dgrid.y + BeAIManager.DIR_VALUE2[i, 1] * num;
			if (num3 >= 0 && num3 < logicWidth && num4 >= 0 && num4 < logicHeight)
			{
				if (mBlockInfo[num4 * logicWidth + num3] == 0)
				{
					vint = scene.CalPositionByGrid(new DGrid(num3, num4));
					if (!scene.IsInBlockPlayer(vint))
					{
						return vint;
					}
				}
			}
		}
		int num5 = 3;
		int num6 = this.FrameRandom.InRange(-num5, num5) * 10000;
		int num7 = this.FrameRandom.InRange(-num5, num5) * 10000;
		pos.x += num6;
		pos.y += num7;
		return pos;
	}

	// Token: 0x06016B44 RID: 92996 RVA: 0x006E310C File Offset: 0x006E150C
	public VInt3 GetRandomPos(VInt3 pos, VInt r)
	{
		int num = this.FrameRandom.InRange(-r.i, r.i);
		int num2 = this.FrameRandom.InRange(-r.i, r.i);
		pos.x += num;
		pos.y += num2;
		return pos;
	}

	// Token: 0x06016B45 RID: 92997 RVA: 0x006E3170 File Offset: 0x006E1570
	public static bool HasOtherEntityInPosition(VInt3 pos, BeScene scene)
	{
		List<BeEntity> entities = scene.GetEntities();
		for (int i = 0; i < entities.Count; i++)
		{
			BeActor beActor = entities[i] as BeActor;
			if (beActor != null)
			{
				VInt3 position = beActor.GetPosition();
				if ((pos - position).magnitude <= VInt.Float2VIntValue(0.9f))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06016B46 RID: 92998 RVA: 0x006E31D8 File Offset: 0x006E15D8
	public int NumberOfInAttackArea(int front, int back, int top, int down)
	{
		BeAIManager.AttackInfo attackInfo = new BeAIManager.AttackInfo(front, back, top, down, 0, 100);
		List<BeActor> list = ListPool<BeActor>.Get();
		this.owner.CurrentBeScene.FindTargets(list, this.owner, (VInt)((float)GlobalLogic.VALUE_1000), false, null);
		int num = 0;
		for (int i = 0; i < list.Count; i++)
		{
			if (attackInfo.IsPointInRange(this.owner.GetPosition2(), list[i].GetPosition2(), this.owner.GetFace()))
			{
				num++;
			}
		}
		ListPool<BeActor>.Release(list);
		return num;
	}

	// Token: 0x06016B47 RID: 92999 RVA: 0x006E3270 File Offset: 0x006E1670
	public int MonsterInArea(int front, int back, int top, int down, int[] monsterIDs, bool isEnemey = true)
	{
		if (monsterIDs == null || monsterIDs.Length <= 0)
		{
			monsterIDs = new int[1];
		}
		BeAIManager.AttackInfo attackInfo = new BeAIManager.AttackInfo(front, back, top, down, 0, 100);
		int num = 0;
		for (int i = 0; i < monsterIDs.Length; i++)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			this.owner.CurrentBeScene.FindMonsterByID(list, monsterIDs[i], isEnemey);
			for (int j = 0; j < list.Count; j++)
			{
				if (attackInfo.IsPointInRange(this.owner.GetPosition2(), list[j].GetPosition2(), this.owner.GetFace()))
				{
					num++;
				}
			}
			ListPool<BeActor>.Release(list);
		}
		return num;
	}

	// Token: 0x06016B48 RID: 93000 RVA: 0x006E3330 File Offset: 0x006E1730
	public bool IsTargetInAttackArea(int front, int back, int top, int down)
	{
		if (this.aiTarget == null)
		{
			return false;
		}
		BeAIManager.AttackInfo attackInfo = new BeAIManager.AttackInfo(front, back, top, down, 0, 100);
		return attackInfo.IsPointInRange(this.owner.GetPosition2(), this.aiTarget.GetPosition2(), this.owner.GetFace());
	}

	// Token: 0x06016B49 RID: 93001 RVA: 0x006E3380 File Offset: 0x006E1780
	public bool IsTargetInConcentricCircles(int front0, int back0, int top0, int down0, int front1, int back1, int top1, int down1)
	{
		if (this.aiTarget == null)
		{
			return false;
		}
		BeAIManager.AttackInfo attackInfo = new BeAIManager.AttackInfo(front0, back0, top0, down0, 0, 100);
		BeAIManager.AttackInfo attackInfo2 = new BeAIManager.AttackInfo(front1, back1, top1, down1, 0, 100);
		return !attackInfo.IsPointInRange(this.owner.GetPosition2(), this.aiTarget.GetPosition2(), this.owner.GetFace()) && attackInfo2.IsPointInRange(this.owner.GetPosition2(), this.aiTarget.GetPosition2(), this.owner.GetFace());
	}

	// Token: 0x06016B4A RID: 93002 RVA: 0x006E340E File Offset: 0x006E180E
	public bool CanUseSkill(int skillID)
	{
		return this.owner.CanUseSkill(skillID);
	}

	// Token: 0x06016B4B RID: 93003 RVA: 0x006E341C File Offset: 0x006E181C
	public bool CanCost(int skillId)
	{
		BeSkill skill = this.owner.GetSkill(skillId);
		return skill == null || skill.GetCrystalCost() <= 0 || this.owner.canUseCrystalSkill;
	}

	// Token: 0x06016B4C RID: 93004 RVA: 0x006E345F File Offset: 0x006E185F
	public bool IsSkillInCooltime(int skillID)
	{
		return !this.owner.CanUseSkill(skillID);
	}

	// Token: 0x06016B4D RID: 93005 RVA: 0x006E3470 File Offset: 0x006E1870
	public int EnemyNumberOfInAttackArea(int front, int back, int top, int down)
	{
		return this.NumberOfInAttackArea(front, back, top, down);
	}

	// Token: 0x06016B4E RID: 93006 RVA: 0x006E347D File Offset: 0x006E187D
	public bool CheckUseSkill(int skillID)
	{
		return this.owner.IsCastingSkill() && this.owner.GetCurSkillID() == skillID;
	}

	// Token: 0x06016B4F RID: 93007 RVA: 0x006E34A0 File Offset: 0x006E18A0
	public bool CheckState(BeActor actor, ActionState state)
	{
		return actor.sgGetCurrentState() == (int)state;
	}

	// Token: 0x06016B50 RID: 93008 RVA: 0x006E34AB File Offset: 0x006E18AB
	public void ReloadSkillInfos(UnitTable data)
	{
		this.attackInfos.Clear();
		this.attackInfoLoaded = false;
		if (data == null)
		{
			return;
		}
		if (Utility.IsStringValid(data.AIAttackKind[0]))
		{
			this.LoadAttackInfo(data.AIAttackKind);
		}
	}

	// Token: 0x06016B51 RID: 93009 RVA: 0x006E34E8 File Offset: 0x006E18E8
	public void ForceAssignAiTarget(BeActor actor)
	{
		this.assignAITarget = actor;
	}

	// Token: 0x06016B52 RID: 93010 RVA: 0x006E34F1 File Offset: 0x006E18F1
	public int GetCounter(int index)
	{
		if (index >= 5)
		{
			Logger.LogErrorFormat("计数器编号不能大于4，策划请检查AI配置", new object[0]);
			return 0;
		}
		return this.counterArr[index];
	}

	// Token: 0x06016B53 RID: 93011 RVA: 0x006E3514 File Offset: 0x006E1914
	public void SetCounter(int index, int value)
	{
		if (index >= 5)
		{
			Logger.LogErrorFormat("计数器编号不能大于4，策划请检查AI配置", new object[0]);
			return;
		}
		this.counterArr[index] = value;
	}

	// Token: 0x06016B54 RID: 93012 RVA: 0x006E3537 File Offset: 0x006E1937
	public void CounterAddUp(int index)
	{
		if (index >= 5)
		{
			Logger.LogErrorFormat("计数器编号不能大于4，策划请检查AI配置", new object[0]);
			return;
		}
		this.counterArr[index]++;
	}

	// Token: 0x040102E3 RID: 66275
	public static string LAST_RESULT = "LastResult";

	// Token: 0x040102E4 RID: 66276
	public static bool logerror = false;

	// Token: 0x040102E5 RID: 66277
	public AIInputData aiInputData;

	// Token: 0x040102E6 RID: 66278
	public int actionResult = -1;

	// Token: 0x040102E7 RID: 66279
	public int destinationSelectResult = -1;

	// Token: 0x040102E8 RID: 66280
	public int monsterID;

	// Token: 0x040102E9 RID: 66281
	public int radius;

	// Token: 0x040102EA RID: 66282
	protected BeAICommand currentCommand;

	// Token: 0x040102EB RID: 66283
	protected BeAICommand lastCommand;

	// Token: 0x040102EC RID: 66284
	public BeActor aiTarget;

	// Token: 0x040102ED RID: 66285
	public BeActor owner;

	// Token: 0x040102EE RID: 66286
	public BeActor followTarget;

	// Token: 0x040102EF RID: 66287
	public BTAgent actionAgent;

	// Token: 0x040102F0 RID: 66288
	public BTAgent destinationSelectAgent;

	// Token: 0x040102F1 RID: 66289
	public BTAgent eventAgent;

	// Token: 0x040102F2 RID: 66290
	public BTAgent actionAgent2;

	// Token: 0x040102F3 RID: 66291
	public BeAIManager.State state;

	// Token: 0x040102F4 RID: 66292
	public int sight;

	// Token: 0x040102F5 RID: 66293
	public int chaseSight;

	// Token: 0x040102F6 RID: 66294
	public BeAIManager.TargetType targetType;

	// Token: 0x040102F7 RID: 66295
	protected IEntityFilter filter;

	// Token: 0x040102F8 RID: 66296
	public int warlike;

	// Token: 0x040102F9 RID: 66297
	public VInt keepDistance;

	// Token: 0x040102FA RID: 66298
	public float followDistance;

	// Token: 0x040102FB RID: 66299
	public int overlapOffset = 15000;

	// Token: 0x040102FC RID: 66300
	public int thinkTerm = GlobalLogic.VALUE_200;

	// Token: 0x040102FD RID: 66301
	public int changeDestinationTerm = GlobalLogic.VALUE_400;

	// Token: 0x040102FE RID: 66302
	public int eventTerm = GlobalLogic.VALUE_200;

	// Token: 0x040102FF RID: 66303
	public int followTerm = GlobalLogic.VALUE_500;

	// Token: 0x04010300 RID: 66304
	public int findTargetTerm = GlobalLogic.VALUE_1000;

	// Token: 0x04010301 RID: 66305
	public int idleRand;

	// Token: 0x04010302 RID: 66306
	public int escapeRand;

	// Token: 0x04010303 RID: 66307
	public int wanderRand;

	// Token: 0x04010304 RID: 66308
	public int idleDuration;

	// Token: 0x04010305 RID: 66309
	public int wanderRange;

	// Token: 0x04010306 RID: 66310
	public int walkBackRange;

	// Token: 0x04010307 RID: 66311
	public int yFirstRand;

	// Token: 0x04010308 RID: 66312
	public static int MAX_WALK_COMMAND = int.MaxValue;

	// Token: 0x04010309 RID: 66313
	public static int MAX_IDLE_COMMAND = int.MaxValue;

	// Token: 0x0401030A RID: 66314
	public int maxWalkCount = BeAIManager.MAX_WALK_COMMAND;

	// Token: 0x0401030B RID: 66315
	public int maxIdleCount = BeAIManager.MAX_IDLE_COMMAND;

	// Token: 0x0401030C RID: 66316
	public bool reduceSpeed;

	// Token: 0x0401030D RID: 66317
	public bool targetUnchange;

	// Token: 0x0401030E RID: 66318
	public bool forceFollow;

	// Token: 0x0401030F RID: 66319
	public BeAIManager.AIState aiState;

	// Token: 0x04010310 RID: 66320
	public BeAIManager.AIMode aiMode;

	// Token: 0x04010311 RID: 66321
	public BeAIManager.IdleMode idleMode;

	// Token: 0x04010312 RID: 66322
	public bool afterAttack;

	// Token: 0x04010313 RID: 66323
	public BeAIManager.AIType aiType = BeAIManager.AIType.RANGED;

	// Token: 0x04010314 RID: 66324
	public bool isAPC;

	// Token: 0x04010315 RID: 66325
	public bool isAutoFight;

	// Token: 0x04010316 RID: 66326
	protected int doorPosCount;

	// Token: 0x04010317 RID: 66327
	private bool attackInfoLoaded;

	// Token: 0x04010318 RID: 66328
	public bool pkRobotWander;

	// Token: 0x04010319 RID: 66329
	protected BeActor assignAITarget;

	// Token: 0x0401031A RID: 66330
	private int[] counterArr = new int[5];

	// Token: 0x0401031B RID: 66331
	private int[] timerArr = new int[5];

	// Token: 0x0401031C RID: 66332
	private bool[] timerFlagArr = new bool[5];

	// Token: 0x0401031D RID: 66333
	public List<int> steps = new List<int>();

	// Token: 0x0401031E RID: 66334
	public List<BeAIManager.AttackInfo> attackInfos = new List<BeAIManager.AttackInfo>();

	// Token: 0x0401031F RID: 66335
	private UnitTable mTableData;

	// Token: 0x04010320 RID: 66336
	public static int[,] DIR_VALUE = new int[,]
	{
		{
			0,
			1
		},
		{
			0,
			-1
		},
		{
			-1,
			0
		},
		{
			1,
			0
		},
		{
			-1,
			1
		},
		{
			-1,
			-1
		},
		{
			1,
			1
		},
		{
			1,
			1
		}
	};

	// Token: 0x04010321 RID: 66337
	public static int[,] DIR_VALUE2 = new int[,]
	{
		{
			1,
			0
		},
		{
			-1,
			0
		},
		{
			0,
			1
		},
		{
			0,
			-1
		},
		{
			1,
			1
		},
		{
			-1,
			1
		},
		{
			1,
			-1
		},
		{
			-1,
			-1
		}
	};

	// Token: 0x04010322 RID: 66338
	public static int[,] DIR_VALUE3 = new int[,]
	{
		{
			1,
			0
		},
		{
			1,
			1
		},
		{
			0,
			1
		},
		{
			-1,
			1
		},
		{
			-1,
			0
		},
		{
			-1,
			-1
		},
		{
			0,
			-1
		},
		{
			1,
			-1
		}
	};

	// Token: 0x04010323 RID: 66339
	private static int MAX_ROW = 200;

	// Token: 0x04010324 RID: 66340
	private static int MAX_COL = 200;

	// Token: 0x04010325 RID: 66341
	private BeAIManager.MoveDir[] oppositeDir = new BeAIManager.MoveDir[]
	{
		BeAIManager.MoveDir.LEFT,
		BeAIManager.MoveDir.RIGHT,
		BeAIManager.MoveDir.DOWN,
		BeAIManager.MoveDir.TOP,
		BeAIManager.MoveDir.LEFT_DOWN,
		BeAIManager.MoveDir.RIGHT_DOWN,
		BeAIManager.MoveDir.LEFT_TOP,
		BeAIManager.MoveDir.RIGHT_TOP
	};

	// Token: 0x04010326 RID: 66342
	private static int[,] dp = new int[BeAIManager.MAX_ROW, BeAIManager.MAX_COL];

	// Token: 0x04010327 RID: 66343
	private static int[,] dp2 = new int[BeAIManager.MAX_ROW, BeAIManager.MAX_COL];

	// Token: 0x04010328 RID: 66344
	private List<BeAIManager._Point> mq = new List<BeAIManager._Point>();

	// Token: 0x04010329 RID: 66345
	private Queue<BeAIManager._Point> pointPool = new Queue<BeAIManager._Point>();

	// Token: 0x0200411A RID: 16666
	public enum AutoFightMode
	{
		// Token: 0x0401032C RID: 66348
		NONE,
		// Token: 0x0401032D RID: 66349
		HALF,
		// Token: 0x0401032E RID: 66350
		ALL
	}

	// Token: 0x0200411B RID: 16667
	public enum State
	{
		// Token: 0x04010330 RID: 66352
		NONE,
		// Token: 0x04010331 RID: 66353
		READY,
		// Token: 0x04010332 RID: 66354
		RUNNING,
		// Token: 0x04010333 RID: 66355
		STOP
	}

	// Token: 0x0200411C RID: 16668
	public enum AIType
	{
		// Token: 0x04010335 RID: 66357
		MELEE,
		// Token: 0x04010336 RID: 66358
		RANGED,
		// Token: 0x04010337 RID: 66359
		NOATTACK
	}

	// Token: 0x0200411D RID: 16669
	public enum TargetType
	{
		// Token: 0x04010339 RID: 66361
		NEAREST,
		// Token: 0x0401033A RID: 66362
		LOW_LEVEL,
		// Token: 0x0401033B RID: 66363
		HIGH_LEVEL,
		// Token: 0x0401033C RID: 66364
		LOW_HP,
		// Token: 0x0401033D RID: 66365
		HIGH_HP,
		// Token: 0x0401033E RID: 66366
		ATTACKER,
		// Token: 0x0401033F RID: 66367
		DOWNED,
		// Token: 0x04010340 RID: 66368
		BOSS,
		// Token: 0x04010341 RID: 66369
		Max_Resentment
	}

	// Token: 0x0200411E RID: 16670
	public enum TargetEntityType
	{
		// Token: 0x04010343 RID: 66371
		DEFAULT,
		// Token: 0x04010344 RID: 66372
		PLAYER,
		// Token: 0x04010345 RID: 66373
		MONSTER,
		// Token: 0x04010346 RID: 66374
		SUMMON
	}

	// Token: 0x0200411F RID: 16671
	public enum AIMode
	{
		// Token: 0x04010348 RID: 66376
		NONE,
		// Token: 0x04010349 RID: 66377
		ALERT,
		// Token: 0x0401034A RID: 66378
		ATTACK,
		// Token: 0x0401034B RID: 66379
		FOLLOW
	}

	// Token: 0x02004120 RID: 16672
	public enum AIState
	{
		// Token: 0x0401034D RID: 66381
		NONE,
		// Token: 0x0401034E RID: 66382
		ATTACK,
		// Token: 0x0401034F RID: 66383
		WALK,
		// Token: 0x04010350 RID: 66384
		FOLLOW
	}

	// Token: 0x02004121 RID: 16673
	public enum DestinationType
	{
		// Token: 0x04010352 RID: 66386
		IDLE = -1,
		// Token: 0x04010353 RID: 66387
		GO_TO_TARGET,
		// Token: 0x04010354 RID: 66388
		ESCAPE,
		// Token: 0x04010355 RID: 66389
		BYPASS_TRACK,
		// Token: 0x04010356 RID: 66390
		Y_FIRST,
		// Token: 0x04010357 RID: 66391
		FOLLOW,
		// Token: 0x04010358 RID: 66392
		WANDER,
		// Token: 0x04010359 RID: 66393
		KEEP_DISTANCE,
		// Token: 0x0401035A RID: 66394
		FINAL_DOOR,
		// Token: 0x0401035B RID: 66395
		WANDER_IN_CIRCLE,
		// Token: 0x0401035C RID: 66396
		WANDER_PKROBOT,
		// Token: 0x0401035D RID: 66397
		MOVETO_LEFT_SCENEEDGE,
		// Token: 0x0401035E RID: 66398
		GO_TO_TARGET2
	}

	// Token: 0x02004122 RID: 16674
	public enum TreeType
	{
		// Token: 0x04010360 RID: 66400
		ACTION,
		// Token: 0x04010361 RID: 66401
		DESTINATION_SELECT
	}

	// Token: 0x02004123 RID: 16675
	public enum IdleMode
	{
		// Token: 0x04010363 RID: 66403
		IDLE,
		// Token: 0x04010364 RID: 66404
		WANDER
	}

	// Token: 0x02004124 RID: 16676
	public enum AIChoise
	{
		// Token: 0x04010366 RID: 66406
		NONE,
		// Token: 0x04010367 RID: 66407
		ATTACK,
		// Token: 0x04010368 RID: 66408
		CANNOT_ATTACK = -1,
		// Token: 0x04010369 RID: 66409
		CANATTACK_BUTCHOOSENOT = -2
	}

	// Token: 0x02004125 RID: 16677
	public class AttackInfo
	{
		// Token: 0x06016B57 RID: 93015 RVA: 0x006E367C File Offset: 0x006E1A7C
		public AttackInfo(int f, int b, int t, int d, int sid, int p = 100)
		{
			this.front = this.Convert(f);
			this.back = this.Convert(b);
			this.top = this.Convert(t);
			this.down = this.Convert(d);
			this.skillID = sid;
			this.prob = p;
			this.attackPassiveProb = Global.Settings.aiSkillAttackPassive;
		}

		// Token: 0x06016B58 RID: 93016 RVA: 0x006E3700 File Offset: 0x006E1B00
		public AttackInfo(string str)
		{
			string[] array = str.Split(new char[]
			{
				','
			});
			this.prob = int.Parse(array[0]);
			this.skillID = int.Parse(array[1]);
			this.front = this.Convert(int.Parse(array[2]));
			this.back = this.Convert(int.Parse(array[3]));
			this.top = this.Convert(int.Parse(array[4]));
			this.down = this.Convert(int.Parse(array[5]));
		}

		// Token: 0x06016B59 RID: 93017 RVA: 0x006E37AC File Offset: 0x006E1BAC
		private int Convert(int k)
		{
			return VFactor.NewVFactor((long)k, 1000L).vint.i;
		}

		// Token: 0x06016B5A RID: 93018 RVA: 0x006E37D8 File Offset: 0x006E1BD8
		public bool IsPointInRange(VInt2 origin, VInt2 point, bool faceLeft = false)
		{
			DBox dbox = default(DBox);
			if (faceLeft)
			{
				dbox._min.x = origin.x - this.front.i;
				dbox._min.y = origin.y - this.down.i;
				dbox._max.x = origin.x + this.back.i;
				dbox._max.y = origin.y + this.top.i;
			}
			else
			{
				dbox._min.x = origin.x - this.back.i;
				dbox._min.y = origin.y - this.down.i;
				dbox._max.x = origin.x + this.front.i;
				dbox._max.y = origin.y + this.top.i;
			}
			return dbox.containPoint(ref point);
		}

		// Token: 0x0401036A RID: 66410
		public VInt front;

		// Token: 0x0401036B RID: 66411
		public VInt back;

		// Token: 0x0401036C RID: 66412
		public VInt top;

		// Token: 0x0401036D RID: 66413
		public VInt down;

		// Token: 0x0401036E RID: 66414
		public int skillID;

		// Token: 0x0401036F RID: 66415
		public int prob;

		// Token: 0x04010370 RID: 66416
		public bool enable = true;

		// Token: 0x04010371 RID: 66417
		public int attackPassiveProb;
	}

	// Token: 0x02004126 RID: 16678
	private class _Point
	{
		// Token: 0x06016B5B RID: 93019 RVA: 0x006E38FC File Offset: 0x006E1CFC
		public _Point()
		{
			this.x = (this.y = (this.cnt = 0));
		}

		// Token: 0x04010372 RID: 66418
		public int x;

		// Token: 0x04010373 RID: 66419
		public int y;

		// Token: 0x04010374 RID: 66420
		public int cnt;
	}

	// Token: 0x02004127 RID: 16679
	public enum MoveDir
	{
		// Token: 0x04010376 RID: 66422
		RIGHT,
		// Token: 0x04010377 RID: 66423
		LEFT,
		// Token: 0x04010378 RID: 66424
		TOP,
		// Token: 0x04010379 RID: 66425
		DOWN,
		// Token: 0x0401037A RID: 66426
		RIGHT_TOP,
		// Token: 0x0401037B RID: 66427
		LEFT_TOP,
		// Token: 0x0401037C RID: 66428
		RIGHT_DOWN,
		// Token: 0x0401037D RID: 66429
		LEFT_DOWN,
		// Token: 0x0401037E RID: 66430
		COUNT
	}

	// Token: 0x02004128 RID: 16680
	public enum MoveDir2
	{
		// Token: 0x04010380 RID: 66432
		RIGHT,
		// Token: 0x04010381 RID: 66433
		RIGHT_TOP,
		// Token: 0x04010382 RID: 66434
		TOP,
		// Token: 0x04010383 RID: 66435
		LEFT_TOP,
		// Token: 0x04010384 RID: 66436
		LEFT,
		// Token: 0x04010385 RID: 66437
		LEFT_DOWN,
		// Token: 0x04010386 RID: 66438
		DOWN,
		// Token: 0x04010387 RID: 66439
		RIGHT_DOWN,
		// Token: 0x04010388 RID: 66440
		COUNT
	}
}
