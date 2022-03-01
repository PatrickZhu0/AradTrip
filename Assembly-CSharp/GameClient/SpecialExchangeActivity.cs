using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001865 RID: 6245
	public class SpecialExchangeActivity : IActivity, IDisposable
	{
		// Token: 0x0600F4D6 RID: 62678 RVA: 0x00421130 File Offset: 0x0041F530
		public void Init(uint activityId)
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(activityId);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossExchangeModel(bossActivityData);
				this.mCheckComponent.InitData(this);
			}
		}

		// Token: 0x0600F4D7 RID: 62679 RVA: 0x00421168 File Offset: 0x0041F568
		public void Show(Transform root)
		{
			if (this.mDataModel.Id == 0U)
			{
				return;
			}
			this.mCheckComponent.Checked(this);
			if (this.mIsInit)
			{
				this.mGameObject.CustomActive(true);
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
				this.mView = this.mGameObject.GetComponent<SpecialExchangeActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F4D8 RID: 62680 RVA: 0x00421267 File Offset: 0x0041F667
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F4D9 RID: 62681 RVA: 0x00421286 File Offset: 0x0041F686
		public void Close()
		{
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Close();
			}
			this.mView = null;
			this.mGameObject = null;
			this.mCheckComponent.Dispose();
		}

		// Token: 0x0600F4DA RID: 62682 RVA: 0x004212C4 File Offset: 0x0041F6C4
		public void UpdateData()
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(this.mDataModel.Id);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossExchangeModel(bossActivityData);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
		}

		// Token: 0x0600F4DB RID: 62683 RVA: 0x0042131B File Offset: 0x0041F71B
		public void UpdateTask(int taskId)
		{
			this.mDataModel.UpdateTask(taskId);
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F4DC RID: 62684 RVA: 0x0042134C File Offset: 0x0041F74C
		public bool IsHaveRedPoint()
		{
			bool result = false;
			foreach (BossExchangeTaskModel bossExchangeTaskModel in this.mDataModel.ExchangeTasks.Values)
			{
				if (bossExchangeTaskModel.Status == TaskStatus.TASK_FINISHED)
				{
					result = true;
					break;
				}
			}
			return result;
		}

		// Token: 0x0600F4DD RID: 62685 RVA: 0x004213C4 File Offset: 0x0041F7C4
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F4DE RID: 62686 RVA: 0x004213D1 File Offset: 0x0041F7D1
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F4DF RID: 62687 RVA: 0x004213DE File Offset: 0x0041F7DE
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F4E0 RID: 62688 RVA: 0x004213EB File Offset: 0x0041F7EB
		public void Dispose()
		{
		}

		// Token: 0x0600F4E1 RID: 62689 RVA: 0x004213ED File Offset: 0x0041F7ED
		private void _OnItemClick(int taskId, int param, ulong param2)
		{
			DataManager<ActivityDataManager>.GetInstance().SendSubmitBossExchangeTask(taskId);
		}

		// Token: 0x0600F4E2 RID: 62690 RVA: 0x004213FA File Offset: 0x0041F7FA
		private string _GetPrefabPath()
		{
			return this.mDataModel.PrefabPath;
		}

		// Token: 0x04009635 RID: 38453
		private GameObject mGameObject;

		// Token: 0x04009636 RID: 38454
		private bool mIsInit;

		// Token: 0x04009637 RID: 38455
		private SpecialExchangeActivityView mView;

		// Token: 0x04009638 RID: 38456
		private BossExchangeModel mDataModel;

		// Token: 0x04009639 RID: 38457
		private readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();
	}
}
