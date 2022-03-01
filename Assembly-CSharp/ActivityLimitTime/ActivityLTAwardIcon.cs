using System;
using GameClient;
using UnityEngine;

namespace ActivityLimitTime
{
	// Token: 0x020018CB RID: 6347
	public class ActivityLTAwardIcon : ActivityLTObject<ActivityLTAwardIcon>
	{
		// Token: 0x0600F7FF RID: 63487 RVA: 0x0043525E File Offset: 0x0043365E
		public void Init(GameObject parent, ActivityLimitTimeFrame currFrame, ActivityLimitTimeAward currAwardData)
		{
			this.Create();
			this.goParent = parent;
			this.currFrame = currFrame;
			Utility.AttachTo(this.goSelf, this.goParent, false);
			this.SetDataToView(currAwardData);
		}

		// Token: 0x0600F800 RID: 63488 RVA: 0x00435290 File Offset: 0x00433690
		public void SetDataToView(ActivityLimitTimeAward currAwardData)
		{
			if (this.currFrame != null && currAwardData != null)
			{
				if (this.currAwardItem == null)
				{
					this.currAwardItem = this.currFrame.CreateComItem(this.goSelf);
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)currAwardData.Id, 100, 0);
				if (itemData == null)
				{
					return;
				}
				itemData.Count = currAwardData.Num;
				itemData.StrengthenLevel = (int)currAwardData.Strenth;
				this.currAwardItem.Setup(itemData, delegate(GameObject go, ItemData itemPa)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(itemPa, null, 4, true, false, true);
				});
			}
		}

		// Token: 0x0600F801 RID: 63489 RVA: 0x0043532D File Offset: 0x0043372D
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<ActivityItemObjectManager>.instance.GetActAwardGo();
		}

		// Token: 0x0600F802 RID: 63490 RVA: 0x00435345 File Offset: 0x00433745
		public override void Destory()
		{
			base.Destory();
			MonoSingleton<ActivityItemObjectManager>.instance.ReleaseActAwardGo(this.goSelf);
			if (this.currAwardItem != null)
			{
				Object.Destroy(this.currAwardItem.gameObject);
			}
			this.Reset();
		}

		// Token: 0x0600F803 RID: 63491 RVA: 0x00435384 File Offset: 0x00433784
		public void Reset()
		{
			this.goSelf = null;
			this.goParent = null;
			this.currFrame = null;
			this.currAwardData = null;
		}

		// Token: 0x04009925 RID: 39205
		protected GameObject goParent;

		// Token: 0x04009926 RID: 39206
		protected ActivityLimitTimeFrame currFrame;

		// Token: 0x04009927 RID: 39207
		private ActivityLimitTimeAward currAwardData;

		// Token: 0x04009928 RID: 39208
		private ComItem currAwardItem;
	}
}
