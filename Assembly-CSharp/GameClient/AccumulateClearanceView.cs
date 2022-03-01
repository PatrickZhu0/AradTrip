using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200186D RID: 6253
	public class AccumulateClearanceView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F50C RID: 62732 RVA: 0x00421A0C File Offset: 0x0041FE0C
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.ACT_DUNGEON);
			if (count > this.mTotalNum)
			{
				count = this.mTotalNum;
			}
			this.mTodayCount.SafeSetText(string.Format("{0}/{1}", count, this.mTotalNum));
		}

		// Token: 0x04009646 RID: 38470
		private int mTotalNum = 2;

		// Token: 0x04009647 RID: 38471
		[SerializeField]
		private Text mTodayCount;
	}
}
