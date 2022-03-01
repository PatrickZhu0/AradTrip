using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001481 RID: 5249
	public class AuctionNewToggleSelectedController : MonoBehaviour
	{
		// Token: 0x0600CB90 RID: 52112 RVA: 0x0031E654 File Offset: 0x0031CA54
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CB91 RID: 52113 RVA: 0x0031E65C File Offset: 0x0031CA5C
		private void BindEvents()
		{
			if (this.toggleButton != null)
			{
				this.toggleButton.onClick.RemoveAllListeners();
				this.toggleButton.onClick.AddListener(new UnityAction(this.OnToggleButtonClick));
			}
		}

		// Token: 0x0600CB92 RID: 52114 RVA: 0x0031E69B File Offset: 0x0031CA9B
		private void OnDestroy()
		{
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x0600CB93 RID: 52115 RVA: 0x0031E6A9 File Offset: 0x0031CAA9
		private void UnBindEvents()
		{
			if (this.toggleButton != null)
			{
				this.toggleButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CB94 RID: 52116 RVA: 0x0031E6CC File Offset: 0x0031CACC
		private void ResetData()
		{
			this._isToggleSelected = false;
			this._onToggleSelectedClick = null;
			this._curInterval = 0f;
		}

		// Token: 0x0600CB95 RID: 52117 RVA: 0x0031E6E7 File Offset: 0x0031CAE7
		public void InitToggleSelectedController(bool isToggleSelected, string labelStr, OnToggleSelectedClicked onToggleClicked)
		{
			this._isToggleSelected = isToggleSelected;
			this._onToggleSelectedClick = onToggleClicked;
			this._labelStr = labelStr;
			this.InitControllerView();
		}

		// Token: 0x0600CB96 RID: 52118 RVA: 0x0031E704 File Offset: 0x0031CB04
		private void InitControllerView()
		{
			if (this.toggleLabel != null)
			{
				this.toggleLabel.text = this._labelStr;
			}
			this.UpdateSelectedFlag();
		}

		// Token: 0x0600CB97 RID: 52119 RVA: 0x0031E72E File Offset: 0x0031CB2E
		private void UpdateSelectedFlag()
		{
			if (this.selectedFlag != null)
			{
				this.selectedFlag.gameObject.CustomActive(this._isToggleSelected);
			}
		}

		// Token: 0x0600CB98 RID: 52120 RVA: 0x0031E757 File Offset: 0x0031CB57
		private void OnToggleButtonClick()
		{
			this._isToggleSelected = !this._isToggleSelected;
			this.UpdateSelectedFlag();
			if (this._onToggleSelectedClick != null)
			{
				this._onToggleSelectedClick(this._isToggleSelected);
			}
			this.SetButtonTimeLimit();
		}

		// Token: 0x0600CB99 RID: 52121 RVA: 0x0031E790 File Offset: 0x0031CB90
		private void SetButtonTimeLimit()
		{
			if (this.buttonClickInterval > 0f)
			{
				this.UpdateButtonState(false);
				this._curInterval = this.buttonClickInterval;
				base.StartCoroutine(this.StartCountDown());
			}
		}

		// Token: 0x0600CB9A RID: 52122 RVA: 0x0031E7C4 File Offset: 0x0031CBC4
		private IEnumerator StartCountDown()
		{
			while (this._curInterval > 0f)
			{
				this._curInterval -= 0.1f;
				yield return new WaitForSeconds(0.1f);
			}
			this.UpdateButtonState(true);
			yield break;
		}

		// Token: 0x0600CB9B RID: 52123 RVA: 0x0031E7DF File Offset: 0x0031CBDF
		private void UpdateButtonState(bool flag)
		{
			if (this.toggleButton != null)
			{
				this.toggleButton.interactable = flag;
			}
		}

		// Token: 0x0600CB9C RID: 52124 RVA: 0x0031E7FE File Offset: 0x0031CBFE
		public void ResetAuctionNewToggleSelectedController()
		{
			this.StopCountDown();
			this.UpdateButtonState(true);
		}

		// Token: 0x0600CB9D RID: 52125 RVA: 0x0031E80D File Offset: 0x0031CC0D
		public void StopCountDown()
		{
			base.StopCoroutine(this.StartCountDown());
		}

		// Token: 0x04007648 RID: 30280
		private bool _isToggleSelected;

		// Token: 0x04007649 RID: 30281
		private OnToggleSelectedClicked _onToggleSelectedClick;

		// Token: 0x0400764A RID: 30282
		private string _labelStr;

		// Token: 0x0400764B RID: 30283
		private float _curInterval;

		// Token: 0x0400764C RID: 30284
		[SerializeField]
		private Text toggleLabel;

		// Token: 0x0400764D RID: 30285
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x0400764E RID: 30286
		[SerializeField]
		private Button toggleButton;

		// Token: 0x0400764F RID: 30287
		[SerializeField]
		private float buttonClickInterval = 0.5f;
	}
}
