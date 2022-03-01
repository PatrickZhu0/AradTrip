using System;

namespace GameClient
{
	// Token: 0x02001836 RID: 6198
	public class DailyChallengeActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3C9 RID: 62409 RVA: 0x0041D93D File Offset: 0x0041BD3D
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/DailyChallengeActivity";
		}

		// Token: 0x0600F3CA RID: 62410 RVA: 0x0041D944 File Offset: 0x0041BD44
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/DailyChallengeItem";
		}
	}
}
