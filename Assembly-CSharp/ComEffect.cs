using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePool;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000027 RID: 39
public class ComEffect : MonoBehaviour
{
	// Token: 0x060000F3 RID: 243 RVA: 0x0000A0CD File Offset: 0x000084CD
	private void OnDestroy()
	{
		this.effects.Clear();
		this.effects = null;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000A0E4 File Offset: 0x000084E4
	public void Play(string key)
	{
		if (this.effects != null)
		{
			ComEffect.Effect effect = this.effects.Find((ComEffect.Effect x) => x.key == key);
			if (effect != null)
			{
				if (effect.parent != null)
				{
					List<DOTweenAnimation> list = ListPool<DOTweenAnimation>.Get();
					effect.parent.GetComponentsInChildren<DOTweenAnimation>(list);
					for (int i = 0; i < list.Count; i++)
					{
						list[i].autoKill = false;
					}
					effect.parent.CustomActive(true);
					for (int j = 0; j < effect.particles.Count; j++)
					{
						effect.particles[j].RestartEmit();
					}
					for (int k = 0; k < list.Count; k++)
					{
						list[k].DORestart(false);
					}
					ListPool<DOTweenAnimation>.Release(list);
				}
			}
			else
			{
				Logger.LogErrorFormat("effect has not find named {0}", new object[]
				{
					key
				});
			}
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x0000A1FC File Offset: 0x000085FC
	public void Stop(string key)
	{
		if (this.effects != null)
		{
			ComEffect.Effect effect = this.effects.Find((ComEffect.Effect x) => x.key == key);
			if (effect != null && effect.parent != null)
			{
				for (int i = 0; i < effect.particles.Count; i++)
				{
					effect.particles[i].StopEmit();
				}
				effect.parent.CustomActive(false);
			}
		}
	}

	// Token: 0x040000CC RID: 204
	public List<ComEffect.Effect> effects;

	// Token: 0x02000028 RID: 40
	[Serializable]
	public class Effect
	{
		// Token: 0x040000CD RID: 205
		public string key = string.Empty;

		// Token: 0x040000CE RID: 206
		public GameObject parent;

		// Token: 0x040000CF RID: 207
		public List<GeUIEffectParticle> particles;
	}
}
