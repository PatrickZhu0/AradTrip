using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BAA RID: 7082
	public class SmithShopNewSecondTabItem : MonoBehaviour
	{
		// Token: 0x0601158A RID: 71050 RVA: 0x005042A5 File Offset: 0x005026A5
		private void Awake()
		{
			if (this.mTabToggle != null)
			{
				this.mTabToggle.onValueChanged.RemoveAllListeners();
				this.mTabToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabToggleClick));
			}
		}

		// Token: 0x0601158B RID: 71051 RVA: 0x005042E4 File Offset: 0x005026E4
		private void OnDestroy()
		{
			this.ResetData();
		}

		// Token: 0x0601158C RID: 71052 RVA: 0x005042EC File Offset: 0x005026EC
		private void ResetData()
		{
			this.mMainTabDataModel = null;
			this.mSecondTabDataModel = null;
			this.isSelected = false;
			this.mOnSecondTabToggleClick = null;
			this.mTabContentView = null;
			this.mLinkData = null;
		}

		// Token: 0x0601158D RID: 71053 RVA: 0x00504318 File Offset: 0x00502718
		public void InitTabItem(SmithShopNewMainTabDataModel mainTabDataModel, SecondTabDataModel secondTabDataModel, bool isSelected, StrengthenGrowthView view, SmithShopNewLinkData linkData, OnSecondTabToggleClick onSecondTabToggleClick)
		{
			this.ResetData();
			this.mMainTabDataModel = mainTabDataModel;
			this.mSecondTabDataModel = secondTabDataModel;
			this.mStrengthenGrowthView = view;
			this.mLinkData = linkData;
			this.mOnSecondTabToggleClick = onSecondTabToggleClick;
			if (this.mSecondTabDataModel == null || this.mMainTabDataModel == null)
			{
				return;
			}
			this.SetTabName(this.mSecondTabDataModel.name);
			if (isSelected && this.mTabToggle != null)
			{
				this.mTabToggle.isOn = true;
			}
		}

		// Token: 0x0601158E RID: 71054 RVA: 0x0050439C File Offset: 0x0050279C
		private void SetTabName(string name)
		{
			if (this.mTabName != null)
			{
				this.mTabName.text = name;
			}
			if (this.mSelectedTabName != null)
			{
				this.mSelectedTabName.text = name;
			}
		}

		// Token: 0x0601158F RID: 71055 RVA: 0x005043D8 File Offset: 0x005027D8
		private void OnTabToggleClick(bool value)
		{
			if (this.mSecondTabDataModel == null)
			{
				return;
			}
			if (this.isSelected == value)
			{
				return;
			}
			this.isSelected = value;
			if (value)
			{
				if (this.mSecondTabDataModel.content != null)
				{
					this.mSecondTabDataModel.content.CustomActive(true);
				}
				if (this.mTabContentView == null)
				{
					this.LoadContentView();
				}
				else if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_GROWTH)
				{
					ISmithShopNewView component = this.mTabContentView.GetComponent<ISmithShopNewView>();
					if (component != null)
					{
						component.OnEnableView();
					}
				}
				else
				{
					StrengthGrowthBaseView component2 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
					if (component2 != null)
					{
						component2.OnEnableView();
					}
				}
				if (this.mOnSecondTabToggleClick != null)
				{
					this.mOnSecondTabToggleClick(this.mMainTabDataModel, this.mSecondTabDataModel);
				}
			}
			else
			{
				if (this.mSecondTabDataModel.content != null)
				{
					this.mSecondTabDataModel.content.CustomActive(false);
				}
				if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_GROWTH)
				{
					ISmithShopNewView component3 = this.mTabContentView.GetComponent<ISmithShopNewView>();
					if (component3 != null)
					{
						component3.OnDisableView();
					}
				}
				else
				{
					StrengthGrowthBaseView component4 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
					if (component4 != null)
					{
						component4.OnDisableView();
					}
				}
			}
		}

		// Token: 0x06011590 RID: 71056 RVA: 0x00504534 File Offset: 0x00502934
		private void LoadContentView()
		{
			UIPrefabWrapper component = this.mSecondTabDataModel.content.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.mSecondTabDataModel.content.transform, false);
					this.mTabContentView = gameObject;
				}
			}
			if (this.mTabContentView != null)
			{
				if (this.mMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_GROWTH)
				{
					StrengthGrowthBaseView component2 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
					StrengthenGrowthType type = StrengthenGrowthType.SGT_NONE;
					if (this.mSecondTabDataModel.index == 0)
					{
						type = StrengthenGrowthType.SGT_Gtowth;
					}
					else if (this.mSecondTabDataModel.index == 1)
					{
						type = StrengthenGrowthType.SGT_Clear;
					}
					else if (this.mSecondTabDataModel.index == 2)
					{
						type = StrengthenGrowthType.SGT_Activate;
					}
					else if (this.mSecondTabDataModel.index == 3)
					{
						type = StrengthenGrowthType.SGT_Change;
					}
					if (component2 != null)
					{
						component2.IniteData(this.mLinkData, type, this.mStrengthenGrowthView);
					}
				}
				else
				{
					ISmithShopNewView component3 = this.mTabContentView.GetComponent<ISmithShopNewView>();
					if (component3 != null)
					{
						component3.InitView(this.mLinkData);
					}
				}
			}
		}

		// Token: 0x06011591 RID: 71057 RVA: 0x00504664 File Offset: 0x00502A64
		public void OnEnabelTabItem(bool value = true)
		{
			if (this.isSelected)
			{
				if (value)
				{
					if (this.mSecondTabDataModel != null)
					{
						this.mSecondTabDataModel.content.CustomActive(true);
					}
					if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_GROWTH)
					{
						ISmithShopNewView component = this.mTabContentView.GetComponent<ISmithShopNewView>();
						if (component != null)
						{
							component.OnEnableView();
						}
					}
					else
					{
						StrengthGrowthBaseView component2 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
						if (component2 != null)
						{
							component2.OnEnableView();
						}
					}
					if (this.mOnSecondTabToggleClick != null)
					{
						this.mOnSecondTabToggleClick(this.mMainTabDataModel, this.mSecondTabDataModel);
					}
				}
				else
				{
					if (this.mSecondTabDataModel != null)
					{
						this.mSecondTabDataModel.content.CustomActive(false);
					}
					if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_GROWTH)
					{
						ISmithShopNewView component3 = this.mTabContentView.GetComponent<ISmithShopNewView>();
						if (component3 != null)
						{
							component3.OnDisableView();
						}
					}
					else
					{
						StrengthGrowthBaseView component4 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
						if (component4 != null)
						{
							component4.OnDisableView();
						}
					}
				}
			}
		}

		// Token: 0x0400B3CA RID: 46026
		[SerializeField]
		private Text mTabName;

		// Token: 0x0400B3CB RID: 46027
		[SerializeField]
		private Text mSelectedTabName;

		// Token: 0x0400B3CC RID: 46028
		[SerializeField]
		private Toggle mTabToggle;

		// Token: 0x0400B3CD RID: 46029
		private SmithShopNewMainTabDataModel mMainTabDataModel;

		// Token: 0x0400B3CE RID: 46030
		private SecondTabDataModel mSecondTabDataModel;

		// Token: 0x0400B3CF RID: 46031
		private bool isSelected;

		// Token: 0x0400B3D0 RID: 46032
		private OnSecondTabToggleClick mOnSecondTabToggleClick;

		// Token: 0x0400B3D1 RID: 46033
		private GameObject mTabContentView;

		// Token: 0x0400B3D2 RID: 46034
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B3D3 RID: 46035
		private SmithShopNewLinkData mLinkData;
	}
}
