using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001483 RID: 5251
	public class AuctionNewBuyNoticeTypeController : AuctionNewBuyNoticeBaseController
	{
		// Token: 0x0600CBA3 RID: 52131 RVA: 0x0031E8F1 File Offset: 0x0031CCF1
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CBA4 RID: 52132 RVA: 0x0031E8F9 File Offset: 0x0031CCF9
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CBA5 RID: 52133 RVA: 0x0031E908 File Offset: 0x0031CD08
		private void BindEvents()
		{
			if (this.typeItemList != null)
			{
				this.typeItemList.Initialize();
				ComUIListScript comUIListScript = this.typeItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTypeItemVisible));
				ComUIListScript comUIListScript2 = this.typeItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTypeItemRecycle));
			}
		}

		// Token: 0x0600CBA6 RID: 52134 RVA: 0x0031E980 File Offset: 0x0031CD80
		private void UnBindEvents()
		{
			if (this.typeItemList != null)
			{
				ComUIListScript comUIListScript = this.typeItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTypeItemVisible));
				ComUIListScript comUIListScript2 = this.typeItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTypeItemRecycle));
			}
		}

		// Token: 0x0600CBA7 RID: 52135 RVA: 0x0031E9EC File Offset: 0x0031CDEC
		private void ResetData()
		{
			this._auctionNewMenuTabDataModel = null;
			this._onBuyNoticeTypeItemClick = null;
			this._mainTabType = AuctionNewMainTabType.None;
			this.childrenMenuTabDataModelList = null;
		}

		// Token: 0x0600CBA8 RID: 52136 RVA: 0x0031EA0A File Offset: 0x0031CE0A
		public void InitTypeControllerData(OnBuyNoticeTypeItemClick onBuyNoticeTypeItemClick = null, OnUpdateFilterBackground onUpdateFilterBackground = null)
		{
			this._onBuyNoticeTypeItemClick = onBuyNoticeTypeItemClick;
			this._onUpdateFilterBackground = onUpdateFilterBackground;
		}

		// Token: 0x0600CBA9 RID: 52137 RVA: 0x0031EA1C File Offset: 0x0031CE1C
		public void OnEnableTypeController(AuctionNewMenuTabDataModel auctionNewMenuTabDataModel, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.None)
		{
			this._auctionNewMenuTabDataModel = auctionNewMenuTabDataModel;
			this._mainTabType = auctionNewMainTabType;
			this.childrenMenuTabDataModelList = AuctionNewUtility.GetAuctionNewChildrenLayerTabDataModelList(this._auctionNewMenuTabDataModel, this._mainTabType);
			if (this.childrenMenuTabDataModelList == null || this.childrenMenuTabDataModelList.Count <= 0)
			{
				this.SetTypeItemList(0);
				Logger.LogErrorFormat("OnEnableTypeController AuctionNewMenuTabDataModel List is null", new object[0]);
				return;
			}
			if (this._onUpdateFilterBackground != null)
			{
				this._onUpdateFilterBackground(false);
			}
			int count = this.childrenMenuTabDataModelList.Count;
			this.SetTypeItemList(count);
		}

		// Token: 0x0600CBAA RID: 52138 RVA: 0x0031EAAC File Offset: 0x0031CEAC
		private void SetTypeItemList(int count)
		{
			if (this.typeItemList != null)
			{
				this.typeItemList.ResetContentPosition();
				this.typeItemList.SetElementAmount(count);
			}
		}

		// Token: 0x0600CBAB RID: 52139 RVA: 0x0031EAD8 File Offset: 0x0031CED8
		private void OnTypeItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewBuyNoticeTypeItem component = item.GetComponent<AuctionNewBuyNoticeTypeItem>();
			if (component == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this._auctionNewMenuTabDataModel.AuctionNewFrameTable.LayerRelation.Count)
			{
				AuctionNewMenuTabDataModel curMenuTabDataModel = this.childrenMenuTabDataModelList[item.m_index];
				component.InitItem(this._auctionNewMenuTabDataModel, curMenuTabDataModel, new OnAuctionNewTypeItemClick(this.OnItemClick), this._mainTabType);
			}
		}

		// Token: 0x0600CBAC RID: 52140 RVA: 0x0031EB64 File Offset: 0x0031CF64
		private void OnTypeItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewBuyNoticeTypeItem component = item.GetComponent<AuctionNewBuyNoticeTypeItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x0600CBAD RID: 52141 RVA: 0x0031EB97 File Offset: 0x0031CF97
		private void OnItemClick(AuctionNewMenuTabDataModel auctionNewMenuTabDataModel)
		{
			if (this._onBuyNoticeTypeItemClick != null)
			{
				this._onBuyNoticeTypeItemClick(auctionNewMenuTabDataModel);
			}
		}

		// Token: 0x04007650 RID: 30288
		private AuctionNewMenuTabDataModel _auctionNewMenuTabDataModel;

		// Token: 0x04007651 RID: 30289
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x04007652 RID: 30290
		private List<AuctionNewMenuTabDataModel> childrenMenuTabDataModelList;

		// Token: 0x04007653 RID: 30291
		private OnBuyNoticeTypeItemClick _onBuyNoticeTypeItemClick;

		// Token: 0x04007654 RID: 30292
		private OnUpdateFilterBackground _onUpdateFilterBackground;

		// Token: 0x04007655 RID: 30293
		[Space(10f)]
		[Header("ItemList")]
		[SerializeField]
		private ComUIListScript typeItemList;
	}
}
