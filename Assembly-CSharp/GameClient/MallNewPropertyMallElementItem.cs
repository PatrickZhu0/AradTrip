using System;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017A1 RID: 6049
	public class MallNewPropertyMallElementItem : MonoBehaviour
	{
		// Token: 0x0600EE8C RID: 61068 RVA: 0x00400905 File Offset: 0x003FED05
		private void Awake()
		{
			this.ClearData();
			this.BindUiEventSystem();
		}

		// Token: 0x0600EE8D RID: 61069 RVA: 0x00400913 File Offset: 0x003FED13
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnButtonClickCallBack));
			}
		}

		// Token: 0x0600EE8E RID: 61070 RVA: 0x00400952 File Offset: 0x003FED52
		private void OnDestroy()
		{
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
			}
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EE8F RID: 61071 RVA: 0x0040097C File Offset: 0x003FED7C
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600EE90 RID: 61072 RVA: 0x004009A0 File Offset: 0x003FEDA0
		private void ClearData()
		{
			this._mallItemInfo = null;
			this._isPlayerLimit = false;
			this._playerLimitDescriptionStr = string.Empty;
			this._playerLimitItemLeftNumber = 0;
			this._isAccountLimit = false;
			this._accountLimitDescriptionStr = string.Empty;
			this._accountLimitItemLeftNumber = 0;
			this._isUpdate = false;
		}

		// Token: 0x0600EE91 RID: 61073 RVA: 0x004009F0 File Offset: 0x003FEDF0
		private void Update()
		{
			if (this._mallItemInfo != null && this._mallItemInfo.multipleEndTime > 0U)
			{
				this._isUpdate = true;
			}
			if (this._isUpdate)
			{
				int num = (int)(this._mallItemInfo.multipleEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
				if (num <= 0)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSendQueryMallItemInfo, this._mallItemInfo.itemid, null, null, null);
					this._isUpdate = false;
				}
			}
		}

		// Token: 0x0600EE92 RID: 61074 RVA: 0x00400A74 File Offset: 0x003FEE74
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
		}

		// Token: 0x0600EE93 RID: 61075 RVA: 0x00400AD4 File Offset: 0x003FEED4
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
		}

		// Token: 0x0600EE94 RID: 61076 RVA: 0x00400B32 File Offset: 0x003FEF32
		public void InitData(MallItemInfo mallItemInfo)
		{
			this.ClearData();
			this._mallItemInfo = mallItemInfo;
			if (this._mallItemInfo == null)
			{
				return;
			}
			this.InitElementView();
		}

		// Token: 0x0600EE95 RID: 61077 RVA: 0x00400B53 File Offset: 0x003FEF53
		private void InitElementView()
		{
			this.InitElementLimitData();
			this.InitElementItem();
			this.InitElementBuyContent();
			this.UpdateCreditPointFlag();
		}

		// Token: 0x0600EE96 RID: 61078 RVA: 0x00400B70 File Offset: 0x003FEF70
		private void InitElementLimitData()
		{
			bool flag = this.IsMallItemLimitBuy();
			if (flag)
			{
				if (this._mallItemInfo.limit == 0)
				{
					this._isPlayerLimit = false;
				}
				else
				{
					this._isPlayerLimit = true;
					this._playerLimitDescriptionStr = TR.Value("mall_new_limit_player_day_limit");
					ELimitiTimeGiftDataLimitType limit = (ELimitiTimeGiftDataLimitType)this._mallItemInfo.limit;
					if (limit != ELimitiTimeGiftDataLimitType.Refresh)
					{
						if (limit != ELimitiTimeGiftDataLimitType.Week)
						{
							if (limit == ELimitiTimeGiftDataLimitType.NotRefresh)
							{
								this._playerLimitDescriptionStr = TR.Value("mall_new_limit_player_forever_limit");
								this._playerLimitItemLeftNumber = (int)this._mallItemInfo.limittotalnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
							}
						}
						else
						{
							this._playerLimitDescriptionStr = TR.Value("mall_new_limit_player_week_limit");
							this._playerLimitItemLeftNumber = (int)this._mallItemInfo.limitnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
						}
					}
					else
					{
						this._playerLimitDescriptionStr = TR.Value("mall_new_limit_player_day_limit");
						this._playerLimitItemLeftNumber = (int)this._mallItemInfo.limitnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
					}
					if (this._playerLimitItemLeftNumber <= 0)
					{
						this._playerLimitItemLeftNumber = 0;
					}
				}
				if (this._mallItemInfo.accountLimitBuyNum <= 0U)
				{
					this._isAccountLimit = false;
				}
				else
				{
					this._isAccountLimit = true;
					this._accountLimitItemLeftNumber = (int)this._mallItemInfo.accountRestBuyNum;
					this._accountLimitDescriptionStr = TR.Value("mall_new_limit_account_day_limit");
					switch (this._mallItemInfo.accountRefreshType)
					{
					case 0:
						this._accountLimitDescriptionStr = TR.Value("mall_new_limit_account_forever_limit");
						break;
					case 1:
						this._accountLimitDescriptionStr = TR.Value("mall_new_limit_account_month_limit");
						break;
					case 2:
						this._accountLimitDescriptionStr = TR.Value("mall_new_limit_account_week_limit");
						break;
					case 3:
						this._accountLimitDescriptionStr = TR.Value("mall_new_limit_account_day_limit");
						break;
					}
				}
			}
		}

		// Token: 0x0600EE97 RID: 61079 RVA: 0x00400D8C File Offset: 0x003FF18C
		private void InitElementItem()
		{
			int itemid = (int)this._mallItemInfo.itemid;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemid, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("The itemTable is null and itemId is {0}", new object[]
				{
					itemid
				});
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemid, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("The ItemData is null and itemId is {0}", new object[]
				{
					itemid
				});
				return;
			}
			if (itemData.SubType != 17 && itemData.SubType != 27)
			{
				itemData.Count = (int)this._mallItemInfo.itemnum;
			}
			this._comItem = this.itemRoot.GetComponentInChildren<ComItem>();
			if (this._comItem == null)
			{
				this._comItem = ComItemManager.Create(this.itemRoot);
			}
			this._comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			if (this.nameText != null)
			{
				if (itemData.SubType == 17 || itemData.SubType == 27)
				{
					this.nameText.text = Utility.GetShowPrice((ulong)this._mallItemInfo.itemnum, true) + itemData.Name;
				}
				else
				{
					this.nameText.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
				}
			}
		}

		// Token: 0x0600EE98 RID: 61080 RVA: 0x00400EF4 File Offset: 0x003FF2F4
		private void UpdateCreditPointFlag()
		{
			if (this.creditTicketFlag == null)
			{
				return;
			}
			bool flag = MallNewUtility.IsMallItemCanCreditPointDeduction(this._mallItemInfo);
			CommonUtility.UpdateGameObjectVisible(this.creditTicketFlag, flag);
		}

		// Token: 0x0600EE99 RID: 61081 RVA: 0x00400F2C File Offset: 0x003FF32C
		private void InitElementBuyContent()
		{
			if (this.costIcon != null)
			{
				ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(this._mallItemInfo.moneytype);
				if (costItemTableByCostType != null)
				{
					ETCImageLoader.LoadSprite(ref this.costIcon, costItemTableByCostType.Icon, true);
				}
				else
				{
					Logger.LogErrorFormat("CostItemTable is null and moneyType is {0}", new object[]
					{
						this._mallItemInfo.moneytype
					});
				}
			}
			this.curPriceText.text = Utility.GetMallRealPrice(this._mallItemInfo).ToString();
			this.UpdateElementBuyContent();
		}

		// Token: 0x0600EE9A RID: 61082 RVA: 0x00400FCC File Offset: 0x003FF3CC
		private void UpdateIntergralInfo()
		{
			this.intergralFlagRoot.CustomActive(this._mallItemInfo.multiple > 0);
			this.intergralRoot.CustomActive(this._mallItemInfo.multipleEndTime > 0U);
			this.singleRoot.CustomActive(this._mallItemInfo.multiple == 1);
			this.multiplePlictityRoot.CustomActive(this._mallItemInfo.multiple > 1);
			if (this.intergralMultiple != null)
			{
				ETCImageLoader.LoadSprite(ref this.intergralMultiple, TR.Value("mall_new_limit_item_left_intergral_multiple_sprit_path", this._mallItemInfo.multiple), true);
			}
			this.intergralLimtText.text = TR.Value("mall_new_limit_item_left_intergral_multiple_limit", this._mallItemInfo.multiple, Function.SetShowTimeDay((int)this._mallItemInfo.multipleEndTime));
		}

		// Token: 0x0600EE9B RID: 61083 RVA: 0x004010AC File Offset: 0x003FF4AC
		private void UpdateElementBuyContent()
		{
			this.UpdateIntergralInfo();
			if (!this.IsLimitItem())
			{
				this.UpdateBuyButton(true);
				this.costRoot.gameObject.CustomActive(true);
				this.limitRoot.gameObject.CustomActive(false);
				this.finishRoot.gameObject.CustomActive(false);
				return;
			}
			if ((this._isPlayerLimit && this._playerLimitItemLeftNumber <= 0) || (this._isAccountLimit && this._accountLimitItemLeftNumber <= 0))
			{
				this.UpdateBuyButton(false);
				this.costRoot.gameObject.CustomActive(false);
				this.limitRoot.gameObject.CustomActive(false);
				this.finishRoot.gameObject.CustomActive(true);
				this.finishText.text = TR.Value("mall_new_limit_item_left_number_zero");
			}
			else
			{
				this.finishRoot.gameObject.CustomActive(false);
				this.UpdateBuyButton(true);
				this.costRoot.gameObject.CustomActive(true);
				this.limitRoot.gameObject.CustomActive(true);
				if (this.playerLimitText != null)
				{
					if (this._isPlayerLimit)
					{
						CommonUtility.UpdateTextVisible(this.playerLimitText, true);
						this.playerLimitText.text = string.Format(this._playerLimitDescriptionStr, this._playerLimitItemLeftNumber);
					}
					else
					{
						CommonUtility.UpdateTextVisible(this.playerLimitText, false);
					}
				}
				if (this.accountLimitText != null)
				{
					if (this._isAccountLimit)
					{
						CommonUtility.UpdateTextVisible(this.accountLimitText, true);
						this.accountLimitText.text = string.Format(this._accountLimitDescriptionStr, this._accountLimitItemLeftNumber);
					}
					else
					{
						CommonUtility.UpdateTextVisible(this.accountLimitText, false);
					}
				}
			}
		}

		// Token: 0x0600EE9C RID: 61084 RVA: 0x00401275 File Offset: 0x003FF675
		private void UpdateBuyButton(bool flag)
		{
			if (this.buyButtonGray != null)
			{
				this.buyButtonGray.enabled = !flag;
			}
			if (this.buyButton != null)
			{
				this.buyButton.interactable = flag;
			}
		}

		// Token: 0x0600EE9D RID: 61085 RVA: 0x004012B4 File Offset: 0x003FF6B4
		private void OnButtonClickCallBack()
		{
			if (this._mallItemInfo == null)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			this.OpenMallBuyFrame();
		}

		// Token: 0x0600EE9E RID: 61086 RVA: 0x004012DC File Offset: 0x003FF6DC
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null || uiEvent.Param3 == null)
			{
				return;
			}
			if (this._mallItemInfo == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (this._mallItemInfo.id != num)
			{
				return;
			}
			if (!this.IsLimitItem())
			{
				return;
			}
			this._playerLimitItemLeftNumber = (int)uiEvent.Param2;
			this._accountLimitItemLeftNumber = (int)uiEvent.Param3;
			this.UpdateElementBuyContent();
		}

		// Token: 0x0600EE9F RID: 61087 RVA: 0x00401370 File Offset: 0x003FF770
		private void ReqQueryMallItemInfo(UIEvent uiEvent)
		{
			if (this._mallItemInfo == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (this._mallItemInfo.itemid != num)
			{
				return;
			}
			DataManager<MallNewDataManager>.GetInstance().ReqQueryMallItemInfo((int)this._mallItemInfo.itemid);
		}

		// Token: 0x0600EEA0 RID: 61088 RVA: 0x004013BC File Offset: 0x003FF7BC
		private void OnQueryMallItenInfoSuccess(UIEvent uiEvent)
		{
			this._mallItemInfo = DataManager<MallNewDataManager>.GetInstance().QueryMallItemInfo;
			this.UpdateIntergralInfo();
		}

		// Token: 0x0600EEA1 RID: 61089 RVA: 0x004013D4 File Offset: 0x003FF7D4
		private void OpenMallBuyFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallBuyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallBuyFrame>(null, false);
			}
			Utility.DoStartFrameOperation("MallNewPropertyMallElementItem", string.Format("BuyItem/{0}", this._mallItemInfo.itemid));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, this._mallItemInfo, string.Empty);
		}

		// Token: 0x0600EEA2 RID: 61090 RVA: 0x00401438 File Offset: 0x003FF838
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			Utility.DoStartFrameOperation("MallNewPropertyMallElementItem", string.Format("DetailItem/{0}", itemData.PackID));
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600EEA3 RID: 61091 RVA: 0x0040146C File Offset: 0x003FF86C
		private bool IsMallItemLimitBuy()
		{
			return this._mallItemInfo != null && (this._mallItemInfo.type == 10 || this._mallItemInfo.type == 3 || this._mallItemInfo.type == 11 || this._mallItemInfo.type == 5 || this._mallItemInfo.type == 15 || this._mallItemInfo.type == 16 || this._mallItemInfo.type == 17 || this._mallItemInfo.type == 18 || this._mallItemInfo.type == 19);
		}

		// Token: 0x0600EEA4 RID: 61092 RVA: 0x00401529 File Offset: 0x003FF929
		private bool IsLimitItem()
		{
			return this._isPlayerLimit || this._isAccountLimit;
		}

		// Token: 0x040091F6 RID: 37366
		private MallItemInfo _mallItemInfo;

		// Token: 0x040091F7 RID: 37367
		private bool _isPlayerLimit;

		// Token: 0x040091F8 RID: 37368
		private string _playerLimitDescriptionStr = string.Empty;

		// Token: 0x040091F9 RID: 37369
		private int _playerLimitItemLeftNumber;

		// Token: 0x040091FA RID: 37370
		private bool _isAccountLimit;

		// Token: 0x040091FB RID: 37371
		private string _accountLimitDescriptionStr = string.Empty;

		// Token: 0x040091FC RID: 37372
		private int _accountLimitItemLeftNumber;

		// Token: 0x040091FD RID: 37373
		private bool _isUpdate;

		// Token: 0x040091FE RID: 37374
		private ComItem _comItem;

		// Token: 0x040091FF RID: 37375
		[Header("Text")]
		[SerializeField]
		private Text nameText;

		// Token: 0x04009200 RID: 37376
		[SerializeField]
		private Text playerLimitText;

		// Token: 0x04009201 RID: 37377
		[SerializeField]
		private Text accountLimitText;

		// Token: 0x04009202 RID: 37378
		[SerializeField]
		private Text curPriceText;

		// Token: 0x04009203 RID: 37379
		[SerializeField]
		private Text finishText;

		// Token: 0x04009204 RID: 37380
		[SerializeField]
		private Text intergralLimtText;

		// Token: 0x04009205 RID: 37381
		[Header("Image")]
		[SerializeField]
		private Image costIcon;

		// Token: 0x04009206 RID: 37382
		[SerializeField]
		private Image intergralMultiple;

		// Token: 0x04009207 RID: 37383
		[Header("GameObject")]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x04009208 RID: 37384
		[SerializeField]
		private GameObject limitRoot;

		// Token: 0x04009209 RID: 37385
		[SerializeField]
		private GameObject costRoot;

		// Token: 0x0400920A RID: 37386
		[SerializeField]
		private GameObject finishRoot;

		// Token: 0x0400920B RID: 37387
		[SerializeField]
		private GameObject intergralRoot;

		// Token: 0x0400920C RID: 37388
		[SerializeField]
		private GameObject intergralFlagRoot;

		// Token: 0x0400920D RID: 37389
		[SerializeField]
		private GameObject singleRoot;

		// Token: 0x0400920E RID: 37390
		[SerializeField]
		private GameObject multiplePlictityRoot;

		// Token: 0x0400920F RID: 37391
		[Header("Button")]
		[SerializeField]
		private Button buyButton;

		// Token: 0x04009210 RID: 37392
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x04009211 RID: 37393
		[Space(10f)]
		[Header("CreditTicketFlag")]
		[Space(10f)]
		[SerializeField]
		private GameObject creditTicketFlag;
	}
}
