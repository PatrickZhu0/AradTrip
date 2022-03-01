using System;

namespace GameClient
{
	// Token: 0x020010CA RID: 4298
	public class DungeonMouFinishFrame : DungeonGoldRushFinishFrame, IDungeonFinish
	{
		// Token: 0x0600A28C RID: 41612 RVA: 0x00212E9B File Offset: 0x0021129B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonGoldRushFinish";
		}
	}
}
