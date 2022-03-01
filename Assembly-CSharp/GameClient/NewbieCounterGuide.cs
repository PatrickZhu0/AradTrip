using System;

namespace GameClient
{
	// Token: 0x02001035 RID: 4149
	public class NewbieCounterGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CBF RID: 40127 RVA: 0x001EA4EB File Offset: 0x001E88EB
		public NewbieCounterGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CC0 RID: 40128 RVA: 0x001EA4F4 File Offset: 0x001E88F4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.SHOW_IMAGE, null, new object[]
			{
				"UI/Image/NewbieGuide/NewbieGuide_7.png:NewbieGuide_7",
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009CC1 RID: 40129 RVA: 0x001EA524 File Offset: 0x001E8924
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.DungeonID, new int[]
			{
				201010
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
		}
	}
}
