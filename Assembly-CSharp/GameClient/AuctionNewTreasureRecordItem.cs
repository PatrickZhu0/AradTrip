using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200149F RID: 5279
	public class AuctionNewTreasureRecordItem : MonoBehaviour
	{
		// Token: 0x0600CCB5 RID: 52405 RVA: 0x003244D8 File Offset: 0x003228D8
		private void OnDestroy()
		{
			if (this._elementComItem != null)
			{
				ComItemManager.Destroy(this._elementComItem);
				this._elementComItem = null;
			}
			this._auctionTransaction = null;
		}

		// Token: 0x0600CCB6 RID: 52406 RVA: 0x00324504 File Offset: 0x00322904
		public void InitItem(AuctionTransaction auctionTransaction, bool isSellRecord = true)
		{
			this._auctionTransaction = auctionTransaction;
			this._isSellRecord = isSellRecord;
			if (this._auctionTransaction == null)
			{
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600CCB7 RID: 52407 RVA: 0x00324528 File Offset: 0x00322928
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
			if (this.itemName != null)
			{
				this.itemName.text = AuctionNewUtility.GetQualityColorString(itemData.Name, tableItem.Color);
			}
			if (this.itemRoot != null)
			{
				this._elementComItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (this._elementComItem == null)
				{
					this._elementComItem = ComItemManager.Create(this.itemRoot);
				}
				if (this._elementComItem != null)
				{
					this._elementComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowItemTip));
					this._elementComItem.SetShowTreasure(true);
				}
			}
			if (this.itemScore != null)
			{
				if (this._auctionTransaction.item_score <= 0U)
				{
					this.itemScore.gameObject.CustomActive(false);
				}
				else
				{
					this.itemScore.gameObject.CustomActive(true);
					this.itemScore.text = string.Format(TR.Value("auction_new_itemDetail_score_value"), this._auctionTransaction.item_score);
				}
			}
			if (this.itemPriceLabel != null)
			{
				this.itemPriceLabel.text = TR.Value("auction_new_sell_item_single_price");
			}
			if (this.itemPriceValue != null)
			{
				ulong num = (ulong)this._auctionTransaction.unit_price;
				this.itemPriceValue.text = Utility.GetShowPrice(num, false);
				this.itemPriceValue.text = Utility.ToThousandsSeparator(num);
			}
			if (this._isSellRecord)
			{
				this.ResetItemGetLabel();
				if (DataManager<TimeManager>.GetInstance().GetServerTime() > this._auctionTransaction.verify_end_time)
				{
					if (this.itemGetFlagLabel != null)
					{
						this.itemGetFlagLabel.gameObject.CustomActive(true);
					}
				}
				else if (this.itemGetTimeLabel != null)
				{
					this.itemGetTimeLabel.gameObject.CustomActive(true);
					this.itemGetTimeLabel.text = CountDownTimeUtility.GetCountDownTimeByHourMinute(this._auctionTransaction.verify_end_time, DataManager<TimeManager>.GetInstance().GetServerTime());
					if (this.countDownTimeController != null)
					{
						this.countDownTimeController.EndTime = this._auctionTransaction.verify_end_time;
						this.countDownTimeController.InitCountDownTimeController();
					}
				}
			}
			else
			{
				this.ResetItemGetLabel();
			}
		}

		// Token: 0x0600CCB8 RID: 52408 RVA: 0x00324800 File Offset: 0x00322C00
		private void ResetItemGetLabel()
		{
			if (this.itemGetFlagLabel != null)
			{
				this.itemGetFlagLabel.gameObject.CustomActive(false);
			}
			if (this.itemGetTimeLabel != null)
			{
				this.itemGetTimeLabel.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600CCB9 RID: 52409 RVA: 0x00324851 File Offset: 0x00322C51
		public void OnItemRecycle()
		{
			this._auctionTransaction = null;
			if (this.countDownTimeController != null)
			{
				this.countDownTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x0600CCBA RID: 52410 RVA: 0x00324876 File Offset: 0x00322C76
		private void OnShowItemTip(GameObject obj, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0400772A RID: 30506
		private bool _isSellRecord = true;

		// Token: 0x0400772B RID: 30507
		private AuctionTransaction _auctionTransaction;

		// Token: 0x0400772C RID: 30508
		private ComItem _elementComItem;

		// Token: 0x0400772D RID: 30509
		private float _baseIntervalTime;

		// Token: 0x0400772E RID: 30510
		[Space(10f)]
		[Header("ItemContent")]
		[Space(5f)]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400772F RID: 30511
		[SerializeField]
		private Text itemName;

		// Token: 0x04007730 RID: 30512
		[SerializeField]
		private Text itemScore;

		// Token: 0x04007731 RID: 30513
		[SerializeField]
		private Text itemPriceLabel;

		// Token: 0x04007732 RID: 30514
		[SerializeField]
		private Text itemPriceValue;

		// Token: 0x04007733 RID: 30515
		[SerializeField]
		private Text itemGetTimeLabel;

		// Token: 0x04007734 RID: 30516
		[SerializeField]
		private CountDownTimeController countDownTimeController;

		// Token: 0x04007735 RID: 30517
		[SerializeField]
		private Text itemGetFlagLabel;
	}
}
