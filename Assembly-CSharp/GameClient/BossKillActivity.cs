using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001826 RID: 6182
	public sealed class BossKillActivity : IActivity, IDisposable
	{
		// Token: 0x0600F372 RID: 62322 RVA: 0x0041CC60 File Offset: 0x0041B060
		public void Init(uint activityId)
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(activityId);
			WorldActivityMonsterRes bossKillMonsterData = DataManager<ActivityDataManager>.GetInstance().GetBossKillMonsterData(activityId);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossKillModel(bossKillMonsterData, bossActivityData);
			}
		}

		// Token: 0x0600F373 RID: 62323 RVA: 0x0041CC98 File Offset: 0x0041B098
		public void Show(Transform root)
		{
			if (this.mDataModel.Id == 0U)
			{
				return;
			}
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
				this.mView = this.mGameObject.GetComponent<BossKillActivityView>();
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick), new UnityAction(this._OnGoShop));
					this.mIsInit = true;
				}
			}
			DataManager<ActivityDataManager>.GetInstance().RequestBossKillData((int)this.mDataModel.Id);
		}

		// Token: 0x0600F374 RID: 62324 RVA: 0x0041CDAC File Offset: 0x0041B1AC
		public void Hide()
		{
			if (this.mGameObject != null)
			{
				this.mGameObject.CustomActive(false);
			}
		}

		// Token: 0x0600F375 RID: 62325 RVA: 0x0041CDCB File Offset: 0x0041B1CB
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

		// Token: 0x0600F376 RID: 62326 RVA: 0x0041CE00 File Offset: 0x0041B200
		public void UpdateData()
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(this.mDataModel.Id);
			WorldActivityMonsterRes bossKillMonsterData = DataManager<ActivityDataManager>.GetInstance().GetBossKillMonsterData(this.mDataModel.Id);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossKillModel(bossKillMonsterData, bossActivityData);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
		}

		// Token: 0x0600F377 RID: 62327 RVA: 0x0041CE6E File Offset: 0x0041B26E
		public void UpdateTask(int taskId)
		{
		}

		// Token: 0x0600F378 RID: 62328 RVA: 0x0041CE70 File Offset: 0x0041B270
		public bool IsHaveRedPoint()
		{
			return false;
		}

		// Token: 0x0600F379 RID: 62329 RVA: 0x0041CE73 File Offset: 0x0041B273
		public uint GetId()
		{
			return this.mDataModel.Id;
		}

		// Token: 0x0600F37A RID: 62330 RVA: 0x0041CE80 File Offset: 0x0041B280
		public string GetName()
		{
			return this.mDataModel.Name;
		}

		// Token: 0x0600F37B RID: 62331 RVA: 0x0041CE8D File Offset: 0x0041B28D
		public OpActivityState GetState()
		{
			return this.mDataModel.State;
		}

		// Token: 0x0600F37C RID: 62332 RVA: 0x0041CE9A File Offset: 0x0041B29A
		public void Dispose()
		{
			this.mGameObject = null;
			this.mIsInit = false;
			if (this.mView != null)
			{
				this.mView.Dispose();
			}
			this.mView = null;
		}

		// Token: 0x0600F37D RID: 62333 RVA: 0x0041CECD File Offset: 0x0041B2CD
		private void _OnItemClick(int id, int param, ulong param2)
		{
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BossSelectBattleFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<BossSelectBattleFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F37E RID: 62334 RVA: 0x0041CEF1 File Offset: 0x0041B2F1
		private void _OnGoShop()
		{
			Singleton<ClientSystemManager>.instance.CloseFrameByType(typeof(LimitTimeActivityFrame), false);
			Singleton<ClientSystemManager>.instance.OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
		}

		// Token: 0x0600F37F RID: 62335 RVA: 0x0041CF1F File Offset: 0x0041B31F
		private string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/BossKillActivity";
		}

		// Token: 0x040095DA RID: 38362
		private GameObject mGameObject;

		// Token: 0x040095DB RID: 38363
		private bool mIsInit;

		// Token: 0x040095DC RID: 38364
		private BossKillActivityView mView;

		// Token: 0x040095DD RID: 38365
		private BossKillModel mDataModel;
	}
}
