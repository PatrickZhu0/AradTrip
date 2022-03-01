using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A94 RID: 6804
	public class WeekSignInAwardControl : MonoBehaviour
	{
		// Token: 0x06010B31 RID: 68401 RVA: 0x004BC69A File Offset: 0x004BAA9A
		private void Awake()
		{
			this.BindComEvents();
		}

		// Token: 0x06010B32 RID: 68402 RVA: 0x004BC6A2 File Offset: 0x004BAAA2
		private void OnDestroy()
		{
			this.UnBindComEvents();
			this.ClearData();
		}

		// Token: 0x06010B33 RID: 68403 RVA: 0x004BC6B0 File Offset: 0x004BAAB0
		private void OnEnable()
		{
			this.BindUiEvents();
		}

		// Token: 0x06010B34 RID: 68404 RVA: 0x004BC6B8 File Offset: 0x004BAAB8
		private void OnDisable()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06010B35 RID: 68405 RVA: 0x004BC6C0 File Offset: 0x004BAAC0
		private void ClearData()
		{
			this._weekSignInType = WeekSignInType.None;
			this._awardDataModel = null;
			this._opActivityData = null;
			this._weekSignSumTableList = null;
			this._weekSignInTaskDataList.Clear();
		}

		// Token: 0x06010B36 RID: 68406 RVA: 0x004BC6EC File Offset: 0x004BAAEC
		private void BindComEvents()
		{
			if (this.taskAwardItemList != null)
			{
				this.taskAwardItemList.Initialize();
				ComUIListScript comUIListScript = this.taskAwardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTaskAwardItemVisible));
				ComUIListScript comUIListScript2 = this.taskAwardItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTaskAwardItemUpdate));
			}
			if (this.totalAwardItemList != null)
			{
				this.totalAwardItemList.Initialize();
				ComUIListScript comUIListScript3 = this.totalAwardItemList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTotalAwardItemVisible));
				ComUIListScript comUIListScript4 = this.totalAwardItemList;
				comUIListScript4.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript4.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTotalAwardItemUpdate));
			}
			if (this.commonTimeRefreshControl != null)
			{
				this.commonTimeRefreshControl.SetInvokeAction(new Action(this.UpdateCurrentWeekValue));
			}
		}

		// Token: 0x06010B37 RID: 68407 RVA: 0x004BC7F8 File Offset: 0x004BABF8
		private void UnBindComEvents()
		{
			if (this.taskAwardItemList != null)
			{
				ComUIListScript comUIListScript = this.taskAwardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTaskAwardItemVisible));
				ComUIListScript comUIListScript2 = this.taskAwardItemList;
				comUIListScript2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTaskAwardItemUpdate));
			}
			if (this.totalAwardItemList != null)
			{
				ComUIListScript comUIListScript3 = this.totalAwardItemList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTotalAwardItemVisible));
				ComUIListScript comUIListScript4 = this.totalAwardItemList;
				comUIListScript4.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript4.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnTotalAwardItemUpdate));
			}
			if (this.commonTimeRefreshControl != null)
			{
				this.commonTimeRefreshControl.ResetInvokeAction();
			}
		}

		// Token: 0x06010B38 RID: 68408 RVA: 0x004BC8E0 File Offset: 0x004BACE0
		private void BindUiEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncSceneWeekSignInNotify, new ClientEventSystem.UIEventHandler(this.OnSyncSceneWeekSignInNotify));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskDataUpdate));
		}

		// Token: 0x06010B39 RID: 68409 RVA: 0x004BC940 File Offset: 0x004BAD40
		private void UnBindUiEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncSceneWeekSignInNotify, new ClientEventSystem.UIEventHandler(this.OnSyncSceneWeekSignInNotify));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskDataUpdate, new ClientEventSystem.UIEventHandler(this.OnReceiveActivityLimitTimeTaskDataUpdate));
		}

		// Token: 0x06010B3A RID: 68410 RVA: 0x004BC9A0 File Offset: 0x004BADA0
		public void InitAwardControl(WeekSignInType weekSignInType)
		{
			this._weekSignInType = weekSignInType;
			if (this._weekSignInType == WeekSignInType.None)
			{
				Logger.LogErrorFormat("WeekSingInType is None", new object[0]);
				return;
			}
			this._opActivityData = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInOpActivityDataByWeekSignInType(this._weekSignInType);
			if (this._opActivityData == null)
			{
				Logger.LogErrorFormat("OPActivityData is null and WeekSignInType is {0}", new object[]
				{
					this._weekSignInType
				});
				return;
			}
			this._awardDataModel = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInAwardDataModelByWeekSignInType(this._weekSignInType);
			if (this._awardDataModel == null)
			{
				Logger.LogErrorFormat("WeekSingInAwardDataModel is null and weekSingInType is {0}", new object[]
				{
					this._weekSignInType
				});
				return;
			}
			this._weekSignSumTableList = this._awardDataModel.WeekSignSumTableList;
			this.InitAwardControlView();
		}

		// Token: 0x06010B3B RID: 68411 RVA: 0x004BCA68 File Offset: 0x004BAE68
		public void OnEnableAwardControl()
		{
			if (this._awardDataModel == null)
			{
				return;
			}
			this.UpdateWeekSignInWeekNumberValue();
			if (this.taskAwardItemList != null)
			{
				this.taskAwardItemList.UpdateElement();
			}
			if (this.totalAwardItemList != null)
			{
				this.totalAwardItemList.UpdateElement();
			}
		}

		// Token: 0x06010B3C RID: 68412 RVA: 0x004BCABF File Offset: 0x004BAEBF
		private void InitAwardControlView()
		{
			this.UpdateWeekSignInTaskAwardItemList();
			this.UpdateWeekSignInWeekNumberValue();
			this.UpdateWeekSignInTotalAwardItemList();
			this.ResetTotalAwardItemList();
		}

		// Token: 0x06010B3D RID: 68413 RVA: 0x004BCADC File Offset: 0x004BAEDC
		private void UpdateWeekSignInTaskAwardItemList()
		{
			this._weekSignInTaskDataList.Clear();
			if (this._opActivityData == null || this._opActivityData.tasks == null)
			{
				return;
			}
			for (int i = 0; i < this._opActivityData.tasks.Length; i++)
			{
				this._weekSignInTaskDataList.Add(this._opActivityData.tasks[i]);
			}
			int count = this._weekSignInTaskDataList.Count;
			if (this.taskAwardItemList != null)
			{
				this.taskAwardItemList.SetElementAmount(count);
			}
		}

		// Token: 0x06010B3E RID: 68414 RVA: 0x004BCB70 File Offset: 0x004BAF70
		private void OnTaskAwardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.taskAwardItemList == null)
			{
				return;
			}
			if (this._weekSignInTaskDataList == null || this._weekSignInTaskDataList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._weekSignInTaskDataList.Count)
			{
				return;
			}
			OpActTaskData opActTaskData = this._weekSignInTaskDataList[item.m_index];
			WeekSignInTaskAwardItem component = item.GetComponent<WeekSignInTaskAwardItem>();
			if (opActTaskData != null && component != null)
			{
				component.InitItem(this._weekSignInType, this._opActivityData.dataId, opActTaskData);
			}
		}

		// Token: 0x06010B3F RID: 68415 RVA: 0x004BCC20 File Offset: 0x004BB020
		private void OnTaskAwardItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			WeekSignInTaskAwardItem component = item.GetComponent<WeekSignInTaskAwardItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x06010B40 RID: 68416 RVA: 0x004BCC54 File Offset: 0x004BB054
		private void OnTaskAwardItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			WeekSignInTaskAwardItem component = item.GetComponent<WeekSignInTaskAwardItem>();
			if (component != null)
			{
				component.OnItemUpdate();
			}
		}

		// Token: 0x06010B41 RID: 68417 RVA: 0x004BCC87 File Offset: 0x004BB087
		private void UpdateWeekSignInWeekNumberValue()
		{
			this.UpdateAlreadySignInWeek();
			this.UpdateCurrentWeekValue();
		}

		// Token: 0x06010B42 RID: 68418 RVA: 0x004BCC98 File Offset: 0x004BB098
		private void UpdateCurrentWeekValue()
		{
			if (this._awardDataModel == null)
			{
				return;
			}
			if (this._opActivityData == null)
			{
				return;
			}
			int weekNumberBetweenTime = TimeUtility.GetWeekNumberBetweenTime((ulong)this._opActivityData.startTime, (ulong)DataManager<TimeManager>.GetInstance().GetServerTime());
			int weekNumberBetweenTime2 = TimeUtility.GetWeekNumberBetweenTime((ulong)this._opActivityData.startTime, (ulong)this._opActivityData.endTime);
			if (this.currentSignInWeek != null)
			{
				this.currentSignInWeek.text = string.Format(TR.Value("week_sing_in_now_week"), weekNumberBetweenTime, weekNumberBetweenTime2);
			}
		}

		// Token: 0x06010B43 RID: 68419 RVA: 0x004BCD30 File Offset: 0x004BB130
		private void UpdateAlreadySignInWeek()
		{
			if (this._awardDataModel == null)
			{
				return;
			}
			if (this._opActivityData == null)
			{
				return;
			}
			int weekNumberBetweenTime = TimeUtility.GetWeekNumberBetweenTime((ulong)this._opActivityData.startTime, (ulong)DataManager<TimeManager>.GetInstance().GetServerTime());
			if (this.alreadySignInWeek != null)
			{
				if ((ulong)this._awardDataModel.AlreadySignInWeek < (ulong)((long)weekNumberBetweenTime))
				{
					this.alreadySignInWeek.text = string.Format(TR.Value("week_sing_in_get_less_week"), this._awardDataModel.AlreadySignInWeek);
				}
				else
				{
					this.alreadySignInWeek.text = string.Format(TR.Value("week_sign_in_get_week"), this._awardDataModel.AlreadySignInWeek);
				}
			}
		}

		// Token: 0x06010B44 RID: 68420 RVA: 0x004BCDF0 File Offset: 0x004BB1F0
		private void UpdateWeekSignInTotalAwardItemList()
		{
			int elementAmount = 0;
			if (this._weekSignSumTableList != null)
			{
				elementAmount = this._weekSignSumTableList.Count;
			}
			if (this.totalAwardItemList != null)
			{
				this.totalAwardItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x06010B45 RID: 68421 RVA: 0x004BCE34 File Offset: 0x004BB234
		private void OnTotalAwardItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._awardDataModel == null)
			{
				return;
			}
			if (this.totalAwardItemList == null)
			{
				return;
			}
			if (this._weekSignSumTableList == null || this._weekSignSumTableList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._weekSignSumTableList.Count)
			{
				return;
			}
			WeekSignSumTable weekSignSumTable = this._weekSignSumTableList[item.m_index];
			WeekSignInTotalAwardItem component = item.GetComponent<WeekSignInTotalAwardItem>();
			if (weekSignSumTable != null && component != null)
			{
				component.InitItem(this._weekSignInType, weekSignSumTable);
			}
		}

		// Token: 0x06010B46 RID: 68422 RVA: 0x004BCEE4 File Offset: 0x004BB2E4
		private void ResetTotalAwardItemList()
		{
			if (this._awardDataModel == null)
			{
				return;
			}
			if (this.totalAwardItemList == null)
			{
				return;
			}
			if (this._weekSignSumTableList == null)
			{
				return;
			}
			int count = this._weekSignSumTableList.Count;
			int firstTotalAwardItemIndex = WeekSignInUtility.GetFirstTotalAwardItemIndex(this._weekSignInType);
			if (firstTotalAwardItemIndex <= 1)
			{
				this.totalAwardItemList.MoveElementInScrollArea(0, true);
			}
			else if (firstTotalAwardItemIndex >= count - 2)
			{
				this.totalAwardItemList.MoveElementInScrollArea(count - 1, true);
			}
			else
			{
				this.totalAwardItemList.MoveElementInScrollArea(firstTotalAwardItemIndex + 1, true);
			}
		}

		// Token: 0x06010B47 RID: 68423 RVA: 0x004BCF78 File Offset: 0x004BB378
		private void OnTotalAwardItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			WeekSignInTotalAwardItem component = item.GetComponent<WeekSignInTotalAwardItem>();
			if (component != null)
			{
				component.OnItemUpdate();
			}
		}

		// Token: 0x06010B48 RID: 68424 RVA: 0x004BCFAB File Offset: 0x004BB3AB
		private void OnSyncSceneWeekSignInNotify(UIEvent uiEvent)
		{
			this.UpdateWeekSignInWeekNumberValue();
			this.UpdateWeekSignInTotalAwardItemList();
		}

		// Token: 0x06010B49 RID: 68425 RVA: 0x004BCFBC File Offset: 0x004BB3BC
		private void OnReceiveActivityLimitTimeTaskDataUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData data = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			this.ReceiveActivityLimitTimeTaskInfoUpdate(data);
		}

		// Token: 0x06010B4A RID: 68426 RVA: 0x004BCFF0 File Offset: 0x004BB3F0
		private void OnReceiveActivityLimitTimeTaskUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			LimitTimeActivityTaskUpdateData data = (LimitTimeActivityTaskUpdateData)uiEvent.Param1;
			this.ReceiveActivityLimitTimeTaskInfoUpdate(data);
		}

		// Token: 0x06010B4B RID: 68427 RVA: 0x004BD022 File Offset: 0x004BB422
		private void ReceiveActivityLimitTimeTaskInfoUpdate(LimitTimeActivityTaskUpdateData data)
		{
			if (data == null)
			{
				return;
			}
			if (this._opActivityData != null && (ulong)this._opActivityData.dataId == (ulong)((long)data.ActivityId))
			{
				this.UpdateWeekSignInWeekNumberValue();
			}
		}

		// Token: 0x0400AACB RID: 43723
		private WeekSignInType _weekSignInType;

		// Token: 0x0400AACC RID: 43724
		private WeekSignInAwardDataModel _awardDataModel;

		// Token: 0x0400AACD RID: 43725
		private List<WeekSignSumTable> _weekSignSumTableList;

		// Token: 0x0400AACE RID: 43726
		private OpActivityData _opActivityData;

		// Token: 0x0400AACF RID: 43727
		private List<OpActTaskData> _weekSignInTaskDataList = new List<OpActTaskData>();

		// Token: 0x0400AAD0 RID: 43728
		[Space(15f)]
		[Header("TaskAward")]
		[Space(15f)]
		[SerializeField]
		private ComUIListScript taskAwardItemList;

		// Token: 0x0400AAD1 RID: 43729
		[Space(15f)]
		[Header("TotalAward")]
		[Space(15f)]
		[SerializeField]
		private Text alreadySignInWeek;

		// Token: 0x0400AAD2 RID: 43730
		[SerializeField]
		private Text currentSignInWeek;

		// Token: 0x0400AAD3 RID: 43731
		[SerializeField]
		private ComUIListScript totalAwardItemList;

		// Token: 0x0400AAD4 RID: 43732
		[SerializeField]
		private CommonTimeRefreshControl commonTimeRefreshControl;
	}
}
