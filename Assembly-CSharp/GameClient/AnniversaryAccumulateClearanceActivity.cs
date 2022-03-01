using System;

namespace GameClient
{
	// Token: 0x02001809 RID: 6153
	public class AnniversaryAccumulateClearanceActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F292 RID: 62098 RVA: 0x004171E2 File Offset: 0x004155E2
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F293 RID: 62099 RVA: 0x004171EB File Offset: 0x004155EB
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F294 RID: 62100 RVA: 0x004171F3 File Offset: 0x004155F3
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/AnniversaryAccumulateClearanceActivity";
		}

		// Token: 0x0600F295 RID: 62101 RVA: 0x004171FA File Offset: 0x004155FA
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Item/AnniversaryAccumulateClearanceItem";
		}
	}
}
