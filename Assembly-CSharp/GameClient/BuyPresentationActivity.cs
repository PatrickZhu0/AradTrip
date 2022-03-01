using System;

namespace GameClient
{
	// Token: 0x0200182B RID: 6187
	public sealed class BuyPresentationActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F392 RID: 62354 RVA: 0x0041D05C File Offset: 0x0041B45C
		public override void Init(uint activityId)
		{
			base.Init(activityId);
		}

		// Token: 0x0600F393 RID: 62355 RVA: 0x0041D065 File Offset: 0x0041B465
		public override void Dispose()
		{
			base.Dispose();
		}

		// Token: 0x0600F394 RID: 62356 RVA: 0x0041D06D File Offset: 0x0041B46D
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/BuyPresentationActivity";
		}

		// Token: 0x0600F395 RID: 62357 RVA: 0x0041D074 File Offset: 0x0041B474
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/BuyPresentationItem";
		}
	}
}
