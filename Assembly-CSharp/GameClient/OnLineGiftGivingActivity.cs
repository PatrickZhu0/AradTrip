using System;

namespace GameClient
{
	// Token: 0x0200185B RID: 6235
	public sealed class OnLineGiftGivingActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4A6 RID: 62630 RVA: 0x00420A11 File Offset: 0x0041EE11
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F4A7 RID: 62631 RVA: 0x00420A1A File Offset: 0x0041EE1A
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F4A8 RID: 62632 RVA: 0x00420A22 File Offset: 0x0041EE22
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/OnLineGiftGivingActivity";
		}

		// Token: 0x0600F4A9 RID: 62633 RVA: 0x00420A29 File Offset: 0x0041EE29
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/OnLineGiftGiviingItem";
		}
	}
}
