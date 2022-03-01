using System;
using UnityEngine;

// Token: 0x02000D94 RID: 3476
public class ScrollAnimation
{
	// Token: 0x06008CE0 RID: 36064 RVA: 0x001A252A File Offset: 0x001A092A
	public ScrollAnimation(Material material, int paramID, Vector2 scrollSpeed)
	{
		this.m_ScrollMaterial = material;
		this.MainTexID = paramID;
		this.m_ScrollSpeed = scrollSpeed;
		this.m_ScrollMaterial.SetTextureOffset(this.MainTexID, this.m_CurrentUVOffset);
	}

	// Token: 0x06008CE1 RID: 36065 RVA: 0x001A2569 File Offset: 0x001A0969
	public void SetSpeed(float speedRate, float duration)
	{
		this.m_IsAccelerate = true;
		this.m_AccelerateElaspedTime = 0f;
		this.m_AccelerateTime = duration;
		this.m_BeginSpeed = this.m_CurrentSpeed;
		this.m_TargetSpeed = this.m_ScrollSpeed * speedRate;
	}

	// Token: 0x06008CE2 RID: 36066 RVA: 0x001A25A4 File Offset: 0x001A09A4
	public void Update(float deltaTime)
	{
		if (this.m_IsAccelerate)
		{
			this.m_AccelerateElaspedTime += deltaTime;
			this.m_CurrentSpeed = Vector2.Lerp(this.m_BeginSpeed, this.m_TargetSpeed, this.m_AccelerateElaspedTime / this.m_AccelerateTime);
			if (this.m_AccelerateElaspedTime >= this.m_AccelerateTime)
			{
				this.m_IsAccelerate = false;
				this.m_CurrentSpeed = this.m_TargetSpeed;
			}
		}
		if (this.m_CurrentSpeed != Vector2.zero)
		{
			this.m_CurrentUVOffset += this.m_CurrentSpeed * deltaTime;
			this.m_CurrentUVOffset.x = this.m_CurrentUVOffset.x % 1f;
			this.m_CurrentUVOffset.y = this.m_CurrentUVOffset.y % 1f;
			this.m_ScrollMaterial.SetTextureOffset(this.MainTexID, this.m_CurrentUVOffset);
		}
	}

	// Token: 0x040045B9 RID: 17849
	private Vector2 m_ScrollSpeed;

	// Token: 0x040045BA RID: 17850
	private Material m_ScrollMaterial;

	// Token: 0x040045BB RID: 17851
	private Vector2 m_CurrentUVOffset;

	// Token: 0x040045BC RID: 17852
	private Vector2 m_CurrentSpeed;

	// Token: 0x040045BD RID: 17853
	private Vector2 m_BeginSpeed;

	// Token: 0x040045BE RID: 17854
	private Vector2 m_TargetSpeed;

	// Token: 0x040045BF RID: 17855
	private float m_AccelerateTime;

	// Token: 0x040045C0 RID: 17856
	private float m_AccelerateElaspedTime = float.MaxValue;

	// Token: 0x040045C1 RID: 17857
	private bool m_IsAccelerate;

	// Token: 0x040045C2 RID: 17858
	private int MainTexID;
}
