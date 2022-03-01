using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02004B8E RID: 19342
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct DAnimatParamData
{
	// Token: 0x040138E6 RID: 80102
	[FieldOffset(0)]
	public float _float;

	// Token: 0x040138E7 RID: 80103
	[FieldOffset(0)]
	public Color _color;

	// Token: 0x040138E8 RID: 80104
	[FieldOffset(0)]
	public Vector4 _vec4;
}
