using System;
using System.Runtime.InteropServices;

namespace GameClient
{
	// Token: 0x02000FBD RID: 4029
	[StructLayout(LayoutKind.Explicit)]
	public struct UIEventParams
	{
		// Token: 0x04005061 RID: 20577
		[FieldOffset(0)]
		public int CommonIntTag;

		// Token: 0x04005062 RID: 20578
		[FieldOffset(0)]
		public uint CommonUIntTag;

		// Token: 0x04005063 RID: 20579
		[FieldOffset(0)]
		public ulong GUID;

		// Token: 0x04005064 RID: 20580
		[FieldOffset(0)]
		public EPackageType PackType;

		// Token: 0x04005065 RID: 20581
		[FieldOffset(0)]
		public TaskInfoData taskData;

		// Token: 0x04005066 RID: 20582
		[FieldOffset(0)]
		public int CurrentSceneID;

		// Token: 0x04005067 RID: 20583
		[FieldOffset(0)]
		public int CurrentSelectedID;

		// Token: 0x04005068 RID: 20584
		[FieldOffset(0)]
		public BuyGoodsResult buyGoodsResult;

		// Token: 0x04005069 RID: 20585
		[FieldOffset(0)]
		public PurchaseCommonData kPurchaseCommonData;
	}
}
