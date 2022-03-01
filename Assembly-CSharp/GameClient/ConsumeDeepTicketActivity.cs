using System;

namespace GameClient
{
	// Token: 0x02001833 RID: 6195
	public sealed class ConsumeDeepTicketActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F3BE RID: 62398 RVA: 0x0041D8AA File Offset: 0x0041BCAA
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F3BF RID: 62399 RVA: 0x0041D8B3 File Offset: 0x0041BCB3
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F3C0 RID: 62400 RVA: 0x0041D8BB File Offset: 0x0041BCBB
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ConsumeDeepTicketActivityItem";
		}
	}
}
