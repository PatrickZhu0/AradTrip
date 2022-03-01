using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200112B RID: 4395
	public class EquipItemShow : MonoBehaviour
	{
		// Token: 0x0600A6F7 RID: 42743 RVA: 0x0022C83C File Offset: 0x0022AC3C
		private void Start()
		{
			if (this.comEquip == null)
			{
				this.comEquip = ComItemManager.Create(this.parentObj);
				this.comEquip.SetupSlot(ComItem.ESlotType.Opened, this.slotName, null, string.Empty);
			}
			this._InitWearEquip();
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
		}

		// Token: 0x0600A6F8 RID: 42744 RVA: 0x0022C8AF File Offset: 0x0022ACAF
		private void OnDestroy()
		{
			this.CurWearEquipGuid = 0UL;
			this.equipSlot = EEquipWearSlotType.EquipInvalid;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
		}

		// Token: 0x0600A6F9 RID: 42745 RVA: 0x0022C8E8 File Offset: 0x0022ACE8
		private void _OnUpdateItem(List<Item> items)
		{
			if (items == null)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				Item item = items[i];
				if (item != null)
				{
					this._UpdateWearEquip(item);
				}
			}
		}

		// Token: 0x0600A6FA RID: 42746 RVA: 0x0022C930 File Offset: 0x0022AD30
		private void _InitWearEquip()
		{
			if (this.parentObj == null)
			{
				Logger.LogErrorFormat("parentObj is null in EquipItemShow, check preferb", new object[0]);
				return;
			}
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					if (item.EquipWearSlotType == this.equipSlot)
					{
						if (this.comEquip != null)
						{
							this.comEquip.Setup(item, new ComItem.OnItemClicked(this._OnWearedItemClicked));
							this.CurWearEquipGuid = item.GUID;
						}
						break;
					}
				}
			}
		}

		// Token: 0x0600A6FB RID: 42747 RVA: 0x0022C9F0 File Offset: 0x0022ADF0
		private void _UpdateWearEquip(Item item)
		{
			if (this.parentObj == null || this.comEquip == null || item == null)
			{
				return;
			}
			ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(item.uid);
			if (item2 == null)
			{
				return;
			}
			if (item2.EquipWearSlotType != this.equipSlot)
			{
				return;
			}
			if (item.pack == 6)
			{
				this.comEquip.Setup(item2, new ComItem.OnItemClicked(this._OnWearedItemClicked));
				this.CurWearEquipGuid = item.uid;
			}
			else if (item.pack == 1)
			{
				if (this.CurWearEquipGuid != item.uid)
				{
					return;
				}
				this.comEquip.Setup(null, null);
				this.CurWearEquipGuid = 0UL;
			}
		}

		// Token: 0x0600A6FC RID: 42748 RVA: 0x0022CAB8 File Offset: 0x0022AEB8
		private void _OnWearedItemClicked(GameObject obj, ItemData item)
		{
			if (item == null)
			{
				return;
			}
			List<TipFuncButon> list = new List<TipFuncButon>();
			if (item.Type == ItemTable.eType.EQUIP || item.Type == ItemTable.eType.FASHION || item.Type == ItemTable.eType.FUCKTITTLE)
			{
				list.Add(new TipFuncButonSpecial
				{
					text = TR.Value("tip_takeoff"),
					callback = new OnTipFuncClicked(this._OnUnWear)
				});
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(item, list, 3, true, false, true);
		}

		// Token: 0x0600A6FD RID: 42749 RVA: 0x0022CB37 File Offset: 0x0022AF37
		private void _OnUnWear(ItemData item, object data)
		{
			if (item != null)
			{
				DataManager<ItemDataManager>.GetInstance().UseItem(item, false, 0, 0);
				MonoSingleton<AudioManager>.instance.PlaySound(103);
				DataManager<ItemTipManager>.GetInstance().CloseAll();
			}
		}

		// Token: 0x0600A6FE RID: 42750 RVA: 0x0022CB64 File Offset: 0x0022AF64
		private void Update()
		{
		}

		// Token: 0x04005D7A RID: 23930
		public GameObject parentObj;

		// Token: 0x04005D7B RID: 23931
		public EEquipWearSlotType equipSlot;

		// Token: 0x04005D7C RID: 23932
		public string slotName = string.Empty;

		// Token: 0x04005D7D RID: 23933
		private ComItem comEquip;

		// Token: 0x04005D7E RID: 23934
		private ulong CurWearEquipGuid;
	}
}
