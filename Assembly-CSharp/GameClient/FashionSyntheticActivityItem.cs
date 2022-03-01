using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018EF RID: 6383
	public class FashionSyntheticActivityItem : MonoBehaviour
	{
		// Token: 0x0600F8FB RID: 63739 RVA: 0x0043DCF4 File Offset: 0x0043C0F4
		public void OnItemVisiable(LimitTimeGiftPackDetailModel model, int index, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.limitTimeGiftPackDetailModel = model;
			this.index = index;
			this.onItemClick = onItemClick;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			if (model.mRewards.Length > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)model.mRewards[0].id, 100, 0);
				if (itemData != null)
				{
					itemData.Count = (int)model.mRewards[0].num;
					ComItem comItem = this.comItem;
					ItemData item = itemData;
					if (FashionSyntheticActivityItem.<>f__mg$cache0 == null)
					{
						FashionSyntheticActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, FashionSyntheticActivityItem.<>f__mg$cache0);
					this.mName.SafeSetText(itemData.GetColorName(string.Empty, false));
				}
			}
			this.mPrice.SafeSetText(string.Format("{0}点券", model.GiftPrice));
			this.mLimit.SafeSetText(TR.Value("mall_new_limit_player_forever_limit", model.LimitPurchaseNum - DataManager<CountDataManager>.GetInstance().GetCount(model.Id.ToString())));
			this.mBuyBtn.SafeRemoveAllListener();
			this.mBuyBtn.SafeAddOnClickListener(new UnityAction(this.OnBuyBtnClick));
			if (this.mBuyGray != null)
			{
				this.mBuyGray.enabled = (model.LimitPurchaseNum - DataManager<CountDataManager>.GetInstance().GetCount(model.Id.ToString()) <= 0);
			}
			if (this.mBuyBtn != null)
			{
				this.mBuyBtn.image.raycastTarget = (model.LimitPurchaseNum - DataManager<CountDataManager>.GetInstance().GetCount(model.Id.ToString()) > 0);
			}
		}

		// Token: 0x0600F8FC RID: 63740 RVA: 0x0043DED0 File Offset: 0x0043C2D0
		private void OnBuyBtnClick()
		{
			if (this.onItemClick != null)
			{
				this.onItemClick(this.index, 0, 0UL);
			}
		}

		// Token: 0x0600F8FD RID: 63741 RVA: 0x0043DEF1 File Offset: 0x0043C2F1
		private void OnDestroy()
		{
			this.index = 0;
			this.onItemClick = null;
			this.comItem = null;
		}

		// Token: 0x04009A84 RID: 39556
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x04009A85 RID: 39557
		[SerializeField]
		private Text mPrice;

		// Token: 0x04009A86 RID: 39558
		[SerializeField]
		private Text mLimit;

		// Token: 0x04009A87 RID: 39559
		[SerializeField]
		private Button mBuyBtn;

		// Token: 0x04009A88 RID: 39560
		[SerializeField]
		private UIGray mBuyGray;

		// Token: 0x04009A89 RID: 39561
		[SerializeField]
		private Text mName;

		// Token: 0x04009A8A RID: 39562
		private LimitTimeGiftPackDetailModel limitTimeGiftPackDetailModel;

		// Token: 0x04009A8B RID: 39563
		private int index;

		// Token: 0x04009A8C RID: 39564
		private ActivityItemBase.OnActivityItemClick<int> onItemClick;

		// Token: 0x04009A8D RID: 39565
		private ComItem comItem;

		// Token: 0x04009A8E RID: 39566
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
