using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A44 RID: 6724
	internal class MysteryShopFrame : ClientFrame
	{
		// Token: 0x06010833 RID: 67635 RVA: 0x004A6357 File Offset: 0x004A4757
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/MysteryShopFrame";
		}

		// Token: 0x06010834 RID: 67636 RVA: 0x004A635E File Offset: 0x004A475E
		protected sealed override void _OnOpenFrame()
		{
			this.data = (this.userData as MysteryShopData);
			this.InitMerchantInfo();
			this.InitMysteriousGoodsDate();
			this.BindUIEvent();
		}

		// Token: 0x06010835 RID: 67637 RVA: 0x004A6383 File Offset: 0x004A4783
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.data = null;
			this.m_akMysteriousGoodsDataItems.DestroyAllObjects();
		}

		// Token: 0x06010836 RID: 67638 RVA: 0x004A63A0 File Offset: 0x004A47A0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010837 RID: 67639 RVA: 0x004A63F0 File Offset: 0x004A47F0
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._RereshAllGoods));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010838 RID: 67640 RVA: 0x004A643E File Offset: 0x004A483E
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x06010839 RID: 67641 RVA: 0x004A6446 File Offset: 0x004A4846
		private void _RereshAllGoods(UIEvent uiEvent)
		{
			this._RefreshAllObjects();
		}

		// Token: 0x0601083A RID: 67642 RVA: 0x004A644E File Offset: 0x004A484E
		private void _RefreshAllObjects()
		{
			this.m_akMysteriousGoodsDataItems.RefreshAllObjects(null);
		}

		// Token: 0x0601083B RID: 67643 RVA: 0x004A645C File Offset: 0x004A485C
		private void InitMerchantInfo()
		{
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this.data.mysteryShopData.ID.Value, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.ShopNpcBody != string.Empty)
			{
				ETCImageLoader.LoadSprite(ref this.mMerchantImage, tableItem.ShopNpcBody, true);
			}
			this.mName.text = tableItem.ShopName + ":";
		}

		// Token: 0x0601083C RID: 67644 RVA: 0x004A64E0 File Offset: 0x004A48E0
		private void InitMysteriousGoodsDate()
		{
			this.m_MysteriousGoodsParent = Utility.FindGameObject(this.frame, "middleback/Goods/Scroll View/Viewport/Content", true);
			this.m_MysteriousGoodsPrefab = Utility.FindGameObject(this.frame, "middleback/Goods/Scroll View/Viewport/Content/Prefab", true);
			this.m_MysteriousGoodsPrefab.CustomActive(false);
			if (this.data != null)
			{
				for (int i = 0; i < this.data.mysteryShopData.Goods.Count; i++)
				{
					this.OnAddMysteriousGoodsData(this.data.mysteryShopData.Goods[i]);
					this.MysticalShopGoodsRefreshNumber(this.data.mysteryShopData.Goods[i]);
				}
			}
		}

		// Token: 0x0601083D RID: 67645 RVA: 0x004A6590 File Offset: 0x004A4990
		private void OnAddMysteriousGoodsData(GoodsData data)
		{
			CachedObjectDicManager<ulong, MysteryShopFrame.MysteriousGoodsDateItem> akMysteriousGoodsDataItems = this.m_akMysteriousGoodsDataItems;
			int? id = data.ID;
			akMysteriousGoodsDataItems.Create((ulong)((long)id.Value), new object[]
			{
				this.m_MysteriousGoodsParent,
				this.m_MysteriousGoodsPrefab,
				data,
				this
			});
		}

		// Token: 0x0601083E RID: 67646 RVA: 0x004A65D8 File Offset: 0x004A49D8
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
				idleUIEvent.EventParams.kPurchaseCommonData.iShopID = ((this.data.mysteryShopData.ID == null) ? 0 : this.data.mysteryShopData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iGoodID = ((goodsData.ID == null) ? 0 : goodsData.ID.Value);
				idleUIEvent.EventParams.kPurchaseCommonData.iItemID = goodsData.ItemData.TableID;
				idleUIEvent.EventParams.kPurchaseCommonData.iCount = goodsData.ItemData.Count;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
			}
		}

		// Token: 0x0601083F RID: 67647 RVA: 0x004A66DC File Offset: 0x004A4ADC
		protected sealed override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mMerchantImage = this.mBind.GetCom<Image>("MerchantImage");
			this.mAddButton = this.mBind.GetCom<Button>("Add");
			if (this.mAddButton != null)
			{
				this.mAddButton.onClick.AddListener(new UnityAction(this.OnAddClick));
			}
			this.mAddBindGoldBtn = this.mBind.GetCom<Button>("AddBindGold");
			this.mAddBindGoldBtn.onClick.AddListener(new UnityAction(this.OnAddBindGoldClick));
		}

		// Token: 0x06010840 RID: 67648 RVA: 0x004A678C File Offset: 0x004A4B8C
		protected sealed override void _unbindExUI()
		{
			this.mName = null;
			this.mMerchantImage = null;
			if (this.mAddButton != null)
			{
				this.mAddButton.onClick.RemoveAllListeners();
			}
			this.mAddButton = null;
			this.mAddBindGoldBtn.onClick.RemoveAllListeners();
			this.mAddBindGoldBtn = null;
		}

		// Token: 0x06010841 RID: 67649 RVA: 0x004A67E8 File Offset: 0x004A4BE8
		private void OnAddClick()
		{
			int id = 0;
			int.TryParse(TR.Value("MysteryShopGoldID"), out id);
			DataManager<ShopDataManager>.GetInstance().OnGoldBuy(id);
		}

		// Token: 0x06010842 RID: 67650 RVA: 0x004A6814 File Offset: 0x004A4C14
		private void OnAddBindGoldClick()
		{
			int id = 0;
			int.TryParse(TR.Value("MysteryShopBindGoldID"), out id);
			DataManager<ShopDataManager>.GetInstance().OnGoldBuy(id);
		}

		// Token: 0x06010843 RID: 67651 RVA: 0x004A6840 File Offset: 0x004A4C40
		[UIEventHandle("BG/Close")]
		private void OnCloseClick()
		{
			this.frameMgr.CloseFrame<MysteryShopFrame>(this, false);
		}

		// Token: 0x06010844 RID: 67652 RVA: 0x004A6850 File Offset: 0x004A4C50
		protected void MysticalShopGoodsRefreshNumber(GoodsData goodsData)
		{
			int itemId = (goodsData.ID == null) ? 0 : goodsData.ID.Value;
			Singleton<GameStatisticManager>.GetInstance().DoStartMysticalShopGoods(itemId);
		}

		// Token: 0x0400A7EB RID: 42987
		private MysteryShopData data;

		// Token: 0x0400A7EC RID: 42988
		private CachedObjectDicManager<ulong, MysteryShopFrame.MysteriousGoodsDateItem> m_akMysteriousGoodsDataItems = new CachedObjectDicManager<ulong, MysteryShopFrame.MysteriousGoodsDateItem>();

		// Token: 0x0400A7ED RID: 42989
		private GameObject m_MysteriousGoodsParent;

		// Token: 0x0400A7EE RID: 42990
		private GameObject m_MysteriousGoodsPrefab;

		// Token: 0x0400A7EF RID: 42991
		private Text mName;

		// Token: 0x0400A7F0 RID: 42992
		private Image mMerchantImage;

		// Token: 0x0400A7F1 RID: 42993
		private Button mAddButton;

		// Token: 0x0400A7F2 RID: 42994
		private Button mAddBindGoldBtn;

		// Token: 0x02001A45 RID: 6725
		private class MysteriousGoodsDateItem : CachedObject
		{
			// Token: 0x17001D51 RID: 7505
			// (get) Token: 0x06010846 RID: 67654 RVA: 0x004A6892 File Offset: 0x004A4C92
			public GoodsData GoodsData
			{
				get
				{
					return this.goodsData;
				}
			}

			// Token: 0x06010847 RID: 67655 RVA: 0x004A689C File Offset: 0x004A4C9C
			public sealed override void OnDestroy()
			{
				if (this.btBuy != null)
				{
					this.btBuy.onClick.RemoveAllListeners();
					this.btBuy = null;
				}
				if (this.comItem != null)
				{
					this.comItem.Setup(null, null);
					this.comItem = null;
				}
			}

			// Token: 0x06010848 RID: 67656 RVA: 0x004A68F8 File Offset: 0x004A4CF8
			public sealed override void OnCreate(object[] param)
			{
				this.goParent = (param[0] as GameObject);
				this.goPrefab = (param[1] as GameObject);
				this.goodsData = (param[2] as GoodsData);
				this.frame = (param[3] as MysteryShopFrame);
				if (this.goLocal == null)
				{
					this.goLocal = Object.Instantiate<GameObject>(this.goPrefab);
					Utility.AttachTo(this.goLocal, this.goParent, false);
					ComCommonBind component = this.goLocal.GetComponent<ComCommonBind>();
					if (component != null)
					{
						this.name = component.GetCom<Text>("name");
						this.itemParent = component.GetGameObject("ItemParent");
						this.comItem = this.frame.CreateComItem(this.itemParent);
						this.buyCount = component.GetCom<Text>("buyCount");
						this.ticketIcon = component.GetCom<Image>("TicketIcon");
						this.curPrice = component.GetCom<Text>("curprice");
						this.colorPrice = this.curPrice.color;
						this.goodsDisCountInfo = component.GetGameObject("VipCountInfo");
						this.disCount = component.GetCom<Text>("discount");
						this.btBuy = component.GetCom<Button>("btBuy");
						this.btBuy.onClick.AddListener(new UnityAction(this.OnClickBuy));
						this.btBuyGray = component.GetCom<UIGray>("btBuyGray");
						this.sellOver = component.GetGameObject("SellOver");
						this.goNormalPrice = component.GetGameObject("Horizen");
					}
				}
				this.Enable();
				this._Update();
			}

			// Token: 0x06010849 RID: 67657 RVA: 0x004A6A94 File Offset: 0x004A4E94
			public sealed override void OnRecycle()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601084A RID: 67658 RVA: 0x004A6AB3 File Offset: 0x004A4EB3
			public sealed override void OnDecycle(object[] param)
			{
				this.OnCreate(param);
			}

			// Token: 0x0601084B RID: 67659 RVA: 0x004A6ABC File Offset: 0x004A4EBC
			public sealed override void OnRefresh(object[] param)
			{
				if (param != null && param.Length > 0)
				{
					this.goodsData = (param[0] as GoodsData);
				}
				this._Update();
			}

			// Token: 0x0601084C RID: 67660 RVA: 0x004A6AE1 File Offset: 0x004A4EE1
			public sealed override void Enable()
			{
				if (null != this.goLocal)
				{
					this.goLocal.CustomActive(true);
				}
			}

			// Token: 0x0601084D RID: 67661 RVA: 0x004A6B00 File Offset: 0x004A4F00
			public sealed override void Disable()
			{
				if (this.goLocal != null)
				{
					this.goLocal.CustomActive(false);
				}
			}

			// Token: 0x0601084E RID: 67662 RVA: 0x004A6B1F File Offset: 0x004A4F1F
			public sealed override void SetAsLastSibling()
			{
				if (this.goLocal != null)
				{
					this.goLocal.transform.SetAsLastSibling();
				}
			}

			// Token: 0x0601084F RID: 67663 RVA: 0x004A6B44 File Offset: 0x004A4F44
			private void _Update()
			{
				this.goodsData.ItemData.userData = this.goodsData;
				this.comItem.Setup(this.goodsData.ItemData, delegate(GameObject obj, ItemData item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
				});
				this.name.text = this.goodsData.ItemData.GetColorName(string.Empty, false);
				ETCImageLoader.LoadSprite(ref this.ticketIcon, this.goodsData.CostItemData.Icon, true);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.goodsData.CostItemData.TableID, true);
				this.goodsDisCountInfo.CustomActive(this.goodsData.GoodsDisCount != null && this.goodsData.GoodsDisCount.Value < 100 && this.goodsData.GoodsDisCount.Value > 0);
				if (this.goodsData.GoodsDisCount != null && this.goodsData.GoodsDisCount.Value < 100 && this.goodsData.GoodsDisCount.Value > 0)
				{
					int num = this.goodsData.GoodsDisCount.Value * this.goodsData.CostItemCount.Value / 100;
					this.curPrice.text = num.ToString();
					this.curPrice.color = ((ownedItemCount < num) ? Color.red : this.colorPrice);
					this.disCount.text = TR.Value("shop_item_discount_info", this.goodsData.GoodsDisCount.Value / 10);
					bool flag = ownedItemCount >= num;
				}
				else
				{
					this.curPrice.text = this.goodsData.CostItemCount.Value.ToString();
					this.curPrice.color = ((!(ownedItemCount >= this.goodsData.CostItemCount)) ? Color.red : this.colorPrice);
					bool flag2 = ownedItemCount >= this.goodsData.CostItemCount;
				}
				this.buyCount.CustomActive(this.goodsData.LimitBuyTimes > 0);
				this.buyCount.text = string.Format(TR.Value("shop_mysteryshop_buycount", this.goodsData.LimitBuyTimes, this.goodsData.TotalLimitBuyTimes), new object[0]);
				this.btBuy.enabled = (this.goodsData.LimitBuyTimes != 0);
				this.btBuyGray.enabled = !this.btBuy.enabled;
				this.sellOver.CustomActive(this.goodsData.LimitBuyTimes == 0);
				this.goNormalPrice.CustomActive(!this.sellOver.activeSelf);
			}

			// Token: 0x06010850 RID: 67664 RVA: 0x004A6E7C File Offset: 0x004A527C
			public void OnClickBuy()
			{
				if (this.goodsData.eGoodsLimitButyType != GoodsLimitButyType.GLBT_NONE)
				{
					if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_TOWER_LEVEL)
					{
						int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
						if (count < this.goodsData.iLimitValue)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_tower_level"), this.goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
					else if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_FIGHT_SCORE)
					{
						int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
						if (seasonLevel < this.goodsData.iLimitValue)
						{
							string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(this.goodsData.iLimitValue, true);
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_fight_score"), rankName), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
					else if (this.goodsData.eGoodsLimitButyType == GoodsLimitButyType.GLBT_GUILD_LEVEL)
					{
						int buildingLevel = DataManager<GuildDataManager>.GetInstance().GetBuildingLevel(GuildBuildingType.SHOP);
						if (buildingLevel < this.goodsData.iLimitValue)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("shop_buy_need_guild_level"), this.goodsData.iLimitValue), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
					}
				}
				if (this.goodsData.VipLimitLevel > 0 && this.goodsData.VipLimitLevel > DataManager<PlayerBaseData>.GetInstance().VipLevel)
				{
					SystemNotifyManager.SystemNotify(1800011, delegate()
					{
						VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
						vipFrame.OpenPayTab();
					});
					return;
				}
				this.frame._OnGoodsClicked(this.goodsData);
			}

			// Token: 0x0400A7F3 RID: 42995
			private GameObject goLocal;

			// Token: 0x0400A7F4 RID: 42996
			private GameObject goPrefab;

			// Token: 0x0400A7F5 RID: 42997
			private GameObject goParent;

			// Token: 0x0400A7F6 RID: 42998
			private GoodsData goodsData;

			// Token: 0x0400A7F7 RID: 42999
			private MysteryShopFrame frame;

			// Token: 0x0400A7F8 RID: 43000
			private Text name;

			// Token: 0x0400A7F9 RID: 43001
			private GameObject itemParent;

			// Token: 0x0400A7FA RID: 43002
			private ComItem comItem;

			// Token: 0x0400A7FB RID: 43003
			private Text buyCount;

			// Token: 0x0400A7FC RID: 43004
			private Image ticketIcon;

			// Token: 0x0400A7FD RID: 43005
			private Text curPrice;

			// Token: 0x0400A7FE RID: 43006
			private Color colorPrice;

			// Token: 0x0400A7FF RID: 43007
			private GameObject goodsDisCountInfo;

			// Token: 0x0400A800 RID: 43008
			private Text disCount;

			// Token: 0x0400A801 RID: 43009
			private Button btBuy;

			// Token: 0x0400A802 RID: 43010
			private UIGray btBuyGray;

			// Token: 0x0400A803 RID: 43011
			private GameObject sellOver;

			// Token: 0x0400A804 RID: 43012
			private GameObject goNormalPrice;
		}
	}
}
