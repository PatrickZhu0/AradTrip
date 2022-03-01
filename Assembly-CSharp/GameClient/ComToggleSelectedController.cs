using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000EAC RID: 3756
	public class ComToggleSelectedController : MonoBehaviour
	{
		// Token: 0x06009449 RID: 37961 RVA: 0x001BCB9C File Offset: 0x001BAF9C
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600944A RID: 37962 RVA: 0x001BCBA4 File Offset: 0x001BAFA4
		private void BindEvents()
		{
			if (this.toggleButton != null)
			{
				this.toggleButton.onClick.RemoveAllListeners();
				this.toggleButton.onClick.AddListener(new UnityAction(this.OnToggleButtonClick));
			}
		}

		// Token: 0x0600944B RID: 37963 RVA: 0x001BCBE3 File Offset: 0x001BAFE3
		private void OnDestroy()
		{
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x0600944C RID: 37964 RVA: 0x001BCBF1 File Offset: 0x001BAFF1
		private void UnBindEvents()
		{
			if (this.toggleButton != null)
			{
				this.toggleButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600944D RID: 37965 RVA: 0x001BCC14 File Offset: 0x001BB014
		private void ResetData()
		{
			this._isToggleSelected = false;
			this._onToggleSelectedClick = null;
		}

		// Token: 0x0600944E RID: 37966 RVA: 0x001BCC24 File Offset: 0x001BB024
		public void InitToggleSelectedController(bool isToggleSelected, string labelStr, OnToggleSelectedClicked onToggleClicked)
		{
			this._isToggleSelected = isToggleSelected;
			this._onToggleSelectedClick = onToggleClicked;
			this._labelStr = labelStr;
			this.InitControllerView();
		}

		// Token: 0x0600944F RID: 37967 RVA: 0x001BCC41 File Offset: 0x001BB041
		private void InitControllerView()
		{
			if (this.toggleLabel != null)
			{
				this.toggleLabel.text = this._labelStr;
			}
			this.UpdateSelectedFlag();
		}

		// Token: 0x06009450 RID: 37968 RVA: 0x001BCC6B File Offset: 0x001BB06B
		private void OnToggleButtonClick()
		{
			this._isToggleSelected = !this._isToggleSelected;
			this.UpdateSelectedFlag();
			if (this._onToggleSelectedClick != null)
			{
				this._onToggleSelectedClick(this._isToggleSelected);
			}
		}

		// Token: 0x06009451 RID: 37969 RVA: 0x001BCC9E File Offset: 0x001BB09E
		private void UpdateSelectedFlag()
		{
			if (this.selectedFlag != null)
			{
				this.selectedFlag.gameObject.CustomActive(this._isToggleSelected);
			}
		}

		// Token: 0x04004B10 RID: 19216
		private bool _isToggleSelected;

		// Token: 0x04004B11 RID: 19217
		private OnToggleSelectedClicked _onToggleSelectedClick;

		// Token: 0x04004B12 RID: 19218
		private string _labelStr;

		// Token: 0x04004B13 RID: 19219
		[SerializeField]
		private Text toggleLabel;

		// Token: 0x04004B14 RID: 19220
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x04004B15 RID: 19221
		[SerializeField]
		private Button toggleButton;
	}
}
