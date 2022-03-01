using System;

namespace GameClient
{
	// Token: 0x0200186B RID: 6251
	public class SwipePicturesToSendTicketsActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4FD RID: 62717 RVA: 0x00421573 File Offset: 0x0041F973
		public override bool IsHaveRedPoint()
		{
			return false;
		}

		// Token: 0x0600F4FE RID: 62718 RVA: 0x00421578 File Offset: 0x0041F978
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/SwipePicturesToSendTicketsActivity";
		}

		// Token: 0x0600F4FF RID: 62719 RVA: 0x0042158C File Offset: 0x0041F98C
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/SwipePicturesToSendTicketsItem";
		}
	}
}
