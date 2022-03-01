using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001037 RID: 4151
	public class NewbieDeathTowerGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CC5 RID: 40133 RVA: 0x001EA709 File Offset: 0x001E8B09
		public NewbieDeathTowerGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CC6 RID: 40134 RVA: 0x001EA714 File Offset: 0x001E8B14
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"<color=#ff0000ff>勇者之塔</color>开启咯,与普通关卡不同，需要从<color=#ff0000ff>活动</color>入口进入~",
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/4/toggle",
				"点击查看活动详情",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ActivityDungeonInfoFrame",
				"C/Middle/button/go",
				"关闭详情",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/4/right/button/go",
				"马上开始挑战吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two
			}));
		}

		// Token: 0x06009CC7 RID: 40135 RVA: 0x001EA836 File Offset: 0x001E8C36
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				16
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
		}
	}
}
