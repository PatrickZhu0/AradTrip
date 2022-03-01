using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001477 RID: 5239
	public class AuctionNewPositionFilterItem : MonoBehaviour
	{
		// Token: 0x0600CB33 RID: 52019 RVA: 0x0031C8D5 File Offset: 0x0031ACD5
		private void Awake()
		{
			this.BindUiEvent();
		}

		// Token: 0x0600CB34 RID: 52020 RVA: 0x0031C8DD File Offset: 0x0031ACDD
		private void OnDestroy()
		{
			this.UnBindUiEvent();
			this.ClearData();
		}

		// Token: 0x0600CB35 RID: 52021 RVA: 0x0031C8EB File Offset: 0x0031ACEB
		private void BindUiEvent()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnItemButtonClick));
			}
		}

		// Token: 0x0600CB36 RID: 52022 RVA: 0x0031C92A File Offset: 0x0031AD2A
		private void UnBindUiEvent()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CB37 RID: 52023 RVA: 0x0031C94D File Offset: 0x0031AD4D
		private void ClearData()
		{
			this._auctionNewFilterData = null;
		}

		// Token: 0x0600CB38 RID: 52024 RVA: 0x0031C956 File Offset: 0x0031AD56
		public void InitItem(AuctionNewFilterData filterData)
		{
			this._auctionNewFilterData = filterData;
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			this.InitView();
		}

		// Token: 0x0600CB39 RID: 52025 RVA: 0x0031C971 File Offset: 0x0031AD71
		public void RecycleItem()
		{
			this.ClearData();
		}

		// Token: 0x0600CB3A RID: 52026 RVA: 0x0031C979 File Offset: 0x0031AD79
		private void InitView()
		{
			if (this.positionLabel != null)
			{
				this.positionLabel.text = this._auctionNewFilterData.Name;
			}
		}

		// Token: 0x0600CB3B RID: 52027 RVA: 0x0031C9A2 File Offset: 0x0031ADA2
		private void OnItemButtonClick()
		{
			if (this._auctionNewFilterData != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAuctionNewSelectPositionFilter, this._auctionNewFilterData, null, null, null);
			}
			AuctionNewUtility.OnCloseAuctionNewPositionFilterFrame();
		}

		// Token: 0x0400760B RID: 30219
		private AuctionNewFilterData _auctionNewFilterData;

		// Token: 0x0400760C RID: 30220
		[SerializeField]
		private Text positionLabel;

		// Token: 0x0400760D RID: 30221
		[SerializeField]
		private Button button;
	}
}
