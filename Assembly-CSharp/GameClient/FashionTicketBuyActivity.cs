using System;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200183D RID: 6205
	public sealed class FashionTicketBuyActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3DD RID: 62429 RVA: 0x0041DD8D File Offset: 0x0041C18D
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/FashionTicketBuyActivity";
		}

		// Token: 0x0600F3DE RID: 62430 RVA: 0x0041DD94 File Offset: 0x0041C194
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
					FashionTicketBuyActivityView fashionTicketBuyActivityView = this.mView as FashionTicketBuyActivityView;
					if (fashionTicketBuyActivityView != null)
					{
						fashionTicketBuyActivityView.SetBuyCallBack(new FashionTicketBuyActivityView.BuyCallBack(this.BuyFashion));
					}
				}
				if (this.mView != null)
				{
					this.mView.Init(this.mDataModel, new ActivityItemBase.OnActivityItemClick<int>(this._OnItemClick));
					this.mIsInit = true;
				}
			}
		}

		// Token: 0x0600F3DF RID: 62431 RVA: 0x0041DEC8 File Offset: 0x0041C2C8
		private void BuyFashion(uint mallItemTableID)
		{
			if (this.mDataModel.State == OpActivityState.OAS_PREPARE)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_havenot_open_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)mallItemTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemTable.eSubType moneytype = (ItemTable.eSubType)tableItem.moneytype;
			if (moneytype == ItemTable.eSubType.BindPOINT)
			{
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
			}
			else if (moneytype == ItemTable.eSubType.POINT)
			{
				costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, DataManager<ActivityDataManager>.GetInstance().GetGiftPackData(MallTypeTable.eMallType.SN_GIFT, mallItemTableID), string.Empty);
		}
	}
}
