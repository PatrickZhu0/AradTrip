using System;

namespace GameClient
{
	// Token: 0x02001822 RID: 6178
	public sealed class AccumulateClearanceActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F34F RID: 62287 RVA: 0x0041C5DF File Offset: 0x0041A9DF
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F350 RID: 62288 RVA: 0x0041C5E8 File Offset: 0x0041A9E8
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F351 RID: 62289 RVA: 0x0041C5F0 File Offset: 0x0041A9F0
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/AccumulateClearanceActivity";
		}

		// Token: 0x0600F352 RID: 62290 RVA: 0x0041C5F7 File Offset: 0x0041A9F7
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/AccumulateClearanceItem";
		}
	}
}
