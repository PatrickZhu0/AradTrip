using System;

namespace Spine
{
	// Token: 0x020049B5 RID: 18869
	public class MeshAttachment : VertexAttachment, IHasRendererObject
	{
		// Token: 0x0601B1BF RID: 111039 RVA: 0x008576EE File Offset: 0x00855AEE
		public MeshAttachment(string name) : base(name)
		{
		}

		// Token: 0x17002317 RID: 8983
		// (get) Token: 0x0601B1C0 RID: 111040 RVA: 0x00857723 File Offset: 0x00855B23
		// (set) Token: 0x0601B1C1 RID: 111041 RVA: 0x0085772B File Offset: 0x00855B2B
		public int HullLength
		{
			get
			{
				return this.hulllength;
			}
			set
			{
				this.hulllength = value;
			}
		}

		// Token: 0x17002318 RID: 8984
		// (get) Token: 0x0601B1C2 RID: 111042 RVA: 0x00857734 File Offset: 0x00855B34
		// (set) Token: 0x0601B1C3 RID: 111043 RVA: 0x0085773C File Offset: 0x00855B3C
		public float[] RegionUVs
		{
			get
			{
				return this.regionUVs;
			}
			set
			{
				this.regionUVs = value;
			}
		}

		// Token: 0x17002319 RID: 8985
		// (get) Token: 0x0601B1C4 RID: 111044 RVA: 0x00857745 File Offset: 0x00855B45
		// (set) Token: 0x0601B1C5 RID: 111045 RVA: 0x0085774D File Offset: 0x00855B4D
		public float[] UVs
		{
			get
			{
				return this.uvs;
			}
			set
			{
				this.uvs = value;
			}
		}

		// Token: 0x1700231A RID: 8986
		// (get) Token: 0x0601B1C6 RID: 111046 RVA: 0x00857756 File Offset: 0x00855B56
		// (set) Token: 0x0601B1C7 RID: 111047 RVA: 0x0085775E File Offset: 0x00855B5E
		public int[] Triangles
		{
			get
			{
				return this.triangles;
			}
			set
			{
				this.triangles = value;
			}
		}

		// Token: 0x1700231B RID: 8987
		// (get) Token: 0x0601B1C8 RID: 111048 RVA: 0x00857767 File Offset: 0x00855B67
		// (set) Token: 0x0601B1C9 RID: 111049 RVA: 0x0085776F File Offset: 0x00855B6F
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

		// Token: 0x1700231C RID: 8988
		// (get) Token: 0x0601B1CA RID: 111050 RVA: 0x00857778 File Offset: 0x00855B78
		// (set) Token: 0x0601B1CB RID: 111051 RVA: 0x00857780 File Offset: 0x00855B80
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

		// Token: 0x1700231D RID: 8989
		// (get) Token: 0x0601B1CC RID: 111052 RVA: 0x00857789 File Offset: 0x00855B89
		// (set) Token: 0x0601B1CD RID: 111053 RVA: 0x00857791 File Offset: 0x00855B91
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

		// Token: 0x1700231E RID: 8990
		// (get) Token: 0x0601B1CE RID: 111054 RVA: 0x0085779A File Offset: 0x00855B9A
		// (set) Token: 0x0601B1CF RID: 111055 RVA: 0x008577A2 File Offset: 0x00855BA2
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

		// Token: 0x1700231F RID: 8991
		// (get) Token: 0x0601B1D0 RID: 111056 RVA: 0x008577AB File Offset: 0x00855BAB
		// (set) Token: 0x0601B1D1 RID: 111057 RVA: 0x008577B3 File Offset: 0x00855BB3
		public string Path { get; set; }

		// Token: 0x17002320 RID: 8992
		// (get) Token: 0x0601B1D2 RID: 111058 RVA: 0x008577BC File Offset: 0x00855BBC
		// (set) Token: 0x0601B1D3 RID: 111059 RVA: 0x008577C4 File Offset: 0x00855BC4
		public object RendererObject { get; set; }

		// Token: 0x17002321 RID: 8993
		// (get) Token: 0x0601B1D4 RID: 111060 RVA: 0x008577CD File Offset: 0x00855BCD
		// (set) Token: 0x0601B1D5 RID: 111061 RVA: 0x008577D5 File Offset: 0x00855BD5
		public float RegionU { get; set; }

		// Token: 0x17002322 RID: 8994
		// (get) Token: 0x0601B1D6 RID: 111062 RVA: 0x008577DE File Offset: 0x00855BDE
		// (set) Token: 0x0601B1D7 RID: 111063 RVA: 0x008577E6 File Offset: 0x00855BE6
		public float RegionV { get; set; }

		// Token: 0x17002323 RID: 8995
		// (get) Token: 0x0601B1D8 RID: 111064 RVA: 0x008577EF File Offset: 0x00855BEF
		// (set) Token: 0x0601B1D9 RID: 111065 RVA: 0x008577F7 File Offset: 0x00855BF7
		public float RegionU2 { get; set; }

		// Token: 0x17002324 RID: 8996
		// (get) Token: 0x0601B1DA RID: 111066 RVA: 0x00857800 File Offset: 0x00855C00
		// (set) Token: 0x0601B1DB RID: 111067 RVA: 0x00857808 File Offset: 0x00855C08
		public float RegionV2 { get; set; }

		// Token: 0x17002325 RID: 8997
		// (get) Token: 0x0601B1DC RID: 111068 RVA: 0x00857811 File Offset: 0x00855C11
		// (set) Token: 0x0601B1DD RID: 111069 RVA: 0x00857819 File Offset: 0x00855C19
		public bool RegionRotate { get; set; }

		// Token: 0x17002326 RID: 8998
		// (get) Token: 0x0601B1DE RID: 111070 RVA: 0x00857822 File Offset: 0x00855C22
		// (set) Token: 0x0601B1DF RID: 111071 RVA: 0x0085782A File Offset: 0x00855C2A
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

		// Token: 0x17002327 RID: 8999
		// (get) Token: 0x0601B1E0 RID: 111072 RVA: 0x00857833 File Offset: 0x00855C33
		// (set) Token: 0x0601B1E1 RID: 111073 RVA: 0x0085783B File Offset: 0x00855C3B
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

		// Token: 0x17002328 RID: 9000
		// (get) Token: 0x0601B1E2 RID: 111074 RVA: 0x00857844 File Offset: 0x00855C44
		// (set) Token: 0x0601B1E3 RID: 111075 RVA: 0x0085784C File Offset: 0x00855C4C
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

		// Token: 0x17002329 RID: 9001
		// (get) Token: 0x0601B1E4 RID: 111076 RVA: 0x00857855 File Offset: 0x00855C55
		// (set) Token: 0x0601B1E5 RID: 111077 RVA: 0x0085785D File Offset: 0x00855C5D
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

		// Token: 0x1700232A RID: 9002
		// (get) Token: 0x0601B1E6 RID: 111078 RVA: 0x00857866 File Offset: 0x00855C66
		// (set) Token: 0x0601B1E7 RID: 111079 RVA: 0x0085786E File Offset: 0x00855C6E
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

		// Token: 0x1700232B RID: 9003
		// (get) Token: 0x0601B1E8 RID: 111080 RVA: 0x00857877 File Offset: 0x00855C77
		// (set) Token: 0x0601B1E9 RID: 111081 RVA: 0x0085787F File Offset: 0x00855C7F
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

		// Token: 0x1700232C RID: 9004
		// (get) Token: 0x0601B1EA RID: 111082 RVA: 0x00857888 File Offset: 0x00855C88
		// (set) Token: 0x0601B1EB RID: 111083 RVA: 0x00857890 File Offset: 0x00855C90
		public bool InheritDeform
		{
			get
			{
				return this.inheritDeform;
			}
			set
			{
				this.inheritDeform = value;
			}
		}

		// Token: 0x1700232D RID: 9005
		// (get) Token: 0x0601B1EC RID: 111084 RVA: 0x00857899 File Offset: 0x00855C99
		// (set) Token: 0x0601B1ED RID: 111085 RVA: 0x008578A4 File Offset: 0x00855CA4
		public MeshAttachment ParentMesh
		{
			get
			{
				return this.parentMesh;
			}
			set
			{
				this.parentMesh = value;
				if (value != null)
				{
					this.bones = value.bones;
					this.vertices = value.vertices;
					this.worldVerticesLength = value.worldVerticesLength;
					this.regionUVs = value.regionUVs;
					this.triangles = value.triangles;
					this.HullLength = value.HullLength;
					this.Edges = value.Edges;
					this.Width = value.Width;
					this.Height = value.Height;
				}
			}
		}

		// Token: 0x1700232E RID: 9006
		// (get) Token: 0x0601B1EE RID: 111086 RVA: 0x0085792A File Offset: 0x00855D2A
		// (set) Token: 0x0601B1EF RID: 111087 RVA: 0x00857932 File Offset: 0x00855D32
		public int[] Edges { get; set; }

		// Token: 0x1700232F RID: 9007
		// (get) Token: 0x0601B1F0 RID: 111088 RVA: 0x0085793B File Offset: 0x00855D3B
		// (set) Token: 0x0601B1F1 RID: 111089 RVA: 0x00857943 File Offset: 0x00855D43
		public float Width { get; set; }

		// Token: 0x17002330 RID: 9008
		// (get) Token: 0x0601B1F2 RID: 111090 RVA: 0x0085794C File Offset: 0x00855D4C
		// (set) Token: 0x0601B1F3 RID: 111091 RVA: 0x00857954 File Offset: 0x00855D54
		public float Height { get; set; }

		// Token: 0x0601B1F4 RID: 111092 RVA: 0x00857960 File Offset: 0x00855D60
		public void UpdateUVs()
		{
			float regionU = this.RegionU;
			float regionV = this.RegionV;
			float num = this.RegionU2 - this.RegionU;
			float num2 = this.RegionV2 - this.RegionV;
			float[] array = this.regionUVs;
			if (this.uvs == null || this.uvs.Length != array.Length)
			{
				this.uvs = new float[array.Length];
			}
			float[] array2 = this.uvs;
			if (this.RegionRotate)
			{
				int i = 0;
				int num3 = array2.Length;
				while (i < num3)
				{
					array2[i] = regionU + array[i + 1] * num;
					array2[i + 1] = regionV + num2 - array[i] * num2;
					i += 2;
				}
			}
			else
			{
				int j = 0;
				int num4 = array2.Length;
				while (j < num4)
				{
					array2[j] = regionU + array[j] * num;
					array2[j + 1] = regionV + array[j + 1] * num2;
					j += 2;
				}
			}
		}

		// Token: 0x0601B1F5 RID: 111093 RVA: 0x00857A5E File Offset: 0x00855E5E
		public override bool ApplyDeform(VertexAttachment sourceAttachment)
		{
			return this == sourceAttachment || (this.inheritDeform && this.parentMesh == sourceAttachment);
		}

		// Token: 0x04012EA6 RID: 77478
		internal float regionOffsetX;

		// Token: 0x04012EA7 RID: 77479
		internal float regionOffsetY;

		// Token: 0x04012EA8 RID: 77480
		internal float regionWidth;

		// Token: 0x04012EA9 RID: 77481
		internal float regionHeight;

		// Token: 0x04012EAA RID: 77482
		internal float regionOriginalWidth;

		// Token: 0x04012EAB RID: 77483
		internal float regionOriginalHeight;

		// Token: 0x04012EAC RID: 77484
		private MeshAttachment parentMesh;

		// Token: 0x04012EAD RID: 77485
		internal float[] uvs;

		// Token: 0x04012EAE RID: 77486
		internal float[] regionUVs;

		// Token: 0x04012EAF RID: 77487
		internal int[] triangles;

		// Token: 0x04012EB0 RID: 77488
		internal float r = 1f;

		// Token: 0x04012EB1 RID: 77489
		internal float g = 1f;

		// Token: 0x04012EB2 RID: 77490
		internal float b = 1f;

		// Token: 0x04012EB3 RID: 77491
		internal float a = 1f;

		// Token: 0x04012EB4 RID: 77492
		internal int hulllength;

		// Token: 0x04012EB5 RID: 77493
		internal bool inheritDeform;
	}
}
