using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E7 RID: 6375
	public class DailyLoginItem : ActivityItemBase
	{
		// Token: 0x0600F8D0 RID: 63696 RVA: 0x0043C804 File Offset: 0x0043AC04
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					this.mUnTakeReward.CustomActive(true);
					this.mHasTakenReward.CustomActive(false);
					this.mCanTakeReward.CustomActive(false);
				}
				else
				{
					this.mUnTakeReward.CustomActive(false);
					this.mHasTakenReward.CustomActive(false);
					this.mCanTakeReward.CustomActive(true);
				}
			}
			else
			{
				this.mCanTakeReward.CustomActive(false);
				this.mUnTakeReward.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
		}

		// Token: 0x0600F8D1 RID: 63697 RVA: 0x0043C8A8 File Offset: 0x0043ACA8
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
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F8D2 RID: 63698 RVA: 0x0043C918 File Offset: 0x0043AD18
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList != null)
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
						if (DailyLoginItem.<>f__mg$cache0 == null)
						{
							DailyLoginItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, DailyLoginItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x04009A45 RID: 39493
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A46 RID: 39494
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009A47 RID: 39495
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009A48 RID: 39496
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009A49 RID: 39497
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009A4A RID: 39498
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009A4B RID: 39499
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009A4C RID: 39500
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009A4D RID: 39501
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009A4E RID: 39502
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009A4F RID: 39503
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
