using System;

namespace GameClient
{
	// Token: 0x0200185A RID: 6234
	public class NewYearOnDayActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4A3 RID: 62627 RVA: 0x004209C0 File Offset: 0x0041EDC0
		protected override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/NewYearOnDayActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}

		// Token: 0x0600F4A4 RID: 62628 RVA: 0x00420A02 File Offset: 0x0041EE02
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/NewYearOnDayItem";
		}
	}
}
