using System;
using UnityEngine;

// Token: 0x02000D83 RID: 3459
public class ParticleAndAnimation : MonoBehaviour
{
	// Token: 0x06008C42 RID: 35906 RVA: 0x0019F98A File Offset: 0x0019DD8A
	private void Start()
	{
		this.PlayOnce();
	}

	// Token: 0x06008C43 RID: 35907 RVA: 0x0019F994 File Offset: 0x0019DD94
	[ContextMenu("Play Loop")]
	public void PlayLoop()
	{
		ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>(true);
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			particleSystem.loop = true;
			particleSystem.Play();
		}
		Animation[] componentsInChildren2 = base.GetComponentsInChildren<Animation>(true);
		foreach (Animation animation in componentsInChildren2)
		{
			animation.wrapMode = 2;
			animation.Play();
		}
	}

	// Token: 0x06008C44 RID: 35908 RVA: 0x0019FA10 File Offset: 0x0019DE10
	[ContextMenu("Play Once")]
	public void PlayOnce()
	{
		ParticleSystem[] componentsInChildren = base.GetComponentsInChildren<ParticleSystem>(true);
		foreach (ParticleSystem particleSystem in componentsInChildren)
		{
			particleSystem.loop = false;
			particleSystem.Play();
		}
		Animation[] componentsInChildren2 = base.GetComponentsInChildren<Animation>(true);
		foreach (Animation animation in componentsInChildren2)
		{
			animation.wrapMode = 1;
			animation.Play();
		}
	}
}
