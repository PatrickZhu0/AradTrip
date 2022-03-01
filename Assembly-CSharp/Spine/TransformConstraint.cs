using System;

namespace Spine
{
	// Token: 0x020049DE RID: 18910
	public class TransformConstraint : IConstraint, IUpdatable
	{
		// Token: 0x0601B452 RID: 111698 RVA: 0x00864714 File Offset: 0x00862B14
		public TransformConstraint(TransformConstraintData data, Skeleton skeleton)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			if (skeleton == null)
			{
				throw new ArgumentNullException("skeleton", "skeleton cannot be null.");
			}
			this.data = data;
			this.rotateMix = data.rotateMix;
			this.translateMix = data.translateMix;
			this.scaleMix = data.scaleMix;
			this.shearMix = data.shearMix;
			this.bones = new ExposedList<Bone>();
			foreach (BoneData boneData in data.bones)
			{
				this.bones.Add(skeleton.FindBone(boneData.name));
			}
			this.target = skeleton.FindBone(data.target.name);
		}

		// Token: 0x170023FC RID: 9212
		// (get) Token: 0x0601B453 RID: 111699 RVA: 0x0086480C File Offset: 0x00862C0C
		public TransformConstraintData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170023FD RID: 9213
		// (get) Token: 0x0601B454 RID: 111700 RVA: 0x00864814 File Offset: 0x00862C14
		public int Order
		{
			get
			{
				return this.data.order;
			}
		}

		// Token: 0x170023FE RID: 9214
		// (get) Token: 0x0601B455 RID: 111701 RVA: 0x00864821 File Offset: 0x00862C21
		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x170023FF RID: 9215
		// (get) Token: 0x0601B456 RID: 111702 RVA: 0x00864829 File Offset: 0x00862C29
		// (set) Token: 0x0601B457 RID: 111703 RVA: 0x00864831 File Offset: 0x00862C31
		public Bone Target
		{
			get
			{
				return this.target;
			}
			set
			{
				this.target = value;
			}
		}

		// Token: 0x17002400 RID: 9216
		// (get) Token: 0x0601B458 RID: 111704 RVA: 0x0086483A File Offset: 0x00862C3A
		// (set) Token: 0x0601B459 RID: 111705 RVA: 0x00864842 File Offset: 0x00862C42
		public float RotateMix
		{
			get
			{
				return this.rotateMix;
			}
			set
			{
				this.rotateMix = value;
			}
		}

		// Token: 0x17002401 RID: 9217
		// (get) Token: 0x0601B45A RID: 111706 RVA: 0x0086484B File Offset: 0x00862C4B
		// (set) Token: 0x0601B45B RID: 111707 RVA: 0x00864853 File Offset: 0x00862C53
		public float TranslateMix
		{
			get
			{
				return this.translateMix;
			}
			set
			{
				this.translateMix = value;
			}
		}

		// Token: 0x17002402 RID: 9218
		// (get) Token: 0x0601B45C RID: 111708 RVA: 0x0086485C File Offset: 0x00862C5C
		// (set) Token: 0x0601B45D RID: 111709 RVA: 0x00864864 File Offset: 0x00862C64
		public float ScaleMix
		{
			get
			{
				return this.scaleMix;
			}
			set
			{
				this.scaleMix = value;
			}
		}

		// Token: 0x17002403 RID: 9219
		// (get) Token: 0x0601B45E RID: 111710 RVA: 0x0086486D File Offset: 0x00862C6D
		// (set) Token: 0x0601B45F RID: 111711 RVA: 0x00864875 File Offset: 0x00862C75
		public float ShearMix
		{
			get
			{
				return this.shearMix;
			}
			set
			{
				this.shearMix = value;
			}
		}

		// Token: 0x0601B460 RID: 111712 RVA: 0x0086487E File Offset: 0x00862C7E
		public void Apply()
		{
			this.Update();
		}

		// Token: 0x0601B461 RID: 111713 RVA: 0x00864888 File Offset: 0x00862C88
		public void Update()
		{
			if (this.data.local)
			{
				if (this.data.relative)
				{
					this.ApplyRelativeLocal();
				}
				else
				{
					this.ApplyAbsoluteLocal();
				}
			}
			else if (this.data.relative)
			{
				this.ApplyRelativeWorld();
			}
			else
			{
				this.ApplyAbsoluteWorld();
			}
		}

		// Token: 0x0601B462 RID: 111714 RVA: 0x008648EC File Offset: 0x00862CEC
		private void ApplyAbsoluteWorld()
		{
			float num = this.rotateMix;
			float num2 = this.translateMix;
			float num3 = this.scaleMix;
			float num4 = this.shearMix;
			Bone bone = this.target;
			float a = bone.a;
			float b = bone.b;
			float c = bone.c;
			float d = bone.d;
			float num5 = (a * d - b * c <= 0f) ? -0.017453292f : 0.017453292f;
			float num6 = this.data.offsetRotation * num5;
			float num7 = this.data.offsetShearY * num5;
			ExposedList<Bone> exposedList = this.bones;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone2 = exposedList.Items[i];
				bool flag = false;
				if (num != 0f)
				{
					float a2 = bone2.a;
					float b2 = bone2.b;
					float c2 = bone2.c;
					float d2 = bone2.d;
					float num8 = MathUtils.Atan2(c, a) - MathUtils.Atan2(c2, a2) + num6;
					if (num8 > 3.1415927f)
					{
						num8 -= 6.2831855f;
					}
					else if (num8 < -3.1415927f)
					{
						num8 += 6.2831855f;
					}
					num8 *= num;
					float num9 = MathUtils.Cos(num8);
					float num10 = MathUtils.Sin(num8);
					bone2.a = num9 * a2 - num10 * c2;
					bone2.b = num9 * b2 - num10 * d2;
					bone2.c = num10 * a2 + num9 * c2;
					bone2.d = num10 * b2 + num9 * d2;
					flag = true;
				}
				if (num2 != 0f)
				{
					float num11;
					float num12;
					bone.LocalToWorld(this.data.offsetX, this.data.offsetY, out num11, out num12);
					bone2.worldX += (num11 - bone2.worldX) * num2;
					bone2.worldY += (num12 - bone2.worldY) * num2;
					flag = true;
				}
				if (num3 > 0f)
				{
					float num13 = (float)Math.Sqrt((double)(bone2.a * bone2.a + bone2.c * bone2.c));
					if (num13 > 1E-05f)
					{
						num13 = (num13 + ((float)Math.Sqrt((double)(a * a + c * c)) - num13 + this.data.offsetScaleX) * num3) / num13;
					}
					bone2.a *= num13;
					bone2.c *= num13;
					num13 = (float)Math.Sqrt((double)(bone2.b * bone2.b + bone2.d * bone2.d));
					if (num13 > 1E-05f)
					{
						num13 = (num13 + ((float)Math.Sqrt((double)(b * b + d * d)) - num13 + this.data.offsetScaleY) * num3) / num13;
					}
					bone2.b *= num13;
					bone2.d *= num13;
					flag = true;
				}
				if (num4 > 0f)
				{
					float b3 = bone2.b;
					float d3 = bone2.d;
					float num14 = MathUtils.Atan2(d3, b3);
					float num15 = MathUtils.Atan2(d, b) - MathUtils.Atan2(c, a) - (num14 - MathUtils.Atan2(bone2.c, bone2.a));
					if (num15 > 3.1415927f)
					{
						num15 -= 6.2831855f;
					}
					else if (num15 < -3.1415927f)
					{
						num15 += 6.2831855f;
					}
					num15 = num14 + (num15 + num7) * num4;
					float num16 = (float)Math.Sqrt((double)(b3 * b3 + d3 * d3));
					bone2.b = MathUtils.Cos(num15) * num16;
					bone2.d = MathUtils.Sin(num15) * num16;
					flag = true;
				}
				if (flag)
				{
					bone2.appliedValid = false;
				}
				i++;
			}
		}

		// Token: 0x0601B463 RID: 111715 RVA: 0x00864CE4 File Offset: 0x008630E4
		private void ApplyRelativeWorld()
		{
			float num = this.rotateMix;
			float num2 = this.translateMix;
			float num3 = this.scaleMix;
			float num4 = this.shearMix;
			Bone bone = this.target;
			float a = bone.a;
			float b = bone.b;
			float c = bone.c;
			float d = bone.d;
			float num5 = (a * d - b * c <= 0f) ? -0.017453292f : 0.017453292f;
			float num6 = this.data.offsetRotation * num5;
			float num7 = this.data.offsetShearY * num5;
			ExposedList<Bone> exposedList = this.bones;
			int i = 0;
			int count = exposedList.Count;
			while (i < count)
			{
				Bone bone2 = exposedList.Items[i];
				bool flag = false;
				if (num != 0f)
				{
					float a2 = bone2.a;
					float b2 = bone2.b;
					float c2 = bone2.c;
					float d2 = bone2.d;
					float num8 = MathUtils.Atan2(c, a) + num6;
					if (num8 > 3.1415927f)
					{
						num8 -= 6.2831855f;
					}
					else if (num8 < -3.1415927f)
					{
						num8 += 6.2831855f;
					}
					num8 *= num;
					float num9 = MathUtils.Cos(num8);
					float num10 = MathUtils.Sin(num8);
					bone2.a = num9 * a2 - num10 * c2;
					bone2.b = num9 * b2 - num10 * d2;
					bone2.c = num10 * a2 + num9 * c2;
					bone2.d = num10 * b2 + num9 * d2;
					flag = true;
				}
				if (num2 != 0f)
				{
					float num11;
					float num12;
					bone.LocalToWorld(this.data.offsetX, this.data.offsetY, out num11, out num12);
					bone2.worldX += num11 * num2;
					bone2.worldY += num12 * num2;
					flag = true;
				}
				if (num3 > 0f)
				{
					float num13 = ((float)Math.Sqrt((double)(a * a + c * c)) - 1f + this.data.offsetScaleX) * num3 + 1f;
					bone2.a *= num13;
					bone2.c *= num13;
					num13 = ((float)Math.Sqrt((double)(b * b + d * d)) - 1f + this.data.offsetScaleY) * num3 + 1f;
					bone2.b *= num13;
					bone2.d *= num13;
					flag = true;
				}
				if (num4 > 0f)
				{
					float num14 = MathUtils.Atan2(d, b) - MathUtils.Atan2(c, a);
					if (num14 > 3.1415927f)
					{
						num14 -= 6.2831855f;
					}
					else if (num14 < -3.1415927f)
					{
						num14 += 6.2831855f;
					}
					float b3 = bone2.b;
					float d3 = bone2.d;
					num14 = MathUtils.Atan2(d3, b3) + (num14 - 1.5707964f + num7) * num4;
					float num15 = (float)Math.Sqrt((double)(b3 * b3 + d3 * d3));
					bone2.b = MathUtils.Cos(num14) * num15;
					bone2.d = MathUtils.Sin(num14) * num15;
					flag = true;
				}
				if (flag)
				{
					bone2.appliedValid = false;
				}
				i++;
			}
		}

		// Token: 0x0601B464 RID: 111716 RVA: 0x00865048 File Offset: 0x00863448
		private void ApplyAbsoluteLocal()
		{
			float num = this.rotateMix;
			float num2 = this.translateMix;
			float num3 = this.scaleMix;
			float num4 = this.shearMix;
			Bone bone = this.target;
			if (!bone.appliedValid)
			{
				bone.UpdateAppliedTransform();
			}
			Bone[] items = this.bones.Items;
			int i = 0;
			int count = this.bones.Count;
			while (i < count)
			{
				Bone bone2 = items[i];
				if (!bone2.appliedValid)
				{
					bone2.UpdateAppliedTransform();
				}
				float num5 = bone2.arotation;
				if (num != 0f)
				{
					float num6 = bone.arotation - num5 + this.data.offsetRotation;
					num6 -= (float)((16384 - (int)(16384.499999999996 - (double)(num6 / 360f))) * 360);
					num5 += num6 * num;
				}
				float num7 = bone2.ax;
				float num8 = bone2.ay;
				if (num2 != 0f)
				{
					num7 += (bone.ax - num7 + this.data.offsetX) * num2;
					num8 += (bone.ay - num8 + this.data.offsetY) * num2;
				}
				float num9 = bone2.ascaleX;
				float num10 = bone2.ascaleY;
				if (num3 > 0f)
				{
					if (num9 > 1E-05f)
					{
						num9 = (num9 + (bone.ascaleX - num9 + this.data.offsetScaleX) * num3) / num9;
					}
					if (num10 > 1E-05f)
					{
						num10 = (num10 + (bone.ascaleY - num10 + this.data.offsetScaleY) * num3) / num10;
					}
				}
				float ashearY = bone2.ashearY;
				if (num4 > 0f)
				{
					float num11 = bone.ashearY - ashearY + this.data.offsetShearY;
					num11 -= (float)((16384 - (int)(16384.499999999996 - (double)(num11 / 360f))) * 360);
					bone2.shearY += num11 * num4;
				}
				bone2.UpdateWorldTransform(num7, num8, num5, num9, num10, bone2.ashearX, ashearY);
				i++;
			}
		}

		// Token: 0x0601B465 RID: 111717 RVA: 0x0086527C File Offset: 0x0086367C
		private void ApplyRelativeLocal()
		{
			float num = this.rotateMix;
			float num2 = this.translateMix;
			float num3 = this.scaleMix;
			float num4 = this.shearMix;
			Bone bone = this.target;
			if (!bone.appliedValid)
			{
				bone.UpdateAppliedTransform();
			}
			Bone[] items = this.bones.Items;
			int i = 0;
			int count = this.bones.Count;
			while (i < count)
			{
				Bone bone2 = items[i];
				if (!bone2.appliedValid)
				{
					bone2.UpdateAppliedTransform();
				}
				float num5 = bone2.arotation;
				if (num != 0f)
				{
					num5 += (bone.arotation + this.data.offsetRotation) * num;
				}
				float num6 = bone2.ax;
				float num7 = bone2.ay;
				if (num2 != 0f)
				{
					num6 += (bone.ax + this.data.offsetX) * num2;
					num7 += (bone.ay + this.data.offsetY) * num2;
				}
				float num8 = bone2.ascaleX;
				float num9 = bone2.ascaleY;
				if (num3 > 0f)
				{
					if (num8 > 1E-05f)
					{
						num8 *= (bone.ascaleX - 1f + this.data.offsetScaleX) * num3 + 1f;
					}
					if (num9 > 1E-05f)
					{
						num9 *= (bone.ascaleY - 1f + this.data.offsetScaleY) * num3 + 1f;
					}
				}
				float num10 = bone2.ashearY;
				if (num4 > 0f)
				{
					num10 += (bone.ashearY + this.data.offsetShearY) * num4;
				}
				bone2.UpdateWorldTransform(num6, num7, num5, num8, num9, bone2.ashearX, num10);
				i++;
			}
		}

		// Token: 0x0601B466 RID: 111718 RVA: 0x00865453 File Offset: 0x00863853
		public override string ToString()
		{
			return this.data.name;
		}

		// Token: 0x04012FF2 RID: 77810
		internal TransformConstraintData data;

		// Token: 0x04012FF3 RID: 77811
		internal ExposedList<Bone> bones;

		// Token: 0x04012FF4 RID: 77812
		internal Bone target;

		// Token: 0x04012FF5 RID: 77813
		internal float rotateMix;

		// Token: 0x04012FF6 RID: 77814
		internal float translateMix;

		// Token: 0x04012FF7 RID: 77815
		internal float scaleMix;

		// Token: 0x04012FF8 RID: 77816
		internal float shearMix;
	}
}
