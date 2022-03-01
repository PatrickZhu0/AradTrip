using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E8 RID: 6376
	public class DailyRewardGiftItem : MonoBehaviour, IDailyRewardGiftItem, IDisposable
	{
		// Token: 0x0600F8D4 RID: 63700 RVA: 0x0043CA50 File Offset: 0x0043AE50
		public void Init(List<DailyRewardDetailData> giftList)
		{
			if (giftList.Count <= 0)
			{
				Logger.LogError("gift 数组数量为0");
				return;
			}
			this.Dispose();
			for (int i = 0; i < giftList.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(giftList[i].mSimpleData.ItemID, 100, 0);
					itemData.Count = giftList[i].mSimpleData.Count;
					comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					this.mComItems.Add(comItem);
				}
			}
			this.mTextDescription.SafeSetText(giftList[0].Desc);
		}

		// Token: 0x0600F8D5 RID: 63701 RVA: 0x0043CB2C File Offset: 0x0043AF2C
		public void Dispose()
		{
			for (int i = this.mComItems.Count - 1; i >= 0; i--)
			{
				ComItemManager.Destroy(this.mComItems[i]);
			}
			this.mComItems.Clear();
		}

		// Token: 0x0600F8D6 RID: 63702 RVA: 0x0043CB73 File Offset: 0x0043AF73
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0600F8D7 RID: 63703 RVA: 0x0043CB7B File Offset: 0x0043AF7B
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x04009A50 RID: 39504
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A51 RID: 39505
		[SerializeField]
		private Image mImageBg;

		// Token: 0x04009A52 RID: 39506
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009A53 RID: 39507
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009A54 RID: 39508
		private List<ComItem> mComItems = new List<ComItem>();
	}
}
