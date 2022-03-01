using System;
using System.Collections.Generic;
using GameClient;
using UnityEngine;

namespace LimitTimeGift
{
	// Token: 0x0200172D RID: 5933
	public class LimitTimeGiftMallItemManager : MonoSingleton<LimitTimeGiftMallItemManager>
	{
		// Token: 0x0600E902 RID: 59650 RVA: 0x003DAD46 File Offset: 0x003D9146
		public void Initialize(GameObject parentGo)
		{
			base.gameObject.name = "LimitTimeGiftItems";
			this.InitPrefabPool(parentGo);
			this.InitMallGiftItemList();
		}

		// Token: 0x0600E903 RID: 59651 RVA: 0x003DAD65 File Offset: 0x003D9165
		public void UnInitialize()
		{
			this.UnInitMallGiftItemList();
			this.ReleasePrefabPool();
		}

		// Token: 0x0600E904 RID: 59652 RVA: 0x003DAD73 File Offset: 0x003D9173
		public GameObject GetMallGiftGo()
		{
			return this.mallGiftPool.GetGameObject();
		}

		// Token: 0x0600E905 RID: 59653 RVA: 0x003DAD80 File Offset: 0x003D9180
		public void ReleaseMallGiftGo(GameObject go)
		{
			this.mallGiftPool.ReleaseGameObject(go);
		}

		// Token: 0x0600E906 RID: 59654 RVA: 0x003DAD8E File Offset: 0x003D918E
		private void InitPrefabPool(GameObject parentGo)
		{
			Utility.AttachTo(base.gameObject, parentGo, false);
			this.InitMallGiftPool(0, "UIFlatten/Prefabs/LimitTimeGift/LimitTimeGiftMallItem");
		}

		// Token: 0x0600E907 RID: 59655 RVA: 0x003DADA9 File Offset: 0x003D91A9
		private void ReleasePrefabPool()
		{
			if (this.mallGiftPool != null)
			{
				this.mallGiftPool.ReleasePool();
			}
		}

		// Token: 0x0600E908 RID: 59656 RVA: 0x003DADC1 File Offset: 0x003D91C1
		private void InitMallGiftPool(int initNum, string prefabPath)
		{
			this.mallGiftPool = new ActivityLTObjectPool<LimitTimeGiftInMall>(initNum, base.gameObject, prefabPath);
		}

		// Token: 0x0600E909 RID: 59657 RVA: 0x003DADD6 File Offset: 0x003D91D6
		private void InitMallGiftItemList()
		{
			this.mallGiftItemList = new List<LimitTimeGiftInMall>();
			this.mallGiftItemDic = new Dictionary<uint, LimitTimeGiftInMall>();
		}

		// Token: 0x0600E90A RID: 59658 RVA: 0x003DADEE File Offset: 0x003D91EE
		private void UnInitMallGiftItemList()
		{
			this.ClearMallGiftItemList();
			this.mallGiftItemList = null;
			this.mallGiftItemDic = null;
		}

		// Token: 0x0600E90B RID: 59659 RVA: 0x003DAE04 File Offset: 0x003D9204
		public List<LimitTimeGiftInMall> GetCurrMallGiftItems()
		{
			return this.mallGiftItemList;
		}

		// Token: 0x0600E90C RID: 59660 RVA: 0x003DAE0C File Offset: 0x003D920C
		public Dictionary<uint, LimitTimeGiftInMall> GetCurrMallGiftItemDicWithId()
		{
			if (this.mallGiftItemList == null)
			{
				return this.mallGiftItemDic;
			}
			if (this.mallGiftItemDic == null)
			{
				return null;
			}
			this.mallGiftItemDic.Clear();
			for (int i = 0; i < this.mallGiftItemList.Count; i++)
			{
				LimitTimeGiftInMall limitTimeGiftInMall = this.mallGiftItemList[i];
				if (limitTimeGiftInMall != null && limitTimeGiftInMall.GetCurrItemData() != null)
				{
					uint giftId = limitTimeGiftInMall.GetCurrItemData().GiftId;
					if (this.mallGiftItemDic.ContainsKey(giftId))
					{
						this.mallGiftItemDic[giftId] = limitTimeGiftInMall;
					}
					else
					{
						this.mallGiftItemDic.Add(giftId, limitTimeGiftInMall);
					}
				}
			}
			return this.mallGiftItemDic;
		}

		// Token: 0x0600E90D RID: 59661 RVA: 0x003DAEC4 File Offset: 0x003D92C4
		public void ClearMallGiftItemList()
		{
			if (this.mallGiftItemList != null)
			{
				for (int i = 0; i < this.mallGiftItemList.Count; i++)
				{
					this.mallGiftItemList[i].Destory();
				}
				this.mallGiftItemList.Clear();
			}
		}

		// Token: 0x0600E90E RID: 59662 RVA: 0x003DAF14 File Offset: 0x003D9314
		public void AddMallGiftItem(LimitTimeGiftInMall mallGiftItem)
		{
			if (this.mallGiftItemList != null)
			{
				this.mallGiftItemList.Add(mallGiftItem);
			}
		}

		// Token: 0x0600E90F RID: 59663 RVA: 0x003DAF2D File Offset: 0x003D932D
		public void RemoveMallGiftItem(LimitTimeGiftInMall mallGiftItem)
		{
			if (this.mallGiftItemList != null && mallGiftItem != null && this.mallGiftItemList.Contains(mallGiftItem))
			{
				this.mallGiftItemList.Remove(mallGiftItem);
			}
		}

		// Token: 0x04008D56 RID: 36182
		private const string GiftInMallPath = "UIFlatten/Prefabs/LimitTimeGift/LimitTimeGiftMallItem";

		// Token: 0x04008D57 RID: 36183
		private ActivityLTObjectPool<LimitTimeGiftInMall> mallGiftPool;

		// Token: 0x04008D58 RID: 36184
		private List<LimitTimeGiftInMall> mallGiftItemList;

		// Token: 0x04008D59 RID: 36185
		private Dictionary<uint, LimitTimeGiftInMall> mallGiftItemDic;
	}
}
