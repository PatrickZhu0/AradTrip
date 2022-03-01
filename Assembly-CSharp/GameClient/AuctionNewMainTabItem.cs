using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001463 RID: 5219
	public class AuctionNewMainTabItem : MonoBehaviour
	{
		// Token: 0x0600CA58 RID: 51800 RVA: 0x003184B3 File Offset: 0x003168B3
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600CA59 RID: 51801 RVA: 0x003184F2 File Offset: 0x003168F2
		private void ResetData()
		{
			this._isSelected = false;
			this._mainTabDataModel = null;
			this._onMainTabClicked = null;
		}

		// Token: 0x0600CA5A RID: 51802 RVA: 0x00318509 File Offset: 0x00316909
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600CA5B RID: 51803 RVA: 0x00318534 File Offset: 0x00316934
		public void Init(AuctionNewMainTabDataModel mainTabDataModel, OnAuctionMainTabClicked onAuctionMainTabClicked, bool isSelected = false)
		{
			this.ResetData();
			this._mainTabDataModel = mainTabDataModel;
			if (this._mainTabDataModel == null)
			{
				return;
			}
			this._onMainTabClicked = onAuctionMainTabClicked;
			if (this.selectedTabName != null && !string.IsNullOrEmpty(this._mainTabDataModel.mainTabName))
			{
				this.selectedTabName.text = TR.Value(this._mainTabDataModel.mainTabName);
			}
			if (this.normalTabName != null && !string.IsNullOrEmpty(this._mainTabDataModel.mainTabName))
			{
				this.normalTabName.text = TR.Value(this._mainTabDataModel.mainTabName);
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600CA5C RID: 51804 RVA: 0x00318608 File Offset: 0x00316A08
		private void OnTabClicked(bool value)
		{
			if (this._mainTabDataModel == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onMainTabClicked != null)
			{
				this._onMainTabClicked(this._mainTabDataModel.mainTabType);
			}
		}

		// Token: 0x04007577 RID: 30071
		private bool _isSelected;

		// Token: 0x04007578 RID: 30072
		private AuctionNewMainTabDataModel _mainTabDataModel;

		// Token: 0x04007579 RID: 30073
		private OnAuctionMainTabClicked _onMainTabClicked;

		// Token: 0x0400757A RID: 30074
		[SerializeField]
		private Text selectedTabName;

		// Token: 0x0400757B RID: 30075
		[SerializeField]
		private Text normalTabName;

		// Token: 0x0400757C RID: 30076
		[SerializeField]
		private Toggle toggle;
	}
}
