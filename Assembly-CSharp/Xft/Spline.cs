using System;
using System.Collections.Generic;
using UnityEngine;

namespace Xft
{
	// Token: 0x02000D9E RID: 3486
	public class Spline
	{
		// Token: 0x170018BA RID: 6330
		public SplineControlPoint this[int index]
		{
			get
			{
				if (index > -1 && index < this.mSegments.Count)
				{
					return this.mSegments[index];
				}
				return null;
			}
		}

		// Token: 0x170018BB RID: 6331
		// (get) Token: 0x06008D32 RID: 36146 RVA: 0x001A3E28 File Offset: 0x001A2228
		public List<SplineControlPoint> Segments
		{
			get
			{
				return this.mSegments;
			}
		}

		// Token: 0x170018BC RID: 6332
		// (get) Token: 0x06008D33 RID: 36147 RVA: 0x001A3E30 File Offset: 0x001A2230
		public List<SplineControlPoint> ControlPoints
		{
			get
			{
				return this.mControlPoints;
			}
		}

		// Token: 0x06008D34 RID: 36148 RVA: 0x001A3E38 File Offset: 0x001A2238
		public SplineControlPoint NextControlPoint(SplineControlPoint controlpoint)
		{
			if (this.mControlPoints.Count == 0)
			{
				return null;
			}
			int num = controlpoint.ControlPointIndex + 1;
			if (num >= this.mControlPoints.Count)
			{
				return null;
			}
			return this.mControlPoints[num];
		}

		// Token: 0x06008D35 RID: 36149 RVA: 0x001A3E80 File Offset: 0x001A2280
		public SplineControlPoint PreviousControlPoint(SplineControlPoint controlpoint)
		{
			if (this.mControlPoints.Count == 0)
			{
				return null;
			}
			int num = controlpoint.ControlPointIndex - 1;
			if (num < 0)
			{
				return null;
			}
			return this.mControlPoints[num];
		}

		// Token: 0x06008D36 RID: 36150 RVA: 0x001A3EC0 File Offset: 0x001A22C0
		public Vector3 NextPosition(SplineControlPoint controlpoint)
		{
			SplineControlPoint splineControlPoint = this.NextControlPoint(controlpoint);
			if (splineControlPoint != null)
			{
				return splineControlPoint.Position;
			}
			return controlpoint.Position;
		}

		// Token: 0x06008D37 RID: 36151 RVA: 0x001A3EE8 File Offset: 0x001A22E8
		public Vector3 PreviousPosition(SplineControlPoint controlpoint)
		{
			SplineControlPoint splineControlPoint = this.PreviousControlPoint(controlpoint);
			if (splineControlPoint != null)
			{
				return splineControlPoint.Position;
			}
			return controlpoint.Position;
		}

		// Token: 0x06008D38 RID: 36152 RVA: 0x001A3F10 File Offset: 0x001A2310
		public Vector3 PreviousNormal(SplineControlPoint controlpoint)
		{
			SplineControlPoint splineControlPoint = this.PreviousControlPoint(controlpoint);
			if (splineControlPoint != null)
			{
				return splineControlPoint.Normal;
			}
			return controlpoint.Normal;
		}

		// Token: 0x06008D39 RID: 36153 RVA: 0x001A3F38 File Offset: 0x001A2338
		public Vector3 NextNormal(SplineControlPoint controlpoint)
		{
			SplineControlPoint splineControlPoint = this.NextControlPoint(controlpoint);
			if (splineControlPoint != null)
			{
				return splineControlPoint.Normal;
			}
			return controlpoint.Normal;
		}

		// Token: 0x06008D3A RID: 36154 RVA: 0x001A3F60 File Offset: 0x001A2360
		public SplineControlPoint LenToSegment(float t, out float localF)
		{
			SplineControlPoint splineControlPoint = null;
			t = Mathf.Clamp01(t);
			float num = t * this.mSegments[this.mSegments.Count - 1].Dist;
			int i;
			for (i = 0; i < this.mSegments.Count; i++)
			{
				if (this.mSegments[i].Dist >= num)
				{
					splineControlPoint = this.mSegments[i];
					break;
				}
			}
			if (i == 0)
			{
				localF = 0f;
				return splineControlPoint;
			}
			int index = splineControlPoint.SegmentIndex - 1;
			SplineControlPoint splineControlPoint2 = this.mSegments[index];
			float num2 = splineControlPoint.Dist - splineControlPoint2.Dist;
			localF = (num - splineControlPoint2.Dist) / num2;
			return splineControlPoint2;
		}

		// Token: 0x06008D3B RID: 36155 RVA: 0x001A402C File Offset: 0x001A242C
		public static Vector3 CatmulRom(Vector3 T0, Vector3 P0, Vector3 P1, Vector3 T1, float f)
		{
			double num = -0.5;
			double num2 = 1.5;
			double num3 = -1.5;
			double num4 = 0.5;
			double num5 = -2.5;
			double num6 = 2.0;
			double num7 = -0.5;
			double num8 = -0.5;
			double num9 = 0.5;
			double num10 = num * (double)T0.x + num2 * (double)P0.x + num3 * (double)P1.x + num4 * (double)T1.x;
			double num11 = (double)T0.x + num5 * (double)P0.x + num6 * (double)P1.x + num7 * (double)T1.x;
			double num12 = num8 * (double)T0.x + num9 * (double)P1.x;
			double num13 = (double)P0.x;
			double num14 = num * (double)T0.y + num2 * (double)P0.y + num3 * (double)P1.y + num4 * (double)T1.y;
			double num15 = (double)T0.y + num5 * (double)P0.y + num6 * (double)P1.y + num7 * (double)T1.y;
			double num16 = num8 * (double)T0.y + num9 * (double)P1.y;
			double num17 = (double)P0.y;
			double num18 = num * (double)T0.z + num2 * (double)P0.z + num3 * (double)P1.z + num4 * (double)T1.z;
			double num19 = (double)T0.z + num5 * (double)P0.z + num6 * (double)P1.z + num7 * (double)T1.z;
			double num20 = num8 * (double)T0.z + num9 * (double)P1.z;
			double num21 = (double)P0.z;
			float num22 = (float)(((num10 * (double)f + num11) * (double)f + num12) * (double)f + num13);
			float num23 = (float)(((num14 * (double)f + num15) * (double)f + num16) * (double)f + num17);
			float num24 = (float)(((num18 * (double)f + num19) * (double)f + num20) * (double)f + num21);
			return new Vector3(num22, num23, num24);
		}

		// Token: 0x06008D3C RID: 36156 RVA: 0x001A426C File Offset: 0x001A266C
		public Vector3 InterpolateByLen(float tl)
		{
			float localF;
			SplineControlPoint splineControlPoint = this.LenToSegment(tl, out localF);
			return splineControlPoint.Interpolate(localF);
		}

		// Token: 0x06008D3D RID: 36157 RVA: 0x001A428C File Offset: 0x001A268C
		public Vector3 InterpolateNormalByLen(float tl)
		{
			float localF;
			SplineControlPoint splineControlPoint = this.LenToSegment(tl, out localF);
			return splineControlPoint.InterpolateNormal(localF);
		}

		// Token: 0x06008D3E RID: 36158 RVA: 0x001A42AC File Offset: 0x001A26AC
		public SplineControlPoint AddControlPoint(Vector3 pos, Vector3 up)
		{
			SplineControlPoint splineControlPoint = new SplineControlPoint();
			splineControlPoint.Init(this);
			splineControlPoint.Position = pos;
			splineControlPoint.Normal = up;
			this.mControlPoints.Add(splineControlPoint);
			splineControlPoint.ControlPointIndex = this.mControlPoints.Count - 1;
			return splineControlPoint;
		}

		// Token: 0x06008D3F RID: 36159 RVA: 0x001A42F4 File Offset: 0x001A26F4
		public void Clear()
		{
			this.mControlPoints.Clear();
		}

		// Token: 0x06008D40 RID: 36160 RVA: 0x001A4304 File Offset: 0x001A2704
		private void RefreshDistance()
		{
			if (this.mSegments.Count < 1)
			{
				return;
			}
			this.mSegments[0].Dist = 0f;
			for (int i = 1; i < this.mSegments.Count; i++)
			{
				float magnitude = (this.mSegments[i].Position - this.mSegments[i - 1].Position).magnitude;
				this.mSegments[i].Dist = this.mSegments[i - 1].Dist + magnitude;
			}
		}

		// Token: 0x06008D41 RID: 36161 RVA: 0x001A43B0 File Offset: 0x001A27B0
		public void RefreshSpline()
		{
			this.mSegments.Clear();
			for (int i = 0; i < this.mControlPoints.Count; i++)
			{
				if (this.mControlPoints[i].IsValid)
				{
					this.mSegments.Add(this.mControlPoints[i]);
					this.mControlPoints[i].SegmentIndex = this.mSegments.Count - 1;
				}
			}
			this.RefreshDistance();
		}

		// Token: 0x040045F6 RID: 17910
		private List<SplineControlPoint> mControlPoints = new List<SplineControlPoint>();

		// Token: 0x040045F7 RID: 17911
		private List<SplineControlPoint> mSegments = new List<SplineControlPoint>();

		// Token: 0x040045F8 RID: 17912
		public int Granularity = 20;
	}
}
