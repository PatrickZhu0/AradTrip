using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AEB RID: 6891
	internal class ComSealEquipmentList
	{
		// Token: 0x17001D7B RID: 7547
		// (get) Token: 0x06010EAB RID: 69291 RVA: 0x004D4C32 File Offset: 0x004D3032
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D7C RID: 7548
		// (get) Token: 0x06010EAC RID: 69292 RVA: 0x004D4C3A File Offset: 0x004D303A
		// (set) Token: 0x06010EAD RID: 69293 RVA: 0x004D4C41 File Offset: 0x004D3041
		public ItemData Selected
		{
			get
			{
				return ComSealEquipment.ms_selected;
			}
			set
			{
				ComSealEquipment.ms_selected = value;
			}
		}

		// Token: 0x06010EAE RID: 69294 RVA: 0x004D4C4C File Offset: 0x004D304C
		private ComSealEquipment _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComSealEquipment>();
		}

		// Token: 0x06010EAF RID: 69295 RVA: 0x004D4C64 File Offset: 0x004D3064
		public ComSealEquipment GetComSealEquipment(ulong guid)
		{
			int i = 0;
			while (i < this.equipments.Count)
			{
				if (this.equipments[i].GUID == guid)
				{
					ComUIListElementScript elemenet = this.comUIListScript.GetElemenet(i);
					if (elemenet != null)
					{
						return elemenet.gameObjectBindScript as ComSealEquipment;
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

		// Token: 0x06010EB0 RID: 69296 RVA: 0x004D4CD0 File Offset: 0x004D30D0
		public void Initialize(GameObject gameObject, ComSealEquipmentList.OnItemSelected onItemSelected, SmithShopNewTabType eFunctionType, SmithShopNewLinkData linkData)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.gameObject = gameObject;
			this.onItemSelected = (ComSealEquipmentList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
			this.eFunctionType = eFunctionType;
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

		// Token: 0x06010EB1 RID: 69297 RVA: 0x004D4DF0 File Offset: 0x004D31F0
		private void _TryKeepLastSelectedEquipment()
		{
			if (ComSealEquipment.ms_selected != null)
			{
				ComSealEquipment.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(ComSealEquipment.ms_selected.GUID);
				if (ComSealEquipment.ms_selected != null && this._CheckNeedFilter(ComSealEquipment.ms_selected))
				{
					ComSealEquipment.ms_selected = null;
				}
			}
		}

		// Token: 0x06010EB2 RID: 69298 RVA: 0x004D4E40 File Offset: 0x004D3240
		public void RefreshAllEquipments(SmithShopNewTabType eFunctionType, bool bForce = true)
		{
			if (!bForce && this.eFunctionType == eFunctionType)
			{
				return;
			}
			if (!this.Initilized)
			{
				return;
			}
			this.eFunctionType = eFunctionType;
			this._TryKeepLastSelectedEquipment();
			this._LoadAllEquipments(ref this.equipments);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06010EB3 RID: 69299 RVA: 0x004D4E80 File Offset: 0x004D3280
		public bool _TrySelectItem(ItemData target)
		{
			this._LoadAllEquipments(ref this.equipments);
			this.Selected = target;
			this._TrySetDefaultEquipment();
			return this.Selected.GUID == target.GUID;
		}

		// Token: 0x06010EB4 RID: 69300 RVA: 0x004D4EB4 File Offset: 0x004D32B4
		private bool _CheckNeedFilter(ItemData x)
		{
			if (x.EquipType == EEquipType.ET_BREATH)
			{
				return true;
			}
			if (x.isInSidePack)
			{
				return true;
			}
			if (this.eFunctionType == SmithShopNewTabType.SSNTT_EQUIPMENTSEAL)
			{
				return x.PackageType != EPackageType.Equip || !ComSealEquipment.CheckCanSeal(x);
			}
			if (this.eFunctionType == SmithShopNewTabType.SSNTT_ADJUST)
			{
				return !x.CheckEquipMagicstoneIsHasBasPro();
			}
			return this.eFunctionType == SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER && (x.IsEquiped() || x.HasTransfered || x.Quality != ItemTable.eColor.YELLOW || x.BindAttr != ItemTable.eOwner.ROLEBIND);
		}

		// Token: 0x06010EB5 RID: 69301 RVA: 0x004D4F5C File Offset: 0x004D335C
		private void _LoadAllEquipments(ref List<ItemData> kEquipments)
		{
			kEquipments.Clear();
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (!item.IsLease)
					{
						if (this.eFunctionType != SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER || !item.IsItemInUnUsedEquipPlan)
						{
							kEquipments.Add(item);
						}
					}
				}
			}
			itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int j = 0; j < itemsByPackageType.Count; j++)
			{
				ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[j]);
				if (item2 != null && !item2.IsLease && item2.Type != ItemTable.eType.FUCKTITTLE)
				{
					kEquipments.Add(item2);
				}
			}
			kEquipments.RemoveAll((ItemData x) => this._CheckNeedFilter(x));
			kEquipments.Sort(new Comparison<ItemData>(this._SortEquipments));
			this.comUIListScript.SetElementAmount(kEquipments.Count);
		}

		// Token: 0x06010EB6 RID: 69302 RVA: 0x004D507C File Offset: 0x004D347C
		public bool HasComSealEquipments()
		{
			return this.equipments.Count > 0;
		}

		// Token: 0x06010EB7 RID: 69303 RVA: 0x004D508C File Offset: 0x004D348C
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

		// Token: 0x06010EB8 RID: 69304 RVA: 0x004D50DC File Offset: 0x004D34DC
		private void _SetSelectedItem(int iBindIndex)
		{
			if (iBindIndex >= 0 && iBindIndex < this.equipments.Count)
			{
				this.Selected = this.equipments[iBindIndex];
				if (!this.comUIListScript.IsElementInScrollArea(iBindIndex))
				{
					this.comUIListScript.EnsureElementVisable(iBindIndex);
				}
				this.comUIListScript.SelectElement(iBindIndex, true);
			}
			else
			{
				this.Selected = null;
				this.comUIListScript.SelectElement(-1, true);
			}
			if (this.onItemSelected != null)
			{
				this.onItemSelected(this.Selected);
			}
		}

		// Token: 0x06010EB9 RID: 69305 RVA: 0x004D5174 File Offset: 0x004D3574
		private void _BindLinkData()
		{
			if (this.linkData != null)
			{
				if (((this.eFunctionType == SmithShopNewTabType.SSNTT_EQUIPMENTSEAL && this.linkData.iDefaultFirstTabId == 7) || (this.eFunctionType == SmithShopNewTabType.SSNTT_ADJUST && this.linkData.iDefaultFirstTabId == 5)) && this.linkData.itemData != null)
				{
					this._TrySelectedItem(this.linkData.itemData.GUID);
				}
				this.linkData = null;
			}
		}

		// Token: 0x06010EBA RID: 69306 RVA: 0x004D51F4 File Offset: 0x004D35F4
		private void _TrySetDefaultEquipment()
		{
			if (this.Selected != null)
			{
				this.Selected = DataManager<ItemDataManager>.GetInstance().GetItem(this.Selected.GUID);
				if (this.Selected != null && !this.HasObject(this.Selected.GUID))
				{
					this.Selected = null;
				}
			}
			int iBindIndex = -1;
			if (this.Selected != null)
			{
				for (int i = 0; i < this.equipments.Count; i++)
				{
					if (this.equipments[i].GUID == this.Selected.GUID)
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

		// Token: 0x06010EBB RID: 69307 RVA: 0x004D52C0 File Offset: 0x004D36C0
		public bool HasObject(ulong guid)
		{
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i] != null && this.equipments[i].GUID == guid)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06010EBC RID: 69308 RVA: 0x004D5314 File Offset: 0x004D3714
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			if (comSealEquipment != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comSealEquipment.OnItemVisible(this.equipments[item.m_index], this.eFunctionType, false);
			}
		}

		// Token: 0x06010EBD RID: 69309 RVA: 0x004D537C File Offset: 0x004D377C
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			ComSealEquipment.ms_selected = ((!(comSealEquipment == null)) ? comSealEquipment.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComSealEquipment.ms_selected);
			}
		}

		// Token: 0x06010EBE RID: 69310 RVA: 0x004D53D0 File Offset: 0x004D37D0
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComSealEquipment comSealEquipment = item.gameObjectBindScript as ComSealEquipment;
			if (comSealEquipment != null)
			{
				comSealEquipment.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010EBF RID: 69311 RVA: 0x004D53FC File Offset: 0x004D37FC
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
			this.eFunctionType = SmithShopNewTabType.SSNTT_EQUIPMENTSEAL;
			this.onItemSelected = (ComSealEquipmentList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.clientFrame = null;
			this.equipments.Clear();
			ComSealEquipment.ms_selected = null;
			this.bInitialize = false;
		}

		// Token: 0x06010EC0 RID: 69312 RVA: 0x004D5510 File Offset: 0x004D3910
		private int _SortEquipments(ItemData left, ItemData right)
		{
			if (this.eFunctionType != SmithShopNewTabType.SSNTT_EQUIPMENTTRANSFER)
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
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x0400ADD6 RID: 44502
		private bool bInitialize;

		// Token: 0x0400ADD7 RID: 44503
		private ClientFrame clientFrame;

		// Token: 0x0400ADD8 RID: 44504
		private GameObject gameObject;

		// Token: 0x0400ADD9 RID: 44505
		private ComUIListScript comUIListScript;

		// Token: 0x0400ADDA RID: 44506
		public ComSealEquipmentList.OnItemSelected onItemSelected;

		// Token: 0x0400ADDB RID: 44507
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400ADDC RID: 44508
		public SmithShopNewTabType eFunctionType = SmithShopNewTabType.SSNTT_EQUIPMENTSEAL;

		// Token: 0x0400ADDD RID: 44509
		public SmithShopNewLinkData linkData;

		// Token: 0x02001AEC RID: 6892
		// (Invoke) Token: 0x06010EC3 RID: 69315
		public delegate void OnItemSelected(ItemData itemData);
	}
}
