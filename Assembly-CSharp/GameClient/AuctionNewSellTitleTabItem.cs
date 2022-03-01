using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200149C RID: 5276
	public class AuctionNewSellTitleTabItem : MonoBehaviour
	{
		// Token: 0x0600CC99 RID: 52377 RVA: 0x00323E78 File Offset: 0x00322278
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600CC9A RID: 52378 RVA: 0x00323EB7 File Offset: 0x003222B7
		private void ResetData()
		{
			this._isSelected = false;
			this._sellTabDataModel = null;
			this._onSellTabClick = null;
		}

		// Token: 0x0600CC9B RID: 52379 RVA: 0x00323ECE File Offset: 0x003222CE
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600CC9C RID: 52380 RVA: 0x00323EF8 File Offset: 0x003222F8
		public void Init(AuctionNewSellTabDataModel sellTabDataModel, OnAuctionNewSellTabClick onAuctionNewSellTabClick, bool isSelected = false)
		{
			this._sellTabDataModel = sellTabDataModel;
			if (this._sellTabDataModel == null)
			{
				return;
			}
			this._onSellTabClick = onAuctionNewSellTabClick;
			if (this.normalTabName != null && !string.IsNullOrEmpty(this._sellTabDataModel.sellTabName))
			{
				this.normalTabName.text = TR.Value(this._sellTabDataModel.sellTabName);
			}
			if (this.selectedTabName != null && !string.IsNullOrEmpty(this._sellTabDataModel.sellTabName))
			{
				this.selectedTabName.text = TR.Value(this._sellTabDataModel.sellTabName);
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600CC9D RID: 52381 RVA: 0x00323FC4 File Offset: 0x003223C4
		private void OnTabClicked(bool value)
		{
			if (this._sellTabDataModel == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onSellTabClick != null)
			{
				this._onSellTabClick(this._sellTabDataModel.sellTabType);
			}
		}

		// Token: 0x0400771B RID: 30491
		private bool _isSelected;

		// Token: 0x0400771C RID: 30492
		private AuctionNewSellTabDataModel _sellTabDataModel;

		// Token: 0x0400771D RID: 30493
		private OnAuctionNewSellTabClick _onSellTabClick;

		// Token: 0x0400771E RID: 30494
		[SerializeField]
		private Text normalTabName;

		// Token: 0x0400771F RID: 30495
		[SerializeField]
		private Text selectedTabName;

		// Token: 0x04007720 RID: 30496
		[SerializeField]
		private Toggle toggle;
	}
}
