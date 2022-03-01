using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020018D4 RID: 6356
	public abstract class ActivityItemBase : MonoBehaviour, IActivityCommonItem, IDisposable
	{
		// Token: 0x0600F829 RID: 63529 RVA: 0x004153DD File Offset: 0x004137DD
		public virtual void Init(uint id, uint activityId, ILimitTimeActivityTaskDataModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (data == null)
			{
				Logger.LogError("data is empty");
				return;
			}
			this.mActivityId = activityId;
			this.mId = id;
			this.mOnItemClick = onItemClick;
			this.OnInit(data);
			this.UpdateData(data);
		}

		// Token: 0x0600F82A RID: 63530 RVA: 0x00415414 File Offset: 0x00413814
		public virtual void InitFromMode(ILimitTimeActivityModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
		}

		// Token: 0x0600F82B RID: 63531
		public abstract void UpdateData(ILimitTimeActivityTaskDataModel data);

		// Token: 0x0600F82C RID: 63532 RVA: 0x00415416 File Offset: 0x00413816
		public virtual void Dispose()
		{
			this.mOnItemClick = null;
		}

		// Token: 0x0600F82D RID: 63533 RVA: 0x0041541F File Offset: 0x0041381F
		public virtual void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F82E RID: 63534 RVA: 0x00415432 File Offset: 0x00413832
		protected virtual void _OnItemClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick((int)this.mId, 0, 0UL);
			}
		}

		// Token: 0x0600F82F RID: 63535 RVA: 0x00415453 File Offset: 0x00413853
		protected virtual void RegisterAccountData(ClientEventSystem.UIEventHandler eventHandler)
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, eventHandler);
		}

		// Token: 0x0600F830 RID: 63536 RVA: 0x00415465 File Offset: 0x00413865
		protected virtual void UnRegisterAccountData(ClientEventSystem.UIEventHandler eventHandler)
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, eventHandler);
		}

		// Token: 0x0600F831 RID: 63537 RVA: 0x00415478 File Offset: 0x00413878
		protected virtual void OnRequsetAccountData(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			if (data.AccountDailySubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
			}
			if (data.AccountTotalSubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
			}
			if (data.AccountWeeklySubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK);
			}
		}

		// Token: 0x0600F832 RID: 63538
		protected abstract void OnInit(ILimitTimeActivityTaskDataModel data);

		// Token: 0x04009951 RID: 39249
		protected uint mId;

		// Token: 0x04009952 RID: 39250
		protected ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009953 RID: 39251
		protected uint mActivityId;

		// Token: 0x020018D5 RID: 6357
		// (Invoke) Token: 0x0600F834 RID: 63540
		public delegate void OnActivityItemClick<T>(int id, T t1, ulong t2 = 0UL);
	}
}
