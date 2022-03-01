using System;

// Token: 0x02000FFA RID: 4090
public class ComNewbieGuideResumeBattle : ComNewbieGuideBase
{
	// Token: 0x06009BBB RID: 39867 RVA: 0x001E5E9C File Offset: 0x001E429C
	protected override ComNewbieGuideBase.GuideState _init()
	{
		IDungeonManager dungeonManager = BattleMain.instance.GetDungeonManager();
		if (dungeonManager == null)
		{
			Logger.LogError("main is nil");
		}
		else
		{
			dungeonManager.ResumeFight(false, "newbie", false);
		}
		return ComNewbieGuideBase.GuideState.Normal;
	}
}
