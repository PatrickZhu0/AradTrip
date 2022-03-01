using System;

namespace GameClient
{
	// Token: 0x02001863 RID: 6243
	public sealed class ReturnTeamBuffActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F4CE RID: 62670 RVA: 0x004210BB File Offset: 0x0041F4BB
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			if (param == 0)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeMapFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
			}
		}

		// Token: 0x0600F4CF RID: 62671 RVA: 0x004210EC File Offset: 0x0041F4EC
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/ReturnTeamBuffItem";
		}
	}
}
