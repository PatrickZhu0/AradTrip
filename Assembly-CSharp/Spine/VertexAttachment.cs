using System;

namespace Spine
{
	// Token: 0x020049B9 RID: 18873
	public class VertexAttachment : Attachment
	{
		// Token: 0x0601B232 RID: 111154 RVA: 0x00857310 File Offset: 0x00855710
		public VertexAttachment(string name) : base(name)
		{
			object obj = VertexAttachment.nextIdLock;
			lock (obj)
			{
				this.id = (VertexAttachment.nextID++ & 65535) << 11;
			}
		}

		// Token: 0x1700234C RID: 9036
		// (get) Token: 0x0601B233 RID: 111155 RVA: 0x00857368 File Offset: 0x00855768
		public int Id
		{
			get
			{
				return this.id;
			}
		}

		// Token: 0x1700234D RID: 9037
		// (get) Token: 0x0601B234 RID: 111156 RVA: 0x00857370 File Offset: 0x00855770
		// (set) Token: 0x0601B235 RID: 111157 RVA: 0x00857378 File Offset: 0x00855778
		public int[] Bones
		{
			get
			{
				return this.bones;
			}
			set
			{
				this.bones = value;
			}
		}

		// Token: 0x1700234E RID: 9038
		// (get) Token: 0x0601B236 RID: 111158 RVA: 0x00857381 File Offset: 0x00855781
		// (set) Token: 0x0601B237 RID: 111159 RVA: 0x00857389 File Offset: 0x00855789
		public float[] Vertices
		{
			get
			{
				return this.vertices;
			}
			set
			{
				this.vertices = value;
			}
		}

		// Token: 0x1700234F RID: 9039
		// (get) Token: 0x0601B238 RID: 111160 RVA: 0x00857392 File Offset: 0x00855792
		// (set) Token: 0x0601B239 RID: 111161 RVA: 0x0085739A File Offset: 0x0085579A
		public int WorldVerticesLength
		{
			get
			{
				return this.worldVerticesLength;
			}
			set
			{
				this.worldVerticesLength = value;
			}
		}

		// Token: 0x0601B23A RID: 111162 RVA: 0x008573A3 File Offset: 0x008557A3
		public void ComputeWorldVertices(Slot slot, float[] worldVertices)
		{
			this.ComputeWorldVertices(slot, 0, this.worldVerticesLength, worldVertices, 0, 2);
		}

		// Token: 0x0601B23B RID: 111163 RVA: 0x008573B8 File Offset: 0x008557B8
		public void ComputeWorldVertices(Slot slot, int start, int count, float[] worldVertices, int offset, int stride = 2)
		{
			count = offset + (count >> 1) * stride;
			Skeleton skeleton = slot.bone.skeleton;
			ExposedList<float> attachmentVertices = slot.attachmentVertices;
			float[] items = this.vertices;
			int[] array = this.bones;
			if (array == null)
			{
				if (attachmentVertices.Count > 0)
				{
					items = attachmentVertices.Items;
				}
				Bone bone = slot.bone;
				float worldX = bone.worldX;
				float worldY = bone.worldY;
				float a = bone.a;
				float b = bone.b;
				float c = bone.c;
				float d = bone.d;
				int num = start;
				for (int i = offset; i < count; i += stride)
				{
					float num2 = items[num];
					float num3 = items[num + 1];
					worldVertices[i] = num2 * a + num3 * b + worldX;
					worldVertices[i + 1] = num2 * c + num3 * d + worldY;
					num += 2;
				}
				return;
			}
			int j = 0;
			int num4 = 0;
			for (int k = 0; k < start; k += 2)
			{
				int num5 = array[j];
				j += num5 + 1;
				num4 += num5;
			}
			Bone[] items2 = skeleton.bones.Items;
			if (attachmentVertices.Count == 0)
			{
				int l = offset;
				int num6 = num4 * 3;
				while (l < count)
				{
					float num7 = 0f;
					float num8 = 0f;
					int num9 = array[j++];
					num9 += j;
					while (j < num9)
					{
						Bone bone2 = items2[array[j]];
						float num10 = items[num6];
						float num11 = items[num6 + 1];
						float num12 = items[num6 + 2];
						num7 += (num10 * bone2.a + num11 * bone2.b + bone2.worldX) * num12;
						num8 += (num10 * bone2.c + num11 * bone2.d + bone2.worldY) * num12;
						j++;
						num6 += 3;
					}
					worldVertices[l] = num7;
					worldVertices[l + 1] = num8;
					l += stride;
				}
			}
			else
			{
				float[] items3 = attachmentVertices.Items;
				int m = offset;
				int num13 = num4 * 3;
				int num14 = num4 << 1;
				while (m < count)
				{
					float num15 = 0f;
					float num16 = 0f;
					int num17 = array[j++];
					num17 += j;
					while (j < num17)
					{
						Bone bone3 = items2[array[j]];
						float num18 = items[num13] + items3[num14];
						float num19 = items[num13 + 1] + items3[num14 + 1];
						float num20 = items[num13 + 2];
						num15 += (num18 * bone3.a + num19 * bone3.b + bone3.worldX) * num20;
						num16 += (num18 * bone3.c + num19 * bone3.d + bone3.worldY) * num20;
						j++;
						num13 += 3;
						num14 += 2;
					}
					worldVertices[m] = num15;
					worldVertices[m + 1] = num16;
					m += stride;
				}
			}
		}

		// Token: 0x0601B23C RID: 111164 RVA: 0x008576B3 File Offset: 0x00855AB3
		public virtual bool ApplyDeform(VertexAttachment sourceAttachment)
		{
			return this == sourceAttachment;
		}

		// Token: 0x04012EE3 RID: 77539
		private static int nextID = 0;

		// Token: 0x04012EE4 RID: 77540
		private static readonly object nextIdLock = new object();

		// Token: 0x04012EE5 RID: 77541
		internal readonly int id;

		// Token: 0x04012EE6 RID: 77542
		internal int[] bones;

		// Token: 0x04012EE7 RID: 77543
		internal float[] vertices;

		// Token: 0x04012EE8 RID: 77544
		internal int worldVerticesLength;
	}
}
