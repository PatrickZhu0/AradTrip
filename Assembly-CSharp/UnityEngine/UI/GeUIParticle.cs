using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D41 RID: 3393
	public class GeUIParticle
	{
		// Token: 0x04004402 RID: 17410
		public Vector2 Position;

		// Token: 0x04004403 RID: 17411
		public Vector2 LastEmitPos;

		// Token: 0x04004404 RID: 17412
		public float InitSize;

		// Token: 0x04004405 RID: 17413
		public float Size;

		// Token: 0x04004406 RID: 17414
		public Vector2 Velocity;

		// Token: 0x04004407 RID: 17415
		public float SpinVel;

		// Token: 0x04004408 RID: 17416
		public float Life;

		// Token: 0x04004409 RID: 17417
		public float NTLife;

		// Token: 0x0400440A RID: 17418
		public float Rotation;

		// Token: 0x0400440B RID: 17419
		public Color Color;

		// Token: 0x0400440C RID: 17420
		public float Alpha;

		// Token: 0x0400440D RID: 17421
		public int TexFrame;

		// Token: 0x0400440E RID: 17422
		public int TexFrameRate;

		// Token: 0x0400440F RID: 17423
		public int TimeStampMS;

		// Token: 0x04004410 RID: 17424
		public int LastFrameMS;

		// Token: 0x04004411 RID: 17425
		public GeUIParticleEmitterBase Emiter;

		// Token: 0x04004412 RID: 17426
		public GeUIEffectGeo m_GeometryData;
	}
}
