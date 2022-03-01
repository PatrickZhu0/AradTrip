using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001051 RID: 4177
	public class NewbieRewardBoxGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D14 RID: 40212 RVA: 0x001ED98B File Offset: 0x001EBD8B
		public NewbieRewardBoxGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D15 RID: 40213 RVA: 0x001ED994 File Offset: 0x001EBD94
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterNormalFrame",
				"FKRoot/Top/Title/Close",
				"每通关一个章节后就可以领取该章节的关卡宝箱奖励了",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(0f, -250f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterSelectFrame",
				"Menu/MR/L/Left/B",
				"回退到上一章",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterSelectFrame",
				"Menu/Buttom/Reward",
				"打开章节奖励界面",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterRewardFrame",
				"C/Scroll/ViewPort/Content/3500/GR/BtnAward",
				"点击领取奖励",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterRewardFrame",
				"C/Scroll/ViewPort/Content/3501/GR/BtnAward",
				"点击领取奖励",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterRewardFrame",
				"C/Middle/SR/Slider/Background/Bx",
				"打开宝箱~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterRewardFrame",
				"Box/Ok/r/AllReward",
				"领取章节奖励吧~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"完成全部相应章节的任务\n就可以领取章节奖励哦~\n继续挑战关卡吧"
			}));
		}

		// Token: 0x06009D16 RID: 40214 RVA: 0x001EDC35 File Offset: 0x001EC035
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				5
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ChapterChooseFrameOpen, null, null));
		}
	}
}
