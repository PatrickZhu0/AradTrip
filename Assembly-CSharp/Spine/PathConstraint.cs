using System;

namespace Spine
{
	// Token: 0x020049CB RID: 18891
	public class PathConstraint : IConstraint, IUpdatable
	{
		// Token: 0x0601B32E RID: 111406 RVA: 0x0085B3E4 File Offset: 0x008597E4
		public PathConstraint(PathConstraintData data, Skeleton skeleton)
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
			this.bones = new ExposedList<Bone>(data.Bones.Count);
			foreach (BoneData boneData in data.bones)
			{
				this.bones.Add(skeleton.FindBone(boneData.name));
			}
			this.target = skeleton.FindSlot(data.target.name);
			this.position = data.position;
			this.spacing = data.spacing;
			this.rotateMix = data.rotateMix;
			this.translateMix = data.translateMix;
		}

		// Token: 0x17002398 RID: 9112
		// (get) Token: 0x0601B32F RID: 111407 RVA: 0x0085B52C File Offset: 0x0085992C
		public int Order
		{
			get
			{
				return this.data.order;
			}
		}

		// Token: 0x17002399 RID: 9113
		// (get) Token: 0x0601B330 RID: 111408 RVA: 0x0085B539 File Offset: 0x00859939
		// (set) Token: 0x0601B331 RID: 111409 RVA: 0x0085B541 File Offset: 0x00859941
		public float Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		// Token: 0x1700239A RID: 9114
		// (get) Token: 0x0601B332 RID: 111410 RVA: 0x0085B54A File Offset: 0x0085994A
		// (set) Token: 0x0601B333 RID: 111411 RVA: 0x0085B552 File Offset: 0x00859952
		public float Spacing
		{
			get
			{
				return this.spacing;
			}
			set
			{
				this.spacing = value;
			}
		}

		// Token: 0x1700239B RID: 9115
		// (get) Token: 0x0601B334 RID: 111412 RVA: 0x0085B55B File Offset: 0x0085995B
		// (set) Token: 0x0601B335 RID: 111413 RVA: 0x0085B563 File Offset: 0x00859963
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

		// Token: 0x1700239C RID: 9116
		// (get) Token: 0x0601B336 RID: 111414 RVA: 0x0085B56C File Offset: 0x0085996C
		// (set) Token: 0x0601B337 RID: 111415 RVA: 0x0085B574 File Offset: 0x00859974
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

		// Token: 0x1700239D RID: 9117
		// (get) Token: 0x0601B338 RID: 111416 RVA: 0x0085B57D File Offset: 0x0085997D
		public ExposedList<Bone> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x1700239E RID: 9118
		// (get) Token: 0x0601B339 RID: 111417 RVA: 0x0085B585 File Offset: 0x00859985
		// (set) Token: 0x0601B33A RID: 111418 RVA: 0x0085B58D File Offset: 0x0085998D
		public Slot Target
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

		// Token: 0x1700239F RID: 9119
		// (get) Token: 0x0601B33B RID: 111419 RVA: 0x0085B596 File Offset: 0x00859996
		public PathConstraintData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x0601B33C RID: 111420 RVA: 0x0085B59E File Offset: 0x0085999E
		public void Apply()
		{
			this.Update();
		}

		// Token: 0x0601B33D RID: 111421 RVA: 0x0085B5A8 File Offset: 0x008599A8
		public void Update()
		{
			PathAttachment pathAttachment = this.target.Attachment as PathAttachment;
			if (pathAttachment == null)
			{
				return;
			}
			float num = this.rotateMix;
			float num2 = this.translateMix;
			bool flag = num2 > 0f;
			bool flag2 = num > 0f;
			if (!flag && !flag2)
			{
				return;
			}
			PathConstraintData pathConstraintData = this.data;
			SpacingMode spacingMode = pathConstraintData.spacingMode;
			bool flag3 = spacingMode == SpacingMode.Length;
			RotateMode rotateMode = pathConstraintData.rotateMode;
			bool flag4 = rotateMode == RotateMode.Tangent;
			bool flag5 = rotateMode == RotateMode.ChainScale;
			int count = this.bones.Count;
			int num3 = (!flag4) ? (count + 1) : count;
			Bone[] items = this.bones.Items;
			ExposedList<float> exposedList = this.spaces.Resize(num3);
			ExposedList<float> exposedList2 = null;
			float num4 = this.spacing;
			if (flag5 || flag3)
			{
				if (flag5)
				{
					exposedList2 = this.lengths.Resize(count);
				}
				int i = 0;
				int num5 = num3 - 1;
				while (i < num5)
				{
					Bone bone = items[i];
					float length = bone.data.length;
					if (length < 1E-05f)
					{
						if (flag5)
						{
							exposedList2.Items[i] = 0f;
						}
						exposedList.Items[++i] = 0f;
					}
					else
					{
						float num6 = length * bone.a;
						float num7 = length * bone.c;
						float num8 = (float)Math.Sqrt((double)(num6 * num6 + num7 * num7));
						if (flag5)
						{
							exposedList2.Items[i] = num8;
						}
						exposedList.Items[++i] = ((!flag3) ? num4 : (length + num4)) * num8 / length;
					}
				}
			}
			else
			{
				for (int j = 1; j < num3; j++)
				{
					exposedList.Items[j] = num4;
				}
			}
			float[] array = this.ComputeWorldPositions(pathAttachment, num3, flag4, pathConstraintData.positionMode == PositionMode.Percent, spacingMode == SpacingMode.Percent);
			float num9 = array[0];
			float num10 = array[1];
			float num11 = pathConstraintData.offsetRotation;
			bool flag6;
			if (num11 == 0f)
			{
				flag6 = (rotateMode == RotateMode.Chain);
			}
			else
			{
				flag6 = false;
				Bone bone2 = this.target.bone;
				num11 *= ((bone2.a * bone2.d - bone2.b * bone2.c <= 0f) ? -0.017453292f : 0.017453292f);
			}
			int k = 0;
			int num12 = 3;
			while (k < count)
			{
				Bone bone3 = items[k];
				bone3.worldX += (num9 - bone3.worldX) * num2;
				bone3.worldY += (num10 - bone3.worldY) * num2;
				float num13 = array[num12];
				float num14 = array[num12 + 1];
				float num15 = num13 - num9;
				float num16 = num14 - num10;
				if (flag5)
				{
					float num17 = exposedList2.Items[k];
					if (num17 >= 1E-05f)
					{
						float num18 = ((float)Math.Sqrt((double)(num15 * num15 + num16 * num16)) / num17 - 1f) * num + 1f;
						bone3.a *= num18;
						bone3.c *= num18;
					}
				}
				num9 = num13;
				num10 = num14;
				if (flag2)
				{
					float a = bone3.a;
					float b = bone3.b;
					float c = bone3.c;
					float d = bone3.d;
					float num19;
					if (flag4)
					{
						num19 = array[num12 - 1];
					}
					else if (exposedList.Items[k + 1] < 1E-05f)
					{
						num19 = array[num12 + 2];
					}
					else
					{
						num19 = MathUtils.Atan2(num16, num15);
					}
					num19 -= MathUtils.Atan2(c, a);
					float num20;
					float num21;
					if (flag6)
					{
						num20 = MathUtils.Cos(num19);
						num21 = MathUtils.Sin(num19);
						float length2 = bone3.data.length;
						num9 += (length2 * (num20 * a - num21 * c) - num15) * num;
						num10 += (length2 * (num21 * a + num20 * c) - num16) * num;
					}
					else
					{
						num19 += num11;
					}
					if (num19 > 3.1415927f)
					{
						num19 -= 6.2831855f;
					}
					else if (num19 < -3.1415927f)
					{
						num19 += 6.2831855f;
					}
					num19 *= num;
					num20 = MathUtils.Cos(num19);
					num21 = MathUtils.Sin(num19);
					bone3.a = num20 * a - num21 * c;
					bone3.b = num20 * b - num21 * d;
					bone3.c = num21 * a + num20 * c;
					bone3.d = num21 * b + num20 * d;
				}
				bone3.appliedValid = false;
				k++;
				num12 += 3;
			}
		}

		// Token: 0x0601B33E RID: 111422 RVA: 0x0085BA84 File Offset: 0x00859E84
		private float[] ComputeWorldPositions(PathAttachment path, int spacesCount, bool tangents, bool percentPosition, bool percentSpacing)
		{
			Slot slot = this.target;
			float num = this.position;
			float[] items = this.spaces.Items;
			float[] items2 = this.positions.Resize(spacesCount * 3 + 2).Items;
			bool closed = path.Closed;
			int num2 = path.WorldVerticesLength;
			int num3 = num2 / 6;
			int num4 = -1;
			float num5;
			float[] items3;
			if (!path.ConstantSpeed)
			{
				float[] array = path.Lengths;
				num3 -= ((!closed) ? 2 : 1);
				num5 = array[num3];
				if (percentPosition)
				{
					num *= num5;
				}
				if (percentSpacing)
				{
					for (int i = 0; i < spacesCount; i++)
					{
						items[i] *= num5;
					}
				}
				items3 = this.world.Resize(8).Items;
				int j = 0;
				int num6 = 0;
				int num7 = 0;
				while (j < spacesCount)
				{
					float num8 = items[j];
					num += num8;
					float num9 = num;
					if (closed)
					{
						num9 %= num5;
						if (num9 < 0f)
						{
							num9 += num5;
						}
						num7 = 0;
						goto IL_178;
					}
					if (num9 < 0f)
					{
						if (num4 != -2)
						{
							num4 = -2;
							path.ComputeWorldVertices(slot, 2, 4, items3, 0, 2);
						}
						PathConstraint.AddBeforePosition(num9, items3, 0, items2, num6);
					}
					else
					{
						if (num9 <= num5)
						{
							goto IL_178;
						}
						if (num4 != -3)
						{
							num4 = -3;
							path.ComputeWorldVertices(slot, num2 - 6, 4, items3, 0, 2);
						}
						PathConstraint.AddAfterPosition(num9 - num5, items3, 0, items2, num6);
					}
					IL_263:
					j++;
					num6 += 3;
					continue;
					IL_178:
					float num10;
					for (;;)
					{
						num10 = array[num7];
						if (num9 <= num10)
						{
							break;
						}
						num7++;
					}
					if (num7 == 0)
					{
						num9 /= num10;
					}
					else
					{
						float num11 = array[num7 - 1];
						num9 = (num9 - num11) / (num10 - num11);
					}
					if (num7 != num4)
					{
						num4 = num7;
						if (closed && num7 == num3)
						{
							path.ComputeWorldVertices(slot, num2 - 4, 4, items3, 0, 2);
							path.ComputeWorldVertices(slot, 0, 4, items3, 4, 2);
						}
						else
						{
							path.ComputeWorldVertices(slot, num7 * 6 + 2, 8, items3, 0, 2);
						}
					}
					PathConstraint.AddCurvePosition(num9, items3[0], items3[1], items3[2], items3[3], items3[4], items3[5], items3[6], items3[7], items2, num6, tangents || (j > 0 && num8 < 1E-05f));
					goto IL_263;
				}
				return items2;
			}
			if (closed)
			{
				num2 += 2;
				items3 = this.world.Resize(num2).Items;
				path.ComputeWorldVertices(slot, 2, num2 - 4, items3, 0, 2);
				path.ComputeWorldVertices(slot, 0, 2, items3, num2 - 4, 2);
				items3[num2 - 2] = items3[0];
				items3[num2 - 1] = items3[1];
			}
			else
			{
				num3--;
				num2 -= 4;
				items3 = this.world.Resize(num2).Items;
				path.ComputeWorldVertices(slot, 2, num2, items3, 0, 2);
			}
			float[] items4 = this.curves.Resize(num3).Items;
			num5 = 0f;
			float num12 = items3[0];
			float num13 = items3[1];
			float num14 = 0f;
			float num15 = 0f;
			float num16 = 0f;
			float num17 = 0f;
			float num18 = 0f;
			float num19 = 0f;
			int k = 0;
			int num20 = 2;
			while (k < num3)
			{
				num14 = items3[num20];
				num15 = items3[num20 + 1];
				num16 = items3[num20 + 2];
				num17 = items3[num20 + 3];
				num18 = items3[num20 + 4];
				num19 = items3[num20 + 5];
				float num21 = (num12 - num14 * 2f + num16) * 0.1875f;
				float num22 = (num13 - num15 * 2f + num17) * 0.1875f;
				float num23 = ((num14 - num16) * 3f - num12 + num18) * 0.09375f;
				float num24 = ((num15 - num17) * 3f - num13 + num19) * 0.09375f;
				float num25 = num21 * 2f + num23;
				float num26 = num22 * 2f + num24;
				float num27 = (num14 - num12) * 0.75f + num21 + num23 * 0.16666667f;
				float num28 = (num15 - num13) * 0.75f + num22 + num24 * 0.16666667f;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25;
				num28 += num26;
				num25 += num23;
				num26 += num24;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25;
				num28 += num26;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				num27 += num25 + num23;
				num28 += num26 + num24;
				num5 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
				items4[k] = num5;
				num12 = num18;
				num13 = num19;
				k++;
				num20 += 6;
			}
			if (percentPosition)
			{
				num *= num5;
			}
			if (percentSpacing)
			{
				for (int l = 0; l < spacesCount; l++)
				{
					items[l] *= num5;
				}
			}
			float[] array2 = this.segments;
			float num29 = 0f;
			int m = 0;
			int num30 = 0;
			int num31 = 0;
			int num32 = 0;
			while (m < spacesCount)
			{
				float num33 = items[m];
				num += num33;
				float num34 = num;
				if (closed)
				{
					num34 %= num5;
					if (num34 < 0f)
					{
						num34 += num5;
					}
					num31 = 0;
					goto IL_5C8;
				}
				if (num34 < 0f)
				{
					PathConstraint.AddBeforePosition(num34, items3, 0, items2, num30);
				}
				else
				{
					if (num34 <= num5)
					{
						goto IL_5C8;
					}
					PathConstraint.AddAfterPosition(num34 - num5, items3, num2 - 4, items2, num30);
				}
				IL_883:
				m++;
				num30 += 3;
				continue;
				IL_5C8:
				float num35;
				for (;;)
				{
					num35 = items4[num31];
					if (num34 <= num35)
					{
						break;
					}
					num31++;
				}
				if (num31 == 0)
				{
					num34 /= num35;
				}
				else
				{
					float num36 = items4[num31 - 1];
					num34 = (num34 - num36) / (num35 - num36);
				}
				if (num31 != num4)
				{
					num4 = num31;
					int n = num31 * 6;
					num12 = items3[n];
					num13 = items3[n + 1];
					num14 = items3[n + 2];
					num15 = items3[n + 3];
					num16 = items3[n + 4];
					num17 = items3[n + 5];
					num18 = items3[n + 6];
					num19 = items3[n + 7];
					float num21 = (num12 - num14 * 2f + num16) * 0.03f;
					float num22 = (num13 - num15 * 2f + num17) * 0.03f;
					float num23 = ((num14 - num16) * 3f - num12 + num18) * 0.006f;
					float num24 = ((num15 - num17) * 3f - num13 + num19) * 0.006f;
					float num25 = num21 * 2f + num23;
					float num26 = num22 * 2f + num24;
					float num27 = (num14 - num12) * 0.3f + num21 + num23 * 0.16666667f;
					float num28 = (num15 - num13) * 0.3f + num22 + num24 * 0.16666667f;
					num29 = (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[0] = num29;
					for (n = 1; n < 8; n++)
					{
						num27 += num25;
						num28 += num26;
						num25 += num23;
						num26 += num24;
						num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
						array2[n] = num29;
					}
					num27 += num25;
					num28 += num26;
					num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[8] = num29;
					num27 += num25 + num23;
					num28 += num26 + num24;
					num29 += (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
					array2[9] = num29;
					num32 = 0;
				}
				num34 *= num29;
				float num37;
				for (;;)
				{
					num37 = array2[num32];
					if (num34 <= num37)
					{
						break;
					}
					num32++;
				}
				if (num32 == 0)
				{
					num34 /= num37;
				}
				else
				{
					float num38 = array2[num32 - 1];
					num34 = (float)num32 + (num34 - num38) / (num37 - num38);
				}
				PathConstraint.AddCurvePosition(num34 * 0.1f, num12, num13, num14, num15, num16, num17, num18, num19, items2, num30, tangents || (m > 0 && num33 < 1E-05f));
				goto IL_883;
			}
			return items2;
		}

		// Token: 0x0601B33F RID: 111423 RVA: 0x0085C32C File Offset: 0x0085A72C
		private static void AddBeforePosition(float p, float[] temp, int i, float[] output, int o)
		{
			float num = temp[i];
			float num2 = temp[i + 1];
			float x = temp[i + 2] - num;
			float y = temp[i + 3] - num2;
			float num3 = MathUtils.Atan2(y, x);
			output[o] = num + p * MathUtils.Cos(num3);
			output[o + 1] = num2 + p * MathUtils.Sin(num3);
			output[o + 2] = num3;
		}

		// Token: 0x0601B340 RID: 111424 RVA: 0x0085C384 File Offset: 0x0085A784
		private static void AddAfterPosition(float p, float[] temp, int i, float[] output, int o)
		{
			float num = temp[i + 2];
			float num2 = temp[i + 3];
			float x = num - temp[i];
			float y = num2 - temp[i + 1];
			float num3 = MathUtils.Atan2(y, x);
			output[o] = num + p * MathUtils.Cos(num3);
			output[o + 1] = num2 + p * MathUtils.Sin(num3);
			output[o + 2] = num3;
		}

		// Token: 0x0601B341 RID: 111425 RVA: 0x0085C3DC File Offset: 0x0085A7DC
		private static void AddCurvePosition(float p, float x1, float y1, float cx1, float cy1, float cx2, float cy2, float x2, float y2, float[] output, int o, bool tangents)
		{
			if (p < 1E-05f || float.IsNaN(p))
			{
				p = 1E-05f;
			}
			float num = p * p;
			float num2 = num * p;
			float num3 = 1f - p;
			float num4 = num3 * num3;
			float num5 = num4 * num3;
			float num6 = num3 * p;
			float num7 = num6 * 3f;
			float num8 = num3 * num7;
			float num9 = num7 * p;
			float num10 = x1 * num5 + cx1 * num8 + cx2 * num9 + x2 * num2;
			float num11 = y1 * num5 + cy1 * num8 + cy2 * num9 + y2 * num2;
			output[o] = num10;
			output[o + 1] = num11;
			if (tangents)
			{
				output[o + 2] = (float)Math.Atan2((double)(num11 - (y1 * num4 + cy1 * num6 * 2f + cy2 * num)), (double)(num10 - (x1 * num4 + cx1 * num6 * 2f + cx2 * num)));
			}
		}

		// Token: 0x04012F5A RID: 77658
		private const int NONE = -1;

		// Token: 0x04012F5B RID: 77659
		private const int BEFORE = -2;

		// Token: 0x04012F5C RID: 77660
		private const int AFTER = -3;

		// Token: 0x04012F5D RID: 77661
		private const float Epsilon = 1E-05f;

		// Token: 0x04012F5E RID: 77662
		internal PathConstraintData data;

		// Token: 0x04012F5F RID: 77663
		internal ExposedList<Bone> bones;

		// Token: 0x04012F60 RID: 77664
		internal Slot target;

		// Token: 0x04012F61 RID: 77665
		internal float position;

		// Token: 0x04012F62 RID: 77666
		internal float spacing;

		// Token: 0x04012F63 RID: 77667
		internal float rotateMix;

		// Token: 0x04012F64 RID: 77668
		internal float translateMix;

		// Token: 0x04012F65 RID: 77669
		internal ExposedList<float> spaces = new ExposedList<float>();

		// Token: 0x04012F66 RID: 77670
		internal ExposedList<float> positions = new ExposedList<float>();

		// Token: 0x04012F67 RID: 77671
		internal ExposedList<float> world = new ExposedList<float>();

		// Token: 0x04012F68 RID: 77672
		internal ExposedList<float> curves = new ExposedList<float>();

		// Token: 0x04012F69 RID: 77673
		internal ExposedList<float> lengths = new ExposedList<float>();

		// Token: 0x04012F6A RID: 77674
		internal float[] segments = new float[10];
	}
}
