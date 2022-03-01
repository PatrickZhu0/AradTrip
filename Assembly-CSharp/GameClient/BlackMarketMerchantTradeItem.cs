using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A40 RID: 6720
	internal class BlackMarketMerchantTradeItem : MonoBehaviour
	{
		// Token: 0x17001D50 RID: 7504
		// (get) Token: 0x06010809 RID: 67593 RVA: 0x004A5717 File Offset: 0x004A3B17
		// (set) Token: 0x0601080A RID: 67594 RVA: 0x004A571F File Offset: 0x004A3B1F
		public ulong GUID
		{
			get
			{
				return this.mGUID;
			}
			set
			{
				this.mGUID = value;
			}
		}

		// Token: 0x0601080B RID: 67595 RVA: 0x004A5728 File Offset: 0x004A3B28
		public void OnItemVisiable(ItemData data)
		{
			this.mGUID = data.GUID;
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.mItemParent);
			}
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(this.mGUID);
			if (item != null)
			{
				ComItem comItem = this.comItem;
				ItemData item2 = item;
				if (BlackMarketMerchantTradeItem.<>f__mg$cache0 == null)
				{
					BlackMarketMerchantTradeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item2, BlackMarketMerchantTradeItem.<>f__mg$cache0);
				this.mName.text = item.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x0601080C RID: 67596 RVA: 0x004A57BA File Offset: 0x004A3BBA
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.mCheckMark.CustomActive(bSelected);
		}

		// Token: 0x0601080D RID: 67597 RVA: 0x004A57C8 File Offset: 0x004A3BC8
		private void OnDestroy()
		{
			this.mGUID = 0UL;
			this.comItem = null;
		}

		// Token: 0x0400A7C5 RID: 42949
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400A7C6 RID: 42950
		[SerializeField]
		private Text mName;

		// Token: 0x0400A7C7 RID: 42951
		[SerializeField]
		private GameObject mCheckMark;

		// Token: 0x0400A7C8 RID: 42952
		private ulong mGUID;

		// Token: 0x0400A7C9 RID: 42953
		private ComItem comItem;

		// Token: 0x0400A7CA RID: 42954
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
