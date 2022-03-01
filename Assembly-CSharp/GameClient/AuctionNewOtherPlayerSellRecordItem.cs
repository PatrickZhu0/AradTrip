using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001494 RID: 5268
	public class AuctionNewOtherPlayerSellRecordItem : MonoBehaviour
	{
		// Token: 0x0600CC4A RID: 52298 RVA: 0x00321F83 File Offset: 0x00320383
		private void OnDestroy()
		{
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
			this._auctionTransaction = null;
		}

		// Token: 0x0600CC4B RID: 52299 RVA: 0x00321FAF File Offset: 0x003203AF
		public void InitItem(AuctionTransaction auctionTransaction)
		{
			this._auctionTransaction = auctionTransaction;
			if (this._auctionTransaction == null)
			{
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600CC4C RID: 52300 RVA: 0x00321FCC File Offset: 0x003203CC
		private void InitItemView()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this._auctionTransaction.item_id, 100, 0);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._auctionTransaction.item_id, string.Empty, string.Empty);
			if (itemData == null || tableItem == null)
			{
				Logger.LogErrorFormat("TreasureItemData is null and itemId is {0}", new object[]
				{
					this._auctionTransaction.item_id
				});
				return;
			}
			itemData.Count = (int)this._auctionTransaction.item_num;
			itemData.StrengthenLevel = (int)this._auctionTransaction.strength;
			itemData.SubQuality = (int)this._auctionTransaction.qualitylv;
			itemData.BeadAdditiveAttributeBuffID = (int)this._auctionTransaction.beadbuffId;
			AuctionNewUtility.UpdateItemDataByEquipType(itemData, this._auctionTransaction.equipType, this._auctionTransaction.enhance_type, (int)this._auctionTransaction.enhanceNum);
			if (itemData.SubType != 25)
			{
				itemData.mPrecEnchantmentCard = DataManager<ItemDataManager>.GetInstance().MountMagicCardInItem(this._auctionTransaction.mountMagicCardId, this._auctionTransaction.mountMagicCardLv);
			}
			if (itemData.SubType != 54)
			{
				itemData.PreciousBeadMountHole = DataManager<ItemDataManager>.GetInstance().MountBeadInItem(this._auctionTransaction.mountBeadId, this._auctionTransaction.mountBeadBuffId);
			}
			if (this.itemName != null)
			{
				this.itemName.text = itemData.GetColorName(string.Empty, false);
			}
			if (this.itemPos != null)
			{
				this._comItem = this.itemPos.GetComponentInChildren<ComItem>();
				if (this._comItem == null)
				{
					this._comItem = ComItemManager.Create(this.itemPos);
				}
				if (this._comItem != null)
				{
					this._comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowItemTip));
					this._comItem.SetShowTreasure(true);
				}
			}
			if (this.itemPriceValueLabel != null)
			{
				ulong nNumber = (ulong)this._auctionTransaction.unit_price;
				this.itemPriceValueLabel.text = Utility.ToThousandsSeparator(nNumber);
			}
		}

		// Token: 0x0600CC4D RID: 52301 RVA: 0x003221DE File Offset: 0x003205DE
		public void OnItemRecycle()
		{
			this._auctionTransaction = null;
		}

		// Token: 0x0600CC4E RID: 52302 RVA: 0x003221E7 File Offset: 0x003205E7
		private void OnShowItemTip(GameObject obj, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x040076D9 RID: 30425
		private AuctionTransaction _auctionTransaction;

		// Token: 0x040076DA RID: 30426
		private ComItem _comItem;

		// Token: 0x040076DB RID: 30427
		[Space(10f)]
		[Header("ItemContent")]
		[Space(5f)]
		[SerializeField]
		private GameObject itemPos;

		// Token: 0x040076DC RID: 30428
		[SerializeField]
		private Text itemName;

		// Token: 0x040076DD RID: 30429
		[SerializeField]
		private Text itemPriceValueLabel;
	}
}
