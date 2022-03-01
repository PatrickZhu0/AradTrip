using System;

namespace GameClient
{
	// Token: 0x02001039 RID: 4153
	public class NewbieDoubleClickRunGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CCB RID: 40139 RVA: 0x001EAAED File Offset: 0x001E8EED
		public NewbieDoubleClickRunGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CCC RID: 40140 RVA: 0x001EAAF8 File Offset: 0x001E8EF8
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, null, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/NewbieGuideDoubleMove",
				string.Empty,
				string.Empty,
				3f,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009CCD RID: 40141 RVA: 0x001EAB50 File Offset: 0x001E8F50
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				10
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(NewbieConditionData.NewUserCondition(() => Global.Settings.hasDoubleRun));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SpecificEvent, new int[1], null));
		}
	}
}
