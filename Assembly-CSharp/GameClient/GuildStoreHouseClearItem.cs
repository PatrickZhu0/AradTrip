using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200165C RID: 5724
	internal class GuildStoreHouseClearItem : CachedNormalObject<GuildStoreHouseClearItemData>
	{
		// Token: 0x0600E138 RID: 57656 RVA: 0x0039B5F8 File Offset: 0x003999F8
		public override void Initialize()
		{
			this.comGuildItem = this.goLocal.GetComponent<ComGuildItem>();
			if (null != this.comGuildItem)
			{
				this.comGuildItem.InitComGuildItem(delegate(GameObject obj, ItemData item)
				{
					if (item != null)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
					}
				}, true, base.Value.bClear);
			}
		}

		// Token: 0x0600E139 RID: 57657 RVA: 0x0039B65B File Offset: 0x00399A5B
		public override void UnInitialize()
		{
			this.comGuildItem = null;
		}

		// Token: 0x0600E13A RID: 57658 RVA: 0x0039B664 File Offset: 0x00399A64
		public override void OnUpdate()
		{
			if (null != this.comGuildItem)
			{
				this.comGuildItem.SetItemData(base.Value.itemData);
			}
		}

		// Token: 0x04008601 RID: 34305
		private ComGuildItem comGuildItem;
	}
}
