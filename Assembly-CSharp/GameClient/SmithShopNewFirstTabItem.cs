using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B97 RID: 7063
	public class SmithShopNewFirstTabItem : MonoBehaviour
	{
		// Token: 0x06011544 RID: 70980 RVA: 0x00502978 File Offset: 0x00500D78
		private void Awake()
		{
			if (this.mTabToggle != null)
			{
				this.mTabToggle.onValueChanged.RemoveAllListeners();
				this.mTabToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTabToggleClick));
			}
		}

		// Token: 0x06011545 RID: 70981 RVA: 0x005029B7 File Offset: 0x00500DB7
		private void OnDestroy()
		{
			this.ResetData();
		}

		// Token: 0x06011546 RID: 70982 RVA: 0x005029C0 File Offset: 0x00500DC0
		private void ResetData()
		{
			this.isSelected = false;
			this.mMainTabDataModel = null;
			this.isOwnerChildren = false;
			this.isInitChildrenTab = false;
			this.mOnFirstTabToggleClick = null;
			this.mOnSecondTabToggleClick = null;
			this.mDefaultSecondTabIndex = 0;
			this.mSecondTabDataModelList = null;
			this.mTabContentView = null;
			this.mStrengthenGrowthView = null;
			this.mLinkData = null;
			this.mSecondTabItemList.Clear();
		}

		// Token: 0x06011547 RID: 70983 RVA: 0x00502A28 File Offset: 0x00500E28
		public void InitTabItem(SmithShopNewMainTabDataModel mainTabDataModel, List<SecondTabDataModel> secondTabDataModelList, bool isSelected, StrengthenGrowthView view, SmithShopNewLinkData linkData, int defaultSecondTabIndex = 0, OnFirstTabToggleClick onFirstTabToggleClick = null, OnSecondTabToggleClick onSecondTabToggleClick = null)
		{
			this.ResetData();
			this.mMainTabDataModel = mainTabDataModel;
			this.mSecondTabDataModelList = secondTabDataModelList;
			this.mDefaultSecondTabIndex = defaultSecondTabIndex;
			this.mStrengthenGrowthView = view;
			this.mLinkData = linkData;
			this.mOnFirstTabToggleClick = onFirstTabToggleClick;
			this.mOnSecondTabToggleClick = onSecondTabToggleClick;
			if (this.mMainTabDataModel == null)
			{
				return;
			}
			this.isOwnerChildren = false;
			if (this.mMainTabDataModel.isSunTAB)
			{
				this.isOwnerChildren = true;
			}
			if (this.mTabName != null)
			{
				this.mTabName.text = this.mMainTabDataModel.tabName;
			}
			if (this.mSelectedTabName != null)
			{
				this.mSelectedTabName.text = this.mMainTabDataModel.tabName;
			}
			this.InitArrowUp();
			if (isSelected && this.mTabToggle != null)
			{
				this.mTabToggle.isOn = true;
			}
		}

		// Token: 0x06011548 RID: 70984 RVA: 0x00502B14 File Offset: 0x00500F14
		private void InitArrowUp()
		{
			if (this.mArrowRoot != null)
			{
				if (this.isOwnerChildren)
				{
					this.mArrowRoot.CustomActive(true);
				}
				else
				{
					this.mArrowRoot.CustomActive(false);
				}
			}
			if (this.isOwnerChildren)
			{
				this.SetArrowUp(true);
				this.SetArrowDown(false);
			}
		}

		// Token: 0x06011549 RID: 70985 RVA: 0x00502B73 File Offset: 0x00500F73
		private void SetArrowUp(bool flag)
		{
			if (this.mArrowUp != null)
			{
				this.mArrowUp.CustomActive(flag);
			}
		}

		// Token: 0x0601154A RID: 70986 RVA: 0x00502B92 File Offset: 0x00500F92
		private void SetArrowDown(bool flag)
		{
			if (this.mArrowDown != null)
			{
				this.mArrowDown.CustomActive(flag);
			}
		}

		// Token: 0x0601154B RID: 70987 RVA: 0x00502BB4 File Offset: 0x00500FB4
		private void InitSecondTab()
		{
			if (this.mSecondTabDataModelList == null || this.mSecondTabDataModelList.Count <= 0)
			{
				return;
			}
			if (this.mSecondMenuRoot == null || this.mSecondTabItemGo == null)
			{
				return;
			}
			for (int i = 0; i < this.mSecondTabDataModelList.Count; i++)
			{
				SecondTabDataModel secondTabDataModel = this.mSecondTabDataModelList[i];
				if (secondTabDataModel != null)
				{
					bool flag = i == this.mDefaultSecondTabIndex;
					GameObject gameObject = Object.Instantiate<GameObject>(this.mSecondTabItemGo);
					if (gameObject != null)
					{
						gameObject.CustomActive(true);
						gameObject.name = secondTabDataModel.index.ToString();
						Utility.AttachTo(gameObject, this.mSecondMenuRoot, false);
						SmithShopNewSecondTabItem component = gameObject.GetComponent<SmithShopNewSecondTabItem>();
						if (component != null)
						{
							component.InitTabItem(this.mMainTabDataModel, secondTabDataModel, flag, this.mStrengthenGrowthView, this.mLinkData, this.mOnSecondTabToggleClick);
							this.mSecondTabItemList.Add(component);
						}
					}
				}
			}
		}

		// Token: 0x0601154C RID: 70988 RVA: 0x00502CC8 File Offset: 0x005010C8
		private void OnTabToggleClick(bool value)
		{
			if (this.mMainTabDataModel == null)
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
				if (SmithShopNewFrameView.mSecondTabItemList != null && SmithShopNewFrameView.mSecondTabItemList.Count > 0)
				{
					for (int i = 0; i < SmithShopNewFrameView.mSecondTabItemList.Count; i++)
					{
						SmithShopNewSecondTabItem smithShopNewSecondTabItem = SmithShopNewFrameView.mSecondTabItemList[i];
						if (smithShopNewSecondTabItem != null)
						{
							smithShopNewSecondTabItem.OnEnabelTabItem(false);
						}
					}
				}
				if (this.mTabToggle != null)
				{
					this.mTabToggle.group.allowSwitchOff = (this.mSecondTabDataModelList != null);
				}
				SmithShopNewFrameView.SetLastSelectItem(this.mMainTabDataModel.tabType);
				if (this.isOwnerChildren)
				{
					this.SetArrowUp(false);
					this.SetArrowDown(true);
					if (this.mSecondMenuRoot != null)
					{
						this.mSecondMenuRoot.CustomActive(true);
					}
					if (!this.isInitChildrenTab)
					{
						this.InitSecondTab();
						this.isInitChildrenTab = true;
					}
					else if (this.mSecondTabItemList != null && this.mSecondTabItemList.Count > 0)
					{
						for (int j = 0; j < this.mSecondTabItemList.Count; j++)
						{
							SmithShopNewSecondTabItem smithShopNewSecondTabItem2 = this.mSecondTabItemList[j];
							if (smithShopNewSecondTabItem2 != null)
							{
								smithShopNewSecondTabItem2.OnEnabelTabItem(true);
							}
						}
					}
					SmithShopNewFrameView.mSecondTabItemList = this.mSecondTabItemList;
				}
				else
				{
					if (this.mMainTabDataModel.content != null)
					{
						this.mMainTabDataModel.content.CustomActive(true);
					}
					if (this.mTabContentView == null)
					{
						this.LoadContentView();
					}
					else if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_STRENGTHEN)
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
				}
				if (this.mOnFirstTabToggleClick != null)
				{
					this.mOnFirstTabToggleClick(this.mMainTabDataModel);
				}
			}
			else
			{
				if (this.isOwnerChildren)
				{
					this.SetArrowUp(true);
					this.SetArrowDown(false);
					if (this.mSecondMenuRoot != null)
					{
						this.mSecondMenuRoot.CustomActive(false);
					}
				}
				else
				{
					if (this.mMainTabDataModel.content != null)
					{
						this.mMainTabDataModel.content.CustomActive(false);
					}
					if (this.mMainTabDataModel.tabType != SmithShopNewTabType.SSNTT_STRENGTHEN)
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
				SmithShopNewFrameView.mLastSelectedItemData = SmithShopNewFrameView.GetLastSelectItem(this.mMainTabDataModel.tabType);
			}
		}

		// Token: 0x0601154D RID: 70989 RVA: 0x00502FCC File Offset: 0x005013CC
		private void LoadContentView()
		{
			if (this.mMainTabDataModel == null || this.mMainTabDataModel.content == null)
			{
				return;
			}
			UIPrefabWrapper component = this.mMainTabDataModel.content.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.mMainTabDataModel.content.transform, false);
					this.mTabContentView = gameObject;
				}
			}
			if (this.mTabContentView != null)
			{
				if (this.mMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_STRENGTHEN)
				{
					StrengthGrowthBaseView component2 = this.mTabContentView.GetComponent<StrengthGrowthBaseView>();
					if (component2 != null)
					{
						component2.IniteData(this.mLinkData, StrengthenGrowthType.SGT_Strengthen, this.mStrengthenGrowthView);
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

		// Token: 0x0400B361 RID: 45921
		[SerializeField]
		private Text mTabName;

		// Token: 0x0400B362 RID: 45922
		[SerializeField]
		private Text mSelectedTabName;

		// Token: 0x0400B363 RID: 45923
		[SerializeField]
		private Toggle mTabToggle;

		// Token: 0x0400B364 RID: 45924
		[SerializeField]
		private GameObject mArrowRoot;

		// Token: 0x0400B365 RID: 45925
		[SerializeField]
		private GameObject mArrowUp;

		// Token: 0x0400B366 RID: 45926
		[SerializeField]
		private GameObject mArrowDown;

		// Token: 0x0400B367 RID: 45927
		[SerializeField]
		private GameObject mSecondMenuRoot;

		// Token: 0x0400B368 RID: 45928
		[SerializeField]
		private GameObject mSecondTabItemGo;

		// Token: 0x0400B369 RID: 45929
		private bool isSelected;

		// Token: 0x0400B36A RID: 45930
		private SmithShopNewMainTabDataModel mMainTabDataModel;

		// Token: 0x0400B36B RID: 45931
		private bool isOwnerChildren;

		// Token: 0x0400B36C RID: 45932
		private bool isInitChildrenTab;

		// Token: 0x0400B36D RID: 45933
		private OnFirstTabToggleClick mOnFirstTabToggleClick;

		// Token: 0x0400B36E RID: 45934
		private OnSecondTabToggleClick mOnSecondTabToggleClick;

		// Token: 0x0400B36F RID: 45935
		private int mDefaultSecondTabIndex;

		// Token: 0x0400B370 RID: 45936
		private List<SecondTabDataModel> mSecondTabDataModelList;

		// Token: 0x0400B371 RID: 45937
		private GameObject mTabContentView;

		// Token: 0x0400B372 RID: 45938
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B373 RID: 45939
		private SmithShopNewLinkData mLinkData;

		// Token: 0x0400B374 RID: 45940
		private List<SmithShopNewSecondTabItem> mSecondTabItemList = new List<SmithShopNewSecondTabItem>();
	}
}
