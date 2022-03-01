using System;
using System.Collections.Generic;
using ActivityLimitTime;
using FashionLimitTimeBuy;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200178B RID: 6027
	public class MallNewFashionMallView : MallNewBaseView
	{
		// Token: 0x0600EDDD RID: 60893 RVA: 0x003FC780 File Offset: 0x003FAB80
		private void Awake()
		{
			this._isAlreadyInit = false;
			this.BindUiEventSystem();
		}

		// Token: 0x0600EDDE RID: 60894 RVA: 0x003FC790 File Offset: 0x003FAB90
		private void BindUiEventSystem()
		{
			if (this.fashionMallClothTabList != null)
			{
				ComUIListScript comUIListScript = this.fashionMallClothTabList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnClothTabItemVisible));
			}
			if (this.fashionMallPositionTabList != null)
			{
				ComUIListScript comUIListScript2 = this.fashionMallPositionTabList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPositionTabItemVisible));
			}
			if (this.fashionMallSuitElementList != null)
			{
				this.fashionMallSuitElementList.Initialize();
				ComUIListScript comUIListScript3 = this.fashionMallSuitElementList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.fashionMallSingleElementList != null)
			{
				this.fashionMallSingleElementList.Initialize();
				ComUIListScript comUIListScript4 = this.fashionMallSingleElementList;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.fashionMallWeaponElementList != null)
			{
				this.fashionMallWeaponElementList.Initialize();
				ComUIListScript comUIListScript5 = this.fashionMallWeaponElementList;
				comUIListScript5.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript5.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.resetButton != null)
			{
				this.resetButton.onClick.RemoveAllListeners();
				this.resetButton.onClick.AddListener(new UnityAction(this.OnResetButtonClicked));
			}
			if (this.tryOnBuyButton != null)
			{
				this.tryOnBuyButton.onClick.RemoveAllListeners();
				this.tryOnBuyButton.onClick.AddListener(new UnityAction(this.OnTryOnBuyButtonClicked));
			}
		}

		// Token: 0x0600EDDF RID: 60895 RVA: 0x003FC950 File Offset: 0x003FAD50
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x0600EDE0 RID: 60896 RVA: 0x003FC960 File Offset: 0x003FAD60
		private void ClearData()
		{
			if (this._fashionMallElementDataModelList != null)
			{
				this._fashionMallElementDataModelList.Clear();
			}
			if (this._heroFashionSlotItemList != null)
			{
				for (int i = this._heroFashionSlotItemList.Count - 1; i >= 0; i--)
				{
					if (this._heroFashionSlotItemList[i] != null)
					{
						ComItemManager.Destroy(this._heroFashionSlotItemList[i]);
					}
				}
				this._heroFashionSlotItemList.Clear();
			}
			this.ResetHeroFashionTryOnDictionary();
			this._alreadyBuyFashionItemIds.Clear();
			this._clothTabType = FashionMallClothTabType.None;
			this._positionTabType = FashionMallPositionTabType.None;
			this._curMallTableId = 0;
			this._curMallType = 0;
			this._curSubType = 0;
			this._professionBaseJobId = 0;
			if (this.fashionMallClothTabDataModelList != null)
			{
				this.fashionMallClothTabDataModelList.Clear();
				this.fashionMallClothTabDataModelList = null;
			}
			if (this.fashionMallPositionTabDataModelList != null)
			{
				this.fashionMallPositionTabDataModelList.Clear();
				this.fashionMallPositionTabDataModelList = null;
			}
			if (this.fashionMallProfessionTabDataModelList != null)
			{
				this.fashionMallProfessionTabDataModelList.Clear();
				this.fashionMallProfessionTabDataModelList = null;
			}
		}

		// Token: 0x0600EDE1 RID: 60897 RVA: 0x003FCA74 File Offset: 0x003FAE74
		private void UnBindUiEventSystem()
		{
			if (this.fashionMallClothTabList != null)
			{
				ComUIListScript comUIListScript = this.fashionMallClothTabList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnClothTabItemVisible));
			}
			if (this.fashionMallPositionTabList != null)
			{
				ComUIListScript comUIListScript2 = this.fashionMallPositionTabList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPositionTabItemVisible));
			}
			if (this.fashionMallSuitElementList != null)
			{
				ComUIListScript comUIListScript3 = this.fashionMallSuitElementList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.fashionMallSingleElementList != null)
			{
				ComUIListScript comUIListScript4 = this.fashionMallSingleElementList;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.fashionMallWeaponElementList != null)
			{
				ComUIListScript comUIListScript5 = this.fashionMallWeaponElementList;
				comUIListScript5.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript5.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
			}
			if (this.resetButton != null)
			{
				this.resetButton.onClick.RemoveAllListeners();
			}
			if (this.tryOnBuyButton != null)
			{
				this.tryOnBuyButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600EDE2 RID: 60898 RVA: 0x003FCBDC File Offset: 0x003FAFDC
		public override void InitData(int index, int secondIndex = 0, int thirdIndex = 0)
		{
			if (this._isAlreadyInit)
			{
				return;
			}
			this._isAlreadyInit = true;
			this.fashionMallClothTabDataModelList = FashionMallUtility.GetClothTabDataModelList();
			this.fashionMallPositionTabDataModelList = FashionMallUtility.GetPositionTabDataModelList();
			this.fashionMallProfessionTabDataModelList = FashionMallUtility.GetProfessionTabDataModelList();
			this._professionBaseJobId = this.GetDefaultBaseJobId(index);
			if (secondIndex < 0 || secondIndex >= 3)
			{
				this._clothTabType = FashionMallClothTabType.Suit;
			}
			else
			{
				this._clothTabType = (FashionMallClothTabType)secondIndex;
			}
			if (this._clothTabType == FashionMallClothTabType.Single)
			{
				if (thirdIndex < 0 || thirdIndex > 4)
				{
					this._positionTabType = FashionMallPositionTabType.Head;
				}
				else
				{
					this._positionTabType = (FashionMallPositionTabType)thirdIndex;
				}
			}
			else
			{
				this._positionTabType = FashionMallPositionTabType.Head;
			}
			this.InitProfessionDropDownControl();
			this.InitClothTabList();
		}

		// Token: 0x0600EDE3 RID: 60899 RVA: 0x003FCC90 File Offset: 0x003FB090
		private void InitClothTabList()
		{
			if (!this.fashionMallClothTabList.IsInitialised())
			{
				this.fashionMallClothTabList.Initialize();
			}
			if (this.fashionMallClothTabDataModelList != null && this.fashionMallClothTabDataModelList.Count > 0 && this.fashionMallClothTabList != null)
			{
				this.fashionMallClothTabList.SetElementAmount(this.fashionMallClothTabDataModelList.Count);
			}
		}

		// Token: 0x0600EDE4 RID: 60900 RVA: 0x003FCCFC File Offset: 0x003FB0FC
		private void OnClothTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.fashionMallClothTabDataModelList == null || this.fashionMallClothTabDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.fashionMallClothTabDataModelList.Count)
			{
				return;
			}
			FashionMallClothTabData fashionMallClothTabData = this.fashionMallClothTabDataModelList[item.m_index];
			FashionMallClothTabItem component = item.GetComponent<FashionMallClothTabItem>();
			if (component != null && fashionMallClothTabData != null)
			{
				bool isSelected = fashionMallClothTabData.ClothTabType == this._clothTabType;
				component.InitData(fashionMallClothTabData, new OnFashionMallClothTabValueChanged(this.OnClothTabClicked), isSelected);
			}
		}

		// Token: 0x0600EDE5 RID: 60901 RVA: 0x003FCDA4 File Offset: 0x003FB1A4
		private void OnClothTabClicked(int index, FashionMallClothTabType clothTabType, int mallTableId)
		{
			this._clothTabType = clothTabType;
			this._curMallTableId = mallTableId;
			this.UpdateFashionMallContentByClothTab();
		}

		// Token: 0x0600EDE6 RID: 60902 RVA: 0x003FCDBC File Offset: 0x003FB1BC
		private void UpdateFashionMallContentByClothTab()
		{
			if (this._clothTabType == FashionMallClothTabType.Single)
			{
				this.InitPositionTabList();
				this.InitHeroFashionSlots();
			}
			else if (this._clothTabType == FashionMallClothTabType.Weapon)
			{
				this.InitHeroFashionSlots();
			}
			this.UpdateFashionMallShowTypeByClothTab(this._clothTabType);
			this.UpdateFashionMallElementList();
			this.UpdateHeroRelationInfo();
		}

		// Token: 0x0600EDE7 RID: 60903 RVA: 0x003FCE10 File Offset: 0x003FB210
		private void UpdateFashionMallShowTypeByClothTab(FashionMallClothTabType clothTabType)
		{
			if (clothTabType != FashionMallClothTabType.Single)
			{
				if (clothTabType != FashionMallClothTabType.Weapon)
				{
					this.fashionMallPositionTabListRoot.CustomActive(false);
					this.fashionMallSingleElementListRoot.CustomActive(false);
					this.fashionMallWeaponElementListRoot.CustomActive(false);
					this.resetButton.CustomActive(false);
					this.tryOnBuyButton.CustomActive(false);
					this.fashionSlotRoot.CustomActive(false);
					this.fashionMallSuitElementListRoot.CustomActive(true);
				}
				else
				{
					this.fashionMallSuitElementListRoot.CustomActive(false);
					this.fashionMallSingleElementListRoot.CustomActive(false);
					this.fashionMallPositionTabListRoot.CustomActive(false);
					this.fashionMallWeaponElementListRoot.CustomActive(true);
					this.resetButton.CustomActive(true);
					this.tryOnBuyButton.CustomActive(true);
					this.fashionSlotRoot.CustomActive(true);
				}
			}
			else
			{
				this.fashionMallSuitElementListRoot.CustomActive(false);
				this.fashionMallWeaponElementListRoot.CustomActive(false);
				this.fashionMallPositionTabListRoot.CustomActive(true);
				this.fashionMallSingleElementListRoot.CustomActive(true);
				this.resetButton.CustomActive(true);
				this.tryOnBuyButton.CustomActive(true);
				this.fashionSlotRoot.CustomActive(true);
			}
		}

		// Token: 0x0600EDE8 RID: 60904 RVA: 0x003FCF3C File Offset: 0x003FB33C
		private int GetDefaultBaseJobId(int index)
		{
			if (index <= 0)
			{
				return FashionMallUtility.GetSelfBaseJobId();
			}
			if (this.fashionMallProfessionTabDataModelList == null || this.fashionMallProfessionTabDataModelList.Count <= 0)
			{
				return FashionMallUtility.GetSelfBaseJobId();
			}
			for (int i = 0; i < this.fashionMallProfessionTabDataModelList.Count; i++)
			{
				if (this.fashionMallProfessionTabDataModelList[i].Index == index)
				{
					return this.fashionMallProfessionTabDataModelList[i].Id;
				}
			}
			return FashionMallUtility.GetSelfBaseJobId();
		}

		// Token: 0x0600EDE9 RID: 60905 RVA: 0x003FCFC4 File Offset: 0x003FB3C4
		private void InitProfessionDropDownControl()
		{
			if (this.fashionMallProfessionTabDataModelList != null && this.fashionMallProfessionTabDataModelList.Count > 0)
			{
				ComControlData comControlData = this.fashionMallProfessionTabDataModelList[0];
				for (int i = 0; i < this.fashionMallProfessionTabDataModelList.Count; i++)
				{
					if (this._professionBaseJobId == this.fashionMallProfessionTabDataModelList[i].Id)
					{
						comControlData = this.fashionMallProfessionTabDataModelList[i];
						break;
					}
				}
				if (this.professionDropDownControl != null)
				{
					this.professionDropDownControl.InitComDropDownControl(comControlData, this.fashionMallProfessionTabDataModelList, new OnComDropDownItemButtonClick(this.OnProfessionDropDownItemClicked), null);
				}
			}
		}

		// Token: 0x0600EDEA RID: 60906 RVA: 0x003FD074 File Offset: 0x003FB474
		private void UpdateFashionMallContentByProfessionBaseId()
		{
			this.UpdateFashionMallElementList();
			this.UpdateHeroRelationInfo();
		}

		// Token: 0x0600EDEB RID: 60907 RVA: 0x003FD082 File Offset: 0x003FB482
		private void OnProfessionDropDownItemClicked(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (this._professionBaseJobId == comControlData.Id)
			{
				return;
			}
			this._professionBaseJobId = comControlData.Id;
			this.UpdateFashionMallContentByProfessionBaseId();
		}

		// Token: 0x0600EDEC RID: 60908 RVA: 0x003FD0B0 File Offset: 0x003FB4B0
		private void InitPositionTabList()
		{
			if (!this.fashionMallPositionTabList.IsInitialised())
			{
				this.fashionMallPositionTabList.Initialize();
				if (this.fashionMallPositionTabDataModelList != null && this.fashionMallPositionTabDataModelList.Count > 0 && this.fashionMallPositionTabList != null)
				{
					this.fashionMallPositionTabList.SetElementAmount(this.fashionMallPositionTabDataModelList.Count);
				}
			}
		}

		// Token: 0x0600EDED RID: 60909 RVA: 0x003FD11C File Offset: 0x003FB51C
		private void OnPositionTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.fashionMallPositionTabDataModelList == null || this.fashionMallPositionTabDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.fashionMallPositionTabDataModelList.Count)
			{
				return;
			}
			FashionMallPositionTabData fashionMallPositionTabData = this.fashionMallPositionTabDataModelList[item.m_index];
			FashionMallPositionTabItem component = item.GetComponent<FashionMallPositionTabItem>();
			if (fashionMallPositionTabData != null && component != null)
			{
				bool isSelected = fashionMallPositionTabData.PositionTabType == this._positionTabType;
				component.InitData(fashionMallPositionTabData, new OnFashionMallPositionTabValueChanged(this.OnPositionTabClicked), isSelected);
			}
		}

		// Token: 0x0600EDEE RID: 60910 RVA: 0x003FD1C4 File Offset: 0x003FB5C4
		private void OnPositionTabClicked(int index, FashionMallPositionTabType positionTabType)
		{
			if (this._positionTabType == positionTabType)
			{
				return;
			}
			this._positionTabType = positionTabType;
			this.UpdateFashionMallContentByPositionTab();
		}

		// Token: 0x0600EDEF RID: 60911 RVA: 0x003FD1E0 File Offset: 0x003FB5E0
		private void UpdateFashionMallContentByPositionTab()
		{
			this.UpdateFashionMallElementList();
		}

		// Token: 0x0600EDF0 RID: 60912 RVA: 0x003FD1E8 File Offset: 0x003FB5E8
		private void UpdateFashionMallElementList()
		{
			this._curMallType = FashionMallUtility.GetMallType(this._curMallTableId);
			this._curSubType = FashionMallUtility.GetMallTableSubTypeIndex(this._clothTabType, this._positionTabType);
			List<MallItemInfo> mallItemInfoList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(this._curMallType, this._curSubType, this._professionBaseJobId);
			if (mallItemInfoList == null)
			{
				DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(this._curMallTableId, this._curSubType, this._professionBaseJobId);
			}
			else
			{
				this.ShowFashionMallElementList(mallItemInfoList);
			}
		}

		// Token: 0x0600EDF1 RID: 60913 RVA: 0x003FD268 File Offset: 0x003FB668
		private void OnElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._fashionMallElementDataModelList == null || this._fashionMallElementDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._fashionMallElementDataModelList.Count)
			{
				return;
			}
			FashionMallElementItem component = item.GetComponent<FashionMallElementItem>();
			FashionMallElementData fashionMallElementData = this._fashionMallElementDataModelList[item.m_index];
			if (component != null && fashionMallElementData != null)
			{
				component.InitData(fashionMallElementData, new OnFashionMallElementItemBuy(this.OnElementItemBuy), new OnFashionMallElementItemTryOn(this.OnElementItemTryOn));
			}
		}

		// Token: 0x0600EDF2 RID: 60914 RVA: 0x003FD30C File Offset: 0x003FB70C
		private void UpdateHeroRelationInfo()
		{
			this.ResetFashionTitleName();
			this.ResetHeroFashionTryOnDictionary();
			this.ResetHeroFashionSlots();
			int selfBaseJobId = FashionMallUtility.GetSelfBaseJobId();
			int num = this._professionBaseJobId;
			if (num == selfBaseJobId)
			{
				num = DataManager<PlayerBaseData>.GetInstance().JobTableID;
				if (this._clothTabType == FashionMallClothTabType.Single || this._clothTabType == FashionMallClothTabType.Weapon)
				{
					this.UpdateHeroFashionSlots();
				}
			}
			this.CreateHeroActor(num);
		}

		// Token: 0x0600EDF3 RID: 60915 RVA: 0x003FD370 File Offset: 0x003FB770
		private void CreateHeroActor(int heroJobId)
		{
			if (this.heroAvatarRenderer == null)
			{
				Logger.LogErrorFormat("HeroAvatarRenderer is null", new object[0]);
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(heroJobId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("Cannot find JobItem and JobId is {0}", new object[]
				{
					heroJobId
				});
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				Logger.LogErrorFormat("Cannot find ResItem with id : {0} ", new object[]
				{
					tableItem.Mode
				});
				return;
			}
			this.heroAvatarRenderer.ClearAvatar();
			this.heroAvatarRenderer.LoadAvatar(tableItem2.ModelPath, -1);
			if (heroJobId == DataManager<PlayerBaseData>.GetInstance().JobTableID)
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipFromCurrentEquiped(this.heroAvatarRenderer, null, false);
			}
			this.heroAvatarRenderer.AttachAvatar("Aureole", "Effects/Scene_effects/Effectui/EffUI_chuangjue_fazhen_JS", "[actor]Orign", false, true, false, 0f);
			this.heroAvatarRenderer.SuitAvatar(true, false);
			this.heroAvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600EDF4 RID: 60916 RVA: 0x003FD49C File Offset: 0x003FB89C
		private void InitHeroFashionSlots()
		{
			if (this._heroFashionSlotItemList.Count > 0)
			{
				return;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
			for (int i = 0; i < this.fashionSlotDataList.Count; i++)
			{
				GameObject slotRoot = this.fashionSlotDataList[i].SlotRoot;
				ComItem comItem = ComItemManager.Create(slotRoot);
				comItem.SetupSlot(ComItem.ESlotType.Opened, this.fashionSlotDataList[i].SlotName, null, string.Empty);
				comItem.labSlot.fontSize = 35;
				this._heroFashionSlotItemList.Add(comItem);
				if (i < itemsByPackageType.Count)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					comItem.Setup(item, null);
				}
			}
		}

		// Token: 0x0600EDF5 RID: 60917 RVA: 0x003FD55C File Offset: 0x003FB95C
		private void ResetHeroFashionSlots()
		{
			for (int i = 0; i < this._heroFashionSlotItemList.Count; i++)
			{
				this._heroFashionSlotItemList[i].Setup(null, null);
			}
		}

		// Token: 0x0600EDF6 RID: 60918 RVA: 0x003FD598 File Offset: 0x003FB998
		private void ResetHeroFashionTryOnDictionary()
		{
			if (this._heroFashionTryOnDic != null)
			{
				this._heroFashionTryOnDic.Clear();
			}
		}

		// Token: 0x0600EDF7 RID: 60919 RVA: 0x003FD5B0 File Offset: 0x003FB9B0
		private void UpdateHeroFashionSlots()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearFashion);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					for (int j = 0; j < this.fashionSlotDataList.Count; j++)
					{
						if (FashionMallUtility.IsSameSlotType(item.FashionWearSlotType, this.fashionSlotDataList[j].PositionTabType) && j < this._heroFashionSlotItemList.Count)
						{
							this._heroFashionSlotItemList[j].Setup(item, null);
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600EDF8 RID: 60920 RVA: 0x003FD664 File Offset: 0x003FBA64
		private void UpdateHeroFashionSlotByItemId(int itemId, EFashionWearSlotType fashionWearSlotType)
		{
			for (int i = 0; i < this.fashionSlotDataList.Count; i++)
			{
				if (FashionMallUtility.IsSameSlotType(fashionWearSlotType, this.fashionSlotDataList[i].PositionTabType))
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemId, 100, 0);
					if (itemData == null)
					{
						return;
					}
					if (i < this._heroFashionSlotItemList.Count)
					{
						this._heroFashionSlotItemList[i].Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTipFrame));
					}
				}
			}
		}

		// Token: 0x0600EDF9 RID: 60921 RVA: 0x003FD6EE File Offset: 0x003FBAEE
		private void ShowItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTipWithoutModelAvatar(itemData);
		}

		// Token: 0x0600EDFA RID: 60922 RVA: 0x003FD6FB File Offset: 0x003FBAFB
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncMallBatchBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncMallBatchBuyRes));
		}

		// Token: 0x0600EDFB RID: 60923 RVA: 0x003FD733 File Offset: 0x003FBB33
		public override void OnEnableView()
		{
			if (this._isAlreadyInit)
			{
				this.UpdateFashionMallContentByOnEnable();
			}
		}

		// Token: 0x0600EDFC RID: 60924 RVA: 0x003FD746 File Offset: 0x003FBB46
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallQueryItems, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallQueryItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncMallBatchBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncMallBatchBuyRes));
			FashionMallUtility.CloseFashionLimitTimeBuyFrame();
		}

		// Token: 0x0600EDFD RID: 60925 RVA: 0x003FD784 File Offset: 0x003FBB84
		private void OnSyncWorldMallQueryItem(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			int num2 = (int)uiEvent.Param2;
			int num3 = (int)uiEvent.Param3;
			if (num != this._curMallType || num2 != this._curSubType || num3 != this._professionBaseJobId)
			{
				return;
			}
			List<MallItemInfo> mallItemInfoList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(this._curMallType, this._curSubType, this._professionBaseJobId);
			this.ShowFashionMallElementList(mallItemInfoList);
		}

		// Token: 0x0600EDFE RID: 60926 RVA: 0x003FD808 File Offset: 0x003FBC08
		private void ShowFashionMallElementList(List<MallItemInfo> mallItems)
		{
			if (mallItems == null || mallItems.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._fashionMallElementDataModelList.Count; i++)
			{
				this._fashionMallElementDataModelList[i].MallItemInfo = null;
			}
			this._fashionMallElementDataModelList.Clear();
			FashionMallElementData fashionMallElementData = new FashionMallElementData
			{
				ClothTabType = this._clothTabType,
				MallItemInfo = mallItems[0]
			};
			for (int j = 1; j < mallItems.Count; j++)
			{
				FashionMallElementData item = new FashionMallElementData
				{
					ClothTabType = this._clothTabType,
					MallItemInfo = mallItems[j]
				};
				this._fashionMallElementDataModelList.Add(item);
			}
			this.StopFashionMallElementListMovement();
			this.ResetFashionMallElementList();
			if (this._clothTabType == FashionMallClothTabType.Suit)
			{
				if (this.fashionMallSuitElementItem != null)
				{
					this.fashionMallSuitElementItem.InitData(fashionMallElementData, new OnFashionMallElementItemBuy(this.OnElementItemBuy), new OnFashionMallElementItemTryOn(this.OnElementItemTryOn));
				}
				this.fashionMallSuitElementList.SetElementAmount(this._fashionMallElementDataModelList.Count);
				this.fashionMallSuitElementList.ResetContentPosition();
			}
			else if (this._clothTabType == FashionMallClothTabType.Single)
			{
				this._fashionMallElementDataModelList.Insert(0, fashionMallElementData);
				this.fashionMallSingleElementList.SetElementAmount(this._fashionMallElementDataModelList.Count);
				this.fashionMallSingleElementList.ResetContentPosition();
			}
			else if (this._clothTabType == FashionMallClothTabType.Weapon)
			{
				this._fashionMallElementDataModelList.Insert(0, fashionMallElementData);
				this.UpdateFashionWeaponElementListRootPosition(this._fashionMallElementDataModelList.Count);
				this.fashionMallWeaponElementList.SetElementAmount(this._fashionMallElementDataModelList.Count);
				this.fashionMallWeaponElementList.ResetContentPosition();
			}
		}

		// Token: 0x0600EDFF RID: 60927 RVA: 0x003FD9C4 File Offset: 0x003FBDC4
		private void UpdateFashionWeaponElementListRootPosition(int fashionWeaponNumber)
		{
			float num = 0f;
			if (this.fashionMallWeaponElementListRoot != null)
			{
				num = this.fashionMallWeaponElementListRoot.transform.localPosition.x;
			}
			if (fashionWeaponNumber <= 1)
			{
				if (this.specialWeaponElementListPosition != null)
				{
					num = this.specialWeaponElementListPosition.transform.localPosition.x;
				}
			}
			else if (this.normalWeaponElementListPosition != null)
			{
				num = this.normalWeaponElementListPosition.transform.localPosition.x;
			}
			if (this.fashionMallWeaponElementListRoot != null)
			{
				this.fashionMallWeaponElementListRoot.transform.localPosition = new Vector3(num, this.fashionMallWeaponElementListRoot.transform.localPosition.y, this.fashionMallWeaponElementListRoot.transform.localPosition.z);
			}
		}

		// Token: 0x0600EE00 RID: 60928 RVA: 0x003FDABC File Offset: 0x003FBEBC
		private void ResetFashionMallElementList()
		{
			if (this.fashionMallSingleElementList != null)
			{
				this.fashionMallSingleElementList.SetElementAmount(0);
			}
			if (this.fashionMallWeaponElementList != null)
			{
				this.fashionMallWeaponElementList.SetElementAmount(0);
			}
			if (this.fashionMallSuitElementList != null)
			{
				this.fashionMallSuitElementList.SetElementAmount(0);
			}
		}

		// Token: 0x0600EE01 RID: 60929 RVA: 0x003FDB20 File Offset: 0x003FBF20
		private void StopFashionMallElementListMovement()
		{
			if (this.fashionMallSingleElementList != null && this.fashionMallSingleElementList.m_scrollRect != null)
			{
				this.fashionMallSingleElementList.m_scrollRect.StopMovement();
			}
			if (this.fashionMallSuitElementList != null && this.fashionMallSuitElementList.m_scrollRect != null)
			{
				this.fashionMallSuitElementList.m_scrollRect.StopMovement();
			}
			if (this.fashionMallWeaponElementList != null && this.fashionMallWeaponElementList.m_scrollRect != null)
			{
				this.fashionMallWeaponElementList.m_scrollRect.StopMovement();
			}
		}

		// Token: 0x0600EE02 RID: 60930 RVA: 0x003FDBD4 File Offset: 0x003FBFD4
		private void UpdateFashionMallContentByOnEnable()
		{
			this.UpdateHeroRelationInfo();
			List<MallItemInfo> mallItemInfoList = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(this._curMallType, this._curSubType, this._professionBaseJobId);
			this.ShowFashionMallElementList(mallItemInfoList);
		}

		// Token: 0x0600EE03 RID: 60931 RVA: 0x003FDC0C File Offset: 0x003FC00C
		private void OnElementItemBuy(MallItemInfo mallItemInfo)
		{
			if (mallItemInfo == null)
			{
				return;
			}
			FashionMallUtility.CloseFashionMallBuyFrame();
			FashionMallUtility.CloseFashionLimitTimeBuyFrame();
			if (mallItemInfo.goodsSubType != 0)
			{
				FashionOutComeData fashionOutComeData = new FashionOutComeData();
				fashionOutComeData.mallItemInfos = new List<MallItemInfo>
				{
					mallItemInfo
				};
				fashionOutComeData.fashionTypeIndex = ((this._clothTabType != FashionMallClothTabType.Suit) ? FashionMallMainIndex.FashionOne : FashionMallMainIndex.FashionAll);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionLimitTimeBuyFrame>(FrameLayer.Middle, fashionOutComeData, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, mallItemInfo, string.Empty);
			}
		}

		// Token: 0x0600EE04 RID: 60932 RVA: 0x003FDC90 File Offset: 0x003FC090
		private void OnElementItemTryOn(MallItemInfo mallItemInfo)
		{
			if (mallItemInfo == null)
			{
				return;
			}
			if (this.fashionNameText != null)
			{
				if (this._clothTabType == FashionMallClothTabType.Single || this._clothTabType == FashionMallClothTabType.Weapon)
				{
					this.ResetFashionTitleName();
				}
				else
				{
					string giftName = mallItemInfo.giftName;
					this.fashionNameText.text = giftName;
					if (mallItemInfo.giftItems.Length > 0)
					{
						int id = (int)mallItemInfo.giftItems[0].id;
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
						if (tableItem != null)
						{
							if (tableItem.Color == ItemTable.eColor.PURPLE)
							{
								this.fashionNameText.text = string.Format(TR.Value("Fashion_mall_Name_Color3"), giftName);
							}
							else if (tableItem.Color == ItemTable.eColor.BLUE)
							{
								this.fashionNameText.text = string.Format(TR.Value("Fashion_mall_Name_Color2"), giftName);
							}
						}
					}
				}
			}
			if (this.heroAvatarRenderer == null)
			{
				return;
			}
			uint[] array = DataManager<FashionLimitTimeBuyManager>.GetInstance().TryGetItemIdsInMallItemInfo(mallItemInfo, 0);
			if (array == null || array.Length <= 0 || (array.Length == 1 && array[0] == 0U))
			{
				return;
			}
			for (int i = 0; i < array.Length; i++)
			{
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)array[i], string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					this.UpdateHeroActorFashion(tableItem2);
					if (this._clothTabType == FashionMallClothTabType.Single || this._clothTabType == FashionMallClothTabType.Weapon)
					{
						EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(tableItem2);
						if (!this._heroFashionTryOnDic.ContainsKey(equipSlotType))
						{
							this._heroFashionTryOnDic.Add(equipSlotType, null);
						}
						this._heroFashionTryOnDic[equipSlotType] = mallItemInfo;
						this.UpdateHeroFashionSlotByItemId((int)mallItemInfo.itemid, equipSlotType);
					}
				}
			}
		}

		// Token: 0x0600EE05 RID: 60933 RVA: 0x003FDE5C File Offset: 0x003FC25C
		private void UpdateHeroActorFashion(ItemTable itemTable)
		{
			EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(itemTable);
			if (itemTable.SubType == ItemTable.eSubType.FASHION_WEAPON)
			{
				int jobID = this._professionBaseJobId;
				if (this._professionBaseJobId == FashionMallUtility.GetSelfBaseJobId())
				{
					jobID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
				}
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipWeapon(this.heroAvatarRenderer, jobID, itemTable.ID, null, false);
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.heroAvatarRenderer, equipSlotType, 0, null, 0, false);
				DataManager<PlayerBaseData>.GetInstance().AvatarEquipPart(this.heroAvatarRenderer, equipSlotType, itemTable.ID, null, 0, false);
			}
			this.heroAvatarRenderer.ChangeAction("Anim_Show_Idle", 1f, true);
		}

		// Token: 0x0600EE06 RID: 60934 RVA: 0x003FDF04 File Offset: 0x003FC304
		private void OnTryOnBuyButtonClicked()
		{
			if (this._heroFashionTryOnDic.Count <= 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Fashion_mall_Try_On_Nothing"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this._clothTabType != FashionMallClothTabType.Single && this._clothTabType != FashionMallClothTabType.Weapon)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Fashion_mall_Try_On_Nothing"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			FashionMallUtility.CloseFashionLimitTimeBuyFrame();
			this.BuyTryOnFashions();
		}

		// Token: 0x0600EE07 RID: 60935 RVA: 0x003FDF68 File Offset: 0x003FC368
		private void BuyTryOnFashions()
		{
			Dictionary<EFashionWearSlotType, MallItemInfo>.Enumerator enumerator = this._heroFashionTryOnDic.GetEnumerator();
			List<MallItemInfo> list = new List<MallItemInfo>();
			while (enumerator.MoveNext())
			{
				KeyValuePair<EFashionWearSlotType, MallItemInfo> keyValuePair = enumerator.Current;
				MallItemInfo value = keyValuePair.Value;
				list.Add(value);
			}
			FashionOutComeData userData = new FashionOutComeData
			{
				mallItemInfos = list,
				fashionTypeIndex = FashionMallMainIndex.FashionOne
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<FashionLimitTimeBuyFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600EE08 RID: 60936 RVA: 0x003FDFDD File Offset: 0x003FC3DD
		private void OnResetButtonClicked()
		{
			this.UpdateHeroRelationInfo();
		}

		// Token: 0x0600EE09 RID: 60937 RVA: 0x003FDFE8 File Offset: 0x003FC3E8
		private void OnSyncMallBatchBuyRes(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			SCMallBatchBuyRes scmallBatchBuyRes = uiEvent.Param1 as SCMallBatchBuyRes;
			if (scmallBatchBuyRes == null)
			{
				return;
			}
			FashionMallUtility.CloseFashionLimitTimeBuyFrame();
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.HaveFashionDiscountActivity && this._clothTabType == FashionMallClothTabType.Suit)
			{
				DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(this._curMallTableId, this._curSubType, this._professionBaseJobId);
			}
			if (FashionMallUtility.GetSelfBaseJobId() != this._professionBaseJobId)
			{
				return;
			}
			this._alreadyBuyFashionItemIds.Clear();
			for (int i = 0; i < scmallBatchBuyRes.itemUids.Length; i++)
			{
				this._alreadyBuyFashionItemIds.Add(scmallBatchBuyRes.itemUids[i]);
			}
			if (DataManager<PlayerBaseData>.GetInstance().isNotify)
			{
				SystemNotifyManager.SetMallBuyMsgBoxOKCancel(TR.Value("Fashion_mall_Wear_Fashion_RightNow"), new UnityAction(this.ClickOkWearFashion), null, FrameLayer.High, false);
			}
			else if (DataManager<PlayerBaseData>.GetInstance().isWear)
			{
				this.ClickOkWearFashion();
			}
		}

		// Token: 0x0600EE0A RID: 60938 RVA: 0x003FE0E0 File Offset: 0x003FC4E0
		private void ClickOkWearFashion()
		{
			for (int i = 0; i < this._alreadyBuyFashionItemIds.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this._alreadyBuyFashionItemIds[i]);
				if (item != null)
				{
					DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.UpdateHeroActorFashion(tableItem);
						if (this._clothTabType == FashionMallClothTabType.Single || this._clothTabType == FashionMallClothTabType.Weapon)
						{
							EFashionWearSlotType equipSlotType = FashionMallUtility.GetEquipSlotType(tableItem);
							this.UpdateHeroFashionSlotByItemId(tableItem.ID, equipSlotType);
						}
					}
				}
			}
			DataManager<PlayerBaseData>.GetInstance().isWear = true;
		}

		// Token: 0x0600EE0B RID: 60939 RVA: 0x003FE19D File Offset: 0x003FC59D
		private void ResetFashionTitleName()
		{
			if (this.fashionNameText != null)
			{
				this.fashionNameText.text = TR.Value("Fashion_mall_Preview_title");
			}
		}

		// Token: 0x04009152 RID: 37202
		private bool _isAlreadyInit;

		// Token: 0x04009153 RID: 37203
		private FashionMallClothTabType _clothTabType = FashionMallClothTabType.None;

		// Token: 0x04009154 RID: 37204
		private FashionMallPositionTabType _positionTabType = FashionMallPositionTabType.None;

		// Token: 0x04009155 RID: 37205
		private int _curMallTableId;

		// Token: 0x04009156 RID: 37206
		private int _curMallType;

		// Token: 0x04009157 RID: 37207
		private int _curSubType;

		// Token: 0x04009158 RID: 37208
		private Dictionary<EFashionWearSlotType, MallItemInfo> _heroFashionTryOnDic = new Dictionary<EFashionWearSlotType, MallItemInfo>();

		// Token: 0x04009159 RID: 37209
		private List<ulong> _alreadyBuyFashionItemIds = new List<ulong>();

		// Token: 0x0400915A RID: 37210
		private List<FashionMallElementData> _fashionMallElementDataModelList = new List<FashionMallElementData>();

		// Token: 0x0400915B RID: 37211
		private List<ComItem> _heroFashionSlotItemList = new List<ComItem>();

		// Token: 0x0400915C RID: 37212
		private List<FashionMallClothTabData> fashionMallClothTabDataModelList;

		// Token: 0x0400915D RID: 37213
		private List<FashionMallPositionTabData> fashionMallPositionTabDataModelList;

		// Token: 0x0400915E RID: 37214
		private List<ComControlData> fashionMallProfessionTabDataModelList;

		// Token: 0x0400915F RID: 37215
		private int _professionBaseJobId;

		// Token: 0x04009160 RID: 37216
		[Space(10f)]
		[Header("FashionClothInfo")]
		[SerializeField]
		private ComUIListScript fashionMallClothTabList;

		// Token: 0x04009161 RID: 37217
		[Space(10f)]
		[Header("FashionProfessionInfo")]
		[SerializeField]
		private ComDropDownControl professionDropDownControl;

		// Token: 0x04009162 RID: 37218
		[Space(10f)]
		[Header("FashionPositionInfo")]
		[SerializeField]
		private ComUIListScript fashionMallPositionTabList;

		// Token: 0x04009163 RID: 37219
		[SerializeField]
		private GameObject fashionMallPositionTabListRoot;

		// Token: 0x04009164 RID: 37220
		[Space(10f)]
		[Header("FashionElementInfo")]
		[SerializeField]
		private ComUIListScript fashionMallSuitElementList;

		// Token: 0x04009165 RID: 37221
		[SerializeField]
		private GameObject fashionMallSuitElementListRoot;

		// Token: 0x04009166 RID: 37222
		[SerializeField]
		private ComUIListScript fashionMallSingleElementList;

		// Token: 0x04009167 RID: 37223
		[SerializeField]
		private GameObject fashionMallSingleElementListRoot;

		// Token: 0x04009168 RID: 37224
		[SerializeField]
		private ComUIListScript fashionMallWeaponElementList;

		// Token: 0x04009169 RID: 37225
		[SerializeField]
		private GameObject fashionMallWeaponElementListRoot;

		// Token: 0x0400916A RID: 37226
		[SerializeField]
		private GameObject normalWeaponElementListPosition;

		// Token: 0x0400916B RID: 37227
		[SerializeField]
		private GameObject specialWeaponElementListPosition;

		// Token: 0x0400916C RID: 37228
		[SerializeField]
		private FashionMallSuitElementItem fashionMallSuitElementItem;

		// Token: 0x0400916D RID: 37229
		[Space(10f)]
		[Header("HeroActor")]
		[SerializeField]
		private GeAvatarRendererEx heroAvatarRenderer;

		// Token: 0x0400916E RID: 37230
		[SerializeField]
		private Text fashionNameText;

		// Token: 0x0400916F RID: 37231
		[SerializeField]
		private GameObject fashionShowRoot;

		// Token: 0x04009170 RID: 37232
		[Space(10f)]
		[Header("FashionSlot")]
		[SerializeField]
		private GameObject fashionSlotRoot;

		// Token: 0x04009171 RID: 37233
		[SerializeField]
		private List<FashionMallPositionSlotData> fashionSlotDataList = new List<FashionMallPositionSlotData>();

		// Token: 0x04009172 RID: 37234
		[Space(10f)]
		[Header("FashionOther")]
		[SerializeField]
		private Button resetButton;

		// Token: 0x04009173 RID: 37235
		[SerializeField]
		private Button tryOnBuyButton;
	}
}
