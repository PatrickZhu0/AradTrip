using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B1D RID: 6941
	internal class ComFashionAttributeModifyEquipmentList
	{
		// Token: 0x17001D8C RID: 7564
		// (get) Token: 0x0601108F RID: 69775 RVA: 0x004E03B5 File Offset: 0x004DE7B5
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D8D RID: 7565
		// (get) Token: 0x06011090 RID: 69776 RVA: 0x004E03BD File Offset: 0x004DE7BD
		// (set) Token: 0x06011091 RID: 69777 RVA: 0x004E03C4 File Offset: 0x004DE7C4
		public ItemData Selected
		{
			get
			{
				return ComFashionAttributeModifyEquipment.ms_selected;
			}
			set
			{
				ComFashionAttributeModifyEquipment.ms_selected = value;
			}
		}

		// Token: 0x06011092 RID: 69778 RVA: 0x004E03CC File Offset: 0x004DE7CC
		private ComFashionAttributeModifyEquipment _OnBindItemDelegate(GameObject itemObject)
		{
			ComFashionAttributeModifyEquipment component = itemObject.GetComponent<ComFashionAttributeModifyEquipment>();
			if (component != null)
			{
				component.OnCreate(this.clientFrame);
			}
			return component;
		}

		// Token: 0x06011093 RID: 69779 RVA: 0x004E03FC File Offset: 0x004DE7FC
		public ComFashionAttributeModifyEquipment GetComSealEquipment(ulong guid)
		{
			int i = 0;
			while (i < this.equipments.Count)
			{
				if (this.equipments[i].GUID == guid)
				{
					ComUIListElementScript elemenet = this.comUIListScript.GetElemenet(i);
					if (elemenet != null)
					{
						return elemenet.gameObjectBindScript as ComFashionAttributeModifyEquipment;
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

		// Token: 0x06011094 RID: 69780 RVA: 0x004E0468 File Offset: 0x004DE868
		public void Initialize(ClientFrame clientFrame, GameObject gameObject, ComFashionAttributeModifyEquipmentList.OnItemSelected onItemSelected, ulong linkGUID)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			ComFashionAttributeModifyEquipment.ms_selected = null;
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.onItemSelected = (ComFashionAttributeModifyEquipmentList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
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
			this.Selected = DataManager<ItemDataManager>.GetInstance().GetItem(linkGUID);
			this._LoadAllEquipments(ref this.equipments);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06011095 RID: 69781 RVA: 0x004E0590 File Offset: 0x004DE990
		private void _TryKeepLastSelectedEquipment()
		{
			if (ComFashionAttributeModifyEquipment.ms_selected != null)
			{
				ComFashionAttributeModifyEquipment.ms_selected = DataManager<ItemDataManager>.GetInstance().GetItem(ComFashionAttributeModifyEquipment.ms_selected.GUID);
				if (ComFashionAttributeModifyEquipment.ms_selected != null && this._CheckNeedFilter(ComFashionAttributeModifyEquipment.ms_selected))
				{
					ComFashionAttributeModifyEquipment.ms_selected = null;
				}
			}
		}

		// Token: 0x06011096 RID: 69782 RVA: 0x004E05E0 File Offset: 0x004DE9E0
		public void RefreshAllEquipments()
		{
			if (!this.Initilized)
			{
				return;
			}
			this._TryKeepLastSelectedEquipment();
			this._LoadAllEquipments(ref this.equipments);
			this._TrySetDefaultEquipment();
		}

		// Token: 0x06011097 RID: 69783 RVA: 0x004E0606 File Offset: 0x004DEA06
		public bool _TrySelectItem(ItemData target)
		{
			this._LoadAllEquipments(ref this.equipments);
			this.Selected = target;
			this._TrySetDefaultEquipment();
			return this.Selected.GUID == target.GUID;
		}

		// Token: 0x06011098 RID: 69784 RVA: 0x004E063A File Offset: 0x004DEA3A
		private bool _CheckNeedFilter(ItemData x)
		{
			return false;
		}

		// Token: 0x06011099 RID: 69785 RVA: 0x004E0640 File Offset: 0x004DEA40
		private void _LoadAllEquipments(ref List<ItemData> kEquipments)
		{
			kEquipments.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.FASHION);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = Utility._TryAddFashionItem(itemsByType[i]);
				if (itemData != null)
				{
					kEquipments.Add(itemData);
				}
			}
			kEquipments.RemoveAll((ItemData x) => x.SubType == 11 || !x.HasFashionAttribute);
			List<ItemData> list = kEquipments;
			if (ComFashionAttributeModifyEquipmentList.<>f__mg$cache0 == null)
			{
				ComFashionAttributeModifyEquipmentList.<>f__mg$cache0 = new Comparison<ItemData>(Utility._SortFashion);
			}
			list.Sort(ComFashionAttributeModifyEquipmentList.<>f__mg$cache0);
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x0601109A RID: 69786 RVA: 0x004E06F1 File Offset: 0x004DEAF1
		public bool HasEquipments()
		{
			return this.equipments.Count > 0;
		}

		// Token: 0x0601109B RID: 69787 RVA: 0x004E0704 File Offset: 0x004DEB04
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

		// Token: 0x0601109C RID: 69788 RVA: 0x004E0754 File Offset: 0x004DEB54
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

		// Token: 0x0601109D RID: 69789 RVA: 0x004E07EA File Offset: 0x004DEBEA
		private void _BindLinkData()
		{
		}

		// Token: 0x0601109E RID: 69790 RVA: 0x004E07EC File Offset: 0x004DEBEC
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

		// Token: 0x0601109F RID: 69791 RVA: 0x004E08B8 File Offset: 0x004DECB8
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

		// Token: 0x060110A0 RID: 69792 RVA: 0x004E090C File Offset: 0x004DED0C
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComFashionAttributeModifyEquipment comFashionAttributeModifyEquipment = item.gameObjectBindScript as ComFashionAttributeModifyEquipment;
			if (comFashionAttributeModifyEquipment != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comFashionAttributeModifyEquipment.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x060110A1 RID: 69793 RVA: 0x004E096C File Offset: 0x004DED6C
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComFashionAttributeModifyEquipment comFashionAttributeModifyEquipment = item.gameObjectBindScript as ComFashionAttributeModifyEquipment;
			ComFashionAttributeModifyEquipment.ms_selected = ((!(comFashionAttributeModifyEquipment == null)) ? comFashionAttributeModifyEquipment.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(ComFashionAttributeModifyEquipment.ms_selected);
			}
		}

		// Token: 0x060110A2 RID: 69794 RVA: 0x004E09C0 File Offset: 0x004DEDC0
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComFashionAttributeModifyEquipment comFashionAttributeModifyEquipment = item.gameObjectBindScript as ComFashionAttributeModifyEquipment;
			if (comFashionAttributeModifyEquipment != null)
			{
				comFashionAttributeModifyEquipment.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x060110A3 RID: 69795 RVA: 0x004E09EC File Offset: 0x004DEDEC
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
			this.onItemSelected = (ComFashionAttributeModifyEquipmentList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.clientFrame = null;
			this.equipments.Clear();
			ComFashionAttributeModifyEquipment.ms_selected = null;
			this.bInitialize = false;
		}

		// Token: 0x060110A4 RID: 69796 RVA: 0x004E0AF0 File Offset: 0x004DEEF0
		private int _SortEquipments(ItemData left, ItemData right)
		{
			if (left.PackageType != right.PackageType)
			{
				return right.PackageType - left.PackageType;
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

		// Token: 0x0400AF5E RID: 44894
		private bool bInitialize;

		// Token: 0x0400AF5F RID: 44895
		private ClientFrame clientFrame;

		// Token: 0x0400AF60 RID: 44896
		private GameObject gameObject;

		// Token: 0x0400AF61 RID: 44897
		private ComUIListScript comUIListScript;

		// Token: 0x0400AF62 RID: 44898
		public ComFashionAttributeModifyEquipmentList.OnItemSelected onItemSelected;

		// Token: 0x0400AF63 RID: 44899
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400AF64 RID: 44900
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x02001B1E RID: 6942
		// (Invoke) Token: 0x060110A7 RID: 69799
		public delegate void OnItemSelected(ItemData itemData);
	}
}
