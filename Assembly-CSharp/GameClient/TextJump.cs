using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004750 RID: 18256
	internal class TextJump : MonoBehaviour
	{
		// Token: 0x0601A395 RID: 107413 RVA: 0x00825499 File Offset: 0x00823899
		private void Start()
		{
			this.iIndex = -1;
			this.iTick = 0;
			if (this.interval < 1)
			{
				this.interval = 1;
			}
		}

		// Token: 0x0601A396 RID: 107414 RVA: 0x008254BC File Offset: 0x008238BC
		private void Update()
		{
			if (this.iTick % this.interval != 0)
			{
				this.iTick = (1 + this.iTick) % this.interval;
				return;
			}
			if (this.jumpTexts != null && null != this.text && this.jumpTexts.Length > 0)
			{
				this.iIndex = (1 + this.iIndex) % this.jumpTexts.Length;
				this.text.text = this.jumpTexts[this.iIndex];
			}
			this.iTick = (1 + this.iTick) % this.interval;
		}

		// Token: 0x040126BF RID: 75455
		public string[] jumpTexts;

		// Token: 0x040126C0 RID: 75456
		private int iIndex;

		// Token: 0x040126C1 RID: 75457
		public Text text;

		// Token: 0x040126C2 RID: 75458
		public int interval = 6;

		// Token: 0x040126C3 RID: 75459
		private int iTick;
	}
}
