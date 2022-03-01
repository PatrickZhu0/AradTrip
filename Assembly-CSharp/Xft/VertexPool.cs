using System;
using System.Collections.Generic;
using UnityEngine;

namespace Xft
{
	// Token: 0x02000DA0 RID: 3488
	public class VertexPool
	{
		// Token: 0x06008D4F RID: 36175 RVA: 0x001A4560 File Offset: 0x001A2960
		public VertexPool(Mesh mesh, Material material)
		{
			this.VertexTotal = (this.VertexUsed = 0);
			this.VertCountChanged = false;
			this.Mesh = mesh;
			this.Material = material;
			this.InitArrays();
			this.IndiceChanged = (this.ColorChanged = (this.UVChanged = (this.UV2Changed = (this.VertChanged = true))));
		}

		// Token: 0x06008D50 RID: 36176 RVA: 0x001A45E6 File Offset: 0x001A29E6
		public void RecalculateBounds()
		{
			this.Mesh.RecalculateBounds();
		}

		// Token: 0x06008D51 RID: 36177 RVA: 0x001A45F4 File Offset: 0x001A29F4
		public VertexPool.VertexSegment GetRopeVertexSeg(int maxcount)
		{
			return this.GetVertices(maxcount * 2, (maxcount - 1) * 6);
		}

		// Token: 0x06008D52 RID: 36178 RVA: 0x001A4611 File Offset: 0x001A2A11
		public Material GetMaterial()
		{
			return this.Material;
		}

		// Token: 0x06008D53 RID: 36179 RVA: 0x001A461C File Offset: 0x001A2A1C
		public VertexPool.VertexSegment GetVertices(int vcount, int icount)
		{
			int num = 0;
			int num2 = 0;
			if (this.VertexUsed + vcount >= this.VertexTotal)
			{
				num = (vcount / 108 + 1) * 108;
			}
			if (this.IndexUsed + icount >= this.IndexTotal)
			{
				num2 = (icount / 108 + 1) * 108;
			}
			this.VertexUsed += vcount;
			this.IndexUsed += icount;
			if (num != 0 || num2 != 0)
			{
				this.EnlargeArrays(num, num2);
				this.VertexTotal += num;
				this.IndexTotal += num2;
			}
			return new VertexPool.VertexSegment(this.VertexUsed - vcount, vcount, this.IndexUsed - icount, icount, this);
		}

		// Token: 0x06008D54 RID: 36180 RVA: 0x001A46D0 File Offset: 0x001A2AD0
		private void InitDefaultShaderParam(Vector2[] uv2)
		{
			for (int i = 0; i < uv2.Length; i++)
			{
				uv2[i].x = 1f;
				uv2[i].y = 0f;
			}
		}

		// Token: 0x06008D55 RID: 36181 RVA: 0x001A4714 File Offset: 0x001A2B14
		protected void InitArrays()
		{
			this.Vertices = new Vector3[4];
			this.UVs = new Vector2[4];
			this.UVs2 = new Vector2[4];
			this.Colors = new Color[4];
			this.Indices = new int[6];
			this.VertexTotal = 4;
			this.IndexTotal = 6;
			this.InitDefaultShaderParam(this.UVs2);
		}

		// Token: 0x06008D56 RID: 36182 RVA: 0x001A4778 File Offset: 0x001A2B78
		public void EnlargeArrays(int count, int icount)
		{
			Vector3[] vertices = this.Vertices;
			this.Vertices = new Vector3[this.Vertices.Length + count];
			vertices.CopyTo(this.Vertices, 0);
			Vector2[] uvs = this.UVs;
			this.UVs = new Vector2[this.UVs.Length + count];
			uvs.CopyTo(this.UVs, 0);
			Vector2[] uvs2 = this.UVs2;
			this.UVs2 = new Vector2[this.UVs2.Length + count];
			uvs2.CopyTo(this.UVs2, 0);
			this.InitDefaultShaderParam(this.UVs2);
			Color[] colors = this.Colors;
			this.Colors = new Color[this.Colors.Length + count];
			colors.CopyTo(this.Colors, 0);
			int[] indices = this.Indices;
			this.Indices = new int[this.Indices.Length + icount];
			indices.CopyTo(this.Indices, 0);
			this.VertCountChanged = true;
			this.IndiceChanged = true;
			this.ColorChanged = true;
			this.UVChanged = true;
			this.VertChanged = true;
			this.UV2Changed = true;
		}

		// Token: 0x06008D57 RID: 36183 RVA: 0x001A488C File Offset: 0x001A2C8C
		public void LateUpdate()
		{
			if (this.VertCountChanged)
			{
				this.Mesh.Clear();
			}
			this.Mesh.vertices = this.Vertices;
			if (this.UVChanged)
			{
				this.Mesh.uv = this.UVs;
			}
			if (this.UV2Changed)
			{
				this.Mesh.uv2 = this.UVs2;
			}
			if (this.ColorChanged)
			{
				this.Mesh.colors = this.Colors;
			}
			if (this.IndiceChanged)
			{
				this.Mesh.triangles = this.Indices;
			}
			this.ElapsedTime += Time.deltaTime;
			if (this.ElapsedTime > this.BoundsScheduleTime || this.FirstUpdate)
			{
				this.RecalculateBounds();
				this.ElapsedTime = 0f;
			}
			if (this.ElapsedTime > this.BoundsScheduleTime)
			{
				this.FirstUpdate = false;
			}
			this.VertCountChanged = false;
			this.IndiceChanged = false;
			this.ColorChanged = false;
			this.UVChanged = false;
			this.UV2Changed = false;
			this.VertChanged = false;
		}

		// Token: 0x040045FF RID: 17919
		public Vector3[] Vertices;

		// Token: 0x04004600 RID: 17920
		public int[] Indices;

		// Token: 0x04004601 RID: 17921
		public Vector2[] UVs;

		// Token: 0x04004602 RID: 17922
		public Color[] Colors;

		// Token: 0x04004603 RID: 17923
		public Vector2[] UVs2;

		// Token: 0x04004604 RID: 17924
		public bool IndiceChanged;

		// Token: 0x04004605 RID: 17925
		public bool ColorChanged;

		// Token: 0x04004606 RID: 17926
		public bool UVChanged;

		// Token: 0x04004607 RID: 17927
		public bool VertChanged;

		// Token: 0x04004608 RID: 17928
		public bool UV2Changed;

		// Token: 0x04004609 RID: 17929
		public Mesh Mesh;

		// Token: 0x0400460A RID: 17930
		public Material Material;

		// Token: 0x0400460B RID: 17931
		protected int VertexTotal;

		// Token: 0x0400460C RID: 17932
		protected int VertexUsed;

		// Token: 0x0400460D RID: 17933
		protected int IndexTotal;

		// Token: 0x0400460E RID: 17934
		protected int IndexUsed;

		// Token: 0x0400460F RID: 17935
		public bool FirstUpdate = true;

		// Token: 0x04004610 RID: 17936
		protected bool VertCountChanged;

		// Token: 0x04004611 RID: 17937
		public const int BlockSize = 108;

		// Token: 0x04004612 RID: 17938
		public float BoundsScheduleTime = 1f;

		// Token: 0x04004613 RID: 17939
		public float ElapsedTime;

		// Token: 0x04004614 RID: 17940
		protected List<VertexPool.VertexSegment> SegmentList = new List<VertexPool.VertexSegment>();

		// Token: 0x02000DA1 RID: 3489
		public class VertexSegment
		{
			// Token: 0x06008D58 RID: 36184 RVA: 0x001A49B1 File Offset: 0x001A2DB1
			public VertexSegment(int start, int count, int istart, int icount, VertexPool pool)
			{
				this.VertStart = start;
				this.VertCount = count;
				this.IndexCount = icount;
				this.IndexStart = istart;
				this.Pool = pool;
			}

			// Token: 0x06008D59 RID: 36185 RVA: 0x001A49E0 File Offset: 0x001A2DE0
			public void ClearIndices()
			{
				for (int i = this.IndexStart; i < this.IndexStart + this.IndexCount; i++)
				{
					this.Pool.Indices[i] = 0;
				}
				this.Pool.IndiceChanged = true;
			}

			// Token: 0x04004615 RID: 17941
			public int VertStart;

			// Token: 0x04004616 RID: 17942
			public int IndexStart;

			// Token: 0x04004617 RID: 17943
			public int VertCount;

			// Token: 0x04004618 RID: 17944
			public int IndexCount;

			// Token: 0x04004619 RID: 17945
			public VertexPool Pool;
		}
	}
}
