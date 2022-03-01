using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001886 RID: 6278
	public class CompetitionSupportActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5CE RID: 62926 RVA: 0x004252FC File Offset: 0x004236FC
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mTime.SafeSetText(string.Format("{0}~{1}", Function._TransTimeStampToStr(this.mModel.StartTime), Function._TransTimeStampToStr(this.mModel.EndTime)));
			this._InitItems(model);
		}

		// Token: 0x040096C7 RID: 38599
		[SerializeField]
		private Text mTime;
	}
}
