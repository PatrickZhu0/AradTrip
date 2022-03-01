using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001472 RID: 5234
	public class AuctionNewFilterElementItem : MonoBehaviour
	{
		// Token: 0x0600CB10 RID: 51984 RVA: 0x0031C3F9 File Offset: 0x0031A7F9
		private void Awake()
		{
			this._auctionNewFilterData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600CB11 RID: 51985 RVA: 0x0031C408 File Offset: 0x0031A808
		private void BindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
			}
		}

		// Token: 0x0600CB12 RID: 51986 RVA: 0x0031C447 File Offset: 0x0031A847
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600CB13 RID: 51987 RVA: 0x0031C44F File Offset: 0x0031A84F
		private void UnBindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CB14 RID: 51988 RVA: 0x0031C474 File Offset: 0x0031A874
		public void InitData(AuctionNewFilterData auctionNewFilterData, OnAuctionNewFilterElementItemButtonClick onButtonClick = null)
		{
			this._auctionNewFilterData = auctionNewFilterData;
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			if (this.nameText != null)
			{
				this.nameText.text = this._auctionNewFilterData.Name;
			}
			this._onButtonClick = onButtonClick;
			this.UpdateFilterElementItem();
		}

		// Token: 0x0600CB15 RID: 51989 RVA: 0x0031C4C8 File Offset: 0x0031A8C8
		private void OnButtonClick()
		{
			this._auctionNewFilterData.IsSelected = true;
			if (this._onButtonClick != null)
			{
				this._onButtonClick(this._auctionNewFilterData);
			}
			this.UpdateFilterElementItem();
		}

		// Token: 0x0600CB16 RID: 51990 RVA: 0x0031C4F8 File Offset: 0x0031A8F8
		public void UpdateFilterElementItem()
		{
			if (this._auctionNewFilterData == null)
			{
				return;
			}
			if (this.selectedFlag == null)
			{
				return;
			}
			this.selectedFlag.gameObject.CustomActive(this._auctionNewFilterData.IsSelected);
		}

		// Token: 0x040075FC RID: 30204
		private OnAuctionNewFilterElementItemButtonClick _onButtonClick;

		// Token: 0x040075FD RID: 30205
		private AuctionNewFilterData _auctionNewFilterData;

		// Token: 0x040075FE RID: 30206
		[SerializeField]
		private Text nameText;

		// Token: 0x040075FF RID: 30207
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x04007600 RID: 30208
		[SerializeField]
		private Button button;
	}
}
