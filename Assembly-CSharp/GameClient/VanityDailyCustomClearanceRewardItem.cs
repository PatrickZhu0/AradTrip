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
	// Token: 0x02001922 RID: 6434
	public class VanityDailyCustomClearanceRewardItem : ActivityItemBase
	{
		// Token: 0x0600FA71 RID: 64113 RVA: 0x004496A8 File Offset: 0x00447AA8
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				Logger.LogError("data is null");
				return;
			}
			this.mData = data;
			this.mTextDescription.text = data.Desc;
			if (this.mButtonTakeReward == null)
			{
				Logger.LogError("按钮为空了，检查预制体DailyRewardItem");
			}
			this.UpdateData(data);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonGo.SafeAddOnClickListener(new UnityAction(this.OnGoBtnClick));
			this.InitItems(data.AwardDataList);
		}

		// Token: 0x0600FA72 RID: 64114 RVA: 0x0044973C File Offset: 0x00447B3C
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data.State == OpActTaskState.OATS_FINISHED)
			{
				this.mButtonTakeReward.gameObject.CustomActive(true);
				this.mHasTakenReward.CustomActive(false);
				this.mButtonGo.CustomActive(false);
			}
			else if (data.State == OpActTaskState.OATS_OVER)
			{
				this.mButtonTakeReward.gameObject.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
				this.mButtonGo.CustomActive(false);
			}
			else
			{
				this.mButtonTakeReward.gameObject.CustomActive(false);
				this.mHasTakenReward.CustomActive(false);
				this.mButtonGo.CustomActive(true);
			}
			if (data.DoneNum <= data.TotalNum)
			{
				this.mTaskCount.text = string.Format("已完成{0}/{1}", data.DoneNum, data.TotalNum);
			}
			else
			{
				this.mTaskCount.text = string.Format("已完成{0}/{1}", data.TotalNum, data.TotalNum);
			}
		}

		// Token: 0x0600FA73 RID: 64115 RVA: 0x00449854 File Offset: 0x00447C54
		public sealed override void Dispose()
		{
			base.Dispose();
			for (int i = this.mComItems.Count - 1; i >= 0; i--)
			{
				ComItemManager.Destroy(this.mComItems[i]);
			}
			this.mComItems.Clear();
			if (this.mButtonTakeReward != null)
			{
				this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			}
			if (this.mButtonGo != null)
			{
				this.mButtonGo.SafeRemoveOnClickListener(new UnityAction(this.OnGoBtnClick));
			}
		}

		// Token: 0x0600FA74 RID: 64116 RVA: 0x004498F4 File Offset: 0x00447CF4
		private void InitItems(List<OpTaskReward> awards)
		{
			if (awards == null || awards.Count == 0)
			{
				return;
			}
			for (int i = 0; i < awards.Count; i++)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)awards[i].id, 100, 0);
					itemData.Count = (int)awards[i].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (VanityDailyCustomClearanceRewardItem.<>f__mg$cache0 == null)
					{
						VanityDailyCustomClearanceRewardItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, VanityDailyCustomClearanceRewardItem.<>f__mg$cache0);
					this.mComItems.Add(comItem);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
				}
			}
		}

		// Token: 0x0600FA75 RID: 64117 RVA: 0x004499B4 File Offset: 0x00447DB4
		private void OnGoBtnClick()
		{
			if (this.mData != null)
			{
				for (int i = 0; i < this.mData.ParamNums.Count; i++)
				{
					if (this.mData.ParamNums[i] == 17U)
					{
						Utility.PathfindingYiJieMap();
						return;
					}
					if (this.mData.ParamNums[i] == 20U || this.mData.ParamNums[i] == 22U || this.mData.ParamNums[i] == 23U)
					{
						ChallengeUtility.OnOpenChallengeMapFrame(DungeonModelTable.eType.WeekHellModel, 0, 0);
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
						}
						return;
					}
					if (this.mData.ParamNums[i] == 19U)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<FallAbyssFrame>(FrameLayer.Middle, null, string.Empty);
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
						{
							Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
						}
						return;
					}
				}
			}
		}

		// Token: 0x04009C6C RID: 40044
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009C6D RID: 40045
		[SerializeField]
		private Image mImageBg;

		// Token: 0x04009C6E RID: 40046
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009C6F RID: 40047
		[SerializeField]
		private Vector2 mComItemSize;

		// Token: 0x04009C70 RID: 40048
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009C71 RID: 40049
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009C72 RID: 40050
		[SerializeField]
		private Button mButtonGo;

		// Token: 0x04009C73 RID: 40051
		[SerializeField]
		private Text mTaskCount;

		// Token: 0x04009C74 RID: 40052
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009C75 RID: 40053
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009C76 RID: 40054
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
