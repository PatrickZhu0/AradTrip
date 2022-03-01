using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001485 RID: 5253
	public class AuctionNewBuyNoticeTypeItem : MonoBehaviour
	{
		// Token: 0x0600CBB3 RID: 52147 RVA: 0x0031EBB8 File Offset: 0x0031CFB8
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CBB4 RID: 52148 RVA: 0x0031EBC0 File Offset: 0x0031CFC0
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CBB5 RID: 52149 RVA: 0x0031EBCE File Offset: 0x0031CFCE
		private void BindEvents()
		{
			if (this.typeItemButton != null)
			{
				this.typeItemButton.onClick.RemoveAllListeners();
				this.typeItemButton.onClick.AddListener(new UnityAction(this.OnTypeItemButtonClick));
			}
		}

		// Token: 0x0600CBB6 RID: 52150 RVA: 0x0031EC0D File Offset: 0x0031D00D
		private void UnBindEvents()
		{
			if (this.typeItemButton != null)
			{
				this.typeItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CBB7 RID: 52151 RVA: 0x0031EC30 File Offset: 0x0031D030
		private void ResetData()
		{
			this._onAuctionNewTypeItemClick = null;
			this._parentMenuTabDataModel = null;
			this._curMenuTabDataModel = null;
			this._mainTabType = AuctionNewMainTabType.None;
		}

		// Token: 0x0600CBB8 RID: 52152 RVA: 0x0031EC4E File Offset: 0x0031D04E
		public void InitItem(AuctionNewMenuTabDataModel parentMenuTabDataModel, AuctionNewMenuTabDataModel curMenuTabDataModel, OnAuctionNewTypeItemClick onAuctionNewTypeItemClick = null, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.None)
		{
			this._parentMenuTabDataModel = parentMenuTabDataModel;
			this._curMenuTabDataModel = curMenuTabDataModel;
			this._onAuctionNewTypeItemClick = onAuctionNewTypeItemClick;
			this._mainTabType = auctionNewMainTabType;
			this.InitItemView();
		}

		// Token: 0x0600CBB9 RID: 52153 RVA: 0x0031EC74 File Offset: 0x0031D074
		private void InitItemView()
		{
			if (this.typeName != null)
			{
				this.typeName.text = this._curMenuTabDataModel.AuctionNewFrameTable.Name;
			}
			if (this.typeProfessionLabel != null)
			{
				if (string.IsNullOrEmpty(this._curMenuTabDataModel.AuctionNewFrameTable.RecommendedJob))
				{
					this.typeProfessionLabel.gameObject.CustomActive(false);
				}
				else
				{
					this.typeProfessionLabel.gameObject.CustomActive(true);
					this.typeProfessionLabel.text = this._curMenuTabDataModel.AuctionNewFrameTable.RecommendedJob;
				}
			}
			if (this.typeIcon != null && !string.IsNullOrEmpty(this._curMenuTabDataModel.AuctionNewFrameTable.IconPath))
			{
				ETCImageLoader.LoadSprite(ref this.typeIcon, this._curMenuTabDataModel.AuctionNewFrameTable.IconPath, true);
			}
			if (this.typeImageFrame != null && !string.IsNullOrEmpty(this._curMenuTabDataModel.AuctionNewFrameTable.IconPath))
			{
				ETCImageLoader.LoadSprite(ref this.typeImageFrame, this._curMenuTabDataModel.AuctionNewFrameTable.BaseMap, true);
			}
		}

		// Token: 0x0600CBBA RID: 52154 RVA: 0x0031EDAA File Offset: 0x0031D1AA
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x0600CBBB RID: 52155 RVA: 0x0031EDB2 File Offset: 0x0031D1B2
		private void OnTypeItemButtonClick()
		{
			if (this._curMenuTabDataModel == null)
			{
				return;
			}
			if (this._onAuctionNewTypeItemClick == null)
			{
				return;
			}
			this._onAuctionNewTypeItemClick(this._curMenuTabDataModel);
		}

		// Token: 0x04007656 RID: 30294
		private OnAuctionNewTypeItemClick _onAuctionNewTypeItemClick;

		// Token: 0x04007657 RID: 30295
		private AuctionNewMenuTabDataModel _parentMenuTabDataModel;

		// Token: 0x04007658 RID: 30296
		private AuctionNewMenuTabDataModel _curMenuTabDataModel;

		// Token: 0x04007659 RID: 30297
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x0400765A RID: 30298
		[SerializeField]
		private Image typeIcon;

		// Token: 0x0400765B RID: 30299
		[SerializeField]
		private Image typeImageFrame;

		// Token: 0x0400765C RID: 30300
		[SerializeField]
		private Text typeName;

		// Token: 0x0400765D RID: 30301
		[SerializeField]
		private Button typeItemButton;

		// Token: 0x0400765E RID: 30302
		[SerializeField]
		private Text typeProfessionLabel;
	}
}
