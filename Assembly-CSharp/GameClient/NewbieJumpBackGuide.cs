using System;

namespace GameClient
{
	// Token: 0x02001049 RID: 4169
	public class NewbieJumpBackGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CFC RID: 40188 RVA: 0x001ECCF5 File Offset: 0x001EB0F5
		public NewbieJumpBackGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CFD RID: 40189 RVA: 0x001ECD00 File Offset: 0x001EB100
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, null, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/NewbieGuideAddJump",
				string.Empty,
				string.Empty,
				3f,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009CFE RID: 40190 RVA: 0x001ECD58 File Offset: 0x001EB158
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.DungeonID, new int[]
			{
				102010
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
		}
	}
}
