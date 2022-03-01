using System;

namespace GameClient
{
	// Token: 0x02000078 RID: 120
	[Serializable]
	internal class JarConfig
	{
		// Token: 0x06000295 RID: 661 RVA: 0x00013EDC File Offset: 0x000122DC
		public float GetAnimationLength(string key)
		{
			AnimationConfig animationConfig = null;
			for (int i = 0; i < this.akConfigs.Length; i++)
			{
				if (this.akConfigs[i].key == key)
				{
					animationConfig = this.akConfigs[i];
					break;
				}
			}
			if (animationConfig != null)
			{
				return animationConfig.fLastTime;
			}
			return 0f;
		}

		// Token: 0x04000288 RID: 648
		public AnimationConfig[] akConfigs = new AnimationConfig[0];
	}
}
