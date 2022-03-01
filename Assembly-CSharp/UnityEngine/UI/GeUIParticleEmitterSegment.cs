using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D50 RID: 3408
	public class GeUIParticleEmitterSegment : GeUIParticleEmitterBase
	{
		// Token: 0x06008A8B RID: 35467 RVA: 0x001972D1 File Offset: 0x001956D1
		public GeUIParticleEmitterSegment()
		{
			this.m_EmitterShape = EUIEffEmitShape.Segment;
		}

		// Token: 0x17001866 RID: 6246
		// (get) Token: 0x06008A8D RID: 35469 RVA: 0x001972FF File Offset: 0x001956FF
		// (set) Token: 0x06008A8C RID: 35468 RVA: 0x001972F6 File Offset: 0x001956F6
		public Vector2 segmentBegin
		{
			get
			{
				return this.m_SegBegin;
			}
			set
			{
				this.m_SegBegin = value;
			}
		}

		// Token: 0x17001867 RID: 6247
		// (get) Token: 0x06008A8F RID: 35471 RVA: 0x00197310 File Offset: 0x00195710
		// (set) Token: 0x06008A8E RID: 35470 RVA: 0x00197307 File Offset: 0x00195707
		public Vector2 segmentEnd
		{
			get
			{
				return this.m_SegEnd;
			}
			set
			{
				this.m_SegEnd = value;
			}
		}

		// Token: 0x17001868 RID: 6248
		// (get) Token: 0x06008A91 RID: 35473 RVA: 0x00197321 File Offset: 0x00195721
		// (set) Token: 0x06008A90 RID: 35472 RVA: 0x00197318 File Offset: 0x00195718
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

		// Token: 0x17001869 RID: 6249
		// (get) Token: 0x06008A93 RID: 35475 RVA: 0x00197332 File Offset: 0x00195732
		// (set) Token: 0x06008A92 RID: 35474 RVA: 0x00197329 File Offset: 0x00195729
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

		// Token: 0x06008A94 RID: 35476 RVA: 0x0019733C File Offset: 0x0019573C
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
						if (!(name == "m_EmitSpread"))
						{
							if (!(name == "m_SegBegin"))
							{
								if (name == "m_SegEnd")
								{
									this.m_SegEnd = Vector2Serializer.ToVector2(dataBlock[i].m_Value);
								}
							}
							else
							{
								this.m_SegBegin = Vector2Serializer.ToVector2(dataBlock[i].m_Value);
							}
						}
						else
						{
							this.m_EmitSpread = float.Parse(dataBlock[i].m_Value);
						}
					}
					else
					{
						this.m_EmitDirection = float.Parse(dataBlock[i].m_Value);
					}
				}
				IL_C7:
				i++;
				continue;
				goto IL_C7;
			}
		}

		// Token: 0x06008A95 RID: 35477 RVA: 0x00197420 File Offset: 0x00195820
		public override void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			base.SaveDataBlock(ref dataBlock);
			List<GeUIEffectDataBlock> list = new List<GeUIEffectDataBlock>();
			list.AddRange(dataBlock);
			list.Add(new GeUIEffectDataBlock("m_EmitDirection", this.m_EmitDirection.ToString()));
			list.Add(new GeUIEffectDataBlock("m_EmitSpread", this.m_EmitSpread.ToString()));
			list.Add(new GeUIEffectDataBlock("m_SegBegin", Vector2Serializer.FromVector2(this.m_SegBegin)));
			list.Add(new GeUIEffectDataBlock("m_SegEnd", Vector2Serializer.FromVector2(this.m_SegEnd)));
			dataBlock = list.ToArray();
		}

		// Token: 0x06008A96 RID: 35478 RVA: 0x001974C4 File Offset: 0x001958C4
		public override void Emit(float speed, ref GeUIParticle particle)
		{
			particle.Position = base._GetPointInSegment(this.m_SegBegin, this.m_SegEnd, (float)Random.Range(0, 100) * 0.01f);
			GeUIParticle geUIParticle = particle;
			Vector2 vector;
			vector..ctor(Mathf.Sin(0.017453292f * (this.m_EmitDirection + Random.Range(-this.m_EmitSpread * 0.5f, this.m_EmitSpread * 0.5f))), Mathf.Cos(0.017453292f * (this.m_EmitDirection + Random.Range(-this.m_EmitSpread * 0.5f, this.m_EmitSpread * 0.5f))));
			geUIParticle.Velocity = vector.normalized * speed;
		}

		// Token: 0x0400448B RID: 17547
		private float m_EmitDirection;

		// Token: 0x0400448C RID: 17548
		private float m_EmitSpread;

		// Token: 0x0400448D RID: 17549
		private Vector2 m_SegBegin = Vector2.zero;

		// Token: 0x0400448E RID: 17550
		private Vector2 m_SegEnd = Vector2.zero;
	}
}
