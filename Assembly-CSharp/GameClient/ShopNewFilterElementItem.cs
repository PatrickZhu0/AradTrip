using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A7C RID: 6780
	public class ShopNewFilterElementItem : MonoBehaviour
	{
		// Token: 0x06010A5A RID: 68186 RVA: 0x004B6D6D File Offset: 0x004B516D
		private void Awake()
		{
			this._shopNewFilterData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x06010A5B RID: 68187 RVA: 0x004B6D7C File Offset: 0x004B517C
		private void BindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
				this.button.onClick.AddListener(new UnityAction(this.OnButtonClick));
			}
		}

		// Token: 0x06010A5C RID: 68188 RVA: 0x004B6DBB File Offset: 0x004B51BB
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06010A5D RID: 68189 RVA: 0x004B6DC3 File Offset: 0x004B51C3
		private void UnBindUiEventSystem()
		{
			if (this.button != null)
			{
				this.button.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06010A5E RID: 68190 RVA: 0x004B6DE8 File Offset: 0x004B51E8
		public void InitData(ShopNewFilterData shopNewFilterData, OnShopNewFilterElementItemTabValueChanged toggleValueChanged = null)
		{
			this._shopNewFilterData = shopNewFilterData;
			if (this._shopNewFilterData == null)
			{
				return;
			}
			if (this.nameText != null)
			{
				this.nameText.text = this._shopNewFilterData.Name;
			}
			this._onToggleValueChanged = toggleValueChanged;
			this.UpdateFilterElementItem();
		}

		// Token: 0x06010A5F RID: 68191 RVA: 0x004B6E3C File Offset: 0x004B523C
		private void OnButtonClick()
		{
			this._shopNewFilterData.IsSelected = true;
			if (this._onToggleValueChanged != null)
			{
				this._onToggleValueChanged(this._shopNewFilterData);
			}
			this.UpdateFilterElementItem();
		}

		// Token: 0x06010A60 RID: 68192 RVA: 0x004B6E6C File Offset: 0x004B526C
		public void UpdateFilterElementItem()
		{
			if (this._shopNewFilterData == null)
			{
				return;
			}
			if (this.selectedFlag == null)
			{
				return;
			}
			this.selectedFlag.gameObject.CustomActive(this._shopNewFilterData.IsSelected);
		}

		// Token: 0x0400AA11 RID: 43537
		private OnShopNewFilterElementItemTabValueChanged _onToggleValueChanged;

		// Token: 0x0400AA12 RID: 43538
		private ShopNewFilterData _shopNewFilterData;

		// Token: 0x0400AA13 RID: 43539
		[SerializeField]
		private Text nameText;

		// Token: 0x0400AA14 RID: 43540
		[SerializeField]
		private Image selectedFlag;

		// Token: 0x0400AA15 RID: 43541
		[SerializeField]
		private Button button;
	}
}
