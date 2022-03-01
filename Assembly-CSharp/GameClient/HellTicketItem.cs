using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F7 RID: 6391
	public class HellTicketItem : ActivityItemBase
	{
		// Token: 0x0600F921 RID: 63777 RVA: 0x0043F144 File Offset: 0x0043D544
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				this.mNotFinishGO.CustomActive(true);
				this.mHasTakenReward.CustomActive(false);
			}
			else
			{
				this.mNotFinishGO.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mTextProgress.SafeSetText(string.Format("{0}/{1}", data.DoneNum, data.TotalNum));
		}

		// Token: 0x0600F922 RID: 63778 RVA: 0x0043F1DC File Offset: 0x0043D5DC
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
		}

		// Token: 0x0600F923 RID: 63779 RVA: 0x0043F234 File Offset: 0x0043D634
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null && data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (HellTicketItem.<>f__mg$cache0 == null)
						{
							HellTicketItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, HellTicketItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
		}

		// Token: 0x04009ACF RID: 39631
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009AD0 RID: 39632
		[SerializeField]
		private Text mTextProgress;

		// Token: 0x04009AD1 RID: 39633
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009AD2 RID: 39634
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009AD3 RID: 39635
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009AD4 RID: 39636
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x04009AD5 RID: 39637
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009AD6 RID: 39638
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009AD7 RID: 39639
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009AD8 RID: 39640
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
