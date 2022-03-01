using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001303 RID: 4867
	public class TAPNewDataManager : DataManager<TAPNewDataManager>
	{
		// Token: 0x17001B79 RID: 7033
		// (get) Token: 0x0600BCDD RID: 48349 RVA: 0x002C20EE File Offset: 0x002C04EE
		// (set) Token: 0x0600BCDE RID: 48350 RVA: 0x002C20F6 File Offset: 0x002C04F6
		public bool HaveSearchTAP
		{
			get
			{
				return this.haveSearchTAP;
			}
			set
			{
				this.haveSearchTAP = value;
			}
		}

		// Token: 0x17001B7A RID: 7034
		// (get) Token: 0x0600BCDF RID: 48351 RVA: 0x002C20FF File Offset: 0x002C04FF
		// (set) Token: 0x0600BCE0 RID: 48352 RVA: 0x002C2106 File Offset: 0x002C0506
		public static bool FindmasterIsSendServer { get; set; }

		// Token: 0x0600BCE1 RID: 48353 RVA: 0x002C2110 File Offset: 0x002C0510
		public override void Initialize()
		{
			this._BindEvents();
			this.tapQuestionnaireInformation = null;
			this.myTAPData = new MasterTaskShareData();
			this.provinceIDDic.Clear();
			this.firstLetterProvinceDic.Clear();
			this.classmateRelationDic.Clear();
			this.MyDailyMission.Clear();
			this.MyMission.Clear();
			this.MyPupilMissionDic.Clear();
			this.relationRedPoint.Clear();
			this._RegisterNetHandler();
			this._GetAreaProvinceTableData();
			this.teacherPublishTime = 0UL;
			this.pupilPublishTime = 0UL;
			this.HaveSearchTAP = false;
			this.haveTalkTeacher = false;
			TAPNewDataManager.FindmasterIsSendServer = false;
			this.m_TaskFinishedPupils.Clear();
		}

		// Token: 0x0600BCE2 RID: 48354 RVA: 0x002C21C0 File Offset: 0x002C05C0
		public override void Clear()
		{
			this.tapQuestionnaireInformation = null;
			this.provinceIDDic.Clear();
			this.firstLetterProvinceDic.Clear();
			this.classmateRelationDic.Clear();
			this.MyDailyMission.Clear();
			this.MyMission.Clear();
			this.MyPupilMissionDic.Clear();
			this.relationRedPoint.Clear();
			this._UnRegisterNetHandler();
			this.myTAPData = null;
			this.teacherPublishTime = 0UL;
			this.pupilPublishTime = 0UL;
			this._UnBindEvents();
			this.HaveSearchTAP = false;
			TAPNewDataManager.FindmasterIsSendServer = false;
			this.m_TaskFinishedPupils.Clear();
		}

		// Token: 0x0600BCE3 RID: 48355 RVA: 0x002C225C File Offset: 0x002C065C
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BCE4 RID: 48356 RVA: 0x002C2260 File Offset: 0x002C0660
		private void _RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(601743U, new Action<MsgDATA>(this._OnWorldNotifyNewMasterSectRelation));
			NetProcess.AddMsgHandler(601744U, new Action<MsgDATA>(this._OnWorldSyncMasterSectRelationData));
			NetProcess.AddMsgHandler(601745U, new Action<MsgDATA>(this._OnWorldSyncMasterSectRelationList));
			NetProcess.AddMsgHandler(601747U, new Action<MsgDATA>(this._OnWorldNotifyDelMasterSectRelation));
			NetProcess.AddMsgHandler(601740U, new Action<MsgDATA>(this._OnWorldSetDiscipleQuestionnaireRes));
			NetProcess.AddMsgHandler(601742U, new Action<MsgDATA>(this._OnWorldSetMasterQuestionnaireRes));
			NetProcess.AddMsgHandler(601748U, new Action<MsgDATA>(this._OnWorldSyncRelationQuestionnaire));
			NetProcess.AddMsgHandler(501159U, new Action<MsgDATA>(this._OnSceneSyncMasterDailyTaskList));
			NetProcess.AddMsgHandler(501160U, new Action<MsgDATA>(this._OnSceneSyncMasterAcademicTaskList));
			NetProcess.AddMsgHandler(601757U, new Action<MsgDATA>(this._OnWorldGetDiscipleMasterTasksRes));
			NetProcess.AddMsgHandler(601753U, new Action<MsgDATA>(this._OnWorldPublishMasterDialyTaskRes));
			NetProcess.AddMsgHandler(601762U, new Action<MsgDATA>(this._OnWorldReportMasterDailyTaskRes));
			NetProcess.AddMsgHandler(601766U, new Action<MsgDATA>(this._OnWorldReceiveMasterDailyTaskRewardRes));
			NetProcess.AddMsgHandler(601768U, new Action<MsgDATA>(this._OnWorldReceiveMasterAcademicTaskRewardRes));
			NetProcess.AddMsgHandler(601750U, new Action<MsgDATA>(this._OnWorldDiscipleFinishSchoolRes));
			NetProcess.AddMsgHandler(601773U, new Action<MsgDATA>(this._OnWorldAutomaticFinishSchoolRes));
			NetProcess.AddMsgHandler(501107U, new Action<MsgDATA>(this._OnSceneNotifyNewTaskRet));
			NetProcess.AddMsgHandler(501108U, new Action<MsgDATA>(this._OnSceneNotifyDeleteTaskRet));
			NetProcess.AddMsgHandler(501110U, new Action<MsgDATA>(this._OnSceneNotifyTaskVarRet));
			NetProcess.AddMsgHandler(601751U, new Action<MsgDATA>(this._OnWorldSyncMasterDisciplePunishTime));
			NetProcess.AddMsgHandler(601713U, new Action<MsgDATA>(this._OnSyncOffline));
			NetProcess.AddMsgHandler(601777U, new Action<MsgDATA>(this._OnWorldNotifyFinSchEvent));
		}

		// Token: 0x0600BCE5 RID: 48357 RVA: 0x002C2454 File Offset: 0x002C0854
		private void _UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(601743U, new Action<MsgDATA>(this._OnWorldNotifyNewMasterSectRelation));
			NetProcess.RemoveMsgHandler(601744U, new Action<MsgDATA>(this._OnWorldSyncMasterSectRelationData));
			NetProcess.RemoveMsgHandler(601745U, new Action<MsgDATA>(this._OnWorldSyncMasterSectRelationList));
			NetProcess.RemoveMsgHandler(601747U, new Action<MsgDATA>(this._OnWorldNotifyDelMasterSectRelation));
			NetProcess.RemoveMsgHandler(601740U, new Action<MsgDATA>(this._OnWorldSetDiscipleQuestionnaireRes));
			NetProcess.RemoveMsgHandler(601742U, new Action<MsgDATA>(this._OnWorldSetMasterQuestionnaireRes));
			NetProcess.RemoveMsgHandler(601748U, new Action<MsgDATA>(this._OnWorldSyncRelationQuestionnaire));
			NetProcess.RemoveMsgHandler(501159U, new Action<MsgDATA>(this._OnSceneSyncMasterDailyTaskList));
			NetProcess.RemoveMsgHandler(501160U, new Action<MsgDATA>(this._OnSceneSyncMasterAcademicTaskList));
			NetProcess.RemoveMsgHandler(601757U, new Action<MsgDATA>(this._OnWorldGetDiscipleMasterTasksRes));
			NetProcess.RemoveMsgHandler(601753U, new Action<MsgDATA>(this._OnWorldPublishMasterDialyTaskRes));
			NetProcess.RemoveMsgHandler(601762U, new Action<MsgDATA>(this._OnWorldReportMasterDailyTaskRes));
			NetProcess.RemoveMsgHandler(601766U, new Action<MsgDATA>(this._OnWorldReceiveMasterDailyTaskRewardRes));
			NetProcess.RemoveMsgHandler(601768U, new Action<MsgDATA>(this._OnWorldReceiveMasterAcademicTaskRewardRes));
			NetProcess.RemoveMsgHandler(601750U, new Action<MsgDATA>(this._OnWorldDiscipleFinishSchoolRes));
			NetProcess.RemoveMsgHandler(601773U, new Action<MsgDATA>(this._OnWorldAutomaticFinishSchoolRes));
			NetProcess.RemoveMsgHandler(501107U, new Action<MsgDATA>(this._OnSceneNotifyNewTaskRet));
			NetProcess.RemoveMsgHandler(501108U, new Action<MsgDATA>(this._OnSceneNotifyDeleteTaskRet));
			NetProcess.RemoveMsgHandler(501110U, new Action<MsgDATA>(this._OnSceneNotifyTaskVarRet));
			NetProcess.RemoveMsgHandler(601751U, new Action<MsgDATA>(this._OnWorldSyncMasterDisciplePunishTime));
			NetProcess.RemoveMsgHandler(601713U, new Action<MsgDATA>(this._OnSyncOffline));
			NetProcess.RemoveMsgHandler(601777U, new Action<MsgDATA>(this._OnWorldNotifyFinSchEvent));
		}

		// Token: 0x0600BCE6 RID: 48358 RVA: 0x002C2645 File Offset: 0x002C0A45
		private void _BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTAPSetRedPoint, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x0600BCE7 RID: 48359 RVA: 0x002C267D File Offset: 0x002C0A7D
		private void _UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRelationChanged, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTAPSetRedPoint, new ClientEventSystem.UIEventHandler(this._OnRelationChanged));
		}

		// Token: 0x0600BCE8 RID: 48360 RVA: 0x002C26B8 File Offset: 0x002C0AB8
		private void _OnRelationChanged(UIEvent uiEvent)
		{
			this.relationRedPoint.Clear();
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			for (int i = 0; i < relation.Count; i++)
			{
				int dailyTaskState = (int)relation[i].dailyTaskState;
				if (dailyTaskState == 0 || dailyTaskState == 2 || dailyTaskState == 4)
				{
					this.relationRedPoint[relation[i].uid] = true;
				}
				else
				{
					this.relationRedPoint[relation[i].uid] = false;
				}
			}
			List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
			for (int j = 0; j < relation2.Count; j++)
			{
				int dailyTaskState2 = (int)relation2[j].dailyTaskState;
				if ((dailyTaskState2 == 0 && !this.haveTalkTeacher) || dailyTaskState2 == 2 || dailyTaskState2 == 4)
				{
					this.relationRedPoint[relation2[j].uid] = true;
				}
				else
				{
					this.relationRedPoint[relation2[j].uid] = false;
				}
			}
			this.m_TaskFinishedPupils = new List<RelationData>();
			this.GetFinishDailtyTaskPupils();
			this.GetPublishedDailyTask();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPRedPointUpdate, null, null, null, null);
		}

		// Token: 0x0600BCE9 RID: 48361 RVA: 0x002C2804 File Offset: 0x002C0C04
		private void _GetAreaProvinceTableData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AreaProvinceTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					AreaProvinceTable areaProvinceTable = keyValuePair.Value as AreaProvinceTable;
					if (areaProvinceTable != null)
					{
						if (this.firstLetterProvinceDic.ContainsKey(areaProvinceTable.FirstLetter))
						{
							if (!this.firstLetterProvinceDic[areaProvinceTable.FirstLetter].Contains(areaProvinceTable.Name))
							{
								this.firstLetterProvinceDic[areaProvinceTable.FirstLetter].Add(areaProvinceTable.Name);
							}
						}
						else
						{
							List<string> list = new List<string>();
							list.Add(areaProvinceTable.Name);
							this.firstLetterProvinceDic[areaProvinceTable.FirstLetter] = list;
						}
						this.provinceIDDic[areaProvinceTable.Name] = areaProvinceTable.ID;
					}
				}
			}
		}

		// Token: 0x0600BCEA RID: 48362 RVA: 0x002C28F0 File Offset: 0x002C0CF0
		public bool HaveTAPDailyRedPoint()
		{
			bool result = false;
			foreach (KeyValuePair<ulong, bool> keyValuePair in this.relationRedPoint)
			{
				if (keyValuePair.Value)
				{
					result = true;
				}
			}
			return result;
		}

		// Token: 0x0600BCEB RID: 48363 RVA: 0x002C2958 File Offset: 0x002C0D58
		public bool HaveSearchRedPoint()
		{
			return this.relationRedPoint.Count == 0 && !this.HaveSearchTAP;
		}

		// Token: 0x0600BCEC RID: 48364 RVA: 0x002C2978 File Offset: 0x002C0D78
		public bool HaveApplyRedPoint()
		{
			return DataManager<RelationDataManager>.GetInstance().ApplyPupils.Count != 0 || DataManager<RelationDataManager>.GetInstance().ApplyTeachers.Count != 0;
		}

		// Token: 0x0600BCED RID: 48365 RVA: 0x002C29A5 File Offset: 0x002C0DA5
		public bool HaveTAPDailyRedPointForID(ulong id)
		{
			return this.relationRedPoint.ContainsKey(id) && this.relationRedPoint[id];
		}

		// Token: 0x0600BCEE RID: 48366 RVA: 0x002C29C6 File Offset: 0x002C0DC6
		public void SetHaveTalkTeacher(bool flag)
		{
			this.haveTalkTeacher = flag;
		}

		// Token: 0x0600BCEF RID: 48367 RVA: 0x002C29D0 File Offset: 0x002C0DD0
		public List<string> GetFirstLetterList()
		{
			List<string> list = new List<string>();
			foreach (string item in this.firstLetterProvinceDic.Keys)
			{
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0600BCF0 RID: 48368 RVA: 0x002C2A38 File Offset: 0x002C0E38
		public List<string> GetRegionList(string firstLetter)
		{
			if (this.firstLetterProvinceDic.ContainsKey(firstLetter))
			{
				return this.firstLetterProvinceDic[firstLetter];
			}
			return null;
		}

		// Token: 0x0600BCF1 RID: 48369 RVA: 0x002C2A59 File Offset: 0x002C0E59
		public int GetRegionID(string region)
		{
			if (this.provinceIDDic.ContainsKey(region))
			{
				return this.provinceIDDic[region];
			}
			return 0;
		}

		// Token: 0x0600BCF2 RID: 48370 RVA: 0x002C2A7C File Offset: 0x002C0E7C
		public TAPType IsTeacher()
		{
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			if (level > 0 && level <= 45)
			{
				return TAPType.Pupil;
			}
			if (level > 45 && level < 50)
			{
				return TAPType.TeacherSoon;
			}
			return TAPType.Teacher;
		}

		// Token: 0x0600BCF3 RID: 48371 RVA: 0x002C2AB8 File Offset: 0x002C0EB8
		public Dictionary<ulong, ClassmateRelationData> GetClassmateRelationDic()
		{
			return this.classmateRelationDic;
		}

		// Token: 0x0600BCF4 RID: 48372 RVA: 0x002C2AC0 File Offset: 0x002C0EC0
		public MasterTaskShareData GetMyPupilData(ulong id)
		{
			if (this.MyPupilMissionDic.ContainsKey(id))
			{
				return this.MyPupilMissionDic[id];
			}
			return null;
		}

		// Token: 0x0600BCF5 RID: 48373 RVA: 0x002C2AE1 File Offset: 0x002C0EE1
		public List<MissionInfo> GetMyMission()
		{
			return this.MyMission;
		}

		// Token: 0x0600BCF6 RID: 48374 RVA: 0x002C2AE9 File Offset: 0x002C0EE9
		public List<MissionInfo> GetDailyMission()
		{
			return this.MyDailyMission;
		}

		// Token: 0x0600BCF7 RID: 48375 RVA: 0x002C2AF4 File Offset: 0x002C0EF4
		public List<TAPMissionReward> _GetRewardItemTableList(int type)
		{
			List<TAPMissionReward> list = new List<TAPMissionReward>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MasterSysGiftTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				MasterSysGiftTable masterSysGiftTable = keyValuePair.Value as MasterSysGiftTable;
				if (type == masterSysGiftTable.Type)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(masterSysGiftTable.GiftId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(new TAPMissionReward(tableItem.ID, 1));
					}
				}
			}
			return list;
		}

		// Token: 0x0600BCF8 RID: 48376 RVA: 0x002C2B84 File Offset: 0x002C0F84
		public List<TAPMissionReward> _GetRewardList(int type)
		{
			List<TAPMissionReward> list = new List<TAPMissionReward>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MasterSysGiftTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				MasterSysGiftTable masterSysGiftTable = keyValuePair.Value as MasterSysGiftTable;
				if (type == masterSysGiftTable.Type)
				{
					GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(masterSysGiftTable.GiftId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						FlatBufferArray<int> items = tableItem.Items;
						for (int i = 0; i < items.Length; i++)
						{
							GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								list.Add(new TAPMissionReward(tableItem2.ItemID, tableItem2.ItemCount));
							}
						}
					}
				}
			}
			if (list.Count == 0)
			{
				return list;
			}
			return list;
		}

		// Token: 0x0600BCF9 RID: 48377 RVA: 0x002C2C7C File Offset: 0x002C107C
		public void _TalkToPeople(RelationData relationData, string talkStr = null)
		{
			DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationData, false);
			RelationFrameData relationFrameData = new RelationFrameData();
			relationFrameData.eCurrentRelationData = relationData;
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationFrameNew>(null))
			{
				RelationFrameNew.CommandOpen(relationFrameData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnCloseMenu, null, null, null, null);
			if (talkStr == null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPStartTalk, relationFrameData, string.Empty, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPStartTalk, relationFrameData, talkStr, null, null);
			}
		}

		// Token: 0x0600BCFA RID: 48378 RVA: 0x002C2D00 File Offset: 0x002C1100
		public static void SendTeachers(string param)
		{
			if (string.IsNullOrEmpty(param))
			{
				return;
			}
			ulong uid = 0UL;
			if (!ulong.TryParse(param, out uid))
			{
				return;
			}
			DataManager<TAPNewDataManager>.GetInstance().SendApplyTeacher(uid);
		}

		// Token: 0x0600BCFB RID: 48379 RVA: 0x002C2D35 File Offset: 0x002C1135
		public void SendApplyTeacher(ulong uid)
		{
			DataManager<RelationDataManager>.GetInstance().AddRelationByID(uid, RequestType.RequestMaster);
		}

		// Token: 0x0600BCFC RID: 48380 RVA: 0x002C2D44 File Offset: 0x002C1144
		public static void SendPupils(string param)
		{
			if (string.IsNullOrEmpty(param))
			{
				return;
			}
			ulong uid = 0UL;
			if (!ulong.TryParse(param, out uid))
			{
				return;
			}
			DataManager<TAPNewDataManager>.GetInstance().SendApplyPupil(uid);
		}

		// Token: 0x0600BCFD RID: 48381 RVA: 0x002C2D79 File Offset: 0x002C1179
		public void SendApplyPupil(ulong uid)
		{
			DataManager<RelationDataManager>.GetInstance().AddRelationByID(uid, RequestType.RequestDisciple);
		}

		// Token: 0x0600BCFE RID: 48382 RVA: 0x002C2D88 File Offset: 0x002C1188
		public string getPublishTime(TAPType type)
		{
			if (type == TAPType.Pupil)
			{
				if (this.pupilPublishTime > (ulong)DataManager<TimeManager>.GetInstance().GetServerTime())
				{
					return string.Format("解除师徒关系惩罚时间：{0}", Function.SetShowTimeMin((int)this.pupilPublishTime));
				}
				return string.Empty;
			}
			else
			{
				if (this.teacherPublishTime > (ulong)DataManager<TimeManager>.GetInstance().GetServerTime())
				{
					return string.Format("解除师徒关系惩罚时间：{0}", Function.SetShowTimeMin((int)this.teacherPublishTime));
				}
				return string.Empty;
			}
		}

		// Token: 0x0600BCFF RID: 48383 RVA: 0x002C2E04 File Offset: 0x002C1204
		public bool canSearchPupil()
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			return relation.Count < 2;
		}

		// Token: 0x0600BD00 RID: 48384 RVA: 0x002C2E2C File Offset: 0x002C122C
		public bool canSearchTeacher()
		{
			RelationData teacher = DataManager<RelationDataManager>.GetInstance().GetTeacher();
			return teacher == null;
		}

		// Token: 0x17001B7B RID: 7035
		// (get) Token: 0x0600BD01 RID: 48385 RVA: 0x002C2E4D File Offset: 0x002C124D
		public List<RelationData> TaskFinishedPupils
		{
			get
			{
				if (this.m_TaskFinishedPupils == null)
				{
					this.m_TaskFinishedPupils = new List<RelationData>();
				}
				return this.m_TaskFinishedPupils;
			}
		}

		// Token: 0x0600BD02 RID: 48386 RVA: 0x002C2E6C File Offset: 0x002C126C
		public void RemoveFinishTaskInfo(int index)
		{
			if (this.m_TaskFinishedPupils == null)
			{
				return;
			}
			if (index >= 0 && index < this.m_TaskFinishedPupils.Count)
			{
				this.m_TaskFinishedPupils.RemoveAt(index);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateMissionListBtn, null, null, null, null);
		}

		// Token: 0x0600BD03 RID: 48387 RVA: 0x002C2EBC File Offset: 0x002C12BC
		public void ClearFinishTaskInfo()
		{
			if (this.m_TaskFinishedPupils == null)
			{
				return;
			}
			for (int i = 0; i < this.m_TaskFinishedPupils.Count; i++)
			{
				this.RemoveFinishTaskInfo(i);
			}
		}

		// Token: 0x0600BD04 RID: 48388 RVA: 0x002C2EF8 File Offset: 0x002C12F8
		private void GetFinishDailtyTaskPupils()
		{
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			if (relation != null)
			{
				for (int i = 0; i < relation.Count; i++)
				{
					RelationData relationData = relation[i];
					if (relationData != null && relationData.dailyTaskState == 2)
					{
						this.TaskFinishedPupils.Add(relationData);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateMissionListBtn, null, null, null, null);
		}

		// Token: 0x0600BD05 RID: 48389 RVA: 0x002C2F68 File Offset: 0x002C1368
		private void GetPublishedDailyTask()
		{
			RelationData teacher = DataManager<RelationDataManager>.GetInstance().GetTeacher();
			if (teacher == null)
			{
				return;
			}
			if (teacher.dailyTaskState == 1)
			{
				this.m_TaskFinishedPupils.Add(teacher);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateMissionListBtn, null, null, null, null);
		}

		// Token: 0x0600BD06 RID: 48390 RVA: 0x002C2FB4 File Offset: 0x002C13B4
		public void AnnounceWorld(RelationAnnounceType type)
		{
			WorldRelationAnnounceReq worldRelationAnnounceReq = new WorldRelationAnnounceReq();
			worldRelationAnnounceReq.type = (uint)type;
			NetManager.Instance().SendCommand<WorldRelationAnnounceReq>(ServerType.GATE_SERVER, worldRelationAnnounceReq);
		}

		// Token: 0x0600BD07 RID: 48391 RVA: 0x002C2FDC File Offset: 0x002C13DC
		public void SendTAPInformation(int activeTimeIndex, int abilityIndex, int regionIndex, string declaration)
		{
			TAPType taptype = this.IsTeacher();
			if (taptype > TAPType.Pupil)
			{
				WorldSetMasterQuestionnaireReq worldSetMasterQuestionnaireReq = new WorldSetMasterQuestionnaireReq();
				worldSetMasterQuestionnaireReq.activeTimeType = (byte)activeTimeIndex;
				worldSetMasterQuestionnaireReq.masterType = (byte)abilityIndex;
				worldSetMasterQuestionnaireReq.regionId = (byte)regionIndex;
				worldSetMasterQuestionnaireReq.declaration = declaration;
				NetManager.Instance().SendCommand<WorldSetMasterQuestionnaireReq>(ServerType.GATE_SERVER, worldSetMasterQuestionnaireReq);
			}
			else
			{
				WorldSetDiscipleQuestionnaireReq worldSetDiscipleQuestionnaireReq = new WorldSetDiscipleQuestionnaireReq();
				worldSetDiscipleQuestionnaireReq.activeTimeType = (byte)activeTimeIndex;
				worldSetDiscipleQuestionnaireReq.masterType = (byte)abilityIndex;
				worldSetDiscipleQuestionnaireReq.regionId = (byte)regionIndex;
				worldSetDiscipleQuestionnaireReq.declaration = declaration;
				NetManager.Instance().SendCommand<WorldSetDiscipleQuestionnaireReq>(ServerType.GATE_SERVER, worldSetDiscipleQuestionnaireReq);
			}
		}

		// Token: 0x0600BD08 RID: 48392 RVA: 0x002C3064 File Offset: 0x002C1464
		public void FinishLearningReward(int id)
		{
			WorldReceiveMasterAcademicTaskRewardReq worldReceiveMasterAcademicTaskRewardReq = new WorldReceiveMasterAcademicTaskRewardReq();
			worldReceiveMasterAcademicTaskRewardReq.giftDataId = (uint)id;
			NetManager.Instance().SendCommand<WorldReceiveMasterAcademicTaskRewardReq>(ServerType.GATE_SERVER, worldReceiveMasterAcademicTaskRewardReq);
		}

		// Token: 0x0600BD09 RID: 48393 RVA: 0x002C308C File Offset: 0x002C148C
		public void GetClassmateInformation()
		{
			WorldUpdateMasterSectRelationReq cmd = new WorldUpdateMasterSectRelationReq();
			NetManager.Instance().SendCommand<WorldUpdateMasterSectRelationReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BD0A RID: 48394 RVA: 0x002C30AC File Offset: 0x002C14AC
		public void GetPupilMissionList(ulong id)
		{
			WorldGetDiscipleMasterTasksReq worldGetDiscipleMasterTasksReq = new WorldGetDiscipleMasterTasksReq();
			worldGetDiscipleMasterTasksReq.discipleId = id;
			NetManager.Instance().SendCommand<WorldGetDiscipleMasterTasksReq>(ServerType.GATE_SERVER, worldGetDiscipleMasterTasksReq);
		}

		// Token: 0x0600BD0B RID: 48395 RVA: 0x002C30D4 File Offset: 0x002C14D4
		public void SendMissionToPupil(ulong id)
		{
			WorldPublishMasterDialyTaskReq worldPublishMasterDialyTaskReq = new WorldPublishMasterDialyTaskReq();
			worldPublishMasterDialyTaskReq.discipleId = id;
			NetManager.Instance().SendCommand<WorldPublishMasterDialyTaskReq>(ServerType.GATE_SERVER, worldPublishMasterDialyTaskReq);
		}

		// Token: 0x0600BD0C RID: 48396 RVA: 0x002C30FC File Offset: 0x002C14FC
		public void SendReportDailyMission(ulong id)
		{
			WorldReportMasterDailyTaskReq worldReportMasterDailyTaskReq = new WorldReportMasterDailyTaskReq();
			worldReportMasterDailyTaskReq.masterId = id;
			NetManager.Instance().SendCommand<WorldReportMasterDailyTaskReq>(ServerType.GATE_SERVER, worldReportMasterDailyTaskReq);
		}

		// Token: 0x0600BD0D RID: 48397 RVA: 0x002C3124 File Offset: 0x002C1524
		public void SendFinishDailyMission(ulong id)
		{
			WorldReceiveMasterDailyTaskRewardReq worldReceiveMasterDailyTaskRewardReq = new WorldReceiveMasterDailyTaskRewardReq();
			if (id == 0UL)
			{
				worldReceiveMasterDailyTaskRewardReq.type = 2;
				worldReceiveMasterDailyTaskRewardReq.discipeleId = id;
			}
			else
			{
				worldReceiveMasterDailyTaskRewardReq.type = 1;
				worldReceiveMasterDailyTaskRewardReq.discipeleId = id;
			}
			NetManager.Instance().SendCommand<WorldReceiveMasterDailyTaskRewardReq>(ServerType.GATE_SERVER, worldReceiveMasterDailyTaskRewardReq);
		}

		// Token: 0x0600BD0E RID: 48398 RVA: 0x002C3170 File Offset: 0x002C1570
		public void GetLearningReward(int id)
		{
			WorldReceiveMasterAcademicTaskRewardReq worldReceiveMasterAcademicTaskRewardReq = new WorldReceiveMasterAcademicTaskRewardReq();
			worldReceiveMasterAcademicTaskRewardReq.giftDataId = (uint)id;
			NetManager.Instance().SendCommand<WorldReceiveMasterAcademicTaskRewardReq>(ServerType.GATE_SERVER, worldReceiveMasterAcademicTaskRewardReq);
		}

		// Token: 0x0600BD0F RID: 48399 RVA: 0x002C3198 File Offset: 0x002C1598
		public void SendChangeSearchedPupilList(RelationFindType type)
		{
			WorldRelationFindPlayersReq worldRelationFindPlayersReq = new WorldRelationFindPlayersReq();
			worldRelationFindPlayersReq.type = (byte)type;
			worldRelationFindPlayersReq.name = string.Empty;
			MonoSingleton<NetManager>.instance.SendCommand<WorldRelationFindPlayersReq>(ServerType.GATE_SERVER, worldRelationFindPlayersReq);
		}

		// Token: 0x0600BD10 RID: 48400 RVA: 0x002C31CC File Offset: 0x002C15CC
		public void SendGraduation(ulong id)
		{
			WorldDiscipleFinishSchoolReq worldDiscipleFinishSchoolReq = new WorldDiscipleFinishSchoolReq();
			worldDiscipleFinishSchoolReq.discipleId = id;
			MonoSingleton<NetManager>.instance.SendCommand<WorldDiscipleFinishSchoolReq>(ServerType.GATE_SERVER, worldDiscipleFinishSchoolReq);
		}

		// Token: 0x0600BD11 RID: 48401 RVA: 0x002C31F4 File Offset: 0x002C15F4
		public void SendGraduationLate(ulong id)
		{
			WorldAutomaticFinishSchoolReq worldAutomaticFinishSchoolReq = new WorldAutomaticFinishSchoolReq();
			worldAutomaticFinishSchoolReq.targetId = id;
			MonoSingleton<NetManager>.instance.SendCommand<WorldAutomaticFinishSchoolReq>(ServerType.GATE_SERVER, worldAutomaticFinishSchoolReq);
		}

		// Token: 0x0600BD12 RID: 48402 RVA: 0x002C321C File Offset: 0x002C161C
		private void _OnWorldNotifyNewMasterSectRelation(MsgDATA msg)
		{
			int num = 0;
			MasterSectRelation masterSectRelation = MasterSectRelationDecoder.DecodeNew(msg.bytes, ref num, msg.bytes.Length);
			ClassmateRelationData classmateRelationData = new ClassmateRelationData();
			classmateRelationData.uid = masterSectRelation.uid;
			classmateRelationData.name = masterSectRelation.name;
			classmateRelationData.level = masterSectRelation.level;
			classmateRelationData.occu = masterSectRelation.occu;
			classmateRelationData.type = masterSectRelation.type;
			classmateRelationData.vipLv = masterSectRelation.vipLv;
			classmateRelationData.status = masterSectRelation.status;
			classmateRelationData.isFinSch = masterSectRelation.isFinSch;
			if (classmateRelationData.type == 2)
			{
				this.classmateRelationDic[classmateRelationData.uid] = classmateRelationData;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshClassmateDic, null, null, null, null);
			}
		}

		// Token: 0x0600BD13 RID: 48403 RVA: 0x002C32D8 File Offset: 0x002C16D8
		private void _OnWorldNotifyDelMasterSectRelation(MsgDATA msg)
		{
			WorldNotifyDelMasterSectRelation worldNotifyDelMasterSectRelation = new WorldNotifyDelMasterSectRelation();
			worldNotifyDelMasterSectRelation.decode(msg.bytes);
			this.classmateRelationDic.Remove(worldNotifyDelMasterSectRelation.id);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshClassmateDic, null, null, null, null);
		}

		// Token: 0x0600BD14 RID: 48404 RVA: 0x002C331C File Offset: 0x002C171C
		private void _OnWorldSyncMasterSectRelationData(MsgDATA msg)
		{
			int num = 0;
			MasterSectRelation masterSectRelation = MasterSectRelationDecoder.DecodeData(msg.bytes, ref num, msg.bytes.Length);
			ClassmateRelationData classmateRelationData = new ClassmateRelationData();
			classmateRelationData.uid = masterSectRelation.uid;
			classmateRelationData.name = masterSectRelation.name;
			classmateRelationData.level = masterSectRelation.level;
			classmateRelationData.occu = masterSectRelation.occu;
			classmateRelationData.type = masterSectRelation.type;
			classmateRelationData.vipLv = masterSectRelation.vipLv;
			classmateRelationData.status = masterSectRelation.status;
			classmateRelationData.isFinSch = masterSectRelation.isFinSch;
			if (classmateRelationData.type == 2)
			{
				this.classmateRelationDic[classmateRelationData.uid] = classmateRelationData;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshClassmateDic, null, null, null, null);
			}
		}

		// Token: 0x0600BD15 RID: 48405 RVA: 0x002C33D8 File Offset: 0x002C17D8
		private void _OnWorldSyncMasterSectRelationList(MsgDATA msg)
		{
			int num = 0;
			this.classmateRelationDic.Clear();
			List<MasterSectRelation> list = MasterSectRelationDecoder.DecodeList(msg.bytes, ref num, msg.bytes.Length);
			for (int i = 0; i < list.Count; i++)
			{
				ClassmateRelationData classmateRelationData = new ClassmateRelationData();
				classmateRelationData.uid = list[i].uid;
				classmateRelationData.name = list[i].name;
				classmateRelationData.level = list[i].level;
				classmateRelationData.occu = list[i].occu;
				classmateRelationData.type = list[i].type;
				classmateRelationData.vipLv = list[i].vipLv;
				classmateRelationData.status = list[i].status;
				classmateRelationData.isFinSch = list[i].isFinSch;
				if (classmateRelationData.type == 2)
				{
					this.classmateRelationDic[classmateRelationData.uid] = classmateRelationData;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshClassmateDic, null, null, null, null);
				}
			}
		}

		// Token: 0x0600BD16 RID: 48406 RVA: 0x002C34E8 File Offset: 0x002C18E8
		private void _OnWorldSetDiscipleQuestionnaireRes(MsgDATA msgData)
		{
			WorldSetDiscipleQuestionnaireRes worldSetDiscipleQuestionnaireRes = new WorldSetDiscipleQuestionnaireRes();
			worldSetDiscipleQuestionnaireRes.decode(msgData.bytes);
			if (worldSetDiscipleQuestionnaireRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSetDiscipleQuestionnaireRes.code, string.Empty);
				return;
			}
			if (worldSetDiscipleQuestionnaireRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSetDiscipleQuestionnaireRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD17 RID: 48407 RVA: 0x002C3540 File Offset: 0x002C1940
		private void _OnWorldSetMasterQuestionnaireRes(MsgDATA msgData)
		{
			WorldSetMasterQuestionnaireRes worldSetMasterQuestionnaireRes = new WorldSetMasterQuestionnaireRes();
			worldSetMasterQuestionnaireRes.decode(msgData.bytes);
			if (worldSetMasterQuestionnaireRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSetMasterQuestionnaireRes.code, string.Empty);
				return;
			}
			if (worldSetMasterQuestionnaireRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSetMasterQuestionnaireRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD18 RID: 48408 RVA: 0x002C3598 File Offset: 0x002C1998
		private void _OnWorldSyncRelationQuestionnaire(MsgDATA msgData)
		{
			WorldSyncRelationQuestionnaire worldSyncRelationQuestionnaire = new WorldSyncRelationQuestionnaire();
			worldSyncRelationQuestionnaire.decode(msgData.bytes);
			TAPQuestionnaireInformation tapquestionnaireInformation = new TAPQuestionnaireInformation(worldSyncRelationQuestionnaire.activeTimeType, worldSyncRelationQuestionnaire.masterType, worldSyncRelationQuestionnaire.regionId, worldSyncRelationQuestionnaire.declaration);
			this.tapQuestionnaireInformation = tapquestionnaireInformation;
		}

		// Token: 0x0600BD19 RID: 48409 RVA: 0x002C35DC File Offset: 0x002C19DC
		private void _OnSceneSyncMasterDailyTaskList(MsgDATA msgData)
		{
			SceneSyncMasterDailyTaskList sceneSyncMasterDailyTaskList = new SceneSyncMasterDailyTaskList();
			sceneSyncMasterDailyTaskList.decode(msgData.bytes);
			this.MyDailyMission.Clear();
			this.MyDailyMission = sceneSyncMasterDailyTaskList.tasks.ToList<MissionInfo>();
			this.myTAPData.dailyTasks = sceneSyncMasterDailyTaskList.tasks;
		}

		// Token: 0x0600BD1A RID: 48410 RVA: 0x002C3628 File Offset: 0x002C1A28
		private void _OnSceneSyncMasterAcademicTaskList(MsgDATA msgData)
		{
			SceneSyncMasterAcademicTaskList sceneSyncMasterAcademicTaskList = new SceneSyncMasterAcademicTaskList();
			sceneSyncMasterAcademicTaskList.decode(msgData.bytes);
			this.MyMission.Clear();
			this.MyMission = sceneSyncMasterAcademicTaskList.tasks.ToList<MissionInfo>();
			this.myTAPData.academicTasks = sceneSyncMasterAcademicTaskList.tasks;
		}

		// Token: 0x0600BD1B RID: 48411 RVA: 0x002C3674 File Offset: 0x002C1A74
		private void _OnWorldGetDiscipleMasterTasksRes(MsgDATA msgData)
		{
			WorldGetDiscipleMasterTasksRes worldGetDiscipleMasterTasksRes = new WorldGetDiscipleMasterTasksRes();
			worldGetDiscipleMasterTasksRes.decode(msgData.bytes);
			if (worldGetDiscipleMasterTasksRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGetDiscipleMasterTasksRes.code, string.Empty);
				return;
			}
			ulong discipleId = worldGetDiscipleMasterTasksRes.discipleId;
			this.MyPupilMissionDic[discipleId] = worldGetDiscipleMasterTasksRes.masterTaskShareData;
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			for (int i = 0; i < relation.Count; i++)
			{
				if (relation[i].uid == discipleId)
				{
					RelationData param = relation[i];
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, param, null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, param, null, null, null);
				}
			}
		}

		// Token: 0x0600BD1C RID: 48412 RVA: 0x002C3730 File Offset: 0x002C1B30
		private void _OnWorldPublishMasterDialyTaskRes(MsgDATA msgData)
		{
			WorldPublishMasterDialyTaskRes worldPublishMasterDialyTaskRes = new WorldPublishMasterDialyTaskRes();
			worldPublishMasterDialyTaskRes.decode(msgData.bytes);
			if (worldPublishMasterDialyTaskRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldPublishMasterDialyTaskRes.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPPublishMissionSuccess, null, null, null, null);
			RelationData relationData = new RelationData();
			List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
			if (relation != null)
			{
				for (int i = 0; i < relation.Count; i++)
				{
					if (relation[i].uid == worldPublishMasterDialyTaskRes.discipleId)
					{
						relationData = relation[i];
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPupilDataUpdate, relationData, null, null, null);
					}
				}
			}
			this.GetPupilMissionList(relationData.uid);
		}

		// Token: 0x0600BD1D RID: 48413 RVA: 0x002C37EC File Offset: 0x002C1BEC
		private void _OnWorldReportMasterDailyTaskRes(MsgDATA msgData)
		{
			WorldReportMasterDailyTaskRes worldReportMasterDailyTaskRes = new WorldReportMasterDailyTaskRes();
			worldReportMasterDailyTaskRes.decode(msgData.bytes);
			if (worldReportMasterDailyTaskRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldReportMasterDailyTaskRes.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPReportTeacherSuccess, null, null, null, null);
		}

		// Token: 0x0600BD1E RID: 48414 RVA: 0x002C383C File Offset: 0x002C1C3C
		private void _OnWorldReceiveMasterDailyTaskRewardRes(MsgDATA msgData)
		{
			WorldReceiveMasterDailyTaskRewardRes worldReceiveMasterDailyTaskRewardRes = new WorldReceiveMasterDailyTaskRewardRes();
			worldReceiveMasterDailyTaskRewardRes.decode(msgData.bytes);
			if (worldReceiveMasterDailyTaskRewardRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldReceiveMasterDailyTaskRewardRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD1F RID: 48415 RVA: 0x002C3878 File Offset: 0x002C1C78
		private void _OnWorldReceiveMasterAcademicTaskRewardRes(MsgDATA msgData)
		{
			WorldReceiveMasterAcademicTaskRewardRes worldReceiveMasterAcademicTaskRewardRes = new WorldReceiveMasterAcademicTaskRewardRes();
			worldReceiveMasterAcademicTaskRewardRes.decode(msgData.bytes);
			if (worldReceiveMasterAcademicTaskRewardRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldReceiveMasterAcademicTaskRewardRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD20 RID: 48416 RVA: 0x002C38B4 File Offset: 0x002C1CB4
		private void _OnWorldDiscipleFinishSchoolRes(MsgDATA msgData)
		{
			WorldDiscipleFinishSchoolRes worldDiscipleFinishSchoolRes = new WorldDiscipleFinishSchoolRes();
			worldDiscipleFinishSchoolRes.decode(msgData.bytes);
			if (worldDiscipleFinishSchoolRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldDiscipleFinishSchoolRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD21 RID: 48417 RVA: 0x002C38F0 File Offset: 0x002C1CF0
		private void _OnWorldAutomaticFinishSchoolRes(MsgDATA msgData)
		{
			WorldAutomaticFinishSchoolRes worldAutomaticFinishSchoolRes = new WorldAutomaticFinishSchoolRes();
			worldAutomaticFinishSchoolRes.decode(msgData.bytes);
			if (worldAutomaticFinishSchoolRes.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldAutomaticFinishSchoolRes.code, string.Empty);
				return;
			}
		}

		// Token: 0x0600BD22 RID: 48418 RVA: 0x002C392C File Offset: 0x002C1D2C
		private void _OnSceneNotifyNewTaskRet(MsgDATA msgData)
		{
			SceneNotifyNewTaskRet sceneNotifyNewTaskRet = new SceneNotifyNewTaskRet();
			sceneNotifyNewTaskRet.decode(msgData.bytes);
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)sceneNotifyNewTaskRet.taskInfo.taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_DAILY)
			{
				for (int i = 0; i < this.MyDailyMission.Count; i++)
				{
					if (this.MyDailyMission[i].taskID == sceneNotifyNewTaskRet.taskInfo.taskID)
					{
						this.MyDailyMission.Remove(this.MyDailyMission[i]);
					}
				}
				this.MyDailyMission.Add(sceneNotifyNewTaskRet.taskInfo);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, null, null, null, null);
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_ACADEMIC)
			{
				for (int j = 0; j < this.MyMission.Count; j++)
				{
					if (this.MyMission[j].taskID == sceneNotifyNewTaskRet.taskInfo.taskID)
					{
						this.MyMission.Remove(this.MyMission[j]);
					}
				}
				this.MyMission.Add(sceneNotifyNewTaskRet.taskInfo);
				this.myTAPData.academicTasks = this.MyMission.ToArray();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600BD23 RID: 48419 RVA: 0x002C3A94 File Offset: 0x002C1E94
		private void _OnSceneNotifyDeleteTaskRet(MsgDATA msgData)
		{
			SceneNotifyDeleteTaskRet sceneNotifyDeleteTaskRet = new SceneNotifyDeleteTaskRet();
			sceneNotifyDeleteTaskRet.decode(msgData.bytes);
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)sceneNotifyDeleteTaskRet.taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_DAILY)
			{
				for (int i = 0; i < this.MyDailyMission.Count; i++)
				{
					if (this.MyDailyMission[i].taskID == sceneNotifyDeleteTaskRet.taskID)
					{
						this.MyDailyMission.Remove(this.MyDailyMission[i]);
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, null, null, null, null);
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_ACADEMIC)
			{
				for (int j = 0; j < this.MyMission.Count; j++)
				{
					if (this.MyMission[j].taskID == sceneNotifyDeleteTaskRet.taskID)
					{
						this.MyMission.Remove(this.MyMission[j]);
					}
				}
				this.myTAPData.academicTasks = this.MyMission.ToArray();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600BD24 RID: 48420 RVA: 0x002C3BCC File Offset: 0x002C1FCC
		private void _OnSceneNotifyTaskVarRet(MsgDATA msgData)
		{
			SceneNotifyTaskVarRet sceneNotifyTaskVarRet = new SceneNotifyTaskVarRet();
			sceneNotifyTaskVarRet.decode(msgData.bytes);
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)sceneNotifyTaskVarRet.taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_DAILY)
			{
				for (int i = 0; i < this.MyDailyMission.Count; i++)
				{
					if (this.MyDailyMission[i].taskID == sceneNotifyTaskVarRet.taskID)
					{
						if (this.MyDailyMission[i].akMissionPairs.Length == 0)
						{
							MissionPair[] array = new MissionPair[]
							{
								new MissionPair()
							};
							array[0].key = sceneNotifyTaskVarRet.key;
							array[0].value = sceneNotifyTaskVarRet.value;
							this.MyDailyMission[i].akMissionPairs = array;
						}
						else
						{
							bool flag = false;
							for (int j = 0; j < this.MyDailyMission[i].akMissionPairs.Length; j++)
							{
								if (this.MyDailyMission[i].akMissionPairs[j].key == sceneNotifyTaskVarRet.key)
								{
									flag = true;
									this.MyDailyMission[i].akMissionPairs[j].value = sceneNotifyTaskVarRet.value;
								}
							}
							if (!flag)
							{
								int num = this.MyDailyMission[i].akMissionPairs.Length;
								MissionPair[] array2 = new MissionPair[num + 1];
								for (int k = 0; k < this.MyDailyMission[i].akMissionPairs.Length; k++)
								{
									array2[k] = this.MyDailyMission[i].akMissionPairs[k];
								}
								array2[num] = new MissionPair
								{
									key = sceneNotifyTaskVarRet.key,
									value = sceneNotifyTaskVarRet.value
								};
								this.MyDailyMission[i].akMissionPairs = array2;
							}
						}
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMyPupilMissionUpdate, null, null, null, null);
			}
			if (tableItem.TaskType == MissionTable.eTaskType.TASK_MASTER_ACADEMIC)
			{
				for (int l = 0; l < this.MyMission.Count; l++)
				{
					if (this.MyMission[l].taskID == sceneNotifyTaskVarRet.taskID)
					{
						if (this.MyMission[l].akMissionPairs.Length == 0)
						{
							MissionPair[] array3 = new MissionPair[]
							{
								new MissionPair()
							};
							array3[0].key = sceneNotifyTaskVarRet.key;
							array3[0].value = sceneNotifyTaskVarRet.value;
							this.MyMission[l].akMissionPairs = array3;
						}
						else
						{
							for (int m = 0; m < this.MyMission[l].akMissionPairs.Length; m++)
							{
								if (this.MyMission[l].akMissionPairs[m].key == sceneNotifyTaskVarRet.key)
								{
									this.MyMission[l].akMissionPairs[m].value = sceneNotifyTaskVarRet.value;
								}
							}
						}
					}
				}
				this.myTAPData.academicTasks = this.MyMission.ToArray();
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPLearningUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600BD25 RID: 48421 RVA: 0x002C3F20 File Offset: 0x002C2320
		private void _OnWorldSyncMasterDisciplePunishTime(MsgDATA msgData)
		{
			WorldSyncMasterDisciplePunishTime worldSyncMasterDisciplePunishTime = new WorldSyncMasterDisciplePunishTime();
			worldSyncMasterDisciplePunishTime.decode(msgData.bytes);
			this.teacherPublishTime = worldSyncMasterDisciplePunishTime.apprenticMasterPunishTime;
			this.pupilPublishTime = worldSyncMasterDisciplePunishTime.recruitDisciplePunishTime;
		}

		// Token: 0x0600BD26 RID: 48422 RVA: 0x002C3F58 File Offset: 0x002C2358
		private void _OnSyncOffline(MsgDATA msg)
		{
			WorldSyncOnOffline worldSyncOnOffline = new WorldSyncOnOffline();
			worldSyncOnOffline.decode(msg.bytes);
			if (this.classmateRelationDic.ContainsKey(worldSyncOnOffline.id))
			{
				this.classmateRelationDic[worldSyncOnOffline.id].status = worldSyncOnOffline.isOnline;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRefreshClassmateDic, null, null, null, null);
		}

		// Token: 0x0600BD27 RID: 48423 RVA: 0x002C3FBC File Offset: 0x002C23BC
		private void _OnWorldNotifyFinSchEvent(MsgDATA msg)
		{
			WorldNotifyFinSchEvent stream = new WorldNotifyFinSchEvent();
			stream.decode(msg.bytes);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPGraduationSuccess, null, null, null, null);
		}

		// Token: 0x04006A35 RID: 27189
		public const int TAPNpc = 2020;

		// Token: 0x04006A36 RID: 27190
		public TAPQuestionnaireInformation tapQuestionnaireInformation;

		// Token: 0x04006A37 RID: 27191
		private Dictionary<string, List<string>> firstLetterProvinceDic = new Dictionary<string, List<string>>();

		// Token: 0x04006A38 RID: 27192
		private Dictionary<string, int> provinceIDDic = new Dictionary<string, int>();

		// Token: 0x04006A39 RID: 27193
		private Dictionary<ulong, ClassmateRelationData> classmateRelationDic = new Dictionary<ulong, ClassmateRelationData>();

		// Token: 0x04006A3A RID: 27194
		private List<MissionInfo> MyDailyMission = new List<MissionInfo>();

		// Token: 0x04006A3B RID: 27195
		private List<MissionInfo> MyMission = new List<MissionInfo>();

		// Token: 0x04006A3C RID: 27196
		public MasterTaskShareData myTAPData = new MasterTaskShareData();

		// Token: 0x04006A3D RID: 27197
		private Dictionary<ulong, MasterTaskShareData> MyPupilMissionDic = new Dictionary<ulong, MasterTaskShareData>();

		// Token: 0x04006A3E RID: 27198
		private Dictionary<ulong, bool> relationRedPoint = new Dictionary<ulong, bool>();

		// Token: 0x04006A3F RID: 27199
		private ulong teacherPublishTime;

		// Token: 0x04006A40 RID: 27200
		private ulong pupilPublishTime;

		// Token: 0x04006A41 RID: 27201
		private bool haveTalkTeacher;

		// Token: 0x04006A42 RID: 27202
		private bool haveSearchTAP;

		// Token: 0x04006A44 RID: 27204
		private List<RelationData> m_TaskFinishedPupils = new List<RelationData>();
	}
}
