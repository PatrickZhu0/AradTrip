using System;
using System.Collections.Generic;
using ActivityLimitTime;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012E1 RID: 4833
	public class WeekSignInDataManager : DataManager<WeekSignInDataManager>
	{
		// Token: 0x0600BB8F RID: 48015 RVA: 0x002B8B49 File Offset: 0x002B6F49
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600BB90 RID: 48016 RVA: 0x002B8B51 File Offset: 0x002B6F51
		public override void Clear()
		{
			this.ClearData();
			this.UnBindNetEvents();
		}

		// Token: 0x0600BB91 RID: 48017 RVA: 0x002B8B60 File Offset: 0x002B6F60
		private void ClearData()
		{
			this._newPlayerPreviewAwardDataModelList.Clear();
			this._activityPreviewAwardDataModelList.Clear();
			if (this._newPlayerWeekSignInAwardDataModel != null)
			{
				this._newPlayerWeekSignInAwardDataModel.Reset();
			}
			if (this._activityWeekSignInAwardDataModel != null)
			{
				this._activityWeekSignInAwardDataModel.Reset();
			}
			this._newPlayerWeekSignInRecordList.Clear();
			this._activityWeekSignInRecordList.Clear();
			this._newPlayerWeekSignInOpActivityData = null;
			this._activityWeekSignInOpActivityData = null;
		}

		// Token: 0x0600BB92 RID: 48018 RVA: 0x002B8BD4 File Offset: 0x002B6FD4
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(707402U, new Action<MsgDATA>(this.OnReceiveGASWeekSignRecordRes));
			NetProcess.AddMsgHandler(507407U, new Action<MsgDATA>(this.OnSyncSceneWeekSignBoxNotify));
			NetProcess.AddMsgHandler(507406U, new Action<MsgDATA>(this.OnSyncSceneWeekSignNotify));
			NetProcess.AddMsgHandler(507409U, new Action<MsgDATA>(this.OnReceiveSceneWeekSignRewardRes));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskDataUpdate));
		}

		// Token: 0x0600BB93 RID: 48019 RVA: 0x002B8CA8 File Offset: 0x002B70A8
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(707402U, new Action<MsgDATA>(this.OnReceiveGASWeekSignRecordRes));
			NetProcess.RemoveMsgHandler(507407U, new Action<MsgDATA>(this.OnSyncSceneWeekSignBoxNotify));
			NetProcess.RemoveMsgHandler(507406U, new Action<MsgDATA>(this.OnSyncSceneWeekSignNotify));
			NetProcess.RemoveMsgHandler(507409U, new Action<MsgDATA>(this.OnReceiveSceneWeekSignRewardRes));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this.OnActivityLimitTimeDataUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskDataUpdate));
		}

		// Token: 0x0600BB94 RID: 48020 RVA: 0x002B8D79 File Offset: 0x002B7179
		public uint GetOpActTypeByWeekSignInType(WeekSignInType weekSignInType)
		{
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				return 5400U;
			}
			return 5500U;
		}

		// Token: 0x0600BB95 RID: 48021 RVA: 0x002B8D90 File Offset: 0x002B7190
		private void OnReceiveActivityLimitTimeTaskDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData data = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			this.ReceiveActivityLimitTimeTaskInfoUpdate(data);
		}

		// Token: 0x0600BB96 RID: 48022 RVA: 0x002B8DC4 File Offset: 0x002B71C4
		private void OnReceiveActivityLimitTimeTaskUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData data = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			this.ReceiveActivityLimitTimeTaskInfoUpdate(data);
		}

		// Token: 0x0600BB97 RID: 48023 RVA: 0x002B8DF8 File Offset: 0x002B71F8
		private void ReceiveActivityLimitTimeTaskInfoUpdate(LimitTimeActivityTaskUpdateData data)
		{
			if (data == null)
			{
				return;
			}
			OpActivityData weekSignInOpActivityDataByWeekSignInType = this.GetWeekSignInOpActivityDataByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
			if (weekSignInOpActivityDataByWeekSignInType != null && (ulong)weekSignInOpActivityDataByWeekSignInType.dataId == (ulong)((long)data.ActivityId))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, null, null, null, null);
				return;
			}
			weekSignInOpActivityDataByWeekSignInType = this.GetWeekSignInOpActivityDataByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
			if (weekSignInOpActivityDataByWeekSignInType != null && (ulong)weekSignInOpActivityDataByWeekSignInType.dataId == (ulong)((long)data.ActivityId))
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnActivityWeekSignInRedPointChanged, null, null, null, null);
				return;
			}
		}

		// Token: 0x0600BB98 RID: 48024 RVA: 0x002B8E78 File Offset: 0x002B7278
		private void OnActivityLimitTimeStateUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			IActivity activity = (IActivity)uiEvent.Param1;
			if (activity == null)
			{
				return;
			}
			uint id = activity.GetId();
			this.OnActivityLimitTimeInfoUpdate(id);
		}

		// Token: 0x0600BB99 RID: 48025 RVA: 0x002B8EB8 File Offset: 0x002B72B8
		private void OnActivityLimitTimeDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint activityId = (uint)uiEvent.Param1;
			this.OnActivityLimitTimeInfoUpdate(activityId);
		}

		// Token: 0x0600BB9A RID: 48026 RVA: 0x002B8EEC File Offset: 0x002B72EC
		private void OnActivityLimitTimeInfoUpdate(uint activityId)
		{
			OpActivityData weekSignInOpActivityDataByWeekSignInType = this.GetWeekSignInOpActivityDataByWeekSignInType(WeekSignInType.NewPlayerWeekSignIn);
			if (weekSignInOpActivityDataByWeekSignInType != null && weekSignInOpActivityDataByWeekSignInType.dataId == activityId)
			{
				this._newPlayerWeekSignInOpActivityData = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_WEEK_SIGN_NEW_PLAYER);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, null, null, null, null);
				return;
			}
			weekSignInOpActivityDataByWeekSignInType = this.GetWeekSignInOpActivityDataByWeekSignInType(WeekSignInType.ActivityWeekSignIn);
			if (weekSignInOpActivityDataByWeekSignInType != null && weekSignInOpActivityDataByWeekSignInType.dataId == activityId)
			{
				this._activityWeekSignInOpActivityData = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_WEEK_SIGN_ACTIVITY);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnActivityWeekSignInRedPointChanged, null, null, null, null);
				return;
			}
		}

		// Token: 0x0600BB9B RID: 48027 RVA: 0x002B8F80 File Offset: 0x002B7380
		private void OnSyncSceneWeekSignBoxNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("OnSyncSceneWeekSignNotice MsgData is null", new object[0]);
				return;
			}
			SceneWeekSignBoxNotify sceneWeekSignBoxNotify = new SceneWeekSignBoxNotify();
			sceneWeekSignBoxNotify.decode(msgData.bytes);
			if (sceneWeekSignBoxNotify.opActType == 5400U)
			{
				this._newPlayerWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.NewPlayerWeekSignIn;
				this._newPlayerWeekSignInAwardDataModel.WeekSignInBoxItemList.Clear();
				for (int i = 0; i < sceneWeekSignBoxNotify.boxData.Length; i++)
				{
					this._newPlayerWeekSignInAwardDataModel.WeekSignInBoxItemList.Add(sceneWeekSignBoxNotify.boxData[i]);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncSceneWeekSignBoxNotify, WeekSignInType.NewPlayerWeekSignIn, null, null, null);
			}
			else if (sceneWeekSignBoxNotify.opActType == 5500U)
			{
				this._activityWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.ActivityWeekSignIn;
				this._activityWeekSignInAwardDataModel.WeekSignInBoxItemList.Clear();
				for (int j = 0; j < sceneWeekSignBoxNotify.boxData.Length; j++)
				{
					this._activityWeekSignInAwardDataModel.WeekSignInBoxItemList.Add(sceneWeekSignBoxNotify.boxData[j]);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncSceneWeekSignBoxNotify, WeekSignInType.ActivityWeekSignIn, null, null, null);
			}
		}

		// Token: 0x0600BB9C RID: 48028 RVA: 0x002B90A8 File Offset: 0x002B74A8
		public WeekSignBox GetWeekSignBoxByWeekSignInType(WeekSignInType weekSignInType, int opActTaskId)
		{
			WeekSignInAwardDataModel weekSignInAwardDataModelByWeekSignInType = this.GetWeekSignInAwardDataModelByWeekSignInType(weekSignInType);
			if (weekSignInAwardDataModelByWeekSignInType == null || weekSignInAwardDataModelByWeekSignInType.WeekSignInBoxItemList == null || weekSignInAwardDataModelByWeekSignInType.WeekSignInBoxItemList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < weekSignInAwardDataModelByWeekSignInType.WeekSignInBoxItemList.Count; i++)
			{
				if ((ulong)weekSignInAwardDataModelByWeekSignInType.WeekSignInBoxItemList[i].opActId == (ulong)((long)opActTaskId))
				{
					return weekSignInAwardDataModelByWeekSignInType.WeekSignInBoxItemList[i];
				}
			}
			return null;
		}

		// Token: 0x0600BB9D RID: 48029 RVA: 0x002B9124 File Offset: 0x002B7524
		private void OnSyncSceneWeekSignNotify(MsgDATA msgData)
		{
			if (msgData == null)
			{
				Logger.LogErrorFormat("OnSyncSceneWeekSignNotice MsgData is null", new object[0]);
				return;
			}
			SceneWeekSignNotify sceneWeekSignNotify = new SceneWeekSignNotify();
			sceneWeekSignNotify.decode(msgData.bytes);
			if (sceneWeekSignNotify.opActType == 5400U)
			{
				this._newPlayerWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.NewPlayerWeekSignIn;
				this._newPlayerWeekSignInAwardDataModel.AlreadySignInWeek = sceneWeekSignNotify.signWeekSum;
				this._newPlayerWeekSignInAwardDataModel.AlreadyReceiveWeekList.Clear();
				for (int i = 0; i < sceneWeekSignNotify.yetWeek.Length; i++)
				{
					this._newPlayerWeekSignInAwardDataModel.AlreadyReceiveWeekList.Add(sceneWeekSignNotify.yetWeek[i]);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncSceneWeekSignInNotify, WeekSignInType.NewPlayerWeekSignIn, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnNewPlayerWeekSignInRedPointChanged, null, null, null, null);
			}
			else if (sceneWeekSignNotify.opActType == 5500U)
			{
				this._activityWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.ActivityWeekSignIn;
				this._activityWeekSignInAwardDataModel.AlreadySignInWeek = sceneWeekSignNotify.signWeekSum;
				this._activityWeekSignInAwardDataModel.AlreadyReceiveWeekList.Clear();
				for (int j = 0; j < sceneWeekSignNotify.yetWeek.Length; j++)
				{
					this._activityWeekSignInAwardDataModel.AlreadyReceiveWeekList.Add(sceneWeekSignNotify.yetWeek[j]);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSyncSceneWeekSignInNotify, WeekSignInType.ActivityWeekSignIn, null, null, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnActivityWeekSignInRedPointChanged, null, null, null, null);
			}
		}

		// Token: 0x0600BB9E RID: 48030 RVA: 0x002B9294 File Offset: 0x002B7694
		private void OnReceiveSceneWeekSignRewardRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneWeekSignRewardRes sceneWeekSignRewardRes = new SceneWeekSignRewardRes();
			sceneWeekSignRewardRes.decode(msgData.bytes);
			if (sceneWeekSignRewardRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneWeekSignRewardRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600BB9F RID: 48031 RVA: 0x002B92D8 File Offset: 0x002B76D8
		public void SendSceneWeekSignRewardReq(uint opActType, uint weekId)
		{
			SceneWeekSignRewardReq sceneWeekSignRewardReq = new SceneWeekSignRewardReq();
			sceneWeekSignRewardReq.opActType = opActType;
			sceneWeekSignRewardReq.weekID = weekId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneWeekSignRewardReq>(ServerType.GATE_SERVER, sceneWeekSignRewardReq);
			}
		}

		// Token: 0x0600BBA0 RID: 48032 RVA: 0x002B9314 File Offset: 0x002B7714
		public void SendGASWeekSignRecordReq(WeekSignInType weekSignInType)
		{
			GASWeekSignRecordReq gasweekSignRecordReq = new GASWeekSignRecordReq();
			uint opActTypeByWeekSignInType = this.GetOpActTypeByWeekSignInType(weekSignInType);
			gasweekSignRecordReq.opActType = opActTypeByWeekSignInType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<GASWeekSignRecordReq>(ServerType.GATE_SERVER, gasweekSignRecordReq);
			}
		}

		// Token: 0x0600BBA1 RID: 48033 RVA: 0x002B9354 File Offset: 0x002B7754
		private void OnReceiveGASWeekSignRecordRes(MsgDATA msgData)
		{
			GASWeekSignRecordRes gasweekSignRecordRes = new GASWeekSignRecordRes();
			gasweekSignRecordRes.decode(msgData.bytes);
			if (gasweekSignRecordRes.opActType == 5400U)
			{
				this._newPlayerWeekSignInRecordList.Clear();
				if (gasweekSignRecordRes.record != null && gasweekSignRecordRes.record.Length > 0)
				{
					for (int i = 0; i < gasweekSignRecordRes.record.Length; i++)
					{
						this._newPlayerWeekSignInRecordList.Add(gasweekSignRecordRes.record[i]);
					}
					if (this._newPlayerWeekSignInRecordList != null && this._newPlayerWeekSignInRecordList.Count > 1)
					{
						this._newPlayerWeekSignInRecordList.Sort((WeekSignRecord x, WeekSignRecord y) => -x.createTime.CompareTo(y.createTime));
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveGasWeekSignInRecordRes, WeekSignInType.NewPlayerWeekSignIn, null, null, null);
			}
			else if (gasweekSignRecordRes.opActType == 5500U)
			{
				this._activityWeekSignInRecordList.Clear();
				if (gasweekSignRecordRes.record != null && gasweekSignRecordRes.record.Length > 0)
				{
					for (int j = 0; j < gasweekSignRecordRes.record.Length; j++)
					{
						this._activityWeekSignInRecordList.Add(gasweekSignRecordRes.record[j]);
					}
					if (this._activityWeekSignInRecordList != null && this._activityWeekSignInRecordList.Count > 1)
					{
						this._activityWeekSignInRecordList.Sort((WeekSignRecord x, WeekSignRecord y) => -x.createTime.CompareTo(y.createTime));
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveGasWeekSignInRecordRes, WeekSignInType.ActivityWeekSignIn, null, null, null);
			}
		}

		// Token: 0x0600BBA2 RID: 48034 RVA: 0x002B94F0 File Offset: 0x002B78F0
		public List<WeekSignRecord> GetWeekSignInRecordListByWeekSignInType(WeekSignInType weekSignInType)
		{
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				return this._newPlayerWeekSignInRecordList;
			}
			if (weekSignInType == WeekSignInType.ActivityWeekSignIn)
			{
				return this._activityWeekSignInRecordList;
			}
			return null;
		}

		// Token: 0x0600BBA3 RID: 48035 RVA: 0x002B950F File Offset: 0x002B790F
		public void ResetWeekSignInRecord()
		{
			this._activityWeekSignInRecordList.Clear();
			this._newPlayerWeekSignInRecordList.Clear();
		}

		// Token: 0x0600BBA4 RID: 48036 RVA: 0x002B9528 File Offset: 0x002B7928
		public List<WeekSignInPreviewAwardDataModel> GetPreviewAwardItemDataModelListByWeekSignInType(WeekSignInType weekSignInType)
		{
			List<WeekSignInPreviewAwardDataModel> list = this._activityPreviewAwardDataModelList;
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				list = this._newPlayerPreviewAwardDataModelList;
			}
			if (list.Count > 0)
			{
				return list;
			}
			uint opActTypeByWeekSignInType = this.GetOpActTypeByWeekSignInType(weekSignInType);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<WeekSignTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				WeekSignTable weekSignTable = keyValuePair.Value as WeekSignTable;
				if (weekSignTable != null && (long)weekSignTable.opActType == (long)((ulong)opActTypeByWeekSignInType) && weekSignTable.Preview == 1)
				{
					WeekSignInPreviewAwardDataModel item = new WeekSignInPreviewAwardDataModel
					{
						OpActType = weekSignTable.opActType,
						ItemId = weekSignTable.rewardId,
						ItemNumber = weekSignTable.rewardNum,
						IsSpecialAward = (weekSignTable.isBigReward == 1),
						SortId = weekSignTable.sortId
					};
					list.Add(item);
				}
			}
			if (list.Count > 0)
			{
				list.Sort((WeekSignInPreviewAwardDataModel x, WeekSignInPreviewAwardDataModel y) => x.SortId.CompareTo(y.SortId));
			}
			return list;
		}

		// Token: 0x0600BBA5 RID: 48037 RVA: 0x002B9654 File Offset: 0x002B7A54
		public WeekSignInAwardDataModel GetWeekSignInAwardDataModelByWeekSignInType(WeekSignInType weekSignInType)
		{
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				if (this._newPlayerWeekSignInAwardDataModel.WeekSignInType == WeekSignInType.None)
				{
					this._newPlayerWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.NewPlayerWeekSignIn;
				}
				if (this._newPlayerWeekSignInAwardDataModel.WeekSignSumTableList == null || this._newPlayerWeekSignInAwardDataModel.WeekSignSumTableList.Count <= 0)
				{
					this._newPlayerWeekSignInAwardDataModel.WeekSignSumTableList = WeekSignInUtility.GetWeekSignSumTableListByWeekSignSumTablesInType(WeekSignInType.NewPlayerWeekSignIn);
				}
				return this._newPlayerWeekSignInAwardDataModel;
			}
			if (weekSignInType == WeekSignInType.ActivityWeekSignIn)
			{
				if (this._activityWeekSignInAwardDataModel.WeekSignInType == WeekSignInType.None)
				{
					this._activityWeekSignInAwardDataModel.WeekSignInType = WeekSignInType.ActivityWeekSignIn;
				}
				if (this._activityWeekSignInAwardDataModel.WeekSignSumTableList == null || this._activityWeekSignInAwardDataModel.WeekSignSumTableList.Count <= 0)
				{
					this._activityWeekSignInAwardDataModel.WeekSignSumTableList = WeekSignInUtility.GetWeekSignSumTableListByWeekSignSumTablesInType(WeekSignInType.ActivityWeekSignIn);
				}
				return this._activityWeekSignInAwardDataModel;
			}
			return null;
		}

		// Token: 0x0600BBA6 RID: 48038 RVA: 0x002B9724 File Offset: 0x002B7B24
		public OpActivityData GetWeekSignInOpActivityDataByWeekSignInType(WeekSignInType weekSignInType)
		{
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				if (this._newPlayerWeekSignInOpActivityData == null)
				{
					this._newPlayerWeekSignInOpActivityData = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_WEEK_SIGN_NEW_PLAYER);
				}
				return this._newPlayerWeekSignInOpActivityData;
			}
			if (this._activityWeekSignInOpActivityData == null)
			{
				this._activityWeekSignInOpActivityData = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_WEEK_SIGN_ACTIVITY);
			}
			return this._activityWeekSignInOpActivityData;
		}

		// Token: 0x0600BBA7 RID: 48039 RVA: 0x002B9788 File Offset: 0x002B7B88
		public string GetWeekSignInTimeLabelByWeekSignInType(WeekSignInType weekSignInType)
		{
			OpActivityData weekSignInOpActivityDataByWeekSignInType = this.GetWeekSignInOpActivityDataByWeekSignInType(weekSignInType);
			if (weekSignInOpActivityDataByWeekSignInType == null)
			{
				return string.Empty;
			}
			string oneData = Function.GetOneData((int)weekSignInOpActivityDataByWeekSignInType.startTime);
			string oneData2 = Function.GetOneData((int)weekSignInOpActivityDataByWeekSignInType.endTime);
			if (weekSignInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				return TR.Value("week_sing_in_new_player_time", oneData, oneData2);
			}
			return TR.Value("week_sing_in_activity_time", oneData, oneData2);
		}

		// Token: 0x0600BBA8 RID: 48040 RVA: 0x002B97E1 File Offset: 0x002B7BE1
		public void OnSendRequestOnTakeActTask(uint activityDataId, uint taskDataId)
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityDataId, taskDataId);
		}

		// Token: 0x04006969 RID: 26985
		public const string NewPlayerTaskAwardBoxImagePath = "UI/Image/Icon/Icon_Jar/item_jar_01.png:item_jar_01";

		// Token: 0x0400696A RID: 26986
		public const string NewPlayerTaskAwardBoxEffectPath = "UIFlatten/Prefabs/Jar/EffUI_xiuzhenguan02";

		// Token: 0x0400696B RID: 26987
		public const string ActivityTaskAwardBoxImagePath = "UI/Image/Icon/Icon_Jar/item_jar_05.png:item_jar_05";

		// Token: 0x0400696C RID: 26988
		public const string ActivityTaskAwardBoxEffectPath = "UIFlatten/Prefabs/Jar/EffUI_xiuzhenguan06";

		// Token: 0x0400696D RID: 26989
		public const string ActivityWeekSignInStr = "ActivityWeekSignIn";

		// Token: 0x0400696E RID: 26990
		public const string NewPlayerWeekSignInStr = "NewPlayerWeekSignIn";

		// Token: 0x0400696F RID: 26991
		public const int WeekSignInConfigId = 9380;

		// Token: 0x04006970 RID: 26992
		public const uint NewPlayerWeekSignInOpActTypeId = 5400U;

		// Token: 0x04006971 RID: 26993
		public const uint ActivityWeekSignInOpActTypeId = 5500U;

		// Token: 0x04006972 RID: 26994
		public const int NewPlayerWeekSignInTipDesId = 10018;

		// Token: 0x04006973 RID: 26995
		public const int ActivityWeekSignInTipDesId = 10019;

		// Token: 0x04006974 RID: 26996
		private OpActivityData _newPlayerWeekSignInOpActivityData;

		// Token: 0x04006975 RID: 26997
		private OpActivityData _activityWeekSignInOpActivityData;

		// Token: 0x04006976 RID: 26998
		private List<WeekSignInPreviewAwardDataModel> _newPlayerPreviewAwardDataModelList = new List<WeekSignInPreviewAwardDataModel>();

		// Token: 0x04006977 RID: 26999
		private List<WeekSignInPreviewAwardDataModel> _activityPreviewAwardDataModelList = new List<WeekSignInPreviewAwardDataModel>();

		// Token: 0x04006978 RID: 27000
		private WeekSignInAwardDataModel _newPlayerWeekSignInAwardDataModel = new WeekSignInAwardDataModel();

		// Token: 0x04006979 RID: 27001
		private WeekSignInAwardDataModel _activityWeekSignInAwardDataModel = new WeekSignInAwardDataModel();

		// Token: 0x0400697A RID: 27002
		private List<WeekSignRecord> _newPlayerWeekSignInRecordList = new List<WeekSignRecord>();

		// Token: 0x0400697B RID: 27003
		private List<WeekSignRecord> _activityWeekSignInRecordList = new List<WeekSignRecord>();
	}
}
