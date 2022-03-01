using System;
using UnityEngine;

// Token: 0x02004B76 RID: 19318
public class DTransportDoorExtraData : ScriptableObject, ITransportDoorExtraData
{
	// Token: 0x0601C6B0 RID: 116400 RVA: 0x0089E7F0 File Offset: 0x0089CBF0
	public Vector3 GetRegionPos(TransportDoorType type)
	{
		switch (type)
		{
		case TransportDoorType.Left:
			return this.left;
		case TransportDoorType.Top:
			return this.top;
		case TransportDoorType.Right:
			return this.right;
		case TransportDoorType.Buttom:
			return this.buttom;
		default:
			return Vector3.zero;
		}
	}

	// Token: 0x040138B9 RID: 80057
	public Vector3 top = Vector3.zero;

	// Token: 0x040138BA RID: 80058
	public Vector3 buttom = Vector3.zero;

	// Token: 0x040138BB RID: 80059
	public Vector3 left = Vector3.zero;

	// Token: 0x040138BC RID: 80060
	public Vector3 right = Vector3.zero;
}
