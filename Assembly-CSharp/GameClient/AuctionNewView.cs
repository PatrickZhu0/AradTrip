using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001466 RID: 5222
	public class AuctionNewView : MonoBehaviour
	{
		// Token: 0x0600CA5F RID: 51807 RVA: 0x00318689 File Offset: 0x00316A89
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CA60 RID: 51808 RVA: 0x00318691 File Offset: 0x00316A91
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CA61 RID: 51809 RVA: 0x003186A0 File Offset: 0x00316AA0
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.mainTabItemList != null)
			{
				this.mainTabItemList.Initialize();
				ComUIListScript comUIListScript = this.mainTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
			}
		}

		// Token: 0x0600CA62 RID: 51810 RVA: 0x00318730 File Offset: 0x00316B30
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.mainTabItemList != null)
			{
				ComUIListScript comUIListScript = this.mainTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
			}
		}

		// Token: 0x0600CA63 RID: 51811 RVA: 0x00318796 File Offset: 0x00316B96
		private void ClearData()
		{
			this._defaultSelectedIndex = 0;
			this._buyContentView = null;
			this._noticeContentView = null;
			this._sellContentView = null;
			this._auctionNewUserData = null;
			this._showMainTabDataModelList = null;
			this._isShowNoticeTab = false;
		}

		// Token: 0x0600CA64 RID: 51812 RVA: 0x003187C9 File Offset: 0x00316BC9
		public void InitView(AuctionNewUserData auctionNewUserData = null)
		{
			this._auctionNewUserData = auctionNewUserData;
			this.InitBaseView();
			this.InitAuctionContent();
		}

		// Token: 0x0600CA65 RID: 51813 RVA: 0x003187DE File Offset: 0x00316BDE
		private void InitBaseView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("auction_new_title");
			}
		}

		// Token: 0x0600CA66 RID: 51814 RVA: 0x00318808 File Offset: 0x00316C08
		private void InitAuctionContent()
		{
			if (this.mainTabDataModelList == null)
			{
				return;
			}
			int count = this.mainTabDataModelList.Count;
			if (count <= 0)
			{
				return;
			}
			this.InitShowMainTabData();
			this.SetDefaultSelectedIndex();
			if (this.mainTabItemList != null)
			{
				this.mainTabItemList.SetElementAmount(this._showMainTabDataModelList.Count);
			}
		}

		// Token: 0x0600CA67 RID: 51815 RVA: 0x00318868 File Offset: 0x00316C68
		private void InitShowMainTabData()
		{
			this._isShowNoticeTab = true;
			if (!AuctionNewUtility.IsAuctionTreasureItemOpen())
			{
				this._isShowNoticeTab = false;
			}
			for (int i = 0; i < this.mainTabDataModelList.Count; i++)
			{
				AuctionNewMainTabDataModel auctionNewMainTabDataModel = this.mainTabDataModelList[i];
				if (auctionNewMainTabDataModel != null)
				{
					if (this._isShowNoticeTab || auctionNewMainTabDataModel.mainTabType != AuctionNewMainTabType.AuctionNoticeType)
					{
						AuctionNewMainTabDataModel item = new AuctionNewMainTabDataModel
						{
							index = auctionNewMainTabDataModel.index,
							mainTabType = auctionNewMainTabDataModel.mainTabType,
							mainTabName = auctionNewMainTabDataModel.mainTabName
						};
						this._showMainTabDataModelList.Add(item);
					}
				}
			}
		}

		// Token: 0x0600CA68 RID: 51816 RVA: 0x00318918 File Offset: 0x00316D18
		private void SetDefaultSelectedIndex()
		{
			if (this._auctionNewUserData == null)
			{
				this._defaultSelectedIndex = 0;
				return;
			}
			this._defaultSelectedIndex = 0;
			for (int i = 0; i < this._showMainTabDataModelList.Count; i++)
			{
				AuctionNewMainTabDataModel auctionNewMainTabDataModel = this._showMainTabDataModelList[i];
				if (auctionNewMainTabDataModel != null)
				{
					if (auctionNewMainTabDataModel.mainTabType == this._auctionNewUserData.MainTabType)
					{
						this._defaultSelectedIndex = i;
						return;
					}
				}
			}
		}

		// Token: 0x0600CA69 RID: 51817 RVA: 0x00318994 File Offset: 0x00316D94
		private void OnMainTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewMainTabItem component = item.GetComponent<AuctionNewMainTabItem>();
			if (component == null)
			{
				return;
			}
			if (this._showMainTabDataModelList != null && item.m_index >= 0 && item.m_index < this._showMainTabDataModelList.Count)
			{
				AuctionNewMainTabDataModel auctionNewMainTabDataModel = this._showMainTabDataModelList[item.m_index];
				if (auctionNewMainTabDataModel != null)
				{
					if (this._defaultSelectedIndex == item.m_index)
					{
						component.Init(auctionNewMainTabDataModel, new OnAuctionMainTabClicked(this.OnMainTabClicked), true);
					}
					else
					{
						component.Init(auctionNewMainTabDataModel, new OnAuctionMainTabClicked(this.OnMainTabClicked), false);
					}
				}
			}
		}

		// Token: 0x0600CA6A RID: 51818 RVA: 0x00318A48 File Offset: 0x00316E48
		private void OnMainTabClicked(AuctionNewMainTabType mainTabType)
		{
			this.ResetContentRoot();
			if (mainTabType != AuctionNewMainTabType.AuctionSellType)
			{
				if (mainTabType != AuctionNewMainTabType.AuctionBuyType)
				{
					if (mainTabType == AuctionNewMainTabType.AuctionNoticeType)
					{
						this.OnNoticeTabClicked(mainTabType);
					}
				}
				else
				{
					this.OnBuyTabClicked(mainTabType);
				}
			}
			else
			{
				this.OnSellTabClicked(mainTabType);
			}
			DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataMainTabType(mainTabType);
		}

		// Token: 0x0600CA6B RID: 51819 RVA: 0x00318AA4 File Offset: 0x00316EA4
		private void OnBuyTabClicked(AuctionNewMainTabType mainTabType)
		{
			if (this.buyContentRoot != null && !this.buyContentRoot.activeSelf)
			{
				this.buyContentRoot.CustomActive(true);
			}
			if (this._buyContentView == null)
			{
				this._buyContentView = this.LoadContentBaseView(this.buyContentRoot);
				this._buyContentView.InitView(mainTabType, this._auctionNewUserData);
				this._auctionNewUserData = null;
			}
			else
			{
				this._buyContentView.OnEnableView(mainTabType);
			}
		}

		// Token: 0x0600CA6C RID: 51820 RVA: 0x00318B2C File Offset: 0x00316F2C
		private void OnSellTabClicked(AuctionNewMainTabType mainTabType)
		{
			if (this.sellContentRoot != null && !this.sellContentRoot.activeSelf)
			{
				this.sellContentRoot.CustomActive(true);
			}
			if (this._sellContentView == null)
			{
				this._sellContentView = this.LoadContentBaseView(this.sellContentRoot);
				this._sellContentView.InitView(mainTabType, this._auctionNewUserData);
				this._auctionNewUserData = null;
			}
			else if (this._sellContentView != null)
			{
				this._sellContentView.OnEnableView(mainTabType);
			}
		}

		// Token: 0x0600CA6D RID: 51821 RVA: 0x00318BC4 File Offset: 0x00316FC4
		private void OnNoticeTabClicked(AuctionNewMainTabType mainTabType)
		{
			if (this.noticeContentRoot != null && !this.noticeContentRoot.activeSelf)
			{
				this.noticeContentRoot.CustomActive(true);
			}
			if (this._noticeContentView == null)
			{
				this._noticeContentView = this.LoadContentBaseView(this.noticeContentRoot);
				this._noticeContentView.InitView(mainTabType, this._auctionNewUserData);
				this._auctionNewUserData = null;
			}
			else
			{
				this._noticeContentView.OnEnableView(mainTabType);
			}
		}

		// Token: 0x0600CA6E RID: 51822 RVA: 0x00318C4C File Offset: 0x0031704C
		private void ResetContentRoot()
		{
			if (this.buyContentRoot != null)
			{
				this.buyContentRoot.CustomActive(false);
			}
			if (this.noticeContentRoot != null)
			{
				this.noticeContentRoot.CustomActive(false);
			}
			if (this.sellContentRoot != null)
			{
				this.sellContentRoot.CustomActive(false);
			}
		}

		// Token: 0x0600CA6F RID: 51823 RVA: 0x00318CB0 File Offset: 0x003170B0
		private AuctionNewContentBaseView LoadContentBaseView(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			AuctionNewContentBaseView result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<AuctionNewContentBaseView>();
				}
			}
			return result;
		}

		// Token: 0x0600CA70 RID: 51824 RVA: 0x00318D0D File Offset: 0x0031710D
		private void OnCloseFrame()
		{
			DataManager<AuctionNewDataManager>.GetInstance().ResetAuctionNewItemIdDictionary();
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewFrame>(null, false);
		}

		// Token: 0x04007585 RID: 30085
		private int _defaultSelectedIndex = 1;

		// Token: 0x04007586 RID: 30086
		private AuctionNewContentBaseView _buyContentView;

		// Token: 0x04007587 RID: 30087
		private AuctionNewContentBaseView _noticeContentView;

		// Token: 0x04007588 RID: 30088
		private AuctionNewContentBaseView _sellContentView;

		// Token: 0x04007589 RID: 30089
		private AuctionNewUserData _auctionNewUserData;

		// Token: 0x0400758A RID: 30090
		private List<AuctionNewMainTabDataModel> _showMainTabDataModelList = new List<AuctionNewMainTabDataModel>();

		// Token: 0x0400758B RID: 30091
		private bool _isShowNoticeTab;

		// Token: 0x0400758C RID: 30092
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400758D RID: 30093
		[SerializeField]
		private ComUIListScript mainTabItemList;

		// Token: 0x0400758E RID: 30094
		[Space(5f)]
		[Header("Button")]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400758F RID: 30095
		[Space(15f)]
		[Header("AuctionNewMainTabData")]
		[SerializeField]
		private List<AuctionNewMainTabDataModel> mainTabDataModelList = new List<AuctionNewMainTabDataModel>();

		// Token: 0x04007590 RID: 30096
		[Space(15f)]
		[Header("AuctionNewContent")]
		[SerializeField]
		private GameObject buyContentRoot;

		// Token: 0x04007591 RID: 30097
		[SerializeField]
		private GameObject noticeContentRoot;

		// Token: 0x04007592 RID: 30098
		[SerializeField]
		private GameObject sellContentRoot;
	}
}
