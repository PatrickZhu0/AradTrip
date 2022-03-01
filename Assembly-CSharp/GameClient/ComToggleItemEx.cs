using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F36 RID: 3894
	public class ComToggleItemEx : MonoBehaviour
	{
		// Token: 0x060097B4 RID: 38836 RVA: 0x001D0E98 File Offset: 0x001CF298
		private void Awake()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleClick));
			}
			if (this.disableButton != null)
			{
				this.disableButton.onClick.RemoveAllListeners();
				this.disableButton.onClick.AddListener(new UnityAction(this.OnDisableButtonClick));
			}
		}

		// Token: 0x060097B5 RID: 38837 RVA: 0x001D0F20 File Offset: 0x001CF320
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			if (this.disableButton != null)
			{
				this.disableButton.onClick.RemoveAllListeners();
			}
			this.ResetData();
		}

		// Token: 0x060097B6 RID: 38838 RVA: 0x001D0F75 File Offset: 0x001CF375
		private void ResetData()
		{
			this._comToggleDataEx = null;
			this._onComToggleItemExClick = null;
			this._onComToggleItemExButtonClick = null;
		}

		// Token: 0x060097B7 RID: 38839 RVA: 0x001D0F8C File Offset: 0x001CF38C
		public virtual void InitItem(ComControlDataEx comToggleDataEx, OnComToggleItemExClick onComToggleItemExClick = null, OnComToggleItemExButtonClick onComToggleItemExButtonClick = null)
		{
			this.ResetData();
			this._comToggleDataEx = comToggleDataEx;
			this._onComToggleItemExClick = onComToggleItemExClick;
			this._onComToggleItemExButtonClick = onComToggleItemExButtonClick;
			if (this._comToggleDataEx == null)
			{
				Logger.LogErrorFormat("ComToggleItemEx InitItem comToggleDataEx is null", new object[0]);
				return;
			}
			this.InitItemView();
		}

		// Token: 0x060097B8 RID: 38840 RVA: 0x001D0FCC File Offset: 0x001CF3CC
		protected virtual void InitItemView()
		{
			if (this.normalName != null)
			{
				this.normalName.text = this._comToggleDataEx.Name;
			}
			if (this.selectedName != null)
			{
				this.selectedName.text = this._comToggleDataEx.Name;
			}
			if (this.disableButtonLabel != null)
			{
				this.disableButtonLabel.text = this._comToggleDataEx.Name;
			}
			if (this.toggle != null)
			{
				if (this._comToggleDataEx.IsSelected)
				{
					if (this.toggle.isOn)
					{
						this.toggle.isOn = false;
					}
					this.toggle.isOn = true;
				}
				else
				{
					this.toggle.isOn = false;
				}
			}
			CommonUtility.UpdateButtonVisible(this.disableButton, this._comToggleDataEx.IsToggleDisabled);
		}

		// Token: 0x060097B9 RID: 38841 RVA: 0x001D10C0 File Offset: 0x001CF4C0
		private void OnToggleClick(bool value)
		{
			if (this._comToggleDataEx == null)
			{
				return;
			}
			if (this._comToggleDataEx.IsToggleDisabled)
			{
				return;
			}
			this._comToggleDataEx.IsSelected = value;
			if (value && this._onComToggleItemExClick != null)
			{
				this._onComToggleItemExClick(this._comToggleDataEx);
			}
		}

		// Token: 0x060097BA RID: 38842 RVA: 0x001D1118 File Offset: 0x001CF518
		private void OnDisableButtonClick()
		{
			if (this._comToggleDataEx == null)
			{
				return;
			}
			if (!this._comToggleDataEx.IsToggleDisabled)
			{
				return;
			}
			if (this._onComToggleItemExButtonClick != null)
			{
				this._onComToggleItemExButtonClick(this._comToggleDataEx);
			}
		}

		// Token: 0x060097BB RID: 38843 RVA: 0x001D1154 File Offset: 0x001CF554
		public void OnEnableComToggleItem()
		{
			if (this._comToggleDataEx == null)
			{
				return;
			}
			if (this._comToggleDataEx.IsToggleDisabled)
			{
				return;
			}
			if (this._onComToggleItemExClick != null && this._comToggleDataEx.IsSelected && this._onComToggleItemExClick != null)
			{
				this._onComToggleItemExClick(this._comToggleDataEx);
			}
		}

		// Token: 0x060097BC RID: 38844 RVA: 0x001D11B5 File Offset: 0x001CF5B5
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x04004E40 RID: 20032
		protected ComControlDataEx _comToggleDataEx;

		// Token: 0x04004E41 RID: 20033
		private OnComToggleItemExClick _onComToggleItemExClick;

		// Token: 0x04004E42 RID: 20034
		private OnComToggleItemExButtonClick _onComToggleItemExButtonClick;

		// Token: 0x04004E43 RID: 20035
		[Space(10f)]
		[Header("ComToggleItemEx")]
		[Space(5f)]
		[SerializeField]
		private Text normalName;

		// Token: 0x04004E44 RID: 20036
		[SerializeField]
		private Text selectedName;

		// Token: 0x04004E45 RID: 20037
		[SerializeField]
		private Toggle toggle;

		// Token: 0x04004E46 RID: 20038
		[Space(10f)]
		[Header("DisableButton")]
		[Space(5f)]
		[SerializeField]
		private Button disableButton;

		// Token: 0x04004E47 RID: 20039
		[SerializeField]
		private Text disableButtonLabel;
	}
}
