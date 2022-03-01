using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001277 RID: 4727
	public class HeadPortraitItemData : IComparable<HeadPortraitItemData>
	{
		// Token: 0x0600B5DA RID: 46554 RVA: 0x0028FD60 File Offset: 0x0028E160
		public HeadPortraitItemData(HeadPortraitTabType type, PictureFrameTable pictureFrameTable)
		{
			if (type == HeadPortraitTabType.HPTT_ALL)
			{
				this.tabType = HeadPortraitTabType.HPTT_ALL;
			}
			else
			{
				this.tabType = (HeadPortraitTabType)pictureFrameTable.TabID;
			}
			this.itemID = pictureFrameTable.ID;
			this.Name = pictureFrameTable.Name;
			this.conditions = pictureFrameTable.Conditions;
			this.iconPath = pictureFrameTable.IconPath;
			this.expireTime = 0;
			if (pictureFrameTable.ID == HeadPortraitFrameDataManager.iDefaultHeadPortraitID)
			{
				this.isObtain = true;
			}
			else
			{
				this.isObtain = false;
			}
			this.isNew = false;
		}

		// Token: 0x0600B5DB RID: 46555 RVA: 0x0028FDF2 File Offset: 0x0028E1F2
		public int CompareTo(HeadPortraitItemData other)
		{
			if (this.isObtain != other.isObtain)
			{
				return other.isObtain.CompareTo(this.isObtain);
			}
			return this.itemID - other.itemID;
		}

		// Token: 0x040066C8 RID: 26312
		public int itemID;

		// Token: 0x040066C9 RID: 26313
		public string Name;

		// Token: 0x040066CA RID: 26314
		public int expireTime;

		// Token: 0x040066CB RID: 26315
		public HeadPortraitTabType tabType;

		// Token: 0x040066CC RID: 26316
		public bool isObtain;

		// Token: 0x040066CD RID: 26317
		public string conditions;

		// Token: 0x040066CE RID: 26318
		public string iconPath;

		// Token: 0x040066CF RID: 26319
		public bool isNew;
	}
}
