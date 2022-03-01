using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001843 RID: 6211
	public sealed class GoblinShopActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3FF RID: 62463 RVA: 0x0041E8F1 File Offset: 0x0041CCF1
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/GoblinShopActivity";
		}

		// Token: 0x0600F400 RID: 62464 RVA: 0x0041E8F8 File Offset: 0x0041CCF8
		public override void Show(Transform root)
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
					GoblinShopActivityView goblinShopActivityView = this.mView as GoblinShopActivityView;
					if (goblinShopActivityView != null)
					{
						goblinShopActivityView.SetCallBack(new GoblinShopActivityView.BuyCallBack(this.GoToGoblinShop));
					}
				}
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F401 RID: 62465 RVA: 0x0041EA2C File Offset: 0x0041CE2C
		private void GoToGoblinShop()
		{
			GoblinShopData goblinShopData = new GoblinShopData();
			goblinShopData.activityId = (int)this.mDataModel.Id;
			goblinShopData.accountShopItem.shopId = (uint)((byte)this.mDataModel.ParamArray[0]);
			goblinShopData.accountShopItem.jobType = 0;
			goblinShopData.accountShopItem.tabType = 0;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GoblinShopFrame>(FrameLayer.Middle, goblinShopData, string.Empty);
		}
	}
}
