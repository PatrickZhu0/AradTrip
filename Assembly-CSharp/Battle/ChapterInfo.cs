using System;
using System.Collections.Generic;
using ProtoTable;

namespace Battle
{
	// Token: 0x0200108D RID: 4237
	public class ChapterInfo
	{
		// Token: 0x06009FB0 RID: 40880 RVA: 0x001FFB60 File Offset: 0x001FDF60
		public bool IsOpen(int dungeonID, out bool isUnlock, out int topHard)
		{
			isUnlock = false;
			topHard = -1;
			if (Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty) == null)
			{
				return false;
			}
			dungeonID = dungeonID / 10 * 10;
			DungeonOpenInfo item = new DungeonOpenInfo
			{
				id = dungeonID
			};
			isUnlock = (this.openedList.BinarySearch(item) >= 0);
			if (isUnlock)
			{
				topHard = this.GetTopHard(dungeonID);
			}
			return true;
		}

		// Token: 0x06009FB1 RID: 40881 RVA: 0x001FFBD0 File Offset: 0x001FDFD0
		public int GetTopHard(int dungeonID)
		{
			List<DungeonHardInfo> list = this.allHardInfo;
			int result = 0;
			int num = list.BinarySearch(new DungeonHardInfo
			{
				id = dungeonID / 1000 * 1000
			});
			if (num >= 0)
			{
				result = list[num].unlockedHardType;
			}
			return result;
		}

		// Token: 0x04005870 RID: 22640
		public List<DungeonInfo> allInfo = new List<DungeonInfo>();

		// Token: 0x04005871 RID: 22641
		public List<DungeonHardInfo> allHardInfo = new List<DungeonHardInfo>();

		// Token: 0x04005872 RID: 22642
		public List<DungeonOpenInfo> openedList = new List<DungeonOpenInfo>();
	}
}
