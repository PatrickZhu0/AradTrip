using System;

namespace GameClient
{
	// Token: 0x0200180D RID: 6157
	public class TuanBenActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F2A2 RID: 62114 RVA: 0x004172DF File Offset: 0x004156DF
		protected sealed override string _GetPrefabPath()
		{
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return "UIFlatten/Prefabs/OperateActivity/Anniversary/Acitivity/TuanBenActivity";
		}

		// Token: 0x0600F2A3 RID: 62115 RVA: 0x00417312 File Offset: 0x00415712
		protected override string _GetItemPrefabPath()
		{
			return string.Empty;
		}
	}
}
