using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200147B RID: 5243
	public class AuctionNewSecondLayerTabItem : MonoBehaviour
	{
		// Token: 0x0600CB53 RID: 52051 RVA: 0x0031D1FF File Offset: 0x0031B5FF
		private void Awake()
		{
			if (this.tabToggle != null)
			{
				this.tabToggle.onValueChanged.RemoveAllListeners();
				this.tabToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600CB54 RID: 52052 RVA: 0x0031D23E File Offset: 0x0031B63E
		private void OnDestroy()
		{
			if (this.tabToggle != null)
			{
				this.tabToggle.onValueChanged.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x0600CB55 RID: 52053 RVA: 0x0031D267 File Offset: 0x0031B667
		private void ResetData()
		{
			this._isSelected = false;
			this._firstLayerTabDataModel = null;
			this._secondLayerTabDataModel = null;
			this._onSecondLayerTabToggleClick = null;
		}

		// Token: 0x0600CB56 RID: 52054 RVA: 0x0031D288 File Offset: 0x0031B688
		public void InitTabItem(AuctionNewMenuTabDataModel firstLayerTabDataModel, AuctionNewMenuTabDataModel secondLayerTabDataModel, bool isSelected = false, OnSecondLayerTabToggleClick onSecondLayerTabToggleClick = null)
		{
			this.ResetData();
			this._firstLayerTabDataModel = firstLayerTabDataModel;
			this._secondLayerTabDataModel = secondLayerTabDataModel;
			this._onSecondLayerTabToggleClick = onSecondLayerTabToggleClick;
			if (this._secondLayerTabDataModel == null)
			{
				return;
			}
			if (this._secondLayerTabDataModel.AuctionNewFrameTable == null)
			{
				return;
			}
			if (this.tabName != null)
			{
				this.tabName.text = this._secondLayerTabDataModel.AuctionNewFrameTable.Name;
			}
			if (this.selectedTabName != null)
			{
				this.selectedTabName.text = this._secondLayerTabDataModel.AuctionNewFrameTable.Name;
			}
			if (isSelected && this.tabToggle != null)
			{
				this.tabToggle.isOn = true;
			}
		}

		// Token: 0x0600CB57 RID: 52055 RVA: 0x0031D34C File Offset: 0x0031B74C
		private void OnTabClicked(bool value)
		{
			if (this._secondLayerTabDataModel == null || this._secondLayerTabDataModel.AuctionNewFrameTable == null)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onSecondLayerTabToggleClick != null)
			{
				this._onSecondLayerTabToggleClick(this._firstLayerTabDataModel, this._secondLayerTabDataModel);
			}
		}

		// Token: 0x0600CB58 RID: 52056 RVA: 0x0031D3A4 File Offset: 0x0031B7A4
		public void OnEnabelTabItem()
		{
			if (this._isSelected && this._onSecondLayerTabToggleClick != null)
			{
				this._onSecondLayerTabToggleClick(this._firstLayerTabDataModel, this._secondLayerTabDataModel);
			}
		}

		// Token: 0x04007622 RID: 30242
		private bool _isSelected;

		// Token: 0x04007623 RID: 30243
		private AuctionNewMenuTabDataModel _firstLayerTabDataModel;

		// Token: 0x04007624 RID: 30244
		private AuctionNewMenuTabDataModel _secondLayerTabDataModel;

		// Token: 0x04007625 RID: 30245
		private OnSecondLayerTabToggleClick _onSecondLayerTabToggleClick;

		// Token: 0x04007626 RID: 30246
		[Space(10f)]
		[Header("SecondLayerTab")]
		[Space(5f)]
		[SerializeField]
		private Text tabName;

		// Token: 0x04007627 RID: 30247
		[SerializeField]
		private Text selectedTabName;

		// Token: 0x04007628 RID: 30248
		[SerializeField]
		private Toggle tabToggle;
	}
}
