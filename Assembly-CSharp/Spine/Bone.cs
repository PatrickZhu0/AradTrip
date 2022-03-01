using System;

namespace Spine
{
	// Token: 0x020049BB RID: 18875
	public class Bone : IUpdatable
	{
		// Token: 0x0601B23E RID: 111166 RVA: 0x00858020 File Offset: 0x00856420
		public Bone(BoneData data, Skeleton skeleton, Bone parent)
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
			this.skeleton = skeleton;
			this.parent = parent;
			this.SetToSetupPose();
		}

		// Token: 0x17002350 RID: 9040
		// (get) Token: 0x0601B23F RID: 111167 RVA: 0x00858085 File Offset: 0x00856485
		public BoneData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x17002351 RID: 9041
		// (get) Token: 0x0601B240 RID: 111168 RVA: 0x0085808D File Offset: 0x0085648D
		public Skeleton Skeleton
		{
			get
			{
				return this.skeleton;
			}
		}

		// Token: 0x17002352 RID: 9042
		// (get) Token: 0x0601B241 RID: 111169 RVA: 0x00858095 File Offset: 0x00856495
		public Bone Parent
		{
			get
			{
				return this.parent;
			}
		}

		// Token: 0x17002353 RID: 9043
		// (get) Token: 0x0601B242 RID: 111170 RVA: 0x0085809D File Offset: 0x0085649D
		public ExposedList<Bone> Children
		{
			get
			{
				return this.children;
			}
		}

		// Token: 0x17002354 RID: 9044
		// (get) Token: 0x0601B243 RID: 111171 RVA: 0x008580A5 File Offset: 0x008564A5
		// (set) Token: 0x0601B244 RID: 111172 RVA: 0x008580AD File Offset: 0x008564AD
		public float X
		{
			get
			{
				return this.x;
			}
			set
			{
				this.x = value;
			}
		}

		// Token: 0x17002355 RID: 9045
		// (get) Token: 0x0601B245 RID: 111173 RVA: 0x008580B6 File Offset: 0x008564B6
		// (set) Token: 0x0601B246 RID: 111174 RVA: 0x008580BE File Offset: 0x008564BE
		public float Y
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17002356 RID: 9046
		// (get) Token: 0x0601B247 RID: 111175 RVA: 0x008580C7 File Offset: 0x008564C7
		// (set) Token: 0x0601B248 RID: 111176 RVA: 0x008580CF File Offset: 0x008564CF
		public float Rotation
		{
			get
			{
				return this.rotation;
			}
			set
			{
				this.rotation = value;
			}
		}

		// Token: 0x17002357 RID: 9047
		// (get) Token: 0x0601B249 RID: 111177 RVA: 0x008580D8 File Offset: 0x008564D8
		// (set) Token: 0x0601B24A RID: 111178 RVA: 0x008580E0 File Offset: 0x008564E0
		public float ScaleX
		{
			get
			{
				return this.scaleX;
			}
			set
			{
				this.scaleX = value;
			}
		}

		// Token: 0x17002358 RID: 9048
		// (get) Token: 0x0601B24B RID: 111179 RVA: 0x008580E9 File Offset: 0x008564E9
		// (set) Token: 0x0601B24C RID: 111180 RVA: 0x008580F1 File Offset: 0x008564F1
		public float ScaleY
		{
			get
			{
				return this.scaleY;
			}
			set
			{
				this.scaleY = value;
			}
		}

		// Token: 0x17002359 RID: 9049
		// (get) Token: 0x0601B24D RID: 111181 RVA: 0x008580FA File Offset: 0x008564FA
		// (set) Token: 0x0601B24E RID: 111182 RVA: 0x00858102 File Offset: 0x00856502
		public float ShearX
		{
			get
			{
				return this.shearX;
			}
			set
			{
				this.shearX = value;
			}
		}

		// Token: 0x1700235A RID: 9050
		// (get) Token: 0x0601B24F RID: 111183 RVA: 0x0085810B File Offset: 0x0085650B
		// (set) Token: 0x0601B250 RID: 111184 RVA: 0x00858113 File Offset: 0x00856513
		public float ShearY
		{
			get
			{
				return this.shearY;
			}
			set
			{
				this.shearY = value;
			}
		}

		// Token: 0x1700235B RID: 9051
		// (get) Token: 0x0601B251 RID: 111185 RVA: 0x0085811C File Offset: 0x0085651C
		// (set) Token: 0x0601B252 RID: 111186 RVA: 0x00858124 File Offset: 0x00856524
		public float AppliedRotation
		{
			get
			{
				return this.arotation;
			}
			set
			{
				this.arotation = value;
			}
		}

		// Token: 0x1700235C RID: 9052
		// (get) Token: 0x0601B253 RID: 111187 RVA: 0x0085812D File Offset: 0x0085652D
		// (set) Token: 0x0601B254 RID: 111188 RVA: 0x00858135 File Offset: 0x00856535
		public float AX
		{
			get
			{
				return this.ax;
			}
			set
			{
				this.ax = value;
			}
		}

		// Token: 0x1700235D RID: 9053
		// (get) Token: 0x0601B255 RID: 111189 RVA: 0x0085813E File Offset: 0x0085653E
		// (set) Token: 0x0601B256 RID: 111190 RVA: 0x00858146 File Offset: 0x00856546
		public float AY
		{
			get
			{
				return this.ay;
			}
			set
			{
				this.ay = value;
			}
		}

		// Token: 0x1700235E RID: 9054
		// (get) Token: 0x0601B257 RID: 111191 RVA: 0x0085814F File Offset: 0x0085654F
		// (set) Token: 0x0601B258 RID: 111192 RVA: 0x00858157 File Offset: 0x00856557
		public float AScaleX
		{
			get
			{
				return this.ascaleX;
			}
			set
			{
				this.ascaleX = value;
			}
		}

		// Token: 0x1700235F RID: 9055
		// (get) Token: 0x0601B259 RID: 111193 RVA: 0x00858160 File Offset: 0x00856560
		// (set) Token: 0x0601B25A RID: 111194 RVA: 0x00858168 File Offset: 0x00856568
		public float AScaleY
		{
			get
			{
				return this.ascaleY;
			}
			set
			{
				this.ascaleY = value;
			}
		}

		// Token: 0x17002360 RID: 9056
		// (get) Token: 0x0601B25B RID: 111195 RVA: 0x00858171 File Offset: 0x00856571
		// (set) Token: 0x0601B25C RID: 111196 RVA: 0x00858179 File Offset: 0x00856579
		public float AShearX
		{
			get
			{
				return this.ashearX;
			}
			set
			{
				this.ashearX = value;
			}
		}

		// Token: 0x17002361 RID: 9057
		// (get) Token: 0x0601B25D RID: 111197 RVA: 0x00858182 File Offset: 0x00856582
		// (set) Token: 0x0601B25E RID: 111198 RVA: 0x0085818A File Offset: 0x0085658A
		public float AShearY
		{
			get
			{
				return this.ashearY;
			}
			set
			{
				this.ashearY = value;
			}
		}

		// Token: 0x17002362 RID: 9058
		// (get) Token: 0x0601B25F RID: 111199 RVA: 0x00858193 File Offset: 0x00856593
		public float A
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17002363 RID: 9059
		// (get) Token: 0x0601B260 RID: 111200 RVA: 0x0085819B File Offset: 0x0085659B
		public float B
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x17002364 RID: 9060
		// (get) Token: 0x0601B261 RID: 111201 RVA: 0x008581A3 File Offset: 0x008565A3
		public float C
		{
			get
			{
				return this.c;
			}
		}

		// Token: 0x17002365 RID: 9061
		// (get) Token: 0x0601B262 RID: 111202 RVA: 0x008581AB File Offset: 0x008565AB
		public float D
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x17002366 RID: 9062
		// (get) Token: 0x0601B263 RID: 111203 RVA: 0x008581B3 File Offset: 0x008565B3
		public float WorldX
		{
			get
			{
				return this.worldX;
			}
		}

		// Token: 0x17002367 RID: 9063
		// (get) Token: 0x0601B264 RID: 111204 RVA: 0x008581BB File Offset: 0x008565BB
		public float WorldY
		{
			get
			{
				return this.worldY;
			}
		}

		// Token: 0x17002368 RID: 9064
		// (get) Token: 0x0601B265 RID: 111205 RVA: 0x008581C3 File Offset: 0x008565C3
		public float WorldRotationX
		{
			get
			{
				return MathUtils.Atan2(this.c, this.a) * 57.295776f;
			}
		}

		// Token: 0x17002369 RID: 9065
		// (get) Token: 0x0601B266 RID: 111206 RVA: 0x008581DC File Offset: 0x008565DC
		public float WorldRotationY
		{
			get
			{
				return MathUtils.Atan2(this.d, this.b) * 57.295776f;
			}
		}

		// Token: 0x1700236A RID: 9066
		// (get) Token: 0x0601B267 RID: 111207 RVA: 0x008581F5 File Offset: 0x008565F5
		public float WorldScaleX
		{
			get
			{
				return (float)Math.Sqrt((double)(this.a * this.a + this.c * this.c));
			}
		}

		// Token: 0x1700236B RID: 9067
		// (get) Token: 0x0601B268 RID: 111208 RVA: 0x00858219 File Offset: 0x00856619
		public float WorldScaleY
		{
			get
			{
				return (float)Math.Sqrt((double)(this.b * this.b + this.d * this.d));
			}
		}

		// Token: 0x0601B269 RID: 111209 RVA: 0x0085823D File Offset: 0x0085663D
		public void Update()
		{
			this.UpdateWorldTransform(this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);
		}

		// Token: 0x0601B26A RID: 111210 RVA: 0x0085826F File Offset: 0x0085666F
		public void UpdateWorldTransform()
		{
			this.UpdateWorldTransform(this.x, this.y, this.rotation, this.scaleX, this.scaleY, this.shearX, this.shearY);
		}

		// Token: 0x0601B26B RID: 111211 RVA: 0x008582A4 File Offset: 0x008566A4
		public void UpdateWorldTransform(float x, float y, float rotation, float scaleX, float scaleY, float shearX, float shearY)
		{
			this.ax = x;
			this.ay = y;
			this.arotation = rotation;
			this.ascaleX = scaleX;
			this.ascaleY = scaleY;
			this.ashearX = shearX;
			this.ashearY = shearY;
			this.appliedValid = true;
			Skeleton skeleton = this.skeleton;
			Bone bone = this.parent;
			if (bone == null)
			{
				float degrees = rotation + 90f + shearY;
				float num = MathUtils.CosDeg(rotation + shearX) * scaleX;
				float num2 = MathUtils.CosDeg(degrees) * scaleY;
				float num3 = MathUtils.SinDeg(rotation + shearX) * scaleX;
				float num4 = MathUtils.SinDeg(degrees) * scaleY;
				if (skeleton.flipX)
				{
					x = -x;
					num = -num;
					num2 = -num2;
				}
				if (skeleton.flipY != Bone.yDown)
				{
					y = -y;
					num3 = -num3;
					num4 = -num4;
				}
				this.a = num;
				this.b = num2;
				this.c = num3;
				this.d = num4;
				this.worldX = x + skeleton.x;
				this.worldY = y + skeleton.y;
				return;
			}
			float num5 = bone.a;
			float num6 = bone.b;
			float num7 = bone.c;
			float num8 = bone.d;
			this.worldX = num5 * x + num6 * y + bone.worldX;
			this.worldY = num7 * x + num8 * y + bone.worldY;
			switch (this.data.transformMode)
			{
			case TransformMode.Normal:
			{
				float degrees2 = rotation + 90f + shearY;
				float num9 = MathUtils.CosDeg(rotation + shearX) * scaleX;
				float num10 = MathUtils.CosDeg(degrees2) * scaleY;
				float num11 = MathUtils.SinDeg(rotation + shearX) * scaleX;
				float num12 = MathUtils.SinDeg(degrees2) * scaleY;
				this.a = num5 * num9 + num6 * num11;
				this.b = num5 * num10 + num6 * num12;
				this.c = num7 * num9 + num8 * num11;
				this.d = num7 * num10 + num8 * num12;
				return;
			}
			case TransformMode.NoRotationOrReflection:
			{
				float num13 = num5 * num5 + num7 * num7;
				float num14;
				if (num13 > 0.0001f)
				{
					num13 = Math.Abs(num5 * num8 - num6 * num7) / num13;
					num6 = num7 * num13;
					num8 = num5 * num13;
					num14 = MathUtils.Atan2(num7, num5) * 57.295776f;
				}
				else
				{
					num5 = 0f;
					num7 = 0f;
					num14 = 90f - MathUtils.Atan2(num8, num6) * 57.295776f;
				}
				float degrees3 = rotation + shearX - num14;
				float degrees4 = rotation + shearY - num14 + 90f;
				float num15 = MathUtils.CosDeg(degrees3) * scaleX;
				float num16 = MathUtils.CosDeg(degrees4) * scaleY;
				float num17 = MathUtils.SinDeg(degrees3) * scaleX;
				float num18 = MathUtils.SinDeg(degrees4) * scaleY;
				this.a = num5 * num15 - num6 * num17;
				this.b = num5 * num16 - num6 * num18;
				this.c = num7 * num15 + num8 * num17;
				this.d = num7 * num16 + num8 * num18;
				break;
			}
			case TransformMode.NoScale:
			case TransformMode.NoScaleOrReflection:
			{
				float num19 = MathUtils.CosDeg(rotation);
				float num20 = MathUtils.SinDeg(rotation);
				float num21 = num5 * num19 + num6 * num20;
				float num22 = num7 * num19 + num8 * num20;
				float num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
				if (num23 > 1E-05f)
				{
					num23 = 1f / num23;
				}
				num21 *= num23;
				num22 *= num23;
				num23 = (float)Math.Sqrt((double)(num21 * num21 + num22 * num22));
				float radians = 1.5707964f + MathUtils.Atan2(num22, num21);
				float num24 = MathUtils.Cos(radians) * num23;
				float num25 = MathUtils.Sin(radians) * num23;
				float num26 = MathUtils.CosDeg(shearX) * scaleX;
				float num27 = MathUtils.CosDeg(90f + shearY) * scaleY;
				float num28 = MathUtils.SinDeg(shearX) * scaleX;
				float num29 = MathUtils.SinDeg(90f + shearY) * scaleY;
				if ((this.data.transformMode == TransformMode.NoScaleOrReflection) ? (skeleton.flipX != skeleton.flipY) : (num5 * num8 - num6 * num7 < 0f))
				{
					num24 = -num24;
					num25 = -num25;
				}
				this.a = num21 * num26 + num24 * num28;
				this.b = num21 * num27 + num24 * num29;
				this.c = num22 * num26 + num25 * num28;
				this.d = num22 * num27 + num25 * num29;
				return;
			}
			case TransformMode.OnlyTranslation:
			{
				float degrees5 = rotation + 90f + shearY;
				this.a = MathUtils.CosDeg(rotation + shearX) * scaleX;
				this.b = MathUtils.CosDeg(degrees5) * scaleY;
				this.c = MathUtils.SinDeg(rotation + shearX) * scaleX;
				this.d = MathUtils.SinDeg(degrees5) * scaleY;
				break;
			}
			}
			if (skeleton.flipX)
			{
				this.a = -this.a;
				this.b = -this.b;
			}
			if (skeleton.flipY != Bone.yDown)
			{
				this.c = -this.c;
				this.d = -this.d;
			}
		}

		// Token: 0x0601B26C RID: 111212 RVA: 0x008587CC File Offset: 0x00856BCC
		public void SetToSetupPose()
		{
			BoneData boneData = this.data;
			this.x = boneData.x;
			this.y = boneData.y;
			this.rotation = boneData.rotation;
			this.scaleX = boneData.scaleX;
			this.scaleY = boneData.scaleY;
			this.shearX = boneData.shearX;
			this.shearY = boneData.shearY;
		}

		// Token: 0x0601B26D RID: 111213 RVA: 0x00858834 File Offset: 0x00856C34
		internal void UpdateAppliedTransform()
		{
			this.appliedValid = true;
			Bone bone = this.parent;
			if (bone == null)
			{
				this.ax = this.worldX;
				this.ay = this.worldY;
				this.arotation = MathUtils.Atan2(this.c, this.a) * 57.295776f;
				this.ascaleX = (float)Math.Sqrt((double)(this.a * this.a + this.c * this.c));
				this.ascaleY = (float)Math.Sqrt((double)(this.b * this.b + this.d * this.d));
				this.ashearX = 0f;
				this.ashearY = MathUtils.Atan2(this.a * this.b + this.c * this.d, this.a * this.d - this.b * this.c) * 57.295776f;
				return;
			}
			float num = bone.a;
			float num2 = bone.b;
			float num3 = bone.c;
			float num4 = bone.d;
			float num5 = 1f / (num * num4 - num2 * num3);
			float num6 = this.worldX - bone.worldX;
			float num7 = this.worldY - bone.worldY;
			this.ax = num6 * num4 * num5 - num7 * num2 * num5;
			this.ay = num7 * num * num5 - num6 * num3 * num5;
			float num8 = num5 * num4;
			float num9 = num5 * num;
			float num10 = num5 * num2;
			float num11 = num5 * num3;
			float num12 = num8 * this.a - num10 * this.c;
			float num13 = num8 * this.b - num10 * this.d;
			float num14 = num9 * this.c - num11 * this.a;
			float num15 = num9 * this.d - num11 * this.b;
			this.ashearX = 0f;
			this.ascaleX = (float)Math.Sqrt((double)(num12 * num12 + num14 * num14));
			if (this.ascaleX > 0.0001f)
			{
				float num16 = num12 * num15 - num13 * num14;
				this.ascaleY = num16 / this.ascaleX;
				this.ashearY = MathUtils.Atan2(num12 * num13 + num14 * num15, num16) * 57.295776f;
				this.arotation = MathUtils.Atan2(num14, num12) * 57.295776f;
			}
			else
			{
				this.ascaleX = 0f;
				this.ascaleY = (float)Math.Sqrt((double)(num13 * num13 + num15 * num15));
				this.ashearY = 0f;
				this.arotation = 90f - MathUtils.Atan2(num15, num13) * 57.295776f;
			}
		}

		// Token: 0x0601B26E RID: 111214 RVA: 0x00858AE0 File Offset: 0x00856EE0
		public void WorldToLocal(float worldX, float worldY, out float localX, out float localY)
		{
			float num = this.a;
			float num2 = this.b;
			float num3 = this.c;
			float num4 = this.d;
			float num5 = 1f / (num * num4 - num2 * num3);
			float num6 = worldX - this.worldX;
			float num7 = worldY - this.worldY;
			localX = num6 * num4 * num5 - num7 * num2 * num5;
			localY = num7 * num * num5 - num6 * num3 * num5;
		}

		// Token: 0x0601B26F RID: 111215 RVA: 0x00858B4F File Offset: 0x00856F4F
		public void LocalToWorld(float localX, float localY, out float worldX, out float worldY)
		{
			worldX = localX * this.a + localY * this.b + this.worldX;
			worldY = localX * this.c + localY * this.d + this.worldY;
		}

		// Token: 0x1700236C RID: 9068
		// (get) Token: 0x0601B270 RID: 111216 RVA: 0x00858B88 File Offset: 0x00856F88
		public float WorldToLocalRotationX
		{
			get
			{
				Bone bone = this.parent;
				if (bone == null)
				{
					return this.arotation;
				}
				float num = bone.a;
				float num2 = bone.b;
				float num3 = bone.c;
				float num4 = bone.d;
				float num5 = this.a;
				float num6 = this.c;
				return MathUtils.Atan2(num * num6 - num3 * num5, num4 * num5 - num2 * num6) * 57.295776f;
			}
		}

		// Token: 0x1700236D RID: 9069
		// (get) Token: 0x0601B271 RID: 111217 RVA: 0x00858BF4 File Offset: 0x00856FF4
		public float WorldToLocalRotationY
		{
			get
			{
				Bone bone = this.parent;
				if (bone == null)
				{
					return this.arotation;
				}
				float num = bone.a;
				float num2 = bone.b;
				float num3 = bone.c;
				float num4 = bone.d;
				float num5 = this.b;
				float num6 = this.d;
				return MathUtils.Atan2(num * num6 - num3 * num5, num4 * num5 - num2 * num6) * 57.295776f;
			}
		}

		// Token: 0x0601B272 RID: 111218 RVA: 0x00858C60 File Offset: 0x00857060
		public float WorldToLocalRotation(float worldRotation)
		{
			float num = MathUtils.SinDeg(worldRotation);
			float num2 = MathUtils.CosDeg(worldRotation);
			return MathUtils.Atan2(this.a * num - this.c * num2, this.d * num2 - this.b * num) * 57.295776f;
		}

		// Token: 0x0601B273 RID: 111219 RVA: 0x00858CA8 File Offset: 0x008570A8
		public float LocalToWorldRotation(float localRotation)
		{
			float num = MathUtils.SinDeg(localRotation);
			float num2 = MathUtils.CosDeg(localRotation);
			return MathUtils.Atan2(num2 * this.c + num * this.d, num2 * this.a + num * this.b) * 57.295776f;
		}

		// Token: 0x0601B274 RID: 111220 RVA: 0x00858CF0 File Offset: 0x008570F0
		public void RotateWorld(float degrees)
		{
			float num = this.a;
			float num2 = this.b;
			float num3 = this.c;
			float num4 = this.d;
			float num5 = MathUtils.CosDeg(degrees);
			float num6 = MathUtils.SinDeg(degrees);
			this.a = num5 * num - num6 * num3;
			this.b = num5 * num2 - num6 * num4;
			this.c = num6 * num + num5 * num3;
			this.d = num6 * num2 + num5 * num4;
			this.appliedValid = false;
		}

		// Token: 0x0601B275 RID: 111221 RVA: 0x00858D6C File Offset: 0x0085716C
		public override string ToString()
		{
			return this.data.name;
		}

		// Token: 0x04012EEE RID: 77550
		public static bool yDown;

		// Token: 0x04012EEF RID: 77551
		internal BoneData data;

		// Token: 0x04012EF0 RID: 77552
		internal Skeleton skeleton;

		// Token: 0x04012EF1 RID: 77553
		internal Bone parent;

		// Token: 0x04012EF2 RID: 77554
		internal ExposedList<Bone> children = new ExposedList<Bone>();

		// Token: 0x04012EF3 RID: 77555
		internal float x;

		// Token: 0x04012EF4 RID: 77556
		internal float y;

		// Token: 0x04012EF5 RID: 77557
		internal float rotation;

		// Token: 0x04012EF6 RID: 77558
		internal float scaleX;

		// Token: 0x04012EF7 RID: 77559
		internal float scaleY;

		// Token: 0x04012EF8 RID: 77560
		internal float shearX;

		// Token: 0x04012EF9 RID: 77561
		internal float shearY;

		// Token: 0x04012EFA RID: 77562
		internal float ax;

		// Token: 0x04012EFB RID: 77563
		internal float ay;

		// Token: 0x04012EFC RID: 77564
		internal float arotation;

		// Token: 0x04012EFD RID: 77565
		internal float ascaleX;

		// Token: 0x04012EFE RID: 77566
		internal float ascaleY;

		// Token: 0x04012EFF RID: 77567
		internal float ashearX;

		// Token: 0x04012F00 RID: 77568
		internal float ashearY;

		// Token: 0x04012F01 RID: 77569
		internal bool appliedValid;

		// Token: 0x04012F02 RID: 77570
		internal float a;

		// Token: 0x04012F03 RID: 77571
		internal float b;

		// Token: 0x04012F04 RID: 77572
		internal float worldX;

		// Token: 0x04012F05 RID: 77573
		internal float c;

		// Token: 0x04012F06 RID: 77574
		internal float d;

		// Token: 0x04012F07 RID: 77575
		internal float worldY;

		// Token: 0x04012F08 RID: 77576
		internal bool sorted;
	}
}
