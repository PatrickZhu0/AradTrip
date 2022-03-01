using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001A65 RID: 6757
	public class WeaponLeaseShopFrame : ClientFrame
	{
		// Token: 0x06010956 RID: 67926 RVA: 0x004AFFAA File Offset: 0x004AE3AA
		protected sealed override void _bindExUI()
		{
			this.mWeaponLeaseShopView = this.mBind.GetCom<WeaponLeaseShopView>("WeaponLeaseShopView");
		}

		// Token: 0x06010957 RID: 67927 RVA: 0x004AFFC2 File Offset: 0x004AE3C2
		protected sealed override void _unbindExUI()
		{
			this.mWeaponLeaseShopView = null;
		}

		// Token: 0x06010958 RID: 67928 RVA: 0x004AFFCC File Offset: 0x004AE3CC
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				int shopID = 0;
				int.TryParse(strParam, out shopID);
				DataManager<ShopDataManager>.GetInstance().OpenShop(shopID, 0, -1, null, null, ShopFrame.ShopFrameMode.SFM_MAIN_FRAME, 0, -1);
			}
			catch (Exception ex)
			{
				Logger.LogError("WeaponLeaseShopFrame.OpenLinkFrame : ==>" + ex.ToString());
			}
		}

		// Token: 0x06010959 RID: 67929 RVA: 0x004B0028 File Offset: 0x004AE428
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/WeaponLeaseShopFrame";
		}

		// Token: 0x0601095A RID: 67930 RVA: 0x004B002F File Offset: 0x004AE42F
		protected sealed override void _OnOpenFrame()
		{
			this.mShopData = (this.userData as ShopData);
			if (this.mShopData != null)
			{
				this.mWeaponLeaseShopView.InitView(this, this.mShopData, new WeaponLeaseItem.OnClickLease(this.OnClickLease));
			}
		}

		// Token: 0x0601095B RID: 67931 RVA: 0x004B006C File Offset: 0x004AE46C
		private void OnClickLease(GoodsData goodsData)
		{
			if (goodsData.eGoodsLimitButyType != GoodsLimitButyType.GLBT_NONE)
			{
				if (goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_TOWER_LEVEL)
				{
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
					if (count < goodsData.iLimitValue)
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_tower_level"), goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				else if (goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_FIGHT_SCORE)
				{
					int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
					if (seasonLevel < goodsData.iLimitValue)
					{
						string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(goodsData.iLimitValue, true);
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_fight_score"), rankName), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				else if (goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_GUILD_LEVEL)
				{
					int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
					if (buildingLevel < goodsData.iLimitValue)
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_guild_level"), goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
			}
			if (goodsData.VipLimitLevel > 0 && goodsData.VipLimitLevel > DataManager<PlayerBaseData>.GetInstance().VipLevel)
			{
				SystemNotifyManager.SystemNotify(1800011, delegate()
				{
					VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
					vipFrame.OpenPayTab();
				});
				return;
			}
			this._OnGoodsClicked(goodsData);
		}

		// Token: 0x0601095C RID: 67932 RVA: 0x004B01EC File Offset: 0x004AE5EC
		private void _OnGoodsClicked(GoodsData goodsData)
		{
			if (!this.frameMgr.IsFrameOpen<PurchaseCommonFrame>(null))
			{
				this.frameMgr.OpenFrame<PurchaseCommonFrame>(FrameLayer.Middle, null, string.Empty);
			}
			UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
			if (idleUIEvent != null)
			{
				idleUIEvent.EventID = EUIEventID.PurchaseCommanUpdate;
				idleUIEvent.EventParams.kPurchaseCommonData.iShopID = ((this.mShopData.ID == null) ? 0 : this.mShopData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iGoodID = ((goodsData.ID == null) ? 0 : goodsData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iItemID = goodsData.ItemData.TableID;
				idleUIEvent.EventParams.kPurchaseCommonData.iCount = goodsData.ItemData.Count;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
			}
		}

		// Token: 0x0601095D RID: 67933 RVA: 0x004B02E6 File Offset: 0x004AE6E6
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mWeaponLeaseShopView.UnInitView();
			this.mShopData = null;
		}

		// Token: 0x0400A925 RID: 43301
		private ShopData mShopData;

		// Token: 0x0400A926 RID: 43302
		private WeaponLeaseShopView mWeaponLeaseShopView;
	}
}
