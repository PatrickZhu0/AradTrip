using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AD5 RID: 6869
	internal class BeadEquipmentList
	{
		// Token: 0x17001D6F RID: 7535
		// (get) Token: 0x06010DC7 RID: 69063 RVA: 0x004CF7AF File Offset: 0x004CDBAF
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D70 RID: 7536
		// (get) Token: 0x06010DC8 RID: 69064 RVA: 0x004CF7B7 File Offset: 0x004CDBB7
		public ItemData Selected
		{
			get
			{
				return ComBeadEquipment.ms_selected;
			}
		}

		// Token: 0x06010DC9 RID: 69065 RVA: 0x004CF7C0 File Offset: 0x004CDBC0
		private ComBeadEquipment _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComBeadEquipment>();
		}

		// Token: 0x06010DCA RID: 69066 RVA: 0x004CF7D8 File Offset: 0x004CDBD8
		public ComBeadEquipment GetEquipment(ulong guid)
		{
			int i = 0;
			while (i < this.equipments.Count)
			{
				if (this.equipments[i].GUID == guid)
				{
					ComUIListElementScript elemenet = this.comUIListScript.GetElemenet(i);
					if (elemenet != null)
					{
						return elemenet.gameObjectBindScript as ComBeadEquipment;
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

		// Token: 0x06010DCB RID: 69067 RVA: 0x004CF844 File Offset: 0x004CDC44
		public void Initialize(GameObject gameObject, BeadEquipmentList.OnItemSelected onItemSelected, ItemTabType eItemTabType, SmithShopNewLinkData linkData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.gameObject = gameObject;
			this.onItemSelected = (BeadEquipmentList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
			this.eItemTabType = eItemTabType;
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

		// Token: 0x06010DCC RID: 69068 RVA: 0x004CF961 File Offset: 0x004CDD61
		public void RefreshAllEquipments(ItemTabType eItemTabType)
		{
			this.eItemTabType = eItemTabType;
			this._LoadAllEquipments(ref this.equipments);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010DCD RID: 69069 RVA: 0x004CF97C File Offset: 0x004CDD7C
		private void _LoadAllEquipments(ref List<ItemData> kEquipments)
		{
			kEquipments.Clear();
			if (this.eItemTabType == ItemTabType.ITT_EQUIP)
			{
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
			}
			else
			{
				List<ulong> itemsByPackageType3 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Title);
				for (int k = 0; k < itemsByPackageType3.Count; k++)
				{
					ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType3[k]);
					if (item3 != null && !item3.IsLease)
					{
						kEquipments.Add(item3);
					}
				}
				List<ulong> itemsByPackageType4 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				for (int l = 0; l < itemsByPackageType4.Count; l++)
				{
					ItemData item4 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType4[l]);
					if (item4 != null && !item4.IsLease && item4.Type == ItemTable.eType.FUCKTITTLE)
					{
						kEquipments.Add(item4);
					}
				}
			}
			kEquipments.RemoveAll(delegate(ItemData x)
			{
				bool flag = false;
				for (int m = 0; m < x.PreciousBeadMountHole.Length; m++)
				{
					if (x.PreciousBeadMountHole[m] != null)
					{
						flag = true;
					}
				}
				return !flag || x.FixTimeLeft > 0 || x.EquipType == EEquipType.ET_BREATH || x.isInSidePack;
			});
			kEquipments.Sort(new Comparison<ItemData>(this._SortEquipments));
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010DCE RID: 69070 RVA: 0x004CFB64 File Offset: 0x004CDF64
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

		// Token: 0x06010DCF RID: 69071 RVA: 0x004CFBB4 File Offset: 0x004CDFB4
		private void _SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				ComBeadEquipment.ms_selected = this.equipments[iBindIndex];
				if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.comUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.comUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.comUIListScript.SelectElement(-1, true);
				ComBeadEquipment.ms_selected = null;
			}
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComBeadEquipment.ms_selected);
			}
		}

		// Token: 0x06010DD0 RID: 69072 RVA: 0x004CFC48 File Offset: 0x004CE048
		private void _BindLinkData()
		{
			if (this.linkData != null && this.linkData.itemData != null)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(this.linkData.itemData.TableID, string.Empty, string.Empty);
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
				else
				{
					this._TrySelectedItem(this.linkData.itemData.GUID);
				}
			}
		}

		// Token: 0x06010DD1 RID: 69073 RVA: 0x004CFD10 File Offset: 0x004CE110
		private void _TrySetDefaultEquipment()
		{
			if (ComBeadEquipment.ms_selected != null)
			{
				ItemData itemData = this.equipments.Find((ItemData x) => x.GUID == ComBeadEquipment.ms_selected.GUID);
				if (itemData != null)
				{
					ComBeadEquipment.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(ComBeadEquipment.ms_selected.GUID);
				}
				else
				{
					ComBeadEquipment.ms_selected = null;
				}
			}
			int iBindIndex = -1;
			if (ComBeadEquipment.ms_selected != null)
			{
				for (int i = 0; i < this.equipments.Count; i++)
				{
					if (this.equipments[i].GUID == ComBeadEquipment.ms_selected.GUID)
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

		// Token: 0x06010DD2 RID: 69074 RVA: 0x004CFDE8 File Offset: 0x004CE1E8
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComBeadEquipment comBeadEquipment = item.gameObjectBindScript as ComBeadEquipment;
			if (comBeadEquipment != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comBeadEquipment.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010DD3 RID: 69075 RVA: 0x004CFE48 File Offset: 0x004CE248
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComBeadEquipment comBeadEquipment = item.gameObjectBindScript as ComBeadEquipment;
			ComBeadEquipment.ms_selected = ((!(comBeadEquipment == null)) ? comBeadEquipment.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComBeadEquipment.ms_selected);
			}
		}

		// Token: 0x06010DD4 RID: 69076 RVA: 0x004CFE9C File Offset: 0x004CE29C
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComBeadEquipment comBeadEquipment = item.gameObjectBindScript as ComBeadEquipment;
			if (comBeadEquipment != null)
			{
				comBeadEquipment.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010DD5 RID: 69077 RVA: 0x004CFEC8 File Offset: 0x004CE2C8
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
			this.eItemTabType = ItemTabType.ITT_EQUIP;
			this.onItemSelected = (BeadEquipmentList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.equipments.Clear();
			ComBeadEquipment.ms_selected = null;
			this.bInitialize = false;
		}

		// Token: 0x06010DD6 RID: 69078 RVA: 0x004CFFD4 File Offset: 0x004CE3D4
		private int _SortEquipments(ItemData left, ItemData right)
		{
			if (this.eItemTabType == ItemTabType.ITT_EQUIP)
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
			}
			else
			{
				if (left.PackageType != right.PackageType)
				{
					return left.PackageType - right.PackageType;
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
				if (left.Packing != right.Packing)
				{
					return left.Packing.CompareTo(right.Packing);
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

		// Token: 0x0400AD29 RID: 44329
		private bool bInitialize;

		// Token: 0x0400AD2A RID: 44330
		private GameObject gameObject;

		// Token: 0x0400AD2B RID: 44331
		private ComUIListScript comUIListScript;

		// Token: 0x0400AD2C RID: 44332
		public BeadEquipmentList.OnItemSelected onItemSelected;

		// Token: 0x0400AD2D RID: 44333
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400AD2E RID: 44334
		private ItemTabType eItemTabType;

		// Token: 0x0400AD2F RID: 44335
		public SmithShopNewLinkData linkData;

		// Token: 0x02001AD6 RID: 6870
		// (Invoke) Token: 0x06010DDA RID: 69082
		public delegate void OnItemSelected(ItemData itemData);
	}
}
