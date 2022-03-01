using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E3 RID: 6371
	public class ConsumePointActivityItem : ActivityItemBase
	{
		// Token: 0x0600F8AB RID: 63659 RVA: 0x0043AFE8 File Offset: 0x004393E8
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
			this.mTaskSlider.value = data.DoneNum * 1f / data.TotalNum;
			if (data.DoneNum < data.TotalNum)
			{
				this.mTaskCount.text = string.Format("{0}/{1}", data.DoneNum, data.TotalNum);
			}
			else
			{
				this.mTaskCount.text = string.Format("{0}/{1}", data.TotalNum, data.TotalNum);
			}
		}

		// Token: 0x0600F8AC RID: 63660 RVA: 0x0043B118 File Offset: 0x00439518
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
			this.mButtonGoActivity.SafeRemoveAllListener();
		}

		// Token: 0x0600F8AD RID: 63661 RVA: 0x0043B194 File Offset: 0x00439594
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
						if (ConsumePointActivityItem.<>f__mg$cache0 == null)
						{
							ConsumePointActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ConsumePointActivityItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonGoActivity.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
			});
			if (data.ParamNums.Count > 0)
			{
				if (data.ParamNums[0] == 0U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_role_tips");
				}
				if (data.ParamNums[0] == 1U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_account_tips");
				}
			}
		}

		// Token: 0x04009A10 RID: 39440
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A11 RID: 39441
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04009A12 RID: 39442
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009A13 RID: 39443
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009A14 RID: 39444
		[SerializeField]
		private Button mButtonGoActivity;

		// Token: 0x04009A15 RID: 39445
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009A16 RID: 39446
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009A17 RID: 39447
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009A18 RID: 39448
		[SerializeField]
		private Slider mTaskSlider;

		// Token: 0x04009A19 RID: 39449
		[SerializeField]
		private Text mTaskCount;

		// Token: 0x04009A1A RID: 39450
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009A1B RID: 39451
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009A1C RID: 39452
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009A1D RID: 39453
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009A1E RID: 39454
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
