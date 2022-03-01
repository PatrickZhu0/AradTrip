using System;
using System.Collections.Generic;
using Network;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020011E3 RID: 4579
	public class AttackCityMonsterDataManager : DataManager<AttackCityMonsterDataManager>
	{
		// Token: 0x0600B017 RID: 45079 RVA: 0x0026AD43 File Offset: 0x00269143
		public override void Initialize()
		{
			this.BindEvents();
			this.InitData();
		}

		// Token: 0x0600B018 RID: 45080 RVA: 0x0026AD54 File Offset: 0x00269154
		private void InitData()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(400, string.Empty, string.Empty);
			if (tableItem == null || tableItem.Value <= 0)
			{
				this._attackCityMonsterTotalTimes = 0;
			}
			else
			{
				this._attackCityMonsterTotalTimes = tableItem.Value;
			}
		}

		// Token: 0x0600B019 RID: 45081 RVA: 0x0026ADA5 File Offset: 0x002691A5
		public override void Clear()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600B01A RID: 45082 RVA: 0x0026ADB3 File Offset: 0x002691B3
		private void ClearData()
		{
			this._attackCityMonsterTotalTimes = 0;
			this._attackCityMonsterBeatTimes = 0;
			this._nearestByMonsterGuid = 0UL;
			this._missionMonsterGuid = 0UL;
			this._eOpenTalkFrameType = EOpenTalkFrameType.Invalid;
			this.ClearSceneNpcDataModelList();
		}

		// Token: 0x0600B01B RID: 45083 RVA: 0x0026ADE0 File Offset: 0x002691E0
		private void ClearSceneNpcDataModelList()
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (this._sceneNpcDataModelList[i] != null)
				{
					this._sceneNpcDataModelList[i].NpcsList.Clear();
				}
			}
			this._sceneNpcDataModelList.Clear();
		}

		// Token: 0x0600B01C RID: 45084 RVA: 0x0026AE3C File Offset: 0x0026923C
		private void BindEvents()
		{
			NetProcess.AddMsgHandler(500621U, new Action<MsgDATA>(this.NetSyncSceneNpcList));
			NetProcess.AddMsgHandler(500622U, new Action<MsgDATA>(this.NetSyncSceneNpcAdd));
			NetProcess.AddMsgHandler(500623U, new Action<MsgDATA>(this.NetSyncSceneNpcDel));
			NetProcess.AddMsgHandler(500624U, new Action<MsgDATA>(this.NetSyncSceneNpcUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
		}

		// Token: 0x0600B01D RID: 45085 RVA: 0x0026AEBC File Offset: 0x002692BC
		private void UnBindEvents()
		{
			NetProcess.RemoveMsgHandler(500621U, new Action<MsgDATA>(this.NetSyncSceneNpcList));
			NetProcess.RemoveMsgHandler(500622U, new Action<MsgDATA>(this.NetSyncSceneNpcAdd));
			NetProcess.RemoveMsgHandler(500623U, new Action<MsgDATA>(this.NetSyncSceneNpcDel));
			NetProcess.RemoveMsgHandler(500624U, new Action<MsgDATA>(this.NetSyncSceneNpcUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
		}

		// Token: 0x0600B01E RID: 45086 RVA: 0x0026AF3C File Offset: 0x0026933C
		private void NetSyncSceneNpcList(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("SyncSceneNpcList ==> msgData is null", new object[0]);
				return;
			}
			SceneNpcList sceneNpcList = new SceneNpcList();
			sceneNpcList.decode(msgData.bytes);
			this.ClearSceneNpcDataModelList();
			for (int i = 0; i < sceneNpcList.infoes.Length; i++)
			{
				SceneNpcInfo sceneNpcInfo = sceneNpcList.infoes[i];
				SceneNpcDataModel item = this.CreateSceneNpcDataModel(sceneNpcInfo);
				this._sceneNpcDataModelList.Add(item);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SyncAttackCityMonsterList, null, null, null, null);
		}

		// Token: 0x0600B01F RID: 45087 RVA: 0x0026AFC4 File Offset: 0x002693C4
		private void NetSyncSceneNpcAdd(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("syncSceneNpcAdd ==> msgData is null", new object[0]);
				return;
			}
			SceneNpcAdd sceneNpcAdd = new SceneNpcAdd();
			sceneNpcAdd.decode(msgData.bytes);
			if (sceneNpcAdd.data == null || sceneNpcAdd.data.Length <= 0)
			{
				return;
			}
			for (int i = 0; i < sceneNpcAdd.data.Length; i++)
			{
				SceneNpcInfo sceneNpcInfo = sceneNpcAdd.data[i];
				SceneNpcDataModel sceneNpcDataModel = this.GetSceneNpcDataModel(sceneNpcInfo.sceneId);
				if (sceneNpcDataModel == null)
				{
					sceneNpcDataModel = this.CreateSceneNpcDataModel(sceneNpcInfo);
					this._sceneNpcDataModelList.Add(sceneNpcDataModel);
				}
				else
				{
					for (int j = 0; j < sceneNpcInfo.npcs.Length; j++)
					{
						sceneNpcDataModel.NpcsList.Add(sceneNpcInfo.npcs[j]);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SyncAttackCityMonsterAdd, null, null, null, null);
		}

		// Token: 0x0600B020 RID: 45088 RVA: 0x0026B0A8 File Offset: 0x002694A8
		private void NetSyncSceneNpcDel(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("SyncSceneNpcDel ==> msgData is null", new object[0]);
				return;
			}
			SceneNpcDel sceneNpcDel = new SceneNpcDel();
			sceneNpcDel.decode(msgData.bytes);
			if (sceneNpcDel.guids == null || sceneNpcDel.guids.Length <= 0)
			{
				return;
			}
			for (int i = 0; i < sceneNpcDel.guids.Length; i++)
			{
				this.RemoveSceneNpcDataModel(sceneNpcDel.guids[i]);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SyncAttackCityMonsterDel, null, null, null, null);
		}

		// Token: 0x0600B021 RID: 45089 RVA: 0x0026B134 File Offset: 0x00269534
		private void NetSyncSceneNpcUpdate(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("SyncSceneNpcUpdate ==> msgData is null", new object[0]);
				return;
			}
			SceneNpcUpdate sceneNpcUpdate = new SceneNpcUpdate();
			sceneNpcUpdate.decode(msgData.bytes);
			if (sceneNpcUpdate.data == null || sceneNpcUpdate.data.sceneId <= 0U || sceneNpcUpdate.data.npcs == null || sceneNpcUpdate.data.npcs.Length <= 0)
			{
				return;
			}
			SceneNpcDataModel sceneNpcDataModel = this.GetSceneNpcDataModel(sceneNpcUpdate.data.sceneId);
			if (sceneNpcDataModel == null)
			{
				return;
			}
			for (int i = 0; i < sceneNpcUpdate.data.npcs.Length; i++)
			{
				SceneNpc sceneNpc = sceneNpcUpdate.data.npcs[i];
				if (sceneNpc != null)
				{
					for (int j = 0; j < sceneNpcDataModel.NpcsList.Count; j++)
					{
						SceneNpc sceneNpc2 = sceneNpcDataModel.NpcsList[j];
						if (sceneNpc2 != null)
						{
							if (sceneNpc.guid == sceneNpc2.guid)
							{
								sceneNpcDataModel.NpcsList[j] = sceneNpc;
							}
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SyncAttackCityMonsterUpdate, null, null, null, null);
		}

		// Token: 0x0600B022 RID: 45090 RVA: 0x0026B270 File Offset: 0x00269670
		private SceneNpcDataModel CreateSceneNpcDataModel(SceneNpcInfo sceneNpcInfo)
		{
			SceneNpcDataModel sceneNpcDataModel = new SceneNpcDataModel();
			sceneNpcDataModel.SceneId = sceneNpcInfo.sceneId;
			for (int i = 0; i < sceneNpcInfo.npcs.Length; i++)
			{
				sceneNpcDataModel.NpcsList.Add(sceneNpcInfo.npcs[i]);
			}
			return sceneNpcDataModel;
		}

		// Token: 0x0600B023 RID: 45091 RVA: 0x0026B2BC File Offset: 0x002696BC
		private SceneNpcDataModel GetSceneNpcDataModel(uint sceneId)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (this._sceneNpcDataModelList[i].SceneId == sceneId)
				{
					return this._sceneNpcDataModelList[i];
				}
			}
			return null;
		}

		// Token: 0x0600B024 RID: 45092 RVA: 0x0026B30C File Offset: 0x0026970C
		private void RemoveSceneNpcDataModel(ulong guid)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (this._sceneNpcDataModelList[i].NpcsList.Count > 0)
				{
					for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
					{
						if (this._sceneNpcDataModelList[i].NpcsList[j].guid == guid)
						{
							this._sceneNpcDataModelList[i].NpcsList.RemoveAt(j);
							return;
						}
					}
				}
			}
		}

		// Token: 0x0600B025 RID: 45093 RVA: 0x0026B3B7 File Offset: 0x002697B7
		public void ShowAttackCityMonsterDialogFrame(ulong npcGuid)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AttackCityMonsterTalkFrame>(FrameLayer.Middle, npcGuid, string.Empty);
		}

		// Token: 0x0600B026 RID: 45094 RVA: 0x0026B3D0 File Offset: 0x002697D0
		public void EnterFindPathProcessByTeamDuplication()
		{
			if (!this.IsExistActivityTypeCityMonster())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_no_activity_monster"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamListFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamMyFrame>(null, false);
			this.CommandMoveToNearestByAttackCityMonster();
			this.SetOpenTalkFrameType(EOpenTalkFrameType.TeamDuplication);
		}

		// Token: 0x0600B027 RID: 45095 RVA: 0x0026B430 File Offset: 0x00269830
		public void EnterFindPathProcessByActivityDuplication()
		{
			if (!this.IsExistActivityTypeCityMonster())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_no_activity_monster"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActivityDungeonFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityDungeonFrame>(null, false);
			}
			this.CommandMoveToNearestByAttackCityMonster();
			this.SetOpenTalkFrameType(EOpenTalkFrameType.ActivityDuplication);
		}

		// Token: 0x0600B028 RID: 45096 RVA: 0x0026B484 File Offset: 0x00269884
		public void EnterFindPathProcessByMissionContent(Dictionary<string, string> content, UnityAction onSucceed = null, UnityAction onFailed = null)
		{
			if (content == null || content.Count <= 0)
			{
				Logger.LogErrorFormat("EnterAttackCityMonsterByMissionContent content is null", new object[0]);
				return;
			}
			string s;
			if (content.TryGetValue("npc_guid", out s))
			{
				ulong num = ulong.Parse(s);
				if (num > 0UL)
				{
					this.EnterFindPathProcessByMonsterGuid(num, onSucceed, onFailed);
					return;
				}
			}
		}

		// Token: 0x0600B029 RID: 45097 RVA: 0x0026B4E0 File Offset: 0x002698E0
		private void EnterFindPathProcessByMonsterGuid(ulong monsterGuid, UnityAction onSucceed = null, UnityAction onFailed = null)
		{
			if (monsterGuid == this._missionMonsterGuid)
			{
				return;
			}
			if (!this.IsSceneDataContainNpcData(monsterGuid, 0U))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("monster_attack_city_no_task_monster"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			this._missionMonsterGuid = monsterGuid;
			this.SetOpenTalkFrameType(EOpenTalkFrameType.Mission);
			this.CommandMoveToAttackCityMonsterByGuid(monsterGuid, null, null);
		}

		// Token: 0x0600B02A RID: 45098 RVA: 0x0026B530 File Offset: 0x00269930
		private void CommandMoveToNearestByAttackCityMonster()
		{
			if (this._nearestByMonsterGuid != 0UL && this.IsSceneDataContainNpcData(this._nearestByMonsterGuid, 0U))
			{
				return;
			}
			this._nearestByMonsterGuid = 0UL;
			this.GetNearestByAttackCityMonsterGuid(ref this._nearestByMonsterGuid);
			if (this._nearestByMonsterGuid == 0UL)
			{
				return;
			}
			this.CommandMoveToAttackCityMonsterByGuid(this._nearestByMonsterGuid, null, null);
		}

		// Token: 0x0600B02B RID: 45099 RVA: 0x0026B590 File Offset: 0x00269990
		private void CommandMoveToAttackCityMonsterByGuid(ulong npcGuid, UnityAction onSucceed = null, UnityAction onFailed = null)
		{
			SceneNpc sceneNpcByNpcGuid = this.GetSceneNpcByNpcGuid(npcGuid);
			if (sceneNpcByNpcGuid == null)
			{
				Logger.LogErrorFormat("The sceneNpc is not exist and npcGuid is {0}", new object[]
				{
					npcGuid
				});
				return;
			}
			if (this.GetSceneIdByNpcGuid(npcGuid) == 0U)
			{
				Logger.LogErrorFormat("Scene is not exist and npcGuid is {0}", new object[]
				{
					npcGuid
				});
				return;
			}
			int id = (int)sceneNpcByNpcGuid.id;
			if (Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(id, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("npcItem is null or npcItem is not AttackCityMonster, monsterid is {0}", new object[]
				{
					sceneNpcByNpcGuid.id
				});
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogErrorFormat("ClientSystemTown is null", new object[0]);
				return;
			}
			if (clientSystemTown.MainPlayer == null)
			{
				Logger.LogErrorFormat("MainPlayer in clientSystemTown is null", new object[0]);
				return;
			}
			NpcParser.OnClickLink(npcGuid, id, ESceneActorType.AttackCityMonster, delegate()
			{
				if (onSucceed != null)
				{
					onSucceed.Invoke();
				}
				DataManager<AttackCityMonsterDataManager>.GetInstance().ShowAttackCityMonsterDialogFrame(npcGuid);
				this._nearestByMonsterGuid = 0UL;
				this._missionMonsterGuid = 0UL;
			}, delegate()
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				this._nearestByMonsterGuid = 0UL;
				this._missionMonsterGuid = 0UL;
			});
		}

		// Token: 0x0600B02C RID: 45100 RVA: 0x0026B6D2 File Offset: 0x00269AD2
		public EOpenTalkFrameType GetOpenTalkFrameType()
		{
			return this._eOpenTalkFrameType;
		}

		// Token: 0x0600B02D RID: 45101 RVA: 0x0026B6DA File Offset: 0x00269ADA
		public void SetOpenTalkFrameType(EOpenTalkFrameType openTalkFrameType)
		{
			this._eOpenTalkFrameType = openTalkFrameType;
		}

		// Token: 0x0600B02E RID: 45102 RVA: 0x0026B6E3 File Offset: 0x00269AE3
		public void ResetOpenTalkFrameType()
		{
			this._eOpenTalkFrameType = EOpenTalkFrameType.Invalid;
		}

		// Token: 0x0600B02F RID: 45103 RVA: 0x0026B6EC File Offset: 0x00269AEC
		public List<SceneNpc> GetSceneNpcsListBySceneId(int sceneId)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if ((ulong)this._sceneNpcDataModelList[i].SceneId == (ulong)((long)sceneId))
				{
					return this._sceneNpcDataModelList[i].NpcsList;
				}
			}
			return null;
		}

		// Token: 0x0600B030 RID: 45104 RVA: 0x0026B744 File Offset: 0x00269B44
		private List<SceneNpc> GetActivityMonsterDataModelBySceneId(int sceneId)
		{
			List<SceneNpc> list = new List<SceneNpc>();
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (this._sceneNpcDataModelList[i].SceneId == (uint)sceneId)
				{
					for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
					{
						if (this._sceneNpcDataModelList[i].NpcsList[j].funcType == 1)
						{
							list.Add(this._sceneNpcDataModelList[i].NpcsList[j]);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B031 RID: 45105 RVA: 0x0026B7F8 File Offset: 0x00269BF8
		public uint GetSceneIdByNpcGuid(ulong guid)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
				{
					if (this._sceneNpcDataModelList[i].NpcsList[j].guid == guid)
					{
						return this._sceneNpcDataModelList[i].SceneId;
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600B032 RID: 45106 RVA: 0x0026B880 File Offset: 0x00269C80
		public SceneNpc GetSceneNpcByNpcGuid(ulong guid)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
				{
					if (this._sceneNpcDataModelList[i].NpcsList[j].guid == guid)
					{
						return this._sceneNpcDataModelList[i].NpcsList[j];
					}
				}
			}
			return null;
		}

		// Token: 0x0600B033 RID: 45107 RVA: 0x0026B90C File Offset: 0x00269D0C
		private void GetNearestByAttackCityMonsterGuid(ref ulong monsterGuid)
		{
			if (this._sceneNpcDataModelList == null || this._sceneNpcDataModelList.Count <= 0)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (clientSystemTown.MainPlayer == null)
			{
				return;
			}
			List<SceneNpc> activityMonsterDataModelBySceneId = this.GetActivityMonsterDataModelBySceneId(clientSystemTown.CurrentSceneID);
			if (activityMonsterDataModelBySceneId != null && activityMonsterDataModelBySceneId.Count > 0)
			{
				monsterGuid = this.GetSceneNpcGuidByRandom(activityMonsterDataModelBySceneId);
				return;
			}
			int sceneId = 0;
			List<Vector3> list = null;
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				SceneNpcDataModel sceneNpcDataModel = this._sceneNpcDataModelList[i];
				if (sceneNpcDataModel != null && sceneNpcDataModel.NpcsList != null && sceneNpcDataModel.NpcsList.Count > 0)
				{
					activityMonsterDataModelBySceneId = this.GetActivityMonsterDataModelBySceneId((int)sceneNpcDataModel.SceneId);
					if (activityMonsterDataModelBySceneId != null && activityMonsterDataModelBySceneId.Count > 0)
					{
						uint sceneId2 = sceneNpcDataModel.SceneId;
						List<Vector3> movePath = clientSystemTown.GetMovePath((int)sceneId2);
						if (list == null)
						{
							list = movePath;
							sceneId = (int)sceneId2;
						}
						else if (movePath.Count > 0 && movePath.Count < list.Count)
						{
							list = movePath;
							sceneId = (int)sceneId2;
						}
					}
				}
			}
			if (list == null || list.Count <= 0)
			{
				return;
			}
			activityMonsterDataModelBySceneId = this.GetActivityMonsterDataModelBySceneId(sceneId);
			if (activityMonsterDataModelBySceneId != null && activityMonsterDataModelBySceneId.Count > 0)
			{
				monsterGuid = this.GetSceneNpcGuidByRandom(activityMonsterDataModelBySceneId);
				return;
			}
		}

		// Token: 0x0600B034 RID: 45108 RVA: 0x0026BA84 File Offset: 0x00269E84
		private ulong GetSceneNpcGuidByRandom(List<SceneNpc> sceneNpcList)
		{
			int count = sceneNpcList.Count;
			int num = Random.Range(0, count);
			if (num >= count)
			{
				num = count - 1;
			}
			if (num < 0)
			{
				num = 0;
			}
			SceneNpc sceneNpc = sceneNpcList[num];
			if (sceneNpc == null)
			{
				return 0UL;
			}
			return sceneNpc.guid;
		}

		// Token: 0x0600B035 RID: 45109 RVA: 0x0026BACB File Offset: 0x00269ECB
		public Vector3 GetAttackCityMonsterScenePosition(NpcPos npcPos)
		{
			return new Vector3((float)npcPos.x / 10000f, 0f, (float)npcPos.y / 10000f);
		}

		// Token: 0x0600B036 RID: 45110 RVA: 0x0026BAF4 File Offset: 0x00269EF4
		public bool IsSceneDataContainNpcData(ulong guid, uint sceneId = 0U)
		{
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (sceneId == 0U || this._sceneNpcDataModelList[i].SceneId == sceneId)
				{
					for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
					{
						if (this._sceneNpcDataModelList[i].NpcsList[j].guid == guid)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B037 RID: 45111 RVA: 0x0026BB8C File Offset: 0x00269F8C
		private bool IsExistActivityTypeCityMonster()
		{
			if (this._sceneNpcDataModelList == null || this._sceneNpcDataModelList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._sceneNpcDataModelList.Count; i++)
			{
				if (this._sceneNpcDataModelList[i].NpcsList != null && this._sceneNpcDataModelList[i].NpcsList.Count > 0)
				{
					for (int j = 0; j < this._sceneNpcDataModelList[i].NpcsList.Count; j++)
					{
						if (this._sceneNpcDataModelList[i].NpcsList[j].funcType == 1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B038 RID: 45112 RVA: 0x0026BC51 File Offset: 0x0026A051
		public bool IsAttackCityMonsterStr(string judgeStr)
		{
			return !string.IsNullOrEmpty(judgeStr) && judgeStr == "AttackCityMonster";
		}

		// Token: 0x0600B039 RID: 45113 RVA: 0x0026BC74 File Offset: 0x0026A074
		public string GetMissionNpcName(Dictionary<string, string> content)
		{
			if (content == null || content.Count <= 0)
			{
				return string.Empty;
			}
			string s;
			if (!content.TryGetValue("npc_data", out s))
			{
				return string.Empty;
			}
			int num = int.Parse(s);
			if (num <= 0)
			{
				return string.Empty;
			}
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return string.Format("<color={0}>{1}</color>", TR.Value("parse_color_npc"), tableItem.NpcName);
		}

		// Token: 0x0600B03A RID: 45114 RVA: 0x0026BD04 File Offset: 0x0026A104
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			string text = uiEvent.Param1 as string;
			if (string.IsNullOrEmpty(text))
			{
				return;
			}
			if (!string.Equals(text, "cm_times"))
			{
				return;
			}
			int count = DataManager<CountDataManager>.GetInstance().GetCount(text);
			this._attackCityMonsterBeatTimes = count;
			this.ShowAttackCityMonsterBeatTimes();
		}

		// Token: 0x0600B03B RID: 45115 RVA: 0x0026BD5C File Offset: 0x0026A15C
		private void ShowAttackCityMonsterBeatTimes()
		{
			if (this._attackCityMonsterTotalTimes <= 0)
			{
				return;
			}
			if (this._attackCityMonsterBeatTimes <= 0)
			{
				return;
			}
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				string text;
				if (this._attackCityMonsterBeatTimes < this._attackCityMonsterTotalTimes)
				{
					text = string.Format(TR.Value("monster_attack_city_less_ten_times"), this._attackCityMonsterBeatTimes, this._attackCityMonsterTotalTimes);
				}
				else
				{
					text = string.Format(TR.Value("monster_attack_city_more_ten_times"), this._attackCityMonsterTotalTimes);
				}
				if (string.IsNullOrEmpty(text))
				{
					return;
				}
				SystemNotifyManager.SysNotifyFloatingEffect(text, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600B03C RID: 45116 RVA: 0x0026BE06 File Offset: 0x0026A206
		public bool IsAlreadyFinishTotalBeatTimes()
		{
			return this._attackCityMonsterTotalTimes > 0 && this._attackCityMonsterBeatTimes >= this._attackCityMonsterTotalTimes;
		}

		// Token: 0x0600B03D RID: 45117 RVA: 0x0026BE2C File Offset: 0x0026A22C
		public int GetLeftBeatTimes()
		{
			int num = this._attackCityMonsterTotalTimes - this._attackCityMonsterBeatTimes;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x04006280 RID: 25216
		private List<SceneNpcDataModel> _sceneNpcDataModelList = new List<SceneNpcDataModel>();

		// Token: 0x04006281 RID: 25217
		private ulong _missionMonsterGuid;

		// Token: 0x04006282 RID: 25218
		private ulong _nearestByMonsterGuid;

		// Token: 0x04006283 RID: 25219
		private EOpenTalkFrameType _eOpenTalkFrameType = EOpenTalkFrameType.Invalid;

		// Token: 0x04006284 RID: 25220
		public int _attackCityMonsterBeatTimes;

		// Token: 0x04006285 RID: 25221
		public int _attackCityMonsterTotalTimes;

		// Token: 0x04006286 RID: 25222
		private const float NpcPositionCoefficient = 10000f;

		// Token: 0x04006287 RID: 25223
		private const string AttackCityMonsterStr = "AttackCityMonster";

		// Token: 0x04006288 RID: 25224
		private const string NetNpcDataStr = "npc_data";

		// Token: 0x04006289 RID: 25225
		private const string NetNpcGuidStr = "npc_guid";

		// Token: 0x0400628A RID: 25226
		private const string NetAttackCityMonsterTimesStr = "cm_times";

		// Token: 0x0400628B RID: 25227
		private const string NetNpcDungeonStr = "npc_dun";

		// Token: 0x0400628C RID: 25228
		private const string NetNpcSceneStr = "npc_scene";

		// Token: 0x0400628D RID: 25229
		private const string NetNpcXStr = "npc_x";

		// Token: 0x0400628E RID: 25230
		private const string NetNpcYStr = "npc_y";

		// Token: 0x0400628F RID: 25231
		public const int LimitLevel = 25;
	}
}
