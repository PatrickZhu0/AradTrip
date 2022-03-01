using System;

namespace Spine
{
	// Token: 0x020049D3 RID: 18899
	public class SkeletonBounds
	{
		// Token: 0x0601B3A9 RID: 111529 RVA: 0x0085FA56 File Offset: 0x0085DE56
		public SkeletonBounds()
		{
			this.BoundingBoxes = new ExposedList<BoundingBoxAttachment>();
			this.Polygons = new ExposedList<Polygon>();
		}

		// Token: 0x170023C0 RID: 9152
		// (get) Token: 0x0601B3AA RID: 111530 RVA: 0x0085FA7F File Offset: 0x0085DE7F
		// (set) Token: 0x0601B3AB RID: 111531 RVA: 0x0085FA87 File Offset: 0x0085DE87
		public ExposedList<BoundingBoxAttachment> BoundingBoxes { get; private set; }

		// Token: 0x170023C1 RID: 9153
		// (get) Token: 0x0601B3AC RID: 111532 RVA: 0x0085FA90 File Offset: 0x0085DE90
		// (set) Token: 0x0601B3AD RID: 111533 RVA: 0x0085FA98 File Offset: 0x0085DE98
		public ExposedList<Polygon> Polygons { get; private set; }

		// Token: 0x170023C2 RID: 9154
		// (get) Token: 0x0601B3AE RID: 111534 RVA: 0x0085FAA1 File Offset: 0x0085DEA1
		// (set) Token: 0x0601B3AF RID: 111535 RVA: 0x0085FAA9 File Offset: 0x0085DEA9
		public float MinX
		{
			get
			{
				return this.minX;
			}
			set
			{
				this.minX = value;
			}
		}

		// Token: 0x170023C3 RID: 9155
		// (get) Token: 0x0601B3B0 RID: 111536 RVA: 0x0085FAB2 File Offset: 0x0085DEB2
		// (set) Token: 0x0601B3B1 RID: 111537 RVA: 0x0085FABA File Offset: 0x0085DEBA
		public float MinY
		{
			get
			{
				return this.minY;
			}
			set
			{
				this.minY = value;
			}
		}

		// Token: 0x170023C4 RID: 9156
		// (get) Token: 0x0601B3B2 RID: 111538 RVA: 0x0085FAC3 File Offset: 0x0085DEC3
		// (set) Token: 0x0601B3B3 RID: 111539 RVA: 0x0085FACB File Offset: 0x0085DECB
		public float MaxX
		{
			get
			{
				return this.maxX;
			}
			set
			{
				this.maxX = value;
			}
		}

		// Token: 0x170023C5 RID: 9157
		// (get) Token: 0x0601B3B4 RID: 111540 RVA: 0x0085FAD4 File Offset: 0x0085DED4
		// (set) Token: 0x0601B3B5 RID: 111541 RVA: 0x0085FADC File Offset: 0x0085DEDC
		public float MaxY
		{
			get
			{
				return this.maxY;
			}
			set
			{
				this.maxY = value;
			}
		}

		// Token: 0x170023C6 RID: 9158
		// (get) Token: 0x0601B3B6 RID: 111542 RVA: 0x0085FAE5 File Offset: 0x0085DEE5
		public float Width
		{
			get
			{
				return this.maxX - this.minX;
			}
		}

		// Token: 0x170023C7 RID: 9159
		// (get) Token: 0x0601B3B7 RID: 111543 RVA: 0x0085FAF4 File Offset: 0x0085DEF4
		public float Height
		{
			get
			{
				return this.maxY - this.minY;
			}
		}

		// Token: 0x0601B3B8 RID: 111544 RVA: 0x0085FB04 File Offset: 0x0085DF04
		public void Update(Skeleton skeleton, bool updateAabb)
		{
			ExposedList<BoundingBoxAttachment> boundingBoxes = this.BoundingBoxes;
			ExposedList<Polygon> polygons = this.Polygons;
			ExposedList<Slot> slots = skeleton.slots;
			int count = slots.Count;
			boundingBoxes.Clear(true);
			int i = 0;
			int count2 = polygons.Count;
			while (i < count2)
			{
				this.polygonPool.Add(polygons.Items[i]);
				i++;
			}
			polygons.Clear(true);
			for (int j = 0; j < count; j++)
			{
				Slot slot = slots.Items[j];
				BoundingBoxAttachment boundingBoxAttachment = slot.attachment as BoundingBoxAttachment;
				if (boundingBoxAttachment != null)
				{
					boundingBoxes.Add(boundingBoxAttachment);
					int count3 = this.polygonPool.Count;
					Polygon polygon;
					if (count3 > 0)
					{
						polygon = this.polygonPool.Items[count3 - 1];
						this.polygonPool.RemoveAt(count3 - 1);
					}
					else
					{
						polygon = new Polygon();
					}
					polygons.Add(polygon);
					int worldVerticesLength = boundingBoxAttachment.worldVerticesLength;
					polygon.Count = worldVerticesLength;
					if (polygon.Vertices.Length < worldVerticesLength)
					{
						polygon.Vertices = new float[worldVerticesLength];
					}
					boundingBoxAttachment.ComputeWorldVertices(slot, polygon.Vertices);
				}
			}
			if (updateAabb)
			{
				this.AabbCompute();
			}
			else
			{
				this.minX = -2.1474836E+09f;
				this.minY = -2.1474836E+09f;
				this.maxX = 2.1474836E+09f;
				this.maxY = 2.1474836E+09f;
			}
		}

		// Token: 0x0601B3B9 RID: 111545 RVA: 0x0085FC7C File Offset: 0x0085E07C
		private void AabbCompute()
		{
			float val = 2.1474836E+09f;
			float val2 = 2.1474836E+09f;
			float val3 = -2.1474836E+09f;
			float val4 = -2.1474836E+09f;
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				Polygon polygon = polygons.Items[i];
				float[] vertices = polygon.Vertices;
				int j = 0;
				int count2 = polygon.Count;
				while (j < count2)
				{
					float val5 = vertices[j];
					float val6 = vertices[j + 1];
					val = Math.Min(val, val5);
					val2 = Math.Min(val2, val6);
					val3 = Math.Max(val3, val5);
					val4 = Math.Max(val4, val6);
					j += 2;
				}
				i++;
			}
			this.minX = val;
			this.minY = val2;
			this.maxX = val3;
			this.maxY = val4;
		}

		// Token: 0x0601B3BA RID: 111546 RVA: 0x0085FD4E File Offset: 0x0085E14E
		public bool AabbContainsPoint(float x, float y)
		{
			return x >= this.minX && x <= this.maxX && y >= this.minY && y <= this.maxY;
		}

		// Token: 0x0601B3BB RID: 111547 RVA: 0x0085FD84 File Offset: 0x0085E184
		public bool AabbIntersectsSegment(float x1, float y1, float x2, float y2)
		{
			float num = this.minX;
			float num2 = this.minY;
			float num3 = this.maxX;
			float num4 = this.maxY;
			if ((x1 <= num && x2 <= num) || (y1 <= num2 && y2 <= num2) || (x1 >= num3 && x2 >= num3) || (y1 >= num4 && y2 >= num4))
			{
				return false;
			}
			float num5 = (y2 - y1) / (x2 - x1);
			float num6 = num5 * (num - x1) + y1;
			if (num6 > num2 && num6 < num4)
			{
				return true;
			}
			num6 = num5 * (num3 - x1) + y1;
			if (num6 > num2 && num6 < num4)
			{
				return true;
			}
			float num7 = (num2 - y1) / num5 + x1;
			if (num7 > num && num7 < num3)
			{
				return true;
			}
			num7 = (num4 - y1) / num5 + x1;
			return num7 > num && num7 < num3;
		}

		// Token: 0x0601B3BC RID: 111548 RVA: 0x0085FE64 File Offset: 0x0085E264
		public bool AabbIntersectsSkeleton(SkeletonBounds bounds)
		{
			return this.minX < bounds.maxX && this.maxX > bounds.minX && this.minY < bounds.maxY && this.maxY > bounds.minY;
		}

		// Token: 0x0601B3BD RID: 111549 RVA: 0x0085FEB8 File Offset: 0x0085E2B8
		public bool ContainsPoint(Polygon polygon, float x, float y)
		{
			float[] vertices = polygon.Vertices;
			int count = polygon.Count;
			int num = count - 2;
			bool flag = false;
			for (int i = 0; i < count; i += 2)
			{
				float num2 = vertices[i + 1];
				float num3 = vertices[num + 1];
				if ((num2 < y && num3 >= y) || (num3 < y && num2 >= y))
				{
					float num4 = vertices[i];
					if (num4 + (y - num2) / (num3 - num2) * (vertices[num] - num4) < x)
					{
						flag = !flag;
					}
				}
				num = i;
			}
			return flag;
		}

		// Token: 0x0601B3BE RID: 111550 RVA: 0x0085FF48 File Offset: 0x0085E348
		public BoundingBoxAttachment ContainsPoint(float x, float y)
		{
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				if (this.ContainsPoint(polygons.Items[i], x, y))
				{
					return this.BoundingBoxes.Items[i];
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3BF RID: 111551 RVA: 0x0085FF9C File Offset: 0x0085E39C
		public BoundingBoxAttachment IntersectsSegment(float x1, float y1, float x2, float y2)
		{
			ExposedList<Polygon> polygons = this.Polygons;
			int i = 0;
			int count = polygons.Count;
			while (i < count)
			{
				if (this.IntersectsSegment(polygons.Items[i], x1, y1, x2, y2))
				{
					return this.BoundingBoxes.Items[i];
				}
				i++;
			}
			return null;
		}

		// Token: 0x0601B3C0 RID: 111552 RVA: 0x0085FFF0 File Offset: 0x0085E3F0
		public bool IntersectsSegment(Polygon polygon, float x1, float y1, float x2, float y2)
		{
			float[] vertices = polygon.Vertices;
			int count = polygon.Count;
			float num = x1 - x2;
			float num2 = y1 - y2;
			float num3 = x1 * y2 - y1 * x2;
			float num4 = vertices[count - 2];
			float num5 = vertices[count - 1];
			for (int i = 0; i < count; i += 2)
			{
				float num6 = vertices[i];
				float num7 = vertices[i + 1];
				float num8 = num4 * num7 - num5 * num6;
				float num9 = num4 - num6;
				float num10 = num5 - num7;
				float num11 = num * num10 - num2 * num9;
				float num12 = (num3 * num9 - num * num8) / num11;
				if (((num12 >= num4 && num12 <= num6) || (num12 >= num6 && num12 <= num4)) && ((num12 >= x1 && num12 <= x2) || (num12 >= x2 && num12 <= x1)))
				{
					float num13 = (num3 * num10 - num2 * num8) / num11;
					if (((num13 >= num5 && num13 <= num7) || (num13 >= num7 && num13 <= num5)) && ((num13 >= y1 && num13 <= y2) || (num13 >= y2 && num13 <= y1)))
					{
						return true;
					}
				}
				num4 = num6;
				num5 = num7;
			}
			return false;
		}

		// Token: 0x0601B3C1 RID: 111553 RVA: 0x00860130 File Offset: 0x0085E530
		public Polygon GetPolygon(BoundingBoxAttachment attachment)
		{
			int num = this.BoundingBoxes.IndexOf(attachment);
			return (num != -1) ? this.Polygons.Items[num] : null;
		}

		// Token: 0x04012FA9 RID: 77737
		private ExposedList<Polygon> polygonPool = new ExposedList<Polygon>();

		// Token: 0x04012FAA RID: 77738
		private float minX;

		// Token: 0x04012FAB RID: 77739
		private float minY;

		// Token: 0x04012FAC RID: 77740
		private float maxX;

		// Token: 0x04012FAD RID: 77741
		private float maxY;
	}
}
