using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B0F RID: 6927
	public class EquipUpgradeView : MonoBehaviour, ISmithShopNewView
	{
		// Token: 0x06011007 RID: 69639 RVA: 0x004DD380 File Offset: 0x004DB780
		private void RegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
		}

		// Token: 0x06011008 RID: 69640 RVA: 0x004DD3DC File Offset: 0x004DB7DC
		private void UnRegisterEventHander()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnAddNewItem));
		}

		// Token: 0x06011009 RID: 69641 RVA: 0x004DD438 File Offset: 0x004DB838
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
					if (item.Type == ItemTable.eType.MATERIAL)
					{
						this.SetConsumElementAmount();
					}
				}
			}
		}

		// Token: 0x0601100A RID: 69642 RVA: 0x004DD498 File Offset: 0x004DB898
		private void Awake()
		{
			this.RegisterEventHander();
			if (this.mUpgradeBtn)
			{
				this.mUpgradeBtn.onClick.RemoveAllListeners();
				this.mUpgradeBtn.onClick.AddListener(delegate()
				{
					if (this.mUpgradeBtn != null)
					{
						this.mUpgradeBtn.enabled = false;
						InvokeMethod.Invoke(this, 0.5f, delegate()
						{
							this.mUpgradeBtn.enabled = true;
						});
					}
					this.OnEquipUpgradeClick();
				});
			}
			this.InitmConsumUIListScript();
			this.InitEquipUIListScript();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnEquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipUpgradeSuccess));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0601100B RID: 69643 RVA: 0x004DD534 File Offset: 0x004DB934
		public void InitView(SmithShopNewLinkData linkData)
		{
			this.LoadAllEquipments();
		}

		// Token: 0x0601100C RID: 69644 RVA: 0x004DD53C File Offset: 0x004DB93C
		public void OnEnableView()
		{
			this.RegisterEventHander();
			this.LoadAllEquipments();
		}

		// Token: 0x0601100D RID: 69645 RVA: 0x004DD54A File Offset: 0x004DB94A
		public void OnDisableView()
		{
			this.UnRegisterEventHander();
		}

		// Token: 0x0601100E RID: 69646 RVA: 0x004DD552 File Offset: 0x004DB952
		private void OnEquipUpgradeSuccess(UIEvent uiEvent)
		{
			this.LoadAllEquipments();
		}

		// Token: 0x0601100F RID: 69647 RVA: 0x004DD55C File Offset: 0x004DB95C
		private void InitEquipUIListScript()
		{
			this.mEquipUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mEquipUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mEquipUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.mEquipUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
			ComUIListScript comUIListScript4 = this.mEquipUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
		}

		// Token: 0x06011010 RID: 69648 RVA: 0x004DD610 File Offset: 0x004DBA10
		public void LoadAllEquipments()
		{
			this.mAllEquipments = DataManager<EquipUpgradeDataManager>.GetInstance().GetAllEquipments();
			this.SetElementAmount(this.mAllEquipments.Count);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06011011 RID: 69649 RVA: 0x004DD639 File Offset: 0x004DBA39
		private void SetElementAmount(int count)
		{
			this.mEquipUIListScript.SetElementAmount(count);
		}

		// Token: 0x06011012 RID: 69650 RVA: 0x004DD648 File Offset: 0x004DBA48
		private void _TrySetDefaultEquipment()
		{
			int selectItem = -1;
			if (EquipUpgradeItem.ms_selected != null)
			{
				ulong num = this.mAllEquipments.Find((ulong x) => x == EquipUpgradeItem.ms_selected.GUID);
				if (num != 0UL)
				{
					EquipUpgradeItem.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(num);
				}
				else
				{
					EquipUpgradeItem.ms_selected = null;
				}
			}
			if (EquipUpgradeItem.ms_selected != null)
			{
				for (int i = 0; i < this.mAllEquipments.Count; i++)
				{
					ulong num2 = this.mAllEquipments[i];
					if (num2 == EquipUpgradeItem.ms_selected.GUID)
					{
						selectItem = i;
					}
				}
			}
			else if (this.mAllEquipments.Count > 0)
			{
				selectItem = 0;
			}
			this.SetSelectItem(selectItem);
		}

		// Token: 0x06011013 RID: 69651 RVA: 0x004DD718 File Offset: 0x004DBB18
		private void SetSelectItem(int index)
		{
			if (index >= 0 && index < this.mAllEquipments.Count)
			{
				EquipUpgradeItem.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(this.mAllEquipments[index]);
				if (!this.mEquipUIListScript.IsElementInScrollArea(index))
				{
					this.mEquipUIListScript.EnsureElementVisable(index);
				}
				this.mEquipUIListScript.SelectElement(index, true);
			}
			else
			{
				this.mEquipUIListScript.SelectElement(-1, true);
				EquipUpgradeItem.ms_selected = null;
			}
			this.UpdateLeftItemInfo();
		}

		// Token: 0x06011014 RID: 69652 RVA: 0x004DD7A0 File Offset: 0x004DBBA0
		private void UnInitEquipUIListScript()
		{
			if (this.mEquipUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mEquipUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mEquipUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mEquipUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mEquipUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
				this.mEquipUIListScript = null;
			}
		}

		// Token: 0x06011015 RID: 69653 RVA: 0x004DD861 File Offset: 0x004DBC61
		private EquipUpgradeItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EquipUpgradeItem>();
		}

		// Token: 0x06011016 RID: 69654 RVA: 0x004DD86C File Offset: 0x004DBC6C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null && item.m_index >= 0 && item.m_index < this.mAllEquipments.Count)
			{
				ulong id = this.mAllEquipments[item.m_index];
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(id);
				if (item2 == null)
				{
					return;
				}
				equipUpgradeItem.OnItemVisiable(item2);
			}
		}

		// Token: 0x06011017 RID: 69655 RVA: 0x004DD8E0 File Offset: 0x004DBCE0
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				EquipUpgradeItem.ms_selected = equipUpgradeItem.ItemData;
				this.UpdateLeftItemInfo();
			}
		}

		// Token: 0x06011018 RID: 69656 RVA: 0x004DD918 File Offset: 0x004DBD18
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			EquipUpgradeItem equipUpgradeItem = item.gameObjectBindScript as EquipUpgradeItem;
			if (equipUpgradeItem != null)
			{
				equipUpgradeItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06011019 RID: 69657 RVA: 0x004DD944 File Offset: 0x004DBD44
		private void UpdateLeftItemInfo()
		{
			if (EquipUpgradeItem.ms_selected != null)
			{
				this.mEquipUpgradeDataModel = DataManager<EquipUpgradeDataManager>.GetInstance().GetEquipUpgradeData(EquipUpgradeItem.ms_selected.TableID);
				this.mItemSimpleData = DataManager<EquipUpgradeDataManager>.GetInstance().GetMaterialConsume(EquipUpgradeItem.ms_selected.TableID, EquipUpgradeItem.ms_selected.StrengthenLevel, EquipUpgradeItem.ms_selected.EquipType);
			}
			else
			{
				this.mEquipUpgradeDataModel = null;
				this.mItemSimpleData = new List<ItemSimpleData>();
			}
			this.UpdateSelectEquipItem(EquipUpgradeItem.ms_selected);
			this.UpdateUpgradeEquipItem(EquipUpgradeItem.ms_selected);
			this.SetConsumElementAmount();
		}

		// Token: 0x0601101A RID: 69658 RVA: 0x004DD9D8 File Offset: 0x004DBDD8
		private void UpdateSelectEquipItem(ItemData data)
		{
			if (this.mCurrentComItem == null)
			{
				this.mCurrentComItem = ComItemManager.Create(this.mCurrentEquipItemParent);
			}
			if (data != null)
			{
				ComItem comItem = this.mCurrentComItem;
				if (EquipUpgradeView.<>f__mg$cache0 == null)
				{
					EquipUpgradeView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(data, EquipUpgradeView.<>f__mg$cache0);
				if (this.mCurrentEquipmentName != null)
				{
					this.mCurrentEquipmentName.text = data.GetColorName(string.Empty, false);
				}
			}
			else
			{
				this.mCurrentComItem.Setup(null, null);
				if (this.mCurrentEquipmentName != null)
				{
					this.mCurrentEquipmentName.text = string.Empty;
				}
			}
		}

		// Token: 0x0601101B RID: 69659 RVA: 0x004DDA94 File Offset: 0x004DBE94
		private void UpdateUpgradeEquipItem(ItemData data)
		{
			if (this.mUpgradeComItem == null)
			{
				this.mUpgradeComItem = ComItemManager.Create(this.mNextLvEquipItemParent);
			}
			if (this.mEquipUpgradeDataModel != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mEquipUpgradeDataModel.mUpgradeEquipID, data.SubQuality, 0);
				itemData = this.SwichItemData(data, itemData);
				ComItem comItem = this.mUpgradeComItem;
				ItemData item = itemData;
				if (EquipUpgradeView.<>f__mg$cache1 == null)
				{
					EquipUpgradeView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, EquipUpgradeView.<>f__mg$cache1);
				if (this.mTargetEquipmentName != null)
				{
					this.mTargetEquipmentName.text = itemData.GetColorName(string.Empty, false);
				}
			}
			else
			{
				this.mUpgradeComItem.Setup(null, null);
				if (this.mTargetEquipmentName != null)
				{
					this.mTargetEquipmentName.text = string.Empty;
				}
			}
		}

		// Token: 0x0601101C RID: 69660 RVA: 0x004DDB74 File Offset: 0x004DBF74
		private ItemData SwichItemData(ItemData currentItemData, ItemData upgradeItemData)
		{
			upgradeItemData.StrengthenLevel = currentItemData.StrengthenLevel;
			upgradeItemData.bLocked = currentItemData.bLocked;
			upgradeItemData.SubQuality = currentItemData.SubQuality;
			upgradeItemData.mPrecEnchantmentCard = currentItemData.mPrecEnchantmentCard;
			upgradeItemData.PreciousBeadMountHole = currentItemData.PreciousBeadMountHole;
			upgradeItemData.BeadAdditiveAttributeBuffID = currentItemData.BeadAdditiveAttributeBuffID;
			upgradeItemData.EquipType = currentItemData.EquipType;
			upgradeItemData.GrowthAttrType = currentItemData.GrowthAttrType;
			upgradeItemData.GrowthAttrNum = DataManager<EquipGrowthDataManager>.GetInstance().GetGrowthAttributeValue(upgradeItemData, upgradeItemData.StrengthenLevel);
			upgradeItemData.InscriptionHoles = currentItemData.InscriptionHoles;
			ItemStrengthAttribute itemStrengthAttribute = ItemStrengthAttribute.Create(upgradeItemData.TableID, false);
			itemStrengthAttribute.SetStrength(upgradeItemData.StrengthenLevel, false, 0);
			ItemData itemData = itemStrengthAttribute.GetItemData();
			upgradeItemData.BaseProp.props[39] = itemData.BaseProp.props[39];
			upgradeItemData.BaseProp.props[37] = itemData.BaseProp.props[37];
			upgradeItemData.BaseProp.props[40] = itemData.BaseProp.props[40];
			upgradeItemData.BaseProp.props[38] = itemData.BaseProp.props[38];
			upgradeItemData.BaseProp.props[60] = itemData.BaseProp.props[60] * 1000;
			upgradeItemData.BaseProp.props[43] = itemData.BaseProp.props[43];
			upgradeItemData.BaseProp.props[41] = itemData.BaseProp.props[41];
			upgradeItemData.BaseProp.props[44] = itemData.BaseProp.props[44];
			upgradeItemData.BaseProp.props[42] = itemData.BaseProp.props[42];
			upgradeItemData.RefreshRateScore();
			return upgradeItemData;
		}

		// Token: 0x0601101D RID: 69661 RVA: 0x004DDDDB File Offset: 0x004DC1DB
		private void SetConsumElementAmount()
		{
			if (this.mEquipUpgradeDataModel != null)
			{
				this.mConsumUIListScript.SetElementAmount(this.mItemSimpleData.Count);
			}
			else
			{
				this.mConsumUIListScript.SetElementAmount(0);
			}
		}

		// Token: 0x0601101E RID: 69662 RVA: 0x004DDE10 File Offset: 0x004DC210
		private void InitmConsumUIListScript()
		{
			this.mConsumUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mConsumUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnConsumBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mConsumUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnConsumItemVisiableDelegate));
		}

		// Token: 0x0601101F RID: 69663 RVA: 0x004DDE78 File Offset: 0x004DC278
		private void UnInitmConsumUIListScript()
		{
			if (this.mConsumUIListScript)
			{
				ComUIListScript comUIListScript = this.mConsumUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnConsumBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mConsumUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnConsumItemVisiableDelegate));
				this.mConsumUIListScript = null;
			}
		}

		// Token: 0x06011020 RID: 69664 RVA: 0x004DDEEA File Offset: 0x004DC2EA
		private EquipUpgradeCostItem OnConsumBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<EquipUpgradeCostItem>();
		}

		// Token: 0x06011021 RID: 69665 RVA: 0x004DDEF4 File Offset: 0x004DC2F4
		private void OnConsumItemVisiableDelegate(ComUIListElementScript item)
		{
			EquipUpgradeCostItem equipUpgradeCostItem = item.gameObjectBindScript as EquipUpgradeCostItem;
			if (equipUpgradeCostItem != null && item.m_index >= 0 && item.m_index < this.mItemSimpleData.Count)
			{
				equipUpgradeCostItem.OnItemVisiable(this.mItemSimpleData[item.m_index]);
			}
		}

		// Token: 0x06011022 RID: 69666 RVA: 0x004DDF52 File Offset: 0x004DC352
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this.SetConsumElementAmount();
		}

		// Token: 0x06011023 RID: 69667 RVA: 0x004DDF5C File Offset: 0x004DC35C
		private void OnEquipUpgradeClick()
		{
			if (EquipUpgradeItem.ms_selected == null)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipUpgrade_PutEquipment"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (EquipUpgradeItem.ms_selected.PackageType == EPackageType.WearEquip || EquipUpgradeItem.ms_selected.IsItemInUnUsedEquipPlan)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipUpgrade_WearEquipDesc"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			bool flag = false;
			for (int i = 0; i < this.mItemSimpleData.Count; i++)
			{
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mItemSimpleData[i].ItemID);
				if (commonItemTableDataByID != null)
				{
					int num;
					if (commonItemTableDataByID.Type == ItemTable.eType.MATERIAL)
					{
						num = DataManager<ItemDataManager>.GetInstance().GetItemCount(commonItemTableDataByID.TableID);
					}
					else
					{
						num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(commonItemTableDataByID.TableID, true);
					}
					if (num < this.mItemSimpleData[i].Count)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("EquipUpgrade_LackOfMaterial"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			ItemData commonItemTableDataByID2 = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mEquipUpgradeDataModel.mUpgradeEquipID);
			if (commonItemTableDataByID2 == null)
			{
				return;
			}
			if (EquipUpgradeItem.ms_selected.PackageType == EPackageType.WearEquip)
			{
			}
			if (commonItemTableDataByID2.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				string msgContent = TR.Value("EquipUpgrade_PackageEquipUpgrade");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.OnSendSceneEquipUpdateReq();
				}, null, 0f, false);
				return;
			}
			string msgContent2 = TR.Value("EquipUpgrade_Tip", EquipUpgradeItem.ms_selected.GetColorName(string.Empty, false), commonItemTableDataByID2.GetColorName(string.Empty, false));
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent2, delegate()
			{
				this.OnSendSceneEquipUpdateReq();
			}, null, 0f, false);
		}

		// Token: 0x06011024 RID: 69668 RVA: 0x004DE113 File Offset: 0x004DC513
		private void OnSendSceneEquipUpdateReq()
		{
			DataManager<EquipUpgradeDataManager>.GetInstance().OnSendSceneEquieUpdateReq(EquipUpgradeItem.ms_selected.GUID);
		}

		// Token: 0x06011025 RID: 69669 RVA: 0x004DE12C File Offset: 0x004DC52C
		private void OnDestroy()
		{
			this.UnRegisterEventHander();
			this.UnInitEquipUIListScript();
			this.UnInitmConsumUIListScript();
			this.mAllEquipments = null;
			this.mCurrentComItem = null;
			this.mUpgradeComItem = null;
			this.mEquipUpgradeDataModel = null;
			this.mItemSimpleData = null;
			EquipUpgradeItem.ms_selected = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnEquipUpgradeSuccess, new ClientEventSystem.UIEventHandler(this.OnEquipUpgradeSuccess));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x0400AF06 RID: 44806
		[SerializeField]
		private GameObject mCurrentEquipItemParent;

		// Token: 0x0400AF07 RID: 44807
		[SerializeField]
		private GameObject mNextLvEquipItemParent;

		// Token: 0x0400AF08 RID: 44808
		[SerializeField]
		private ComUIListScript mConsumUIListScript;

		// Token: 0x0400AF09 RID: 44809
		[SerializeField]
		private Button mUpgradeBtn;

		// Token: 0x0400AF0A RID: 44810
		[SerializeField]
		private ComUIListScript mEquipUIListScript;

		// Token: 0x0400AF0B RID: 44811
		[SerializeField]
		private Text mCurrentEquipmentName;

		// Token: 0x0400AF0C RID: 44812
		[SerializeField]
		private Text mTargetEquipmentName;

		// Token: 0x0400AF0D RID: 44813
		private List<ulong> mAllEquipments;

		// Token: 0x0400AF0E RID: 44814
		private EquipUpgradeDataModel mEquipUpgradeDataModel;

		// Token: 0x0400AF0F RID: 44815
		private List<ItemSimpleData> mItemSimpleData;

		// Token: 0x0400AF10 RID: 44816
		private ComItem mCurrentComItem;

		// Token: 0x0400AF11 RID: 44817
		private ComItem mUpgradeComItem;

		// Token: 0x0400AF13 RID: 44819
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x0400AF14 RID: 44820
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
