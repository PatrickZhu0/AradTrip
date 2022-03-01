using System;

// Token: 0x02004B6C RID: 19308
public static class DTransportDoorTool
{
	// Token: 0x0601C64D RID: 116301 RVA: 0x0089DE82 File Offset: 0x0089C282
	public static TransportDoorType OppositeType(this TransportDoorType doortype)
	{
		switch (doortype)
		{
		case TransportDoorType.Left:
			return TransportDoorType.Right;
		case TransportDoorType.Top:
			return TransportDoorType.Buttom;
		case TransportDoorType.Right:
			return TransportDoorType.Left;
		case TransportDoorType.Buttom:
			return TransportDoorType.Top;
		default:
			return TransportDoorType.Right;
		}
	}
}
