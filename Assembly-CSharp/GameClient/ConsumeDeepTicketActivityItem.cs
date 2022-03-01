using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E2 RID: 6370
	public class ConsumeDeepTicketActivityItem : ActivityItemBase
	{
		// Token: 0x0600F8A6 RID: 63654 RVA: 0x0043ABD4 File Offset: 0x00438FD4
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

		// Token: 0x0600F8A7 RID: 63655 RVA: 0x0043AC78 File Offset: 0x00439078
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
			this.mButtonGoActivity.onClick.RemoveAllListeners();
		}

		// Token: 0x0600F8A8 RID: 63656 RVA: 0x0043ACF8 File Offset: 0x004390F8
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
						if (ConsumeDeepTicketActivityItem.<>f__mg$cache0 == null)
						{
							ConsumeDeepTicketActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ConsumeDeepTicketActivityItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonGoActivity.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeMapFrame>(FrameLayer.Middle, null, string.Empty);
			});
			if (this.mTaskSlider != null)
			{
				this.mTaskSlider.value = data.DoneNum * 1f / data.TotalNum;
			}
			if (this.mTaskCount != null)
			{
				this.mTaskCount.text = string.Format("{0}/{1}", data.DoneNum, data.TotalNum);
			}
			if (data.ParamNums.Count > 0 && data.ParamNums2.Count > 0)
			{
				if (data.ParamNums[0] == 0U && data.ParamNums2[0] == 0U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_role_day_not_update_tips");
				}
				if (data.ParamNums[0] == 0U && data.ParamNums2[0] == 1U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_role_day_update_tips");
				}
				if (data.ParamNums[0] == 1U && data.ParamNums2[0] == 0U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_account_day_not_update_tips");
				}
				if (data.ParamNums[0] == 1U && data.ParamNums2[0] == 1U)
				{
					this.mTextExchangeCount.text = TR.Value("activity_account_day_update_tips");
				}
			}
		}

		// Token: 0x04009A00 RID: 39424
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009A01 RID: 39425
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04009A02 RID: 39426
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009A03 RID: 39427
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009A04 RID: 39428
		[SerializeField]
		private Button mButtonGoActivity;

		// Token: 0x04009A05 RID: 39429
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009A06 RID: 39430
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009A07 RID: 39431
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009A08 RID: 39432
		[SerializeField]
		private Slider mTaskSlider;

		// Token: 0x04009A09 RID: 39433
		[SerializeField]
		private Text mTaskCount;

		// Token: 0x04009A0A RID: 39434
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009A0B RID: 39435
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009A0C RID: 39436
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009A0D RID: 39437
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009A0E RID: 39438
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
