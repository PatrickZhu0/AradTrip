using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200184F RID: 6223
	public class LimitTimeCommonActivity : IActivity, IDisposable
	{
		// Token: 0x0600F43E RID: 62526 RVA: 0x00416DB0 File Offset: 0x004151B0
		public virtual void Init(uint activityId)
		{
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(activityId);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F43F RID: 62527 RVA: 0x00416DF0 File Offset: 0x004151F0
		public virtual void Show(Transform root)
		{
			if (this.mDataModel == null)
			{
				return;
			}
			if (this.mIsInit)
			{
				this.mGameObject.CustomActive(true);
				if (this.mView != null)
				{
					this.mView.Show();
				}
			}
			else
			{
				if (this.mGameObject == null)
				{
					this.mGameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this._GetPrefabPath(), true, 0U);
				}
				if (!(this.mGameObject != null))
				{
					Logger.LogError("加载活动预制体失败，路径:" + this._GetPrefabPath());
					return;
				}
				this.mGameObject.transform.SetParent(root, false);
				this.mGameObject.CustomActive(true);
				this.mView = this.mGameObject.GetComponent<IActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F440 RID: 62528 RVA: 0x00416EEF File Offset: 0x004152EF
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
			if (this.mView != null)
			{
				this.mView.Hide();
			}
		}

		// Token: 0x0600F441 RID: 62529 RVA: 0x00416F24 File Offset: 0x00415324
		public void Close()
		{
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Close();
			}
			this.mView = null;
			this.mGameObject = null;
		}

		// Token: 0x0600F442 RID: 62530 RVA: 0x00416F54 File Offset: 0x00415354
		public virtual void UpdateData()
		{
			if (this.mDataModel == null)
			{
				return;
			}
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData(this.mDataModel.Id);
			if (limitTimeActivityData != null)
			{
				this.mDataModel = new LimitTimeActivityModel(limitTimeActivityData, this._GetItemPrefabPath(), null, null, null);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
		}

		// Token: 0x0600F443 RID: 62531 RVA: 0x00416FBA File Offset: 0x004153BA
		public void UpdateTask(int taskId)
		{
			this.mDataModel.UpdateTask(taskId);
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F444 RID: 62532 RVA: 0x00416FE4 File Offset: 0x004153E4
		public virtual bool IsHaveRedPoint()
		{
			if (this.mDataModel.TaskDatas == null || this.mDataModel.State != OpActivityState.OAS_IN)
			{
				return false;
			}
			for (int i = 0; i < this.mDataModel.TaskDatas.Count; i++)
			{
				if (this.mDataModel.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
				{
					ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = this.mDataModel.TaskDatas[i];
					int accountTotalSubmitLimit = this.mDataModel.TaskDatas[i].AccountTotalSubmitLimit;
					int accountDailySubmitLimit = this.mDataModel.TaskDatas[i].AccountDailySubmitLimit;
					int accountWeeklySubmitLimit = this.mDataModel.TaskDatas[i].AccountWeeklySubmitLimit;
					if (accountTotalSubmitLimit > 0)
					{
						if ((ulong)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(limitTimeActivityTaskDataModel.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK) < (ulong)((long)limitTimeActivityTaskDataModel.AccountTotalSubmitLimit))
						{
							return true;
						}
					}
					else if (accountDailySubmitLimit > 0)
					{
						if ((ulong)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(limitTimeActivityTaskDataModel.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK) < (ulong)((long)limitTimeActivityTaskDataModel.AccountDailySubmitLimit))
						{
							return true;
						}
					}
					else
					{
						if (accountWeeklySubmitLimit <= 0)
						{
							return true;
						}
						if ((ulong)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(limitTimeActivityTaskDataModel.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK) < (ulong)((long)limitTimeActivityTaskDataModel.AccountWeeklySubmitLimit))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600F445 RID: 62533 RVA: 0x0041713D File Offset: 0x0041553D
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F446 RID: 62534 RVA: 0x0041714A File Offset: 0x0041554A
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F447 RID: 62535 RVA: 0x00417157 File Offset: 0x00415557
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F448 RID: 62536 RVA: 0x00417164 File Offset: 0x00415564
		public virtual void Dispose()
		{
			this.mGameObject = null;
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
			if (this.mCheckComponent != null)
			{
				this.mCheckComponent.Dispose();
			}
		}

		// Token: 0x0600F449 RID: 62537 RVA: 0x004171B2 File Offset: 0x004155B2
		protected virtual void _OnItemClick(int taskId, int param, ulong param2)
		{
			DataManager<ActivityDataManager>.GetInstance().RequestOnTakeActTask(this.mDataModel.Id, (uint)taskId, 0UL);
		}

		// Token: 0x0600F44A RID: 62538 RVA: 0x004171CC File Offset: 0x004155CC
		protected virtual string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/DailyLoginItem";
		}

		// Token: 0x0600F44B RID: 62539 RVA: 0x004171D3 File Offset: 0x004155D3
		protected virtual string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/CommonActivity";
		}

		// Token: 0x0400960C RID: 38412
		protected GameObject mGameObject;

		// Token: 0x0400960D RID: 38413
		protected bool mIsInit;

		// Token: 0x0400960E RID: 38414
		protected IActivityView mView;

		// Token: 0x0400960F RID: 38415
		protected ILimitTimeActivityModel mDataModel;

		// Token: 0x04009610 RID: 38416
		protected LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();
	}
}
