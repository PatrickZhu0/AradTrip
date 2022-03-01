using System;

namespace GameClient
{
	// Token: 0x02001834 RID: 6196
	public sealed class ConsumePointActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3C2 RID: 62402 RVA: 0x0041D8CA File Offset: 0x0041BCCA
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F3C3 RID: 62403 RVA: 0x0041D8D3 File Offset: 0x0041BCD3
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F3C4 RID: 62404 RVA: 0x0041D8DB File Offset: 0x0041BCDB
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ConsumePointActivityItem";
		}
	}
}
