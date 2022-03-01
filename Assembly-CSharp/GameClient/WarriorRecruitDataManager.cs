using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001352 RID: 4946
	public class WarriorRecruitDataManager : DataManager<WarriorRecruitDataManager>
	{
		// Token: 0x0600BFAA RID: 49066 RVA: 0x002D1C5C File Offset: 0x002D005C
		public sealed override void Clear()
		{
			this.UnRegisterNetHandler();
			WarriorRecruitDataManager.inviteCode = string.Empty;
			WarriorRecruitDataManager.identify = 0;
			WarriorRecruitDataManager.isBindInviteCode = false;
			WarriorRecruitDataManager.isOtherBindMe = false;
			WarriorRecruitDataManager.isHireAlreadyBind = false;
			if (this.mAllTaskDataModelList != null)
			{
				this.mAllTaskDataModelList.Clear();
			}
			if (this.mRecruitCompanionsTaskList != null)
			{
				this.mRecruitCompanionsTaskList.Clear();
			}
			if (this.mRecruitmentBonusPreview_OldPlayerList != null)
			{
				this.mRecruitmentBonusPreview_OldPlayerList.Clear();
			}
			if (this.mRecruitmentBonusPreview_NewPlayerList != null)
			{
				this.mRecruitmentBonusPreview_NewPlayerList.Clear();
			}
		}

		// Token: 0x0600BFAB RID: 49067 RVA: 0x002D1CE9 File Offset: 0x002D00E9
		public sealed override void Initialize()
		{
			this.InitHireTaskTable();
			this.RegisterNetHandler();
			this.InitRecruitmentBonusPreviewData("RecruitmentBonusPreview_OldPlayer", ref this.mRecruitmentBonusPreview_OldPlayerList);
			this.InitRecruitmentBonusPreviewData("RecruitmentBonusPreview_NewPlayer", ref this.mRecruitmentBonusPreview_NewPlayerList);
		}

		// Token: 0x0600BFAC RID: 49068 RVA: 0x002D1D1C File Offset: 0x002D011C
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(601783U, new Action<MsgDATA>(this.OnQueryHireInfoRes));
			NetProcess.AddMsgHandler(601785U, new Action<MsgDATA>(this.OnUseHireCodeRes));
			NetProcess.AddMsgHandler(601787U, new Action<MsgDATA>(this.OnQueryTaskStatusRes));
			NetProcess.AddMsgHandler(601789U, new Action<MsgDATA>(this.OnQueryHireTaskAccidListRes));
			NetProcess.AddMsgHandler(601791U, new Action<MsgDATA>(this.OnQueryHireListRes));
			NetProcess.AddMsgHandler(601793U, new Action<MsgDATA>(this.OnSubmitHireTaskRes));
			NetProcess.AddMsgHandler(601798U, new Action<MsgDATA>(this.OnQueryHireAlreadyBindRes));
		}

		// Token: 0x0600BFAD RID: 49069 RVA: 0x002D1DC4 File Offset: 0x002D01C4
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(601783U, new Action<MsgDATA>(this.OnQueryHireInfoRes));
			NetProcess.RemoveMsgHandler(601785U, new Action<MsgDATA>(this.OnUseHireCodeRes));
			NetProcess.RemoveMsgHandler(601787U, new Action<MsgDATA>(this.OnQueryTaskStatusRes));
			NetProcess.RemoveMsgHandler(601789U, new Action<MsgDATA>(this.OnQueryHireTaskAccidListRes));
			NetProcess.RemoveMsgHandler(601791U, new Action<MsgDATA>(this.OnQueryHireListRes));
			NetProcess.RemoveMsgHandler(601793U, new Action<MsgDATA>(this.OnSubmitHireTaskRes));
			NetProcess.RemoveMsgHandler(601798U, new Action<MsgDATA>(this.OnQueryHireAlreadyBindRes));
		}

		// Token: 0x0600BFAE RID: 49070 RVA: 0x002D1E6C File Offset: 0x002D026C
		private void OnQueryHireInfoRes(MsgDATA msgData)
		{
			WorldQueryHireInfoRes worldQueryHireInfoRes = new WorldQueryHireInfoRes();
			worldQueryHireInfoRes.decode(msgData.bytes);
			WarriorRecruitDataManager.identify = worldQueryHireInfoRes.identity;
			WarriorRecruitDataManager.inviteCode = worldQueryHireInfoRes.code;
			WarriorRecruitDataManager.isBindInviteCode = (worldQueryHireInfoRes.isBind == 1);
			WarriorRecruitDataManager.isOtherBindMe = (worldQueryHireInfoRes.isOtherBindMe == 1);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorRecruitQueryIdentitySuccessed, null, null, null, null);
		}

		// Token: 0x0600BFAF RID: 49071 RVA: 0x002D1ED0 File Offset: 0x002D02D0
		private void OnUseHireCodeRes(MsgDATA msgData)
		{
			WorldUseHireCodeRes worldUseHireCodeRes = new WorldUseHireCodeRes();
			worldUseHireCodeRes.decode(msgData.bytes);
			if (worldUseHireCodeRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldUseHireCodeRes.errorCode, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyTextAnimation("绑定成功", CommonTipsDesc.eShowMode.SI_UNIQUE);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorRecruitBindInviteCodeSuccessed, null, null, null, null);
			}
		}

		// Token: 0x0600BFB0 RID: 49072 RVA: 0x002D1F30 File Offset: 0x002D0330
		private void OnQueryTaskStatusRes(MsgDATA msgData)
		{
			WorldQueryTaskStatusRes worldQueryTaskStatusRes = new WorldQueryTaskStatusRes();
			worldQueryTaskStatusRes.decode(msgData.bytes);
			for (int i = 0; i < worldQueryTaskStatusRes.hireTaskInfoList.Length; i++)
			{
				HireInfoData hireInfoData = worldQueryTaskStatusRes.hireTaskInfoList[i];
				if (hireInfoData != null)
				{
					for (int j = 0; j < this.mAllTaskDataModelList.Count; j++)
					{
						WarriorRecruitTaskDataModel warriorRecruitTaskDataModel = this.mAllTaskDataModelList[j];
						if (warriorRecruitTaskDataModel != null)
						{
							if ((long)warriorRecruitTaskDataModel.taskId == (long)((ulong)hireInfoData.taskID))
							{
								warriorRecruitTaskDataModel.state = (int)hireInfoData.status;
								warriorRecruitTaskDataModel.cnt = (int)hireInfoData.cnt;
								break;
							}
						}
					}
				}
			}
			this.mRecruitCompanionsTaskList = this.FilterRecruiIdentifyTask(4);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorRecruitQueryTaskSuccessed, null, null, null, null);
		}

		// Token: 0x0600BFB1 RID: 49073 RVA: 0x002D200C File Offset: 0x002D040C
		private void OnQueryHireTaskAccidListRes(MsgDATA msgData)
		{
			WorldQueryHireTaskAccidListRes worldQueryHireTaskAccidListRes = new WorldQueryHireTaskAccidListRes();
			worldQueryHireTaskAccidListRes.decode(msgData.bytes);
			List<string> list = new List<string>();
			for (int i = 0; i < worldQueryHireTaskAccidListRes.nameList.Length; i++)
			{
				list.Add(worldQueryHireTaskAccidListRes.nameList[i]);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<CompleteQuestPlayerLlistFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<CompleteQuestPlayerLlistFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CompleteQuestPlayerLlistFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x0600BFB2 RID: 49074 RVA: 0x002D2088 File Offset: 0x002D0488
		private void OnQueryHireListRes(MsgDATA msgData)
		{
			WorldQueryHireListRes worldQueryHireListRes = new WorldQueryHireListRes();
			worldQueryHireListRes.decode(msgData.bytes);
			List<RecruitPlayerInfo> list = new List<RecruitPlayerInfo>();
			for (int i = 0; i < worldQueryHireListRes.hireList.Length; i++)
			{
				HirePlayerData hirePlayerData = worldQueryHireListRes.hireList[i];
				if (hirePlayerData != null)
				{
					list.Add(new RecruitPlayerInfo
					{
						name = hirePlayerData.name,
						occu = hirePlayerData.occu,
						online = hirePlayerData.online,
						userId = hirePlayerData.userId,
						level = (int)hirePlayerData.lv
					});
				}
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RecruitListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RecruitListFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RecruitListFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x0600BFB3 RID: 49075 RVA: 0x002D2158 File Offset: 0x002D0558
		private void OnSubmitHireTaskRes(MsgDATA msgData)
		{
			WorldSubmitHireTaskRes worldSubmitHireTaskRes = new WorldSubmitHireTaskRes();
			worldSubmitHireTaskRes.decode(msgData.bytes);
			if (worldSubmitHireTaskRes.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldSubmitHireTaskRes.errorCode, string.Empty);
			}
			else
			{
				for (int i = 0; i < this.mAllTaskDataModelList.Count; i++)
				{
					WarriorRecruitTaskDataModel warriorRecruitTaskDataModel = this.mAllTaskDataModelList[i];
					if (warriorRecruitTaskDataModel != null)
					{
						if ((long)warriorRecruitTaskDataModel.taskId == (long)((ulong)worldSubmitHireTaskRes.taskId))
						{
							warriorRecruitTaskDataModel.state = 5;
							break;
						}
					}
				}
				for (int j = 0; j < this.mRecruitCompanionsTaskList.Count; j++)
				{
					WarriorRecruitTaskDataModel warriorRecruitTaskDataModel2 = this.mRecruitCompanionsTaskList[j];
					if (warriorRecruitTaskDataModel2 != null)
					{
						if ((long)warriorRecruitTaskDataModel2.taskId == (long)((ulong)worldSubmitHireTaskRes.taskId))
						{
							warriorRecruitTaskDataModel2.state = 5;
							break;
						}
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorRecruitReceiveRewardSuccessed, null, null, null, null);
			}
		}

		// Token: 0x0600BFB4 RID: 49076 RVA: 0x002D2260 File Offset: 0x002D0660
		private void OnQueryHireAlreadyBindRes(MsgDATA msgData)
		{
			WorldQueryHireAlreadyBindRes worldQueryHireAlreadyBindRes = new WorldQueryHireAlreadyBindRes();
			worldQueryHireAlreadyBindRes.decode(msgData.bytes);
			WarriorRecruitDataManager.isHireAlreadyBind = (worldQueryHireAlreadyBindRes.errorCode > 0U);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WarriorRecruitQueryHireAlreadyBindSuccessed, null, null, null, null);
		}

		// Token: 0x0600BFB5 RID: 49077 RVA: 0x002D22AC File Offset: 0x002D06AC
		public void SendHireInfoReq()
		{
			WorldQueryHireInfoReq cmd = new WorldQueryHireInfoReq();
			NetManager.Instance().SendCommand<WorldQueryHireInfoReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFB6 RID: 49078 RVA: 0x002D22CC File Offset: 0x002D06CC
		public void SendUseHireCodeReq(string code)
		{
			WorldUseHireCodeReq worldUseHireCodeReq = new WorldUseHireCodeReq();
			worldUseHireCodeReq.code = code;
			NetManager.Instance().SendCommand<WorldUseHireCodeReq>(ServerType.GATE_SERVER, worldUseHireCodeReq);
		}

		// Token: 0x0600BFB7 RID: 49079 RVA: 0x002D22F4 File Offset: 0x002D06F4
		public void SendQueryTaskStatusReq()
		{
			WorldQueryTaskStatusReq cmd = new WorldQueryTaskStatusReq();
			NetManager.Instance().SendCommand<WorldQueryTaskStatusReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFB8 RID: 49080 RVA: 0x002D2314 File Offset: 0x002D0714
		public void SendQueryHireTaskAccidListReq(int taskId)
		{
			WorldQueryHireTaskAccidListReq worldQueryHireTaskAccidListReq = new WorldQueryHireTaskAccidListReq();
			worldQueryHireTaskAccidListReq.taskId = (uint)taskId;
			NetManager.Instance().SendCommand<WorldQueryHireTaskAccidListReq>(ServerType.GATE_SERVER, worldQueryHireTaskAccidListReq);
		}

		// Token: 0x0600BFB9 RID: 49081 RVA: 0x002D233C File Offset: 0x002D073C
		public void SendQueryHireListReq()
		{
			WorldQueryHireListReq cmd = new WorldQueryHireListReq();
			NetManager.Instance().SendCommand<WorldQueryHireListReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFBA RID: 49082 RVA: 0x002D235C File Offset: 0x002D075C
		public void SendSubmitHireTaskReq(int taskId)
		{
			WorldSubmitHireTaskReq worldSubmitHireTaskReq = new WorldSubmitHireTaskReq();
			worldSubmitHireTaskReq.taskId = (uint)taskId;
			NetManager.Instance().SendCommand<WorldSubmitHireTaskReq>(ServerType.GATE_SERVER, worldSubmitHireTaskReq);
		}

		// Token: 0x0600BFBB RID: 49083 RVA: 0x002D2384 File Offset: 0x002D0784
		public void SendWorldQueryHireCoinReq()
		{
			WorldQueryHireCoinReq cmd = new WorldQueryHireCoinReq();
			NetManager.Instance().SendCommand<WorldQueryHireCoinReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFBC RID: 49084 RVA: 0x002D23A4 File Offset: 0x002D07A4
		public void SendWorldQueryHirePushReq(byte type)
		{
			WorldQueryHirePushReq worldQueryHirePushReq = new WorldQueryHirePushReq();
			worldQueryHirePushReq.type = type;
			NetManager.Instance().SendCommand<WorldQueryHirePushReq>(ServerType.GATE_SERVER, worldQueryHirePushReq);
		}

		// Token: 0x0600BFBD RID: 49085 RVA: 0x002D23CC File Offset: 0x002D07CC
		public void SendWorldQueryHireRedPointReq()
		{
			SceneQueryHireRedPointReq cmd = new SceneQueryHireRedPointReq();
			NetManager.Instance().SendCommand<SceneQueryHireRedPointReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFBE RID: 49086 RVA: 0x002D23EC File Offset: 0x002D07EC
		public void SendWorldQueryHireAlreadyBindReq()
		{
			WorldQueryHireAlreadyBindReq cmd = new WorldQueryHireAlreadyBindReq();
			NetManager.Instance().SendCommand<WorldQueryHireAlreadyBindReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BFBF RID: 49087 RVA: 0x002D240C File Offset: 0x002D080C
		public List<WarriorRecruitTaskDataModel> FilterRecruiIdentifyTask(int identify)
		{
			List<WarriorRecruitTaskDataModel> list = new List<WarriorRecruitTaskDataModel>();
			for (int i = 0; i < this.mAllTaskDataModelList.Count; i++)
			{
				WarriorRecruitTaskDataModel warriorRecruitTaskDataModel = this.mAllTaskDataModelList[i];
				if (warriorRecruitTaskDataModel != null)
				{
					if (warriorRecruitTaskDataModel.identify == identify)
					{
						list.Add(warriorRecruitTaskDataModel);
					}
				}
			}
			return list;
		}

		// Token: 0x0600BFC0 RID: 49088 RVA: 0x002D246C File Offset: 0x002D086C
		private void InitHireTaskTable()
		{
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<HireTask>())
			{
				HireTask hireTask = keyValuePair.Value as HireTask;
				if (hireTask != null)
				{
					WarriorRecruitTaskDataModel warriorRecruitTaskDataModel = new WarriorRecruitTaskDataModel();
					warriorRecruitTaskDataModel.fullcnt = hireTask.FullCnt;
					warriorRecruitTaskDataModel.identify = hireTask.Identify;
					warriorRecruitTaskDataModel.taskId = hireTask.ID;
					warriorRecruitTaskDataModel.taskType = hireTask.Type;
					warriorRecruitTaskDataModel.taskDesc = hireTask.Describe;
					warriorRecruitTaskDataModel.rewards = this.GetRewards(hireTask.Rewards);
					warriorRecruitTaskDataModel.linkId = hireTask.Link;
					this.mAllTaskDataModelList.Add(warriorRecruitTaskDataModel);
				}
			}
		}

		// Token: 0x0600BFC1 RID: 49089 RVA: 0x002D2528 File Offset: 0x002D0928
		private List<ItemSimpleData> GetRewards(string path)
		{
			List<ItemSimpleData> list = new List<ItemSimpleData>();
			foreach (string text in path.Split(new char[]
			{
				','
			}))
			{
				if (!(text == string.Empty))
				{
					string[] array2 = text.Split(new char[]
					{
						'_'
					});
					if (array2.Length >= 2)
					{
						int id = 0;
						int count = 0;
						int.TryParse(array2[0], out id);
						int.TryParse(array2[1], out count);
						list.Add(new ItemSimpleData(id, count));
					}
				}
			}
			return list;
		}

		// Token: 0x0600BFC2 RID: 49090 RVA: 0x002D25C8 File Offset: 0x002D09C8
		public bool CheckWarriorRecruitActiveIsOpen()
		{
			if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(this.warriorRecruitActiveID))
			{
				ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[this.warriorRecruitActiveID];
				if (activityInfo.state == 1)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BFC3 RID: 49091 RVA: 0x002D2614 File Offset: 0x002D0A14
		private void InitRecruitmentBonusPreviewData(string key, ref List<int> idList)
		{
			if (idList == null)
			{
				idList = new List<int>();
			}
			idList.Clear();
			string text = TR.Value(key);
			foreach (string text2 in text.Split(new char[]
			{
				'|'
			}))
			{
				if (!(text2 == string.Empty))
				{
					int item = 0;
					int.TryParse(text2, out item);
					idList.Add(item);
				}
			}
		}

		// Token: 0x0600BFC4 RID: 49092 RVA: 0x002D2694 File Offset: 0x002D0A94
		public bool IsRedPointShow()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_HIRE_RED_POINT);
			if (count <= 0)
			{
				return true;
			}
			for (int i = 0; i < this.mAllTaskDataModelList.Count; i++)
			{
				WarriorRecruitTaskDataModel warriorRecruitTaskDataModel = this.mAllTaskDataModelList[i];
				if (warriorRecruitTaskDataModel != null)
				{
					if (warriorRecruitTaskDataModel.state == 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600BFC5 RID: 49093 RVA: 0x002D2700 File Offset: 0x002D0B00
		public bool IsAcceptRecruitTabShow()
		{
			return ((WarriorRecruitDataManager.identify & 2) != 0 && WarriorRecruitDataManager.isBindInviteCode) || (!ClientApplication.playerinfo.CheckAllRoleLevelIsContainsParamLevel(20) && !WarriorRecruitDataManager.isHireAlreadyBind) || (WarriorRecruitDataManager.identify & 8) != 0 || ((WarriorRecruitDataManager.identify & 8) != 0 && (WarriorRecruitDataManager.identify & 2) == 0);
		}

		// Token: 0x04006C30 RID: 27696
		public static byte identify = 0;

		// Token: 0x04006C31 RID: 27697
		public static string inviteCode = string.Empty;

		// Token: 0x04006C32 RID: 27698
		public static bool isBindInviteCode = false;

		// Token: 0x04006C33 RID: 27699
		public static bool isHireAlreadyBind = false;

		// Token: 0x04006C34 RID: 27700
		public static bool isOtherBindMe = false;

		// Token: 0x04006C35 RID: 27701
		private List<WarriorRecruitTaskDataModel> mAllTaskDataModelList = new List<WarriorRecruitTaskDataModel>();

		// Token: 0x04006C36 RID: 27702
		public List<WarriorRecruitTaskDataModel> mRecruitCompanionsTaskList = new List<WarriorRecruitTaskDataModel>();

		// Token: 0x04006C37 RID: 27703
		public int warriorRecruitActiveID = 8800;

		// Token: 0x04006C38 RID: 27704
		public List<int> mRecruitmentBonusPreview_OldPlayerList = new List<int>();

		// Token: 0x04006C39 RID: 27705
		public List<int> mRecruitmentBonusPreview_NewPlayerList = new List<int>();
	}
}
