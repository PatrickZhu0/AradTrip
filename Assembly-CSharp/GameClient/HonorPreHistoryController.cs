using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200166F RID: 5743
	public class HonorPreHistoryController : MonoBehaviour
	{
		// Token: 0x0600E1DE RID: 57822 RVA: 0x003A0A6C File Offset: 0x0039EE6C
		public void InitHonorPreHistoryController()
		{
			if (this.todayItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.todayItem.gameObject, true);
				this.todayItem.InitItem(HONOR_DATE_TYPE.HONOR_DATE_TYPE_TODAY);
			}
			if (this.thisWeekItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.thisWeekItem.gameObject, true);
				this.thisWeekItem.InitItem(HONOR_DATE_TYPE.HONOR_DATE_TYPE_THIS_WEEK);
			}
			if (this.lastWeekItem != null)
			{
				CommonUtility.UpdateGameObjectVisible(this.lastWeekItem.gameObject, true);
				this.lastWeekItem.InitItem(HONOR_DATE_TYPE.HONOR_DATE_TYPE_LAST_WEEK);
			}
		}

		// Token: 0x0400872C RID: 34604
		[Space(5f)]
		[Header("PreHistoryItem")]
		[Space(5f)]
		[SerializeField]
		private HonorPreHistoryItem todayItem;

		// Token: 0x0400872D RID: 34605
		[SerializeField]
		private HonorPreHistoryItem thisWeekItem;

		// Token: 0x0400872E RID: 34606
		[SerializeField]
		private HonorPreHistoryItem lastWeekItem;
	}
}
