using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001489 RID: 5257
	public class AuctionNewMagicCardStrengthenLevelView : MonoBehaviour
	{
		// Token: 0x0600CBD2 RID: 52178 RVA: 0x0031F1A3 File Offset: 0x0031D5A3
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CBD3 RID: 52179 RVA: 0x0031F1AB File Offset: 0x0031D5AB
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CBD4 RID: 52180 RVA: 0x0031F1B9 File Offset: 0x0031D5B9
		private void ResetData()
		{
			this._magicCardDataModel = null;
			this._magicCardStrengthenLevelDataList.Clear();
		}

		// Token: 0x0600CBD5 RID: 52181 RVA: 0x0031F1D0 File Offset: 0x0031D5D0
		private void BindEvents()
		{
			if (this.magicCardStrengthLevelItemList != null)
			{
				this.magicCardStrengthLevelItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.magicCardStrengthLevelItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.magicCardStrengthLevelItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x0600CBD6 RID: 52182 RVA: 0x0031F284 File Offset: 0x0031D684
		private void UnBindEvents()
		{
			if (this.magicCardStrengthLevelItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.magicCardStrengthLevelItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.magicCardStrengthLevelItemList;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CBD7 RID: 52183 RVA: 0x0031F311 File Offset: 0x0031D711
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryMagicCardOnSaleResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveMagicCardOnSaleRes));
		}

		// Token: 0x0600CBD8 RID: 52184 RVA: 0x0031F32E File Offset: 0x0031D72E
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryMagicCardOnSaleResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveMagicCardOnSaleRes));
		}

		// Token: 0x0600CBD9 RID: 52185 RVA: 0x0031F34C File Offset: 0x0031D74C
		public void Init(AuctionNewMagicCardDataModel dataModel)
		{
			this._selectedLevel = -1;
			this._itemId = -1;
			this._magicCardDataModel = dataModel;
			if (this._magicCardDataModel == null)
			{
				return;
			}
			this._itemId = (int)this._magicCardDataModel.ItemId;
			this._selectedLevel = this._magicCardDataModel.DefaultLevel;
			this.SendMagicCardOnSaleReq();
		}

		// Token: 0x0600CBDA RID: 52186 RVA: 0x0031F3A2 File Offset: 0x0031D7A2
		private void SendMagicCardOnSaleReq()
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendAuctionNewMagicCardOnSaleReq(this._magicCardDataModel.ItemId);
		}

		// Token: 0x0600CBDB RID: 52187 RVA: 0x0031F3BC File Offset: 0x0031D7BC
		private void OnReceiveMagicCardOnSaleRes(UIEvent uiEvent)
		{
			WorldAuctionQueryMagicOnsalesRes auctionNewMagicCardOnSaleRes = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewMagicCardOnSaleRes();
			this._magicCardStrengthenLevelDataList.Clear();
			if (auctionNewMagicCardOnSaleRes != null && auctionNewMagicCardOnSaleRes.magicOnsales != null && auctionNewMagicCardOnSaleRes.magicOnsales.Length > 0)
			{
				for (int i = 0; i < auctionNewMagicCardOnSaleRes.magicOnsales.Length; i++)
				{
					AuctionMagicOnsale auctionMagicOnsale = auctionNewMagicCardOnSaleRes.magicOnsales[i];
					if (auctionMagicOnsale != null)
					{
						AuctionNewMagicCardStrengthenLevelDataModel auctionNewMagicCardStrengthenLevelDataModel = new AuctionNewMagicCardStrengthenLevelDataModel
						{
							StrengthenLevel = (int)auctionMagicOnsale.strength,
							Number = (int)auctionMagicOnsale.num
						};
						if ((int)auctionMagicOnsale.strength == this._magicCardDataModel.DefaultLevel)
						{
							auctionNewMagicCardStrengthenLevelDataModel.IsSelected = true;
						}
						this._magicCardStrengthenLevelDataList.Add(auctionNewMagicCardStrengthenLevelDataModel);
					}
				}
			}
			this.SortMagicCardStrengthenLevelDataList();
			if (this.magicCardStrengthLevelItemList != null)
			{
				this.magicCardStrengthLevelItemList.SetElementAmount(this._magicCardStrengthenLevelDataList.Count);
			}
		}

		// Token: 0x0600CBDC RID: 52188 RVA: 0x0031F4A0 File Offset: 0x0031D8A0
		private void SortMagicCardStrengthenLevelDataList()
		{
			if (this._magicCardStrengthenLevelDataList == null || this._magicCardStrengthenLevelDataList.Count <= 1)
			{
				return;
			}
			this._magicCardStrengthenLevelDataList.Sort(delegate(AuctionNewMagicCardStrengthenLevelDataModel x, AuctionNewMagicCardStrengthenLevelDataModel y)
			{
				if (x.Number > 0 && y.Number > 0)
				{
					return x.StrengthenLevel.CompareTo(y.StrengthenLevel);
				}
				if (x.Number > 0)
				{
					return -1;
				}
				if (y.Number > 0)
				{
					return 1;
				}
				return x.StrengthenLevel.CompareTo(y.StrengthenLevel);
			});
		}

		// Token: 0x0600CBDD RID: 52189 RVA: 0x0031F4F4 File Offset: 0x0031D8F4
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._magicCardStrengthenLevelDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index > this._magicCardStrengthenLevelDataList.Count)
			{
				return;
			}
			AuctionNewMagicCardStrengthenLevelDataModel auctionNewMagicCardStrengthenLevelDataModel = this._magicCardStrengthenLevelDataList[item.m_index];
			AuctionNewMagicCardStrengthenLevelItem component = item.GetComponent<AuctionNewMagicCardStrengthenLevelItem>();
			if (auctionNewMagicCardStrengthenLevelDataModel != null && component != null)
			{
				component.InitItem(auctionNewMagicCardStrengthenLevelDataModel, new OnMagicCardStrengthenLevelItemClick(this.OnMagicCardItemClick));
			}
		}

		// Token: 0x0600CBDE RID: 52190 RVA: 0x0031F57C File Offset: 0x0031D97C
		private void OnMagicCardItemClick(int strengthenLevel)
		{
			this._selectedLevel = strengthenLevel;
			for (int i = 0; i < this._magicCardStrengthenLevelDataList.Count; i++)
			{
				AuctionNewMagicCardStrengthenLevelDataModel auctionNewMagicCardStrengthenLevelDataModel = this._magicCardStrengthenLevelDataList[i];
				if (auctionNewMagicCardStrengthenLevelDataModel != null)
				{
					if (auctionNewMagicCardStrengthenLevelDataModel.StrengthenLevel == this._selectedLevel)
					{
						auctionNewMagicCardStrengthenLevelDataModel.IsSelected = true;
					}
					else
					{
						auctionNewMagicCardStrengthenLevelDataModel.IsSelected = false;
					}
				}
			}
			if (this.magicCardStrengthLevelItemList != null)
			{
				this.magicCardStrengthLevelItemList.UpdateElement();
			}
			this.OnCloseFrame();
		}

		// Token: 0x0600CBDF RID: 52191 RVA: 0x0031F608 File Offset: 0x0031DA08
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewMagicCardStrengthenLevelItem component = item.GetComponent<AuctionNewMagicCardStrengthenLevelItem>();
			if (component != null)
			{
				component.UpdateMagicCardItem();
			}
		}

		// Token: 0x0600CBE0 RID: 52192 RVA: 0x0031F63B File Offset: 0x0031DA3B
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewSelectMagicCardStrengthenLevel, this._itemId, this._selectedLevel, null, null);
			AuctionNewUtility.OnCloseAuctionNewMagicCardStrengthLevelFrame();
		}

		// Token: 0x04007668 RID: 30312
		private AuctionNewMagicCardDataModel _magicCardDataModel;

		// Token: 0x04007669 RID: 30313
		private List<AuctionNewMagicCardStrengthenLevelDataModel> _magicCardStrengthenLevelDataList = new List<AuctionNewMagicCardStrengthenLevelDataModel>();

		// Token: 0x0400766A RID: 30314
		private int _selectedLevel = -1;

		// Token: 0x0400766B RID: 30315
		private int _itemId = -1;

		// Token: 0x0400766C RID: 30316
		[Space(15f)]
		[Header("AuctionNewMagicCardItemList")]
		[Space(5f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400766D RID: 30317
		[SerializeField]
		private ComUIListScriptEx magicCardStrengthLevelItemList;
	}
}
