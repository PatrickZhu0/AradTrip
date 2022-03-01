using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000D46 RID: 3398
public class GeUIEffectPlayer : MonoBehaviour
{
	// Token: 0x17001856 RID: 6230
	// (get) Token: 0x06008A50 RID: 35408 RVA: 0x00196240 File Offset: 0x00194640
	public GeUIEffectParticle[] UIParticles
	{
		get
		{
			return this.m_UIParticles;
		}
	}

	// Token: 0x06008A51 RID: 35409 RVA: 0x00196248 File Offset: 0x00194648
	private void Start()
	{
		this.m_UIParticles = base.gameObject.GetComponentsInChildren<GeUIEffectParticle>();
	}

	// Token: 0x06008A52 RID: 35410 RVA: 0x0019625B File Offset: 0x0019465B
	private void Update()
	{
	}

	// Token: 0x06008A53 RID: 35411 RVA: 0x0019625D File Offset: 0x0019465D
	private void OnEnable()
	{
		this.m_UIParticles = base.gameObject.GetComponentsInChildren<GeUIEffectParticle>();
	}

	// Token: 0x06008A54 RID: 35412 RVA: 0x00196270 File Offset: 0x00194670
	public void Reinit()
	{
		this.m_UIParticles = base.gameObject.GetComponentsInChildren<GeUIEffectParticle>();
	}

	// Token: 0x04004467 RID: 17511
	private GeUIEffectParticle[] m_UIParticles;
}
