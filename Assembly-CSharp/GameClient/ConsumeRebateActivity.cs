using System;

namespace GameClient
{
	// Token: 0x02001835 RID: 6197
	public class ConsumeRebateActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3C6 RID: 62406 RVA: 0x0041D8EC File Offset: 0x0041BCEC
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ConsumeRebateActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}

		// Token: 0x0600F3C7 RID: 62407 RVA: 0x0041D92E File Offset: 0x0041BD2E
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ConsumeRebateItem";
		}
	}
}
