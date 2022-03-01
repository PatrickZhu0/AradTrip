using System;

namespace GameClient
{
	// Token: 0x0200185F RID: 6239
	public class RechargeConsumerRebatesActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4B6 RID: 62646 RVA: 0x00420C1F File Offset: 0x0041F01F
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/RechargeConsumerRebatesItem";
		}

		// Token: 0x0600F4B7 RID: 62647 RVA: 0x00420C26 File Offset: 0x0041F026
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/RechargeConsumerRebatesActivity";
		}
	}
}
