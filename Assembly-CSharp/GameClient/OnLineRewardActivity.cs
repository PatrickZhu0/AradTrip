using System;

namespace GameClient
{
	// Token: 0x0200185C RID: 6236
	public sealed class OnLineRewardActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4AB RID: 62635 RVA: 0x00420A38 File Offset: 0x0041EE38
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4AC RID: 62636 RVA: 0x00420A41 File Offset: 0x0041EE41
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4AD RID: 62637 RVA: 0x00420A49 File Offset: 0x0041EE49
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/OnLineRewardActivity";
		}

		// Token: 0x0600F4AE RID: 62638 RVA: 0x00420A50 File Offset: 0x0041EE50
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/OnLineRewardGrandTotalItem";
		}
	}
}
