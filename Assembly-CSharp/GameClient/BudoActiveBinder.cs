using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000014 RID: 20
	internal class BudoActiveBinder : MonoBehaviour
	{
		// Token: 0x0600006D RID: 109 RVA: 0x00006FDF File Offset: 0x000053DF
		public void OnClick()
		{
			DataManager<BudoManager>.GetInstance().TryBeginActive();
		}

		// Token: 0x0600006E RID: 110 RVA: 0x00006FEB File Offset: 0x000053EB
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._UpdateStatus();
		}

		// Token: 0x0600006F RID: 111 RVA: 0x00006FF4 File Offset: 0x000053F4
		private void Start()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			this._UpdateStatus();
		}

		// Token: 0x06000070 RID: 112 RVA: 0x00007070 File Offset: 0x00005470
		private void _OnActivityUpdated(UIEvent a_event)
		{
			uint iID = (uint)a_event.Param1;
			if (DataManager<ActiveManager>.GetInstance().IsBudoActive((int)iID))
			{
				this._UpdateStatus();
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x000070A0 File Offset: 0x000054A0
		private void _UpdateStatus()
		{
			if (this.comTimer != null)
			{
				this.comTimer.CustomActive(false);
				if (this.bReadyShow && DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
				{
					ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
					if (activityInfo != null && activityInfo.state == 2)
					{
						this.comTimer.Initialize();
						this.comTimer.CustomActive(true);
						uint time = (DataManager<TimeManager>.GetInstance().GetServerTime() > activityInfo.startTime) ? 0U : (activityInfo.startTime - DataManager<TimeManager>.GetInstance().GetServerTime());
						this.comTimer.Time = time;
					}
				}
			}
			if (this.goGo != null)
			{
				this.goGo.CustomActive(false);
			}
			bool flag = this.bAlwasyShow;
			bool bActive = false;
			if (DataManager<BudoManager>.GetInstance().CanAcqured && !this.bReadyShow)
			{
				flag = true;
				bActive = true;
			}
			else if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
			{
				ActivityInfo activityInfo2 = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
				if (activityInfo2 != null && (activityInfo2.state == 1 || (activityInfo2.state == 2 && this.bReadyShow)))
				{
					flag = true;
					if (this.goGo != null)
					{
						this.goGo.CustomActive(activityInfo2.state == 2);
					}
				}
			}
			if (this.RedPoints != null)
			{
				for (int i = 0; i < this.RedPoints.Length; i++)
				{
					this.RedPoints[i].CustomActive(bActive);
				}
			}
			if (!DataManager<BudoManager>.GetInstance().IsLevelFit)
			{
				flag = false;
			}
			if (this.ShowTargets != null)
			{
				for (int j = 0; j < this.ShowTargets.Length; j++)
				{
					this.ShowTargets[j].CustomActive(flag);
				}
			}
			if (this.bNeedNotify)
			{
				if (flag)
				{
					DataManager<ActivityNoticeDataManager>.GetInstance().AddActivityNotice(this.noticeData);
					DataManager<DeadLineReminderDataManager>.GetInstance().AddActivityNotice(this.noticeData);
				}
				else
				{
					DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(this.noticeData);
					DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(this.noticeData);
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x00007306 File Offset: 0x00005706
		private void OnBudoInfoChanged()
		{
			this._UpdateStatus();
		}

		// Token: 0x06000073 RID: 115 RVA: 0x00007310 File Offset: 0x00005710
		private void OnDestroy()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			this.RedPoints = null;
			this.ShowTargets = null;
		}

		// Token: 0x0400004D RID: 77
		public GameObject[] RedPoints;

		// Token: 0x0400004E RID: 78
		public GameObject[] ShowTargets;

		// Token: 0x0400004F RID: 79
		public bool bAlwasyShow;

		// Token: 0x04000050 RID: 80
		public bool bReadyShow;

		// Token: 0x04000051 RID: 81
		public TimeRefresh comTimer;

		// Token: 0x04000052 RID: 82
		public GameObject goGo;

		// Token: 0x04000053 RID: 83
		public bool bNeedNotify;

		// Token: 0x04000054 RID: 84
		private NotifyInfo noticeData = new NotifyInfo
		{
			type = 2U
		};
	}
}
