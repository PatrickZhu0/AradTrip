using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200111B RID: 4379
	public class ChijiShopItemDataModel
	{
		// Token: 0x04005CE8 RID: 23784
		public ChijiShopType ChijiShopType;

		// Token: 0x04005CE9 RID: 23785
		public int ItemIndex;

		// Token: 0x04005CEA RID: 23786
		public bool IsSelected;

		// Token: 0x04005CEB RID: 23787
		public ulong ItemGuid;

		// Token: 0x04005CEC RID: 23788
		public int ShopId;

		// Token: 0x04005CED RID: 23789
		public int ShopItemId;

		// Token: 0x04005CEE RID: 23790
		public ChiJiShopItemTable ShopItemTable;

		// Token: 0x04005CEF RID: 23791
		public bool IsSoldOver;
	}
}
