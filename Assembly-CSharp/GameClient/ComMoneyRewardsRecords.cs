using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017E3 RID: 6115
	internal class ComMoneyRewardsRecords : MonoBehaviour
	{
		// Token: 0x0600F0EB RID: 61675 RVA: 0x0040DE85 File Offset: 0x0040C285
		public void OnItemVisible(ComMoneyRewardsRecordsData value)
		{
			this.data = value;
			if (this.data != null && null != this.content)
			{
				this.content.text = this.data.saveValue;
			}
		}

		// Token: 0x0600F0EC RID: 61676 RVA: 0x0040DEC0 File Offset: 0x0040C2C0
		public void OnDestroy()
		{
			this.data = null;
		}

		// Token: 0x040093F5 RID: 37877
		public Text content;

		// Token: 0x040093F6 RID: 37878
		private ComMoneyRewardsRecordsData data;
	}
}
