using System;

// Token: 0x02000FF8 RID: 4088
public class ComNewbieGuidePauseBattle : ComNewbieGuideBase
{
	// Token: 0x06009BB5 RID: 39861 RVA: 0x001E5D78 File Offset: 0x001E4178
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IDungeonManager dungeonManager = BattleMain.instance.GetDungeonManager();
		if (dungeonManager == null)
		{
			Logger.LogError("main is nil");
		}
		else
		{
			dungeonManager.PauseFight(false, "newbie", false);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
