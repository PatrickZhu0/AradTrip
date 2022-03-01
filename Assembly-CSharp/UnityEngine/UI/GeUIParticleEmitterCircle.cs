using System;
using System.Collections.Generic;

namespace UnityEngine.UI
{
	// Token: 0x02000D4E RID: 3406
	public class GeUIParticleEmitterCircle : GeUIParticleEmitterBase
	{
		// Token: 0x06008A74 RID: 35444 RVA: 0x0019684F File Offset: 0x00194C4F
		public GeUIParticleEmitterCircle()
		{
			this.m_EmitterShape = EUIEffEmitShape.Circle;
		}

		// Token: 0x1700185F RID: 6239
		// (get) Token: 0x06008A76 RID: 35446 RVA: 0x001968AB File Offset: 0x00194CAB
		// (set) Token: 0x06008A75 RID: 35445 RVA: 0x00196883 File Offset: 0x00194C83
		public float radius
		{
			get
			{
				return this.m_Radius;
			}
			set
			{
				if (value == this.m_Radius)
				{
					return;
				}
				this.m_Radius = value;
				this._RebuildVertices(this.m_CircleSegments, this.m_Radius);
			}
		}

		// Token: 0x17001860 RID: 6240
		// (get) Token: 0x06008A78 RID: 35448 RVA: 0x001968DB File Offset: 0x00194CDB
		// (set) Token: 0x06008A77 RID: 35447 RVA: 0x001968B3 File Offset: 0x00194CB3
		public int circleSegments
		{
			get
			{
				return this.m_CircleSegments;
			}
			set
			{
				if (value == this.m_CircleSegments)
				{
					return;
				}
				this.m_CircleSegments = value;
				this._RebuildVertices(this.m_CircleSegments, this.m_Radius);
			}
		}

		// Token: 0x17001861 RID: 6241
		// (get) Token: 0x06008A7A RID: 35450 RVA: 0x001968EC File Offset: 0x00194CEC
		// (set) Token: 0x06008A79 RID: 35449 RVA: 0x001968E3 File Offset: 0x00194CE3
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

		// Token: 0x17001862 RID: 6242
		// (get) Token: 0x06008A7C RID: 35452 RVA: 0x001968FD File Offset: 0x00194CFD
		// (set) Token: 0x06008A7B RID: 35451 RVA: 0x001968F4 File Offset: 0x00194CF4
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

		// Token: 0x06008A7D RID: 35453 RVA: 0x00196908 File Offset: 0x00194D08
		public override void Emit(float speed, ref GeUIParticle particle)
		{
			EUIParticleEmitMode emitMode = this.m_EmitMode;
			if (emitMode != EUIParticleEmitMode.Area)
			{
				if (emitMode != EUIParticleEmitMode.Edge)
				{
					if (emitMode == EUIParticleEmitMode.Vertices)
					{
						particle.Position = this.m_Vertices[Random.Range(0, this.m_CircleSegments)];
					}
				}
				else
				{
					int num = Random.Range(0, this.m_CircleSegments);
					int num2 = num + 1;
					if (num2 >= this.m_CircleSegments)
					{
						num2 = 0;
					}
					particle.Position = base._GetPointInSegment(this.m_Vertices[num], this.m_Vertices[num2], (float)Random.Range(0, 100) / 100f);
				}
			}
			else
			{
				float num3 = 0.017453292f * (float)Random.Range(0, 360);
				float num4 = Mathf.Sin(num3);
				float num5 = Mathf.Cos(num3);
				float num6 = this.m_Radius * Random.Range(0f, 1f);
				particle.Position.x = num5 * num6;
				particle.Position.y = num4 * num6;
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

		// Token: 0x06008A7E RID: 35454 RVA: 0x00196B58 File Offset: 0x00194F58
		public override void LoadDataBlock(GeUIEffectDataBlock[] dataBlock)
		{
			base.LoadDataBlock(dataBlock);
			int i = 0;
			while (i < dataBlock.Length)
			{
				string name = dataBlock[i].m_Name;
				if (name != null)
				{
					if (!(name == "m_Radius"))
					{
						if (!(name == "m_CircleSegments"))
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
							this.m_CircleSegments = int.Parse(dataBlock[i].m_Value);
						}
					}
					else
					{
						this.m_Radius = float.Parse(dataBlock[i].m_Value);
					}
				}
				IL_C7:
				i++;
				continue;
				goto IL_C7;
			}
			this._RebuildVertices(this.m_CircleSegments, this.m_Radius);
		}

		// Token: 0x06008A7F RID: 35455 RVA: 0x00196C4C File Offset: 0x0019504C
		public override void SaveDataBlock(ref GeUIEffectDataBlock[] dataBlock)
		{
			base.SaveDataBlock(ref dataBlock);
			List<GeUIEffectDataBlock> list = new List<GeUIEffectDataBlock>();
			list.AddRange(dataBlock);
			list.Add(new GeUIEffectDataBlock("m_Radius", this.m_Radius.ToString()));
			list.Add(new GeUIEffectDataBlock("m_CircleSegments", this.m_CircleSegments.ToString()));
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

		// Token: 0x06008A80 RID: 35456 RVA: 0x00196D00 File Offset: 0x00195100
		protected void _RebuildVertices(int sides, float radius)
		{
			this.m_Vertices.Clear();
			for (int i = 0; i < sides; i++)
			{
				float num = 6.2831855f * ((float)i / (float)sides);
				float num2 = Mathf.Cos(num) * radius;
				float num3 = Mathf.Sin(num) * radius;
				Vector2 item;
				item..ctor(num2, num3);
				this.m_Vertices.Add(item);
			}
		}

		// Token: 0x04004483 RID: 17539
		private EUIParticleVelMode m_VelocityMode;

		// Token: 0x04004484 RID: 17540
		private float m_Radius = 10f;

		// Token: 0x04004485 RID: 17541
		private int m_CircleSegments = 20;

		// Token: 0x04004486 RID: 17542
		private EUIParticleEmitMode m_EmitMode = EUIParticleEmitMode.Area;

		// Token: 0x04004487 RID: 17543
		private List<Vector2> m_Vertices = new List<Vector2>();
	}
}
