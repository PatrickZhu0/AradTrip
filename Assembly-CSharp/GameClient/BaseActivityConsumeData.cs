using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F53 RID: 3923
	public class BaseActivityConsumeData
	{
		// Token: 0x06009875 RID: 39029 RVA: 0x001D54AC File Offset: 0x001D38AC
		public BaseActivityConsumeData(int id)
		{
			this.mId = id;
			this.mDungeonTable = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (this.mDungeonTable != null)
			{
				this.mDungeonTimesTable = Singleton<TableManager>.instance.GetTableItem<DungeonTimesTable>((int)this.mDungeonTable.SubType, string.Empty, string.Empty);
			}
			if (this.mDungeonTimesTable != null)
			{
				this.mVipTable = Singleton<TableManager>.instance.GetTableItem<VipPrivilegeTable>(this.mDungeonTimesTable.BuyTimesVipPrivilege, string.Empty, string.Empty);
			}
		}

		// Token: 0x04004EAF RID: 20143
		protected int mId;

		// Token: 0x04004EB0 RID: 20144
		protected DungeonTable mDungeonTable;

		// Token: 0x04004EB1 RID: 20145
		protected DungeonTimesTable mDungeonTimesTable;

		// Token: 0x04004EB2 RID: 20146
		protected VipPrivilegeTable mVipTable;
	}
}
