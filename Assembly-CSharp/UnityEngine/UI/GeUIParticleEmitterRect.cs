using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D4F RID: 3407
	public class GeUIParticleEmitterRect : GeUIParticleEmitterBase
	{
		// Token: 0x06008A81 RID: 35457 RVA: 0x00196D5E File Offset: 0x0019515E
		public GeUIParticleEmitterRect()
		{
			this.m_EmitterShape = EUIEffEmitShape.Rect;
		}

		// Token: 0x17001863 RID: 6243
		// (get) Token: 0x06008A83 RID: 35459 RVA: 0x00196D92 File Offset: 0x00195192
		// (set) Token: 0x06008A82 RID: 35458 RVA: 0x00196D89 File Offset: 0x00195189
		public Vector2 dimension
		{
			get
			{
				return this.m_Dimension;
			}
			set
			{
				this.m_Dimension = value;
			}
		}

		// Token: 0x17001864 RID: 6244
		// (get) Token: 0x06008A85 RID: 35461 RVA: 0x00196DA3 File Offset: 0x001951A3
		// (set) Token: 0x06008A84 RID: 35460 RVA: 0x00196D9A File Offset: 0x0019519A
		public EUIParticleEmitMode emitMode
		{
			get
			{
				return this.m_EmitMode;
			}
			set
			{
				this.m_EmitMode = value;
			}
		}

		// Token: 0x17001865 RID: 6245
		// (get) Token: 0x06008A87 RID: 35463 RVA: 0x00196DB4 File Offset: 0x001951B4
		// (set) Token: 0x06008A86 RID: 35462 RVA: 0x00196DAB File Offset: 0x001951AB
		public EUIParticleVelMode velocityMode
		{
			get
			{
				return this.m_VelocityMode;
			}
			set
			{
				this.m_VelocityMode = value;
			}
		}

		// Token: 0x06008A88 RID: 35464 RVA: 0x00196DBC File Offset: 0x001951BC
		public override void Emit(float speed, ref GeUIParticle particle)
		{
			EUIParticleEmitMode emitMode = this.m_EmitMode;
			if (emitMode != EUIParticleEmitMode.Area)
			{
				if (emitMode != EUIParticleEmitMode.Edge)
				{
					if (emitMode == EUIParticleEmitMode.Vertices)
					{
						Vector2[] array = new Vector2[]
						{
							new Vector2(-this.m_Dimension.x, -this.m_Dimension.y),
							new Vector2(-this.m_Dimension.x, this.m_Dimension.y),
							new Vector2(this.m_Dimension.x, this.m_Dimension.y),
							new Vector2(this.m_Dimension.x, -this.m_Dimension.y)
						};
						particle.Position = array[Random.Range(0, array.Length)];
					}
				}
				else
				{
					particle.Position = Vector2.zero;
					switch (Random.Range(0, 4))
					{
					case 0:
						particle.Position = new Vector2(Random.Range(-this.m_Dimension.x, this.m_Dimension.x), -this.m_Dimension.y);
						break;
					case 1:
						particle.Position = new Vector2(-this.m_Dimension.x, Random.Range(-this.m_Dimension.y, this.m_Dimension.y));
						break;
					case 2:
						particle.Position = new Vector2(Random.Range(-this.m_Dimension.x, this.m_Dimension.x), this.m_Dimension.y);
						break;
					case 3:
						particle.Position = new Vector2(this.m_Dimension.x, Random.Range(-this.m_Dimension.y, this.m_Dimension.y));
						break;
					default:
						particle.Position = new Vector2(this.m_Dimension.x, Random.Range(-this.m_Dimension.y, this.m_Dimension.y));
						break;
					}
				}
			}
			else
			{
				particle.Position = new Vector2(Random.Range(-this.m_Dimension.x, this.m_Dimension.x), Random.Range(-this.m_Dimension.y, this.m_Dimension.y));
			}
			switch (this.m_VelocityMode)
			{
			case EUIParticleVelMode.None:
			{
				GeUIParticle geUIParticle = particle;
				Vector2 vector;
				vector..ctor(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
				geUIParticle.Velocity = vector.normalized;
				break;
			}
			case EUIParticleVelMode.Radiant:
			{
				GeUIParticle geUIParticle2 = particle;
				Vector2 vector2;
				vector2..ctor(particle.Position.x, particle.Position.y);
				geUIParticle2.Velocity = vector2.normalized;
				break;
			}
			case EUIParticleVelMode.RadiantFlip:
			{
				GeUIParticle geUIParticle3 = particle;
				Vector2 vector3;
				vector3..ctor(-particle.Position.x, -particle.Position.y);
				geUIParticle3.Velocity = vector3.normalized;
				break;
			}
			case EUIParticleVelMode.RadiantTwoSide:
			{
				GeUIParticle geUIParticle4 = particle;
				Vector2 vector4;
				vector4..ctor(particle.Position.x, particle.Position.y);
				geUIParticle4.Velocity = vector4.normalized;
				particle.Velocity *= Mathf.Sign(Random.Range(-1f, 1f));
				break;
			}
			}
			GeUIParticle geUIParticle5 = particle;
			geUIParticle5.Velocity.x = geUIParticle5.Velocity.x * speed;
			GeUIParticle geUIParticle6 = particle;
			geUIParticle6.Velocity.y = geUIParticle6.Velocity.y * speed;
		}

		// Token: 0x06008A89 RID: 35465 RVA: 0x00197188 File Offset: 0x00195588
		public override void LoadDataBlock(GeUIEffectDataBlock[] dataBlock)
		{
			base.LoadDataBlock(dataBlock);
			int i = 0;
			while (i < dataBlock.Length)
			{
				string name = dataBlock[i].m_Name;
				if (name != null)
				{
					if (!(name == "m_Dimension"))
					{
						if (!(name == "m_EmitMode"))
						{
							if (name == "m_VelocityMode")
							{
								this.m_VelocityMode = (EUIParticleVelMode)int.Parse(dataBlock[i].m_Value);
							}
						}
						else
						{
							this.m_EmitMode = (EUIParticleEmitMode)int.Parse(dataBlock[i].m_Value);
						}
					}
					else
					{
						this.m_Dimension = Vector2Serializer.ToVector2(dataBlock[i].m_Value);
					}
				}
				IL_9F:
				i++;
				continue;
				goto IL_9F;
			}
		}

		// Token: 0x06008A8A RID: 35466 RVA: 0x00197244 File Offset: 0x00195644
		public override void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			base.SaveDataBlock(ref dataBlock);
			List<GeUIEffectDataBlock> list = new List<GeUIEffectDataBlock>();
			list.AddRange(dataBlock);
			list.Add(new GeUIEffectDataBlock("m_Dimension", Vector2Serializer.FromVector2(this.m_Dimension)));
			List<GeUIEffectDataBlock> list2 = list;
			string name = "m_EmitMode";
			int emitMode = (int)this.m_EmitMode;
			list2.Add(new GeUIEffectDataBlock(name, emitMode.ToString()));
			List<GeUIEffectDataBlock> list3 = list;
			string name2 = "m_VelocityMode";
			int velocityMode = (int)this.m_VelocityMode;
			list3.Add(new GeUIEffectDataBlock(name2, velocityMode.ToString()));
			dataBlock = list.ToArray();
		}

		// Token: 0x04004488 RID: 17544
		private Vector2 m_Dimension = new Vector2(100f, 100f);

		// Token: 0x04004489 RID: 17545
		private EUIParticleEmitMode m_EmitMode = EUIParticleEmitMode.Area;

		// Token: 0x0400448A RID: 17546
		private EUIParticleVelMode m_VelocityMode;
	}
}
