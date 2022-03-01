using System;

namespace GameClient
{
	// Token: 0x02001054 RID: 4180
	public class NewbieSuperArmorGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D1D RID: 40221 RVA: 0x001EE1CB File Offset: 0x001EC5CB
		public NewbieSuperArmorGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D1E RID: 40222 RVA: 0x001EE1D4 File Offset: 0x001EC5D4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.SHOW_IMAGE, null, new object[]
			{
				"UI/Image/NewbieGuide/NewbieGuide_3.png:NewbieGuide_3",
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009D1F RID: 40223 RVA: 0x001EE204 File Offset: 0x001EC604
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.DungeonID, new int[]
			{
				102000
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.DungeonAreaID, new int[]
			{
				16
			}, null));
		}
	}
}
