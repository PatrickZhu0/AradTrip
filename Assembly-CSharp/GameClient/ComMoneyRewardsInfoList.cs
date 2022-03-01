using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017DF RID: 6111
	internal class ComMoneyRewardsInfoList : MonoBehaviour
	{
		// Token: 0x0600F0DA RID: 61658 RVA: 0x0040D8E7 File Offset: 0x0040BCE7
		public void OnClickWatchRecords()
		{
		}

		// Token: 0x040093DD RID: 37853
		public ComMoneyRewardsResultInfo[] results = new ComMoneyRewardsResultInfo[0];

		// Token: 0x040093DE RID: 37854
		public ComMoneyRewardsResultInfo[] result4s = new ComMoneyRewardsResultInfo[0];

		// Token: 0x040093DF RID: 37855
		public ComMoneyRewardsResultInfo[] result2s = new ComMoneyRewardsResultInfo[0];

		// Token: 0x040093E0 RID: 37856
		public Button[] buttons = new Button[0];

		// Token: 0x040093E1 RID: 37857
		public StateController[] btnWatchStatus = new StateController[0];
	}
}
