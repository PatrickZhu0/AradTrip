using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F7A RID: 3962
	public class ComDropDownItem : MonoBehaviour
	{
		// Token: 0x06009941 RID: 39233 RVA: 0x001D7E0D File Offset: 0x001D620D
		private void Awake()
		{
			this._comControlData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x06009942 RID: 39234 RVA: 0x001D7E1C File Offset: 0x001D621C
		private void BindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnItemButtonClick));
			}
		}

		// Token: 0x06009943 RID: 39235 RVA: 0x001D7E5B File Offset: 0x001D625B
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06009944 RID: 39236 RVA: 0x001D7E63 File Offset: 0x001D6263
		private void UnBindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009945 RID: 39237 RVA: 0x001D7E88 File Offset: 0x001D6288
		public virtual void InitItem(ComControlData comControlData, OnComDropDownItemButtonClick onItemButtonClick = null)
		{
			this._comControlData = comControlData;
			if (this._comControlData == null)
			{
				return;
			}
			if (this.nameText != null)
			{
				if (string.IsNullOrEmpty(this._comControlData.Name))
				{
					this.nameText.text = "ERROR";
				}
				else
				{
					this.nameText.text = this._comControlData.Name;
				}
			}
			this._onItemButtonClick = onItemButtonClick;
			this.UpdateComDropDownItem();
		}

		// Token: 0x06009946 RID: 39238 RVA: 0x001D7F06 File Offset: 0x001D6306
		private void OnItemButtonClick()
		{
			this._comControlData.IsSelected = true;
			if (this._onItemButtonClick != null)
			{
				this._onItemButtonClick(this._comControlData);
			}
			this.UpdateComDropDownItem();
		}

		// Token: 0x06009947 RID: 39239 RVA: 0x001D7F36 File Offset: 0x001D6336
		public void UpdateComDropDownItem()
		{
			if (this._comControlData == null)
			{
				return;
			}
			if (this.selectedFlag == null)
			{
				return;
			}
			this.selectedFlag.gameObject.CustomActive(this._comControlData.IsSelected);
		}

		// Token: 0x04004EE7 RID: 20199
		private OnComDropDownItemButtonClick _onItemButtonClick;

		// Token: 0x04004EE8 RID: 20200
		protected ComControlData _comControlData;

		// Token: 0x04004EE9 RID: 20201
		[SerializeField]
		private Text nameText;

		// Token: 0x04004EEA RID: 20202
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x04004EEB RID: 20203
		[SerializeField]
		private Button button;
	}
}
