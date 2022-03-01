using System;

namespace GameClient
{
	// Token: 0x020018B9 RID: 6329
	public sealed class WeeklyCheckInActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F751 RID: 63313 RVA: 0x0042E7E7 File Offset: 0x0042CBE7
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F752 RID: 63314 RVA: 0x0042E7F0 File Offset: 0x0042CBF0
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F753 RID: 63315 RVA: 0x0042E7F8 File Offset: 0x0042CBF8
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/WeeklyCheckInActivity";
		}

		// Token: 0x0600F754 RID: 63316 RVA: 0x0042E7FF File Offset: 0x0042CBFF
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/WeeklyCheckInActivityItem";
		}
	}
}
