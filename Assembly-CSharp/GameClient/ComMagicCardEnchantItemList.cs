using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AE5 RID: 6885
	internal class ComMagicCardEnchantItemList
	{
		// Token: 0x17001D75 RID: 7541
		// (get) Token: 0x06010E68 RID: 69224 RVA: 0x004D36A3 File Offset: 0x004D1AA3
		public bool Initilized
		{
			get
			{
				return this.bInitialize;
			}
		}

		// Token: 0x17001D76 RID: 7542
		// (get) Token: 0x06010E69 RID: 69225 RVA: 0x004D36AB File Offset: 0x004D1AAB
		// (set) Token: 0x06010E6A RID: 69226 RVA: 0x004D36B2 File Offset: 0x004D1AB2
		public ItemData Selected
		{
			get
			{
				return ComMagicCardEnchantItem.ms_selected;
			}
			set
			{
				ComMagicCardEnchantItem.ms_selected = value;
			}
		}

		// Token: 0x06010E6B RID: 69227 RVA: 0x004D36BC File Offset: 0x004D1ABC
		private ComMagicCardEnchantItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComMagicCardEnchantItem>();
		}

		// Token: 0x06010E6C RID: 69228 RVA: 0x004D36D1 File Offset: 0x004D1AD1
		public bool HasEquipments()
		{
			return this.equipments.Count > 0;
		}

		// Token: 0x06010E6D RID: 69229 RVA: 0x004D36E4 File Offset: 0x004D1AE4
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

		// Token: 0x06010E6E RID: 69230 RVA: 0x004D3738 File Offset: 0x004D1B38
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

		// Token: 0x06010E6F RID: 69231 RVA: 0x004D378C File Offset: 0x004D1B8C
		public void Initialize(GameObject gameObject, ComMagicCardEnchantItemList.OnItemSelected onItemSelected, SmithShopNewLinkData linkData, EnchantmentsFunctionData data)
		{
			if (this.bInitialize)
			{
				return;
			}
			this.bInitialize = true;
			this.Selected = null;
			this.gameObject = gameObject;
			this.onItemSelected = (ComMagicCardEnchantItemList.OnItemSelected)Delegate.Combine(this.onItemSelected, onItemSelected);
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
			this._LoadAllEquipments(ref this.equipments);
			this._BindLinkData();
		}

		// Token: 0x06010E70 RID: 69232 RVA: 0x004D38AA File Offset: 0x004D1CAA
		public void RefreshAllEquipments()
		{
			if (this.Initilized)
			{
				this._LoadAllEquipments(ref this.equipments);
			}
		}

		// Token: 0x06010E71 RID: 69233 RVA: 0x004D38C4 File Offset: 0x004D1CC4
		private void _LoadAllEquipments(ref List<ItemData> kEquipments)
		{
			kEquipments.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = ComMagicCardEnchantItem._TryAddMagicCard(itemsByType[i]);
				if (itemData != null)
				{
					kEquipments.Add(itemData);
				}
			}
			kEquipments.RemoveAll(delegate(ItemData x)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(x.TableID, string.Empty, string.Empty);
				return tableItem == null || (this.data == null || this.data.rightItem == null) || !tableItem.Parts.Contains((int)this.data.rightItem.EquipWearSlotType);
			});
			List<ItemData> list = kEquipments;
			if (ComMagicCardEnchantItemList.<>f__mg$cache0 == null)
			{
				ComMagicCardEnchantItemList.<>f__mg$cache0 = new Comparison<ItemData>(ComMagicCardEnchantItem.Sort);
			}
			list.Sort(ComMagicCardEnchantItemList.<>f__mg$cache0);
			this.comUIListScript.SetElementAmount(this.equipments.Count);
		}

		// Token: 0x06010E72 RID: 69234 RVA: 0x004D3964 File Offset: 0x004D1D64
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

		// Token: 0x06010E73 RID: 69235 RVA: 0x004D39B4 File Offset: 0x004D1DB4
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

		// Token: 0x06010E74 RID: 69236 RVA: 0x004D3A4C File Offset: 0x004D1E4C
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

		// Token: 0x06010E75 RID: 69237 RVA: 0x004D3ABC File Offset: 0x004D1EBC
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

		// Token: 0x06010E76 RID: 69238 RVA: 0x004D3B88 File Offset: 0x004D1F88
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComMagicCardEnchantItem comMagicCardEnchantItem = item.gameObjectBindScript as ComMagicCardEnchantItem;
			if (comMagicCardEnchantItem != null && item.m_index >= 0 && item.m_index < this.equipments.Count)
			{
				comMagicCardEnchantItem.OnItemVisible(this.equipments[item.m_index]);
			}
		}

		// Token: 0x06010E77 RID: 69239 RVA: 0x004D3BE8 File Offset: 0x004D1FE8
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ComMagicCardEnchantItem comMagicCardEnchantItem = item.gameObjectBindScript as ComMagicCardEnchantItem;
			this.Selected = ((!(comMagicCardEnchantItem == null)) ? comMagicCardEnchantItem.ItemData : null);
			if (this.onItemSelected != null)
			{
				this.onItemSelected(this.Selected);
			}
		}

		// Token: 0x06010E78 RID: 69240 RVA: 0x004D3C3C File Offset: 0x004D203C
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ComMagicCardEnchantItem comMagicCardEnchantItem = item.gameObjectBindScript as ComMagicCardEnchantItem;
			if (comMagicCardEnchantItem != null)
			{
				comMagicCardEnchantItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x06010E79 RID: 69241 RVA: 0x004D3C68 File Offset: 0x004D2068
		public void ClearSelectedItem()
		{
			this.Selected = null;
			if (this.comUIListScript != null)
			{
				this.comUIListScript.SelectElement(-1, true);
			}
		}

		// Token: 0x06010E7A RID: 69242 RVA: 0x004D3C90 File Offset: 0x004D2090
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
			this.onItemSelected = (ComMagicCardEnchantItemList.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.gameObject = null;
			this.equipments.Clear();
			this.Selected = null;
			this.bInitialize = false;
		}

		// Token: 0x0400ADAB RID: 44459
		private bool bInitialize;

		// Token: 0x0400ADAC RID: 44460
		private GameObject gameObject;

		// Token: 0x0400ADAD RID: 44461
		private ComUIListScript comUIListScript;

		// Token: 0x0400ADAE RID: 44462
		public ComMagicCardEnchantItemList.OnItemSelected onItemSelected;

		// Token: 0x0400ADAF RID: 44463
		private List<ItemData> equipments = new List<ItemData>();

		// Token: 0x0400ADB0 RID: 44464
		public SmithShopNewLinkData linkData;

		// Token: 0x0400ADB1 RID: 44465
		public EnchantmentsFunctionData data;

		// Token: 0x0400ADB2 RID: 44466
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;

		// Token: 0x02001AE6 RID: 6886
		// (Invoke) Token: 0x06010E7D RID: 69245
		public delegate void OnItemSelected(ItemData itemData);
	}
}
