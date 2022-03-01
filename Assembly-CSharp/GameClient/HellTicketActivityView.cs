using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001897 RID: 6295
	public class HellTicketActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x17001CFB RID: 7419
		// (set) Token: 0x0600F63D RID: 63037 RVA: 0x00427791 File Offset: 0x00425B91
		public UnityAction OnLotteryClick
		{
			set
			{
				this.mButtonLottery.SafeRemoveAllListener();
				this.mButtonLottery.SafeAddOnClickListener(value);
			}
		}

		// Token: 0x17001CFC RID: 7420
		// (set) Token: 0x0600F63E RID: 63038 RVA: 0x004277AA File Offset: 0x00425BAA
		public UnityAction OnPreviewAwardsClick
		{
			set
			{
				this.mButtonPreviewAwards.SafeRemoveAllListener();
				this.mButtonPreviewAwards.SafeAddOnClickListener(value);
			}
		}

		// Token: 0x0600F63F RID: 63039 RVA: 0x004277C3 File Offset: 0x00425BC3
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			this.mTextLotteryCount.SafeSetText(string.Format(TR.Value("activity_hell_ticket_lottery_count"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME)));
		}

		// Token: 0x0600F640 RID: 63040 RVA: 0x004277FB File Offset: 0x00425BFB
		public void UpdateLotteryCount()
		{
			this.mTextLotteryCount.SafeSetText(string.Format(TR.Value("activity_hell_ticket_lottery_count"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME)));
		}

		// Token: 0x04009713 RID: 38675
		[SerializeField]
		private Text mTextLotteryCount;

		// Token: 0x04009714 RID: 38676
		[SerializeField]
		private Button mButtonLottery;

		// Token: 0x04009715 RID: 38677
		[SerializeField]
		private Button mButtonPreviewAwards;
	}
}
