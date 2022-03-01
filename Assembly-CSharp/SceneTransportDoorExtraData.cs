using System;
using FBTransportDoorExtraData;
using UnityEngine;

// Token: 0x02004B87 RID: 19335
public class SceneTransportDoorExtraData : ITransportDoorExtraData
{
	// Token: 0x0601C749 RID: 116553 RVA: 0x0089E8EC File Offset: 0x0089CCEC
	public SceneTransportDoorExtraData(FBTransportDoorExtraData.DTransportDoorExtraData data)
	{
		this.mData = data;
		this._init();
	}

	// Token: 0x0601C74A RID: 116554 RVA: 0x0089E938 File Offset: 0x0089CD38
	private void _init()
	{
		if (this.mData == null)
		{
			return;
		}
		this.mTop = new Vector3(this.mData.Top.X, this.mData.Top.Y, this.mData.Top.Z);
		this.mButtom = new Vector3(this.mData.Buttom.X, this.mData.Buttom.Y, this.mData.Buttom.Z);
		this.mLeft = new Vector3(this.mData.Left.X, this.mData.Left.Y, this.mData.Left.Z);
		this.mRight = new Vector3(this.mData.Right.X, this.mData.Right.Y, this.mData.Right.Z);
	}

	// Token: 0x0601C74B RID: 116555 RVA: 0x0089EA3D File Offset: 0x0089CE3D
	public Vector3 GetRegionPos(TransportDoorType type)
	{
		switch (type)
		{
		case TransportDoorType.Left:
			return this.mLeft;
		case TransportDoorType.Top:
			return this.mTop;
		case TransportDoorType.Right:
			return this.mRight;
		case TransportDoorType.Buttom:
			return this.mButtom;
		default:
			return Vector3.zero;
		}
	}

	// Token: 0x040138CF RID: 80079
	private FBTransportDoorExtraData.DTransportDoorExtraData mData;

	// Token: 0x040138D0 RID: 80080
	private Vector3 mTop = Vector3.zero;

	// Token: 0x040138D1 RID: 80081
	private Vector3 mButtom = Vector3.zero;

	// Token: 0x040138D2 RID: 80082
	private Vector3 mRight = Vector3.zero;

	// Token: 0x040138D3 RID: 80083
	private Vector3 mLeft = Vector3.zero;
}
