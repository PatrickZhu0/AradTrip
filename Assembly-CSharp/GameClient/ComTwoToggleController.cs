using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F31 RID: 3889
	public class ComTwoToggleController : MonoBehaviour
	{
		// Token: 0x06009797 RID: 38807 RVA: 0x001D091B File Offset: 0x001CED1B
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06009798 RID: 38808 RVA: 0x001D0923 File Offset: 0x001CED23
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06009799 RID: 38809 RVA: 0x001D0934 File Offset: 0x001CED34
		private void BindUiEvents()
		{
			if (this.firstToggle != null)
			{
				this.firstToggle.onValueChanged.RemoveAllListeners();
				this.firstToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnFirstToggleClicked));
			}
			if (this.secondToggle != null)
			{
				this.secondToggle.onValueChanged.RemoveAllListeners();
				this.secondToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnSecondToggleClicked));
			}
		}

		// Token: 0x0600979A RID: 38810 RVA: 0x001D09BC File Offset: 0x001CEDBC
		private void UnBindUiEvents()
		{
			if (this.firstToggle != null)
			{
				this.firstToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.secondToggle != null)
			{
				this.secondToggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x0600979B RID: 38811 RVA: 0x001D0A0B File Offset: 0x001CEE0B
		private void ClearData()
		{
			this._firstToggleId = 0;
			this._secondToggleId = 0;
			this._onTwoToggleClickAction = null;
			this._defaultSelectToggleId = 0;
		}

		// Token: 0x0600979C RID: 38812 RVA: 0x001D0A2C File Offset: 0x001CEE2C
		public void InitTwoToggleController(int firstToggleId, string firstToggleNameStr, int secondToggleId, string secondToggleNameStr, OnTwoToggleClickAction onTwoToggleClickAction, int defaultSelectToggleId = 0)
		{
			this._firstToggleId = firstToggleId;
			if (this._firstToggleId <= 0)
			{
				this._firstToggleId = 1;
			}
			this._firstToggleNameStr = firstToggleNameStr;
			this._secondToggleId = secondToggleId;
			if (this._secondToggleId <= 0)
			{
				this._secondToggleId = 2;
			}
			this._secondToggleNameStr = secondToggleNameStr;
			this._onTwoToggleClickAction = onTwoToggleClickAction;
			this.InitTwoToggleView();
		}

		// Token: 0x0600979D RID: 38813 RVA: 0x001D0A8C File Offset: 0x001CEE8C
		private void InitTwoToggleView()
		{
			if (this.firstToggleNormalLabel != null)
			{
				this.firstToggleNormalLabel.text = this._firstToggleNameStr;
			}
			if (this.firstToggleSelectLabel != null)
			{
				this.firstToggleSelectLabel.text = this._firstToggleNameStr;
			}
			if (this.secondToggleNormalLabel != null)
			{
				this.secondToggleNormalLabel.text = this._secondToggleNameStr;
			}
			if (this.secondToggleSelectLabel != null)
			{
				this.secondToggleSelectLabel.text = this._secondToggleNameStr;
			}
			if (this._defaultSelectToggleId == this._secondToggleId)
			{
				if (this.secondToggle != null)
				{
					this.secondToggle.isOn = false;
					this.secondToggle.isOn = true;
				}
			}
			else if (this.firstToggle != null)
			{
				this.firstToggle.isOn = false;
				this.firstToggle.isOn = true;
			}
		}

		// Token: 0x0600979E RID: 38814 RVA: 0x001D0B89 File Offset: 0x001CEF89
		private void OnFirstToggleClicked(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this._onTwoToggleClickAction == null)
			{
				return;
			}
			this._onTwoToggleClickAction(this._firstToggleId);
		}

		// Token: 0x0600979F RID: 38815 RVA: 0x001D0BAF File Offset: 0x001CEFAF
		private void OnSecondToggleClicked(bool value)
		{
			if (!value)
			{
				return;
			}
			if (this._onTwoToggleClickAction == null)
			{
				return;
			}
			this._onTwoToggleClickAction(this._secondToggleId);
		}

		// Token: 0x04004E2B RID: 20011
		private int _firstToggleId;

		// Token: 0x04004E2C RID: 20012
		private int _secondToggleId;

		// Token: 0x04004E2D RID: 20013
		private string _firstToggleNameStr;

		// Token: 0x04004E2E RID: 20014
		private string _secondToggleNameStr;

		// Token: 0x04004E2F RID: 20015
		private OnTwoToggleClickAction _onTwoToggleClickAction;

		// Token: 0x04004E30 RID: 20016
		private int _defaultSelectToggleId;

		// Token: 0x04004E31 RID: 20017
		[Space(15f)]
		[Header("firstToggle")]
		[Space(15f)]
		[SerializeField]
		private Toggle firstToggle;

		// Token: 0x04004E32 RID: 20018
		[SerializeField]
		private Text firstToggleNormalLabel;

		// Token: 0x04004E33 RID: 20019
		[SerializeField]
		private Text firstToggleSelectLabel;

		// Token: 0x04004E34 RID: 20020
		[Space(15f)]
		[Header("secondToggle")]
		[Space(15f)]
		[SerializeField]
		private Toggle secondToggle;

		// Token: 0x04004E35 RID: 20021
		[SerializeField]
		private Text secondToggleNormalLabel;

		// Token: 0x04004E36 RID: 20022
		[SerializeField]
		private Text secondToggleSelectLabel;
	}
}
