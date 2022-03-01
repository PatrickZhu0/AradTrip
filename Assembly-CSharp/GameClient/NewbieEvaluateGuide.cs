using System;

namespace GameClient
{
	// Token: 0x02001044 RID: 4164
	public class NewbieEvaluateGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CED RID: 40173 RVA: 0x001EC1BE File Offset: 0x001EA5BE
		public NewbieEvaluateGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CEE RID: 40174 RVA: 0x001EC1C8 File Offset: 0x001EA5C8
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.SHOW_IMAGE, null, new object[]
			{
				"UI/Image/NewbieGuide/NewbieGuide_4.png:NewbieGuide_4",
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.STRESS, null, new object[]
			{
				"ClientSystemBattle",
				"DungeonMap/RScore",
				2f,
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.ResumeBattle
			}));
		}

		// Token: 0x06009CEF RID: 40175 RVA: 0x001EC250 File Offset: 0x001EA650
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.DungeonID, new int[]
			{
				101000
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
		}
	}
}
