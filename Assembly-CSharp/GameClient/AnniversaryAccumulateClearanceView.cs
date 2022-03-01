using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001812 RID: 6162
	public class AnniversaryAccumulateClearanceView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F2BF RID: 62143 RVA: 0x00418494 File Offset: 0x00416894
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			if (this.mActiveUpdate != null)
			{
				this.mActiveUpdate.SetTotlaNum((int)model.Param);
			}
		}

		// Token: 0x04009532 RID: 38194
		[SerializeField]
		private ActiveUpdate mActiveUpdate;
	}
}
