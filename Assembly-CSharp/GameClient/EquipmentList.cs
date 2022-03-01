using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001ADC RID: 6876
	internal class EquipmentList
	{
		// Token: 0x17001D72 RID: 7538
		// (get) Token: 0x06010E18 RID: 69144 RVA: 0x004D1AF8 File Offset: 0x004CFEF8
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D73 RID: 7539
		// (get) Token: 0x06010E19 RID: 69145 RVA: 0x004D1B00 File Offset: 0x004CFF00
		public ItemData Selected
		{
			get
			{
				return ComEquipment.ms_selected;
			}
		}

		// Token: 0x06010E1A RID: 69146 RVA: 0x004D1B08 File Offset: 0x004CFF08
		private ComEquipment _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComEquipment>();
		}

		// Token: 0x06010E1B RID: 69147 RVA: 0x004D1B20 File Offset: 0x004CFF20
		public ComEquipment GetEquipment(ulong guid)
		{
			int i = 0;
			while (i < this.equipments.Count)
			{
				if (this.equipments[i].GUID == guid)
				{
					ComUIListElementScript elemenet = this.comUIListScript.GetElemenet(i);
					if (elemenet != null)
					{
						return elemenet.gameObjectBindScript as ComEquipment;
					}
					break;
				}
				else
				{
					i++;
				}
			}
			return null;
		}

		// Token: 0x06010E1C RID: 69148 RVA: 0x004D1B8C File Offset: 0x004CFF8C
		public void Initialize(GameObject gameObject, EquipmentList.OnItemSelected onItemSelected, SmithShopNewLinkData linkData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.gameObject = gameObject;
			this.onItemSelected = (EquipmentList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
			this.linkData = linkData;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.comUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
			ComUIListScript comUIListScript4 = this.comUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			this._LoadAllEquipments(ref this.equipments);
			this._BindLinkData();
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010E1D RID: 69149 RVA: 0x004D1CA1 File Offset: 0x004D00A1
		public void RefreshAllEquipments()
		{
			this._LoadAllEquipments(ref this.equipments);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010E1E RID: 69150 RVA: 0x004D1CB8 File Offset: 0x004D00B8
		private void _LoadAllEquipments(ref List<ItemData> kEquipments)
		{
			kEquipments.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null && !item.IsLease)
				{
					kEquipments.Add(item);
				}
			}
			List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType2.Count; j++)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[j]);
				if (item2 != null && !item2.IsLease && item2.Type != ItemTable.eType.FUCKTITTLE)
				{
					kEquipments.Add(item2);
				}
			}
			kEquipments.RemoveAll((ItemData x) => x.EquipType == EEquipType.ET_BREATH || x.isInSidePack);
			kEquipments.Sort(new Comparison<ItemData>(this._SortEquipments));
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010E1F RID: 69151 RVA: 0x004D1DCC File Offset: 0x004D01CC
		private void _TrySelectedItem(ulong guid)
		{
			int iBindIndex = -1;
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i].GUID == guid)
				{
					iBindIndex = i;
					break;
				}
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010E20 RID: 69152 RVA: 0x004D1E1C File Offset: 0x004D021C
		private void _SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				ComEquipment.ms_selected = this.equipments[iBindIndex];
				if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.comUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.comUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.comUIListScript.SelectElement(-1, true);
				ComEquipment.ms_selected = null;
			}
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComEquipment.ms_selected);
			}
		}

		// Token: 0x06010E21 RID: 69153 RVA: 0x004D1EB0 File Offset: 0x004D02B0
		private void _BindLinkData()
		{
			if (this.linkData != null && this.linkData.itemData != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(this.linkData.itemData.TableID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int i = 0; i < this.equipments.Count; i++)
					{
						if (tableItem.Parts.Contains((int)this.equipments[i].EquipWearSlotType))
						{
							this._TrySelectedItem(this.equipments[i].GUID);
							break;
						}
					}
				}
			}
		}

		// Token: 0x06010E22 RID: 69154 RVA: 0x004D1F5C File Offset: 0x004D035C
		private void _TrySetDefaultEquipment()
		{
			if (ComEquipment.ms_selected != null)
			{
				ItemData itemData = this.equipments.Find((ItemData x) => x.GUID == ComEquipment.ms_selected.GUID);
				if (itemData != null)
				{
					ComEquipment.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(ComEquipment.ms_selected.GUID);
				}
				else
				{
					ComEquipment.ms_selected = null;
				}
			}
			int iBindIndex = -1;
			if (ComEquipment.ms_selected != null)
			{
				for (int i = 0; i < this.equipments.Count; i++)
				{
					if (this.equipments[i].GUID == ComEquipment.ms_selected.GUID)
					{
						iBindIndex = i;
						break;
					}
				}
			}
			else if (this.equipments.Count > 0)
			{
				iBindIndex = 0;
			}
			this._SetSelectedItem(iBindIndex);
		}

		// Token: 0x06010E23 RID: 69155 RVA: 0x004D2034 File Offset: 0x004D0434
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComEquipment comEquipment = item.gameObjectBindScript as ComEquipment;
			if (comEquipment != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comEquipment.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010E24 RID: 69156 RVA: 0x004D2094 File Offset: 0x004D0494
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComEquipment comEquipment = item.gameObjectBindScript as ComEquipment;
			ComEquipment.ms_selected = ((!(comEquipment == null)) ? comEquipment.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComEquipment.ms_selected);
			}
		}

		// Token: 0x06010E25 RID: 69157 RVA: 0x004D20E8 File Offset: 0x004D04E8
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComEquipment comEquipment = item.gameObjectBindScript as ComEquipment;
			if (comEquipment != null)
			{
				comEquipment.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010E26 RID: 69158 RVA: 0x004D2114 File Offset: 0x004D0514
		public void UnInitialize()
		{
			if (this.comUIListScript != null)
			{
				ComUIListScript comUIListScript = this.comUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.comUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.comUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.comUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
				this.comUIListScript = null;
			}
			this.linkData = null;
			this.onItemSelected = (EquipmentList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.equipments.Clear();
			ComEquipment.ms_selected = null;
			this.bInitialize = false;
		}

		// Token: 0x06010E27 RID: 69159 RVA: 0x004D2218 File Offset: 0x004D0618
		private int _SortEquipments(ItemData left, ItemData right)
		{
			if (left.PackageType != right.PackageType)
			{
				return right.PackageType - left.PackageType;
			}
			if (left.IsItemInUnUsedEquipPlan != right.IsItemInUnUsedEquipPlan)
			{
				if (left.IsItemInUnUsedEquipPlan)
				{
					return -1;
				}
				if (right.IsItemInUnUsedEquipPlan)
				{
					return 1;
				}
			}
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			if (left.SubType != right.SubType)
			{
				return left.SubType - right.SubType;
			}
			if (left.StrengthenLevel != right.StrengthenLevel)
			{
				return right.StrengthenLevel - left.StrengthenLevel;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x0400AD5F RID: 44383
		private bool bInitialize;

		// Token: 0x0400AD60 RID: 44384
		private GameObject gameObject;

		// Token: 0x0400AD61 RID: 44385
		private ComUIListScript comUIListScript;

		// Token: 0x0400AD62 RID: 44386
		public EquipmentList.OnItemSelected onItemSelected;

		// Token: 0x0400AD63 RID: 44387
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400AD64 RID: 44388
		public SmithShopNewLinkData linkData;

		// Token: 0x02001ADD RID: 6877
		// (Invoke) Token: 0x06010E2B RID: 69163
		public delegate void OnItemSelected(ItemData itemData);
	}
}
