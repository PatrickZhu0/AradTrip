using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001470 RID: 5232
	public class AuctionNewBuyNoticeDetailItem : MonoBehaviour
	{
		// Token: 0x0600CAE5 RID: 51941 RVA: 0x0031B389 File Offset: 0x00319789
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CAE6 RID: 51942 RVA: 0x0031B391 File Offset: 0x00319791
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CAE7 RID: 51943 RVA: 0x0031B39F File Offset: 0x0031979F
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewReceiveNoticeReqSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveNoticeReqSucceed));
		}

		// Token: 0x0600CAE8 RID: 51944 RVA: 0x0031B3BC File Offset: 0x003197BC
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewReceiveNoticeReqSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveNoticeReqSucceed));
		}

		// Token: 0x0600CAE9 RID: 51945 RVA: 0x0031B3DC File Offset: 0x003197DC
		private void BindEvents()
		{
			if (this.itemBuyButton != null)
			{
				this.itemBuyButton.onClick.RemoveAllListeners();
				this.itemBuyButton.onClick.AddListener(new UnityAction(this.OnDetailItemBuyButtonClick));
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
				this.chatButton.onClick.AddListener(new UnityAction(this.OnChatButtonClick));
			}
			if (this.noticeButtonWithCd != null)
			{
				this.noticeButtonWithCd.SetButtonListener(new Action(this.OnNoticeButtonClick));
			}
		}

		// Token: 0x0600CAEA RID: 51946 RVA: 0x0031B48C File Offset: 0x0031988C
		private void UnBindEvents()
		{
			if (this.itemBuyButton != null)
			{
				this.itemBuyButton.onClick.RemoveAllListeners();
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
			}
			if (this.noticeButtonWithCd != null)
			{
				this.noticeButtonWithCd.ResetButtonListener();
			}
		}

		// Token: 0x0600CAEB RID: 51947 RVA: 0x0031B4F7 File Offset: 0x003198F7
		private void ResetData()
		{
			this._auctionBaseInfo = null;
			this._mainTabType = AuctionNewMainTabType.None;
			this._isTreasure = false;
			this._isOwnerNotice = false;
			this._itemNoticeCount = 0;
		}

		// Token: 0x0600CAEC RID: 51948 RVA: 0x0031B51C File Offset: 0x0031991C
		public void InitItem(AuctionNewMainTabType mainTabType, AuctionBaseInfo auctionBaseInfo)
		{
			this._baseIntervalTime = 0f;
			this._mainTabType = mainTabType;
			this._auctionBaseInfo = auctionBaseInfo;
			if (this._auctionBaseInfo == null)
			{
				Logger.LogError("BuyNoticeDetail InitItem auctionBaseInfo is null");
				return;
			}
			this._isTreasure = (this._auctionBaseInfo.isTreas == 1);
			this.InitItemView();
		}

		// Token: 0x0600CAED RID: 51949 RVA: 0x0031B57C File Offset: 0x0031997C
		private void InitItemView()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this._auctionBaseInfo.itemTypeId, 100, 0);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._auctionBaseInfo.itemTypeId, string.Empty, string.Empty);
			if (itemData == null || tableItem == null)
			{
				Logger.LogErrorFormat("ItemData or ItemTable is null and itemTypeid is {0}", new object[]
				{
					this._auctionBaseInfo.itemTypeId
				});
				return;
			}
			itemData.Count = (int)this._auctionBaseInfo.num;
			itemData.StrengthenLevel = (int)this._auctionBaseInfo.strengthed;
			AuctionNewUtility.UpdateItemDataByEquipType(itemData, this._auctionBaseInfo);
			if (this.itemName != null)
			{
				this.itemName.text = AuctionNewUtility.GetQualityColorString(itemData.Name, tableItem.Color);
			}
			if (this.itemRoot != null)
			{
				this._detailComItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (this._detailComItem == null)
				{
					this._detailComItem = ComItemManager.Create(this.itemRoot);
				}
				if (this._detailComItem != null)
				{
					this._detailComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowDetailItemTip));
					this._detailComItem.SetShowTreasure(this._isTreasure);
				}
			}
			if (this.itemScore != null)
			{
				if (this._auctionBaseInfo.itemScore <= 0U)
				{
					this.itemScore.gameObject.CustomActive(false);
				}
				else
				{
					this.itemScore.gameObject.CustomActive(true);
					this.itemScore.text = string.Format(TR.Value("auction_new_itemDetail_score_value"), this._auctionBaseInfo.itemScore);
				}
			}
			this.InitItemTime();
			if (this.itemPriceLabel != null)
			{
				this.itemPriceLabel.text = TR.Value("auction_new_sell_item_single_price");
			}
			if (this.itemPriceValue != null)
			{
				ulong num = (ulong)this._auctionBaseInfo.price;
				if (this._auctionBaseInfo.num > 0U)
				{
					num = (ulong)this._auctionBaseInfo.price / (ulong)this._auctionBaseInfo.num;
				}
				this.itemPriceValue.text = Utility.GetShowPrice(num, false);
				this.itemPriceValue.text = Utility.ToThousandsSeparator(num);
			}
			if (this.itemCountTime != null)
			{
				if (this._mainTabType != AuctionNewMainTabType.AuctionNoticeType)
				{
					this.itemCountTime.gameObject.CustomActive(false);
				}
				else
				{
					this.itemCountTime.gameObject.CustomActive(true);
					this.itemCountTime.text = CountDownTimeUtility.GetCountDownTimeByHourMinute(this._auctionBaseInfo.publicEndTime, DataManager<TimeManager>.GetInstance().GetServerTime());
					if (this.countDownTimeController != null)
					{
						this.countDownTimeController.EndTime = this._auctionBaseInfo.publicEndTime;
						this.countDownTimeController.InitCountDownTimeController();
					}
				}
			}
			this.InitItemTreasureInfo();
		}

		// Token: 0x0600CAEE RID: 51950 RVA: 0x0031B874 File Offset: 0x00319C74
		private void InitItemTime()
		{
			CommonUtility.UpdateGameObjectVisible(this.itemTimeRoot, false);
			if (!AuctionNewUtility.IsItemOwnerTimeValid((int)this._auctionBaseInfo.itemTypeId))
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.itemTimeRoot, true);
			bool flag = AuctionNewUtility.IsItemInValidTimeInterval(this._auctionBaseInfo.itemDueTime);
			if (flag)
			{
				CommonUtility.UpdateTextVisible(this.itemTimeInvalidText, false);
				CommonUtility.UpdateTextVisible(this.itemLeftTimeText, true);
				if (this.itemLeftTimeText != null)
				{
					string timeValidItemLeftTimeStr = AuctionNewUtility.GetTimeValidItemLeftTimeStr(this._auctionBaseInfo.itemDueTime);
					this.itemLeftTimeText.text = timeValidItemLeftTimeStr;
				}
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.itemLeftTimeText, false);
				CommonUtility.UpdateTextVisible(this.itemTimeInvalidText, true);
			}
		}

		// Token: 0x0600CAEF RID: 51951 RVA: 0x0031B92B File Offset: 0x00319D2B
		private void InitItemTreasureInfo()
		{
			if (!this._isTreasure)
			{
				this.UpdateTreasureRelationButton(false);
				return;
			}
			this.UpdateTreasureRelationButton(true);
			this.UpdateNoticeState();
			if (this.noticeButtonWithCd != null)
			{
				this.noticeButtonWithCd.Reset();
			}
		}

		// Token: 0x0600CAF0 RID: 51952 RVA: 0x0031B969 File Offset: 0x00319D69
		public void OnItemRecycle()
		{
			this.ResetData();
			if (this._mainTabType == AuctionNewMainTabType.AuctionNoticeType && this.countDownTimeController != null)
			{
				this.countDownTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x0600CAF1 RID: 51953 RVA: 0x0031B99C File Offset: 0x00319D9C
		private void OnDetailItemBuyButtonClick()
		{
			if (this._auctionBaseInfo == null)
			{
				return;
			}
			if (this._mainTabType == AuctionNewMainTabType.AuctionNoticeType)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_onSale_notice_can_not_buy"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._auctionBaseInfo.itemTypeId, string.Empty, string.Empty) == null)
			{
				Logger.LogErrorFormat("BuyNoticeDetailItem itemData is null and itemTypeId is {0}", new object[]
				{
					this._auctionBaseInfo.itemTypeId
				});
				return;
			}
			AuctionNewUtility.OnOpenAuctionNewBuyItemFrame(this._auctionBaseInfo);
		}

		// Token: 0x0600CAF2 RID: 51954 RVA: 0x0031BA28 File Offset: 0x00319E28
		private void OnShowDetailItemTip(GameObject obj, ItemData itemData)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, this._auctionBaseInfo.guid);
		}

		// Token: 0x0600CAF3 RID: 51955 RVA: 0x0031BA40 File Offset: 0x00319E40
		private void UpdateTreasureRelationButton(bool flag)
		{
			if (this.chatButton != null)
			{
				this.chatButton.gameObject.CustomActive(flag);
			}
			if (this.noticeButtonRoot != null)
			{
				this.noticeButtonRoot.CustomActive(flag);
			}
		}

		// Token: 0x0600CAF4 RID: 51956 RVA: 0x0031BA8C File Offset: 0x00319E8C
		private void OnChatButtonClick()
		{
			if (this._auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("AuctionBaseInfo is null", new object[0]);
				return;
			}
			AuctionNewUtility.ChatWithOnShelfItemOwner(this._auctionBaseInfo.owner);
		}

		// Token: 0x0600CAF5 RID: 51957 RVA: 0x0031BABA File Offset: 0x00319EBA
		private void OnNoticeButtonClick()
		{
			if (this._auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("The AuctionBaseInfo is null", new object[0]);
				return;
			}
			DataManager<AuctionNewDataManager>.GetInstance().OnSendWorldActionNoticeReq(this._auctionBaseInfo.guid);
		}

		// Token: 0x0600CAF6 RID: 51958 RVA: 0x0031BAF0 File Offset: 0x00319EF0
		private void OnReceiveNoticeReqSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (this._auctionBaseInfo == null || this._auctionBaseInfo.guid != num)
			{
				return;
			}
			this.ShowNoticeResultEffect();
			this.UpdateNoticeState();
		}

		// Token: 0x0600CAF7 RID: 51959 RVA: 0x0031BB39 File Offset: 0x00319F39
		private void ShowNoticeResultEffect()
		{
			if (this._auctionBaseInfo.attent == 1)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_notice_succeed"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_notice_cancel"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600CAF8 RID: 51960 RVA: 0x0031BB74 File Offset: 0x00319F74
		private void UpdateNoticeState()
		{
			if (this._auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("AuctionBaseInfo is null", new object[0]);
				return;
			}
			bool flag = this._auctionBaseInfo.attent != 0;
			this.UpdateNoticeFlag(flag);
			if (this.noticeNumber != null)
			{
				this.noticeNumber.text = this._auctionBaseInfo.attentNum.ToString();
			}
		}

		// Token: 0x0600CAF9 RID: 51961 RVA: 0x0031BBE8 File Offset: 0x00319FE8
		private void UpdateNoticeFlag(bool flag)
		{
			if (this.ownerNoticeImage != null)
			{
				this.ownerNoticeImage.gameObject.CustomActive(flag);
			}
			if (this.ownerNotNoticeImage != null)
			{
				this.ownerNotNoticeImage.gameObject.CustomActive(!flag);
			}
		}

		// Token: 0x040075D9 RID: 30169
		private AuctionBaseInfo _auctionBaseInfo;

		// Token: 0x040075DA RID: 30170
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x040075DB RID: 30171
		private ComItem _detailComItem;

		// Token: 0x040075DC RID: 30172
		private float _baseIntervalTime;

		// Token: 0x040075DD RID: 30173
		private bool _isTreasure;

		// Token: 0x040075DE RID: 30174
		private int _itemNoticeCount;

		// Token: 0x040075DF RID: 30175
		private bool _isOwnerNotice;

		// Token: 0x040075E0 RID: 30176
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x040075E1 RID: 30177
		[SerializeField]
		private Text itemName;

		// Token: 0x040075E2 RID: 30178
		[SerializeField]
		private Text itemScore;

		// Token: 0x040075E3 RID: 30179
		[SerializeField]
		private Text itemPriceLabel;

		// Token: 0x040075E4 RID: 30180
		[SerializeField]
		private Image itemCostImage;

		// Token: 0x040075E5 RID: 30181
		[SerializeField]
		private Text itemPriceValue;

		// Token: 0x040075E6 RID: 30182
		[SerializeField]
		private Text itemCountTime;

		// Token: 0x040075E7 RID: 30183
		[SerializeField]
		private CountDownTimeController countDownTimeController;

		// Token: 0x040075E8 RID: 30184
		[Space(10f)]
		[Header("ItemTime")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemTimeRoot;

		// Token: 0x040075E9 RID: 30185
		[SerializeField]
		private Text itemLeftTimeText;

		// Token: 0x040075EA RID: 30186
		[SerializeField]
		private Text itemTimeInvalidText;

		// Token: 0x040075EB RID: 30187
		[Space(10f)]
		[Header("Chat")]
		[Space(10f)]
		[SerializeField]
		private Button chatButton;

		// Token: 0x040075EC RID: 30188
		[Space(10f)]
		[Header("Notice")]
		[Space(10f)]
		[SerializeField]
		private GameObject noticeButtonRoot;

		// Token: 0x040075ED RID: 30189
		[SerializeField]
		private ComButtonWithCd noticeButtonWithCd;

		// Token: 0x040075EE RID: 30190
		[SerializeField]
		private Image ownerNoticeImage;

		// Token: 0x040075EF RID: 30191
		[SerializeField]
		private Image ownerNotNoticeImage;

		// Token: 0x040075F0 RID: 30192
		[SerializeField]
		private Text noticeNumber;

		// Token: 0x040075F1 RID: 30193
		[Space(10f)]
		[Header("treasureInfo")]
		[SerializeField]
		private Button itemBuyButton;
	}
}
