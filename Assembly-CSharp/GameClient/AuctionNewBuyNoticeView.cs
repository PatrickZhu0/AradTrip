using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200146D RID: 5229
	public class AuctionNewBuyNoticeView : AuctionNewContentBaseView
	{
		// Token: 0x0600CAA6 RID: 51878 RVA: 0x003197EA File Offset: 0x00317BEA
		private void OnDestroy()
		{
			this.ResetData();
		}

		// Token: 0x0600CAA7 RID: 51879 RVA: 0x003197F4 File Offset: 0x00317BF4
		private void ResetData()
		{
			this._auctionItemBaseInfo = null;
			this._curMainTabType = AuctionNewMainTabType.None;
			this._firstLayerMenuTabDataModel = null;
			this._secondLayerMenuTabDataModel = null;
			this._thirdLayerMenuTabDataModel = null;
			this._buyNoticeTypeController = null;
			this._buyNoticeOnSaleController = null;
			this._buyNoticeDetailController = null;
			this._auctionNewUserData = null;
			this._defaultFirstLayerTabId = 0;
			this._defaultSecondLayerTabId = 0;
			this._auctionNewFirstLayerTabDataModelList = null;
		}

		// Token: 0x0600CAA8 RID: 51880 RVA: 0x00319858 File Offset: 0x00317C58
		public override void InitView(AuctionNewMainTabType mainTabType, AuctionNewUserData auctionNewUserData = null)
		{
			this._curMainTabType = mainTabType;
			this._auctionNewUserData = auctionNewUserData;
			this._auctionNewFirstLayerTabDataModelList = AuctionNewUtility.GetAuctionNewFirstLayerTabDataModelList(this._curMainTabType);
			if (this._auctionNewFirstLayerTabDataModelList == null || this._auctionNewFirstLayerTabDataModelList.Count <= 0)
			{
				Logger.LogErrorFormat("First Layer TabDataModel is null or count is 0", new object[0]);
				return;
			}
			this.InitBuyNoticeDefaultData();
			this.InitBuyNoticeView();
		}

		// Token: 0x0600CAA9 RID: 51881 RVA: 0x003198BD File Offset: 0x00317CBD
		private void InitBuyNoticeDefaultData()
		{
			this.UpdateDefaultFirstLayerTabId();
		}

		// Token: 0x0600CAAA RID: 51882 RVA: 0x003198C8 File Offset: 0x00317CC8
		private void UpdateDefaultFirstLayerTabId()
		{
			this._defaultFirstLayerTabId = this._auctionNewFirstLayerTabDataModelList[0].Id;
			this._defaultSecondLayerTabId = 0;
			if (this._auctionNewUserData != null)
			{
				if (this._auctionNewUserData.FirstLayerTabId > 0)
				{
					for (int i = 0; i < this._auctionNewFirstLayerTabDataModelList.Count; i++)
					{
						if (this._auctionNewFirstLayerTabDataModelList[i].Id == this._auctionNewUserData.FirstLayerTabId)
						{
							this._defaultFirstLayerTabId = this._auctionNewUserData.FirstLayerTabId;
							break;
						}
					}
				}
				if (this._auctionNewUserData.SecondLayerTabId > 0)
				{
					this._defaultSecondLayerTabId = this._auctionNewUserData.SecondLayerTabId;
				}
			}
		}

		// Token: 0x0600CAAB RID: 51883 RVA: 0x00319984 File Offset: 0x00317D84
		private void InitBuyNoticeView()
		{
			if (this.menuTabContent == null || this.menuItemGroup == null)
			{
				Logger.LogErrorFormat("Item is null ", new object[0]);
				return;
			}
			for (int i = 0; i < this._auctionNewFirstLayerTabDataModelList.Count; i++)
			{
				AuctionNewMenuTabDataModel auctionNewMenuTabDataModel = this._auctionNewFirstLayerTabDataModelList[i];
				bool isSelected = this._defaultFirstLayerTabId == auctionNewMenuTabDataModel.Id;
				List<AuctionNewMenuTabDataModel> auctionNewChildrenLayerTabDataModelList = AuctionNewUtility.GetAuctionNewChildrenLayerTabDataModelList(auctionNewMenuTabDataModel, this._curMainTabType);
				GameObject gameObject = Object.Instantiate<GameObject>(this.menuItemGroup);
				if (gameObject != null)
				{
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.menuTabContent, false);
					AuctionNewMenuItemGroup component = gameObject.GetComponent<AuctionNewMenuItemGroup>();
					if (component != null && component.firstLayerTabItem != null)
					{
						component.firstLayerTabItem.InitTabItem(auctionNewMenuTabDataModel, auctionNewChildrenLayerTabDataModelList, isSelected, this._defaultSecondLayerTabId, new OnFirstLayerTabToggleClick(this.OnFirstLayerTabToggleClick), new OnSecondLayerTabToggleClick(this.OnSecondLayerTabToggleClick));
					}
				}
			}
		}

		// Token: 0x0600CAAC RID: 51884 RVA: 0x00319A8E File Offset: 0x00317E8E
		public override void OnEnableView(AuctionNewMainTabType mainTabType)
		{
			this._curMainTabType = mainTabType;
			this.UpdateBuyNoticeController();
		}

		// Token: 0x0600CAAD RID: 51885 RVA: 0x00319A9D File Offset: 0x00317E9D
		public override void ResetViewType()
		{
			this._curMainTabType = AuctionNewMainTabType.None;
		}

		// Token: 0x0600CAAE RID: 51886 RVA: 0x00319AA8 File Offset: 0x00317EA8
		private void UpdateBuyNoticeController()
		{
			this.SetLastTimeUserData();
			if (this._buyNoticeTypeController != null && this._buyNoticeTypeController.gameObject.activeInHierarchy)
			{
				this._buyNoticeTypeController.OnEnableTypeController(this._secondLayerMenuTabDataModel, this._curMainTabType);
				return;
			}
			if (this._buyNoticeOnSaleController != null && this._buyNoticeOnSaleController.gameObject.activeInHierarchy)
			{
				this._buyNoticeOnSaleController.OnEnableOnSaleController(this._firstLayerMenuTabDataModel, this._secondLayerMenuTabDataModel, this._thirdLayerMenuTabDataModel, this._curMainTabType);
				return;
			}
			if (this._buyNoticeDetailController != null && this._buyNoticeDetailController.gameObject.activeInHierarchy)
			{
				if (this._firstLayerMenuTabDataModel != null && this._firstLayerMenuTabDataModel.AuctionNewFrameTable != null && this._firstLayerMenuTabDataModel.AuctionNewFrameTable.MenuType == AuctionNewFrameTable.eMenuType.Auction_Menu_Notice)
				{
					this._buyNoticeDetailController.OnEnableDetailController(this._curMainTabType, true, null, false);
				}
				else
				{
					this._buyNoticeDetailController.OnEnableDetailController(this._curMainTabType, false, this._auctionItemBaseInfo, false);
				}
			}
		}

		// Token: 0x0600CAAF RID: 51887 RVA: 0x00319BCC File Offset: 0x00317FCC
		private void SetLastTimeUserData()
		{
			if (this._firstLayerMenuTabDataModel != null)
			{
				DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataFirstLayerTabId(this._firstLayerMenuTabDataModel.Id);
			}
			if (this._secondLayerMenuTabDataModel != null)
			{
				DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataSecondLayerTabId(this._secondLayerMenuTabDataModel.Id);
			}
		}

		// Token: 0x0600CAB0 RID: 51888 RVA: 0x00319C1C File Offset: 0x0031801C
		private void OnFirstLayerTabToggleClick(AuctionNewMenuTabDataModel auctionNewMenuTabDataModel)
		{
			this._firstLayerMenuTabDataModel = auctionNewMenuTabDataModel;
			if (this._firstLayerMenuTabDataModel != null && this._firstLayerMenuTabDataModel.AuctionNewFrameTable != null)
			{
				if (this._firstLayerMenuTabDataModel.AuctionNewFrameTable.MenuType == AuctionNewFrameTable.eMenuType.Auction_Menu_Notice)
				{
					this.OnShowBuyNoticeDetailContent(true);
					this._secondLayerMenuTabDataModel = null;
					this._thirdLayerMenuTabDataModel = null;
					this._auctionItemBaseInfo = null;
					DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataSecondLayerTabId(0);
				}
				DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataFirstLayerTabId(this._firstLayerMenuTabDataModel.Id);
			}
			else
			{
				Logger.LogErrorFormat("firstLayerMenuTabModel is null or auctionNewFrameTable is null", new object[0]);
			}
		}

		// Token: 0x0600CAB1 RID: 51889 RVA: 0x00319CB4 File Offset: 0x003180B4
		private void OnSecondLayerTabToggleClick(AuctionNewMenuTabDataModel parentTabDataModel, AuctionNewMenuTabDataModel auctionNewMenuTabDataModel)
		{
			this._firstLayerMenuTabDataModel = parentTabDataModel;
			this._secondLayerMenuTabDataModel = auctionNewMenuTabDataModel;
			this._thirdLayerMenuTabDataModel = null;
			this._auctionItemBaseInfo = null;
			if (this._firstLayerMenuTabDataModel == null || this._firstLayerMenuTabDataModel.AuctionNewFrameTable == null || this._secondLayerMenuTabDataModel == null || this._secondLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogError("OnSecondLayerTabToggleClick is Error");
				return;
			}
			if (this._secondLayerMenuTabDataModel.IsOwnerChildren)
			{
				this.OnShowBuyNoticeTypeContent();
			}
			else
			{
				this.OnShowBuyNoticeOnSaleContent();
			}
			DataManager<AuctionNewDataManager>.GetInstance().SetLastTimeUserDataSecondLayerTabId(this._secondLayerMenuTabDataModel.Id);
		}

		// Token: 0x0600CAB2 RID: 51890 RVA: 0x00319D54 File Offset: 0x00318154
		private void OnShowBuyNoticeTypeContent()
		{
			this.ResetBuyNoticeRoot();
			if (this.buyNoticeTypeRoot == null)
			{
				Logger.LogErrorFormat("BuyNoticeView buyNoticeTypeRoot is null", new object[0]);
				return;
			}
			if (!this.buyNoticeTypeRoot.activeSelf)
			{
				this.buyNoticeTypeRoot.CustomActive(true);
			}
			if (this._buyNoticeTypeController == null)
			{
				this._buyNoticeTypeController = (this.LoadBuyNoticeBaseController(this.buyNoticeTypeRoot) as AuctionNewBuyNoticeTypeController);
				if (this._buyNoticeTypeController != null)
				{
					this._buyNoticeTypeController.InitTypeControllerData(new OnBuyNoticeTypeItemClick(this.OnBuyNoticeTypeItemClick), new OnUpdateFilterBackground(this.OnUpdateFilterBackground));
				}
			}
			if (this._buyNoticeTypeController != null)
			{
				this._buyNoticeTypeController.OnEnableTypeController(this._secondLayerMenuTabDataModel, this._curMainTabType);
			}
		}

		// Token: 0x0600CAB3 RID: 51891 RVA: 0x00319E2C File Offset: 0x0031822C
		private void OnShowBuyNoticeOnSaleContent()
		{
			this.ResetBuyNoticeRoot();
			if (this.buyNoticeOnSaleRoot == null)
			{
				Logger.LogErrorFormat("BuyNoticeView buyNoticeOnSaleRoot is null", new object[0]);
				return;
			}
			if (!this.buyNoticeOnSaleRoot.activeSelf)
			{
				this.buyNoticeOnSaleRoot.CustomActive(true);
			}
			if (this._buyNoticeOnSaleController == null)
			{
				this._buyNoticeOnSaleController = (this.LoadBuyNoticeBaseController(this.buyNoticeOnSaleRoot) as AuctionNewBuyNoticeOnSaleController);
				if (this._buyNoticeOnSaleController != null)
				{
					this._buyNoticeOnSaleController.InitOnSaleController(new OnBuyNoticeOnSaleItemClick(this.OnBuyNoticeOnSaleItemClick), new OnUpdateFilterBackground(this.OnUpdateFilterBackground), this._curMainTabType);
				}
			}
			if (this._buyNoticeOnSaleController != null)
			{
				this._buyNoticeOnSaleController.OnEnableOnSaleController(this._firstLayerMenuTabDataModel, this._secondLayerMenuTabDataModel, this._thirdLayerMenuTabDataModel, this._curMainTabType);
			}
		}

		// Token: 0x0600CAB4 RID: 51892 RVA: 0x00319F14 File Offset: 0x00318314
		private void OnShowBuyNoticeDetailContent(bool isNoticeTab = false)
		{
			this.ResetBuyNoticeRoot();
			if (this.buyNoticeDetailRoot == null)
			{
				Logger.LogErrorFormat("BuyNoticeView buyNoticeDetailRoot is null", new object[0]);
				return;
			}
			if (!this.buyNoticeDetailRoot.activeSelf)
			{
				this.buyNoticeDetailRoot.CustomActive(true);
			}
			if (this._buyNoticeDetailController == null)
			{
				this._buyNoticeDetailController = (this.LoadBuyNoticeBaseController(this.buyNoticeDetailRoot) as AuctionNewBuyNoticeDetailController);
				if (this._buyNoticeDetailController != null)
				{
					this._buyNoticeDetailController.InitDetailController(new OnUpdateFilterBackground(this.OnUpdateFilterBackground), new Action(this.OnReturnButtonClick));
				}
			}
			if (this._buyNoticeDetailController != null)
			{
				if (isNoticeTab)
				{
					this._buyNoticeDetailController.OnEnableDetailController(this._curMainTabType, true, null, false);
				}
				else
				{
					this._buyNoticeDetailController.OnEnableDetailController(this._curMainTabType, false, this._auctionItemBaseInfo, true);
				}
			}
		}

		// Token: 0x0600CAB5 RID: 51893 RVA: 0x0031A00C File Offset: 0x0031840C
		private void ResetBuyNoticeRoot()
		{
			if (this.buyNoticeOnSaleRoot != null)
			{
				this.buyNoticeOnSaleRoot.CustomActive(false);
			}
			if (this.buyNoticeTypeRoot != null)
			{
				this.buyNoticeTypeRoot.CustomActive(false);
			}
			if (this.buyNoticeDetailRoot != null)
			{
				this.buyNoticeDetailRoot.CustomActive(false);
			}
		}

		// Token: 0x0600CAB6 RID: 51894 RVA: 0x0031A070 File Offset: 0x00318470
		private AuctionNewBuyNoticeBaseController LoadBuyNoticeBaseController(GameObject contentRoot)
		{
			AuctionNewBuyNoticeBaseController result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<AuctionNewBuyNoticeBaseController>();
				}
			}
			return result;
		}

		// Token: 0x0600CAB7 RID: 51895 RVA: 0x0031A0BF File Offset: 0x003184BF
		private void OnBuyNoticeTypeItemClick(AuctionNewMenuTabDataModel auctionNewMenuTabDataModel)
		{
			this._thirdLayerMenuTabDataModel = auctionNewMenuTabDataModel;
			this._auctionItemBaseInfo = null;
			this.OnShowBuyNoticeOnSaleContent();
		}

		// Token: 0x0600CAB8 RID: 51896 RVA: 0x0031A0D5 File Offset: 0x003184D5
		private void OnBuyNoticeOnSaleItemClick(AuctionItemBaseInfo auctionItemBaseInfo)
		{
			this._auctionItemBaseInfo = auctionItemBaseInfo;
			this.OnShowBuyNoticeDetailContent(false);
		}

		// Token: 0x0600CAB9 RID: 51897 RVA: 0x0031A0E5 File Offset: 0x003184E5
		private void OnReturnButtonClick()
		{
			this._auctionItemBaseInfo = null;
			this.OnShowBuyNoticeOnSaleContent();
		}

		// Token: 0x0600CABA RID: 51898 RVA: 0x0031A0F4 File Offset: 0x003184F4
		private void OnUpdateFilterBackground(bool isHaveFilter)
		{
			if (isHaveFilter)
			{
				if (this.noFilterBackground != null)
				{
					this.noFilterBackground.gameObject.CustomActive(false);
				}
				if (this.haveFilterBackground != null)
				{
					this.haveFilterBackground.gameObject.CustomActive(true);
				}
			}
			else
			{
				if (this.haveFilterBackground != null)
				{
					this.haveFilterBackground.gameObject.CustomActive(false);
				}
				if (this.noFilterBackground != null)
				{
					this.noFilterBackground.gameObject.CustomActive(true);
				}
			}
		}

		// Token: 0x040075A9 RID: 30121
		private AuctionItemBaseInfo _auctionItemBaseInfo;

		// Token: 0x040075AA RID: 30122
		private AuctionNewMainTabType _curMainTabType;

		// Token: 0x040075AB RID: 30123
		private AuctionNewMenuTabDataModel _firstLayerMenuTabDataModel;

		// Token: 0x040075AC RID: 30124
		private AuctionNewMenuTabDataModel _secondLayerMenuTabDataModel;

		// Token: 0x040075AD RID: 30125
		private AuctionNewMenuTabDataModel _thirdLayerMenuTabDataModel;

		// Token: 0x040075AE RID: 30126
		private AuctionNewBuyNoticeTypeController _buyNoticeTypeController;

		// Token: 0x040075AF RID: 30127
		private AuctionNewBuyNoticeOnSaleController _buyNoticeOnSaleController;

		// Token: 0x040075B0 RID: 30128
		private AuctionNewBuyNoticeDetailController _buyNoticeDetailController;

		// Token: 0x040075B1 RID: 30129
		private int _defaultFirstLayerTabId;

		// Token: 0x040075B2 RID: 30130
		private int _defaultSecondLayerTabId;

		// Token: 0x040075B3 RID: 30131
		private AuctionNewUserData _auctionNewUserData;

		// Token: 0x040075B4 RID: 30132
		private List<AuctionNewMenuTabDataModel> _auctionNewFirstLayerTabDataModelList;

		// Token: 0x040075B5 RID: 30133
		[Space(10f)]
		[Header("BuyNoticeContent")]
		[Space(5f)]
		[SerializeField]
		private GameObject buyNoticeTypeRoot;

		// Token: 0x040075B6 RID: 30134
		[SerializeField]
		private GameObject buyNoticeOnSaleRoot;

		// Token: 0x040075B7 RID: 30135
		[SerializeField]
		private GameObject buyNoticeDetailRoot;

		// Token: 0x040075B8 RID: 30136
		[Space(10f)]
		[Header("MenuTabs")]
		[Space(5f)]
		[SerializeField]
		private GameObject menuTabContent;

		// Token: 0x040075B9 RID: 30137
		[SerializeField]
		private GameObject menuItemGroup;

		// Token: 0x040075BA RID: 30138
		[Space(15f)]
		[Header("FilterBackground")]
		[Space(5f)]
		[SerializeField]
		private GameObject noFilterBackground;

		// Token: 0x040075BB RID: 30139
		[SerializeField]
		private GameObject haveFilterBackground;
	}
}
