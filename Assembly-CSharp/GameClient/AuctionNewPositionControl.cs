using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001475 RID: 5237
	public class AuctionNewPositionControl : MonoBehaviour
	{
		// Token: 0x0600CB22 RID: 52002 RVA: 0x0031C6D2 File Offset: 0x0031AAD2
		private void Awake()
		{
			this.BindUiEvent();
		}

		// Token: 0x0600CB23 RID: 52003 RVA: 0x0031C6DA File Offset: 0x0031AADA
		private void OnDestroy()
		{
			this.UnBindUiEvent();
			this.ClearData();
		}

		// Token: 0x0600CB24 RID: 52004 RVA: 0x0031C6E8 File Offset: 0x0031AAE8
		private void BindUiEvent()
		{
			if (this.positionButton != null)
			{
				this.positionButton.onClick.RemoveAllListeners();
				this.positionButton.onClick.AddListener(new UnityAction(this.OnPositionButtonClick));
			}
		}

		// Token: 0x0600CB25 RID: 52005 RVA: 0x0031C727 File Offset: 0x0031AB27
		private void UnBindUiEvent()
		{
			if (this.positionButton != null)
			{
				this.positionButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CB26 RID: 52006 RVA: 0x0031C74A File Offset: 0x0031AB4A
		private void ClearData()
		{
			this._auctionNewFilterData = null;
			this._onAuctionNewFilterElementItemButtonClick = null;
		}

		// Token: 0x0600CB27 RID: 52007 RVA: 0x0031C75A File Offset: 0x0031AB5A
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewSelectPositionFilter, new ClientEventSystem.UIEventHandler(this.OnAuctionNewSelectPositionFilter));
		}

		// Token: 0x0600CB28 RID: 52008 RVA: 0x0031C777 File Offset: 0x0031AB77
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewSelectPositionFilter, new ClientEventSystem.UIEventHandler(this.OnAuctionNewSelectPositionFilter));
		}

		// Token: 0x0600CB29 RID: 52009 RVA: 0x0031C794 File Offset: 0x0031AB94
		public void InitFilterControl(AuctionNewFilterData auctionNewFilterData, OnAuctionNewFilterElementItemButtonClick filterElementItemButtonClick)
		{
			this.ClearData();
			this._auctionNewFilterData = auctionNewFilterData;
			this._onAuctionNewFilterElementItemButtonClick = filterElementItemButtonClick;
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			this._filterType = (int)this._auctionNewFilterData.FilterItemType;
			this.UpdatePositionLabel();
		}

		// Token: 0x0600CB2A RID: 52010 RVA: 0x0031C7CD File Offset: 0x0031ABCD
		private void UpdatePositionLabel()
		{
			if (this.positionName != null)
			{
				this.positionName.text = this._auctionNewFilterData.Name;
			}
		}

		// Token: 0x0600CB2B RID: 52011 RVA: 0x0031C7F6 File Offset: 0x0031ABF6
		private void OnPositionButtonClick()
		{
			AuctionNewUtility.OnOpenAuctionNewPositionFilterFrame(this._filterType);
		}

		// Token: 0x0600CB2C RID: 52012 RVA: 0x0031C804 File Offset: 0x0031AC04
		private void OnAuctionNewSelectPositionFilter(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			AuctionNewFilterData auctionNewFilterData = uiEvent.Param1 as AuctionNewFilterData;
			if (auctionNewFilterData == null)
			{
				return;
			}
			this._auctionNewFilterData = auctionNewFilterData;
			this.UpdatePositionLabel();
			if (this._onAuctionNewFilterElementItemButtonClick != null)
			{
				this._onAuctionNewFilterElementItemButtonClick(this._auctionNewFilterData);
			}
		}

		// Token: 0x04007605 RID: 30213
		private AuctionNewFilterData _auctionNewFilterData;

		// Token: 0x04007606 RID: 30214
		private int _filterType;

		// Token: 0x04007607 RID: 30215
		private OnAuctionNewFilterElementItemButtonClick _onAuctionNewFilterElementItemButtonClick;

		// Token: 0x04007608 RID: 30216
		[SerializeField]
		private Text positionName;

		// Token: 0x04007609 RID: 30217
		[SerializeField]
		private Button positionButton;
	}
}
