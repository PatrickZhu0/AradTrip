using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001195 RID: 4501
	internal class BeTownPlayerMain : BeTownPlayer
	{
		// Token: 0x0600AC61 RID: 44129 RVA: 0x00251644 File Offset: 0x0024FA44
		public BeTownPlayerMain(BeTownPlayerData data, ClientSystemTown systemTown) : base(data, systemTown)
		{
			if (BeTownPlayerMain.OnAutoMoveSuccess == null)
			{
				BeTownPlayerMain.OnAutoMoveSuccess = new BeTownPlayerMain.AutoMoveSuccessEvent();
			}
			if (BeTownPlayerMain.OnMoveStateChanged == null)
			{
				BeTownPlayerMain.OnMoveStateChanged = new BeTownPlayerMain.MoveStateChangedEvent();
			}
			if (BeTownPlayerMain.OnAutoMoveFail == null)
			{
				BeTownPlayerMain.OnAutoMoveFail = new BeTownPlayerMain.AutoMoveFailEvent();
			}
			if (BeTownPlayerMain.OnMoveing == null)
			{
				BeTownPlayerMain.OnMoveing = new BeTownPlayerMain.MoveingEvent();
			}
			if (BeTownPlayerMain.OnAutoMoving == null)
			{
				BeTownPlayerMain.OnAutoMoving = new BeTownPlayerMain.AutoMoveingEvent();
			}
			this.MoveState = BeTownPlayerMain.EMoveState.Idle;
		}

		// Token: 0x17001A65 RID: 6757
		// (get) Token: 0x0600AC62 RID: 44130 RVA: 0x00251709 File Offset: 0x0024FB09
		// (set) Token: 0x0600AC63 RID: 44131 RVA: 0x00251710 File Offset: 0x0024FB10
		public static BeTownPlayerMain.MoveStateChangedEvent OnMoveStateChanged { get; set; }

		// Token: 0x17001A66 RID: 6758
		// (get) Token: 0x0600AC64 RID: 44132 RVA: 0x00251718 File Offset: 0x0024FB18
		// (set) Token: 0x0600AC65 RID: 44133 RVA: 0x0025171F File Offset: 0x0024FB1F
		public static BeTownPlayerMain.AutoMoveSuccessEvent OnAutoMoveSuccess { get; set; }

		// Token: 0x17001A67 RID: 6759
		// (get) Token: 0x0600AC66 RID: 44134 RVA: 0x00251727 File Offset: 0x0024FB27
		// (set) Token: 0x0600AC67 RID: 44135 RVA: 0x0025172E File Offset: 0x0024FB2E
		public static BeTownPlayerMain.AutoMoveFailEvent OnAutoMoveFail { get; set; }

		// Token: 0x17001A68 RID: 6760
		// (get) Token: 0x0600AC68 RID: 44136 RVA: 0x00251736 File Offset: 0x0024FB36
		// (set) Token: 0x0600AC69 RID: 44137 RVA: 0x0025173D File Offset: 0x0024FB3D
		public static BeTownPlayerMain.MoveingEvent OnMoveing { get; set; }

		// Token: 0x17001A69 RID: 6761
		// (get) Token: 0x0600AC6A RID: 44138 RVA: 0x00251745 File Offset: 0x0024FB45
		// (set) Token: 0x0600AC6B RID: 44139 RVA: 0x0025174C File Offset: 0x0024FB4C
		public static BeTownPlayerMain.AutoMoveingEvent OnAutoMoving { get; set; }

		// Token: 0x17001A6A RID: 6762
		// (get) Token: 0x0600AC6C RID: 44140 RVA: 0x00251754 File Offset: 0x0024FB54
		// (set) Token: 0x0600AC6D RID: 44141 RVA: 0x0025175C File Offset: 0x0024FB5C
		public BeTownPlayerMain.EMoveState MoveState { get; set; }

		// Token: 0x0600AC6E RID: 44142 RVA: 0x00251765 File Offset: 0x0024FB65
		private void _BeginTrace(int iNpcID, Vector3 target)
		{
			if (this.comTaskGuideModelArrow != null)
			{
				this.comTaskGuideModelArrow.BeginTrace(iNpcID, target);
			}
		}

		// Token: 0x0600AC6F RID: 44143 RVA: 0x00251785 File Offset: 0x0024FB85
		private void _EndTrace()
		{
			if (this.comTaskGuideModelArrow != null)
			{
				this.comTaskGuideModelArrow.EndTrace();
			}
		}

		// Token: 0x0600AC70 RID: 44144 RVA: 0x002517A4 File Offset: 0x0024FBA4
		public sealed override void InitGeActor(GeSceneEx geScene)
		{
			base.InitGeActor(geScene);
			if (this._geActor != null)
			{
				bool flag = false;
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null)
				{
					CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
					if (tableItem != null && tableItem.SceneSubType == CitySceneTable.eSceneSubType.Pk3v3)
					{
						flag = true;
					}
				}
				if (flag)
				{
					RoomInfo roomInfo = DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo();
					if (roomInfo == null || roomInfo.roomSlotInfos == null)
					{
						base.CreateFootIndicator(BeTownPlayer.FootEffectType.DEFUALT);
					}
					else
					{
						bool flag2 = false;
						for (int i = 0; i < roomInfo.roomSlotInfos.Length; i++)
						{
							if (roomInfo.roomSlotInfos[i].playerId == base.ActorData.GUID)
							{
								if (roomInfo.roomSlotInfos[i].group == 1)
								{
									base.CreateFootIndicator(BeTownPlayer.FootEffectType.RED);
								}
								else
								{
									base.CreateFootIndicator(BeTownPlayer.FootEffectType.BULE);
								}
								flag2 = true;
								break;
							}
						}
						if (!flag2)
						{
							base.CreateFootIndicator(BeTownPlayer.FootEffectType.DEFUALT);
						}
					}
				}
				else
				{
					base.CreateFootIndicator(BeTownPlayer.FootEffectType.DEFUALT);
				}
				this.UpdateEquip();
				UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this.UpdateAvatar));
			}
		}

		// Token: 0x0600AC71 RID: 44145 RVA: 0x002518E0 File Offset: 0x0024FCE0
		public void CreatePropertyRiseEffect(string content)
		{
			this._geActor.CreatePropertyRiseEffect(content);
		}

		// Token: 0x0600AC72 RID: 44146 RVA: 0x002518EE File Offset: 0x0024FCEE
		private void UpdateAvatar(UIEvent data = null)
		{
			this.UpdateEquip();
		}

		// Token: 0x0600AC73 RID: 44147 RVA: 0x002518F6 File Offset: 0x0024FCF6
		public sealed override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AvatarChanged, new ClientEventSystem.UIEventHandler(this.UpdateAvatar));
		}

		// Token: 0x0600AC74 RID: 44148 RVA: 0x0025191C File Offset: 0x0024FD1C
		public void UpdateEquip()
		{
			PlayerAvatar avatar = DataManager<PlayerBaseData>.GetInstance().avatar;
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			if (avatar != null)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromItems(null, avatar.equipItemIds, jobTableID, (int)avatar.weaponStrengthen, this._geActor, false, avatar.isShoWeapon, false);
			}
			else
			{
				Logger.LogErrorFormat("avatar is null in BeTownPlayerMain UpdateEquip", new object[0]);
			}
		}

		// Token: 0x0600AC75 RID: 44149 RVA: 0x00251980 File Offset: 0x0024FD80
		public void SetEnable(bool bEnable)
		{
			this.m_bEnable = bEnable;
		}

		// Token: 0x0600AC76 RID: 44150 RVA: 0x0025198C File Offset: 0x0024FD8C
		public void CommandMoveToSceneActor(object sceneActorId, ESceneActorType sceneActorType = ESceneActorType.Npc)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			BeTownPlayerMain.CommandStopAutoMove();
			List<Vector3> sceneActorMovePath = this.GetSceneActorMovePath(sceneActorId, sceneActorType);
			if (sceneActorMovePath != null)
			{
				BeTownPlayerMain.ms_autoMoveCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(BeTownPlayerMain.AsyncMoveToSceneActor(this._systemTown, sceneActorMovePath, sceneActorId, sceneActorType));
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("common_cannot_auto_move"), null, string.Empty, false);
				Logger.LogErrorFormat("移动到SceneActor{0} >>> 无效的NPC", new object[]
				{
					sceneActorId
				});
			}
		}

		// Token: 0x0600AC77 RID: 44151 RVA: 0x00251A08 File Offset: 0x0024FE08
		private static IEnumerator AsyncMoveToSceneActor(ClientSystemTown systemTown, List<Vector3> doorList, object sceneActorId, ESceneActorType sceneActorType = ESceneActorType.Npc)
		{
			while (doorList.Count > 0)
			{
				if (!BeTownPlayerMain._CheckSystemValid(systemTown))
				{
					BeTownPlayerMain.OnAutoMoveFail.Invoke();
					BeTownPlayerMain.ms_autoMoveCoroutine = null;
					yield break;
				}
				Vector3 targetPos = doorList[0];
				doorList.RemoveAt(0);
				systemTown.MainPlayer.CommandMoveTo(targetPos);
				if (systemTown.MainPlayer.MoveState != BeTownPlayerMain.EMoveState.AutoMoving)
				{
					BeTownPlayerMain.OnAutoMoveFail.Invoke();
					BeTownPlayerMain.ms_autoMoveCoroutine = null;
					yield break;
				}
				int oldSceneId = systemTown.CurrentSceneID;
				while (oldSceneId == systemTown.CurrentSceneID)
				{
					if (!BeTownPlayerMain._CheckSystemValid(systemTown))
					{
						BeTownPlayerMain.OnAutoMoveFail.Invoke();
						BeTownPlayerMain.ms_autoMoveCoroutine = null;
						yield break;
					}
					if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
					{
						yield return Yielders.EndOfFrame;
					}
					else
					{
						if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.Moveing)
						{
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
							BeTownPlayerMain.ms_autoMoveCoroutine = null;
							yield break;
						}
						if (!systemTown.MainPlayer._IsInSameGrid(targetPos, systemTown.MainPlayer.ActorData.MoveData.Position))
						{
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
							BeTownPlayerMain.ms_autoMoveCoroutine = null;
							yield break;
						}
						yield return Yielders.EndOfFrame;
					}
				}
			}
			if (!BeTownPlayerMain._CheckSystemValid(systemTown))
			{
				BeTownPlayerMain.OnAutoMoveFail.Invoke();
				BeTownPlayerMain.ms_autoMoveCoroutine = null;
				yield break;
			}
			bool isSceneActorExist = false;
			Vector3 sceneActorPosition = Vector3.zero;
			BeTownPlayerMain.GetSceneActorMoveTargetPosition(ref isSceneActorExist, ref sceneActorPosition, systemTown, sceneActorId, sceneActorType);
			if (isSceneActorExist)
			{
				systemTown.MainPlayer.CommandMoveTo(sceneActorPosition);
				while (BeTownPlayerMain._CheckSystemValid(systemTown))
				{
					if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
					{
						yield return Yielders.EndOfFrame;
					}
					else
					{
						if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.Moveing)
						{
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
							BeTownPlayerMain.ms_autoMoveCoroutine = null;
							yield break;
						}
						if (systemTown.MainPlayer._IsInSameGrid(sceneActorPosition, systemTown.MainPlayer.ActorData.MoveData.Position))
						{
							BeTownPlayerMain.OnAutoMoveSuccess.Invoke();
						}
						else
						{
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
						}
						BeTownPlayerMain.ms_autoMoveCoroutine = null;
						yield break;
					}
				}
				BeTownPlayerMain.OnAutoMoveFail.Invoke();
				BeTownPlayerMain.ms_autoMoveCoroutine = null;
				yield break;
			}
			BeTownPlayerMain.OnAutoMoveFail.Invoke();
			BeTownPlayerMain.ms_autoMoveCoroutine = null;
			yield break;
		}

		// Token: 0x0600AC78 RID: 44152 RVA: 0x00251A38 File Offset: 0x0024FE38
		private List<Vector3> GetSceneActorMovePath(object sceneActorId, ESceneActorType sceneActorType = ESceneActorType.Npc)
		{
			List<Vector3> result = null;
			if (sceneActorType != ESceneActorType.Npc)
			{
				if (sceneActorType == ESceneActorType.AttackCityMonster)
				{
					ulong monsterGuid = (ulong)sceneActorId;
					result = this.GetAttackCityMonsterMovePath(monsterGuid);
				}
			}
			else
			{
				int npcId = (int)sceneActorId;
				result = this.GetNpcMovePath(npcId);
			}
			return result;
		}

		// Token: 0x0600AC79 RID: 44153 RVA: 0x00251A84 File Offset: 0x0024FE84
		private static void GetSceneActorMoveTargetPosition(ref bool isSceneActorExist, ref Vector3 sceneActorPosition, ClientSystemTown systemTown, object sceneActorId, ESceneActorType sceneActorType = ESceneActorType.Npc)
		{
			if (sceneActorType == ESceneActorType.Npc)
			{
				int npcID = (int)sceneActorId;
				ISceneNPCInfoData npcInfo = systemTown.GetNpcInfo(npcID);
				if (npcInfo == null)
				{
					return;
				}
				isSceneActorExist = true;
				sceneActorPosition = systemTown.GetValidTargetPosition(systemTown.MainPlayer.ActorData.MoveData.Position, npcInfo.GetEntityInfo().GetPosition(), npcInfo.GetMinFindRange(), npcInfo.GetMaxFindRange());
			}
			else if (sceneActorType == ESceneActorType.AttackCityMonster)
			{
				ulong num = (ulong)sceneActorId;
				if (DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneNpcByNpcGuid(num) == null)
				{
					Logger.LogErrorFormat("AutoFindPath sceneNpc info  is not exist and monster guid is {0}", new object[]
					{
						num
					});
					return;
				}
				BeTownNPC townAttackCityMonsterByGuid = systemTown.GetTownAttackCityMonsterByGuid(num);
				if (townAttackCityMonsterByGuid == null)
				{
					Logger.LogErrorFormat("AutoFindPath townAttackCityMonster is not exist and monsterGuid is {0}", new object[]
					{
						num
					});
					return;
				}
				Vector3 position = townAttackCityMonsterByGuid.ActorData.MoveData.Position;
				Vector2 a_minRange;
				a_minRange..ctor(0.5f, 0.5f);
				Vector2 a_maxRange;
				a_maxRange..ctor(2f, 2f);
				sceneActorPosition = systemTown.GetValidTargetPosition(systemTown.MainPlayer.ActorData.MoveData.Position, position, a_minRange, a_maxRange);
				isSceneActorExist = true;
			}
		}

		// Token: 0x0600AC7A RID: 44154 RVA: 0x00251BB4 File Offset: 0x0024FFB4
		private List<Vector3> GetNpcMovePath(int npcId)
		{
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(npcId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			List<Vector3> list = new List<Vector3>();
			for (int i = 0; i < tableItem.MapID.Count; i++)
			{
				List<Vector3> movePath = this._systemTown.GetMovePath(tableItem.MapID[i]);
				if (i == 0)
				{
					list = movePath;
				}
				else if (movePath.Count < list.Count)
				{
					list = movePath;
				}
			}
			return list;
		}

		// Token: 0x0600AC7B RID: 44155 RVA: 0x00251C3C File Offset: 0x0025003C
		private List<Vector3> GetAttackCityMonsterMovePath(ulong monsterGuid)
		{
			uint sceneIdByNpcGuid = DataManager<AttackCityMonsterDataManager>.GetInstance().GetSceneIdByNpcGuid(monsterGuid);
			if (sceneIdByNpcGuid == 0U)
			{
				Logger.LogErrorFormat("The scene is not exisit and monsterGuid is {0}", new object[]
				{
					monsterGuid
				});
				return null;
			}
			return this._systemTown.GetMovePath((int)sceneIdByNpcGuid);
		}

		// Token: 0x0600AC7C RID: 44156 RVA: 0x00251C84 File Offset: 0x00250084
		public void CreateMissionLink(uint iMissionID)
		{
			this.linkedDoorList.Clear();
			int iNpcID = 0;
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue(iMissionID, out singleMissionInfo))
			{
				return;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iMissionID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (singleMissionInfo.status == 0)
			{
				if (tableItem.AcceptType == MissionTable.eAcceptType.ACT_NPC)
				{
					NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.MissionTakeNpc, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						BeTownNPC townNpcByNpcId = this._systemTown.GetTownNpcByNpcId(tableItem.MissionTakeNpc);
						if (townNpcByNpcId != null)
						{
							this.linkedDoorList.Add(townNpcByNpcId.ActorData.MoveData.Position);
						}
						else
						{
							this.linkedDoorList = this.GetNpcMovePath(tableItem.MissionTakeNpc);
						}
						iNpcID = tableItem.MissionTakeNpc;
					}
				}
			}
			else if (singleMissionInfo.status == 1)
			{
				int dungenSceneID = this._systemTown.GetDungenSceneID(tableItem.MapID);
				this.linkedDoorList = this._systemTown.GetMovePath(dungenSceneID);
			}
			else if (singleMissionInfo.status == 2 && tableItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_NPC)
			{
				NpcTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(tableItem.MissionFinishNpc, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					BeTownNPC townNpcByNpcId2 = this._systemTown.GetTownNpcByNpcId(tableItem.MissionFinishNpc);
					if (townNpcByNpcId2 != null)
					{
						this.linkedDoorList.Add(townNpcByNpcId2.ActorData.MoveData.Position);
					}
					else
					{
						this.linkedDoorList = this.GetNpcMovePath(tableItem.MissionFinishNpc);
					}
					iNpcID = tableItem.MissionFinishNpc;
				}
			}
			if (this.linkedDoorList.Count == 0)
			{
				this._EndTrace();
				return;
			}
			this._BeginTrace(iNpcID, this.linkedDoorList[0]);
		}

		// Token: 0x0600AC7D RID: 44157 RVA: 0x00251E58 File Offset: 0x00250258
		public void CommandMoveToScene(int a_sceneID)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			BeTownPlayerMain.CommandStopAutoMove();
			List<Vector3> movePath = this._systemTown.GetMovePath(a_sceneID);
			if (movePath.Count > 0)
			{
				BeTownPlayerMain.ms_autoMoveCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(BeTownPlayerMain._AsyncMoveToDungeon(this._systemTown, movePath));
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("common_cannot_auto_move"), null, string.Empty, false);
				Logger.LogErrorFormat("CommandMoveToDungeon. doorList is null!", new object[0]);
			}
		}

		// Token: 0x0600AC7E RID: 44158 RVA: 0x00251ED5 File Offset: 0x002502D5
		public void CommandMoveToScene(int a_sceneID, Vector3 a_vecPos)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			BeTownPlayerMain.CommandStopAutoMove();
			BeTownPlayerMain.ms_autoMoveCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(BeTownPlayerMain._AsyncMoveToScene(this._systemTown, a_sceneID, a_vecPos));
		}

		// Token: 0x0600AC7F RID: 44159 RVA: 0x00251F04 File Offset: 0x00250304
		private static IEnumerator _AsyncMoveToScene(ClientSystemTown a_systemTown, int a_nTargetSceneID, Vector3 a_vecTargetPos)
		{
			yield return BeTownPlayerMain._AsyncAcrossScenes(a_systemTown, a_nTargetSceneID);
			if (!BeTownPlayerMain.ms_bAutoMoveSuccessed)
			{
				BeTownPlayerMain.OnAutoMoveFail.Invoke();
				BeTownPlayerMain.ms_autoMoveCoroutine = null;
				BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
				yield break;
			}
			yield return BeTownPlayerMain._AsyncMoveToTargetPos(a_systemTown, a_vecTargetPos);
			if (!BeTownPlayerMain.ms_bAutoMoveSuccessed)
			{
				BeTownPlayerMain.OnAutoMoveFail.Invoke();
			}
			else
			{
				BeTownPlayerMain.OnAutoMoveSuccess.Invoke();
			}
			BeTownPlayerMain.ms_autoMoveCoroutine = null;
			BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
			yield break;
		}

		// Token: 0x0600AC80 RID: 44160 RVA: 0x00251F30 File Offset: 0x00250330
		private static IEnumerator _AsyncAcrossScenes(ClientSystemTown systemTown, int a_nTargetSceneID)
		{
			BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
			if (!BeTownPlayerMain._CheckSystemValid(systemTown))
			{
				BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
				yield break;
			}
			if (systemTown.CurrentSceneID == a_nTargetSceneID)
			{
				BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
				yield break;
			}
			List<Vector3> doorList = systemTown.GetMovePath(a_nTargetSceneID);
			if (doorList.Count <= 0)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("common_cannot_auto_move"), null, string.Empty, false);
				Logger.LogErrorFormat("跨地图寻路 >>> 无法自动移动到目标场景（ID:{0}）", new object[]
				{
					a_nTargetSceneID
				});
				BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
				yield break;
			}
			while (doorList.Count > 0)
			{
				if (!BeTownPlayerMain._CheckSystemValid(systemTown))
				{
					BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
					yield break;
				}
				Vector3 targetPos = doorList[0];
				doorList.RemoveAt(0);
				systemTown.MainPlayer.CommandMoveTo(targetPos);
				if (systemTown.MainPlayer.MoveState != BeTownPlayerMain.EMoveState.AutoMoving)
				{
					BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
					yield break;
				}
				int oldSceneID = systemTown.CurrentSceneID;
				while (oldSceneID == systemTown.CurrentSceneID)
				{
					if (!BeTownPlayerMain._CheckSystemValid(systemTown))
					{
						BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
						yield break;
					}
					if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
					{
						yield return Yielders.EndOfFrame;
					}
					else
					{
						if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.Moveing)
						{
							BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
							yield break;
						}
						if (!systemTown.MainPlayer._IsInSameGrid(targetPos, systemTown.MainPlayer.ActorData.MoveData.Position))
						{
							BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
							yield break;
						}
						yield return Yielders.EndOfFrame;
					}
				}
			}
			yield break;
		}

		// Token: 0x0600AC81 RID: 44161 RVA: 0x00251F54 File Offset: 0x00250354
		private static IEnumerator _AsyncMoveToTargetPos(ClientSystemTown a_systemTown, Vector3 a_pos)
		{
			BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
			if (!BeTownPlayerMain._CheckSystemValid(a_systemTown))
			{
				BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
				yield break;
			}
			a_systemTown.MainPlayer.CommandMoveTo(a_pos);
			while (BeTownPlayerMain._CheckSystemValid(a_systemTown))
			{
				if (a_systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
				{
					yield return Yielders.EndOfFrame;
				}
				else
				{
					if (a_systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.Moveing)
					{
						BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
						yield break;
					}
					if (a_systemTown.MainPlayer._IsInSameGrid(a_pos, a_systemTown.MainPlayer.ActorData.MoveData.Position))
					{
						BeTownPlayerMain.ms_bAutoMoveSuccessed = true;
					}
					else
					{
						BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
					}
					yield break;
				}
			}
			BeTownPlayerMain.ms_bAutoMoveSuccessed = false;
			yield break;
			yield break;
		}

		// Token: 0x0600AC82 RID: 44162 RVA: 0x00251F78 File Offset: 0x00250378
		public void CommandMoveToDungeon(int dungeonID)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			BeTownPlayerMain.CommandStopAutoMove();
			int dungenSceneID = this._systemTown.GetDungenSceneID(dungeonID);
			List<Vector3> movePath = this._systemTown.GetMovePath(dungenSceneID);
			if (movePath.Count > 0)
			{
				BeTownPlayerMain.ms_autoMoveCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(BeTownPlayerMain._AsyncMoveToDungeon(this._systemTown, movePath));
			}
			else
			{
				SystemNotifyManager.SysNotifyMsgBoxOK(TR.Value("common_cannot_auto_move"), null, string.Empty, false);
				Logger.LogErrorFormat("CommandMoveToDungeon id={0}.找不到路径!", new object[]
				{
					dungeonID
				});
			}
		}

		// Token: 0x0600AC83 RID: 44163 RVA: 0x0025200C File Offset: 0x0025040C
		private static IEnumerator _AsyncMoveToDungeon(ClientSystemTown systemTown, List<Vector3> doorList)
		{
			while (doorList.Count > 0)
			{
				if (!BeTownPlayerMain._CheckSystemValid(systemTown))
				{
					BeTownPlayerMain.OnAutoMoveFail.Invoke();
					BeTownPlayerMain.ms_autoMoveCoroutine = null;
					yield break;
				}
				Vector3 targetPos = doorList[0];
				doorList.RemoveAt(0);
				systemTown.MainPlayer.CommandMoveTo(targetPos);
				if (systemTown.MainPlayer.MoveState != BeTownPlayerMain.EMoveState.AutoMoving)
				{
					BeTownPlayerMain.OnAutoMoveFail.Invoke();
					BeTownPlayerMain.ms_autoMoveCoroutine = null;
					yield break;
				}
				int oldSceneID = systemTown.CurrentSceneID;
				while (oldSceneID == systemTown.CurrentSceneID)
				{
					if (!BeTownPlayerMain._CheckSystemValid(systemTown))
					{
						BeTownPlayerMain.OnAutoMoveFail.Invoke();
						BeTownPlayerMain.ms_autoMoveCoroutine = null;
						yield break;
					}
					if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
					{
						yield return Yielders.EndOfFrame;
					}
					else
					{
						if (systemTown.MainPlayer.MoveState == BeTownPlayerMain.EMoveState.Moveing)
						{
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
							BeTownPlayerMain.ms_autoMoveCoroutine = null;
							yield break;
						}
						if (!systemTown.MainPlayer._IsInSameGrid(targetPos, systemTown.MainPlayer.ActorData.MoveData.Position))
						{
							Vector3 position = systemTown.MainPlayer.ActorData.MoveData.Position;
							BeTownPlayerMain.OnAutoMoveFail.Invoke();
							BeTownPlayerMain.ms_autoMoveCoroutine = null;
							yield break;
						}
						yield return Yielders.EndOfFrame;
					}
				}
			}
			BeTownPlayerMain.ms_autoMoveCoroutine = null;
			BeTownPlayerMain.OnAutoMoveSuccess.Invoke();
			yield break;
		}

		// Token: 0x0600AC84 RID: 44164 RVA: 0x0025202E File Offset: 0x0025042E
		public static void CommandStopAutoMove()
		{
			if (BeTownPlayerMain.ms_autoMoveCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(BeTownPlayerMain.ms_autoMoveCoroutine);
				BeTownPlayerMain.ms_autoMoveCoroutine = null;
				if (BeTownPlayerMain.OnAutoMoveFail != null)
				{
					BeTownPlayerMain.OnAutoMoveFail.Invoke();
				}
			}
		}

		// Token: 0x0600AC85 RID: 44165 RVA: 0x00252063 File Offset: 0x00250463
		public void CommandMoveToTargetPos(Vector3 pos)
		{
			if (!this.m_bEnable)
			{
				return;
			}
		}

		// Token: 0x0600AC86 RID: 44166 RVA: 0x00252071 File Offset: 0x00250471
		public sealed override void CommandMoveForward(Vector3 targetDirection)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			targetDirection.y = 0f;
			base.CommandMoveForward(targetDirection);
			this._UpdateMoveState();
		}

		// Token: 0x0600AC87 RID: 44167 RVA: 0x00252098 File Offset: 0x00250498
		public sealed override void CommandDirectMoveTo(Vector3 targetPosition)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			targetPosition.y = 0f;
			base.CommandDirectMoveTo(targetPosition);
			this._UpdateMoveState();
		}

		// Token: 0x0600AC88 RID: 44168 RVA: 0x002520BF File Offset: 0x002504BF
		public sealed override void CommandMoveTo(Vector3 targetPosition)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			targetPosition.y = 0f;
			base.CommandMoveTo(targetPosition);
			this._UpdateMoveState();
		}

		// Token: 0x0600AC89 RID: 44169 RVA: 0x002520E6 File Offset: 0x002504E6
		public sealed override void CommandStopMove()
		{
			if (!this.m_bEnable)
			{
				return;
			}
			base.CommandStopMove();
			this._UpdateMoveState();
		}

		// Token: 0x0600AC8A RID: 44170 RVA: 0x00252100 File Offset: 0x00250500
		public sealed override void UpdateMove(float timeElapsed)
		{
			if (!this.m_bEnable)
			{
				return;
			}
			if (this._systemTown.IsNet)
			{
				this._SyncMove();
			}
			base.UpdateMove(timeElapsed);
			if (this.MoveState == BeTownPlayerMain.EMoveState.Moveing)
			{
				BeTownPlayerMain.OnMoveing.Invoke(base.ActorData.MoveData.Position);
			}
			else if (this.MoveState == BeTownPlayerMain.EMoveState.AutoMoving)
			{
				BeTownPlayerMain.OnAutoMoving.Invoke(base.ActorData.MoveData.Position);
			}
		}

		// Token: 0x0600AC8B RID: 44171 RVA: 0x00252187 File Offset: 0x00250587
		public sealed override void CreatePet(int a_nPetID)
		{
			base.CreatePet(a_nPetID);
			if (this.m_townPet != null)
			{
				this.m_townPet.SetDialogEnable(true);
			}
		}

		// Token: 0x0600AC8C RID: 44172 RVA: 0x002521A7 File Offset: 0x002505A7
		protected static bool _CheckSystemValid(ClientSystemTown a_system)
		{
			return a_system != null && a_system.MainPlayer != null;
		}

		// Token: 0x0600AC8D RID: 44173 RVA: 0x002521C0 File Offset: 0x002505C0
		protected BeTownPlayerMain.EMoveState _CalculateMoveState()
		{
			BeTownPlayerMain.EMoveState result = BeTownPlayerMain.EMoveState.Idle;
			if (base.ActorData.MoveData.MoveType == EActorMoveType.Invalid)
			{
				result = BeTownPlayerMain.EMoveState.Idle;
			}
			else if (base.ActorData.MoveData.MoveType == EActorMoveType.TargetDir)
			{
				result = BeTownPlayerMain.EMoveState.Moveing;
			}
			else if (base.ActorData.MoveData.MoveType == EActorMoveType.TargetPos)
			{
				result = BeTownPlayerMain.EMoveState.AutoMoving;
			}
			return result;
		}

		// Token: 0x0600AC8E RID: 44174 RVA: 0x00252224 File Offset: 0x00250624
		protected void _UpdateMoveState()
		{
			BeTownPlayerMain.EMoveState emoveState = this._CalculateMoveState();
			if (this.MoveState != emoveState)
			{
				BeTownPlayerMain.EMoveState moveState = this.MoveState;
				this.MoveState = emoveState;
				BeTownPlayerMain.OnMoveStateChanged.Invoke(moveState, this.MoveState);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PlayerMoveStateChanged, moveState, this.MoveState, null, null);
			}
		}

		// Token: 0x0600AC8F RID: 44175 RVA: 0x00252288 File Offset: 0x00250688
		protected void _SyncMove()
		{
			ActorMoveData moveData = base.ActorData.MoveData;
			if (this.m_oldMoveType != moveData.MoveType)
			{
				if (moveData.MoveType == EActorMoveType.TargetDir)
				{
					this.m_oldMoveDir = moveData.TargetDirection;
					this.m_oldTargetPos = Vector3.zero;
					this.m_moveDir = moveData.TargetDirection;
				}
				else if (moveData.MoveType == EActorMoveType.TargetPos)
				{
					this.m_oldMoveDir = Vector3.zero;
					this.m_oldTargetPos = moveData.TargetPosition;
					this.m_moveDir = (moveData.TargetPosition - moveData.Position).normalized;
				}
				else
				{
					this.m_oldMoveDir = Vector3.zero;
					this.m_oldTargetPos = Vector3.zero;
					this.m_moveDir = Vector3.zero;
				}
				this.m_oldMoveType = moveData.MoveType;
				this._SendSyncMoveMessage();
			}
			else if (moveData.MoveType != EActorMoveType.Invalid)
			{
				bool flag = false;
				if (moveData.MoveType == EActorMoveType.TargetDir && this.m_oldMoveDir != moveData.TargetDirection)
				{
					this.m_oldMoveDir = moveData.TargetDirection;
					this.m_moveDir = moveData.TargetDirection;
					this._SendSyncMoveMessage();
					flag = true;
				}
				else if (moveData.MoveType == EActorMoveType.TargetPos && this.m_oldTargetPos != moveData.TargetPosition)
				{
					this.m_oldTargetPos = moveData.TargetPosition;
					Vector3 normalized = (moveData.TargetPosition - moveData.Position).normalized;
					if (this.m_moveDir != normalized)
					{
						this.m_moveDir = normalized;
						this._SendSyncMoveMessage();
						flag = true;
					}
				}
				if (!flag)
				{
					this.m_syncElapsed += Time.deltaTime;
					if (this.m_syncElapsed > 0.2f)
					{
						this._SendSyncMoveMessage();
						this.m_syncElapsed = 0f;
					}
				}
			}
		}

		// Token: 0x0600AC90 RID: 44176 RVA: 0x0025245C File Offset: 0x0025085C
		protected void _SendSyncMoveMessage()
		{
			SceneMoveRequire sceneMoveRequire = new SceneMoveRequire
			{
				dir = new SceneDir
				{
					x = (short)(this.m_moveDir.x * this.m_axisScale),
					y = (short)(this.m_moveDir.z * this.m_axisScale),
					faceRight = ((!base.ActorData.MoveData.FaceRight) ? 0 : 1)
				},
				pos = new ScenePosition
				{
					x = (uint)(base.ActorData.MoveData.ServerPosition.x * this.m_axisScale),
					y = (uint)(base.ActorData.MoveData.ServerPosition.z * this.m_axisScale)
				}
			};
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				sceneMoveRequire.clientSceneId = (uint)clientSystemTown.CurrentSceneID;
			}
			NetManager.Instance().SendCommand<SceneMoveRequire>(ServerType.GATE_SERVER, sceneMoveRequire);
		}

		// Token: 0x0600AC91 RID: 44177 RVA: 0x00252560 File Offset: 0x00250960
		protected bool _IsInSameGrid(Vector3 posA, Vector3 posB)
		{
			PathFinding.Grid grid = new PathFinding.Grid(this._systemTown.GridInfo, posA);
			PathFinding.Grid grid2 = new PathFinding.Grid(this._systemTown.GridInfo, posB);
			return grid.X == grid2.X && grid.Y == grid2.Y;
		}

		// Token: 0x0600AC92 RID: 44178 RVA: 0x002525BC File Offset: 0x002509BC
		public int OwnerResistMagicValue()
		{
			return BeUtility.GetMainActorResist();
		}

		// Token: 0x0600AC93 RID: 44179 RVA: 0x002525D0 File Offset: 0x002509D0
		public void SyncResistMagicValue()
		{
			int num = this.OwnerResistMagicValue();
			if (num == -1)
			{
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance() != null)
			{
				if (DataManager<PlayerBaseData>.GetInstance().ResistMagicValue == num)
				{
					return;
				}
				DataManager<PlayerBaseData>.GetInstance().ResistMagicValue = num;
			}
			SceneSyncResistMagicReq cmd = new SceneSyncResistMagicReq
			{
				resist_magic = (uint)num
			};
			if (NetManager.Instance() != null)
			{
				NetManager.Instance().SendCommand<SceneSyncResistMagicReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x040060B0 RID: 24752
		private bool m_bEnable = true;

		// Token: 0x040060B1 RID: 24753
		private TaskGuideModelArrow comTaskGuideModelArrow;

		// Token: 0x040060B2 RID: 24754
		private static Coroutine ms_autoMoveCoroutine;

		// Token: 0x040060B3 RID: 24755
		private List<Vector3> linkedDoorList = new List<Vector3>();

		// Token: 0x040060B4 RID: 24756
		private static bool ms_bAutoMoveSuccessed = true;

		// Token: 0x040060B5 RID: 24757
		protected Vector3 m_moveDir = Vector3.zero;

		// Token: 0x040060B6 RID: 24758
		protected Vector3 m_oldMoveDir = Vector3.zero;

		// Token: 0x040060B7 RID: 24759
		protected Vector3 m_oldTargetPos = Vector3.zero;

		// Token: 0x040060B8 RID: 24760
		protected EActorMoveType m_oldMoveType = EActorMoveType.Invalid;

		// Token: 0x040060B9 RID: 24761
		protected float m_syncElapsed;

		// Token: 0x040060BA RID: 24762
		protected float m_axisScale = 10000f;

		// Token: 0x02001196 RID: 4502
		public enum EMoveState
		{
			// Token: 0x040060BC RID: 24764
			Invalid = -1,
			// Token: 0x040060BD RID: 24765
			Idle,
			// Token: 0x040060BE RID: 24766
			Moveing,
			// Token: 0x040060BF RID: 24767
			AutoMoving
		}

		// Token: 0x02001197 RID: 4503
		public class MoveStateChangedEvent : UnityEvent<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>
		{
		}

		// Token: 0x02001198 RID: 4504
		public class AutoMoveSuccessEvent : UnityEvent
		{
		}

		// Token: 0x02001199 RID: 4505
		public class AutoMoveFailEvent : UnityEvent
		{
		}

		// Token: 0x0200119A RID: 4506
		public class MoveingEvent : UnityEvent<Vector3>
		{
		}

		// Token: 0x0200119B RID: 4507
		public class AutoMoveingEvent : UnityEvent<Vector3>
		{
		}
	}
}
