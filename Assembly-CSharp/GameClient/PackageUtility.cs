using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012BB RID: 4795
	public static class PackageUtility
	{
		// Token: 0x0600B924 RID: 47396 RVA: 0x002A6C10 File Offset: 0x002A5010
		public static bool IsPackageFullByType(EPackageType type)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
			int num = 0;
			if (itemsByPackageType != null)
			{
				num = itemsByPackageType.Count;
			}
			return DataManager<PlayerBaseData>.GetInstance().PackTotalSize.Count > (int)type && DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)type] <= num;
		}
	}
}
