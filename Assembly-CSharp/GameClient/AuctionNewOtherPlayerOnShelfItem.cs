using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001492 RID: 5266
	public class AuctionNewOtherPlayerOnShelfItem : MonoBehaviour
	{
		// Token: 0x0600CC33 RID: 52275 RVA: 0x003219F4 File Offset: 0x0031FDF4
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC34 RID: 52276 RVA: 0x003219FC File Offset: 0x0031FDFC
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CC35 RID: 52277 RVA: 0x00321A0A File Offset: 0x0031FE0A
		private void BindEvents()
		{
		}

		// Token: 0x0600CC36 RID: 52278 RVA: 0x00321A0C File Offset: 0x0031FE0C
		private void UnBindEvents()
		{
		}

		// Token: 0x0600CC37 RID: 52279 RVA: 0x00321A0E File Offset: 0x0031FE0E
		private void ResetData()
		{
			this._auctionBaseInfo = null;
			this._itemData = null;
		}

		// Token: 0x0600CC38 RID: 52280 RVA: 0x00321A1E File Offset: 0x0031FE1E
		public void InitItem(AuctionBaseInfo auctionBaseInfo)
		{
			this._auctionBaseInfo = auctionBaseInfo;
			if (this._auctionBaseInfo == null)
			{
				Logger.LogError("OtherPlayerOnShelf InitItem auctionBaseInfo is null");
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600CC39 RID: 52281 RVA: 0x00321A44 File Offset: 0x0031FE44
		private void InitItemView()
		{
			this._itemData = ItemDataManager.CreateItemDataFromTable((int)this._auctionBaseInfo.itemTypeId, 100, 0);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._auctionBaseInfo.itemTypeId, string.Empty, string.Empty);
			if (this._itemData == null || tableItem == null)
			{
				Logger.LogErrorFormat("ItemData or ItemTable is null and itemTypeid is {0}", new object[]
				{
					this._auctionBaseInfo.itemTypeId
				});
				return;
			}
			this._itemData.Count = (int)this._auctionBaseInfo.num;
			this._itemData.StrengthenLevel = (int)this._auctionBaseInfo.strengthed;
			this._itemData.GUID = this._auctionBaseInfo.guid;
			AuctionNewUtility.UpdateItemDataByEquipType(this._itemData, this._auctionBaseInfo);
			if (this.itemPos != null)
			{
				ComItem comItem = this.itemPos.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = ComItemManager.Create(this.itemPos);
				}
				if (comItem != null)
				{
					comItem.Setup(this._itemData, new ComItem.OnItemClicked(this.OnShowOtherPlayerItemTip));
					bool showTreasure = this._auctionBaseInfo.isTreas == 1;
					comItem.SetShowTreasure(showTreasure);
				}
			}
			if (this.itemName != null)
			{
				this.itemName.text = this._itemData.GetColorName(string.Empty, false);
			}
			if (this.itemScoreLabel != null)
			{
				if (this._auctionBaseInfo.itemScore > 0U)
				{
					CommonUtility.UpdateTextVisible(this.itemScoreLabel, true);
					this.itemScoreLabel.text = string.Format(TR.Value("auction_new_itemDetail_score_value"), this._auctionBaseInfo.itemScore);
				}
				else
				{
					CommonUtility.UpdateTextVisible(this.itemScoreLabel, false);
				}
			}
			if (this.itemPriceValueLabel != null)
			{
				ulong nNumber = (ulong)this._auctionBaseInfo.price;
				if (this._auctionBaseInfo.num > 0U)
				{
					nNumber = (ulong)this._auctionBaseInfo.price / (ulong)this._auctionBaseInfo.num;
				}
				this.itemPriceValueLabel.text = Utility.ToThousandsSeparator(nNumber);
			}
		}

		// Token: 0x0600CC3A RID: 52282 RVA: 0x00321C7B File Offset: 0x0032007B
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x0600CC3B RID: 52283 RVA: 0x00321C83 File Offset: 0x00320083
		private void OnShowOtherPlayerItemTip(GameObject obj, ItemData itemData)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, itemData.GUID);
		}

		// Token: 0x040076D0 RID: 30416
		private AuctionBaseInfo _auctionBaseInfo;

		// Token: 0x040076D1 RID: 30417
		private ItemData _itemData;

		// Token: 0x040076D2 RID: 30418
		[SerializeField]
		private GameObject itemPos;

		// Token: 0x040076D3 RID: 30419
		[Space(10f)]
		[Header("NormalContent")]
		[Space(10f)]
		[SerializeField]
		private Text itemName;

		// Token: 0x040076D4 RID: 30420
		[SerializeField]
		private Text itemScoreLabel;

		// Token: 0x040076D5 RID: 30421
		[SerializeField]
		private Text itemPriceValueLabel;
	}
}
