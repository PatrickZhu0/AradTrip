using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A79 RID: 6777
	public class ShopNewCostItem : MonoBehaviour
	{
		// Token: 0x06010A1C RID: 68124 RVA: 0x004B4AD5 File Offset: 0x004B2ED5
		public void InitCostItem(int costItemId, int costNumber, int vipDisCount = 100)
		{
			this._costItemId = costItemId;
			this._costNumber = costNumber;
			this._vipDiscount = vipDisCount;
			this.UpdateCostItemImage();
		}

		// Token: 0x06010A1D RID: 68125 RVA: 0x004B4AF4 File Offset: 0x004B2EF4
		private void UpdateCostItemImage()
		{
			if (this.costItemImage != null)
			{
				EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(this._costItemId, string.Empty, string.Empty);
				if (tableItem != null && tableItem.EqualItemIDs != null && tableItem.EqualItemIDs.Count > 0)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.EqualItemIDs[0], string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ETCImageLoader.LoadSprite(ref this.costItemImage, tableItem2.Icon, true);
					}
				}
				else
				{
					ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._costItemId, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						ETCImageLoader.LoadSprite(ref this.costItemImage, tableItem3.Icon, true);
					}
				}
			}
		}

		// Token: 0x06010A1E RID: 68126 RVA: 0x004B4BC4 File Offset: 0x004B2FC4
		public void UpdateCostItemValue()
		{
			int num = this._costNumber;
			num = ShopNewUtility.GetRealCostValue(num, this._vipDiscount);
			if (this.costValueText != null)
			{
				this.costValueText.text = num.ToString();
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._costItemId, true);
				if (ownedItemCount >= num)
				{
					this.costValueText.color = Color.white;
				}
				else
				{
					this.costValueText.color = Color.red;
				}
			}
		}

		// Token: 0x06010A1F RID: 68127 RVA: 0x004B4C4C File Offset: 0x004B304C
		public void UpdateCostItemValueByBuyNumber(int buyNumber)
		{
			if (this.costValueText == null)
			{
				return;
			}
			int num = this._costNumber;
			num = ShopNewUtility.GetRealCostValue(num, this._vipDiscount);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._costItemId, true);
			int num2 = num * buyNumber;
			this.costValueText.text = num2.ToString();
			this.costValueText.color = ((ownedItemCount >= num2) ? DataManager<ShopNewDataManager>.GetInstance().specialColor : Color.red);
		}

		// Token: 0x0400A9D8 RID: 43480
		private int _costItemId;

		// Token: 0x0400A9D9 RID: 43481
		private int _costNumber;

		// Token: 0x0400A9DA RID: 43482
		private int _vipDiscount;

		// Token: 0x0400A9DB RID: 43483
		[Space(5f)]
		[Header("NormalContent")]
		[SerializeField]
		private Image costItemImage;

		// Token: 0x0400A9DC RID: 43484
		[SerializeField]
		private Text costValueText;
	}
}
