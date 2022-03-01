using System;
using UnityEngine;

// Token: 0x0200023F RID: 575
public class MirroEffect : MonoBehaviour
{
	// Token: 0x06001300 RID: 4864 RVA: 0x0006543E File Offset: 0x0006383E
	public void Apply(bool bMirror)
	{
		if (this.mtype == MirroEffect.MirroType.MirroTransformRotation)
		{
			this.ApplyTransformRotation(bMirror);
		}
		else if (this.mtype == MirroEffect.MirroType.MirroParicleRotation)
		{
			this.ApplyParicleRotation(bMirror);
		}
	}

	// Token: 0x06001301 RID: 4865 RVA: 0x0006546C File Offset: 0x0006386C
	protected void ApplyParicleRotation(bool bMirror)
	{
		ParticleSystem componentInChildren = base.gameObject.GetComponentInChildren<ParticleSystem>();
		if (componentInChildren)
		{
			componentInChildren.Stop();
			componentInChildren.startRotation = ((!bMirror) ? this.fValue.x : this.fValue.y) / 180f * 3.1415927f;
		}
	}

	// Token: 0x06001302 RID: 4866 RVA: 0x000654CC File Offset: 0x000638CC
	protected void ApplyTransformRotation(bool bMirror)
	{
		float num = (!bMirror) ? this.fValue.x : this.fValue.y;
		base.gameObject.transform.localRotation = Quaternion.Euler(0f, num, 0f);
	}

	// Token: 0x04000C9B RID: 3227
	public MirroEffect.MirroType mtype;

	// Token: 0x04000C9C RID: 3228
	public Vector3 fValue;

	// Token: 0x02000240 RID: 576
	public enum MirroType
	{
		// Token: 0x04000C9E RID: 3230
		MirroTransformRotation,
		// Token: 0x04000C9F RID: 3231
		MirroParicleRotation
	}
}
