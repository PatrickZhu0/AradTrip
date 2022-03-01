using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200177F RID: 6015
	public class FashionMallClothTabItem : MonoBehaviour
	{
		// Token: 0x0600ED9C RID: 60828 RVA: 0x003FB6A9 File Offset: 0x003F9AA9
		private void Awake()
		{
			this._isSelected = false;
			this._clothTabData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600ED9D RID: 60829 RVA: 0x003FB6BF File Offset: 0x003F9ABF
		private void BindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600ED9E RID: 60830 RVA: 0x003FB6FE File Offset: 0x003F9AFE
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600ED9F RID: 60831 RVA: 0x003FB706 File Offset: 0x003F9B06
		private void UnBindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x0600EDA0 RID: 60832 RVA: 0x003FB72C File Offset: 0x003F9B2C
		public void InitData(FashionMallClothTabData clothTabData, OnFashionMallClothTabValueChanged toggleValueChanged = null, bool isSelected = false)
		{
			this._isSelected = false;
			this._clothTabData = clothTabData;
			if (this._clothTabData == null)
			{
				return;
			}
			if (this.nameText != null)
			{
				this.nameText.text = this._clothTabData.Name;
			}
			this.InitSpecialImage();
			this._onToggleValueChanged = toggleValueChanged;
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600EDA1 RID: 60833 RVA: 0x003FB7AC File Offset: 0x003F9BAC
		private void InitSpecialImage()
		{
			if (this.specialImage != null)
			{
				if (this._clothTabData.ClothTabType == FashionMallClothTabType.Weapon)
				{
					this.specialImage.gameObject.CustomActive(true);
				}
				else
				{
					this.specialImage.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x0600EDA2 RID: 60834 RVA: 0x003FB804 File Offset: 0x003F9C04
		private void OnTabClicked(bool value)
		{
			if (this._clothTabData == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onToggleValueChanged != null)
			{
				this._onToggleValueChanged(this._clothTabData.Index, this._clothTabData.ClothTabType, this._clothTabData.MallTableId);
			}
		}

		// Token: 0x0400910D RID: 37133
		private OnFashionMallClothTabValueChanged _onToggleValueChanged;

		// Token: 0x0400910E RID: 37134
		private bool _isSelected;

		// Token: 0x0400910F RID: 37135
		private FashionMallClothTabData _clothTabData;

		// Token: 0x04009110 RID: 37136
		[SerializeField]
		private Text nameText;

		// Token: 0x04009111 RID: 37137
		[SerializeField]
		private Toggle toggle;

		// Token: 0x04009112 RID: 37138
		[SerializeField]
		private Image specialImage;
	}
}
