using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A84 RID: 6788
	public class ShopNewMainTabItem : MonoBehaviour
	{
		// Token: 0x06010A76 RID: 68214 RVA: 0x004B71DD File Offset: 0x004B55DD
		private void Awake()
		{
			this._isSelected = false;
			this._mainTabIndex = 0;
			this._shopNewMainTabData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x06010A77 RID: 68215 RVA: 0x004B71FA File Offset: 0x004B55FA
		private void BindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x06010A78 RID: 68216 RVA: 0x004B7239 File Offset: 0x004B5639
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06010A79 RID: 68217 RVA: 0x004B7241 File Offset: 0x004B5641
		private void UnBindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x06010A7A RID: 68218 RVA: 0x004B7264 File Offset: 0x004B5664
		public void InitData(int index, ShopNewMainTabData shopNewMainTabData, OnShopMainTabClickCallBack toggleValueChanged = null, bool isSelected = false)
		{
			this._mainTabIndex = index;
			this._isSelected = false;
			this._shopNewMainTabData = shopNewMainTabData;
			if (this._shopNewMainTabData == null)
			{
				return;
			}
			if (this.nameText != null)
			{
				this.nameText.text = this._shopNewMainTabData.Name;
			}
			if (this.selectedNameText != null)
			{
				this.selectedNameText.text = this._shopNewMainTabData.Name;
			}
			this._onToggleValueChanged = toggleValueChanged;
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x06010A7B RID: 68219 RVA: 0x004B730C File Offset: 0x004B570C
		private void OnTabClicked(bool value)
		{
			if (this._shopNewMainTabData == null)
			{
				Logger.LogErrorFormat("SHopNewMainTabItem OnTabClicked and tabData is null", new object[0]);
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onToggleValueChanged != null)
			{
				this._onToggleValueChanged(this._mainTabIndex, this._shopNewMainTabData);
			}
		}

		// Token: 0x0400AA27 RID: 43559
		private int _mainTabIndex;

		// Token: 0x0400AA28 RID: 43560
		private OnShopMainTabClickCallBack _onToggleValueChanged;

		// Token: 0x0400AA29 RID: 43561
		private bool _isSelected;

		// Token: 0x0400AA2A RID: 43562
		private ShopNewMainTabData _shopNewMainTabData;

		// Token: 0x0400AA2B RID: 43563
		[SerializeField]
		private Text nameText;

		// Token: 0x0400AA2C RID: 43564
		[SerializeField]
		private Text selectedNameText;

		// Token: 0x0400AA2D RID: 43565
		[SerializeField]
		private Toggle toggle;
	}
}
