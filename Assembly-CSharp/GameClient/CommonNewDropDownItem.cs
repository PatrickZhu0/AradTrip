using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F80 RID: 3968
	public class CommonNewDropDownItem : MonoBehaviour
	{
		// Token: 0x06009960 RID: 39264 RVA: 0x001D84FA File Offset: 0x001D68FA
		private void Awake()
		{
			this._commonNewControlData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x06009961 RID: 39265 RVA: 0x001D8509 File Offset: 0x001D6909
		private void BindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnItemButtonClick));
			}
		}

		// Token: 0x06009962 RID: 39266 RVA: 0x001D8548 File Offset: 0x001D6948
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06009963 RID: 39267 RVA: 0x001D8550 File Offset: 0x001D6950
		private void UnBindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009964 RID: 39268 RVA: 0x001D8573 File Offset: 0x001D6973
		private void ClearData()
		{
			this._commonNewControlData = null;
			this._onItemButtonClick = null;
		}

		// Token: 0x06009965 RID: 39269 RVA: 0x001D8583 File Offset: 0x001D6983
		public virtual void InitItem(ComControlData comControlData, OnCommonNewDropDownItemButtonClick onItemButtonClick = null)
		{
			this._commonNewControlData = comControlData;
			if (this._commonNewControlData == null)
			{
				return;
			}
			this._onItemButtonClick = onItemButtonClick;
			this.UpdateCommonNewDropDownItemName();
			this.UpdateComDropDownItemSelectedFlag();
		}

		// Token: 0x06009966 RID: 39270 RVA: 0x001D85AC File Offset: 0x001D69AC
		private void UpdateCommonNewDropDownItemName()
		{
			if (this.nameText != null)
			{
				if (string.IsNullOrEmpty(this._commonNewControlData.Name))
				{
					this.nameText.text = "ERROR";
				}
				else
				{
					this.nameText.text = this._commonNewControlData.Name;
				}
			}
		}

		// Token: 0x06009967 RID: 39271 RVA: 0x001D860A File Offset: 0x001D6A0A
		public void UpdateComDropDownItemSelectedFlag()
		{
			if (this._commonNewControlData == null)
			{
				return;
			}
			if (this.selectedFlag == null)
			{
				return;
			}
			this.selectedFlag.gameObject.CustomActive(this._commonNewControlData.IsSelected);
		}

		// Token: 0x06009968 RID: 39272 RVA: 0x001D8645 File Offset: 0x001D6A45
		private void OnItemButtonClick()
		{
			this._commonNewControlData.IsSelected = true;
			this.UpdateComDropDownItemSelectedFlag();
			if (this._onItemButtonClick != null)
			{
				this._onItemButtonClick(this._commonNewControlData);
			}
		}

		// Token: 0x04004EFF RID: 20223
		private OnCommonNewDropDownItemButtonClick _onItemButtonClick;

		// Token: 0x04004F00 RID: 20224
		protected ComControlData _commonNewControlData;

		// Token: 0x04004F01 RID: 20225
		[SerializeField]
		private Text nameText;

		// Token: 0x04004F02 RID: 20226
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x04004F03 RID: 20227
		[SerializeField]
		private Button button;
	}
}
