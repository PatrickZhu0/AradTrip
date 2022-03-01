using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200177A RID: 6010
	public class MallNewExchangeMallElementItem : MonoBehaviour
	{
		// Token: 0x0600ED80 RID: 60800 RVA: 0x003FAD22 File Offset: 0x003F9122
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600ED81 RID: 60801 RVA: 0x003FAD2A File Offset: 0x003F912A
		private void BindUiEventSystem()
		{
			if (this.mallButton != null)
			{
				this.mallButton.onClick.RemoveAllListeners();
				this.mallButton.onClick.AddListener(new UnityAction(this.OnMallButtonClicked));
			}
		}

		// Token: 0x0600ED82 RID: 60802 RVA: 0x003FAD6C File Offset: 0x003F916C
		private void UnBindUiEventSystem()
		{
			if (this.mallButton != null)
			{
				this.mallButton.onClick.RemoveAllListeners();
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnExchangeMallItemLevelChanged));
		}

		// Token: 0x0600ED83 RID: 60803 RVA: 0x003FADC0 File Offset: 0x003F91C0
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600ED84 RID: 60804 RVA: 0x003FADC8 File Offset: 0x003F91C8
		public void InitData(ShopTable shopTable)
		{
			this._shopTable = shopTable;
			if (shopTable != null && shopTable.ShopKind == ShopTable.eShopKind.SK_Guild && DataManager<GuildDataManager>.GetInstance().HasSelfGuild() && DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings != null)
			{
				int nLevel = DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings[GuildBuildingType.SHOP].nLevel;
				GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(nLevel, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this._shopTable = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(tableItem.ShopId, string.Empty, string.Empty);
				}
			}
			if (this._shopTable == null)
			{
				return;
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnExchangeMallItemLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnExchangeMallItemLevelChanged));
			this.InitElementView();
		}

		// Token: 0x0600ED85 RID: 60805 RVA: 0x003FAEC6 File Offset: 0x003F92C6
		private void InitElementView()
		{
			this.InitMallPreName();
			this.InitSpecialContent();
			if (this.mallIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mallIcon, this._shopTable.ExchangeShopShowImage, true);
			}
			this.UpdateMallElementItemState();
		}

		// Token: 0x0600ED86 RID: 60806 RVA: 0x003FAF04 File Offset: 0x003F9304
		private void InitMallPreName()
		{
			if (this._shopTable == null || string.IsNullOrEmpty(this._shopTable.ExchangeShopNameImage))
			{
				return;
			}
			if (this.mallPreName == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.mallPreName, this._shopTable.ExchangeShopNameImage, true);
		}

		// Token: 0x0600ED87 RID: 60807 RVA: 0x003FAF5C File Offset: 0x003F935C
		private void InitSpecialContent()
		{
			if (this.specialContent == null)
			{
				return;
			}
			if (this._shopTable == null)
			{
				return;
			}
			if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_Magic)
			{
				this.specialContent.gameObject.CustomActive(true);
				if (this.specialContentLabel != null)
				{
					this.specialContentLabel.text = TR.Value("exchange_mall_special_description");
				}
			}
			else if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_Activity)
			{
				this.specialContent.gameObject.CustomActive(true);
				if (this.specialContentLabel != null)
				{
					string activityShopTimeData = ShopNewUtility.GetActivityShopTimeData(this._shopTable);
					if (string.IsNullOrEmpty(activityShopTimeData))
					{
						this.specialContent.gameObject.CustomActive(false);
					}
					else
					{
						this.specialContentLabel.text = activityShopTimeData;
					}
				}
			}
			else if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_BlessCrystal)
			{
				this.specialContent.gameObject.CustomActive(true);
				if (this.specialContentLabel != null)
				{
					this.specialContentLabel.text = TR.Value("adventure_team_shop_blesscrystal_clear_tip");
				}
			}
			else if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_AdventureCoin)
			{
				this.specialContent.gameObject.CustomActive(true);
				if (this.specialContentLabel != null)
				{
					this.specialContentLabel.text = TR.Value("adventurer_pass_card_shop_coin_clear_tip");
				}
			}
			else
			{
				this.specialContent.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600ED88 RID: 60808 RVA: 0x003FB0F4 File Offset: 0x003F94F4
		private void OnExchangeMallItemLevelChanged(int preLevel, int curLevel)
		{
			if (this._shopTable == null)
			{
				return;
			}
			if (!this._isLocked)
			{
				return;
			}
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			int openLevel = this._shopTable.OpenLevel;
			if (level < openLevel)
			{
				return;
			}
			this.UpdateMallElementItemState();
		}

		// Token: 0x0600ED89 RID: 60809 RVA: 0x003FB140 File Offset: 0x003F9540
		private void UpdateMallElementItemState()
		{
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			int openLevel = this._shopTable.OpenLevel;
			if (level < openLevel)
			{
				this._isLocked = true;
			}
			else
			{
				this._isLocked = false;
			}
			if (DataManager<AccountShopDataManager>.GetInstance().CheckIsAdventureTeamAccShop(this._shopTable))
			{
				this._isLocked = !DataManager<AccountShopDataManager>.GetInstance().CheckIsAdventureTeamAccShopOpen();
			}
			if (this._shopTable != null && this._shopTable.ShopKind == ShopTable.eShopKind.SK_Guild && !DataManager<GuildDataManager>.GetInstance().HasSelfGuild())
			{
				this._isLocked = true;
			}
			if (this._shopTable != null && this._shopTable.ShopKind == ShopTable.eShopKind.SK_AdventureCoin && DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv == 0U)
			{
				this._isLocked = true;
			}
			if (this._isLocked)
			{
				if (this.mallLock != null)
				{
					this.mallLock.gameObject.CustomActive(true);
				}
				if (this.uiGray != null)
				{
					this.uiGray.enabled = true;
					this.uiGray.Refresh();
				}
			}
			else
			{
				if (this.mallLock != null)
				{
					this.mallLock.gameObject.CustomActive(false);
				}
				if (this.uiGray != null)
				{
					this.uiGray.enabled = false;
				}
			}
		}

		// Token: 0x0600ED8A RID: 60810 RVA: 0x003FB2A4 File Offset: 0x003F96A4
		public void OnMallButtonClicked()
		{
			if (this._isLocked)
			{
				if (this._shopTable == null)
				{
					Logger.LogErrorFormat("shopTable is invalid ", new object[0]);
					return;
				}
				if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_Guild)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("have_no_guild"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
				else if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_AdventureCoin)
				{
					if (DataManager<AdventurerPassCardDataManager>.GetInstance().SeasonID == 0U)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_shop_locked"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("adventurer_pass_card_shop_locked1"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
				else
				{
					string msgContent = string.Format(TR.Value("exchange_mall_not_open"), this._shopTable.OpenLevel, this._shopTable.ShopName);
					SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				}
			}
			else
			{
				if (this._shopTable == null)
				{
					Logger.LogErrorFormat("shopTable is invalid ", new object[0]);
					return;
				}
				Utility.DoStartFrameOperation("MallNewExchangeMallElementItem", string.Format("ShopID/{0}", this._shopTable.ID));
				if (this._shopTable.ShopKind == ShopTable.eShopKind.SK_Activity && !ShopNewUtility.IsActivityShopInStartState(this._shopTable))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("shop_new_activity_end"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (this._shopTable.BindType == ShopTable.eBindType.ACCOUNT_BIND)
				{
					DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(this._shopTable.ID, 0, 0, -1);
					return;
				}
				DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(this._shopTable.ID, 0, 0, -1);
			}
		}

		// Token: 0x040090F6 RID: 37110
		private const int StoneShopId = 24;

		// Token: 0x040090F7 RID: 37111
		private ShopTable _shopTable;

		// Token: 0x040090F8 RID: 37112
		private bool _isLocked;

		// Token: 0x040090F9 RID: 37113
		[SerializeField]
		private Image mallIcon;

		// Token: 0x040090FA RID: 37114
		[SerializeField]
		private Image mallLock;

		// Token: 0x040090FB RID: 37115
		[SerializeField]
		private UIGray uiGray;

		// Token: 0x040090FC RID: 37116
		[SerializeField]
		private Image mallPreName;

		// Token: 0x040090FD RID: 37117
		[SerializeField]
		private GameObject specialContent;

		// Token: 0x040090FE RID: 37118
		[SerializeField]
		private Text specialContentLabel;

		// Token: 0x040090FF RID: 37119
		[SerializeField]
		private Button mallButton;
	}
}
