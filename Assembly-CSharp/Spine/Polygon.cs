using System;

namespace Spine
{
	// Token: 0x020049D4 RID: 18900
	public class Polygon
	{
		// Token: 0x0601B3C2 RID: 111554 RVA: 0x00860164 File Offset: 0x0085E564
		public Polygon()
		{
			this.Vertices = new float[16];
		}

		// Token: 0x170023C8 RID: 9160
		// (get) Token: 0x0601B3C3 RID: 111555 RVA: 0x00860179 File Offset: 0x0085E579
		// (set) Token: 0x0601B3C4 RID: 111556 RVA: 0x00860181 File Offset: 0x0085E581
		public float[] Vertices { get; set; }

		// Token: 0x170023C9 RID: 9161
		// (get) Token: 0x0601B3C5 RID: 111557 RVA: 0x0086018A File Offset: 0x0085E58A
		// (set) Token: 0x0601B3C6 RID: 111558 RVA: 0x00860192 File Offset: 0x0085E592
		public int Count { get; set; }
	}
}
