using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BA8 RID: 7080
	public class SmithShopNewFrameView : MonoBehaviour
	{
		// Token: 0x0601157A RID: 71034 RVA: 0x005038E0 File Offset: 0x00501CE0
		private void OnDestroy()
		{
			this.mStrengthenGrowthViewGo = null;
			this.mStrengthenGrowthView = null;
			SmithShopNewFrameView.mLastSelectedItemData = null;
			this.iDefaultFirstTabId = 0;
			this.iDefaultSecondTabId = 0;
			this.mSecondTabDataModel = null;
			this.ResetPreSelectedFirstTabType();
		}

		// Token: 0x0601157B RID: 71035 RVA: 0x00503914 File Offset: 0x00501D14
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.mLinkData = linkData;
			this.iDefaultFirstTabId = 0;
			this.iDefaultSecondTabId = 0;
			if (linkData != null)
			{
				SmithShopNewFrameView.mLastSelectedItemData = linkData.itemData;
				this.iDefaultFirstTabId = linkData.iDefaultFirstTabId;
				this.iDefaultSecondTabId = linkData.iDefaultSecondTabId;
			}
			this.LoadStrengthenGrowthView();
			for (int i = 0; i < this.mMainTabs.Count; i++)
			{
				SmithShopNewMainTabDataModel smithShopNewMainTabDataModel = this.mMainTabs[i];
				if (smithShopNewMainTabDataModel != null)
				{
					if (this.GetOpenLevel(smithShopNewMainTabDataModel.tabType) <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
					{
						bool isSelected = this.iDefaultFirstTabId == smithShopNewMainTabDataModel.index;
						List<SecondTabDataModel> list = null;
						if (smithShopNewMainTabDataModel.isSunTAB)
						{
							if (smithShopNewMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_GROWTH)
							{
								list = this.mGrowthSubTabs;
							}
							else if (smithShopNewMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_ENCHANTMENTCARD)
							{
								list = this.mEnchantmentCardSubTabs;
							}
							else if (smithShopNewMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_INSCRIPTION)
							{
								list = this.mInscriptionSubTabs;
							}
							else if (smithShopNewMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_EQUIPMENTEVOLUTION)
							{
								list = new List<SecondTabDataModel>();
								for (int j = 0; j < this.mEquipmentEvolutionSubTabs.Count; j++)
								{
									SecondTabDataModel secondTabDataModel = this.mEquipmentEvolutionSubTabs[j];
									if (secondTabDataModel != null)
									{
										if (secondTabDataModel.index == 1 || secondTabDataModel.index == 2)
										{
											JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
											if (tableItem == null)
											{
												goto IL_17C;
											}
											if (tableItem.JobType != 1)
											{
												goto IL_17C;
											}
										}
										list.Add(secondTabDataModel);
									}
									IL_17C:;
								}
							}
						}
						GameObject gameObject = Object.Instantiate<GameObject>(this.mMenuItemGroup);
						if (gameObject != null)
						{
							gameObject.CustomActive(true);
							gameObject.name = smithShopNewMainTabDataModel.tabType.ToString();
							if (smithShopNewMainTabDataModel.tabType == SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER)
							{
								gameObject.CustomActive(this.iDefaultFirstTabId == 8);
							}
							Utility.AttachTo(gameObject, this.mMainMenuTabContent, false);
							SmithShopNewMenuItemGroup component = gameObject.GetComponent<SmithShopNewMenuItemGroup>();
							if (component != null && component.mFirstTabItem != null)
							{
								component.mFirstTabItem.InitTabItem(smithShopNewMainTabDataModel, list, isSelected, this.mStrengthenGrowthView, linkData, this.iDefaultSecondTabId, new OnFirstTabToggleClick(this.OnFirstTabToggleClick), new OnSecondTabToggleClick(this.OnSecondTabToggleClick));
							}
						}
					}
				}
			}
		}

		// Token: 0x0601157C RID: 71036 RVA: 0x00503B8C File Offset: 0x00501F8C
		private void OnFirstTabToggleClick(SmithShopNewMainTabDataModel mainTabDataModel)
		{
			if (mainTabDataModel == null)
			{
				return;
			}
			if (this.mStrengthenGrowthViewGo != null)
			{
				this.mStrengthenGrowthViewGo.CustomActive(mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_STRENGTHEN || mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_GROWTH);
			}
			this.OnFirstLayerTabChanged(mainTabDataModel);
			if (mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_STRENGTHEN)
			{
				StrengthenGrowthType type = StrengthenGrowthType.SGT_Strengthen;
				this.OnSetStrengthGrowthType(type);
				DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessStart, null, null, null, null);
			}
			else if (mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_GROWTH)
			{
				DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened = false;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessStart, null, null, null, null);
				this.OnSecondTabToggleClick(mainTabDataModel, this.mSecondTabDataModel);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessReset, null, null, null, null);
			}
			this.SetHelpAssistant(mainTabDataModel);
			this._preSelectedFirstTabType = mainTabDataModel.tabType;
		}

		// Token: 0x0601157D RID: 71037 RVA: 0x00503C74 File Offset: 0x00502074
		private void OnSecondTabToggleClick(SmithShopNewMainTabDataModel mainTabDataModel, SecondTabDataModel secondTabDataModel)
		{
			if (mainTabDataModel == null || secondTabDataModel == null)
			{
				return;
			}
			this.mSecondTabDataModel = secondTabDataModel;
			if (mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_GROWTH)
			{
				StrengthenGrowthType type = StrengthenGrowthType.SGT_Gtowth;
				if (secondTabDataModel.index == 0)
				{
					type = StrengthenGrowthType.SGT_Gtowth;
				}
				else if (secondTabDataModel.index == 1)
				{
					type = StrengthenGrowthType.SGT_Clear;
				}
				else if (secondTabDataModel.index == 2)
				{
					type = StrengthenGrowthType.SGT_Activate;
				}
				else if (secondTabDataModel.index == 3)
				{
					type = StrengthenGrowthType.SGT_Change;
				}
				this.OnSetStrengthGrowthType(type);
			}
			this.SetHelpAssistant(mainTabDataModel, secondTabDataModel);
		}

		// Token: 0x0601157E RID: 71038 RVA: 0x00503CF8 File Offset: 0x005020F8
		private void OnSetStrengthGrowthType(StrengthenGrowthType type)
		{
			if (this.mStrengthenGrowthView != null)
			{
				this.mStrengthenGrowthView.OnSetStrengthGrowthType(type);
			}
		}

		// Token: 0x0601157F RID: 71039 RVA: 0x00503D18 File Offset: 0x00502118
		private void LoadStrengthenGrowthView()
		{
			if (this.mStrengthenGrowthRoot != null)
			{
				UIPrefabWrapper component = this.mStrengthenGrowthRoot.GetComponent<UIPrefabWrapper>();
				if (component != null)
				{
					GameObject gameObject = component.LoadUIPrefab();
					if (gameObject != null)
					{
						gameObject.transform.SetParent(this.mStrengthenGrowthRoot.transform, false);
						this.mStrengthenGrowthViewGo = gameObject;
					}
				}
			}
			if (this.mStrengthenGrowthViewGo != null)
			{
				this.mStrengthenGrowthView = this.mStrengthenGrowthViewGo.GetComponent<StrengthenGrowthView>();
				if (this.mStrengthenGrowthView != null)
				{
					this.mStrengthenGrowthView.InitView(this.mLinkData);
				}
			}
		}

		// Token: 0x06011580 RID: 71040 RVA: 0x00503DC4 File Offset: 0x005021C4
		private int GetOpenLevel(SmithShopNewTabType tabType)
		{
			if (tabType >= SmithShopNewTabType.SSNTT_STRENGTHEN && tabType < SmithShopNewTabType.SSNTT_COUNT)
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(this.ms_iOpenLevel[(int)tabType], string.Empty, string.Empty);
				if (tableItem != null)
				{
					return tableItem.FinishLevel;
				}
			}
			return 9999;
		}

		// Token: 0x06011581 RID: 71041 RVA: 0x00503E10 File Offset: 0x00502210
		public static ItemData GetLastSelectItem(SmithShopNewTabType tabType)
		{
			ItemData result = null;
			switch (tabType)
			{
			case SmithShopNewTabType.SSNTT_STRENGTHEN:
			case SmithShopNewTabType.SSNTT_GROWTH:
				result = StrengthenGrowthView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_ENCHANTMENTCARD:
				result = ComEquipment.ms_selected;
				break;
			case SmithShopNewTabType.SSNTT_BEAD:
				result = ComBeadEquipment.ms_selected;
				break;
			case SmithShopNewTabType.SSNTT_INSCRIPTION:
				result = InscriptionEquipmentItem.mSelectItemData;
				break;
			case SmithShopNewTabType.SSNTT_ADJUST:
			case SmithShopNewTabType.SSNTT_EQUIPMENTSEAL:
			case SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER:
				result = ComSealEquipment.ms_selected;
				break;
			case SmithShopNewTabType.SSNTT_EQUIPMENTEVOLUTION:
				result = EquipUpgradeItem.ms_selected;
				break;
			case SmithShopNewTabType.SSNTT_MATERIALSSYNTHESIS:
				break;
			default:
				result = null;
				break;
			}
			return result;
		}

		// Token: 0x06011582 RID: 71042 RVA: 0x00503EA4 File Offset: 0x005022A4
		public static void SetLastSelectItem(SmithShopNewTabType tabType)
		{
			if (SmithShopNewFrameView.mLastSelectedItemData == null)
			{
				return;
			}
			switch (tabType)
			{
			case SmithShopNewTabType.SSNTT_STRENGTHEN:
			case SmithShopNewTabType.SSNTT_GROWTH:
				StrengthenGrowthView.mLastSelectedItemData = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_ENCHANTMENTCARD:
				ComEquipment.ms_selected = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_BEAD:
				ComBeadEquipment.ms_selected = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_INSCRIPTION:
				InscriptionEquipmentItem.mSelectItemData = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_ADJUST:
			case SmithShopNewTabType.SSNTT_EQUIPMENTSEAL:
			case SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER:
				ComSealEquipment.ms_selected = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			case SmithShopNewTabType.SSNTT_EQUIPMENTEVOLUTION:
				EquipUpgradeItem.ms_selected = SmithShopNewFrameView.mLastSelectedItemData;
				break;
			}
		}

		// Token: 0x06011583 RID: 71043 RVA: 0x00503F54 File Offset: 0x00502354
		private void SetHelpAssistant(SmithShopNewMainTabDataModel mainTabDataModel, SecondTabDataModel secondTabDataModel)
		{
			if (mainTabDataModel == null || secondTabDataModel == null)
			{
				return;
			}
			if (this.mHelpAssistant == null)
			{
				return;
			}
			if (mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_ENCHANTMENTCARD)
			{
				if (secondTabDataModel.index == 0)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_ADDMAGIC;
				}
				else if (secondTabDataModel.index == 1)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_MAGICCOPMOSE;
				}
				else if (secondTabDataModel.index == 2)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_ENCHANTMENTCARUPGRADE;
				}
			}
			else if (mainTabDataModel.tabType == SmithShopNewTabType.SSNTT_EQUIPMENTEVOLUTION)
			{
				if (secondTabDataModel.index == 0)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_EQUIPUPGRADE;
				}
				else if (secondTabDataModel.index == 1)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_SAMEEQUIPMENTCONVER;
				}
				else if (secondTabDataModel.index == 2)
				{
					this.mHelpAssistant.eType = HelpFrame.HelpType.HT_CROSSEQUIPMENTCONVER;
				}
			}
		}

		// Token: 0x06011584 RID: 71044 RVA: 0x00504044 File Offset: 0x00502444
		private void SetHelpAssistant(SmithShopNewMainTabDataModel mainTabDataModel)
		{
			if (mainTabDataModel == null)
			{
				return;
			}
			if (this.mHelpAssistant == null)
			{
				return;
			}
			switch (mainTabDataModel.tabType)
			{
			case SmithShopNewTabType.SSNTT_STRENGTHEN:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_STRENTH;
				break;
			case SmithShopNewTabType.SSNTT_GROWTH:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_STRENTH;
				break;
			case SmithShopNewTabType.SSNTT_BEAD:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_PEARLINLAY;
				break;
			case SmithShopNewTabType.SSNTT_INSCRIPTION:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_INSCRIPTION;
				break;
			case SmithShopNewTabType.SSNTT_ADJUST:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_QUALITYCHANGE;
				break;
			case SmithShopNewTabType.SSNTT_EQUIPMENTSEAL:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_SEAL;
				break;
			case SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_TRANSFER;
				break;
			case SmithShopNewTabType.SSNTT_MATERIALSSYNTHESIS:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_MATERIALSSYNTHESIS;
				break;
			case SmithShopNewTabType.SSNIT_BEADUPGRADE:
				this.mHelpAssistant.eType = HelpFrame.HelpType.HT_BEADUPGRADE;
				break;
			}
		}

		// Token: 0x06011585 RID: 71045 RVA: 0x0050414C File Offset: 0x0050254C
		private void OnFirstLayerTabChanged(SmithShopNewMainTabDataModel mainTabDataModel)
		{
			if (mainTabDataModel == null)
			{
				return;
			}
			if (this._preSelectedFirstTabType == SmithShopNewTabType.SSNTT_STRENGTHEN && mainTabDataModel.tabType != SmithShopNewTabType.SSNTT_STRENGTHEN)
			{
				if (DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
				}
				DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened = false;
			}
			else if (this._preSelectedFirstTabType == SmithShopNewTabType.SSNTT_GROWTH && mainTabDataModel.tabType != SmithShopNewTabType.SSNTT_GROWTH)
			{
				if (DataManager<EquipGrowthDataManager>.GetInstance().IsEquipIntensify)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
				}
				DataManager<EquipGrowthDataManager>.GetInstance().IsEquipIntensify = false;
			}
		}

		// Token: 0x06011586 RID: 71046 RVA: 0x005041F0 File Offset: 0x005025F0
		private void ResetPreSelectedFirstTabType()
		{
			if (this._preSelectedFirstTabType == SmithShopNewTabType.SSNTT_STRENGTHEN && DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
			}
			else if (this._preSelectedFirstTabType == SmithShopNewTabType.SSNTT_GROWTH && DataManager<EquipGrowthDataManager>.GetInstance().IsEquipIntensify)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessFinish, null, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ContinueProcessReset, null, null, null, null);
			}
			this._preSelectedFirstTabType = SmithShopNewTabType.SSNTT_COUNT;
			DataManager<StrengthenDataManager>.GetInstance().IsEquipStrengthened = false;
			DataManager<EquipGrowthDataManager>.GetInstance().IsEquipIntensify = false;
		}

		// Token: 0x0400B3B6 RID: 46006
		[SerializeField]
		private List<SmithShopNewMainTabDataModel> mMainTabs;

		// Token: 0x0400B3B7 RID: 46007
		[SerializeField]
		private List<SecondTabDataModel> mGrowthSubTabs;

		// Token: 0x0400B3B8 RID: 46008
		[SerializeField]
		private List<SecondTabDataModel> mEnchantmentCardSubTabs;

		// Token: 0x0400B3B9 RID: 46009
		[SerializeField]
		private List<SecondTabDataModel> mInscriptionSubTabs;

		// Token: 0x0400B3BA RID: 46010
		[SerializeField]
		private List<SecondTabDataModel> mEquipmentEvolutionSubTabs;

		// Token: 0x0400B3BB RID: 46011
		[SerializeField]
		private GameObject mMainMenuTabContent;

		// Token: 0x0400B3BC RID: 46012
		[SerializeField]
		private GameObject mMenuItemGroup;

		// Token: 0x0400B3BD RID: 46013
		[SerializeField]
		private HelpAssistant mHelpAssistant;

		// Token: 0x0400B3BE RID: 46014
		[SerializeField]
		private GameObject mStrengthenGrowthRoot;

		// Token: 0x0400B3BF RID: 46015
		[SerializeField]
		private int[] ms_iOpenLevel;

		// Token: 0x0400B3C0 RID: 46016
		private GameObject mStrengthenGrowthViewGo;

		// Token: 0x0400B3C1 RID: 46017
		private StrengthenGrowthView mStrengthenGrowthView;

		// Token: 0x0400B3C2 RID: 46018
		public static ItemData mLastSelectedItemData;

		// Token: 0x0400B3C3 RID: 46019
		private int iDefaultFirstTabId;

		// Token: 0x0400B3C4 RID: 46020
		private int iDefaultSecondTabId;

		// Token: 0x0400B3C5 RID: 46021
		private SmithShopNewLinkData mLinkData;

		// Token: 0x0400B3C6 RID: 46022
		private SecondTabDataModel mSecondTabDataModel;

		// Token: 0x0400B3C7 RID: 46023
		public static List<SmithShopNewSecondTabItem> mSecondTabItemList;

		// Token: 0x0400B3C8 RID: 46024
		private SmithShopNewTabType _preSelectedFirstTabType = SmithShopNewTabType.SSNTT_COUNT;
	}
}
