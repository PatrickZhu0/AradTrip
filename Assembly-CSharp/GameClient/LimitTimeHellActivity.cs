using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001853 RID: 6227
	public sealed class LimitTimeHellActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F474 RID: 62580 RVA: 0x0041FF19 File Offset: 0x0041E319
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/LimitTimeHellActivity";
		}

		// Token: 0x0600F475 RID: 62581 RVA: 0x0041FF20 File Offset: 0x0041E320
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/LimitTimeHellItem";
		}

		// Token: 0x0600F476 RID: 62582 RVA: 0x0041FF28 File Offset: 0x0041E328
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
					LimitTimeHellActivityView limitTimeHellActivityView = this.mView as LimitTimeHellActivityView;
					if (limitTimeHellActivityView != null)
					{
						limitTimeHellActivityView.SetCallBack(new LimitTimeHellActivityView.CallBack(this.GoToHellFrame));
					}
				}
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F477 RID: 62583 RVA: 0x0042005C File Offset: 0x0041E45C
		private void GoToHellFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FallAbyssFrame>(FrameLayer.Middle, null, string.Empty);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
		}
	}
}
