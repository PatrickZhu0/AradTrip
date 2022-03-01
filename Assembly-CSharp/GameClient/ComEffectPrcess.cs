using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001AD9 RID: 6873
	public class ComEffectPrcess : MonoBehaviour
	{
		// Token: 0x06010DE5 RID: 69093 RVA: 0x004D03A0 File Offset: 0x004CE7A0
		public void Play()
		{
			this.Stop();
			for (int i = 0; i < this.mConfigs.Length; i++)
			{
				EffectProcessConfig config = this.mConfigs[i];
				if (config != null)
				{
					InvokeMethod.InvokeInterval(this, this.startDelay + config.start, config.len, config.len, delegate
					{
						if (null != this.comEffectLoader)
						{
							this.comEffectLoader.LoadEffect(config.index);
							this.comEffectLoader.ActiveEffect(config.index);
						}
						if (config.onActionStart != null)
						{
							config.onActionStart.Invoke();
						}
					}, null, delegate
					{
						if (null != this.comEffectLoader)
						{
							this.comEffectLoader.DeActiveEffect(config.index);
						}
						if (config.onActionEnd != null)
						{
							config.onActionEnd.Invoke();
						}
					});
				}
			}
		}

		// Token: 0x06010DE6 RID: 69094 RVA: 0x004D043C File Offset: 0x004CE83C
		public void Stop()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
			for (int i = 0; i < this.mConfigs.Length; i++)
			{
				EffectProcessConfig effectProcessConfig = this.mConfigs[i];
				if (effectProcessConfig != null && null != this.comEffectLoader)
				{
					this.comEffectLoader.DeActiveEffect(effectProcessConfig.index);
				}
			}
		}

		// Token: 0x06010DE7 RID: 69095 RVA: 0x004D0499 File Offset: 0x004CE899
		private void OnDestroy()
		{
			InvokeMethod.RmoveInvokeIntervalCall(this);
		}

		// Token: 0x0400AD3A RID: 44346
		public float startDelay;

		// Token: 0x0400AD3B RID: 44347
		public ComEffectLoader comEffectLoader;

		// Token: 0x0400AD3C RID: 44348
		public EffectProcessConfig[] mConfigs = new EffectProcessConfig[0];
	}
}
