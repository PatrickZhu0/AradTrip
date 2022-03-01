using System;

namespace GameClient
{
	// Token: 0x02001559 RID: 5465
	public class VoiceButtonUsed
	{
		// Token: 0x0600D56E RID: 54638 RVA: 0x003555FE File Offset: 0x003539FE
		public VoiceButtonUsed()
		{
			this.Reset();
		}

		// Token: 0x0600D56F RID: 54639 RVA: 0x0035560C File Offset: 0x00353A0C
		public void Reset()
		{
			this.currActiveBtn = null;
			this.pointerFirstId = 10000;
		}

		// Token: 0x04007D55 RID: 32085
		public VoiceInputBtn currActiveBtn;

		// Token: 0x04007D56 RID: 32086
		public int pointerFirstId;
	}
}
