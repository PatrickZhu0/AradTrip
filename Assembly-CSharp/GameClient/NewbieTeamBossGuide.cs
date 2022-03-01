using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001055 RID: 4181
	public class NewbieTeamBossGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D20 RID: 40224 RVA: 0x001EE28D File Offset: 0x001EC68D
		public NewbieTeamBossGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D21 RID: 40225 RVA: 0x001EE298 File Offset: 0x001EC698
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"那么去那里获得这些材料？Boss挑战等你来战！",
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/Tabs/Activity1",
				"选择首领切页",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/11/toggle",
				"与普通副本基本相同，但这里掉落稀有的打造材料",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009D22 RID: 40226 RVA: 0x001EE39E File Offset: 0x001EC79E
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				20
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
		}
	}
}
