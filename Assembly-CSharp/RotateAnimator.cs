using System;
using UnityEngine;

// Token: 0x02000D96 RID: 3478
public class RotateAnimator : MonoBehaviour, ISceneAnimator
{
	// Token: 0x06008CE5 RID: 36069 RVA: 0x001A269B File Offset: 0x001A0A9B
	public void SetSpeed(float speedRate, float duration)
	{
		this.m_RotateAnimation.SetSpeed(speedRate, duration);
	}

	// Token: 0x06008CE6 RID: 36070 RVA: 0x001A26AA File Offset: 0x001A0AAA
	private void Start()
	{
		this.m_RotateAnimation = new RotateAnimation(base.transform, this.RotateSpeed);
	}

	// Token: 0x06008CE7 RID: 36071 RVA: 0x001A26C3 File Offset: 0x001A0AC3
	private void Update()
	{
		this.m_RotateAnimation.Update(Time.deltaTime);
	}

	// Token: 0x040045C3 RID: 17859
	[Tooltip("速度范围：0 ~ 360")]
	public Vector3 RotateSpeed;

	// Token: 0x040045C4 RID: 17860
	private RotateAnimation m_RotateAnimation;
}
