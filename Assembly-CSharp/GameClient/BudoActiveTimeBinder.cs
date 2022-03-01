using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000017 RID: 23
	internal class BudoActiveTimeBinder : MonoBehaviour
	{
		// Token: 0x06000076 RID: 118 RVA: 0x000073B0 File Offset: 0x000057B0
		private void _UpdateActive()
		{
			this.m_eBudoActiveStatus = BudoActiveStatus.BAS_CLOSE;
			if (DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey(BudoManager.ActiveID))
			{
				ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[BudoManager.ActiveID];
				if (activityInfo != null)
				{
					if (activityInfo.state == 1)
					{
						this.m_eBudoActiveStatus = BudoActiveStatus.BAS_PLAYING;
					}
					else if (activityInfo.state == 2)
					{
						this.m_eBudoActiveStatus = BudoActiveStatus.BAS_READY;
					}
					else
					{
						this.m_eBudoActiveStatus = BudoActiveStatus.BAS_CLOSE;
					}
					this._SetTimer(activityInfo);
				}
			}
			base.gameObject.CustomActive(this.m_eBudoActiveStatus == BudoActiveStatus.BAS_PLAYING);
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0000744C File Offset: 0x0000584C
		private void _SetTimer(ActivityInfo activity)
		{
			if (activity == null)
			{
				return;
			}
			if (this.m_eBudoActiveStatus != BudoActiveStatus.BAS_PLAYING)
			{
				return;
			}
			uint num;
			if (this.m_eBudoActiveStatus == BudoActiveStatus.BAS_PLAYING)
			{
				num = ((DataManager<TimeManager>.GetInstance().GetServerTime() > activity.dueTime) ? 0U : (activity.dueTime - DataManager<TimeManager>.GetInstance().GetServerTime()));
			}
			else
			{
				num = ((DataManager<TimeManager>.GetInstance().GetServerTime() > activity.startTime) ? 0U : (activity.startTime - DataManager<TimeManager>.GetInstance().GetServerTime()));
			}
			StatusConfig statusConfig = null;
			for (int i = 0; i < this.akConfigs.Length; i++)
			{
				if (this.akConfigs[i].eBudoActiveStatus == this.m_eBudoActiveStatus)
				{
					statusConfig = this.akConfigs[i];
					break;
				}
			}
			if (statusConfig == null || string.IsNullOrEmpty(statusConfig.fmtString))
			{
				return;
			}
			if (this.timer != null)
			{
				uint num2 = num / 3600U % 24U;
				uint num3 = num / 60U % 60U;
				uint num4 = num % 60U;
				this.timer.text = string.Format(statusConfig.fmtString, string.Format("{0:D2}:{1:D2}:{2:D2}", num2, num3, num4));
			}
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00007591 File Offset: 0x00005991
		private void OnBudoInfoChanged()
		{
			this._UpdateActive();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x0000759C File Offset: 0x0000599C
		private void Start()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Combine(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			base.CancelInvoke("_UpdateActive");
			base.InvokeRepeating("_UpdateActive", 0f, 1f);
		}

		// Token: 0x0600007A RID: 122 RVA: 0x0000760C File Offset: 0x00005A0C
		private void _OnActivityUpdated(UIEvent a_event)
		{
			uint num = (uint)a_event.Param1;
			if ((ulong)num == (ulong)((long)BudoManager.ActiveID))
			{
				this._UpdateActive();
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00007638 File Offset: 0x00005A38
		private void OnDestroy()
		{
			BudoManager instance = DataManager<BudoManager>.GetInstance();
			instance.onBudoInfoChanged = (BudoManager.OnBudoInfoChanged)Delegate.Remove(instance.onBudoInfoChanged, new BudoManager.OnBudoInfoChanged(this.OnBudoInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityUpdated));
			base.CancelInvoke("_UpdateActive");
		}

		// Token: 0x0400005C RID: 92
		public StatusConfig[] akConfigs = new StatusConfig[0];

		// Token: 0x0400005D RID: 93
		public Text timer;

		// Token: 0x0400005E RID: 94
		private BudoActiveStatus m_eBudoActiveStatus;
	}
}
