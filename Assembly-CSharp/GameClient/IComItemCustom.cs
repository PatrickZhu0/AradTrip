using System;

namespace GameClient
{
	// Token: 0x02001BBF RID: 7103
	public interface IComItemCustom
	{
		// Token: 0x06011604 RID: 71172
		void Init(bool enableTips, ItemData itemData, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType);

		// Token: 0x06011605 RID: 71173
		void Init(bool enableTips, ItemSimpleData itemSData, bool bOwned, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType);

		// Token: 0x06011606 RID: 71174
		void Init(bool enableTips, int itemDataId, bool bOwned, bool bHideCount, bool hasBottomDesc, ComItemCustomClickType clickType);
	}
}
