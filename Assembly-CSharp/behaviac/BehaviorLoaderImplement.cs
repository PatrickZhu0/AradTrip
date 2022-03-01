using System;
using System.Collections;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020040E0 RID: 16608
	public class BehaviorLoaderImplement : BehaviorLoader
	{
		// Token: 0x06016948 RID: 92488 RVA: 0x006D5584 File Offset: 0x006D3984
		public override bool Load()
		{
			AgentMeta.TotalSignature = 1960296965U;
			AgentMeta agentMeta = new AgentMeta(24743406U);
			AgentMeta._AgentMetas_[2436498804U] = agentMeta;
			agentMeta.RegisterMethod(1045109914U, new CAgentStaticMethodVoid<string>(delegate(string param0)
			{
				Agent.LogMessage(param0);
			}));
			agentMeta.RegisterMethod(2521019022U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorAdd());
			agentMeta.RegisterMethod(2306090221U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorClear());
			agentMeta.RegisterMethod(3483755530U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorContains());
			agentMeta.RegisterMethod(505785840U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorLength());
			agentMeta.RegisterMethod(502968959U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorRemove());
			agentMeta = new AgentMeta(3394480464U);
			AgentMeta._AgentMetas_[1383043708U] = agentMeta;
			agentMeta.RegisterMemberProperty(1084314299U, new CMemberProperty<int>("bianshen", delegate(Agent self, int value)
			{
				((BTAgent)self).bianshen = value;
			}, (Agent self) => ((BTAgent)self).bianshen));
			agentMeta.RegisterMemberProperty(3409466350U, new CMemberProperty<bool>("buffRemoved", delegate(Agent self, bool value)
			{
				((BTAgent)self).buffRemoved = value;
			}, (Agent self) => ((BTAgent)self).buffRemoved));
			agentMeta.RegisterMemberProperty(2801688976U, new CMemberProperty<int>("compare", delegate(Agent self, int value)
			{
				((BTAgent)self).compare = value;
			}, (Agent self) => ((BTAgent)self).compare));
			agentMeta.RegisterMemberProperty(4111240886U, new CMemberProperty<int>("lastResult", delegate(Agent self, int value)
			{
				((BTAgent)self).lastResult = value;
			}, (Agent self) => ((BTAgent)self).lastResult));
			agentMeta.RegisterMemberProperty(914061992U, new CMemberProperty<int>("mojiankuilei", delegate(Agent self, int value)
			{
				((BTAgent)self).mojiankuilei = value;
			}, (Agent self) => ((BTAgent)self).mojiankuilei));
			agentMeta.RegisterMemberProperty(830633236U, new CMemberProperty<int>("monsterID", delegate(Agent self, int value)
			{
				((BTAgent)self).monsterID = value;
			}, (Agent self) => ((BTAgent)self).monsterID));
			agentMeta.RegisterMemberProperty(1327198659U, new CMemberProperty<int>("radius", delegate(Agent self, int value)
			{
				((BTAgent)self)._set_radius(value);
			}, (Agent self) => ((BTAgent)self)._get_radius()));
			agentMeta.RegisterMemberProperty(3672209233U, new CMemberProperty<List<int>>("regist_gameTime", delegate(Agent self, List<int> value)
			{
				((BTAgent)self)._set_regist_gameTime(value);
			}, (Agent self) => ((BTAgent)self)._get_regist_gameTime()));
			agentMeta.RegisterMemberProperty(1674696684U, new CMemberArrayItemProperty<int>("regist_gameTime[]", delegate(Agent self, int value, int index)
			{
				((BTAgent)self)._get_regist_gameTime()[index] = value;
			}, (Agent self, int index) => ((BTAgent)self)._get_regist_gameTime()[index]));
			agentMeta.RegisterMemberProperty(1838972536U, new CMemberProperty<int>("shifacishu", delegate(Agent self, int value)
			{
				((BTAgent)self).shifacishu = value;
			}, (Agent self) => ((BTAgent)self).shifacishu));
			agentMeta.RegisterMemberProperty(2903075710U, new CMemberProperty<int>("shifangjineng", delegate(Agent self, int value)
			{
				((BTAgent)self).shifangjineng = value;
			}, (Agent self) => ((BTAgent)self).shifangjineng));
			agentMeta.RegisterMemberProperty(141972075U, new CMemberProperty<int>("shifangjineng2", delegate(Agent self, int value)
			{
				((BTAgent)self).shifangjineng2 = value;
			}, (Agent self) => ((BTAgent)self).shifangjineng2));
			agentMeta.RegisterMemberProperty(292381482U, new CMemberProperty<int>("shifangjineng3", delegate(Agent self, int value)
			{
				((BTAgent)self).shifangjineng3 = value;
			}, (Agent self) => ((BTAgent)self).shifangjineng3));
			agentMeta.RegisterMemberProperty(788961159U, new CMemberProperty<int>("shouhufanshang", delegate(Agent self, int value)
			{
				((BTAgent)self).shouhufanshang = value;
			}, (Agent self) => ((BTAgent)self).shouhufanshang));
			agentMeta.RegisterMemberProperty(3792036068U, new CMemberProperty<int>("zhaohuan", delegate(Agent self, int value)
			{
				((BTAgent)self).zhaohuan = value;
			}, (Agent self) => ((BTAgent)self).zhaohuan));
			agentMeta.RegisterMemberProperty(2215575011U, new CMemberProperty<int>("zhaohuancishu", delegate(Agent self, int value)
			{
				((BTAgent)self)._set_zhaohuancishu(value);
			}, (Agent self) => ((BTAgent)self)._get_zhaohuancishu()));
			agentMeta.RegisterMemberProperty(3544135268U, new CMemberProperty<List<int>>("regist_TimeUp", delegate(Agent self, List<int> value)
			{
				((BTAgent)self)._set_regist_TimeUp(value);
			}, (Agent self) => ((BTAgent)self)._get_regist_TimeUp()));
			agentMeta.RegisterMemberProperty(967869583U, new CMemberArrayItemProperty<int>("regist_TimeUp[]", delegate(Agent self, int value, int index)
			{
				((BTAgent)self)._get_regist_TimeUp()[index] = value;
			}, (Agent self, int index) => ((BTAgent)self)._get_regist_TimeUp()[index]));
			agentMeta.RegisterMethod(2622935024U, new CAgentMethodVoid(delegate(Agent self)
			{
				((BTAgent)self).Action_ChangeFaceToTarget();
			}));
			agentMeta.RegisterMethod(1491615331U, new CAgentMethodVoid<int>(delegate(Agent self, int index)
			{
				((BTAgent)self).Action_CounterAddUp(index);
			}));
			agentMeta.RegisterMethod(3800847452U, new CAgentMethodVoid<int>(delegate(Agent self, int timerId)
			{
				((BTAgent)self).Action_StartTimer(timerId);
			}));
			agentMeta.RegisterMethod(2228423954U, new CAgentMethodVoid<int, bool>(delegate(Agent self, int monsterId, bool isCancel)
			{
				((BTAgent)self).Action_AssignAITarget(monsterId, isCancel);
			}));
			agentMeta.RegisterMethod(3016241397U, new CAgentMethodVoid<int, int>(delegate(Agent self, int index, int value)
			{
				((BTAgent)self).Action_SetCounter(index, value);
			}));
			agentMeta.RegisterMethod(3479728335U, new CAgentMethodVoid<int>(delegate(Agent self, int timerId)
			{
				((BTAgent)self).Action_StopTimer(timerId);
			}));
			agentMeta.RegisterMethod(3137412692U, new CAgentMethodVoid<int>(delegate(Agent self, int phase)
			{
				((BTAgent)self).Action_CreateBossPhaseChange(phase);
			}));
			agentMeta.RegisterMethod(3385729165U, new CAgentMethodVoid(delegate(Agent self)
			{
				((BTAgent)self).Action_RemoveAbnormalBuffs();
			}));
			agentMeta.RegisterMethod(1378719051U, new CAgentMethodVoid<int, List<int>, bool, int>(delegate(Agent self, int monsterId, List<int> offset, bool useSummonerLevel, int level)
			{
				((BTAgent)self).Action_Summon(monsterId, offset, useSummonerLevel, level);
			}));
			agentMeta.RegisterMethod(1346249081U, new CAgentMethod<int>((Agent self) => ((BTAgent)self).Action_GetAlivePlayerNum()));
			agentMeta.RegisterMethod(3472155925U, new CAgentMethod<int, int, int>((Agent self, int monsterID, int attributeType) => ((BTAgent)self).Action_GetMonsterAttributeByID(monsterID, attributeType)));
			agentMeta.RegisterMethod(806916736U, new CAgentMethodVoid<EventType>(delegate(Agent self, EventType eventType)
			{
				((BTAgent)self).Action_RegisterEventNew(eventType);
			}));
			agentMeta.RegisterMethod(1230983302U, new CAgentMethod<bool, EventType>((Agent self, EventType eventType) => ((BTAgent)self).Condition_HasReceiveEventNew(eventType)));
			agentMeta.RegisterMethod(2860011019U, new CAgentMethod<bool, int>((Agent self, int radius) => ((BTAgent)self).Condition_HaveTargetInArea(radius)));
			agentMeta.RegisterMethod(3950680632U, new CAgentMethod<bool>((Agent self) => ((BTAgent)self).Condition_IsAroundBossRomm()));
			agentMeta.RegisterMethod(1966675733U, new CAgentMethod<int, int>((Agent self, int dungeonId) => ((BTAgent)self).Condition_DungeonRecoverProcess(dungeonId)));
			agentMeta.RegisterMethod(1779607886U, new CAgentMethod<int>((Agent self) => ((BTAgent)self).Condition_GetMonsterCount()));
			agentMeta.RegisterMethod(2841312548U, new CAgentMethod<int, int>((Agent self, int timerId) => ((BTAgent)self).Condition_GetTimerById(timerId)));
			agentMeta.RegisterMethod(1402453247U, new CAgentMethod<int, int>((Agent self, int index) => ((BTAgent)self).Condition_GetCounter(index)));
			agentMeta.RegisterMethod(3252394897U, new CAgentMethod<bool, int>((Agent self, int dis) => ((BTAgent)self).Condition_CheckYDis(dis)));
			agentMeta.RegisterMethod(2089526615U, new CAgentMethod<bool>((Agent self) => ((BTAgent)self).Condition_HavePlayerUseAwakeSkill()));
			agentMeta.RegisterMethod(316819091U, new CAgentMethod<bool, int, int>((Agent self, int monsterId, int count) => ((BTAgent)self).Condition_JudgeMonsterCount(monsterId, count)));
			agentMeta.RegisterMethod(4255249166U, new CAgentMethod<bool, ServerNotifyMessageId>((Agent self, ServerNotifyMessageId dungeonMsgType) => ((BTAgent)self).Condition_ServerNotify(dungeonMsgType)));
			agentMeta.RegisterMethod(672830310U, new CAgentMethod<bool, int, int>((Agent self, int time, int timeId) => (bool)AgentMetaVisitor.ExecuteMethod(self, "Condition_IsTimeUp", new object[]
			{
				time,
				timeId
			})));
			agentMeta.RegisterMethod(26675105U, new CAgentMethod<bool, int>((Agent self, int radius) => ((BTAgent)self).Condition_IsPlayerAround(radius)));
			agentMeta.RegisterMethod(3297841801U, new CAgentMethod<bool, BE_Target, BE_Equal, int>((Agent self, BE_Target targetType, BE_Equal operation, int mechanismID) => ((BTAgent)self).Condition_HasMechanism(targetType, operation, mechanismID)));
			agentMeta.RegisterMethod(3740780351U, new CAgentMethod<bool, int>((Agent self, int buffId) => ((BTAgent)self).Condition_IsPlayerHasBuff(buffId)));
			agentMeta.RegisterMethod(541558984U, new CAgentMethod<bool, int>((Agent self, int dungeonID) => ((BTAgent)self).Condition_ServerNotifyEx(dungeonID)));
			agentMeta.RegisterMethod(720602260U, new CAgentMethodVoid<BE_Target, int, int, int, int>(delegate(Agent self, BE_Target targetType, int buffID, int buffTime, int buffLevel, int buffAttack)
			{
				((BTAgent)self).Action_AddBuff(targetType, buffID, buffTime, buffLevel, buffAttack);
			}));
			agentMeta.RegisterMethod(1803650255U, new CAgentMethodVoid<List<int>>(delegate(Agent self, List<int> targetIds)
			{
				((BTAgent)self).Action_AttackTargetByID(targetIds);
			}));
			agentMeta.RegisterMethod(25577190U, new CAgentMethodVoid<DestinationType>(delegate(Agent self, DestinationType destinationType)
			{
				((BTAgent)self).Action_DoDestinationSelect(destinationType);
			}));
			agentMeta.RegisterMethod(3029999138U, new CAgentMethodVoid<int, int, int, int>(delegate(Agent self, int front, int back, int top, int down)
			{
				((BTAgent)self).Action_EnemyNumberOfInAttackArea(front, back, top, down);
			}));
			agentMeta.RegisterMethod(2504827272U, new CAgentMethod<int>((Agent self) => ((BTAgent)self).Action_GenRandom()));
			agentMeta.RegisterMethod(3344799977U, new CAgentMethodVoid<int, int, int, int, List<int>>(delegate(Agent self, int front, int back, int top, int down, List<int> monsterIDs)
			{
				((BTAgent)self).Action_MonsterNumberOfInArea(front, back, top, down, monsterIDs);
			}));
			agentMeta.RegisterMethod(82079068U, new CAgentMethodVoid<int, int, int, int, List<int>, bool>(delegate(Agent self, int front, int back, int top, int bottom, List<int> monsterIds, bool isEnemy)
			{
				((BTAgent)self).Action_MonsterNumberOfInAreaByCamp(front, back, top, bottom, monsterIds, isEnemy);
			}));
			agentMeta.RegisterMethod(1789821441U, new CAgentMethodVoid<EventType>(delegate(Agent self, EventType eventType)
			{
				((BTAgent)self).Action_RegisterEvent(eventType);
			}));
			agentMeta.RegisterMethod(3483556305U, new CAgentMethodVoid<EventType, int>(delegate(Agent self, EventType eventType, int monsterID)
			{
				((BTAgent)self).Action_RegisterOtherEvent(eventType, monsterID);
			}));
			agentMeta.RegisterMethod(3171515372U, new CAgentMethodVoid<BE_Target, int>(delegate(Agent self, BE_Target targetType, int buffID)
			{
				((BTAgent)self).Action_RemoveBuff(targetType, buffID);
			}));
			agentMeta.RegisterMethod(2342758687U, new CAgentMethodVoid<string, float, int>(delegate(Agent self, string text, float durTime, int style)
			{
				((BTAgent)self).Action_ShowHeadText(text, durTime, style);
			}));
			agentMeta.RegisterMethod(3304377747U, new CAgentMethodVoid<EventType>(delegate(Agent self, EventType eventType)
			{
				((BTAgent)self).Action_UnRegistEvent(eventType);
			}));
			agentMeta.RegisterMethod(2178682257U, new CAgentMethod<EBTStatus, int, int>((Agent self, int waitTime, int timerId) => ((BTAgent)self).Action_WaitGameTime(waitTime, timerId)));
			agentMeta.RegisterMethod(2970849355U, new CAgentMethod<bool, int>((Agent self, int skillID) => ((BTAgent)self).Condition_CanUseSkill(skillID)));
			agentMeta.RegisterMethod(4187585523U, new CAgentMethod<bool, BE_Target, BE_Equal, int>((Agent self, BE_Target target, BE_Equal operation, int buffID) => ((BTAgent)self).Condition_CheckHasBuff(target, operation, buffID)));
			agentMeta.RegisterMethod(3268246582U, new CAgentMethod<bool, HMType, BE_Operation, float>((Agent self, HMType type, BE_Operation operation, float value) => ((BTAgent)self).Condition_CheckHPMP(type, operation, value)));
			agentMeta.RegisterMethod(614082085U, new CAgentMethod<bool, BE_Target, BE_Passive>((Agent self, BE_Target target, BE_Passive passive) => ((BTAgent)self).Condition_CheckInPassive(target, passive)));
			agentMeta.RegisterMethod(2590296450U, new CAgentMethod<bool, int>((Agent self, int skillID) => ((BTAgent)self).Condition_CheckIsUsingSkill(skillID)));
			agentMeta.RegisterMethod(1644788736U, new CAgentMethod<bool, BE_Operation, int>((Agent self, BE_Operation operation, int value) => ((BTAgent)self).Condition_CheckLastResult(operation, value)));
			agentMeta.RegisterMethod(2329920666U, new CAgentMethod<bool, BE_Target, BE_Operation, int>((Agent self, BE_Target target, BE_Operation operation, int level) => ((BTAgent)self).Condition_CheckLevel(target, operation, level)));
			agentMeta.RegisterMethod(607639502U, new CAgentMethod<bool, BE_Target, BE_Equal, BE_State>((Agent self, BE_Target target, BE_Equal operation, BE_State state) => ((BTAgent)self).Condition_CheckState(target, operation, state)));
			agentMeta.RegisterMethod(1159653452U, new CAgentMethod<bool, float>((Agent self, float succeedRandom) => ((BTAgent)self).Condition_GetRandom(succeedRandom)));
			agentMeta.RegisterMethod(1969182254U, new CAgentMethod<bool, EventType>((Agent self, EventType EventType) => ((BTAgent)self).Condition_HasReceiveEvent(EventType)));
			agentMeta.RegisterMethod(2927427711U, new CAgentMethod<bool, int>((Agent self, int skillId) => ((BTAgent)self).Condition_HaveSkill(skillId)));
			agentMeta.RegisterMethod(1362447907U, new CAgentMethod<bool, int>((Agent self, int monsterID) => ((BTAgent)self).Condition_IsHaveMonster(monsterID)));
			agentMeta.RegisterMethod(2047331937U, new CAgentMethod<bool>((Agent self) => ((BTAgent)self).Condition_IsSelfInCircle()));
			agentMeta.RegisterMethod(3630258334U, new CAgentMethod<bool, int, int, int, int>((Agent self, int front, int back, int top, int down) => ((BTAgent)self).Condition_IsTargetInAttackArea(front, back, top, down)));
			agentMeta.RegisterMethod(1165651594U, new CAgentMethod<bool, BE_Operation, int>((Agent self, BE_Operation compare, int dis) => ((BTAgent)self).Condition_XDis(compare, dis)));
			agentMeta.RegisterMethod(3871263378U, new CAgentMethod<bool>((Agent self) => ((BTAgent)self).Conditon_IsDayTime()));
			agentMeta.RegisterMethod(1045109914U, new CAgentStaticMethodVoid<string>(delegate(string param0)
			{
				Agent.LogMessage(param0);
			}));
			agentMeta.RegisterMethod(2521019022U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorAdd());
			agentMeta.RegisterMethod(2306090221U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorClear());
			agentMeta.RegisterMethod(3483755530U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorContains());
			agentMeta.RegisterMethod(505785840U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorLength());
			agentMeta.RegisterMethod(502968959U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorRemove());
			agentMeta.RegisterMethod(2858372515U, new CAgentMethod<bool, int, int, int, int, int, int, int, int>((Agent self, int innerFront, int innerBack, int innerTop, int innerBottom, int outerFront, int outerBack, int outerTop, int outerBottom) => ((BTAgent)self).Condition_isTargetIsCircleArea(innerFront, innerBack, innerTop, innerBottom, outerFront, outerBack, outerTop, outerBottom)));
			agentMeta.RegisterMethod(860390019U, new CAgentMethod<bool, int, bool, bool>((Agent self, int dist, bool faceRelated, bool sameFace) => ((BTAgent)self).Condition_IsAroundHorizontalEdge(dist, faceRelated, sameFace)));
			agentMeta.RegisterMethod(777013559U, new BehaviorLoaderImplement.CMethod_BTAgent_Action_DoAction());
			agentMeta.RegisterMethod(4062511972U, new CAgentMethod<bool, int>((Agent self, int buffID) => ((BTAgent)self).Condition_PlayerHaveBuff(buffID)));
			agentMeta.RegisterMethod(818989492U, new CAgentMethod<bool, List<int>>((Agent self, List<int> skillIdArr) => ((BTAgent)self).Condition_AtLeastOneSkillInCD(skillIdArr)));
			agentMeta.RegisterMethod(822633361U, new CAgentMethod<bool, List<int>>((Agent self, List<int> skillIdArr) => ((BTAgent)self).Condition_AtLeastOneSkillCanUse(skillIdArr)));
			agentMeta.RegisterMethod(1594679734U, new CAgentMethodVoid<int>(delegate(Agent self, int timeID)
			{
				((BTAgent)self).Action_ResetTime(timeID);
			}));
			agentMeta = new AgentMeta(2319960345U);
			AgentMeta._AgentMetas_[576847485U] = agentMeta;
			agentMeta.RegisterMemberProperty(253469147U, new CMemberProperty<int>("CommonIntVar", delegate(Agent self, int value)
			{
				((LevelAgent)self)._set_CommonIntVar(value);
			}, (Agent self) => ((LevelAgent)self)._get_CommonIntVar()));
			agentMeta.RegisterMethod(2700841094U, new CAgentMethodVoid<string>(delegate(Agent self, string path)
			{
				((LevelAgent)self).Action_PlayBgm(path);
			}));
			agentMeta.RegisterMethod(2342758687U, new CAgentMethodVoid<string, float>(delegate(Agent self, string text, float durTime)
			{
				((LevelAgent)self).Action_ShowHeadText(text, durTime);
			}));
			agentMeta.RegisterMethod(2509543484U, new CAgentMethodVoid<int>(delegate(Agent self, int time)
			{
				((LevelAgent)self).Action_SetCountTime(time);
			}));
			agentMeta.RegisterMethod(3016241397U, new CAgentMethodVoid<LevelCounterType, int>(delegate(Agent self, LevelCounterType typeId, int value)
			{
				((LevelAgent)self).Action_SetCounter(typeId, value);
			}));
			agentMeta.RegisterMethod(2679587398U, new CAgentMethodVoid<int, bool>(delegate(Agent self, int buffInfoId, bool summonerFlag)
			{
				((LevelAgent)self).Action_AllPlayersAddBuffInfo(buffInfoId, summonerFlag);
			}));
			agentMeta.RegisterMethod(646934834U, new CAgentMethodVoid<int, List<float>, int>(delegate(Agent self, int summonId, List<float> summonPos, int level)
			{
				((LevelAgent)self).Action_SummonMonster(summonId, summonPos, level);
			}));
			agentMeta.RegisterMethod(495595849U, new CAgentMethod<bool, int>((Agent self, int time) => ((LevelAgent)self).Condition_CheckCountTime(time)));
			agentMeta.RegisterMethod(288724314U, new CAgentMethod<int>((Agent self) => ((LevelAgent)self).Condition_RoomRunningTime()));
			agentMeta.RegisterMethod(3002086281U, new CAgentMethod<bool, LevelCounterType, int>((Agent self, LevelCounterType counterType, int value) => ((LevelAgent)self).Condition_CheckCounter(counterType, value)));
			agentMeta.RegisterMethod(1667802496U, new CAgentMethod<bool, int>((Agent self, int rate) => ((LevelAgent)self).Condition_Random(rate)));
			agentMeta.RegisterMethod(2840239545U, new CAgentMethod<bool, int>((Agent self, int areaid) => ((LevelAgent)self).Condition_IsInRoom(areaid)));
			agentMeta.RegisterMethod(2137614504U, new CAgentMethod<bool, int>((Agent self, int monsterId) => ((LevelAgent)self).Condition_HaveMonster(monsterId)));
			agentMeta.RegisterMethod(1045109914U, new CAgentStaticMethodVoid<string>(delegate(string param0)
			{
				Agent.LogMessage(param0);
			}));
			agentMeta.RegisterMethod(2521019022U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorAdd());
			agentMeta.RegisterMethod(2306090221U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorClear());
			agentMeta.RegisterMethod(3483755530U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorContains());
			agentMeta.RegisterMethod(505785840U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorLength());
			agentMeta.RegisterMethod(502968959U, new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorRemove());
			AgentMeta.Register<Agent>("behaviac.Agent");
			AgentMeta.Register<BTAgent>("BTAgent");
			AgentMeta.Register<LevelAgent>("LevelAgent");
			AgentMeta.Register<BE_Target>("behaviac.BE_Target");
			ComparerRegister.RegisterType<BE_Target, CompareValue_behaviac_BE_Target>();
			AgentMeta.Register<DestinationType>("behaviac.DestinationType");
			ComparerRegister.RegisterType<DestinationType, CompareValue_behaviac_DestinationType>();
			AgentMeta.Register<BE_Operation>("behaviac.BE_Operation");
			ComparerRegister.RegisterType<BE_Operation, CompareValue_behaviac_BE_Operation>();
			AgentMeta.Register<HMType>("behaviac.HMType");
			ComparerRegister.RegisterType<HMType, CompareValue_behaviac_HMType>();
			AgentMeta.Register<BE_Passive>("behaviac.BE_Passive");
			ComparerRegister.RegisterType<BE_Passive, CompareValue_behaviac_BE_Passive>();
			AgentMeta.Register<BE_State>("behaviac.BE_State");
			ComparerRegister.RegisterType<BE_State, CompareValue_behaviac_BE_State>();
			AgentMeta.Register<BE_Equal>("behaviac.BE_Equal");
			ComparerRegister.RegisterType<BE_Equal, CompareValue_behaviac_BE_Equal>();
			AgentMeta.Register<EventType>("behaviac.EventType");
			ComparerRegister.RegisterType<EventType, CompareValue_behaviac_EventType>();
			AgentMeta.Register<LevelCounterType>("behaviac.LevelCounterType");
			ComparerRegister.RegisterType<LevelCounterType, CompareValue_behaviac_LevelCounterType>();
			AgentMeta.Register<ServerNotifyMessageId>("behaviac.ServerNotifyMessageId");
			ComparerRegister.RegisterType<ServerNotifyMessageId, CompareValue_behaviac_ServerNotifyMessageId>();
			AgentMeta.Register<Input>("behaviac.Input");
			ComparerRegister.RegisterType<Input, CompareValue_behaviac_Input>();
			return true;
		}

		// Token: 0x06016949 RID: 92489 RVA: 0x006D6B54 File Offset: 0x006D4F54
		public override bool UnLoad()
		{
			AgentMeta.UnRegister<Agent>("behaviac.Agent");
			AgentMeta.UnRegister<BTAgent>("BTAgent");
			AgentMeta.UnRegister<LevelAgent>("LevelAgent");
			AgentMeta.UnRegister<BE_Target>("behaviac.BE_Target");
			AgentMeta.UnRegister<DestinationType>("behaviac.DestinationType");
			AgentMeta.UnRegister<BE_Operation>("behaviac.BE_Operation");
			AgentMeta.UnRegister<HMType>("behaviac.HMType");
			AgentMeta.UnRegister<BE_Passive>("behaviac.BE_Passive");
			AgentMeta.UnRegister<BE_State>("behaviac.BE_State");
			AgentMeta.UnRegister<BE_Equal>("behaviac.BE_Equal");
			AgentMeta.UnRegister<EventType>("behaviac.EventType");
			AgentMeta.UnRegister<LevelCounterType>("behaviac.LevelCounterType");
			AgentMeta.UnRegister<ServerNotifyMessageId>("behaviac.ServerNotifyMessageId");
			AgentMeta.UnRegister<Input>("behaviac.Input");
			return true;
		}

		// Token: 0x020040E1 RID: 16609
		private class CInstanceConst_behaviac_Input : CInstanceConst<Input>
		{
			// Token: 0x060169BE RID: 92606 RVA: 0x006D74AC File Offset: 0x006D58AC
			public CInstanceConst_behaviac_Input(string typeName, string valueStr) : base(typeName, valueStr)
			{
				List<string> list = StringUtils.SplitTokensForStruct(valueStr);
				this._delay = (CInstanceMember<int>)AgentMeta.ParseProperty<int>(list[0]);
				this._skillID = (CInstanceMember<int>)AgentMeta.ParseProperty<int>(list[1]);
				this._pressTime = (CInstanceMember<int>)AgentMeta.ParseProperty<int>(list[2]);
				this._specialChoice = (CInstanceMember<int>)AgentMeta.ParseProperty<int>(list[3]);
				this._randomChangeDirection = (CInstanceMember<bool>)AgentMeta.ParseProperty<bool>(list[4]);
				this._PKRobotComboCheck = (CInstanceMember<bool>)AgentMeta.ParseProperty<bool>(list[5]);
				this._moveInSkillState = (CInstanceMember<bool>)AgentMeta.ParseProperty<bool>(list[6]);
				this._moveKeepDistance = (CInstanceMember<int>)AgentMeta.ParseProperty<int>(list[7]);
			}

			// Token: 0x060169BF RID: 92607 RVA: 0x006D7580 File Offset: 0x006D5980
			public override void Run(Agent self)
			{
				this._value.delay = ((CInstanceMember<int>)this._delay).GetValue(self);
				this._value.skillID = ((CInstanceMember<int>)this._skillID).GetValue(self);
				this._value.pressTime = ((CInstanceMember<int>)this._pressTime).GetValue(self);
				this._value.specialChoice = ((CInstanceMember<int>)this._specialChoice).GetValue(self);
				this._value.randomChangeDirection = ((CInstanceMember<bool>)this._randomChangeDirection).GetValue(self);
				this._value.PKRobotComboCheck = ((CInstanceMember<bool>)this._PKRobotComboCheck).GetValue(self);
				this._value.moveInSkillState = ((CInstanceMember<bool>)this._moveInSkillState).GetValue(self);
				this._value.moveKeepDistance = ((CInstanceMember<int>)this._moveKeepDistance).GetValue(self);
			}

			// Token: 0x040101AF RID: 65967
			private IInstanceMember _delay;

			// Token: 0x040101B0 RID: 65968
			private IInstanceMember _skillID;

			// Token: 0x040101B1 RID: 65969
			private IInstanceMember _pressTime;

			// Token: 0x040101B2 RID: 65970
			private IInstanceMember _specialChoice;

			// Token: 0x040101B3 RID: 65971
			private IInstanceMember _randomChangeDirection;

			// Token: 0x040101B4 RID: 65972
			private IInstanceMember _PKRobotComboCheck;

			// Token: 0x040101B5 RID: 65973
			private IInstanceMember _moveInSkillState;

			// Token: 0x040101B6 RID: 65974
			private IInstanceMember _moveKeepDistance;
		}

		// Token: 0x020040E2 RID: 16610
		private class CMethod_behaviac_Agent_VectorAdd : CAgentMethodVoidBase
		{
			// Token: 0x060169C0 RID: 92608 RVA: 0x006D76D0 File Offset: 0x006D5AD0
			public CMethod_behaviac_Agent_VectorAdd()
			{
			}

			// Token: 0x060169C1 RID: 92609 RVA: 0x006D76D8 File Offset: 0x006D5AD8
			public CMethod_behaviac_Agent_VectorAdd(BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorAdd rhs) : base(rhs)
			{
			}

			// Token: 0x060169C2 RID: 92610 RVA: 0x006D76E1 File Offset: 0x006D5AE1
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorAdd(this);
			}

			// Token: 0x060169C3 RID: 92611 RVA: 0x006D76E9 File Offset: 0x006D5AE9
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._param0 = AgentMeta.ParseProperty<IList>(paramStrs[0]);
				this._param1 = AgentMeta.ParseProperty<object>(paramStrs[1]);
			}

			// Token: 0x060169C4 RID: 92612 RVA: 0x006D770E File Offset: 0x006D5B0E
			public override void Run(Agent self)
			{
				Agent.VectorAdd((IList)this._param0.GetValueObject(self), this._param1.GetValueObject(self));
			}

			// Token: 0x040101B7 RID: 65975
			private IInstanceMember _param0;

			// Token: 0x040101B8 RID: 65976
			private IInstanceMember _param1;
		}

		// Token: 0x020040E3 RID: 16611
		private class CMethod_behaviac_Agent_VectorClear : CAgentMethodVoidBase
		{
			// Token: 0x060169C5 RID: 92613 RVA: 0x006D7732 File Offset: 0x006D5B32
			public CMethod_behaviac_Agent_VectorClear()
			{
			}

			// Token: 0x060169C6 RID: 92614 RVA: 0x006D773A File Offset: 0x006D5B3A
			public CMethod_behaviac_Agent_VectorClear(BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorClear rhs) : base(rhs)
			{
			}

			// Token: 0x060169C7 RID: 92615 RVA: 0x006D7743 File Offset: 0x006D5B43
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorClear(this);
			}

			// Token: 0x060169C8 RID: 92616 RVA: 0x006D774B File Offset: 0x006D5B4B
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._param0 = AgentMeta.ParseProperty<IList>(paramStrs[0]);
			}

			// Token: 0x060169C9 RID: 92617 RVA: 0x006D7762 File Offset: 0x006D5B62
			public override void Run(Agent self)
			{
				Agent.VectorClear((IList)this._param0.GetValueObject(self));
			}

			// Token: 0x040101B9 RID: 65977
			private IInstanceMember _param0;
		}

		// Token: 0x020040E4 RID: 16612
		private class CMethod_behaviac_Agent_VectorContains : CAgentMethodBase<bool>
		{
			// Token: 0x060169CA RID: 92618 RVA: 0x006D782A File Offset: 0x006D5C2A
			public CMethod_behaviac_Agent_VectorContains()
			{
			}

			// Token: 0x060169CB RID: 92619 RVA: 0x006D7832 File Offset: 0x006D5C32
			public CMethod_behaviac_Agent_VectorContains(BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorContains rhs) : base(rhs)
			{
			}

			// Token: 0x060169CC RID: 92620 RVA: 0x006D783B File Offset: 0x006D5C3B
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorContains(this);
			}

			// Token: 0x060169CD RID: 92621 RVA: 0x006D7843 File Offset: 0x006D5C43
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._param0 = AgentMeta.ParseProperty<IList>(paramStrs[0]);
				this._param1 = AgentMeta.ParseProperty<object>(paramStrs[1]);
			}

			// Token: 0x060169CE RID: 92622 RVA: 0x006D7868 File Offset: 0x006D5C68
			public override void Run(Agent self)
			{
				this._returnValue.value = Agent.VectorContains((IList)this._param0.GetValueObject(self), this._param1.GetValueObject(self));
			}

			// Token: 0x040101BA RID: 65978
			private IInstanceMember _param0;

			// Token: 0x040101BB RID: 65979
			private IInstanceMember _param1;
		}

		// Token: 0x020040E5 RID: 16613
		private class CMethod_behaviac_Agent_VectorLength : CAgentMethodBase<int>
		{
			// Token: 0x060169CF RID: 92623 RVA: 0x006D7897 File Offset: 0x006D5C97
			public CMethod_behaviac_Agent_VectorLength()
			{
			}

			// Token: 0x060169D0 RID: 92624 RVA: 0x006D789F File Offset: 0x006D5C9F
			public CMethod_behaviac_Agent_VectorLength(BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorLength rhs) : base(rhs)
			{
			}

			// Token: 0x060169D1 RID: 92625 RVA: 0x006D78A8 File Offset: 0x006D5CA8
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorLength(this);
			}

			// Token: 0x060169D2 RID: 92626 RVA: 0x006D78B0 File Offset: 0x006D5CB0
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._param0 = AgentMeta.ParseProperty<IList>(paramStrs[0]);
			}

			// Token: 0x060169D3 RID: 92627 RVA: 0x006D78C7 File Offset: 0x006D5CC7
			public override void Run(Agent self)
			{
				this._returnValue.value = Agent.VectorLength((IList)this._param0.GetValueObject(self));
			}

			// Token: 0x040101BC RID: 65980
			private IInstanceMember _param0;
		}

		// Token: 0x020040E6 RID: 16614
		private class CMethod_behaviac_Agent_VectorRemove : CAgentMethodVoidBase
		{
			// Token: 0x060169D4 RID: 92628 RVA: 0x006D78EA File Offset: 0x006D5CEA
			public CMethod_behaviac_Agent_VectorRemove()
			{
			}

			// Token: 0x060169D5 RID: 92629 RVA: 0x006D78F2 File Offset: 0x006D5CF2
			public CMethod_behaviac_Agent_VectorRemove(BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorRemove rhs) : base(rhs)
			{
			}

			// Token: 0x060169D6 RID: 92630 RVA: 0x006D78FB File Offset: 0x006D5CFB
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_behaviac_Agent_VectorRemove(this);
			}

			// Token: 0x060169D7 RID: 92631 RVA: 0x006D7903 File Offset: 0x006D5D03
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._param0 = AgentMeta.ParseProperty<IList>(paramStrs[0]);
				this._param1 = AgentMeta.ParseProperty<object>(paramStrs[1]);
			}

			// Token: 0x060169D8 RID: 92632 RVA: 0x006D7928 File Offset: 0x006D5D28
			public override void Run(Agent self)
			{
				Agent.VectorRemove((IList)this._param0.GetValueObject(self), this._param1.GetValueObject(self));
			}

			// Token: 0x040101BD RID: 65981
			private IInstanceMember _param0;

			// Token: 0x040101BE RID: 65982
			private IInstanceMember _param1;
		}

		// Token: 0x020040E7 RID: 16615
		private class CMethod_BTAgent_Action_DoAction : CAgentMethodVoidBase
		{
			// Token: 0x060169D9 RID: 92633 RVA: 0x006D794C File Offset: 0x006D5D4C
			public CMethod_BTAgent_Action_DoAction()
			{
			}

			// Token: 0x060169DA RID: 92634 RVA: 0x006D7954 File Offset: 0x006D5D54
			public CMethod_BTAgent_Action_DoAction(BehaviorLoaderImplement.CMethod_BTAgent_Action_DoAction rhs) : base(rhs)
			{
			}

			// Token: 0x060169DB RID: 92635 RVA: 0x006D795D File Offset: 0x006D5D5D
			public override IMethod Clone()
			{
				return new BehaviorLoaderImplement.CMethod_BTAgent_Action_DoAction(this);
			}

			// Token: 0x060169DC RID: 92636 RVA: 0x006D7965 File Offset: 0x006D5D65
			public override void Load(string instance, string[] paramStrs)
			{
				this._instance = instance;
				this._inputs = (CInstanceMember<List<Input>>)AgentMeta.ParseProperty<List<Input>>(paramStrs[0]);
				this._isPVPAI = (CInstanceMember<bool>)AgentMeta.ParseProperty<bool>(paramStrs[1]);
			}

			// Token: 0x060169DD RID: 92637 RVA: 0x006D7994 File Offset: 0x006D5D94
			public override void Run(Agent self)
			{
				List<Input> value = this._inputs.GetValue(self);
				Agent parentAgent = Utils.GetParentAgent(self, this._instance);
				((BTAgent)parentAgent).Action_DoAction(ref value, this._isPVPAI.GetValue(self));
				this._inputs.SetValue(self, value);
			}

			// Token: 0x040101BF RID: 65983
			private CInstanceMember<List<Input>> _inputs;

			// Token: 0x040101C0 RID: 65984
			private CInstanceMember<bool> _isPVPAI;
		}
	}
}
