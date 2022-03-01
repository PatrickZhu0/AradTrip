using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018EC RID: 6380
	public class DungeionDropItem : ActivityItemBase
	{
		// Token: 0x0600F8EA RID: 63722 RVA: 0x0043D290 File Offset: 0x0043B690
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				this.mTextDesc.SafeSetText(data.Desc);
				this._InitAwards(data.AwardDataList);
			}
			this.mButtonChallenge.SafeRemoveAllListener();
			this.mButtonChallenge.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F8EB RID: 63723 RVA: 0x0043D2E4 File Offset: 0x0043B6E4
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				this.mTextDesc.SafeSetText(data.Desc);
				int id = (int)data.ParamNums[0];
				AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				this.mTextTitle.SafeSetText(tableItem.Name);
			}
		}

		// Token: 0x0600F8EC RID: 63724 RVA: 0x0043D343 File Offset: 0x0043B743
		public override void Dispose()
		{
			base.Dispose();
			this.mReviewList.Clear();
			this.mButtonChallenge.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
		}

		// Token: 0x0600F8ED RID: 63725 RVA: 0x0043D370 File Offset: 0x0043B770
		private void _InitAwards(List<OpTaskReward> awardDataList)
		{
			if (awardDataList == null)
			{
				return;
			}
			this.mReviewList.Clear();
			for (int i = 0; i < awardDataList.Count; i++)
			{
				this.mReviewList.Add((int)awardDataList[i].id);
			}
			if (this.mReviewDrop != null)
			{
				this.mReviewDrop.SetDropList(this.mReviewList, 0);
			}
		}

		// Token: 0x04009A66 RID: 39526
		[SerializeField]
		private Text mTextDesc;

		// Token: 0x04009A67 RID: 39527
		[SerializeField]
		private Text mTextTitle;

		// Token: 0x04009A68 RID: 39528
		[SerializeField]
		private Button mButtonChallenge;

		// Token: 0x04009A69 RID: 39529
		[SerializeField]
		private ComChapterInfoDrop mReviewDrop;

		// Token: 0x04009A6A RID: 39530
		private List<int> mReviewList = new List<int>();
	}
}
