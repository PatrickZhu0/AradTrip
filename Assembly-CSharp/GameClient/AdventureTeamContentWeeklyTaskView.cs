using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001426 RID: 5158
	public class AdventureTeamContentWeeklyTaskView : AdventureTeamContentBaseView
	{
		// Token: 0x0600C818 RID: 51224 RVA: 0x003083A9 File Offset: 0x003067A9
		private void Awake()
		{
			this._InitTR();
			this.BindEvents();
			this._bindEvents();
		}

		// Token: 0x0600C819 RID: 51225 RVA: 0x003083BD File Offset: 0x003067BD
		private void OnDestroy()
		{
			this._ClearTR();
			this.UnBindEvents();
			this._unBindEvents();
			this.UnInitialize();
		}

		// Token: 0x0600C81A RID: 51226 RVA: 0x003083D7 File Offset: 0x003067D7
		private void BindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamWeeklyTaskChange, new ClientEventSystem.UIEventHandler(this._LoadAdventureTeamWeeklyMission));
		}

		// Token: 0x0600C81B RID: 51227 RVA: 0x003083F4 File Offset: 0x003067F4
		private void UnBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamWeeklyTaskChange, new ClientEventSystem.UIEventHandler(this._LoadAdventureTeamWeeklyMission));
		}

		// Token: 0x0600C81C RID: 51228 RVA: 0x00308411 File Offset: 0x00306811
		private void _InitTR()
		{
			this.tr_weekly_task_refresh_tip = TR.Value("adventure_team_weekly_task_refresh_tip");
			this.tr_weekly_task_progress_tip = TR.Value("adventure_team_weekly_task_progress_tip");
			this.tr_weekly_task_progress_max_tip = TR.Value("adventure_team_weekly_task_progress_max");
		}

		// Token: 0x0600C81D RID: 51229 RVA: 0x00308443 File Offset: 0x00306843
		private void _ClearTR()
		{
			this.tr_weekly_task_refresh_tip = null;
			this.tr_weekly_task_progress_tip = null;
			this.tr_weekly_task_progress_max_tip = null;
		}

		// Token: 0x0600C81E RID: 51230 RVA: 0x0030845A File Offset: 0x0030685A
		private void _bindEvents()
		{
		}

		// Token: 0x0600C81F RID: 51231 RVA: 0x0030845C File Offset: 0x0030685C
		private void _unBindEvents()
		{
		}

		// Token: 0x0600C820 RID: 51232 RVA: 0x0030845E File Offset: 0x0030685E
		public override void InitData()
		{
			this.Initialize();
			if (this.mRefreshTip != null)
			{
				this.mRefreshTip.text = this.tr_weekly_task_refresh_tip;
			}
			DataManager<AdventureTeamDataManager>.GetInstance().OnFirstCheckWeeklyTaskFlag = false;
		}

		// Token: 0x0600C821 RID: 51233 RVA: 0x00308493 File Offset: 0x00306893
		public override void OnEnableView()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().OnFirstCheckWeeklyTaskFlag = false;
		}

		// Token: 0x0600C822 RID: 51234 RVA: 0x003084A0 File Offset: 0x003068A0
		private void Initialize()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen("AdventureTeamInformationFrame"))
			{
				this.clientFrame = (Singleton<ClientSystemManager>.GetInstance().GetFrame("AdventureTeamInformationFrame") as AdventureTeamInformationFrame);
			}
			if (this.mTaskItemUIListScript != null)
			{
				this.mTaskItemUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mTaskItemUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTaskItemUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			}
			this._LoadAdventureTeamWeeklyMission(null);
		}

		// Token: 0x0600C823 RID: 51235 RVA: 0x0030854C File Offset: 0x0030694C
		public void UnInitialize()
		{
			if (this.mTaskItemUIListScript != null)
			{
				this.mTaskItemUIListScript.SetElementAmount(0);
				ComUIListScript comUIListScript = this.mTaskItemUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTaskItemUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				this.mTaskItemUIListScript = null;
			}
			this.clientFrame = null;
		}

		// Token: 0x0600C824 RID: 51236 RVA: 0x003085D4 File Offset: 0x003069D4
		private void _LoadAdventureTeamWeeklyMission(UIEvent uiEvent)
		{
			this.missionList = DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionList;
			if (this.missionList != null && this.mTaskItemUIListScript != null)
			{
				this.missionList.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._Sort));
				this.mTaskItemUIListScript.SetElementAmount(this.missionList.Count);
			}
			this._UpdateWeeklyMissionProgress();
		}

		// Token: 0x0600C825 RID: 51237 RVA: 0x00308640 File Offset: 0x00306A40
		private void _UpdateWeeklyMissionProgress()
		{
			int num = DataManager<AdventureTeamDataManager>.GetInstance()._GetFinishedWeeklyTaskNum();
			int adtmissionFinishMaxNum = DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionFinishMaxNum;
			int num2 = adtmissionFinishMaxNum - num;
			bool flag = num2 <= 0;
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (this.mProgressTip)
			{
				if (flag)
				{
					this.mProgressTip.text = string.Format(this.tr_weekly_task_progress_max_tip, num2, adtmissionFinishMaxNum);
				}
				else
				{
					this.mProgressTip.text = string.Format(this.tr_weekly_task_progress_tip, num2, adtmissionFinishMaxNum);
				}
			}
		}

		// Token: 0x0600C826 RID: 51238 RVA: 0x003086D8 File Offset: 0x00306AD8
		private int _Sort(MissionManager.SingleMissionInfo left, MissionManager.SingleMissionInfo right)
		{
			if (left.status != right.status)
			{
				if (left.status == 5)
				{
					return 1;
				}
				if (right.status == 5)
				{
					return -1;
				}
				return (int)(right.status - left.status);
			}
			else
			{
				int num;
				if (int.TryParse(left.missionItem.MissionParam, out num))
				{
				}
				int num2;
				if (int.TryParse(right.missionItem.MissionParam, out num2))
				{
				}
				if (num != num2)
				{
					return num2 - num;
				}
				if (left.missionItem.SortID != right.missionItem.SortID)
				{
					return left.missionItem.SortID - right.missionItem.SortID;
				}
				if (left.taskID != right.taskID)
				{
					return (left.taskID >= right.taskID) ? 1 : -1;
				}
				return 0;
			}
		}

		// Token: 0x0600C827 RID: 51239 RVA: 0x003087B7 File Offset: 0x00306BB7
		private AdventureTeamWeeklyTaskItem _OnBindItemDelegate(GameObject itemObject)
		{
			if (itemObject == null)
			{
				return null;
			}
			return itemObject.GetComponent<AdventureTeamWeeklyTaskItem>();
		}

		// Token: 0x0600C828 RID: 51240 RVA: 0x003087D0 File Offset: 0x00306BD0
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.missionList.Count)
			{
				AdventureTeamWeeklyTaskItem adventureTeamWeeklyTaskItem = item.gameObjectBindScript as AdventureTeamWeeklyTaskItem;
				if (adventureTeamWeeklyTaskItem != null)
				{
					adventureTeamWeeklyTaskItem.Init(this.missionList[item.m_index], this.clientFrame);
				}
			}
		}

		// Token: 0x0600C829 RID: 51241 RVA: 0x00308840 File Offset: 0x00306C40
		public static int _GetFinishedWeeklyTaskNum()
		{
			int num = 0;
			List<MissionManager.SingleMissionInfo> adtmissionList = DataManager<AdventureTeamDataManager>.GetInstance().ADTMissionList;
			if (adtmissionList != null)
			{
				for (int i = 0; i < adtmissionList.Count; i++)
				{
					if (adtmissionList[i].status == 5)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x04007338 RID: 29496
		[SerializeField]
		private Text mRefreshTip;

		// Token: 0x04007339 RID: 29497
		[SerializeField]
		private Text mProgressTip;

		// Token: 0x0400733A RID: 29498
		[SerializeField]
		private ComUIListScript mTaskItemUIListScript;

		// Token: 0x0400733B RID: 29499
		private string tr_weekly_task_refresh_tip = string.Empty;

		// Token: 0x0400733C RID: 29500
		private string tr_weekly_task_progress_tip = string.Empty;

		// Token: 0x0400733D RID: 29501
		private string tr_weekly_task_progress_max_tip = string.Empty;

		// Token: 0x0400733E RID: 29502
		private List<MissionManager.SingleMissionInfo> missionList;

		// Token: 0x0400733F RID: 29503
		private ClientFrame clientFrame;
	}
}
