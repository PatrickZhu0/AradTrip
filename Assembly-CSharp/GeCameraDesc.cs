using System;
using System.Runtime.InteropServices;

// Token: 0x02000D8A RID: 3466
[StructLayout(LayoutKind.Sequential, Size = 1)]
public struct GeCameraDesc
{
	// Token: 0x1700189F RID: 6303
	// (get) Token: 0x06008C66 RID: 35942 RVA: 0x001A00E1 File Offset: 0x0019E4E1
	// (set) Token: 0x06008C65 RID: 35941 RVA: 0x001A00D8 File Offset: 0x0019E4D8
	public bool IsOrthographic { get; set; }

	// Token: 0x170018A0 RID: 6304
	// (get) Token: 0x06008C68 RID: 35944 RVA: 0x001A00F2 File Offset: 0x0019E4F2
	// (set) Token: 0x06008C67 RID: 35943 RVA: 0x001A00E9 File Offset: 0x0019E4E9
	public float FOV { get; set; }

	// Token: 0x170018A1 RID: 6305
	// (get) Token: 0x06008C69 RID: 35945 RVA: 0x001A00FA File Offset: 0x0019E4FA
	// (set) Token: 0x06008C6A RID: 35946 RVA: 0x001A0102 File Offset: 0x0019E502
	public float OrthographicSize { get; set; }

	// Token: 0x170018A2 RID: 6306
	// (get) Token: 0x06008C6B RID: 35947 RVA: 0x001A010B File Offset: 0x0019E50B
	// (set) Token: 0x06008C6C RID: 35948 RVA: 0x001A0113 File Offset: 0x0019E513
	public float NearPlane { get; set; }

	// Token: 0x170018A3 RID: 6307
	// (get) Token: 0x06008C6D RID: 35949 RVA: 0x001A011C File Offset: 0x0019E51C
	// (set) Token: 0x06008C6E RID: 35950 RVA: 0x001A0124 File Offset: 0x0019E524
	public float FarPlane { get; set; }
}
