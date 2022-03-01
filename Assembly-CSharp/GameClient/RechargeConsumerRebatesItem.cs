using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001904 RID: 6404
	public class RechargeConsumerRebatesItem : ActivityItemBase
	{
		// Token: 0x0600F983 RID: 63875 RVA: 0x0044278C File Offset: 0x00440B8C
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
			this.UpdateTaskDesc(data);
		}

		// Token: 0x0600F984 RID: 63876 RVA: 0x00442838 File Offset: 0x00440C38
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			this.mTaskData = data;
			if (this.mTaskData == null)
			{
				return;
			}
			if (this.mTaskData.AwardDataList != null)
			{
				for (int i = 0; i < this.mTaskData.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.mTaskData.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)this.mTaskData.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (RechargeConsumerRebatesItem.<>f__mg$cache0 == null)
						{
							RechargeConsumerRebatesItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, RechargeConsumerRebatesItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (this.mTaskData.AwardDataList.Count > this.mScrollCount);
			}
			this.UpdateTaskDesc(this.mTaskData);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this.OnReceiveBtnClick));
		}

		// Token: 0x0600F985 RID: 63877 RVA: 0x0044296D File Offset: 0x00440D6D
		private void OnReceiveBtnClick()
		{
			this._OnItemClick();
		}

		// Token: 0x0600F986 RID: 63878 RVA: 0x00442978 File Offset: 0x00440D78
		private void UpdateTaskDesc(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				string arg = string.Empty;
				string arg2 = string.Empty;
				if (data.Desc != string.Empty)
				{
					string[] array = data.Desc.Split(new char[]
					{
						'，'
					});
					if (array.Length >= 2)
					{
						arg = array[0];
						arg2 = array[1];
					}
				}
				int num = 0;
				int num2 = 0;
				if (data.ParamNums2 != null && data.ParamNums2.Count >= 2)
				{
					num = (int)data.ParamNums2[0];
					num2 = (int)data.ParamNums2[1];
				}
				int num3 = 0;
				int num4 = 0;
				if (data.ParamProgressList != null)
				{
					for (int i = 0; i < data.ParamProgressList.Count; i++)
					{
						OpActTaskParam opActTaskParam = data.ParamProgressList[i];
						if (opActTaskParam != null)
						{
							if (opActTaskParam.key == "chargeNum")
							{
								num3 = (int)opActTaskParam.value;
							}
							else if (opActTaskParam.key == "consumeNum")
							{
								num4 = (int)opActTaskParam.value;
							}
						}
					}
				}
				if (num4 >= num2)
				{
					num4 = num2;
				}
				if (this.mFirstConditionDesc != null)
				{
					this.mFirstConditionDesc.text = string.Format(this.sDesc, arg, num3 / num, num / num);
				}
				if (this.mSecondConditionDesc != null)
				{
					this.mSecondConditionDesc.text = string.Format(this.sDesc, arg2, num4, num2);
				}
			}
		}

		// Token: 0x0600F987 RID: 63879 RVA: 0x00442B20 File Offset: 0x00440F20
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

		// Token: 0x04009B5E RID: 39774
		[SerializeField]
		private Text mFirstConditionDesc;

		// Token: 0x04009B5F RID: 39775
		[SerializeField]
		private Text mSecondConditionDesc;

		// Token: 0x04009B60 RID: 39776
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009B61 RID: 39777
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009B62 RID: 39778
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009B63 RID: 39779
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009B64 RID: 39780
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009B65 RID: 39781
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009B66 RID: 39782
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B67 RID: 39783
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009B68 RID: 39784
		[SerializeField]
		private string sDesc = "{0}({1}/{2})";

		// Token: 0x04009B69 RID: 39785
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B6A RID: 39786
		private ILimitTimeActivityTaskDataModel mTaskData;

		// Token: 0x04009B6B RID: 39787
		private bool mIsLeftMinus0;

		// Token: 0x04009B6C RID: 39788
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
