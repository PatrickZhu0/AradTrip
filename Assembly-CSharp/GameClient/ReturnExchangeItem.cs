using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001906 RID: 6406
	public class ReturnExchangeItem : ActivityItemBase
	{
		// Token: 0x0600F98D RID: 63885 RVA: 0x00442F24 File Offset: 0x00441324
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
			if (data.ParamNums2.Count > 0)
			{
				if (data.ParamNums2[0] == 0U)
				{
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_exchange_count_role"), data.DoneNum, data.TotalNum));
				}
				else
				{
					this.mTextExchangeCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_item_exchange_count_account"), data.DoneNum, data.TotalNum));
				}
			}
			ulong accountSpecialItemNum = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_ENERGY_COIN);
			List<uint> paramNums = data.ParamNums;
			if (paramNums.Count == 0)
			{
				return;
			}
			this.mTextCoinCount.SafeSetText(string.Format("/{0}", paramNums[0]));
			this.mTextCoinOwnNum.SafeSetText(accountSpecialItemNum.ToString());
			if (accountSpecialItemNum < (ulong)paramNums[0])
			{
				this.mTextCoinOwnNum.color = Color.red;
			}
			else
			{
				this.mTextCoinOwnNum.color = Color.green;
			}
		}

		// Token: 0x0600F98E RID: 63886 RVA: 0x004430E0 File Offset: 0x004414E0
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
			this.mButtonExchangeBlue.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F98F RID: 63887 RVA: 0x00443168 File Offset: 0x00441568
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
						if (ReturnExchangeItem.<>f__mg$cache0 == null)
						{
							ReturnExchangeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ReturnExchangeItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mButtonExchange.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonExchangeBlue.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x04009B7A RID: 39802
		[SerializeField]
		private Text mTextExchangeCount;

		// Token: 0x04009B7B RID: 39803
		[SerializeField]
		private Image mImageCoinIcon;

		// Token: 0x04009B7C RID: 39804
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x04009B7D RID: 39805
		[SerializeField]
		private Text mTextCoinOwnNum;

		// Token: 0x04009B7E RID: 39806
		[SerializeField]
		private Button mButtonExchange;

		// Token: 0x04009B7F RID: 39807
		[SerializeField]
		private Button mButtonExchangeBlue;

		// Token: 0x04009B80 RID: 39808
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009B81 RID: 39809
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009B82 RID: 39810
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009B83 RID: 39811
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x04009B84 RID: 39812
		[SerializeField]
		private GameObject mFinishedGO;

		// Token: 0x04009B85 RID: 39813
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B86 RID: 39814
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009B87 RID: 39815
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B88 RID: 39816
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
