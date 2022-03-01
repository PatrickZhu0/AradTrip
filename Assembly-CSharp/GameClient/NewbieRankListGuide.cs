using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104F RID: 4175
	public class NewbieRankListGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D0E RID: 40206 RVA: 0x001ED74C File Offset: 0x001EBB4C
		public NewbieRankListGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D0F RID: 40207 RVA: 0x001ED758 File Offset: 0x001EBB58
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"topright/ranklist",
				"可以查看排行榜喽",
				ComNewbieGuideBase.eNewbieGuideAnchor.Buttom,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"RanklistFrame",
				"Details/RankContent/Viewport",
				"这是等级榜，下方是你的排名哦~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Left,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"RanklistFrame",
				"Ranks/Viewport",
				"其他还有竞技榜和死亡之塔榜哦~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RanklistFrame",
				"Close",
				"继续挑战关卡吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 50f, 0f)
			}));
		}

		// Token: 0x06009D10 RID: 40208 RVA: 0x001ED894 File Offset: 0x001EBC94
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				8
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
