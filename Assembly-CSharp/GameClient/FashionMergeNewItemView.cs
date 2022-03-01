using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B33 RID: 6963
	public class FashionMergeNewItemView : MonoBehaviour
	{
		// Token: 0x06011186 RID: 70022 RVA: 0x004E728C File Offset: 0x004E568C
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06011187 RID: 70023 RVA: 0x004E7294 File Offset: 0x004E5694
		private void BindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.jumpButton != null)
			{
				this.jumpButton.onClick.RemoveAllListeners();
				this.jumpButton.onClick.AddListener(new UnityAction(this.OnJumpToFashionMall));
			}
			if (this.fashionItemList != null)
			{
				this.fashionItemList.Initialize();
				ComUIListScript comUIListScript = this.fashionItemList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItem));
				ComUIListScript comUIListScript2 = this.fashionItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript3 = this.fashionItemList;
				comUIListScript3.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript3.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplay));
				ComUIListScript comUIListScript4 = this.fashionItemList;
				comUIListScript4.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript4.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
			}
		}

		// Token: 0x06011188 RID: 70024 RVA: 0x004E73D3 File Offset: 0x004E57D3
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06011189 RID: 70025 RVA: 0x004E73DC File Offset: 0x004E57DC
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.SafeRemoveAllListener();
			}
			if (this.jumpButton != null)
			{
				this.jumpButton.onClick.RemoveAllListeners();
				this.jumpButton = null;
			}
			if (this.fashionItemList != null)
			{
				ComUIListScript comUIListScript = this.fashionItemList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItem));
				ComUIListScript comUIListScript2 = this.fashionItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript3 = this.fashionItemList;
				comUIListScript3.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript3.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplay));
				ComUIListScript comUIListScript4 = this.fashionItemList;
				comUIListScript4.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript4.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
			}
			this.buyItemMoneyCount = null;
			if (this.buyItemButton != null)
			{
				this.buyItemButton.onClick.RemoveAllListeners();
				this.buyItemButton = null;
			}
		}

		// Token: 0x0601118A RID: 70026 RVA: 0x004E7509 File Offset: 0x004E5909
		private object OnBindItem(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<ComFashionMergeItemEx>();
		}

		// Token: 0x0601118B RID: 70027 RVA: 0x004E7520 File Offset: 0x004E5920
		private void OnItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComFashionMergeItemEx comFashionMergeItemEx = item.gameObjectBindScript as ComFashionMergeItemEx;
			if (comFashionMergeItemEx == null)
			{
				return;
			}
			if (this._fashionItemDataList != null && item.m_index >= 0 && item.m_index < this._fashionItemDataList.Count)
			{
				comFashionMergeItemEx.OnItemVisible(this._fashionItemDataList[item.m_index]);
			}
		}

		// Token: 0x0601118C RID: 70028 RVA: 0x004E7598 File Offset: 0x004E5998
		private void OnItemChangeDisplay(ComUIListElementScript item, bool bSelected)
		{
			if (item == null)
			{
				return;
			}
			ComFashionMergeItemEx comFashionMergeItemEx = item.gameObjectBindScript as ComFashionMergeItemEx;
			if (comFashionMergeItemEx == null)
			{
				return;
			}
			comFashionMergeItemEx.OnItemChangeDisplay(bSelected);
		}

		// Token: 0x0601118D RID: 70029 RVA: 0x004E75D4 File Offset: 0x004E59D4
		private void OnItemSelected(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComFashionMergeItemEx comFashionMergeItemEx = item.gameObjectBindScript as ComFashionMergeItemEx;
			if (comFashionMergeItemEx == null)
			{
				return;
			}
			if (comFashionMergeItemEx.ItemData == null)
			{
				return;
			}
			if (comFashionMergeItemEx.ItemData.bFashionItemLocked)
			{
				if (this.fashionItemList != null)
				{
					this.fashionItemList.SelectElement(-1, true);
				}
				SystemNotifyManager.SystemNotify(1000107, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionNormalItemSelected, comFashionMergeItemEx, null, null, null);
			this.OnCloseFrame();
		}

		// Token: 0x0601118E RID: 70030 RVA: 0x004E766A File Offset: 0x004E5A6A
		public void InitData(ItemTable.eSubType fashionPart, bool isLeft, bool needBlueFashion)
		{
			this._fashionPart = fashionPart;
			this._isLeft = isLeft;
			this._needBlue = needBlueFashion;
			this.InitTitle();
			this.InitItemList();
		}

		// Token: 0x0601118F RID: 70031 RVA: 0x004E7690 File Offset: 0x004E5A90
		private void InitTitle()
		{
			if (this.description != null)
			{
				this.description.text = TR.Value("fashion_merge_new_item_description");
			}
			switch (this._fashionPart)
			{
			case ItemTable.eSubType.FASHION_HAIR:
				this.title.text = TR.Value("fashion_merge_new_item_hair");
				break;
			case ItemTable.eSubType.FASHION_HEAD:
				this.title.text = TR.Value("fashion_merge_new_item_head");
				break;
			case ItemTable.eSubType.FASHION_SASH:
				this.title.text = TR.Value("fashion_merge_new_item_sash");
				break;
			case ItemTable.eSubType.FASHION_CHEST:
				this.title.text = TR.Value("fashion_merge_new_item_chest");
				break;
			case ItemTable.eSubType.FASHION_LEG:
				this.title.text = TR.Value("fashion_merge_new_item_leg");
				break;
			case ItemTable.eSubType.FASHION_EPAULET:
				this.title.text = TR.Value("fashion_merge_new_item_epaulet");
				break;
			}
		}

		// Token: 0x06011190 RID: 70032 RVA: 0x004E778C File Offset: 0x004E5B8C
		private void InitItemList()
		{
			if (this._fashionItemDataList == null)
			{
				this._fashionItemDataList = new List<ItemData>();
			}
			this._fashionItemDataList.Clear();
			ComFashionMergeItemEx.LoadAllEquipments(ref this._fashionItemDataList, this._fashionPart, this._isLeft, this._needBlue);
			this.fashionItemList.SetElementAmount(this._fashionItemDataList.Count);
			if (this._fashionItemDataList != null && this._fashionItemDataList.Count > 0)
			{
				this.linkItem.CustomActive(false);
				this.fastBuyItem.CustomActive(false);
			}
			else
			{
				this.linkItem.CustomActive(true);
				this.InitFastBuyItem();
			}
		}

		// Token: 0x06011191 RID: 70033 RVA: 0x004E7838 File Offset: 0x004E5C38
		private void InitFastBuyItem()
		{
			this.fastBuyItem.CustomActive(true);
			this.buyItemButton.onClick.RemoveAllListeners();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			MallItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>(tableItem.FashionMergeFastBuyID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			int fastBuyItemId = this.GetFastBuyItemId(tableItem2);
			ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(fastBuyItemId, string.Empty, string.Empty);
			if (tableItem3 == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem3.ID, 100, 0);
			if (itemData != null)
			{
				ComItem comItem = this.buyItemRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = ComItemManager.Create(this.buyItemRoot);
				}
				comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowTips));
			}
			this.buyItemName.text = tableItem3.Name;
			WorldGetMallItemByItemIdReq cmd = new WorldGetMallItemByItemIdReq
			{
				itemId = (uint)fastBuyItemId
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldGetMallItemByItemIdReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldGetMallItemByItemIdRes>(new Action<WorldGetMallItemByItemIdRes>(this.OnWorldGetMallItemByItemIdRes), false, 15f, null);
		}

		// Token: 0x06011192 RID: 70034 RVA: 0x004E7978 File Offset: 0x004E5D78
		private void OnWorldGetMallItemByItemIdRes(WorldGetMallItemByItemIdRes msgRet)
		{
			if (msgRet == null)
			{
				return;
			}
			this._mallItemInfo = msgRet.mallItem;
			if (this._mallItemInfo == null)
			{
				return;
			}
			if (this.buyItemMoneyCount != null)
			{
				this.buyItemMoneyCount.text = this._mallItemInfo.discountprice.ToString();
			}
			if (this.buyItemButton != null)
			{
				this.buyItemButton.onClick.RemoveAllListeners();
				this.buyItemButton.onClick.AddListener(new UnityAction(this.OnFastBuyItemClick));
			}
			if (this.mIntergralMallInfoRoot != null)
			{
				this.mIntergralMallInfoRoot.CustomActive(this._mallItemInfo.multiple > 0);
			}
			if (this.mIntergralInfoText != null)
			{
				int num = MallNewUtility.GetTicketConvertIntergalNumnber((int)this._mallItemInfo.discountprice) * (int)this._mallItemInfo.multiple;
				string text = string.Empty;
				if (this._mallItemInfo.multiple <= 1)
				{
					text = TR.Value("mall_buy_intergral_single_multiple_desc", num);
				}
				else
				{
					text = TR.Value("mall_buy_intergral_many_multiple_desc", num, this._mallItemInfo.multiple);
				}
				this.mIntergralInfoText.text = text;
			}
		}

		// Token: 0x06011193 RID: 70035 RVA: 0x004E7AC8 File Offset: 0x004E5EC8
		private void OnFastBuyItemClick()
		{
			FashionMergeNewItemView.<OnFastBuyItemClick>c__AnonStorey0 <OnFastBuyItemClick>c__AnonStorey = new FashionMergeNewItemView.<OnFastBuyItemClick>c__AnonStorey0();
			<OnFastBuyItemClick>c__AnonStorey.$this = this;
			<OnFastBuyItemClick>c__AnonStorey.costInfo = new CostItemManager.CostInfo();
			if (this._mallItemInfo.moneytype == 28)
			{
				<OnFastBuyItemClick>c__AnonStorey.costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
			}
			else
			{
				<OnFastBuyItemClick>c__AnonStorey.costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			}
			<OnFastBuyItemClick>c__AnonStorey.costInfo.nCount = Utility.GetMallRealPrice(this._mallItemInfo);
			<OnFastBuyItemClick>c__AnonStorey.costInfo.IsCreditPointDeduction = MallNewUtility.IsMallItemCanCreditPointDeduction(this._mallItemInfo);
			string text = string.Format(TR.Value("fashion_merge_new_buy_item"), <OnFastBuyItemClick>c__AnonStorey.costInfo.nCount);
			if (this._mallItemInfo.multiple > 0)
			{
				int num = MallNewUtility.GetTicketConvertIntergalNumnber(<OnFastBuyItemClick>c__AnonStorey.costInfo.nCount) * (int)this._mallItemInfo.multiple;
				string str = string.Empty;
				if (this._mallItemInfo.multiple <= 1)
				{
					str = TR.Value("mall_fast_buy_intergral_single_multiple_desc", num);
				}
				else
				{
					str = TR.Value("mall_fast_buy_intergral_many_multiple_desc", num, this._mallItemInfo.multiple, string.Empty);
				}
				text += str;
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(text, delegate()
			{
				uint reqId = <OnFastBuyItemClick>c__AnonStorey.$this._mallItemInfo.id;
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(<OnFastBuyItemClick>c__AnonStorey.costInfo, delegate
				{
					if (<OnFastBuyItemClick>c__AnonStorey._mallItemInfo.multiple > 0)
					{
						string text2 = string.Empty;
						if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
						{
							text2 = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
							string content = text2;
							if (FashionMergeNewItemView.<>f__mg$cache0 == null)
							{
								FashionMergeNewItemView.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content, FashionMergeNewItemView.<>f__mg$cache0, delegate
							{
								<OnFastBuyItemClick>c__AnonStorey.OnSendWorldMallBuy(reqId);
							});
						}
						else
						{
							int num2 = MallNewUtility.GetTicketConvertIntergalNumnber(<OnFastBuyItemClick>c__AnonStorey.costInfo.nCount) * (int)<OnFastBuyItemClick>c__AnonStorey._mallItemInfo.multiple;
							int num3 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num2;
							if (num3 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
							{
								text2 = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
								string content2 = text2;
								if (FashionMergeNewItemView.<>f__mg$cache1 == null)
								{
									FashionMergeNewItemView.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
								}
								MallNewUtility.CommonIntergralMallPopupWindow(content2, FashionMergeNewItemView.<>f__mg$cache1, delegate
								{
									<OnFastBuyItemClick>c__AnonStorey.OnSendWorldMallBuy(reqId);
								});
							}
							else
							{
								<OnFastBuyItemClick>c__AnonStorey.OnSendWorldMallBuy(reqId);
							}
						}
					}
					else
					{
						<OnFastBuyItemClick>c__AnonStorey.OnSendWorldMallBuy(reqId);
					}
				}, "common_money_cost", null);
			}, null, 0f, false);
		}

		// Token: 0x06011194 RID: 70036 RVA: 0x004E7C20 File Offset: 0x004E6020
		private void OnSendWorldMallBuy(uint reqId)
		{
			WorldMallBuy cmd = new WorldMallBuy
			{
				itemId = reqId,
				num = 1
			};
			NetManager.Instance().SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMallBuyRet>(delegate(WorldMallBuyRet ret)
			{
				if (ret.mallitemid == reqId)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionFastItemBuyFinished, null, null, null, null);
					this.OnCloseFrame();
				}
			}, false, 15f, null);
		}

		// Token: 0x06011195 RID: 70037 RVA: 0x004E7C88 File Offset: 0x004E6088
		private int GetFastBuyItemId(MallItemTable mallItemTableData)
		{
			string s = "-1";
			int result = -1;
			try
			{
				switch (this._fashionPart)
				{
				case ItemTable.eSubType.FASHION_HEAD:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[0].Split(new char[]
					{
						':'
					})[0];
					break;
				case ItemTable.eSubType.FASHION_SASH:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[4].Split(new char[]
					{
						':'
					})[0];
					break;
				case ItemTable.eSubType.FASHION_CHEST:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[1].Split(new char[]
					{
						':'
					})[0];
					break;
				case ItemTable.eSubType.FASHION_LEG:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[3].Split(new char[]
					{
						':'
					})[0];
					break;
				case ItemTable.eSubType.FASHION_EPAULET:
					s = mallItemTableData.giftpackitems.Split(new char[]
					{
						'|'
					})[2].Split(new char[]
					{
						':'
					})[0];
					break;
				}
				int.TryParse(s, out result);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("{0}", new object[]
				{
					ex.ToString()
				});
				return -1;
			}
			return result;
		}

		// Token: 0x06011196 RID: 70038 RVA: 0x004E7E08 File Offset: 0x004E6208
		private void OnJumpToFashionMall()
		{
			string fashionMallLink = this.GetFashionMallLink();
			DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(fashionMallLink, null, false);
			this.OnCloseFrame();
		}

		// Token: 0x06011197 RID: 70039 RVA: 0x004E7E30 File Offset: 0x004E6230
		private string GetFashionMallLink()
		{
			string result = string.Empty;
			int slotIdBySubType = this.GetSlotIdBySubType(DataManager<FashionMergeManager>.GetInstance().FashionPart);
			if (slotIdBySubType >= 0 && slotIdBySubType < 5)
			{
				result = string.Format("<type=framename param=2|0|1|{0} value=GameClient.MallNewFrame>", slotIdBySubType);
			}
			return result;
		}

		// Token: 0x06011198 RID: 70040 RVA: 0x004E7E74 File Offset: 0x004E6274
		private int GetSlotIdBySubType(ItemTable.eSubType eSubType)
		{
			int result = -1;
			switch (eSubType)
			{
			case ItemTable.eSubType.FASHION_HAIR:
				result = 5;
				break;
			case ItemTable.eSubType.FASHION_HEAD:
				result = 0;
				break;
			case ItemTable.eSubType.FASHION_SASH:
				result = 4;
				break;
			case ItemTable.eSubType.FASHION_CHEST:
				result = 1;
				break;
			case ItemTable.eSubType.FASHION_LEG:
				result = 3;
				break;
			case ItemTable.eSubType.FASHION_EPAULET:
				result = 2;
				break;
			}
			return result;
		}

		// Token: 0x06011199 RID: 70041 RVA: 0x004E7ED4 File Offset: 0x004E62D4
		private void OnShowTips(GameObject go, ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0601119A RID: 70042 RVA: 0x004E7EED File Offset: 0x004E62ED
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionMergeNewItemFrame>(null, false);
		}

		// Token: 0x0400B02D RID: 45101
		[SerializeField]
		private Text title;

		// Token: 0x0400B02E RID: 45102
		[SerializeField]
		private Text description;

		// Token: 0x0400B02F RID: 45103
		[Space(10f)]
		[Header("LinkItem")]
		[SerializeField]
		private GameObject linkItem;

		// Token: 0x0400B030 RID: 45104
		[SerializeField]
		private Button jumpButton;

		// Token: 0x0400B031 RID: 45105
		[Space(10f)]
		[Header("FastBuyItem")]
		[SerializeField]
		private GameObject fastBuyItem;

		// Token: 0x0400B032 RID: 45106
		[SerializeField]
		private Text buyItemMoneyCount;

		// Token: 0x0400B033 RID: 45107
		[SerializeField]
		private Button buyItemButton;

		// Token: 0x0400B034 RID: 45108
		[SerializeField]
		private Text buyItemName;

		// Token: 0x0400B035 RID: 45109
		[SerializeField]
		private GameObject buyItemRoot;

		// Token: 0x0400B036 RID: 45110
		[SerializeField]
		private GameObject mIntergralMallInfoRoot;

		// Token: 0x0400B037 RID: 45111
		[SerializeField]
		private Text mIntergralInfoText;

		// Token: 0x0400B038 RID: 45112
		[Space(10f)]
		[Header("NormalItemList")]
		[SerializeField]
		private ComUIListScript fashionItemList;

		// Token: 0x0400B039 RID: 45113
		[Space(5f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B03A RID: 45114
		private ItemTable.eSubType _fashionPart;

		// Token: 0x0400B03B RID: 45115
		private bool _isLeft;

		// Token: 0x0400B03C RID: 45116
		private bool _needBlue;

		// Token: 0x0400B03D RID: 45117
		private List<ItemData> _fashionItemDataList;

		// Token: 0x0400B03E RID: 45118
		private MallItemInfo _mallItemInfo;

		// Token: 0x0400B03F RID: 45119
		private const string FashionLink = "<type=framename param=2|0|1|{0} value=GameClient.MallNewFrame>";

		// Token: 0x0400B040 RID: 45120
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x0400B041 RID: 45121
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}
