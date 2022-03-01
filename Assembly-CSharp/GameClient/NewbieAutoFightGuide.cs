using System;

namespace GameClient
{
	// Token: 0x0200102E RID: 4142
	public class NewbieAutoFightGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CAA RID: 40106 RVA: 0x001E9D30 File Offset: 0x001E8130
		public NewbieAutoFightGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CAB RID: 40107 RVA: 0x001E9D3C File Offset: 0x001E813C
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, null, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/NewbieGuideAddAutofight",
				string.Empty,
				string.Empty,
				3f,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
		}

		// Token: 0x06009CAC RID: 40108 RVA: 0x001E9D94 File Offset: 0x001E8194
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				12
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.IsDungeon, null, null));
		}
	}
}
