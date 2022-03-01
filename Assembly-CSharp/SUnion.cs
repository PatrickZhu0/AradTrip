using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x02004BBE RID: 19390
[Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct SUnion
{
	// Token: 0x04013A3F RID: 80447
	[FieldOffset(0)]
	public bool _bool;

	// Token: 0x04013A40 RID: 80448
	[FieldOffset(0)]
	public float _float;

	// Token: 0x04013A41 RID: 80449
	[FieldOffset(0)]
	public int _int;

	// Token: 0x04013A42 RID: 80450
	[FieldOffset(0)]
	public Quaternion _quat;

	// Token: 0x04013A43 RID: 80451
	[FieldOffset(0)]
	public uint _uint;

	// Token: 0x04013A44 RID: 80452
	[FieldOffset(0)]
	public Vector3 _vec3;
}
