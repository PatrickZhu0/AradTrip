using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CC6 RID: 7366
	public class TreasureConversionView : MonoBehaviour
	{
		// Token: 0x06012100 RID: 73984 RVA: 0x00548918 File Offset: 0x00546D18
		private void Awake()
		{
			this.BindAddListener();
			this.InitTreasureUIListScript();
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTreasureConversionSuccessed, new ClientEventSystem.UIEventHandler(this.OnTreasureConversionSuccessed));
		}

		// Token: 0x06012101 RID: 73985 RVA: 0x00548998 File Offset: 0x00546D98
		private void OnDestroy()
		{
			this.RemoveAddListener();
			this.UnInitTreasureUIListScript();
			this.currentSelectedTreasureConversionTabType = TreasureConversionTabType.TCTT_NONE;
			this.treasureConversionItemDataList.Clear();
			this.mCurrentSelectedTreasure = null;
			this.mConversionEffectItemData = null;
			this.mTreasureMaterialItemData = null;
			this.mBeadConvertCostTable = null;
			this.treasureMaterialType = TreasureMaterialType.None;
			this.materialGuid = 0UL;
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance2.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTreasureConversionSuccessed, new ClientEventSystem.UIEventHandler(this.OnTreasureConversionSuccessed));
		}

		// Token: 0x06012102 RID: 73986 RVA: 0x00548A55 File Offset: 0x00546E55
		public void InitView()
		{
			this.InitActivityTimer();
			this.CreatTabs();
		}

		// Token: 0x06012103 RID: 73987 RVA: 0x00548A64 File Offset: 0x00546E64
		private void BindAddListener()
		{
			if (this.mReplacMaterialTog != null)
			{
				this.mReplacMaterialTog.onValueChanged.RemoveAllListeners();
				this.mReplacMaterialTog.onValueChanged.AddListener(new UnityAction<bool>(this.OnReplacMaterialTogClick));
			}
			if (this.mTreasureBtn != null)
			{
				this.mTreasureBtn.onClick.RemoveAllListeners();
				this.mTreasureBtn.onClick.AddListener(new UnityAction(this.OnTreasureBtnClick));
			}
			if (this.mCurrentTreasureIconBtn != null)
			{
				this.mCurrentTreasureIconBtn.onClick.RemoveAllListeners();
				this.mCurrentTreasureIconBtn.onClick.AddListener(new UnityAction(this.OnCurrentTreasureIconBtnClick));
			}
			if (this.mConversionEffectIconBtn != null)
			{
				this.mConversionEffectIconBtn.onClick.RemoveAllListeners();
				this.mConversionEffectIconBtn.onClick.AddListener(new UnityAction(this.OnConversionEffectIconBtnClick));
			}
			if (this.mCostItemComLinkBtn != null)
			{
				this.mCostItemComLinkBtn.onClick.RemoveAllListeners();
				this.mCostItemComLinkBtn.onClick.AddListener(new UnityAction(this.OnCostItemComLinkBtnClick));
			}
			if (this.mCostItemBtn != null)
			{
				this.mCostItemBtn.onClick.RemoveAllListeners();
				this.mCostItemBtn.onClick.AddListener(new UnityAction(this.OnCostItemBtnClick));
			}
			if (this.mCostTreasureBtn != null)
			{
				this.mCostTreasureBtn.onClick.RemoveAllListeners();
				this.mCostTreasureBtn.onClick.AddListener(new UnityAction(this.OnCostTreasureBtnClick));
			}
		}

		// Token: 0x06012104 RID: 73988 RVA: 0x00548C1C File Offset: 0x0054701C
		private void RemoveAddListener()
		{
			if (this.mReplacMaterialTog != null)
			{
				this.mReplacMaterialTog.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnReplacMaterialTogClick));
			}
			if (this.mTreasureBtn != null)
			{
				this.mTreasureBtn.onClick.RemoveListener(new UnityAction(this.OnTreasureBtnClick));
			}
			if (this.mCurrentTreasureIconBtn != null)
			{
				this.mCurrentTreasureIconBtn.onClick.RemoveListener(new UnityAction(this.OnCurrentTreasureIconBtnClick));
			}
			if (this.mConversionEffectIconBtn != null)
			{
				this.mConversionEffectIconBtn.onClick.RemoveListener(new UnityAction(this.OnConversionEffectIconBtnClick));
			}
			if (this.mCostItemComLinkBtn != null)
			{
				this.mCostItemComLinkBtn.onClick.RemoveListener(new UnityAction(this.OnCostItemComLinkBtnClick));
			}
			if (this.mCostItemBtn != null)
			{
				this.mCostItemBtn.onClick.RemoveListener(new UnityAction(this.OnCostItemBtnClick));
			}
			if (this.mCostTreasureBtn != null)
			{
				this.mCostTreasureBtn.onClick.RemoveListener(new UnityAction(this.OnCostTreasureBtnClick));
			}
		}

		// Token: 0x06012105 RID: 73989 RVA: 0x00548D64 File Offset: 0x00547164
		private void CreatTabs()
		{
			for (int i = 0; i < this.mTabsList.Count; i++)
			{
				TreasureConversionTabDataModel tab = this.mTabsList[i];
				if (tab != null)
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.mTabPrefab);
					gameObject.CustomActive(true);
					Utility.AttachTo(gameObject, this.mTabParent, false);
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					if (component != null)
					{
						Toggle com = component.GetCom<Toggle>("tab");
						Text com2 = component.GetCom<Text>("tabName");
						Text com3 = component.GetCom<Text>("checkName");
						if (com2 != null && com3 != null)
						{
							Text text = com2;
							string tabName = tab.tabName;
							com3.text = tabName;
							text.text = tabName;
						}
						if (com != null)
						{
							com.onValueChanged.RemoveAllListeners();
							com.onValueChanged.AddListener(delegate(bool value)
							{
								if (this.currentSelectedTreasureConversionTabType == tab.tabType)
								{
									return;
								}
								if (value)
								{
									this.currentSelectedTreasureConversionTabType = tab.tabType;
									if (this.mTreasureUIListScript != null)
									{
										this.mTreasureUIListScript.ResetSelectedElementIndex();
									}
									this.mCurrentSelectedTreasure = null;
									this.mConversionEffectItemData = null;
									this.mTreasureMaterialItemData = null;
									this.UpdateCurrentTreasure();
									this.UpdateConversionEffect();
									this.UpdateCostTreasure();
									this.RefreshTreasureConversionItemDataList(true);
									if (this.mStateControl != null)
									{
										this.mStateControl.Key = "None";
									}
								}
							});
						}
						if (this.defaultTreasureConversionTabType == tab.tabType && com != null)
						{
							com.isOn = true;
						}
					}
				}
			}
		}

		// Token: 0x06012106 RID: 73990 RVA: 0x00548EAC File Offset: 0x005472AC
		private void InitTreasureUIListScript()
		{
			if (this.mTreasureUIListScript != null)
			{
				this.mTreasureUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mTreasureUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTreasureUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mTreasureUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mTreasureUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChageDisplayDelegate));
			}
		}

		// Token: 0x06012107 RID: 73991 RVA: 0x00548F74 File Offset: 0x00547374
		private void UnInitTreasureUIListScript()
		{
			if (this.mTreasureUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mTreasureUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTreasureUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mTreasureUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mTreasureUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChageDisplayDelegate));
			}
		}

		// Token: 0x06012108 RID: 73992 RVA: 0x0054902E File Offset: 0x0054742E
		private TreasureConversionItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TreasureConversionItem>();
		}

		// Token: 0x06012109 RID: 73993 RVA: 0x00549038 File Offset: 0x00547438
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TreasureConversionItem treasureConversionItem = item.gameObjectBindScript as TreasureConversionItem;
			if (treasureConversionItem != null && item.m_index >= 0 && item.m_index < this.treasureConversionItemDataList.Count)
			{
				treasureConversionItem.OnItemVisiable(this.treasureConversionItemDataList[item.m_index]);
			}
		}

		// Token: 0x0601210A RID: 73994 RVA: 0x00549098 File Offset: 0x00547498
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			TreasureConversionItem treasureConversionItem = item.gameObjectBindScript as TreasureConversionItem;
			if (treasureConversionItem != null)
			{
				this.mCurrentSelectedTreasure = treasureConversionItem.TreasureItemData;
				this.UpdateFrameInfo();
			}
		}

		// Token: 0x0601210B RID: 73995 RVA: 0x005490D0 File Offset: 0x005474D0
		private void OnItemChageDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			TreasureConversionItem treasureConversionItem = item.gameObjectBindScript as TreasureConversionItem;
			if (treasureConversionItem != null)
			{
				treasureConversionItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0601210C RID: 73996 RVA: 0x005490FC File Offset: 0x005474FC
		private void InitActivityTimer()
		{
			ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().GetActivityInfo(TR.Value("TreasureConvert_activity_name"));
			if (activityInfo != null)
			{
				this.mActivityTime.text = Function.GetDateTimeHMS((int)activityInfo.startTime, (int)activityInfo.dueTime);
			}
		}

		// Token: 0x0601210D RID: 73997 RVA: 0x00549140 File Offset: 0x00547540
		private void UpdateFrameInfo()
		{
			if (this.mCurrentSelectedTreasure == null)
			{
				return;
			}
			this.mBeadConvertCostTable = this.GetBeadConvertCostTableData((int)this.mCurrentSelectedTreasure.Quality);
			if (this.mBeadConvertCostTable != null)
			{
				this.mConversionEffectItemData = ItemDataManager.CreateItemDataFromTable(this.mBeadConvertCostTable.ProduceBeadPreview, 100, 0);
				if (this.mBeadConvertCostTable.MoneyCostId != 0 && this.mBeadConvertCostTable.BeadCost != 0)
				{
					this.treasureMaterialType = TreasureMaterialType.Both;
				}
				else if (this.mBeadConvertCostTable.MoneyCostId != 0 && this.mBeadConvertCostTable.BeadCost == 0)
				{
					this.treasureMaterialType = TreasureMaterialType.Gold;
				}
				else if (this.mBeadConvertCostTable.MoneyCostId == 0 && this.mBeadConvertCostTable.BeadCost != 0)
				{
					this.treasureMaterialType = TreasureMaterialType.Treasure;
				}
				TreasureMaterialType treasureMaterialType = this.treasureMaterialType;
				if (treasureMaterialType != TreasureMaterialType.Gold)
				{
					if (treasureMaterialType != TreasureMaterialType.Treasure)
					{
						if (treasureMaterialType == TreasureMaterialType.Both)
						{
							if (this.mStateControl != null)
							{
								this.mStateControl.Key = "Both";
							}
							this.UpdateCostItem(this.mBeadConvertCostTable);
							this.OnReplacMaterialTogClick(this.mReplacMaterialTog.isOn);
						}
					}
					else if (this.mStateControl != null)
					{
						this.mStateControl.Key = "Treasure";
					}
				}
				else
				{
					if (this.mStateControl != null)
					{
						this.mStateControl.Key = "Gold";
					}
					this.UpdateCostItem(this.mBeadConvertCostTable);
				}
			}
			this.UpdateCurrentTreasure();
			this.UpdateConversionEffect();
			if (this.mTreasureMaterialItemData != null)
			{
				this.mTreasureMaterialItemData = DataManager<ItemDataManager>.GetInstance().GetItem(this.mTreasureMaterialItemData.GUID);
				if (this.mTreasureMaterialItemData.GUID == this.mCurrentSelectedTreasure.GUID)
				{
					if (this.mTreasureMaterialItemData.Count - 1 <= 0)
					{
						this.mTreasureMaterialItemData = null;
					}
					else
					{
						this.mTreasureMaterialItemData.ShowCount = this.mTreasureMaterialItemData.Count - 1;
					}
				}
				else
				{
					this.mTreasureMaterialItemData = DataManager<ItemDataManager>.GetInstance().GetItem(this.mTreasureMaterialItemData.GUID);
					this.mTreasureMaterialItemData.ShowCount = this.mTreasureMaterialItemData.Count;
				}
				this.UpdateCostTreasure();
			}
		}

		// Token: 0x0601210E RID: 73998 RVA: 0x00549390 File Offset: 0x00547790
		private void UpdateCurrentTreasure()
		{
			if (this.mCurrentSelectedTreasure == null)
			{
				if (this.mCurrentTreasureBackground != null)
				{
					this.mCurrentTreasureBackground.CustomActive(false);
				}
			}
			else
			{
				if (this.mCurrentTreasureBackground != null)
				{
					this.mCurrentTreasureBackground.CustomActive(true);
					ETCImageLoader.LoadSprite(ref this.mCurrentTreasureBackground, this.mCurrentSelectedTreasure.GetQualityInfo().Background, true);
				}
				if (this.mCurrentTreasureIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mCurrentTreasureIcon, this.mCurrentSelectedTreasure.Icon, true);
				}
			}
		}

		// Token: 0x0601210F RID: 73999 RVA: 0x00549430 File Offset: 0x00547830
		private void UpdateConversionEffect()
		{
			if (this.mConversionEffectItemData == null)
			{
				if (this.mConversionEffectBackground != null)
				{
					this.mConversionEffectBackground.CustomActive(false);
				}
			}
			else
			{
				if (this.mConversionEffectBackground != null)
				{
					this.mConversionEffectBackground.CustomActive(true);
					ETCImageLoader.LoadSprite(ref this.mConversionEffectBackground, this.mConversionEffectItemData.GetQualityInfo().Background, true);
				}
				if (this.mConversionEffectIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mConversionEffectIcon, this.mConversionEffectItemData.Icon, true);
				}
			}
		}

		// Token: 0x06012110 RID: 74000 RVA: 0x005494D0 File Offset: 0x005478D0
		private void UpdateCostItem(BeadConvertCostTable beadConvertCostTable)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(beadConvertCostTable.MoneyCostId, 100, 0);
			if (itemData == null)
			{
				return;
			}
			if (this.mCostItemBackground != null)
			{
				ETCImageLoader.LoadSprite(ref this.mCostItemBackground, itemData.GetQualityInfo().Background, true);
			}
			if (this.mCostItemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mCostItemIcon, itemData.Icon, true);
			}
			this.RefreshCostItemCount(beadConvertCostTable);
		}

		// Token: 0x06012111 RID: 74001 RVA: 0x00549548 File Offset: 0x00547948
		private void RefreshCostItemCount(BeadConvertCostTable beadConvertCostTable)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(beadConvertCostTable.MoneyCostId, true);
			if (ownedItemCount >= beadConvertCostTable.MoneyCostNum)
			{
				this.mCostItemCount.text = TR.Value("EquipUpgrade_Merial_white", ownedItemCount, beadConvertCostTable.MoneyCostNum);
			}
			else
			{
				this.mCostItemCount.text = TR.Value("EquipUpgrade_Merial_Red", ownedItemCount, beadConvertCostTable.MoneyCostNum);
			}
			this.mCostItemComLink.CustomActive(ownedItemCount < beadConvertCostTable.MoneyCostNum);
		}

		// Token: 0x06012112 RID: 74002 RVA: 0x005495D8 File Offset: 0x005479D8
		private void RefreshTreasureConversionItemDataList(bool setScrollRect = false)
		{
			if (this.treasureConversionItemDataList == null)
			{
				this.treasureConversionItemDataList = new List<ItemData>();
			}
			this.treasureConversionItemDataList.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						if (item.SubType == 54)
						{
							if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PURPLE)
							{
								if (item.Quality != ItemTable.eColor.PURPLE)
								{
									goto IL_C0;
								}
							}
							else if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PINK && item.Quality != ItemTable.eColor.PINK)
							{
								goto IL_C0;
							}
							item.ShowCount = item.Count;
							this.treasureConversionItemDataList.Add(item);
						}
					}
					IL_C0:;
				}
			}
			this.treasureConversionItemDataList.Sort((ItemData x, ItemData y) => x.TableID - y.TableID);
			if (this.mTreasureUIListScript != null)
			{
				this.mTreasureUIListScript.SetElementAmount(this.treasureConversionItemDataList.Count);
			}
			if (setScrollRect && this.mTreasureConversionScrollRect != null)
			{
				this.mTreasureConversionScrollRect.verticalNormalizedPosition = 1f;
			}
			if (this.mCurrentSelectedTreasure != null)
			{
				int num = -1;
				for (int j = 0; j < this.treasureConversionItemDataList.Count; j++)
				{
					ulong guid = this.treasureConversionItemDataList[j].GUID;
					if (guid == this.mCurrentSelectedTreasure.GUID)
					{
						num = j;
					}
				}
				if (num >= 0 && num < this.treasureConversionItemDataList.Count)
				{
					if (!this.mTreasureUIListScript.IsElementInScrollArea(num))
					{
						this.mTreasureUIListScript.EnsureElementVisable(num);
					}
					this.mTreasureUIListScript.SelectElement(num, true);
				}
				else
				{
					this.mTreasureUIListScript.SelectElement(-1, true);
				}
			}
		}

		// Token: 0x06012113 RID: 74003 RVA: 0x005497DA File Offset: 0x00547BDA
		private void OnTreasureChooseCallback(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mTreasureMaterialItemData = itemData;
			this.UpdateCostTreasure();
		}

		// Token: 0x06012114 RID: 74004 RVA: 0x005497F0 File Offset: 0x00547BF0
		private void UpdateCostTreasure()
		{
			if (this.mTreasureMaterialItemData == null)
			{
				if (this.mCostTreasureBackground != null)
				{
					this.mCostTreasureBackground.CustomActive(false);
				}
				if (this.mCostTreasureName != null)
				{
					this.mCostTreasureName.text = "请选择宝珠";
				}
			}
			else
			{
				if (this.mCostTreasureBackground != null)
				{
					this.mCostTreasureBackground.CustomActive(true);
					ETCImageLoader.LoadSprite(ref this.mCostTreasureBackground, this.mTreasureMaterialItemData.GetQualityInfo().Background, true);
				}
				if (this.mCostTreasureIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mCostTreasureIcon, this.mTreasureMaterialItemData.Icon, true);
				}
				if (this.mCostTreasureName != null)
				{
					this.mCostTreasureName.text = this.mTreasureMaterialItemData.GetColorName(string.Empty, false);
				}
				if (this.mTreasureMaterialItemData.ShowCount >= this.mBeadConvertCostTable.BeadCostNum)
				{
					this.mCostTreasureCount.text = TR.Value("EquipUpgrade_Merial_white", this.mTreasureMaterialItemData.ShowCount, this.mBeadConvertCostTable.BeadCostNum);
				}
				else
				{
					this.mCostTreasureCount.text = TR.Value("EquipUpgrade_Merial_Red", this.mTreasureMaterialItemData.ShowCount, this.mBeadConvertCostTable.BeadCostNum);
				}
			}
		}

		// Token: 0x06012115 RID: 74005 RVA: 0x00549965 File Offset: 0x00547D65
		private void OnReplacMaterialTogClick(bool value)
		{
			if (value)
			{
				this.mCostTreasureRoot.CustomActive(true);
				this.mCostItemRoot.CustomActive(false);
			}
			else
			{
				this.mCostTreasureRoot.CustomActive(false);
				this.mCostItemRoot.CustomActive(true);
			}
		}

		// Token: 0x06012116 RID: 74006 RVA: 0x005499A2 File Offset: 0x00547DA2
		private void OnCurrentTreasureIconBtnClick()
		{
			this.ShowTip(this.mCurrentSelectedTreasure);
		}

		// Token: 0x06012117 RID: 74007 RVA: 0x005499B0 File Offset: 0x00547DB0
		private void OnConversionEffectIconBtnClick()
		{
			this.ShowTip(this.mConversionEffectItemData);
		}

		// Token: 0x06012118 RID: 74008 RVA: 0x005499BE File Offset: 0x00547DBE
		private void ShowTip(ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x06012119 RID: 74009 RVA: 0x005499D8 File Offset: 0x00547DD8
		private void OnCostItemComLinkBtnClick()
		{
			if (this.mBeadConvertCostTable != null)
			{
				ItemComeLink.OnLink(this.mBeadConvertCostTable.MoneyCostId, 0, true, null, false, false, false, null, string.Empty);
			}
		}

		// Token: 0x0601211A RID: 74010 RVA: 0x00549A0C File Offset: 0x00547E0C
		private void OnCostItemBtnClick()
		{
			if (this.mBeadConvertCostTable != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mBeadConvertCostTable.MoneyCostId, 100, 0);
				this.ShowTip(itemData);
			}
		}

		// Token: 0x0601211B RID: 74011 RVA: 0x00549A40 File Offset: 0x00547E40
		private void OnCostTreasureBtnClick()
		{
			if (this.mCurrentSelectedTreasure == null)
			{
				return;
			}
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						if (item.SubType == 54)
						{
							if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PINK)
							{
								if (item.Quality != ItemTable.eColor.PINK)
								{
									goto IL_E3;
								}
							}
							else if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PURPLE && item.Quality != ItemTable.eColor.PURPLE)
							{
								goto IL_E3;
							}
							item.ShowCount = item.Count;
							if (item.GUID == this.mCurrentSelectedTreasure.GUID)
							{
								if (item.Count - 1 <= 0)
								{
									goto IL_E3;
								}
								item.ShowCount = item.Count - 1;
							}
							list.Add(item);
						}
					}
					IL_E3:;
				}
			}
			if (list.Count <= 0)
			{
				if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PINK)
				{
					ItemComeLink.OnLink(294, 0, true, null, false, false, false, null, string.Empty);
				}
				else if (this.currentSelectedTreasureConversionTabType == TreasureConversionTabType.TCTT_PURPLE)
				{
					ItemComeLink.OnLink(293, 0, true, null, false, false, false, null, string.Empty);
				}
				return;
			}
			list.Sort((ItemData x, ItemData y) => x.TableID - y.TableID);
			TreasureChooseParam treasureChooseParam = new TreasureChooseParam();
			treasureChooseParam.treasureChooseList = list;
			TreasureChooseParam treasureChooseParam2 = treasureChooseParam;
			treasureChooseParam2.treasureChooseCallback = (Action<ItemData>)Delegate.Combine(treasureChooseParam2.treasureChooseCallback, new Action<ItemData>(this.OnTreasureChooseCallback));
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TreasureChooseFrame>(FrameLayer.Middle, treasureChooseParam, string.Empty);
		}

		// Token: 0x0601211C RID: 74012 RVA: 0x00549C00 File Offset: 0x00548000
		private void OnTreasureBtnClick()
		{
			if (this.mCurrentSelectedTreasure == null)
			{
				return;
			}
			if (this.mBeadConvertCostTable == null)
			{
				return;
			}
			if (this.treasureMaterialType == TreasureMaterialType.Gold)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBeadConvertCostTable.MoneyCostId, true);
				if (ownedItemCount < this.mBeadConvertCostTable.MoneyCostNum)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("金币不足，转换失败。", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			else if (this.treasureMaterialType == TreasureMaterialType.Treasure)
			{
				if (this.mTreasureMaterialItemData == null)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("请放入材料宝珠", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				this.materialGuid = this.mTreasureMaterialItemData.GUID;
			}
			else if (this.treasureMaterialType == TreasureMaterialType.Both && this.mReplacMaterialTog != null)
			{
				if (this.mReplacMaterialTog.isOn)
				{
					if (this.mTreasureMaterialItemData == null)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("请放入材料宝珠", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					this.materialGuid = this.mTreasureMaterialItemData.GUID;
				}
				else
				{
					int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mBeadConvertCostTable.MoneyCostId, true);
					if (ownedItemCount2 < this.mBeadConvertCostTable.MoneyCostNum)
					{
						SystemNotifyManager.SysNotifyFloatingEffect("金币不足，转换失败。", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
			}
			if (this.mCurrentSelectedTreasure != null && this.mCurrentSelectedTreasure.Quality >= ItemTable.eColor.PINK && !DataManager<BeadCardManager>.GetInstance().TreasureConvertTip)
			{
				CommonMsgBoxOkCancelNewParamData commonMsgBoxOkCancelNewParamData = new CommonMsgBoxOkCancelNewParamData();
				commonMsgBoxOkCancelNewParamData.ContentLabel = TR.Value("TreasureConvert_tip");
				commonMsgBoxOkCancelNewParamData.IsShowNotify = true;
				commonMsgBoxOkCancelNewParamData.OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.OnCommonMsgBoxToggleClick);
				commonMsgBoxOkCancelNewParamData.LeftButtonText = TR.Value("common_data_cancel");
				commonMsgBoxOkCancelNewParamData.RightButtonText = TR.Value("common_data_sure_2");
				commonMsgBoxOkCancelNewParamData.OnRightButtonClickCallBack = new Action(this.OnOnSceneBeadConvertReq);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMsgBoxOkCancelFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMsgBoxOkCancelFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewMsgBoxOkCancelFrame>(FrameLayer.High, commonMsgBoxOkCancelNewParamData, string.Empty);
				return;
			}
			if (this.mTreasureBtn != null)
			{
				this.mTreasureBtn.enabled = false;
				InvokeMethod.Invoke(this, 0.5f, delegate()
				{
					if (this.mTreasureBtn != null)
					{
						this.mTreasureBtn.enabled = true;
					}
				});
			}
			this.OnOnSceneBeadConvertReq();
		}

		// Token: 0x0601211D RID: 74013 RVA: 0x00549E2A File Offset: 0x0054822A
		private void OnOnSceneBeadConvertReq()
		{
			if (this.mCurrentSelectedTreasure == null)
			{
				return;
			}
			DataManager<BeadCardManager>.GetInstance().OnSceneBeadConvertReq(this.mCurrentSelectedTreasure.GUID, this.materialGuid);
		}

		// Token: 0x0601211E RID: 74014 RVA: 0x00549E53 File Offset: 0x00548253
		private void OnCommonMsgBoxToggleClick(bool value)
		{
			DataManager<BeadCardManager>.GetInstance().TreasureConvertTip = value;
		}

		// Token: 0x0601211F RID: 74015 RVA: 0x00549E60 File Offset: 0x00548260
		private BeadConvertCostTable GetBeadConvertCostTableData(int quality)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<BeadConvertCostTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					BeadConvertCostTable beadConvertCostTable = keyValuePair.Value as BeadConvertCostTable;
					if (beadConvertCostTable != null)
					{
						if (beadConvertCostTable.Colour == quality)
						{
							return beadConvertCostTable;
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06012120 RID: 74016 RVA: 0x00549ECC File Offset: 0x005482CC
		private void OnAddNewItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null)
				{
					if (item.SubType == 54)
					{
						this.RefreshTreasureConversionItemDataList(false);
					}
				}
			}
		}

		// Token: 0x06012121 RID: 74017 RVA: 0x00549F2D File Offset: 0x0054832D
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			if ((eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_GOLD || eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD) && (this.treasureMaterialType == TreasureMaterialType.Gold || this.treasureMaterialType == TreasureMaterialType.Both) && this.mBeadConvertCostTable != null)
			{
				this.RefreshCostItemCount(this.mBeadConvertCostTable);
			}
		}

		// Token: 0x06012122 RID: 74018 RVA: 0x00549F6C File Offset: 0x0054836C
		private void OnTreasureConversionSuccessed(UIEvent uiEvent)
		{
			if (this.mTreasureUIListScript != null)
			{
				this.mTreasureUIListScript.ResetSelectedElementIndex();
			}
			this.mCurrentSelectedTreasure = null;
			this.mConversionEffectItemData = null;
			this.mTreasureMaterialItemData = null;
			this.UpdateCurrentTreasure();
			this.UpdateConversionEffect();
			this.UpdateCostTreasure();
			this.RefreshTreasureConversionItemDataList(false);
			if (this.mStateControl != null)
			{
				this.mStateControl.Key = "None";
			}
		}

		// Token: 0x0400BC4F RID: 48207
		[SerializeField]
		private List<TreasureConversionTabDataModel> mTabsList;

		// Token: 0x0400BC50 RID: 48208
		[SerializeField]
		private GameObject mTabPrefab;

		// Token: 0x0400BC51 RID: 48209
		[SerializeField]
		private GameObject mTabParent;

		// Token: 0x0400BC52 RID: 48210
		[SerializeField]
		private ComUIListScript mTreasureUIListScript;

		// Token: 0x0400BC53 RID: 48211
		[SerializeField]
		private Button mTreasureBtn;

		// Token: 0x0400BC54 RID: 48212
		[SerializeField]
		private Text mActivityTime;

		// Token: 0x0400BC55 RID: 48213
		[SerializeField]
		private ScrollRect mTreasureConversionScrollRect;

		// Token: 0x0400BC56 RID: 48214
		[SerializeField]
		private StateController mStateControl;

		// Token: 0x0400BC57 RID: 48215
		[SerializeField]
		private Image mCurrentTreasureBackground;

		// Token: 0x0400BC58 RID: 48216
		[SerializeField]
		private Image mCurrentTreasureIcon;

		// Token: 0x0400BC59 RID: 48217
		[SerializeField]
		private Button mCurrentTreasureIconBtn;

		// Token: 0x0400BC5A RID: 48218
		[SerializeField]
		private Image mConversionEffectBackground;

		// Token: 0x0400BC5B RID: 48219
		[SerializeField]
		private Image mConversionEffectIcon;

		// Token: 0x0400BC5C RID: 48220
		[SerializeField]
		private Button mConversionEffectIconBtn;

		// Token: 0x0400BC5D RID: 48221
		[SerializeField]
		private Button mCostTreasureBtn;

		// Token: 0x0400BC5E RID: 48222
		[SerializeField]
		private Image mCostTreasureBackground;

		// Token: 0x0400BC5F RID: 48223
		[SerializeField]
		private Image mCostTreasureIcon;

		// Token: 0x0400BC60 RID: 48224
		[SerializeField]
		private Text mCostTreasureName;

		// Token: 0x0400BC61 RID: 48225
		[SerializeField]
		private Text mCostTreasureCount;

		// Token: 0x0400BC62 RID: 48226
		[SerializeField]
		private GameObject mCostTreasureRoot;

		// Token: 0x0400BC63 RID: 48227
		[SerializeField]
		private GameObject mCostItemRoot;

		// Token: 0x0400BC64 RID: 48228
		[SerializeField]
		private Image mCostItemBackground;

		// Token: 0x0400BC65 RID: 48229
		[SerializeField]
		private Image mCostItemIcon;

		// Token: 0x0400BC66 RID: 48230
		[SerializeField]
		private Text mCostItemCount;

		// Token: 0x0400BC67 RID: 48231
		[SerializeField]
		private GameObject mCostItemComLink;

		// Token: 0x0400BC68 RID: 48232
		[SerializeField]
		private Button mCostItemComLinkBtn;

		// Token: 0x0400BC69 RID: 48233
		[SerializeField]
		private Button mCostItemBtn;

		// Token: 0x0400BC6A RID: 48234
		[SerializeField]
		private Toggle mReplacMaterialTog;

		// Token: 0x0400BC6B RID: 48235
		private TreasureConversionTabType defaultTreasureConversionTabType = TreasureConversionTabType.TCTT_PURPLE;

		// Token: 0x0400BC6C RID: 48236
		private TreasureConversionTabType currentSelectedTreasureConversionTabType;

		// Token: 0x0400BC6D RID: 48237
		private List<ItemData> treasureConversionItemDataList = new List<ItemData>();

		// Token: 0x0400BC6E RID: 48238
		private ItemData mCurrentSelectedTreasure;

		// Token: 0x0400BC6F RID: 48239
		private ItemData mConversionEffectItemData;

		// Token: 0x0400BC70 RID: 48240
		private ItemData mTreasureMaterialItemData;

		// Token: 0x0400BC71 RID: 48241
		private BeadConvertCostTable mBeadConvertCostTable;

		// Token: 0x0400BC72 RID: 48242
		private TreasureMaterialType treasureMaterialType;

		// Token: 0x0400BC73 RID: 48243
		private ulong materialGuid;
	}
}
