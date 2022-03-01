using System;
using FBTransportDoorExtraData;
using FlatBuffers;
using UnityEngine;

// Token: 0x02004B45 RID: 19269
public class FBTransportDoorExtraDataTool
{
	// Token: 0x0601C4E2 RID: 115938 RVA: 0x0089B072 File Offset: 0x00899472
	private static Offset<Vector3> _createVec3(FlatBufferBuilder builder, Vector3 pos)
	{
		return Vector3.CreateVector3(builder, pos.x, pos.y, pos.z);
	}

	// Token: 0x0601C4E3 RID: 115939 RVA: 0x0089B090 File Offset: 0x00899490
	public static Offset<FBTransportDoorExtraData.DTransportDoorExtraData> CreateTransportDoorExtraData(FlatBufferBuilder builder, global::DTransportDoorExtraData data)
	{
		FBTransportDoorExtraData.DTransportDoorExtraData.StartDTransportDoorExtraData(builder);
		FBTransportDoorExtraData.DTransportDoorExtraData.AddButtom(builder, FBTransportDoorExtraDataTool._createVec3(builder, data.buttom));
		FBTransportDoorExtraData.DTransportDoorExtraData.AddLeft(builder, FBTransportDoorExtraDataTool._createVec3(builder, data.left));
		FBTransportDoorExtraData.DTransportDoorExtraData.AddRight(builder, FBTransportDoorExtraDataTool._createVec3(builder, data.right));
		FBTransportDoorExtraData.DTransportDoorExtraData.AddTop(builder, FBTransportDoorExtraDataTool._createVec3(builder, data.top));
		return FBTransportDoorExtraData.DTransportDoorExtraData.EndDTransportDoorExtraData(builder);
	}
}
