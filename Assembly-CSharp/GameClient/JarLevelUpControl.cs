using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000079 RID: 121
	internal class JarLevelUpControl : MonoBehaviour
	{
		// Token: 0x06000297 RID: 663 RVA: 0x00013F44 File Offset: 0x00012344
		public float GetAnimationLength(string key)
		{
			if (this.jarConfig != null)
			{
				return this.jarConfig.GetAnimationLength(key);
			}
			return 0f;
		}

		// Token: 0x06000298 RID: 664 RVA: 0x00013F64 File Offset: 0x00012364
		public void Play(string key)
		{
			if (this.jarConfig != null)
			{
				for (int i = 0; i < this.jarConfig.akConfigs.Length; i++)
				{
					if (this.jarConfig.akConfigs[i] != null && this.jarConfig.akConfigs[i].key == key)
					{
						this.jarConfig.akConfigs[i].Play();
						break;
					}
				}
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x00013FE0 File Offset: 0x000123E0
		public void PlayAll()
		{
			if (this.jarConfig != null)
			{
				for (int i = 0; i < this.jarConfig.akConfigs.Length; i++)
				{
					if (this.jarConfig.akConfigs[i] != null)
					{
						this.jarConfig.akConfigs[i].Play();
					}
				}
			}
		}

		// Token: 0x0600029A RID: 666 RVA: 0x0001403C File Offset: 0x0001243C
		public void Stop(string key)
		{
			if (this.jarConfig != null)
			{
				for (int i = 0; i < this.jarConfig.akConfigs.Length; i++)
				{
					if (this.jarConfig.akConfigs[i] != null && this.jarConfig.akConfigs[i].key == key)
					{
						this.jarConfig.akConfigs[i].Play();
						break;
					}
				}
			}
		}

		// Token: 0x0600029B RID: 667 RVA: 0x000140B8 File Offset: 0x000124B8
		public void StopAll()
		{
			if (this.jarConfig != null)
			{
				for (int i = 0; i < this.jarConfig.akConfigs.Length; i++)
				{
					if (this.jarConfig.akConfigs[i] != null)
					{
						this.jarConfig.akConfigs[i].Stop();
					}
				}
			}
		}

		// Token: 0x04000289 RID: 649
		public JarConfig jarConfig;
	}
}
