using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001891 RID: 6289
	public class FatigueBurnActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x17001CFA RID: 7418
		// (get) Token: 0x0600F60F RID: 62991 RVA: 0x00426314 File Offset: 0x00424714
		// (set) Token: 0x0600F60E RID: 62990 RVA: 0x0042630B File Offset: 0x0042470B
		public ActivityItemBase.OnActivityItemClick<int> OnOpenClick { private get; set; }

		// Token: 0x0600F610 RID: 62992 RVA: 0x0042631C File Offset: 0x0042471C
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this.mNote.Init(model, true, base.GetComponent<ComCommonBind>());
			this.mTasksScrollRect.enabled = (model.TaskDatas != null && model.TaskDatas.Count > this.mScrollCount);
		}

		// Token: 0x040096E1 RID: 38625
		[SerializeField]
		private int mScrollCount = 2;

		// Token: 0x040096E2 RID: 38626
		[SerializeField]
		private ScrollRect mTasksScrollRect;
	}
}
