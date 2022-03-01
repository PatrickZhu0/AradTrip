using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000077 RID: 119
	[Serializable]
	internal class AnimationConfig
	{
		// Token: 0x06000291 RID: 657 RVA: 0x00013D95 File Offset: 0x00012195
		public float GetAnimationTime()
		{
			return this.fLastTime;
		}

		// Token: 0x06000292 RID: 658 RVA: 0x00013DA0 File Offset: 0x000121A0
		public void Stop()
		{
			if (!string.IsNullOrEmpty(this.key))
			{
				for (int i = 0; i < this.ani.Length; i++)
				{
					if (this.ani[i] != null)
					{
						this.ani[i].Stop();
					}
				}
			}
			for (int j = 0; j < this.akEffectObjects.Length; j++)
			{
				if (this.akEffectObjects[j] != null)
				{
					this.akEffectObjects[j].CustomActive(false);
				}
			}
		}

		// Token: 0x06000293 RID: 659 RVA: 0x00013E30 File Offset: 0x00012230
		public void Play()
		{
			for (int i = 0; i < this.akEffectObjects.Length; i++)
			{
				if (this.akEffectObjects[i] != null)
				{
					this.akEffectObjects[i].CustomActive(false);
				}
			}
			if (!string.IsNullOrEmpty(this.key))
			{
				for (int j = 0; j < this.ani.Length; j++)
				{
					if (this.ani[j] != null)
					{
						this.ani[j].Play(this.key);
					}
				}
			}
		}

		// Token: 0x04000284 RID: 644
		public string key;

		// Token: 0x04000285 RID: 645
		public Animation[] ani = new Animation[0];

		// Token: 0x04000286 RID: 646
		public GameObject[] akEffectObjects = new GameObject[0];

		// Token: 0x04000287 RID: 647
		public float fLastTime = 1f;
	}
}
