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
	// Token: 0x02001B40 RID: 6976
	public class InscriptionComposeFrameView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x060111D3 RID: 70099 RVA: 0x004E9190 File Offset: 0x004E7590
		private void Awake()
		{
			if (this.btnCompopse != null)
			{
				this.btnCompopse.onClick.RemoveAllListeners();
				this.btnCompopse.onClick.AddListener(new UnityAction(this.OnBtnCompopseClick));
			}
			this.BindUIEvent();
			this.InitInscriptionScrollView();
			this.InitCanBeGetIncriptionUIList();
			this.RegisterDelegateHandler();
		}

		// Token: 0x060111D4 RID: 70100 RVA: 0x004E91F4 File Offset: 0x004E75F4
		private void RegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
		}

		// Token: 0x060111D5 RID: 70101 RVA: 0x004E9250 File Offset: 0x004E7650
		private void UnRegisterDelegateHandler()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
		}

		// Token: 0x060111D6 RID: 70102 RVA: 0x004E92AC File Offset: 0x004E76AC
		private void OnDestroy()
		{
			this.UnBindUIEvent();
			this.UnInitInscriptionScrollView();
			this.UnInitCanBeGetIncriptionUIList();
			if (this.inscriptionItemDataList != null)
			{
				this.inscriptionItemDataList.Clear();
			}
			if (this.inscriptionQulityTabDataList != null)
			{
				this.inscriptionQulityTabDataList.Clear();
			}
			if (this.inscriptionThirdTypeTabDataList != null)
			{
				this.inscriptionThirdTypeTabDataList.Clear();
			}
			if (this.canBeObTainedInscriptionItemList != null)
			{
				this.canBeObTainedInscriptionItemList.Clear();
			}
			if (this.putInIncriptionItemDataList != null)
			{
				this.putInIncriptionItemDataList.Clear();
			}
			this.defalutQultityId = 0;
			this.defalutThirdTypeId = 0;
			this.selectIncriptionQultity = 0;
			this.maxSynthesisNum = 0;
			this.currentSelectIncriptionItemData = null;
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x060111D7 RID: 70103 RVA: 0x004E9364 File Offset: 0x004E7764
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.inscriptionQulityTabDataList = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionQualityTabDataList();
			this.inscriptionThirdTypeTabDataList = DataManager<InscriptionMosaicDataManager>.GetInstance().GetInscriptionThirdTypeTabDataList();
			this.InitQulityDrop();
			this.InitThridTypeDrop();
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
		}

		// Token: 0x060111D8 RID: 70104 RVA: 0x004E93B0 File Offset: 0x004E77B0
		public void OnEnableView()
		{
			this.RegisterDelegateHandler();
			this.ResetFrameIno();
		}

		// Token: 0x060111D9 RID: 70105 RVA: 0x004E93BE File Offset: 0x004E77BE
		public void OnDisableView()
		{
			this.UnRegisterDelegateHandler();
		}

		// Token: 0x060111DA RID: 70106 RVA: 0x004E93C8 File Offset: 0x004E77C8
		private void ResetFrameIno()
		{
			this.maxSynthesisNum = this.inscriptionComposeItems.Length;
			this.selectIncriptionQultity = 0;
			this.putInIncriptionItemDataList.Clear();
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
			this.UpdatePutInIncriptionItemInfo(this.maxSynthesisNum);
			this.UpdateCanBeObtainedInscriptionItemDataInfo(this.currentSelectIncriptionItemData);
		}

		// Token: 0x060111DB RID: 70107 RVA: 0x004E9420 File Offset: 0x004E7820
		private void InitCanBeGetIncriptionUIList()
		{
			if (this.canBeGetIncriptionUIList != null)
			{
				this.canBeGetIncriptionUIList.Initialize();
				ComUIListScript comUIListScript = this.canBeGetIncriptionUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindCanBeGetIncriptionItemDelegate));
				ComUIListScript comUIListScript2 = this.canBeGetIncriptionUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnCanBeGetIncriptionItemVisiableDelegate));
			}
		}

		// Token: 0x060111DC RID: 70108 RVA: 0x004E9498 File Offset: 0x004E7898
		private void UnInitCanBeGetIncriptionUIList()
		{
			if (this.canBeGetIncriptionUIList != null)
			{
				ComUIListScript comUIListScript = this.canBeGetIncriptionUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindCanBeGetIncriptionItemDelegate));
				ComUIListScript comUIListScript2 = this.canBeGetIncriptionUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnCanBeGetIncriptionItemVisiableDelegate));
			}
		}

		// Token: 0x060111DD RID: 70109 RVA: 0x004E9504 File Offset: 0x004E7904
		private InscriptionSynthesisAvailableItem OnBindCanBeGetIncriptionItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<InscriptionSynthesisAvailableItem>();
		}

		// Token: 0x060111DE RID: 70110 RVA: 0x004E950C File Offset: 0x004E790C
		private void OnCanBeGetIncriptionItemVisiableDelegate(ComUIListElementScript item)
		{
			InscriptionSynthesisAvailableItem inscriptionSynthesisAvailableItem = item.gameObjectBindScript as InscriptionSynthesisAvailableItem;
			if (inscriptionSynthesisAvailableItem != null && item.m_index >= 0 && item.m_index < this.canBeObTainedInscriptionItemList.Count)
			{
				inscriptionSynthesisAvailableItem.OnItemVisiable(this.canBeObTainedInscriptionItemList[item.m_index]);
			}
		}

		// Token: 0x060111DF RID: 70111 RVA: 0x004E956C File Offset: 0x004E796C
		private void InitInscriptionScrollView()
		{
			if (this.inscriptionScrollView != null)
			{
				this.inscriptionScrollView.Initialize();
				ComUIListScript comUIListScript = this.inscriptionScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.inscriptionScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060111E0 RID: 70112 RVA: 0x004E95E4 File Offset: 0x004E79E4
		private void UnInitInscriptionScrollView()
		{
			if (this.inscriptionScrollView != null)
			{
				ComUIListScript comUIListScript = this.inscriptionScrollView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.inscriptionScrollView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060111E1 RID: 70113 RVA: 0x004E9650 File Offset: 0x004E7A50
		private InscriptionSelectItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<InscriptionSelectItem>();
		}

		// Token: 0x060111E2 RID: 70114 RVA: 0x004E9658 File Offset: 0x004E7A58
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			InscriptionSelectItem inscriptionSelectItem = item.gameObjectBindScript as InscriptionSelectItem;
			if (inscriptionSelectItem != null && item.m_index >= 0 && item.m_index < this.inscriptionItemDataList.Count)
			{
				inscriptionSelectItem.OnItemVisiable(this.inscriptionItemDataList[item.m_index], this.selectIncriptionQultity, new OnSelectInscriptionItemClick(this.IncriptionPutInList), this.putInIncriptionItemDataList);
			}
		}

		// Token: 0x060111E3 RID: 70115 RVA: 0x004E96D0 File Offset: 0x004E7AD0
		private void IncriptionPutInList(ItemData itemData, InscriptionSelectItem inscriptionSelectItem)
		{
			if (itemData == null)
			{
				return;
			}
			this.currentSelectIncriptionItemData = itemData;
			if (this.selectIncriptionQultity != 0 && this.selectIncriptionQultity != (int)itemData.Quality)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Compose_QualityDifferent_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			this.selectIncriptionQultity = (int)itemData.Quality;
			this.maxSynthesisNum = DataManager<InscriptionMosaicDataManager>.GetInstance().GetMaxInscriptionSynthesisNum(this.selectIncriptionQultity);
			if (this.putInIncriptionItemDataList.Count >= this.maxSynthesisNum)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Compose_Beyond_Desc", this.maxSynthesisNum), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int count = itemData.Count;
			int num = 0;
			for (int i = 0; i < this.putInIncriptionItemDataList.Count; i++)
			{
				ItemData itemData2 = this.putInIncriptionItemDataList[i];
				if (itemData2 != null)
				{
					if (itemData2.TableID == itemData.TableID)
					{
						num++;
					}
				}
			}
			if (num >= count)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Compose_SameQualityBeyond_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			ItemData item = ItemDataManager.CreateItemDataFromTable(itemData.TableID, 100, 0);
			this.putInIncriptionItemDataList.Add(item);
			if (inscriptionSelectItem != null)
			{
				inscriptionSelectItem.SetCheckMaskRoot(true);
			}
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, false);
			this.UpdatePutInIncriptionItemInfo(this.maxSynthesisNum);
			this.UpdateCanBeObtainedInscriptionItemDataInfo(itemData);
		}

		// Token: 0x060111E4 RID: 70116 RVA: 0x004E982C File Offset: 0x004E7C2C
		private void UpdatePutInIncriptionItemInfo(int maxSynthesisNum)
		{
			for (int i = 0; i < this.inscriptionComposeItems.Length; i++)
			{
				InscriptionComposeItem inscriptionComposeItem = this.inscriptionComposeItems[i];
				if (!(inscriptionComposeItem == null))
				{
					if (i < maxSynthesisNum)
					{
						inscriptionComposeItem.SetUp(null);
					}
					else
					{
						inscriptionComposeItem.SetupSlot();
					}
				}
			}
			for (int j = 0; j < this.inscriptionComposeItems.Length; j++)
			{
				InscriptionComposeItem inscriptionComposeItem2 = this.inscriptionComposeItems[j];
				if (!(inscriptionComposeItem2 == null))
				{
					if (j < this.putInIncriptionItemDataList.Count)
					{
						ItemData itemData = this.putInIncriptionItemDataList[j];
						if (itemData != null)
						{
							inscriptionComposeItem2.SetUp(itemData);
						}
					}
				}
			}
		}

		// Token: 0x060111E5 RID: 70117 RVA: 0x004E98EC File Offset: 0x004E7CEC
		public void UpdateCanBeObtainedInscriptionItemDataInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.canBeGetRoot.CustomActive(false);
			if (this.putInIncriptionItemDataList.Count != 0)
			{
				List<CanBeObtainedInscriptionItemData> canBeObtainedInscriptionItemData = DataManager<InscriptionMosaicDataManager>.GetInstance().GetCanBeObtainedInscriptionItemData((int)itemData.Quality, this.putInIncriptionItemDataList.Count);
				if (this.canBeObTainedInscriptionItemList != null)
				{
					this.canBeObTainedInscriptionItemList.Clear();
				}
				this.canBeObTainedInscriptionItemList.AddRange(canBeObtainedInscriptionItemData);
				if (this.canBeObTainedInscriptionItemList.Count > 0)
				{
					this.canBeGetRoot.CustomActive(true);
				}
				this.canBeGetIncriptionUIList.SetElementAmount(this.canBeObTainedInscriptionItemList.Count);
			}
		}

		// Token: 0x060111E6 RID: 70118 RVA: 0x004E9990 File Offset: 0x004E7D90
		private void RefrshInscriptionItemList(int defalutQultityId, int defalutThirdTypeId, bool setScrollRect = true)
		{
			if (this.inscriptionItemDataList != null)
			{
				this.inscriptionItemDataList.Clear();
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Inscription);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						if (defalutQultityId == 0 || defalutQultityId == (int)item.Quality)
						{
							if (defalutThirdTypeId == 0 || defalutThirdTypeId == (int)item.ThirdType)
							{
								this.inscriptionItemDataList.Add(item);
							}
						}
					}
				}
			}
			this.inscriptionItemDataList.Sort(new Comparison<ItemData>(this.SortInscriptionItemList));
			if (this.inscriptionScrollView != null)
			{
				this.inscriptionScrollView.SetElementAmount(this.inscriptionItemDataList.Count);
			}
			if (this.inscriptionItemDataList.Count <= 0)
			{
				if (defalutQultityId > 0 || defalutThirdTypeId > 0)
				{
					this.noItemTips.text = "背包中未有符合条件的铭文";
				}
				else
				{
					this.noItemTips.text = "背包中未有铭文";
				}
			}
			if (setScrollRect && this.inscriptionScrollRect != null)
			{
				this.inscriptionScrollRect.verticalNormalizedPosition = 1f;
			}
		}

		// Token: 0x060111E7 RID: 70119 RVA: 0x004E9AE0 File Offset: 0x004E7EE0
		private int SortInscriptionItemList(ItemData x, ItemData y)
		{
			if (x.Quality != y.Quality)
			{
				return y.Quality - x.Quality;
			}
			if (x.ThirdType != y.ThirdType)
			{
				return x.ThirdType - y.ThirdType;
			}
			return x.TableID - y.TableID;
		}

		// Token: 0x060111E8 RID: 70120 RVA: 0x004E9B38 File Offset: 0x004E7F38
		private void InitQulityDrop()
		{
			if (this.inscriptionQulityTabDataList != null && this.inscriptionQulityTabDataList.Count > 0)
			{
				ComControlData comControlData = this.inscriptionQulityTabDataList[0];
				for (int i = 0; i < this.inscriptionQulityTabDataList.Count; i++)
				{
					if (this.defalutQultityId == this.inscriptionQulityTabDataList[i].Id)
					{
						comControlData = this.inscriptionQulityTabDataList[i];
						break;
					}
				}
				if (this.qulityDrop != null)
				{
					this.qulityDrop.InitComDropDownControl(comControlData, this.inscriptionQulityTabDataList, new OnComDropDownItemButtonClick(this.OnInscriptionQulityDropDownItemClicked), null);
				}
			}
		}

		// Token: 0x060111E9 RID: 70121 RVA: 0x004E9BE8 File Offset: 0x004E7FE8
		private void OnInscriptionQulityDropDownItemClicked(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (this.defalutQultityId == comControlData.Id)
			{
				return;
			}
			this.defalutQultityId = comControlData.Id;
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
		}

		// Token: 0x060111EA RID: 70122 RVA: 0x004E9C24 File Offset: 0x004E8024
		private void InitThridTypeDrop()
		{
			if (this.inscriptionThirdTypeTabDataList != null && this.inscriptionThirdTypeTabDataList.Count > 0)
			{
				ComControlData comControlData = this.inscriptionThirdTypeTabDataList[0];
				for (int i = 0; i < this.inscriptionThirdTypeTabDataList.Count; i++)
				{
					if (this.defalutThirdTypeId == this.inscriptionThirdTypeTabDataList[i].Id)
					{
						comControlData = this.inscriptionThirdTypeTabDataList[i];
						break;
					}
				}
				if (this.typeDrop != null)
				{
					this.typeDrop.InitComDropDownControl(comControlData, this.inscriptionThirdTypeTabDataList, new OnComDropDownItemButtonClick(this.OnInscriptionThirdTypeDropDownItemClicked), null);
				}
			}
		}

		// Token: 0x060111EB RID: 70123 RVA: 0x004E9CD4 File Offset: 0x004E80D4
		private void OnInscriptionThirdTypeDropDownItemClicked(ComControlData comControlData)
		{
			if (comControlData == null)
			{
				return;
			}
			if (this.defalutThirdTypeId == comControlData.Id)
			{
				return;
			}
			this.defalutThirdTypeId = comControlData.Id;
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
		}

		// Token: 0x060111EC RID: 70124 RVA: 0x004E9D0E File Offset: 0x004E810E
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCloseSynthesisIncriptionChanged, new ClientEventSystem.UIEventHandler(this.OnCloseSynthesisIncriptionChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnIncriptionSynthesisSuccess, new ClientEventSystem.UIEventHandler(this.OnIncriptionSynthesisSuccess));
		}

		// Token: 0x060111ED RID: 70125 RVA: 0x004E9D46 File Offset: 0x004E8146
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCloseSynthesisIncriptionChanged, new ClientEventSystem.UIEventHandler(this.OnCloseSynthesisIncriptionChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnIncriptionSynthesisSuccess, new ClientEventSystem.UIEventHandler(this.OnIncriptionSynthesisSuccess));
		}

		// Token: 0x060111EE RID: 70126 RVA: 0x004E9D80 File Offset: 0x004E8180
		private void OnCloseSynthesisIncriptionChanged(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			for (int i = 0; i < this.putInIncriptionItemDataList.Count; i++)
			{
				ItemData itemData = this.putInIncriptionItemDataList[i];
				if (itemData != null)
				{
					if (itemData.TableID == num)
					{
						this.putInIncriptionItemDataList.Remove(itemData);
						break;
					}
				}
			}
			if (this.putInIncriptionItemDataList.Count <= 0)
			{
				this.selectIncriptionQultity = 0;
				this.maxSynthesisNum = this.inscriptionComposeItems.Length;
				this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
			}
			else
			{
				this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, false);
			}
			this.UpdatePutInIncriptionItemInfo(this.maxSynthesisNum);
			this.UpdateCanBeObtainedInscriptionItemDataInfo(this.currentSelectIncriptionItemData);
		}

		// Token: 0x060111EF RID: 70127 RVA: 0x004E9E5B File Offset: 0x004E825B
		private void OnIncriptionSynthesisSuccess(UIEvent uiEvent)
		{
			this.ResetFrameIno();
		}

		// Token: 0x060111F0 RID: 70128 RVA: 0x004E9E63 File Offset: 0x004E8263
		private void _OnAddNewItem(List<Item> items)
		{
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
		}

		// Token: 0x060111F1 RID: 70129 RVA: 0x004E9E78 File Offset: 0x004E8278
		private void _OnRemoveItem(ItemData itemData)
		{
			this.RefrshInscriptionItemList(this.defalutQultityId, this.defalutThirdTypeId, true);
		}

		// Token: 0x060111F2 RID: 70130 RVA: 0x004E9E90 File Offset: 0x004E8290
		private void OnBtnCompopseClick()
		{
			if (this.putInIncriptionItemDataList.Count == 0 || this.canBeObTainedInscriptionItemList.Count <= 0)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("Inscription_Compose_IncriptionInsufficient_Desc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			bool flag = false;
			int num = 0;
			for (int i = 0; i < this.putInIncriptionItemDataList.Count; i++)
			{
				ItemData itemData = this.putInIncriptionItemDataList[i];
				if (itemData != null)
				{
					if (itemData.Quality >= ItemTable.eColor.PINK)
					{
						flag = true;
						num = (int)itemData.Quality;
						break;
					}
				}
			}
			if (flag && !InscriptionMosaicDataManager.IncriptionSynthesisHightQualityBounced)
			{
				string content = TR.Value("Inscription_Compose_HasHigheQualityIncription_Desc", TR.Value(string.Format("Inscription_Compose_Quailty_Desc_{0}", num)));
				MallNewUtility.CommonIntergralMallPopupWindow(content, new OnCommonMsgBoxToggleClick(this.OnToggleClick), new Action(this.OnSceneEquipInscriptionSynthesisReq));
				return;
			}
			this.OnSceneEquipInscriptionSynthesisReq();
		}

		// Token: 0x060111F3 RID: 70131 RVA: 0x004E9F80 File Offset: 0x004E8380
		private void OnSceneEquipInscriptionSynthesisReq()
		{
			uint[] array = new uint[this.putInIncriptionItemDataList.Count];
			for (int i = 0; i < this.putInIncriptionItemDataList.Count; i++)
			{
				ItemData itemData = this.putInIncriptionItemDataList[i];
				if (itemData != null)
				{
					array[i] = (uint)itemData.TableID;
				}
			}
			DataManager<InscriptionMosaicDataManager>.GetInstance().OnSceneEquipInscriptionSynthesisReq(array);
		}

		// Token: 0x060111F4 RID: 70132 RVA: 0x004E9FE6 File Offset: 0x004E83E6
		private void OnToggleClick(bool value)
		{
			InscriptionMosaicDataManager.IncriptionSynthesisHightQualityBounced = value;
		}

		// Token: 0x0400B070 RID: 45168
		[SerializeField]
		private Button btnCompopse;

		// Token: 0x0400B071 RID: 45169
		[SerializeField]
		private ComDropDownControl qulityDrop;

		// Token: 0x0400B072 RID: 45170
		[SerializeField]
		private ComDropDownControl typeDrop;

		// Token: 0x0400B073 RID: 45171
		[SerializeField]
		private InscriptionComposeItem[] inscriptionComposeItems = new InscriptionComposeItem[0];

		// Token: 0x0400B074 RID: 45172
		[SerializeField]
		private ComUIListScript inscriptionScrollView;

		// Token: 0x0400B075 RID: 45173
		[SerializeField]
		private ComUIListScript canBeGetIncriptionUIList;

		// Token: 0x0400B076 RID: 45174
		[SerializeField]
		private Text noItemTips;

		// Token: 0x0400B077 RID: 45175
		[SerializeField]
		private GameObject canBeGetRoot;

		// Token: 0x0400B078 RID: 45176
		[SerializeField]
		private ScrollRect inscriptionScrollRect;

		// Token: 0x0400B079 RID: 45177
		private List<ItemData> inscriptionItemDataList = new List<ItemData>();

		// Token: 0x0400B07A RID: 45178
		private List<ComControlData> inscriptionQulityTabDataList = new List<ComControlData>();

		// Token: 0x0400B07B RID: 45179
		private List<ComControlData> inscriptionThirdTypeTabDataList = new List<ComControlData>();

		// Token: 0x0400B07C RID: 45180
		private List<ItemData> putInIncriptionItemDataList = new List<ItemData>();

		// Token: 0x0400B07D RID: 45181
		private List<CanBeObtainedInscriptionItemData> canBeObTainedInscriptionItemList = new List<CanBeObtainedInscriptionItemData>();

		// Token: 0x0400B07E RID: 45182
		private int defalutQultityId;

		// Token: 0x0400B07F RID: 45183
		private int defalutThirdTypeId;

		// Token: 0x0400B080 RID: 45184
		private int selectIncriptionQultity;

		// Token: 0x0400B081 RID: 45185
		private int maxSynthesisNum;

		// Token: 0x0400B082 RID: 45186
		private ItemData currentSelectIncriptionItemData;
	}
}
