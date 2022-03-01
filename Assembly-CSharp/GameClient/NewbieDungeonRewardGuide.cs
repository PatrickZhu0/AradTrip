using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103D RID: 4157
	public class NewbieDungeonRewardGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CD8 RID: 40152 RVA: 0x001EB10F File Offset: 0x001E950F
		public NewbieDungeonRewardGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CD9 RID: 40153 RVA: 0x001EB118 File Offset: 0x001E9518
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"DungeonRewardFrame",
				"mid/Root/Card1/CardItem0",
				"点击卡牌翻开奖励~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
		}

		// Token: 0x06009CDA RID: 40154 RVA: 0x001EB19D File Offset: 0x001E959D
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
		}
	}
}
