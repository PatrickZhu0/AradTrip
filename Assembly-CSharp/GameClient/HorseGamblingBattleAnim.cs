using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200167F RID: 5759
	public class HorseGamblingBattleAnim : MonoBehaviour
	{
		// Token: 0x0600E275 RID: 57973 RVA: 0x003A2CB7 File Offset: 0x003A10B7
		public void Play()
		{
			this.mEffet.CustomActive(true);
			this.mStaticEffet.CustomActive(false);
		}

		// Token: 0x0600E276 RID: 57974 RVA: 0x003A2CD1 File Offset: 0x003A10D1
		public void Stop()
		{
			this.mEffet.CustomActive(false);
			this.mStaticEffet.CustomActive(true);
		}

		// Token: 0x04008780 RID: 34688
		[SerializeField]
		private GameObject mEffet;

		// Token: 0x04008781 RID: 34689
		[SerializeField]
		private GameObject mStaticEffet;
	}
}
