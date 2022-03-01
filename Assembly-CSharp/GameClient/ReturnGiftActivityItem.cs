using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001907 RID: 6407
	public class ReturnGiftActivityItem : ActivityItemBase
	{
		// Token: 0x0600F991 RID: 63889 RVA: 0x004432B4 File Offset: 0x004416B4
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			OpActTaskState state = data.State;
			if (state != OpActTaskState.OATS_OVER)
			{
				if (state != OpActTaskState.OATS_FINISHED)
				{
					this.mHasTakenReward.CustomActive(false);
					this.mCanTakeReward.CustomActive(false);
					this.mCanTakeRewardFree.CustomActive(false);
				}
				else
				{
					this.mHasTakenReward.CustomActive(false);
					this.mCanTakeReward.CustomActive(true);
					this.mCanTakeRewardFree.CustomActive(true);
				}
			}
			else
			{
				this.mCanTakeReward.CustomActive(false);
				this.mCanTakeRewardFree.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
			if (data.ParamNums2.Count > 1)
			{
				if (data.ParamNums2[1] == 0U)
				{
					this.mGoldIcon.CustomActive(false);
					this.mGoldNum.CustomActive(false);
					this.mCanTakeRewardFree.CustomActive(true);
					this.mCanTakeReward.CustomActive(false);
				}
				else
				{
					this.mGoldIcon.CustomActive(true);
					this.mGoldNum.CustomActive(true);
					this.mCanTakeRewardFree.CustomActive(false);
					this.mCanTakeReward.CustomActive(true);
				}
			}
			if (data.ParamNums[0] == 1U)
			{
				this.mBuyDes.text = string.Format(TR.Value("activity_coin_exchange_item_exchange_count_account"), data.DoneNum, data.TotalNum);
			}
			else
			{
				this.mBuyDes.text = string.Format(TR.Value("activity_coin_exchange_item_exchange_count_role"), data.DoneNum, data.TotalNum);
			}
		}

		// Token: 0x0600F992 RID: 63890 RVA: 0x00443454 File Offset: 0x00441854
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
			this.mButtonTakeRewardFree.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F993 RID: 63891 RVA: 0x004434DC File Offset: 0x004418DC
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
						if (ReturnGiftActivityItem.<>f__mg$cache0 == null)
						{
							ReturnGiftActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ReturnGiftActivityItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						comItem.labCount.fontSize = 28;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonTakeRewardFree.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			if (data.ParamNums2.Count > 1)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)data.ParamNums2[0], string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.mGoldIcon, tableItem.Icon, true);
				}
				this.mGoldNum.text = data.ParamNums2[1].ToString();
				if (data.ParamNums2[1] == 0U)
				{
					this.mGoldIcon.CustomActive(false);
					this.mGoldNum.CustomActive(false);
					this.mCanTakeRewardFree.CustomActive(true);
					this.mCanTakeReward.CustomActive(false);
				}
				else
				{
					this.mGoldIcon.CustomActive(true);
					this.mGoldNum.CustomActive(true);
					this.mCanTakeRewardFree.CustomActive(false);
					this.mCanTakeReward.CustomActive(true);
				}
			}
		}

		// Token: 0x04009B89 RID: 39817
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009B8A RID: 39818
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009B8B RID: 39819
		[SerializeField]
		private Button mButtonTakeRewardFree;

		// Token: 0x04009B8C RID: 39820
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009B8D RID: 39821
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009B8E RID: 39822
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009B8F RID: 39823
		[SerializeField]
		private GameObject mCanTakeRewardFree;

		// Token: 0x04009B90 RID: 39824
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009B91 RID: 39825
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009B92 RID: 39826
		[SerializeField]
		private Text mGoldNum;

		// Token: 0x04009B93 RID: 39827
		[SerializeField]
		private Image mGoldIcon;

		// Token: 0x04009B94 RID: 39828
		[SerializeField]
		private Text mBuyDes;

		// Token: 0x04009B95 RID: 39829
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B96 RID: 39830
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009B97 RID: 39831
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B98 RID: 39832
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
