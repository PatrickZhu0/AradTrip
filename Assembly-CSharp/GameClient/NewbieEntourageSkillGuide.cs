using System;

namespace GameClient
{
	// Token: 0x02001040 RID: 4160
	public class NewbieEntourageSkillGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CE1 RID: 40161 RVA: 0x001EB8C1 File Offset: 0x001E9CC1
		public NewbieEntourageSkillGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CE2 RID: 40162 RVA: 0x001EB8CC File Offset: 0x001E9CCC
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, null, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/NewbieGuideAddSkill2",
				string.Empty,
				string.Empty,
				3f,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009CE3 RID: 40163 RVA: 0x001EB924 File Offset: 0x001E9D24
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				11
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
		}
	}
}
