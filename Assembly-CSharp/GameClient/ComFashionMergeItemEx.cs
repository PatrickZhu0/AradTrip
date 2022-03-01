using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B21 RID: 6945
	internal class ComFashionMergeItemEx : MonoBehaviour
	{
		// Token: 0x17001D94 RID: 7572
		// (get) Token: 0x060110FA RID: 69882 RVA: 0x004E3A63 File Offset: 0x004E1E63
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x060110FB RID: 69883 RVA: 0x004E3A87 File Offset: 0x004E1E87
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(false);
		}

		// Token: 0x060110FC RID: 69884 RVA: 0x004E3A95 File Offset: 0x004E1E95
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x060110FD RID: 69885 RVA: 0x004E3AB0 File Offset: 0x004E1EB0
		public void OnItemVisible(ItemData itemData)
		{
			if (itemData != null)
			{
				if (null != this.Name)
				{
					this.Name.text = itemData.GetColorName(string.Empty, false);
				}
				if (null != this.Atrribute)
				{
					this.Atrribute.text = DataManager<FashionAttributeSelectManager>.GetInstance().GetAttributesDesc(itemData.FashionAttributeID, "fashion_attribute_color", string.Empty);
				}
				if (null == this.comItem)
				{
					this.comItem = ComItemManager.Create(this.goItemParent);
				}
				if (null != this.comItem)
				{
					this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
				}
				base.gameObject.name = itemData.TableID.ToString();
			}
		}

		// Token: 0x060110FE RID: 69886 RVA: 0x004E3B8C File Offset: 0x004E1F8C
		public static void LoadAllEquipments(ref List<ItemData> kEquipments, ItemTable.eSubType eMergeType, bool bLocationLeft, bool needBlue = true)
		{
			kEquipments.Clear();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.FASHION);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData itemData = ComFashionMergeItemEx._TryAddMergeFashionItem(itemsByType[i]);
				if (itemData != null)
				{
					kEquipments.Add(itemData);
				}
			}
			for (int j = 0; j < kEquipments.Count; j++)
			{
				ItemData itemData2 = kEquipments[j];
				if (itemData2 == null)
				{
					kEquipments.RemoveAt(j--);
				}
				else
				{
					if (!bLocationLeft)
					{
						if (ComFashionMergeDataBinder.SLValue != null && ComFashionMergeDataBinder.SLValue.GUID == itemData2.GUID && itemData2.Count <= 1)
						{
							kEquipments.RemoveAt(j--);
							goto IL_137;
						}
					}
					else if (ComFashionMergeDataBinder.SRValue != null && ComFashionMergeDataBinder.SRValue.GUID == itemData2.GUID && itemData2.Count <= 1)
					{
						kEquipments.RemoveAt(j--);
						goto IL_137;
					}
					if (eMergeType != (ItemTable.eSubType)itemData2.SubType)
					{
						kEquipments.RemoveAt(j--);
					}
					else if (!needBlue && itemData2.Quality == ItemTable.eColor.BLUE)
					{
						kEquipments.RemoveAt(j--);
					}
				}
				IL_137:;
			}
			List<ItemData> list = kEquipments;
			if (ComFashionMergeItemEx.<>f__mg$cache0 == null)
			{
				ComFashionMergeItemEx.<>f__mg$cache0 = new Comparison<ItemData>(ComFashionMergeItemEx._SortFashion);
			}
			list.Sort(ComFashionMergeItemEx.<>f__mg$cache0);
		}

		// Token: 0x060110FF RID: 69887 RVA: 0x004E3D08 File Offset: 0x004E2108
		public static ItemData _TryAddMergeFashionItem(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item == null || item.Type != ItemTable.eType.FASHION || item.PackageType != EPackageType.Fashion)
			{
				return null;
			}
			if (item.bFashionItemLocked)
			{
				return null;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem == null || (tableItem.TimeLeft > 0 && item.DeadTimestamp != 0))
			{
				return null;
			}
			if (tableItem.SuitID == 101139)
			{
				return null;
			}
			if (DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType) && tableItem.Color == ItemTable.eColor.BLUE)
			{
				return null;
			}
			if (!DataManager<FashionMergeManager>.GetInstance().IsChangeSectionActivity(DataManager<FashionMergeManager>.GetInstance().FashionType))
			{
				FashionComposeSkyTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.Type < 10000)
				{
					return null;
				}
			}
			else
			{
				FashionComposeSkyTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<FashionComposeSkyTable>(item.TableID, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					return null;
				}
			}
			if (item.SubType == 11)
			{
				return null;
			}
			if (item.Quality == ItemTable.eColor.PINK)
			{
				return null;
			}
			return item;
		}

		// Token: 0x06011100 RID: 69888 RVA: 0x004E3E54 File Offset: 0x004E2254
		public static int _SortFashion(ItemData left, ItemData right)
		{
			if (left.bFashionItemLocked != right.bFashionItemLocked)
			{
				return left.bFashionItemLocked.CompareTo(right.bFashionItemLocked);
			}
			if (left.FashionWearSlotType != right.FashionWearSlotType)
			{
				return left.FashionWearSlotType - right.FashionWearSlotType;
			}
			if (left.Quality != right.Quality)
			{
				return left.Quality - right.Quality;
			}
			if (left.TableID != right.TableID)
			{
				return left.TableID - right.TableID;
			}
			return (int)(left.GUID - right.GUID);
		}

		// Token: 0x06011101 RID: 69889 RVA: 0x004E3EEF File Offset: 0x004E22EF
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
		}

		// Token: 0x0400AFB6 RID: 44982
		public GameObject goItemParent;

		// Token: 0x0400AFB7 RID: 44983
		public Text Name;

		// Token: 0x0400AFB8 RID: 44984
		public Text Atrribute;

		// Token: 0x0400AFB9 RID: 44985
		public GameObject goCheckMark;

		// Token: 0x0400AFBA RID: 44986
		private ComItem comItem;

		// Token: 0x0400AFBB RID: 44987
		[CompilerGenerated]
		private static Comparison<ItemData> <>f__mg$cache0;
	}
}
