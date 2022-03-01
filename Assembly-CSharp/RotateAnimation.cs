using System;
using UnityEngine;

// Token: 0x02000D93 RID: 3475
public class RotateAnimation
{
	// Token: 0x06008CDD RID: 36061 RVA: 0x001A23A4 File Offset: 0x001A07A4
	public RotateAnimation(Transform transform, Vector3 rotateSpeed)
	{
		this.m_Transform = transform;
		this.m_RotateSpeed = rotateSpeed;
		this.m_CurrentAngle = transform.localRotation.eulerAngles;
	}

	// Token: 0x06008CDE RID: 36062 RVA: 0x001A23E4 File Offset: 0x001A07E4
	public void SetSpeed(float speedRate, float duration)
	{
		this.m_IsAccelerate = true;
		this.m_AccelerateElaspedTime = 0f;
		this.m_AccelerateTime = duration;
		this.m_BeginSpeed = this.m_CurrentSpeed;
		this.m_TargetSpeed = this.m_RotateSpeed * speedRate;
	}

	// Token: 0x06008CDF RID: 36063 RVA: 0x001A2420 File Offset: 0x001A0820
	public void Update(float deltaTime)
	{
		if (this.m_IsAccelerate)
		{
			this.m_AccelerateElaspedTime += deltaTime;
			this.m_CurrentSpeed = Vector3.Lerp(this.m_BeginSpeed, this.m_TargetSpeed, this.m_AccelerateElaspedTime / this.m_AccelerateTime);
			if (this.m_AccelerateElaspedTime >= this.m_AccelerateTime)
			{
				this.m_IsAccelerate = false;
				this.m_CurrentSpeed = this.m_TargetSpeed;
			}
		}
		if (this.m_CurrentSpeed != Vector3.zero)
		{
			this.m_CurrentAngle += this.m_CurrentSpeed * deltaTime;
			this.m_CurrentAngle.x = this.m_CurrentAngle.x % 360f;
			this.m_CurrentAngle.y = this.m_CurrentAngle.y % 360f;
			this.m_CurrentAngle.z = this.m_CurrentAngle.z % 360f;
			this.m_Transform.localRotation = Quaternion.Euler(this.m_CurrentAngle);
		}
	}

	// Token: 0x040045B0 RID: 17840
	private Vector3 m_RotateSpeed;

	// Token: 0x040045B1 RID: 17841
	private Vector3 m_CurrentAngle;

	// Token: 0x040045B2 RID: 17842
	private Vector3 m_CurrentSpeed;

	// Token: 0x040045B3 RID: 17843
	private Vector3 m_BeginSpeed;

	// Token: 0x040045B4 RID: 17844
	private Vector3 m_TargetSpeed;

	// Token: 0x040045B5 RID: 17845
	private float m_AccelerateTime;

	// Token: 0x040045B6 RID: 17846
	private float m_AccelerateElaspedTime = float.MaxValue;

	// Token: 0x040045B7 RID: 17847
	private bool m_IsAccelerate;

	// Token: 0x040045B8 RID: 17848
	private Transform m_Transform;
}
