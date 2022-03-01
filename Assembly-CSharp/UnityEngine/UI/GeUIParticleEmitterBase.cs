using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D4A RID: 3402
	public class GeUIParticleEmitterBase
	{
		// Token: 0x17001857 RID: 6231
		// (get) Token: 0x06008A5D RID: 35421 RVA: 0x001963CA File Offset: 0x001947CA
		// (set) Token: 0x06008A5C RID: 35420 RVA: 0x001963C1 File Offset: 0x001947C1
		public bool relative
		{
			get
			{
				return this.m_Relative;
			}
			set
			{
				this.m_Relative = value;
			}
		}

		// Token: 0x17001858 RID: 6232
		// (get) Token: 0x06008A5F RID: 35423 RVA: 0x001963DB File Offset: 0x001947DB
		// (set) Token: 0x06008A5E RID: 35422 RVA: 0x001963D2 File Offset: 0x001947D2
		public float emitRate
		{
			get
			{
				return this.m_EmiterRate;
			}
			set
			{
				this.m_EmiterRate = value;
			}
		}

		// Token: 0x17001859 RID: 6233
		// (get) Token: 0x06008A61 RID: 35425 RVA: 0x001963EC File Offset: 0x001947EC
		// (set) Token: 0x06008A60 RID: 35424 RVA: 0x001963E3 File Offset: 0x001947E3
		public float delayEmit
		{
			get
			{
				return this.m_DelayEmit;
			}
			set
			{
				this.m_DelayEmit = value;
			}
		}

		// Token: 0x1700185A RID: 6234
		// (get) Token: 0x06008A63 RID: 35427 RVA: 0x001963FD File Offset: 0x001947FD
		// (set) Token: 0x06008A62 RID: 35426 RVA: 0x001963F4 File Offset: 0x001947F4
		public int partiPerEmission
		{
			get
			{
				return this.m_PartiPerEmission;
			}
			set
			{
				this.m_PartiPerEmission = value;
			}
		}

		// Token: 0x1700185B RID: 6235
		// (get) Token: 0x06008A65 RID: 35429 RVA: 0x0019640E File Offset: 0x0019480E
		// (set) Token: 0x06008A64 RID: 35428 RVA: 0x00196405 File Offset: 0x00194805
		public int maxParticles
		{
			get
			{
				return this.m_MaxParticles;
			}
			set
			{
				this.m_MaxParticles = value;
			}
		}

		// Token: 0x1700185C RID: 6236
		// (get) Token: 0x06008A67 RID: 35431 RVA: 0x0019641F File Offset: 0x0019481F
		// (set) Token: 0x06008A66 RID: 35430 RVA: 0x00196416 File Offset: 0x00194816
		public uint durationMS
		{
			get
			{
				return this.m_DurationMS;
			}
			set
			{
				this.m_DurationMS = value;
			}
		}

		// Token: 0x1700185D RID: 6237
		// (get) Token: 0x06008A68 RID: 35432 RVA: 0x00196427 File Offset: 0x00194827
		public float emiterRate
		{
			get
			{
				return this.m_EmiterRate;
			}
		}

		// Token: 0x1700185E RID: 6238
		// (get) Token: 0x06008A69 RID: 35433 RVA: 0x0019642F File Offset: 0x0019482F
		public EUIEffEmitShape emitterShape
		{
			get
			{
				return this.m_EmitterShape;
			}
		}

		// Token: 0x06008A6A RID: 35434 RVA: 0x00196437 File Offset: 0x00194837
		public EUIEffEmitShape GetEmitShape()
		{
			return this.emitterShape;
		}

		// Token: 0x06008A6B RID: 35435 RVA: 0x0019643F File Offset: 0x0019483F
		public virtual void Emit(float speed, ref GeUIParticle particle)
		{
			particle.Position = Vector2.zero;
			particle.Velocity = Vector2.zero;
		}

		// Token: 0x06008A6C RID: 35436 RVA: 0x0019645C File Offset: 0x0019485C
		public virtual void LoadDataBlock(GeUIEffectDataBlock[] dataBlock)
		{
			int i = 0;
			while (i < dataBlock.Length)
			{
				string name = dataBlock[i].m_Name;
				switch (name)
				{
				case "m_EmitSpeed":
					this.m_EmitSpeed = float.Parse(dataBlock[i].m_Value);
					break;
				case "m_EmitRandomRange":
					this.m_EmitRandomRange = float.Parse(dataBlock[i].m_Value);
					break;
				case "m_DelayEmit":
					this.m_DelayEmit = float.Parse(dataBlock[i].m_Value);
					break;
				case "m_EmiterRate":
					this.m_EmiterRate = float.Parse(dataBlock[i].m_Value);
					break;
				case "m_PartiPerEmission":
					this.m_PartiPerEmission = int.Parse(dataBlock[i].m_Value);
					break;
				case "m_MaxParticles":
					this.m_MaxParticles = int.Parse(dataBlock[i].m_Value);
					break;
				case "m_NumberOfParticles":
					this.m_NumberOfParticles = int.Parse(dataBlock[i].m_Value);
					break;
				case "m_DurationMS":
					this.m_DurationMS = uint.Parse(dataBlock[i].m_Value);
					break;
				case "m_Relative":
					this.m_Relative = bool.Parse(dataBlock[i].m_Value);
					break;
				}
				IL_1BC:
				i++;
				continue;
				goto IL_1BC;
			}
		}

		// Token: 0x06008A6D RID: 35437 RVA: 0x00196634 File Offset: 0x00194A34
		public virtual void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			dataBlock = new List<GeUIEffectDataBlock>
			{
				new GeUIEffectDataBlock("m_EmitSpeed", this.m_EmitSpeed.ToString()),
				new GeUIEffectDataBlock("m_EmitRandomRange", this.m_EmitRandomRange.ToString()),
				new GeUIEffectDataBlock("m_DelayEmit", this.m_DelayEmit.ToString()),
				new GeUIEffectDataBlock("m_EmiterRate", this.m_EmiterRate.ToString()),
				new GeUIEffectDataBlock("m_PartiPerEmission", this.m_PartiPerEmission.ToString()),
				new GeUIEffectDataBlock("m_MaxParticles", this.m_MaxParticles.ToString()),
				new GeUIEffectDataBlock("m_NumberOfParticles", this.m_NumberOfParticles.ToString()),
				new GeUIEffectDataBlock("m_DurationMS", this.m_DurationMS.ToString()),
				new GeUIEffectDataBlock("m_Relative", this.m_Relative.ToString())
			}.ToArray();
		}

		// Token: 0x06008A6E RID: 35438 RVA: 0x00196778 File Offset: 0x00194B78
		public virtual void DrawGizmo(GeUIEffectParticle particle)
		{
		}

		// Token: 0x06008A6F RID: 35439 RVA: 0x0019677C File Offset: 0x00194B7C
		protected Vector2 _GetPointInSegment(Vector2 pointA, Vector2 pointB, float percent)
		{
			Vector2 result;
			result..ctor(pointA.x + percent * (pointB.x - pointA.x), pointA.y + percent * (pointB.y - pointA.y));
			return result;
		}

		// Token: 0x0400446E RID: 17518
		protected EUIEffEmitShape m_EmitterShape;

		// Token: 0x0400446F RID: 17519
		protected float m_EmitSpeed = 1f;

		// Token: 0x04004470 RID: 17520
		protected float m_EmitRandomRange = 0.5f;

		// Token: 0x04004471 RID: 17521
		protected float m_EmiterRate = 1f;

		// Token: 0x04004472 RID: 17522
		protected float m_DelayEmit;

		// Token: 0x04004473 RID: 17523
		protected int m_PartiPerEmission = 1;

		// Token: 0x04004474 RID: 17524
		protected int m_MaxParticles = 20;

		// Token: 0x04004475 RID: 17525
		protected int m_NumberOfParticles;

		// Token: 0x04004476 RID: 17526
		protected uint m_DurationMS;

		// Token: 0x04004477 RID: 17527
		protected bool m_Relative;

		// Token: 0x04004478 RID: 17528
		private float m_ElapsedEmitTime;
	}
}
