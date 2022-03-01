using System;

namespace GameClient
{
	// Token: 0x02001864 RID: 6244
	public sealed class RewardPointsActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4D1 RID: 62673 RVA: 0x004210FB File Offset: 0x0041F4FB
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4D2 RID: 62674 RVA: 0x00421104 File Offset: 0x0041F504
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4D3 RID: 62675 RVA: 0x0042110C File Offset: 0x0041F50C
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/RewardPointsActivity";
		}

		// Token: 0x0600F4D4 RID: 62676 RVA: 0x00421113 File Offset: 0x0041F513
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/RewardPointsActivityItem";
		}
	}
}
