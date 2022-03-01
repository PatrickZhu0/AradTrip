using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200179E RID: 6046
	public class MallNewMainTabItem : MonoBehaviour
	{
		// Token: 0x0600EE76 RID: 61046 RVA: 0x00400164 File Offset: 0x003FE564
		private void Awake()
		{
			this.InitData();
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
				this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabClicked));
			}
		}

		// Token: 0x0600EE77 RID: 61047 RVA: 0x004001B4 File Offset: 0x003FE5B4
		private void InitData()
		{
			this._isSelected = false;
			this._mainTabDataModel = null;
			this._mainTabContentView = null;
		}

		// Token: 0x0600EE78 RID: 61048 RVA: 0x004001CB File Offset: 0x003FE5CB
		private void OnDestroy()
		{
			if (this.toggle != null)
			{
				this.toggle.onValueChanged.RemoveAllListeners();
			}
			this._mainTabDataModel = null;
			this._mainTabContentView = null;
			this.mOnMallTabClick = null;
		}

		// Token: 0x0600EE79 RID: 61049 RVA: 0x00400204 File Offset: 0x003FE604
		public void Init(MallNewMainTabDataModel mainTabDataModel, OnMallTabClick onMallTabClick, bool isSelected = false)
		{
			this._mainTabDataModel = mainTabDataModel;
			this.mOnMallTabClick = onMallTabClick;
			if (this._mainTabDataModel == null)
			{
				return;
			}
			if (this.mainTabName != null)
			{
				this.mainTabName.text = this._mainTabDataModel.mainTabName;
			}
			if (isSelected && this.toggle != null)
			{
				this.toggle.isOn = true;
			}
			this.InitSpecialMainTabItem();
		}

		// Token: 0x0600EE7A RID: 61050 RVA: 0x0040027C File Offset: 0x003FE67C
		public void SetTabUiEffect(GameObject tabUiEffect)
		{
			if (this.tabUiEffectRoot != null && tabUiEffect != null)
			{
				tabUiEffect.CustomActive(true);
				tabUiEffect.transform.SetParent(this.tabUiEffectRoot.transform, false);
				tabUiEffect.transform.localPosition = new Vector3(0f, 0f, 0f);
			}
		}

		// Token: 0x0600EE7B RID: 61051 RVA: 0x004002E4 File Offset: 0x003FE6E4
		private void InitSpecialMainTabItem()
		{
			if (this._mainTabDataModel.mainTabType == MallNewType.LimitTimeMall)
			{
				if (this.hot != null)
				{
					this.hot.CustomActive(true);
				}
			}
			else if (this.hot != null)
			{
				this.hot.CustomActive(false);
			}
			if (this._mainTabDataModel.mainTabType == MallNewType.ReChargeMall)
			{
				if (this.normalImage != null)
				{
					ETCImageLoader.LoadSprite(ref this.normalImage, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01", true);
				}
				if (this.selectedImage != null)
				{
					ETCImageLoader.LoadSprite(ref this.selectedImage, "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Shuxiang_Yeqian_Xuanzhong_02", true);
				}
			}
		}

		// Token: 0x0600EE7C RID: 61052 RVA: 0x00400398 File Offset: 0x003FE798
		private void OnTabClicked(bool value)
		{
			if (this._mainTabDataModel == null)
			{
				return;
			}
			if (this._isSelected == value)
			{
				return;
			}
			this._isSelected = value;
			if (value)
			{
				if (this._mainTabDataModel.mainTabType == MallNewType.ReChargeMall)
				{
					MallNewFrame.OpenMallPayFrame();
				}
				else
				{
					MallNewFrame.CloseMallPayFrame();
					if (this._mainTabDataModel.contentRoot != null)
					{
						this._mainTabDataModel.contentRoot.CustomActive(true);
						if (this._mainTabContentView == null)
						{
							this.LoadContentView();
						}
						else
						{
							MallNewBaseView component = this._mainTabContentView.GetComponent<MallNewBaseView>();
							if (component != null)
							{
								component.OnEnableView();
							}
						}
					}
				}
				if (this._mainTabDataModel.mainTabType == MallNewType.LimitTimeMall)
				{
					Utility.DoStartFrameOperation("MallNewFrame", "LimitTimeMallBtn");
				}
				else if (this._mainTabDataModel.mainTabType == MallNewType.ExChangeMall)
				{
					Utility.DoStartFrameOperation("MallNewFrame", "ExChangeMallBtn");
				}
				else if (this._mainTabDataModel.mainTabType == MallNewType.PropertyMall)
				{
					Utility.DoStartFrameOperation("MallNewFrame", "PropertyMallBtn");
				}
			}
			else if (this._mainTabDataModel.contentRoot != null)
			{
				this._mainTabDataModel.contentRoot.CustomActive(false);
			}
			if (this.mOnMallTabClick != null)
			{
				this.mOnMallTabClick(this._mainTabDataModel);
			}
		}

		// Token: 0x0600EE7D RID: 61053 RVA: 0x00400500 File Offset: 0x003FE900
		private void LoadContentView()
		{
			UIPrefabWrapper component = this._mainTabDataModel.contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this._mainTabDataModel.contentRoot.transform, false);
					this._mainTabContentView = gameObject;
				}
			}
			if (this._mainTabContentView != null)
			{
				MallNewBaseView component2 = this._mainTabContentView.GetComponent<MallNewBaseView>();
				if (component2 != null)
				{
					component2.InitData(MallNewFrame.DefaultIndex, MallNewFrame.SecondIndex, MallNewFrame.ThirdIndex);
					MallNewFrame.DefaultIndex = 0;
					MallNewFrame.SecondIndex = 0;
					MallNewFrame.ThirdIndex = 0;
				}
			}
		}

		// Token: 0x040091DE RID: 37342
		private const string normalRechargeImagePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Anniu_Quren_Xuanzhong_01";

		// Token: 0x040091DF RID: 37343
		private const string selectedRechargeImagePath = "UI/Image/Packed/p_UI_Common00.png:UI_Tongyong_Shuxiang_Yeqian_Xuanzhong_02";

		// Token: 0x040091E0 RID: 37344
		private bool _isSelected;

		// Token: 0x040091E1 RID: 37345
		private MallNewMainTabDataModel _mainTabDataModel;

		// Token: 0x040091E2 RID: 37346
		private GameObject _mainTabContentView;

		// Token: 0x040091E3 RID: 37347
		[SerializeField]
		private Text mainTabName;

		// Token: 0x040091E4 RID: 37348
		[SerializeField]
		private Toggle toggle;

		// Token: 0x040091E5 RID: 37349
		[SerializeField]
		private GameObject hot;

		// Token: 0x040091E6 RID: 37350
		[SerializeField]
		private Image normalImage;

		// Token: 0x040091E7 RID: 37351
		[SerializeField]
		private Image selectedImage;

		// Token: 0x040091E8 RID: 37352
		[SerializeField]
		private GameObject tabUiEffectRoot;

		// Token: 0x040091E9 RID: 37353
		private OnMallTabClick mOnMallTabClick;
	}
}
