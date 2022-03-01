using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018DE RID: 6366
	public class CoinExchangeItem : ActivityItemBase
	{
		// Token: 0x0600F88A RID: 63626 RVA: 0x00439D30 File Offset: 0x00438130
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					if (state == OpActTaskState.OATS_UNFINISH)
					{
						this.mFinishedGO.CustomActive(false);
						this.mNotFinishGO.CustomActive(true);
						this.mHasTakenReward.CustomActive(false);
					}
				}
				else
				{
					this.mFinishedGO.CustomActive(true);
					this.mNotFinishGO.CustomActive(false);
					this.mHasTakenReward.CustomActive(false);
				}
			}
			else
			{
				this.mNotFinishGO.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
				this.mFinishedGO.CustomActive(false);
			}
			if (data.State == OpActTaskState.OATS_OVER)
			{
				if (data.AccountDailySubmitLimit == 0 && data.AccountTotalSubmitLimit == 0)
				{
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_count_role"), 0, data.TotalNum));
				}
			}
			else if (data.AccountDailySubmitLimit == 0 && data.AccountTotalSubmitLimit == 0)
			{
				this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_count_role"), data.DoneNum, data.TotalNum));
			}
			int count = DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", this.mActivityId, CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM));
			List<uint> paramNums = data.ParamNums;
			if (paramNums.Count == 0)
			{
				return;
			}
			this.mTextCoinCount.SafeSetText(string.Format("/{0}", paramNums[0]));
			this.mTextCoinOwnNum.SafeSetText(count.ToString());
			if ((long)count < (long)((ulong)paramNums[0]))
			{
				this.mTextCoinOwnNum.color = Color.red;
			}
			else
			{
				this.mTextCoinOwnNum.color = Color.green;
			}
		}

		// Token: 0x0600F88B RID: 63627 RVA: 0x00439F18 File Offset: 0x00438318
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
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchange.SafeRemoveOnClickListener(new UnityAction(this._OnSendMsg));
			this.mButtonExchangeBlue.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F88C RID: 63628 RVA: 0x00439FB8 File Offset: 0x004383B8
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
						if (CoinExchangeItem.<>f__mg$cache0 == null)
						{
							CoinExchangeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, CoinExchangeItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mData = data;
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchangeBlue.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnSendMsg));
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			base.OnRequsetAccountData(data);
		}

		// Token: 0x0600F88D RID: 63629 RVA: 0x0043A10B File Offset: 0x0043850B
		private void _OnSendMsg()
		{
			if (this.mData != null)
			{
				base.OnRequsetAccountData(this.mData);
			}
		}

		// Token: 0x0600F88E RID: 63630 RVA: 0x0043A124 File Offset: 0x00438524
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				int accountDailySubmitLimit = this.mData.AccountDailySubmitLimit;
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				int num2 = 0;
				if (accountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = accountDailySubmitLimit;
				}
				if (accountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int num3 = num - num2;
					if (num3 <= 0)
					{
						num3 = 0;
					}
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_count_account"), num3, num));
				}
			}
		}

		// Token: 0x040099CF RID: 39375
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x040099D0 RID: 39376
		[SerializeField]
		private Image mImageCoinIcon;

		// Token: 0x040099D1 RID: 39377
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x040099D2 RID: 39378
		[SerializeField]
		private Text mTextCoinOwnNum;

		// Token: 0x040099D3 RID: 39379
		[SerializeField]
		private Button mButtonExchange;

		// Token: 0x040099D4 RID: 39380
		[SerializeField]
		private Button mButtonExchangeBlue;

		// Token: 0x040099D5 RID: 39381
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x040099D6 RID: 39382
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x040099D7 RID: 39383
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x040099D8 RID: 39384
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x040099D9 RID: 39385
		[SerializeField]
		private GameObject mFinishedGO;

		// Token: 0x040099DA RID: 39386
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x040099DB RID: 39387
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x040099DC RID: 39388
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x040099DD RID: 39389
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x040099DE RID: 39390
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
