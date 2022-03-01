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
	// Token: 0x02001AE8 RID: 6888
	internal class ComSarahCardInlayItemList
	{
		// Token: 0x17001D78 RID: 7544
		// (get) Token: 0x06010E8C RID: 69260 RVA: 0x004D415E File Offset: 0x004D255E
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D79 RID: 7545
		// (get) Token: 0x06010E8D RID: 69261 RVA: 0x004D4166 File Offset: 0x004D2566
		// (set) Token: 0x06010E8E RID: 69262 RVA: 0x004D416D File Offset: 0x004D256D
		public ItemData Selected
		{
			get
			{
				return ComSarahCardInlayItem.ms_selected;
			}
			set
			{
				ComSarahCardInlayItem.ms_selected = value;
			}
		}

		// Token: 0x06010E8F RID: 69263 RVA: 0x004D4178 File Offset: 0x004D2578
		private ComSarahCardInlayItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComSarahCardInlayItem>();
		}

		// Token: 0x06010E90 RID: 69264 RVA: 0x004D418D File Offset: 0x004D258D
		public bool HasEquipments()
		{
			return this.equipments.Count > 0;
		}

		// Token: 0x06010E91 RID: 69265 RVA: 0x004D41A0 File Offset: 0x004D25A0
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

		// Token: 0x06010E92 RID: 69266 RVA: 0x004D41F4 File Offset: 0x004D25F4
		public int FindObject(ulong guid)
		{
			for (int i = 0; i < this.equipments.Count; i++)
			{
				if (this.equipments[i] != null && this.equipments[i].GUID == guid)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06010E93 RID: 69267 RVA: 0x004D4248 File Offset: 0x004D2648
		public void Initialize(GameObject gameObject, ComSarahCardInlayItemList.OnItemSelected onItemSelected, SmithShopNewLinkData linkData, SarahsFuctionData data)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.Selected = null;
			this.gameObject = gameObject;
			this.onItemSelected = onItemSelected;
			this.linkData = linkData;
			this.data = data;
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
			this._LoadAllEquipments(ref this.equipments, PreciousBeadMountHoleType.PBMHT_COMMON);
			this._BindLinkData();
		}

		// Token: 0x06010E94 RID: 69268 RVA: 0x004D4357 File Offset: 0x004D2757
		public void RefreshAllEquipments(PreciousBeadMountHoleType type = PreciousBeadMountHoleType.PBMHT_COMMON)
		{
			if (this.Initilized)
			{
				this._LoadAllEquipments(ref this.equipments, type);
				this.gameObject.GetComponent<ScrollRect>().verticalNormalizedPosition = 1f;
			}
		}

		// Token: 0x06010E95 RID: 69269 RVA: 0x004D4388 File Offset: 0x004D2788
		private void _LoadAllEquipments(ref List<ItemData> kEquipments, PreciousBeadMountHoleType type = PreciousBeadMountHoleType.PBMHT_COMMON)
		{
			kEquipments.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = ComSarahCardInlayItem._TryAddSarahCard(itemsByType[i]);
				if (itemData != null)
				{
					kEquipments.Add(itemData);
				}
			}
			kEquipments.RemoveAll(delegate(ItemData x)
			{
				BeadTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(x.TableID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return true;
				}
				if (type == PreciousBeadMountHoleType.PBMHT_COMMON)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.ID, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						return true;
					}
					if (tableItem2.BeadType != 1)
					{
						return true;
					}
				}
				return this.data == null || this.data.rightItem == null || !tableItem.Parts.Contains((int)this.data.rightItem.EquipWearSlotType);
			});
			List<ItemData> list = kEquipments;
			if (ComSarahCardInlayItemList.<>f__mg$cache0 == null)
			{
				ComSarahCardInlayItemList.<>f__mg$cache0 = new Comparison<ItemData>(ComSarahCardInlayItem.Sort);
			}
			list.Sort(ComSarahCardInlayItemList.<>f__mg$cache0);
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010E96 RID: 69270 RVA: 0x004D443C File Offset: 0x004D283C
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

		// Token: 0x06010E97 RID: 69271 RVA: 0x004D448C File Offset: 0x004D288C
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

		// Token: 0x06010E98 RID: 69272 RVA: 0x004D4524 File Offset: 0x004D2924
		private void _BindLinkData()
		{
			if (this.linkData != null)
			{
				if (this.linkData.itemData != null && this.HasObject(this.linkData.itemData.GUID))
				{
					int num = this.FindObject(this.linkData.itemData.GUID);
					if (num != -1)
					{
						this._SetSelectedItem(num);
					}
				}
				this.linkData = null;
			}
		}

		// Token: 0x06010E99 RID: 69273 RVA: 0x004D4594 File Offset: 0x004D2994
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			if (comSarahCardInlayItem != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comSarahCardInlayItem.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010E9A RID: 69274 RVA: 0x004D45F4 File Offset: 0x004D29F4
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			this.Selected = ((!(comSarahCardInlayItem == null)) ? comSarahCardInlayItem.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(this.Selected);
			}
		}

		// Token: 0x06010E9B RID: 69275 RVA: 0x004D4648 File Offset: 0x004D2A48
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComSarahCardInlayItem comSarahCardInlayItem = item.gameObjectBindScript as ComSarahCardInlayItem;
			if (comSarahCardInlayItem != null)
			{
				comSarahCardInlayItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010E9C RID: 69276 RVA: 0x004D4674 File Offset: 0x004D2A74
		public void ClearSelectedItem()
		{
			this.Selected = null;
			if (this.comUIListScript != null)
			{
				this.comUIListScript.SelectElement(-1, true);
			}
		}

		// Token: 0x06010E9D RID: 69277 RVA: 0x004D469C File Offset: 0x004D2A9C
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
			this.data = null;
			this.linkData = null;
			this.onItemSelected = (ComSarahCardInlayItemList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.equipments.Clear();
			this.Selected = null;
			this.bInitialize = false;
		}

		// Token: 0x0400ADC0 RID: 44480
		private bool bInitialize;

		// Token: 0x0400ADC1 RID: 44481
		private GameObject gameObject;

		// Token: 0x0400ADC2 RID: 44482
		private ComUIListScript comUIListScript;

		// Token: 0x0400ADC3 RID: 44483
		public ComSarahCardInlayItemList.OnItemSelected onItemSelected;

		// Token: 0x0400ADC4 RID: 44484
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400ADC5 RID: 44485
		public SmithShopNewLinkData linkData;

		// Token: 0x0400ADC6 RID: 44486
		public SarahsFuctionData data;

		// Token: 0x0400ADC7 RID: 44487
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x02001AE9 RID: 6889
		// (Invoke) Token: 0x06010E9F RID: 69279
		public delegate void OnItemSelected(ItemData itemData);
	}
}
