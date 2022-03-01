using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001905 RID: 6405
	public class ReservationUpgradeItem : ActivityItemBase
	{
		// Token: 0x0600F989 RID: 63881 RVA: 0x00442BC0 File Offset: 0x00440FC0
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (DataManager<PlayerBaseData>.GetInstance().appointmentOccu == 1)
			{
				if (data.State == OpActTaskState.OATS_OVER)
				{
					this.mTextProgress.SafeSetText(string.Format("<color=#00FF56FF>{0}</color>/{1}", data.TotalNum, data.TotalNum));
					this.mFinishGO.CustomActive(false);
					this.mNotFinishGO.CustomActive(false);
					this.mCanNotTakeReward.CustomActive(false);
					this.mHasTakenReward.CustomActive(true);
				}
				else if (data.State == OpActTaskState.OATS_FINISHED)
				{
					this.mTextProgress.SafeSetText(string.Format("<color=#00FF56FF>{0}</color>/{1}", data.TotalNum, data.TotalNum));
					this.mNotFinishGO.CustomActive(false);
					this.mHasTakenReward.CustomActive(false);
					this.mCanNotTakeReward.CustomActive(false);
					this.mFinishGO.CustomActive(true);
				}
				else
				{
					this.mTextProgress.SafeSetText(string.Format("<color=#AE0000FF>{0}</color>/{1}", data.DoneNum, data.TotalNum));
					this.mNotFinishGO.CustomActive(true);
					this.mHasTakenReward.CustomActive(false);
					this.mCanNotTakeReward.CustomActive(false);
					this.mFinishGO.CustomActive(false);
				}
			}
			else
			{
				this.mTextProgress.SafeSetText(string.Format("{0}/{1}", data.DoneNum, data.TotalNum));
				this.mNotFinishGO.CustomActive(false);
				this.mHasTakenReward.CustomActive(false);
				this.mCanNotTakeReward.CustomActive(true);
				this.mFinishGO.CustomActive(false);
			}
		}

		// Token: 0x0600F98A RID: 63882 RVA: 0x00442D70 File Offset: 0x00441170
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

		// Token: 0x0600F98B RID: 63883 RVA: 0x00442DE0 File Offset: 0x004411E0
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
						if (ReservationUpgradeItem.<>f__mg$cache0 == null)
						{
							ReservationUpgradeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, ReservationUpgradeItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x04009B6D RID: 39789
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009B6E RID: 39790
		[SerializeField]
		private Text mTextProgress;

		// Token: 0x04009B6F RID: 39791
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009B70 RID: 39792
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009B71 RID: 39793
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009B72 RID: 39794
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009B73 RID: 39795
		[SerializeField]
		private GameObject mNotFinishGO;

		// Token: 0x04009B74 RID: 39796
		[SerializeField]
		private GameObject mFinishGO;

		// Token: 0x04009B75 RID: 39797
		[SerializeField]
		private GameObject mCanNotTakeReward;

		// Token: 0x04009B76 RID: 39798
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009B77 RID: 39799
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009B78 RID: 39800
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B79 RID: 39801
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
