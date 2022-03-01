using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000043 RID: 67
	internal class ComMergeMoneyControl : MonoBehaviour
	{
		// Token: 0x060001A6 RID: 422 RVA: 0x0000F166 File Offset: 0x0000D566
		private void OnDestroy()
		{
			if (null != this.comItem)
			{
				this.comItem.Setup(null, null);
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
			this.goItemParent = null;
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x0000F1A0 File Offset: 0x0000D5A0
		public void SetState(ComMergeMoneyControl.CMMC eCMMC)
		{
			if (eCMMC != ComMergeMoneyControl.CMMC.CMMC_ENOUGH)
			{
				if (eCMMC == ComMergeMoneyControl.CMMC.CMMC_NOT_ENOUGH)
				{
					if (null != this.stateControl)
					{
						this.stateControl.Key = this.key_notenough;
					}
				}
			}
			else if (null != this.stateControl)
			{
				this.stateControl.Key = this.key_enough;
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x0000F210 File Offset: 0x0000D610
		public void SetCost(int moneyId, int moneyCount)
		{
			if (null == this.comItem && null != this.goItemParent)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(moneyId, 100, 0);
			if (itemData != null)
			{
				itemData.Count = 1;
			}
			if (null != this.comItem)
			{
				this.comItem.Setup(itemData, null);
			}
			if (null != this.Name)
			{
				if (itemData != null)
				{
					this.Name.text = itemData.Name;
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyId, true);
				int num = moneyCount;
				bool flag = ownedItemCount >= num || num < 0;
				this.count.color = ((!flag) ? Color.red : Color.white);
				this.count.text = num.ToString();
			}
		}

		// Token: 0x0400018D RID: 397
		private string key_enough = "enough";

		// Token: 0x0400018E RID: 398
		private string key_notenough = "not_enough";

		// Token: 0x0400018F RID: 399
		public StateController stateControl;

		// Token: 0x04000190 RID: 400
		public GameObject goItemParent;

		// Token: 0x04000191 RID: 401
		public Text Name;

		// Token: 0x04000192 RID: 402
		public Text count;

		// Token: 0x04000193 RID: 403
		private ComItem comItem;

		// Token: 0x02000044 RID: 68
		public enum CMMC
		{
			// Token: 0x04000195 RID: 405
			CMMC_ENOUGH,
			// Token: 0x04000196 RID: 406
			CMMC_NOT_ENOUGH
		}
	}
}
