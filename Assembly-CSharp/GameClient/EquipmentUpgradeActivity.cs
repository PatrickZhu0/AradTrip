using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200183A RID: 6202
	public sealed class EquipmentUpgradeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3D5 RID: 62421 RVA: 0x0041DBED File Offset: 0x0041BFED
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/EquipmentUpgradeActivity";
		}

		// Token: 0x0600F3D6 RID: 62422 RVA: 0x0041DBF4 File Offset: 0x0041BFF4
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
					EquipmentUpgradeActivityView equipmentUpgradeActivityView = this.mView as EquipmentUpgradeActivityView;
					if (equipmentUpgradeActivityView != null)
					{
						equipmentUpgradeActivityView.SetCallBack(new EquipmentUpgradeActivityView.BuyCallBack(this.GoToGoblinShop));
					}
				}
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F3D7 RID: 62423 RVA: 0x0041DD28 File Offset: 0x0041C128
		private void GoToGoblinShop()
		{
			SmithShopNewLinkData smithShopNewLinkData = new SmithShopNewLinkData();
			smithShopNewLinkData.itemData = null;
			smithShopNewLinkData.iDefaultFirstTabId = 0;
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, true);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, smithShopNewLinkData, string.Empty);
		}
	}
}
