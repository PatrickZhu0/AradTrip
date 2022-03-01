using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A73 RID: 6771
	public class GoblinPreviewItem : MonoBehaviour
	{
		// Token: 0x060109F5 RID: 68085 RVA: 0x004B38E4 File Offset: 0x004B1CE4
		public void InitUI(MallItemInfo mallItemInfo)
		{
			this.mName.text = string.Format("购买{0}", mallItemInfo.giftName);
			if (mallItemInfo.buyGotInfos != null && mallItemInfo.buyGotInfos.Length != 0)
			{
				this.mScoreNum.text = mallItemInfo.buyGotInfos[0].buyGotNum.ToString();
			}
			ComItem comItem = this.itemRoot.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				ComItem comItem2 = ComItemManager.Create(this.itemRoot);
				comItem = comItem2;
			}
			if (mallItemInfo.giftItems != null && mallItemInfo.giftItems.Length != 0)
			{
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)mallItemInfo.giftItems[0].id, 100, 0);
				if (ItemDetailData != null)
				{
					ItemDetailData.Count = 1;
					comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
					{
						this._OnShowTips(ItemDetailData);
					});
				}
			}
		}

		// Token: 0x060109F6 RID: 68086 RVA: 0x004B39DC File Offset: 0x004B1DDC
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0400A99F RID: 43423
		[SerializeField]
		private Text mName;

		// Token: 0x0400A9A0 RID: 43424
		[SerializeField]
		private Text mScoreNum;

		// Token: 0x0400A9A1 RID: 43425
		[SerializeField]
		private GameObject itemRoot;
	}
}
