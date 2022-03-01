using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001497 RID: 5271
	public class AuctionNewSellView : AuctionNewContentBaseView
	{
		// Token: 0x0600CC51 RID: 52305 RVA: 0x00322214 File Offset: 0x00320614
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC52 RID: 52306 RVA: 0x0032221C File Offset: 0x0032061C
		private void OnDestroy()
		{
			this.UnBindEvents();
		}

		// Token: 0x0600CC53 RID: 52307 RVA: 0x00322224 File Offset: 0x00320624
		private void BindEvents()
		{
			if (this.sellRecordButton != null)
			{
				this.sellRecordButton.onClick.RemoveAllListeners();
				this.sellRecordButton.onClick.AddListener(new UnityAction(this.OnSellRecordButtonClick));
			}
			if (this.sellTitleTabItemList != null)
			{
				this.sellTitleTabItemList.Initialize();
				ComUIListScript comUIListScript = this.sellTitleTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellTitleTabVisible));
			}
			if (this.forSellItemList != null)
			{
				this.forSellItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.forSellItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnForSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.forSellItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnForSellItemRecycle));
			}
			if (this.onShelfItemList != null)
			{
				this.onShelfItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx3 = this.onShelfItemList;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnShelfItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.onShelfItemList;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnShelfItemRecycle));
			}
		}

		// Token: 0x0600CC54 RID: 52308 RVA: 0x00322388 File Offset: 0x00320788
		private void UnBindEvents()
		{
			if (this.sellRecordButton != null)
			{
				this.sellRecordButton.onClick.RemoveAllListeners();
			}
			if (this.sellTitleTabItemList != null)
			{
				ComUIListScript comUIListScript = this.sellTitleTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellTitleTabVisible));
			}
			if (this.forSellItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.forSellItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnForSellItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.forSellItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnForSellItemRecycle));
			}
			if (this.onShelfItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx3 = this.onShelfItemList;
				comUIListScriptEx3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnShelfItemVisible));
				ComUIListScriptEx comUIListScriptEx4 = this.onShelfItemList;
				comUIListScriptEx4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnShelfItemRecycle));
			}
		}

		// Token: 0x0600CC55 RID: 52309 RVA: 0x003224AC File Offset: 0x003208AC
		private void ResetData()
		{
			this._auctionNewUserData = null;
			this._auctionNewUserItemData = null;
		}

		// Token: 0x0600CC56 RID: 52310 RVA: 0x003224BC File Offset: 0x003208BC
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewReceiveSelfListResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSelfListSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewBuyShelfResSucceed, new ClientEventSystem.UIEventHandler(this.OnBuyShelfSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnItemInPackageAddedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageAddedMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnItemInPackageRemovedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageRemovedMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemPropertyChanged, new ClientEventSystem.UIEventHandler(this.OnItemPropertyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnItemEquipInscriptionSucceed, new ClientEventSystem.UIEventHandler(this.OnItemEquipInscriptionSucceed));
		}

		// Token: 0x0600CC57 RID: 52311 RVA: 0x0032256C File Offset: 0x0032096C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewReceiveSelfListResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSelfListSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewBuyShelfResSucceed, new ClientEventSystem.UIEventHandler(this.OnBuyShelfSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnItemInPackageAddedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageAddedMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnItemInPackageRemovedMessage, new ClientEventSystem.UIEventHandler(this.OnItemInPackageRemovedMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemPropertyChanged, new ClientEventSystem.UIEventHandler(this.OnItemPropertyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnItemEquipInscriptionSucceed, new ClientEventSystem.UIEventHandler(this.OnItemEquipInscriptionSucceed));
			this.ResetData();
		}

		// Token: 0x0600CC58 RID: 52312 RVA: 0x00322621 File Offset: 0x00320A21
		public override void InitView(AuctionNewMainTabType mainTabType, AuctionNewUserData auctionNewUserData = null)
		{
			this._mainTabType = mainTabType;
			this._auctionNewUserData = auctionNewUserData;
			this.InitSellBaseView();
			DataManager<AuctionNewDataManager>.GetInstance().SendSelfAuctionListRequest();
		}

		// Token: 0x0600CC59 RID: 52313 RVA: 0x00322644 File Offset: 0x00320A44
		private void InitTabDataModelList()
		{
			if (this._sellTabDataModelList == null)
			{
				this._sellTabDataModelList = new List<AuctionNewSellTabDataModel>();
			}
			this._sellTabDataModelList.Clear();
			AuctionNewSellTabDataModel auctionNewSellTabDataModel = new AuctionNewSellTabDataModel();
			auctionNewSellTabDataModel.index = 1;
			auctionNewSellTabDataModel.sellTabType = ActionNewSellTabType.AuctionNewSellEquipType;
			auctionNewSellTabDataModel.sellTabName = "auction_new_sell_equip_type";
			AuctionNewSellTabDataModel auctionNewSellTabDataModel2 = new AuctionNewSellTabDataModel();
			auctionNewSellTabDataModel2.index = 2;
			auctionNewSellTabDataModel2.sellTabType = ActionNewSellTabType.AuctionNewSellMaterialType;
			auctionNewSellTabDataModel2.sellTabName = "auction_new_sell_cost_material";
			this._sellTabDataModelList.Add(auctionNewSellTabDataModel);
			this._sellTabDataModelList.Add(auctionNewSellTabDataModel2);
		}

		// Token: 0x0600CC5A RID: 52314 RVA: 0x003226C8 File Offset: 0x00320AC8
		private void InitSellBaseView()
		{
			this.InitTabDataModelList();
			int count = this._sellTabDataModelList.Count;
			if (count <= 0)
			{
				return;
			}
			this.SetDefaultSellTabIndex();
			if (this.sellTitleTabItemList != null)
			{
				this.sellTitleTabItemList.SetElementAmount(count);
			}
			this._isShowSellRecordButton = true;
			if (!AuctionNewUtility.IsAuctionTreasureItemOpen())
			{
				this._isShowSellRecordButton = false;
			}
			this.sellRecordButton.gameObject.CustomActive(this._isShowSellRecordButton);
		}

		// Token: 0x0600CC5B RID: 52315 RVA: 0x00322740 File Offset: 0x00320B40
		private void SetDefaultSellTabIndex()
		{
			this._defaultSellTabIndex = 0;
			if (this._auctionNewUserData == null)
			{
				return;
			}
			this._auctionNewUserItemData = DataManager<ItemDataManager>.GetInstance().GetItem(this._auctionNewUserData.ItemLinkId);
			if (this._auctionNewUserItemData == null)
			{
				return;
			}
			ActionNewSellTabType actionNewSellTabType = ActionNewSellTabType.AuctionNewSellEquipType;
			if (!AuctionNewUtility.IsEquipItems(this._auctionNewUserItemData))
			{
				actionNewSellTabType = ActionNewSellTabType.AuctionNewSellMaterialType;
			}
			int count = this._sellTabDataModelList.Count;
			if (count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._sellTabDataModelList.Count; i++)
			{
				if (this._sellTabDataModelList[i] != null && this._sellTabDataModelList[i].sellTabType == actionNewSellTabType)
				{
					this._defaultSellTabIndex = i;
				}
			}
		}

		// Token: 0x0600CC5C RID: 52316 RVA: 0x003227FA File Offset: 0x00320BFA
		public override void OnEnableView(AuctionNewMainTabType mainTabType)
		{
			if (this.forSellItemList != null)
			{
				this.forSellItemList.ResetComUiListScriptEx();
			}
			this.UpdateForSaleItemList();
			DataManager<AuctionNewDataManager>.GetInstance().SendSelfAuctionListRequest();
		}

		// Token: 0x0600CC5D RID: 52317 RVA: 0x00322828 File Offset: 0x00320C28
		private void OnSellTitleTabVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewSellTitleTabItem component = item.GetComponent<AuctionNewSellTitleTabItem>();
			if (component == null)
			{
				return;
			}
			if (this._sellTabDataModelList != null && item.m_index >= 0 && item.m_index < this._sellTabDataModelList.Count)
			{
				AuctionNewSellTabDataModel auctionNewSellTabDataModel = this._sellTabDataModelList[item.m_index];
				bool isSelected = this._defaultSellTabIndex == item.m_index;
				if (auctionNewSellTabDataModel != null)
				{
					component.Init(auctionNewSellTabDataModel, new OnAuctionNewSellTabClick(this.OnTitleTabClick), isSelected);
				}
			}
		}

		// Token: 0x0600CC5E RID: 52318 RVA: 0x003228C0 File Offset: 0x00320CC0
		private void OnTitleTabClick(ActionNewSellTabType sellTabType)
		{
			if (sellTabType != ActionNewSellTabType.AuctionNewSellEquipType && sellTabType != ActionNewSellTabType.AuctionNewSellMaterialType)
			{
				Logger.LogErrorFormat("Error TabType and AuctionNewSellTabType is {0}", new object[]
				{
					sellTabType.ToString()
				});
				return;
			}
			if (this._sellTabType == sellTabType)
			{
				return;
			}
			this._sellTabType = sellTabType;
			if (this.forSellItemList != null)
			{
				this.forSellItemList.ResetComUiListScriptEx();
			}
			this.UpdateForSaleItemList();
		}

		// Token: 0x0600CC5F RID: 52319 RVA: 0x00322932 File Offset: 0x00320D32
		private void UpdateForSaleItemList()
		{
			this._packageForSellItemDataList = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionSellItemDataByType(this._sellTabType);
			if (this.forSellItemList != null)
			{
				this.forSellItemList.SetElementAmount(this._packageForSellItemDataList.Count);
			}
		}

		// Token: 0x0600CC60 RID: 52320 RVA: 0x00322974 File Offset: 0x00320D74
		private void OnForSellItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._packageForSellItemDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._packageForSellItemDataList.Count)
			{
				return;
			}
			AuctionSellItemData auctionSellItemData = this._packageForSellItemDataList[item.m_index];
			AuctionNewForSellElementItem component = item.GetComponent<AuctionNewForSellElementItem>();
			if (auctionSellItemData != null && component != null)
			{
				component.InitItem(auctionSellItemData);
			}
		}

		// Token: 0x0600CC61 RID: 52321 RVA: 0x003229F0 File Offset: 0x00320DF0
		private void OnForSellItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewForSellElementItem component = item.GetComponent<AuctionNewForSellElementItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CC62 RID: 52322 RVA: 0x00322A24 File Offset: 0x00320E24
		private void ShowAuctionSellFrame()
		{
			if (this._auctionNewUserData == null)
			{
				this._auctionNewUserItemData = null;
				return;
			}
			AuctionNewUtility.CloseAuctionNewOnShelfFrame();
			this._auctionNewUserItemData = DataManager<ItemDataManager>.GetInstance().GetItem(this._auctionNewUserData.ItemLinkId);
			if (this._auctionNewUserItemData == null)
			{
				this._auctionNewUserData = null;
				return;
			}
			if (this._auctionNewUserItemData.IsNeedPacking())
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("Auction_item_packing"), new UnityAction(this.ClickOkPacking), null, 0f, false);
			}
			else
			{
				AuctionNewUtility.OpenAuctionNewOnShelfFrame(this._auctionNewUserData.ItemLinkId, this._auctionNewUserItemData.IsTreasure, DataManager<AuctionNewDataManager>.GetInstance().BaseShelfNum + DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum, DataManager<AuctionNewDataManager>.GetInstance().OnShelfItemNumber);
				this._auctionNewUserItemData = null;
			}
			this._auctionNewUserData = null;
		}

		// Token: 0x0600CC63 RID: 52323 RVA: 0x00322AF6 File Offset: 0x00320EF6
		private void ClickOkPacking()
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnClickOnPacking(this._auctionNewUserItemData);
			this._auctionNewUserItemData = null;
		}

		// Token: 0x0600CC64 RID: 52324 RVA: 0x00322B10 File Offset: 0x00320F10
		private void OnShelfItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._onSelfDataModelList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._onSelfDataModelList.Count)
			{
				return;
			}
			AuctionNewOnShelfElementItem component = item.GetComponent<AuctionNewOnShelfElementItem>();
			AuctionNewOnShelfDataModel auctionNewOnShelfDataModel = this._onSelfDataModelList[item.m_index];
			if (component != null && auctionNewOnShelfDataModel != null)
			{
				component.InitItem(auctionNewOnShelfDataModel);
			}
		}

		// Token: 0x0600CC65 RID: 52325 RVA: 0x00322B8C File Offset: 0x00320F8C
		private void OnShelfItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewOnShelfElementItem component = item.GetComponent<AuctionNewOnShelfElementItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CC66 RID: 52326 RVA: 0x00322BC0 File Offset: 0x00320FC0
		private void OnBuyShelfSucceed(UIEvent uiEvent)
		{
			this._onSelfDataModelList = DataManager<AuctionNewDataManager>.GetInstance().GetOnShelfDataModelList();
			if (this._onSelfDataModelList != null && this.onShelfItemList != null)
			{
				this.onShelfItemList.SetElementAmount(this._onSelfDataModelList.Count);
			}
			this.UpdateOnShelfTitle();
		}

		// Token: 0x0600CC67 RID: 52327 RVA: 0x00322C18 File Offset: 0x00321018
		private void OnReceiveSelfListSucceed(UIEvent uiEvent)
		{
			this._onSelfDataModelList = DataManager<AuctionNewDataManager>.GetInstance().GetOnShelfDataModelList();
			if (this._onSelfDataModelList != null && this.onShelfItemList != null)
			{
				this.onShelfItemList.SetElementAmount(this._onSelfDataModelList.Count);
			}
			this.UpdateOnShelfTitle();
			this.ShowAuctionSellFrame();
		}

		// Token: 0x0600CC68 RID: 52328 RVA: 0x00322C74 File Offset: 0x00321074
		private void OnItemEquipInscriptionSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong itemGuid = (ulong)uiEvent.Param1;
			if (!this.IsItemInForSaleItemList(itemGuid))
			{
				return;
			}
			this.UpdateForSaleItemList();
		}

		// Token: 0x0600CC69 RID: 52329 RVA: 0x00322CB4 File Offset: 0x003210B4
		private void OnItemPropertyChanged(UIEvent uiEvent)
		{
			ItemData itemData = (ItemData)uiEvent.Param1;
			EItemProperty eitemProperty = (EItemProperty)uiEvent.Param2;
			if (eitemProperty == EItemProperty.EP_SEAL_STATE || eitemProperty == EItemProperty.EP_IS_TREAS || eitemProperty == EItemProperty.EA_AUCTION_TRANS_NUM)
			{
				if (itemData == null)
				{
					return;
				}
				this.UpdateForSaleItemList();
			}
			if (eitemProperty == EItemProperty.EP_NUM)
			{
				if (itemData == null)
				{
					return;
				}
				if (!this.IsItemInForSaleItemList(itemData.GUID))
				{
					return;
				}
				this.UpdateForSaleItemList();
			}
			if (eitemProperty == EItemProperty.EP_PACK)
			{
				this.UpdateForSaleItemList();
			}
		}

		// Token: 0x0600CC6A RID: 52330 RVA: 0x00322D34 File Offset: 0x00321134
		private void OnItemInPackageRemovedMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong itemGuid = (ulong)uiEvent.Param1;
			if (!this.IsItemInForSaleItemList(itemGuid))
			{
				return;
			}
			this.UpdateForSaleItemList();
		}

		// Token: 0x0600CC6B RID: 52331 RVA: 0x00322D74 File Offset: 0x00321174
		private void OnItemInPackageAddedMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			ulong guid = (ulong)uiEvent.Param1;
			if (!DataManager<AuctionNewDataManager>.GetInstance().IsPackageItemCanInForSaleList(guid, this._sellTabType))
			{
				return;
			}
			this.UpdateForSaleItemList();
		}

		// Token: 0x0600CC6C RID: 52332 RVA: 0x00322DCC File Offset: 0x003211CC
		private void UpdateOnShelfTitle()
		{
			if (this.onShelfLabel != null)
			{
				int onShelfItemNumber = DataManager<AuctionNewDataManager>.GetInstance().OnShelfItemNumber;
				int num = DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum + DataManager<AuctionNewDataManager>.GetInstance().BaseShelfNum;
				this.onShelfLabel.text = string.Format(TR.Value("auction_new_sell_item_auction_number"), onShelfItemNumber, num);
			}
		}

		// Token: 0x0600CC6D RID: 52333 RVA: 0x00322E31 File Offset: 0x00321231
		private void OnSellRecordButtonClick()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewSellRecordFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewSellRecordFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewSellRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600CC6E RID: 52334 RVA: 0x00322E64 File Offset: 0x00321264
		private bool IsItemInForSaleItemList(ulong itemGuid)
		{
			if (this._packageForSellItemDataList == null || this._packageForSellItemDataList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this._packageForSellItemDataList.Count; i++)
			{
				AuctionSellItemData auctionSellItemData = this._packageForSellItemDataList[i];
				if (auctionSellItemData != null)
				{
					if (auctionSellItemData.uId == itemGuid)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x040076E5 RID: 30437
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x040076E6 RID: 30438
		private int _defaultSellTabIndex;

		// Token: 0x040076E7 RID: 30439
		private ActionNewSellTabType _sellTabType;

		// Token: 0x040076E8 RID: 30440
		private List<AuctionSellItemData> _packageForSellItemDataList;

		// Token: 0x040076E9 RID: 30441
		private List<AuctionNewSellTabDataModel> _sellTabDataModelList = new List<AuctionNewSellTabDataModel>();

		// Token: 0x040076EA RID: 30442
		private List<AuctionNewOnShelfDataModel> _onSelfDataModelList;

		// Token: 0x040076EB RID: 30443
		private AuctionNewUserData _auctionNewUserData;

		// Token: 0x040076EC RID: 30444
		private ItemData _auctionNewUserItemData;

		// Token: 0x040076ED RID: 30445
		private bool _isShowSellRecordButton;

		// Token: 0x040076EE RID: 30446
		[Space(15f)]
		[Header("ComUIList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScript sellTitleTabItemList;

		// Token: 0x040076EF RID: 30447
		[SerializeField]
		private ComUIListScriptEx forSellItemList;

		// Token: 0x040076F0 RID: 30448
		[SerializeField]
		private ComUIListScriptEx onShelfItemList;

		// Token: 0x040076F1 RID: 30449
		[Space(10f)]
		[Header("Other")]
		[SerializeField]
		private Button sellRecordButton;

		// Token: 0x040076F2 RID: 30450
		[SerializeField]
		private Text onShelfLabel;
	}
}
