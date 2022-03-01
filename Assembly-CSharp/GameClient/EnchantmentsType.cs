using System;
using System.ComponentModel;

namespace GameClient
{
	// Token: 0x020015B3 RID: 5555
	internal enum EnchantmentsType
	{
		// Token: 0x04007FA1 RID: 32673
		[Description("ItemTable.eColor.CL_NONE")]
		[MapIndex(0)]
		ET_INVALID = -1,
		// Token: 0x04007FA2 RID: 32674
		[Description("ItemTable.eColor.WHITE")]
		[MapIndex(1)]
		ET_NORMAL,
		// Token: 0x04007FA3 RID: 32675
		[Description("ItemTable.eColor.BLUE")]
		[MapIndex(2)]
		ET_HIGH,
		// Token: 0x04007FA4 RID: 32676
		[Description("ItemTable.eColor.PURPLE")]
		[MapIndex(3)]
		ET_PURPLE,
		// Token: 0x04007FA5 RID: 32677
		[Description("ItemTable.eColor.GREEN")]
		[MapIndex(4)]
		ET_GREEN,
		// Token: 0x04007FA6 RID: 32678
		[Description("ItemTable.eColor.PINK")]
		[MapIndex(5)]
		ET_PINK,
		// Token: 0x04007FA7 RID: 32679
		[Description("ItemTable.eColor.YELLOW")]
		[MapIndex(6)]
		ET_ORANGE,
		// Token: 0x04007FA8 RID: 32680
		[Description("ItemTable.eColor.ALL")]
		ET_COUNT
	}
}
