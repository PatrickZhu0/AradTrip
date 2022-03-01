using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001727 RID: 5927
	internal class FashionLimitTimeItemManager : MonoSingleton<FashionLimitTimeItemManager>
	{
		// Token: 0x0600E8C5 RID: 59589 RVA: 0x003D95E4 File Offset: 0x003D79E4
		public void Initialize(GameObject parent)
		{
			Utility.AttachTo(base.gameObject, parent, false);
			this.fashionItemPool = new ActivityLTObjectPool<FashionLimitTimeItem>(0, parent, "UIFlatten/Prefabs/LimitTimeGift/FashionLimitTimebuyItem");
		}

		// Token: 0x0600E8C6 RID: 59590 RVA: 0x003D9605 File Offset: 0x003D7A05
		public void UnInitialize()
		{
			this.ReleaseAllFashionItems();
			this.fashionItemPool = null;
		}

		// Token: 0x0600E8C7 RID: 59591 RVA: 0x003D9614 File Offset: 0x003D7A14
		public GameObject GetFashionItem()
		{
			if (this.fashionItemPool == null)
			{
				return null;
			}
			return this.fashionItemPool.GetGameObject();
		}

		// Token: 0x0600E8C8 RID: 59592 RVA: 0x003D962E File Offset: 0x003D7A2E
		public void ReleaseFashionItem(GameObject item)
		{
			if (this.fashionItemPool != null && item != null)
			{
				this.fashionItemPool.ReleaseGameObject(item);
			}
		}

		// Token: 0x0600E8C9 RID: 59593 RVA: 0x003D9653 File Offset: 0x003D7A53
		public void ReleaseAllFashionItems()
		{
			if (this.fashionItemPool != null)
			{
				this.fashionItemPool.ReleasePool();
			}
		}

		// Token: 0x04008D29 RID: 36137
		public const string FashionLimitTimeItem = "UIFlatten/Prefabs/LimitTimeGift/FashionLimitTimebuyItem";

		// Token: 0x04008D2A RID: 36138
		private ActivityLTObjectPool<FashionLimitTimeItem> fashionItemPool;
	}
}
