using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D51 RID: 3409
	public class GeUIParticleEmitterDirectional : GeUIParticleEmitterBase
	{
		// Token: 0x06008A97 RID: 35479 RVA: 0x00197574 File Offset: 0x00195974
		public GeUIParticleEmitterDirectional()
		{
			this.m_EmitterShape = EUIEffEmitShape.Directional;
		}

		// Token: 0x1700186A RID: 6250
		// (get) Token: 0x06008A99 RID: 35481 RVA: 0x0019758C File Offset: 0x0019598C
		// (set) Token: 0x06008A98 RID: 35480 RVA: 0x00197583 File Offset: 0x00195983
		public float emitDirection
		{
			get
			{
				return this.m_EmitDirection;
			}
			set
			{
				this.m_EmitDirection = value;
			}
		}

		// Token: 0x1700186B RID: 6251
		// (get) Token: 0x06008A9B RID: 35483 RVA: 0x0019759D File Offset: 0x0019599D
		// (set) Token: 0x06008A9A RID: 35482 RVA: 0x00197594 File Offset: 0x00195994
		public float emitSpread
		{
			get
			{
				return this.m_EmitSpread;
			}
			set
			{
				this.m_EmitSpread = value;
			}
		}

		// Token: 0x06008A9C RID: 35484 RVA: 0x001975A8 File Offset: 0x001959A8
		public override void LoadDataBlock(GeUIEffectDataBlock[] dataBlock)
		{
			base.LoadDataBlock(dataBlock);
			int i = 0;
			while (i < dataBlock.Length)
			{
				string name = dataBlock[i].m_Name;
				if (name != null)
				{
					if (!(name == "m_EmitDirection"))
					{
						if (name == "m_EmitSpread")
						{
							this.m_EmitSpread = float.Parse(dataBlock[i].m_Value);
						}
					}
					else
					{
						this.m_EmitDirection = float.Parse(dataBlock[i].m_Value);
					}
				}
				IL_77:
				i++;
				continue;
				goto IL_77;
			}
		}

		// Token: 0x06008A9D RID: 35485 RVA: 0x0019763C File Offset: 0x00195A3C
		public override void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			base.SaveDataBlock(ref dataBlock);
			List<GeUIEffectDataBlock> list = new List<GeUIEffectDataBlock>();
			list.AddRange(dataBlock);
			list.Add(new GeUIEffectDataBlock("m_EmitDirection", this.m_EmitDirection.ToString()));
			list.Add(new GeUIEffectDataBlock("m_EmitSpread", this.m_EmitSpread.ToString()));
			dataBlock = list.ToArray();
		}

		// Token: 0x06008A9E RID: 35486 RVA: 0x001976A8 File Offset: 0x00195AA8
		public override void Emit(float speed, ref GeUIParticle particle)
		{
			particle.Position = Vector2.zero;
			GeUIParticle geUIParticle = particle;
			Vector2 vector;
			vector..ctor(Mathf.Sin(0.017453292f * (this.m_EmitDirection + Random.Range(-this.m_EmitSpread * 0.5f, this.m_EmitSpread * 0.5f))), Mathf.Cos(0.017453292f * (this.m_EmitDirection + Random.Range(-this.m_EmitSpread * 0.5f, this.m_EmitSpread * 0.5f))));
			geUIParticle.Velocity = vector.normalized * speed;
		}

		// Token: 0x0400448F RID: 17551
		private float m_EmitDirection;

		// Token: 0x04004490 RID: 17552
		private float m_EmitSpread;
	}
}
