using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001787 RID: 6023
	public class FashionMallPositionTabItem : MonoBehaviour
	{
		// Token: 0x0600EDC2 RID: 60866 RVA: 0x003FBF3F File Offset: 0x003FA33F
		private void Awake()
		{
			this._isSelected = false;
			this._positionTabData = null;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EDC3 RID: 60867 RVA: 0x003FBF55 File Offset: 0x003FA355
		private void BindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600EDC4 RID: 60868 RVA: 0x003FBF94 File Offset: 0x003FA394
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600EDC5 RID: 60869 RVA: 0x003FBF9C File Offset: 0x003FA39C
		private void UnBindUiEventSystem()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
		}

		// Token: 0x0600EDC6 RID: 60870 RVA: 0x003FBFC0 File Offset: 0x003FA3C0
		public void InitData(FashionMallPositionTabData positionTabData, OnFashionMallPositionTabValueChanged toggleValueChanged = null, bool isSelected = false)
		{
			this._isSelected = false;
			this._positionTabData = positionTabData;
			if (this._positionTabData == null)
			{
				return;
			}
			this.InitTabItemImage();
			this._onToggleValueChanged = toggleValueChanged;
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
		}

		// Token: 0x0600EDC7 RID: 60871 RVA: 0x003FC018 File Offset: 0x003FA418
		private void InitTabItemImage()
		{
			string path = string.Empty;
			string path2 = string.Empty;
			switch (this._positionTabData.PositionTabType)
			{
			case FashionMallPositionTabType.Head:
				path = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Toufa_");
				path2 = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Toufa_Xuanzhong");
				break;
			case FashionMallPositionTabType.Clothes:
				path = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Shangyi");
				path2 = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Shangyi_Xuanzhong");
				break;
			case FashionMallPositionTabType.Plastron:
				path = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "Lianyiqun");
				path2 = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "Lianyiqun_Xuanzhong");
				break;
			case FashionMallPositionTabType.Trousers:
				path = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Kuzi_");
				path2 = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Kuzi_Xuanzhong");
				break;
			case FashionMallPositionTabType.Waist:
				path = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Yaodai");
				path2 = string.Format("UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}", "_Yaodai_Xuanzhong");
				break;
			}
			ETCImageLoader.LoadSprite(ref this.normalImage, path, true);
			ETCImageLoader.LoadSprite(ref this.selectedImage, path2, true);
		}

		// Token: 0x0600EDC8 RID: 60872 RVA: 0x003FC134 File Offset: 0x003FA534
		private void OnTabClicked(bool value)
		{
			if (this._positionTabData == null)
			{
				return;
			}
			this._isSelected = value;
			if (value && this._onToggleValueChanged != null)
			{
				this._onToggleValueChanged(this._positionTabData.Index, this._positionTabData.PositionTabType);
			}
		}

		// Token: 0x04009138 RID: 37176
		private const string ImagePath = "UI/Image/Packed/p_UI_Shop.png:UI_Shop_Tubiao{0}";

		// Token: 0x04009139 RID: 37177
		private OnFashionMallPositionTabValueChanged _onToggleValueChanged;

		// Token: 0x0400913A RID: 37178
		private bool _isSelected;

		// Token: 0x0400913B RID: 37179
		private FashionMallPositionTabData _positionTabData;

		// Token: 0x0400913C RID: 37180
		[SerializeField]
		private Toggle toggle;

		// Token: 0x0400913D RID: 37181
		[SerializeField]
		private Image normalImage;

		// Token: 0x0400913E RID: 37182
		[SerializeField]
		private Image selectedImage;
	}
}
