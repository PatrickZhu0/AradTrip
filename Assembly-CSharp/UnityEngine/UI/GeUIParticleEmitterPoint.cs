using System;

namespace UnityEngine.UI
{
	// Token: 0x02000D4B RID: 3403
	public class GeUIParticleEmitterPoint : GeUIParticleEmitterBase
	{
		// Token: 0x06008A70 RID: 35440 RVA: 0x001967C3 File Offset: 0x00194BC3
		public GeUIParticleEmitterPoint()
		{
			this.m_EmitterShape = EUIEffEmitShape.Point;
		}

		// Token: 0x06008A71 RID: 35441 RVA: 0x001967D4 File Offset: 0x00194BD4
		public override void Emit(float speed, ref GeUIParticle particle)
		{
			particle.Position = new Vector2((float)Random.Range(0, 0), (float)Random.Range(0, 0));
			GeUIParticle geUIParticle = particle;
			Vector2 vector;
			vector..ctor(Mathf.Sin((float)Random.Range(0, 360)), Mathf.Sin(Random.Range(0f, 100f)));
			geUIParticle.Velocity = vector.normalized * speed;
		}

		// Token: 0x06008A72 RID: 35442 RVA: 0x0019683D File Offset: 0x00194C3D
		public override void LoadDataBlock(GeUIEffectDataBlock[] dataBlock)
		{
			base.LoadDataBlock(dataBlock);
		}

		// Token: 0x06008A73 RID: 35443 RVA: 0x00196846 File Offset: 0x00194C46
		public override void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			base.SaveDataBlock(ref dataBlock);
		}
	}
}
