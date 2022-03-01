using System;
using UnityEngine;

// Token: 0x02000D97 RID: 3479
public class ScrollAnimator : MonoBehaviour, ISceneAnimator
{
	// Token: 0x06008CE9 RID: 36073 RVA: 0x001A26DD File Offset: 0x001A0ADD
	public void SetSpeed(float speedRate, float duration)
	{
		this.m_ScrollAnimation.SetSpeed(speedRate, duration);
	}

	// Token: 0x06008CEA RID: 36074 RVA: 0x001A26EC File Offset: 0x001A0AEC
	private void Start()
	{
		int paramID = Shader.PropertyToID("_MainTex");
		Material material = base.GetComponent<Renderer>().material;
		this.m_ScrollAnimation = new ScrollAnimation(material, paramID, this.ScrollSpeed);
	}

	// Token: 0x06008CEB RID: 36075 RVA: 0x001A2723 File Offset: 0x001A0B23
	private void Update()
	{
		this.m_ScrollAnimation.Update(Time.deltaTime);
	}

	// Token: 0x040045C5 RID: 17861
	[Tooltip("速度范围：-1 ~ 1")]
	public Vector2 ScrollSpeed;

	// Token: 0x040045C6 RID: 17862
	private ScrollAnimation m_ScrollAnimation;
}
