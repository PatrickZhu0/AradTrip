using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001825 RID: 6181
	public sealed class BossExchangeActivity : IActivity, IDisposable
	{
		// Token: 0x0600F362 RID: 62306 RVA: 0x0041C898 File Offset: 0x0041AC98
		public void Init(uint activityId)
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(activityId);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossExchangeModel(bossActivityData);
				this.mCheckComponent.InitData(this);
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F363 RID: 62307 RVA: 0x0041C8EC File Offset: 0x0041ACEC
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
				this.mView = this.mGameObject.GetComponent<BossExchangeActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick), new UnityAction(this._OnGoShop));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F364 RID: 62308 RVA: 0x0041C9F7 File Offset: 0x0041ADF7
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F365 RID: 62309 RVA: 0x0041CA16 File Offset: 0x0041AE16
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

		// Token: 0x0600F366 RID: 62310 RVA: 0x0041CA4C File Offset: 0x0041AE4C
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

		// Token: 0x0600F367 RID: 62311 RVA: 0x0041CAA3 File Offset: 0x0041AEA3
		public void UpdateTask(int taskId)
		{
			this.mDataModel.UpdateTask(taskId);
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x0600F368 RID: 62312 RVA: 0x0041CAD4 File Offset: 0x0041AED4
		public bool IsHaveRedPoint()
		{
			bool flag = false;
			foreach (BossExchangeTaskModel bossExchangeTaskModel in this.mDataModel.ExchangeTasks.Values)
			{
				if (bossExchangeTaskModel.Status == TaskStatus.TASK_FINISHED)
				{
					flag = true;
				}
			}
			return flag && !this.mCheckComponent.IsChecked();
		}

		// Token: 0x0600F369 RID: 62313 RVA: 0x0041CB5C File Offset: 0x0041AF5C
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F36A RID: 62314 RVA: 0x0041CB69 File Offset: 0x0041AF69
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F36B RID: 62315 RVA: 0x0041CB76 File Offset: 0x0041AF76
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F36C RID: 62316 RVA: 0x0041CB84 File Offset: 0x0041AF84
		public void Dispose()
		{
			this.mGameObject = null;
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F36D RID: 62317 RVA: 0x0041CBDD File Offset: 0x0041AFDD
		private void _OnItemClick(int taskId, int param, ulong param2)
		{
			DataManager<ActivityDataManager>.GetInstance().SendSubmitBossExchangeTask(taskId);
		}

		// Token: 0x0600F36E RID: 62318 RVA: 0x0041CBEC File Offset: 0x0041AFEC
		private void _OnGoShop()
		{
			Singleton<ClientSystemManager>.instance.CloseFrameByType(typeof(LimitTimeActivityFrame), false);
			Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.LimitTimeMall
			}, string.Empty);
		}

		// Token: 0x0600F36F RID: 62319 RVA: 0x0041CC2D File Offset: 0x0041B02D
		private string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/BossExchangeActivity";
		}

		// Token: 0x0600F370 RID: 62320 RVA: 0x0041CC34 File Offset: 0x0041B034
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mView != null)
			{
				this.mView.UpdateData(this.mDataModel);
			}
		}

		// Token: 0x040095D5 RID: 38357
		private GameObject mGameObject;

		// Token: 0x040095D6 RID: 38358
		private bool mIsInit;

		// Token: 0x040095D7 RID: 38359
		private BossExchangeActivityView mView;

		// Token: 0x040095D8 RID: 38360
		private BossExchangeModel mDataModel;

		// Token: 0x040095D9 RID: 38361
		private readonly LimitTimeActivityCheckComponent mCheckComponent = new LimitTimeActivityCheckComponent();
	}
}
