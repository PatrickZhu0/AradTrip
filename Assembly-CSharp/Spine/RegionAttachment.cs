using System;

namespace Spine
{
	// Token: 0x020049B8 RID: 18872
	public class RegionAttachment : Attachment, IHasRendererObject
	{
		// Token: 0x0601B206 RID: 111110 RVA: 0x00857B68 File Offset: 0x00855F68
		public RegionAttachment(string name) : base(name)
		{
		}

		// Token: 0x17002337 RID: 9015
		// (get) Token: 0x0601B207 RID: 111111 RVA: 0x00857BD6 File Offset: 0x00855FD6
		// (set) Token: 0x0601B208 RID: 111112 RVA: 0x00857BDE File Offset: 0x00855FDE
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

		// Token: 0x17002338 RID: 9016
		// (get) Token: 0x0601B209 RID: 111113 RVA: 0x00857BE7 File Offset: 0x00855FE7
		// (set) Token: 0x0601B20A RID: 111114 RVA: 0x00857BEF File Offset: 0x00855FEF
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

		// Token: 0x17002339 RID: 9017
		// (get) Token: 0x0601B20B RID: 111115 RVA: 0x00857BF8 File Offset: 0x00855FF8
		// (set) Token: 0x0601B20C RID: 111116 RVA: 0x00857C00 File Offset: 0x00856000
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

		// Token: 0x1700233A RID: 9018
		// (get) Token: 0x0601B20D RID: 111117 RVA: 0x00857C09 File Offset: 0x00856009
		// (set) Token: 0x0601B20E RID: 111118 RVA: 0x00857C11 File Offset: 0x00856011
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

		// Token: 0x1700233B RID: 9019
		// (get) Token: 0x0601B20F RID: 111119 RVA: 0x00857C1A File Offset: 0x0085601A
		// (set) Token: 0x0601B210 RID: 111120 RVA: 0x00857C22 File Offset: 0x00856022
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

		// Token: 0x1700233C RID: 9020
		// (get) Token: 0x0601B211 RID: 111121 RVA: 0x00857C2B File Offset: 0x0085602B
		// (set) Token: 0x0601B212 RID: 111122 RVA: 0x00857C33 File Offset: 0x00856033
		public float Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		// Token: 0x1700233D RID: 9021
		// (get) Token: 0x0601B213 RID: 111123 RVA: 0x00857C3C File Offset: 0x0085603C
		// (set) Token: 0x0601B214 RID: 111124 RVA: 0x00857C44 File Offset: 0x00856044
		public float Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		// Token: 0x1700233E RID: 9022
		// (get) Token: 0x0601B215 RID: 111125 RVA: 0x00857C4D File Offset: 0x0085604D
		// (set) Token: 0x0601B216 RID: 111126 RVA: 0x00857C55 File Offset: 0x00856055
		public float R
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x1700233F RID: 9023
		// (get) Token: 0x0601B217 RID: 111127 RVA: 0x00857C5E File Offset: 0x0085605E
		// (set) Token: 0x0601B218 RID: 111128 RVA: 0x00857C66 File Offset: 0x00856066
		public float G
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x17002340 RID: 9024
		// (get) Token: 0x0601B219 RID: 111129 RVA: 0x00857C6F File Offset: 0x0085606F
		// (set) Token: 0x0601B21A RID: 111130 RVA: 0x00857C77 File Offset: 0x00856077
		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x17002341 RID: 9025
		// (get) Token: 0x0601B21B RID: 111131 RVA: 0x00857C80 File Offset: 0x00856080
		// (set) Token: 0x0601B21C RID: 111132 RVA: 0x00857C88 File Offset: 0x00856088
		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17002342 RID: 9026
		// (get) Token: 0x0601B21D RID: 111133 RVA: 0x00857C91 File Offset: 0x00856091
		// (set) Token: 0x0601B21E RID: 111134 RVA: 0x00857C99 File Offset: 0x00856099
		public string Path { get; set; }

		// Token: 0x17002343 RID: 9027
		// (get) Token: 0x0601B21F RID: 111135 RVA: 0x00857CA2 File Offset: 0x008560A2
		// (set) Token: 0x0601B220 RID: 111136 RVA: 0x00857CAA File Offset: 0x008560AA
		public object RendererObject { get; set; }

		// Token: 0x17002344 RID: 9028
		// (get) Token: 0x0601B221 RID: 111137 RVA: 0x00857CB3 File Offset: 0x008560B3
		// (set) Token: 0x0601B222 RID: 111138 RVA: 0x00857CBB File Offset: 0x008560BB
		public float RegionOffsetX
		{
			get
			{
				return this.regionOffsetX;
			}
			set
			{
				this.regionOffsetX = value;
			}
		}

		// Token: 0x17002345 RID: 9029
		// (get) Token: 0x0601B223 RID: 111139 RVA: 0x00857CC4 File Offset: 0x008560C4
		// (set) Token: 0x0601B224 RID: 111140 RVA: 0x00857CCC File Offset: 0x008560CC
		public float RegionOffsetY
		{
			get
			{
				return this.regionOffsetY;
			}
			set
			{
				this.regionOffsetY = value;
			}
		}

		// Token: 0x17002346 RID: 9030
		// (get) Token: 0x0601B225 RID: 111141 RVA: 0x00857CD5 File Offset: 0x008560D5
		// (set) Token: 0x0601B226 RID: 111142 RVA: 0x00857CDD File Offset: 0x008560DD
		public float RegionWidth
		{
			get
			{
				return this.regionWidth;
			}
			set
			{
				this.regionWidth = value;
			}
		}

		// Token: 0x17002347 RID: 9031
		// (get) Token: 0x0601B227 RID: 111143 RVA: 0x00857CE6 File Offset: 0x008560E6
		// (set) Token: 0x0601B228 RID: 111144 RVA: 0x00857CEE File Offset: 0x008560EE
		public float RegionHeight
		{
			get
			{
				return this.regionHeight;
			}
			set
			{
				this.regionHeight = value;
			}
		}

		// Token: 0x17002348 RID: 9032
		// (get) Token: 0x0601B229 RID: 111145 RVA: 0x00857CF7 File Offset: 0x008560F7
		// (set) Token: 0x0601B22A RID: 111146 RVA: 0x00857CFF File Offset: 0x008560FF
		public float RegionOriginalWidth
		{
			get
			{
				return this.regionOriginalWidth;
			}
			set
			{
				this.regionOriginalWidth = value;
			}
		}

		// Token: 0x17002349 RID: 9033
		// (get) Token: 0x0601B22B RID: 111147 RVA: 0x00857D08 File Offset: 0x00856108
		// (set) Token: 0x0601B22C RID: 111148 RVA: 0x00857D10 File Offset: 0x00856110
		public float RegionOriginalHeight
		{
			get
			{
				return this.regionOriginalHeight;
			}
			set
			{
				this.regionOriginalHeight = value;
			}
		}

		// Token: 0x1700234A RID: 9034
		// (get) Token: 0x0601B22D RID: 111149 RVA: 0x00857D19 File Offset: 0x00856119
		public float[] Offset
		{
			get
			{
				return this.offset;
			}
		}

		// Token: 0x1700234B RID: 9035
		// (get) Token: 0x0601B22E RID: 111150 RVA: 0x00857D21 File Offset: 0x00856121
		public float[] UVs
		{
			get
			{
				return this.uvs;
			}
		}

		// Token: 0x0601B22F RID: 111151 RVA: 0x00857D2C File Offset: 0x0085612C
		public void UpdateOffset()
		{
			float num = this.width;
			float num2 = this.height;
			float num3 = num * 0.5f;
			float num4 = num2 * 0.5f;
			float num5 = -num3;
			float num6 = -num4;
			if (this.regionOriginalWidth != 0f)
			{
				num5 += this.regionOffsetX / this.regionOriginalWidth * num;
				num6 += this.regionOffsetY / this.regionOriginalHeight * num2;
				num3 -= (this.regionOriginalWidth - this.regionOffsetX - this.regionWidth) / this.regionOriginalWidth * num;
				num4 -= (this.regionOriginalHeight - this.regionOffsetY - this.regionHeight) / this.regionOriginalHeight * num2;
			}
			float num7 = this.scaleX;
			float num8 = this.scaleY;
			num5 *= num7;
			num6 *= num8;
			num3 *= num7;
			num4 *= num8;
			float degrees = this.rotation;
			float num9 = MathUtils.CosDeg(degrees);
			float num10 = MathUtils.SinDeg(degrees);
			float num11 = this.x;
			float num12 = this.y;
			float num13 = num5 * num9 + num11;
			float num14 = num5 * num10;
			float num15 = num6 * num9 + num12;
			float num16 = num6 * num10;
			float num17 = num3 * num9 + num11;
			float num18 = num3 * num10;
			float num19 = num4 * num9 + num12;
			float num20 = num4 * num10;
			float[] array = this.offset;
			array[0] = num13 - num16;
			array[1] = num15 + num14;
			array[2] = num13 - num20;
			array[3] = num19 + num14;
			array[4] = num17 - num20;
			array[5] = num19 + num18;
			array[6] = num17 - num16;
			array[7] = num15 + num18;
		}

		// Token: 0x0601B230 RID: 111152 RVA: 0x00857EBC File Offset: 0x008562BC
		public void SetUVs(float u, float v, float u2, float v2, bool rotate)
		{
			float[] array = this.uvs;
			if (rotate)
			{
				array[4] = u;
				array[5] = v2;
				array[6] = u;
				array[7] = v;
				array[0] = u2;
				array[1] = v;
				array[2] = u2;
				array[3] = v2;
			}
			else
			{
				array[2] = u;
				array[3] = v2;
				array[4] = u;
				array[5] = v;
				array[6] = u2;
				array[7] = v;
				array[0] = u2;
				array[1] = v2;
			}
		}

		// Token: 0x0601B231 RID: 111153 RVA: 0x00857F20 File Offset: 0x00856320
		public void ComputeWorldVertices(Bone bone, float[] worldVertices, int offset, int stride = 2)
		{
			float[] array = this.offset;
			float worldX = bone.worldX;
			float worldY = bone.worldY;
			float num = bone.a;
			float num2 = bone.b;
			float c = bone.c;
			float d = bone.d;
			float num3 = array[6];
			float num4 = array[7];
			worldVertices[offset] = num3 * num + num4 * num2 + worldX;
			worldVertices[offset + 1] = num3 * c + num4 * d + worldY;
			offset += stride;
			num3 = array[0];
			num4 = array[1];
			worldVertices[offset] = num3 * num + num4 * num2 + worldX;
			worldVertices[offset + 1] = num3 * c + num4 * d + worldY;
			offset += stride;
			num3 = array[2];
			num4 = array[3];
			worldVertices[offset] = num3 * num + num4 * num2 + worldX;
			worldVertices[offset + 1] = num3 * c + num4 * d + worldY;
			offset += stride;
			num3 = array[4];
			num4 = array[5];
			worldVertices[offset] = num3 * num + num4 * num2 + worldX;
			worldVertices[offset + 1] = num3 * c + num4 * d + worldY;
		}

		// Token: 0x04012EC6 RID: 77510
		public const int BLX = 0;

		// Token: 0x04012EC7 RID: 77511
		public const int BLY = 1;

		// Token: 0x04012EC8 RID: 77512
		public const int ULX = 2;

		// Token: 0x04012EC9 RID: 77513
		public const int ULY = 3;

		// Token: 0x04012ECA RID: 77514
		public const int URX = 4;

		// Token: 0x04012ECB RID: 77515
		public const int URY = 5;

		// Token: 0x04012ECC RID: 77516
		public const int BRX = 6;

		// Token: 0x04012ECD RID: 77517
		public const int BRY = 7;

		// Token: 0x04012ECE RID: 77518
		internal float x;

		// Token: 0x04012ECF RID: 77519
		internal float y;

		// Token: 0x04012ED0 RID: 77520
		internal float rotation;

		// Token: 0x04012ED1 RID: 77521
		internal float scaleX = 1f;

		// Token: 0x04012ED2 RID: 77522
		internal float scaleY = 1f;

		// Token: 0x04012ED3 RID: 77523
		internal float width;

		// Token: 0x04012ED4 RID: 77524
		internal float height;

		// Token: 0x04012ED5 RID: 77525
		internal float regionOffsetX;

		// Token: 0x04012ED6 RID: 77526
		internal float regionOffsetY;

		// Token: 0x04012ED7 RID: 77527
		internal float regionWidth;

		// Token: 0x04012ED8 RID: 77528
		internal float regionHeight;

		// Token: 0x04012ED9 RID: 77529
		internal float regionOriginalWidth;

		// Token: 0x04012EDA RID: 77530
		internal float regionOriginalHeight;

		// Token: 0x04012EDB RID: 77531
		internal float[] offset = new float[8];

		// Token: 0x04012EDC RID: 77532
		internal float[] uvs = new float[8];

		// Token: 0x04012EDD RID: 77533
		internal float r = 1f;

		// Token: 0x04012EDE RID: 77534
		internal float g = 1f;

		// Token: 0x04012EDF RID: 77535
		internal float b = 1f;

		// Token: 0x04012EE0 RID: 77536
		internal float a = 1f;
	}
}
