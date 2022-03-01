using System;
using UnityEngine;

namespace Xft
{
	// Token: 0x02000D9F RID: 3487
	public class SplineControlPoint
	{
		// Token: 0x170018BD RID: 6333
		// (get) Token: 0x06008D43 RID: 36163 RVA: 0x001A444B File Offset: 0x001A284B
		public SplineControlPoint NextControlPoint
		{
			get
			{
				return this.mSpline.NextControlPoint(this);
			}
		}

		// Token: 0x170018BE RID: 6334
		// (get) Token: 0x06008D44 RID: 36164 RVA: 0x001A4459 File Offset: 0x001A2859
		public SplineControlPoint PreviousControlPoint
		{
			get
			{
				return this.mSpline.PreviousControlPoint(this);
			}
		}

		// Token: 0x170018BF RID: 6335
		// (get) Token: 0x06008D45 RID: 36165 RVA: 0x001A4467 File Offset: 0x001A2867
		public Vector3 NextPosition
		{
			get
			{
				return this.mSpline.NextPosition(this);
			}
		}

		// Token: 0x170018C0 RID: 6336
		// (get) Token: 0x06008D46 RID: 36166 RVA: 0x001A4475 File Offset: 0x001A2875
		public Vector3 PreviousPosition
		{
			get
			{
				return this.mSpline.PreviousPosition(this);
			}
		}

		// Token: 0x170018C1 RID: 6337
		// (get) Token: 0x06008D47 RID: 36167 RVA: 0x001A4483 File Offset: 0x001A2883
		public Vector3 NextNormal
		{
			get
			{
				return this.mSpline.NextNormal(this);
			}
		}

		// Token: 0x170018C2 RID: 6338
		// (get) Token: 0x06008D48 RID: 36168 RVA: 0x001A4491 File Offset: 0x001A2891
		public Vector3 PreviousNormal
		{
			get
			{
				return this.mSpline.PreviousNormal(this);
			}
		}

		// Token: 0x170018C3 RID: 6339
		// (get) Token: 0x06008D49 RID: 36169 RVA: 0x001A449F File Offset: 0x001A289F
		public bool IsValid
		{
			get
			{
				return this.NextControlPoint != null;
			}
		}

		// Token: 0x06008D4A RID: 36170 RVA: 0x001A44B0 File Offset: 0x001A28B0
		private Vector3 GetNext2Position()
		{
			SplineControlPoint nextControlPoint = this.NextControlPoint;
			if (nextControlPoint != null)
			{
				return nextControlPoint.NextPosition;
			}
			return this.NextPosition;
		}

		// Token: 0x06008D4B RID: 36171 RVA: 0x001A44D8 File Offset: 0x001A28D8
		private Vector3 GetNext2Normal()
		{
			SplineControlPoint nextControlPoint = this.NextControlPoint;
			if (nextControlPoint != null)
			{
				return nextControlPoint.NextNormal;
			}
			return this.Normal;
		}

		// Token: 0x06008D4C RID: 36172 RVA: 0x001A44FF File Offset: 0x001A28FF
		public Vector3 Interpolate(float localF)
		{
			localF = Mathf.Clamp01(localF);
			return Spline.CatmulRom(this.PreviousPosition, this.Position, this.NextPosition, this.GetNext2Position(), localF);
		}

		// Token: 0x06008D4D RID: 36173 RVA: 0x001A4527 File Offset: 0x001A2927
		public Vector3 InterpolateNormal(float localF)
		{
			localF = Mathf.Clamp01(localF);
			return Spline.CatmulRom(this.PreviousNormal, this.Normal, this.NextNormal, this.GetNext2Normal(), localF);
		}

		// Token: 0x06008D4E RID: 36174 RVA: 0x001A454F File Offset: 0x001A294F
		public void Init(Spline owner)
		{
			this.mSpline = owner;
			this.SegmentIndex = -1;
		}

		// Token: 0x040045F9 RID: 17913
		public Vector3 Position;

		// Token: 0x040045FA RID: 17914
		public Vector3 Normal;

		// Token: 0x040045FB RID: 17915
		public int ControlPointIndex = -1;

		// Token: 0x040045FC RID: 17916
		public int SegmentIndex = -1;

		// Token: 0x040045FD RID: 17917
		public float Dist;

		// Token: 0x040045FE RID: 17918
		protected Spline mSpline;
	}
}
