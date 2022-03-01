using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001052 RID: 4178
	public class NewbieSkillGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D17 RID: 40215 RVA: 0x001EDC6A File Offset: 0x001EC06A
		public NewbieSkillGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D18 RID: 40216 RVA: 0x001EDC74 File Offset: 0x001EC074
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.JobID
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.TALK_DIALOG, null, new object[]
			{
				22050
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/skill",
				"冒险家大人！铁匠大叔向\n你传授了<color=#fcff21>新技能</color>呢！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SkillTreeFrame",
				"rightNew/Bottom/down/btSkillPlan",
				"学习新技能后一定要记得<color=#fcff21>进行配置</color>~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-550f, 30f, 0f)
			}));
			base.AddContent(ComNewbieData.New<ComNewbieGuideDragSkill>(null, new object[]
			{
				"SkillTreeFrame",
				"left/root/JobSkillTree(Clone)/ScrollView/Viewport/Content/ActiveSkillPanel2/Pos9/SkillTreeElement(Clone)/icon",
				"请拖动技能进行配置",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 30f, 0f),
				"SkillPlanFrame",
				"root/BarPos5",
				"将学习过的新技能拖拽进快捷技能栏",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 30f, 0f)
			}));
			base.AddContent(ComNewbieData.New<ComNewbieGuideDragSkill>(null, new object[]
			{
				"SkillTreeFrame",
				"left/root/JobSkillTree(Clone)/ScrollView/Viewport/Content/ActiveSkillPanel2/Pos10/SkillTreeElement(Clone)/icon",
				"请再次尝试配置新技能",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 30f, 0f),
				"SkillPlanFrame",
				"root/BarPos6",
				"将第二个新技能配置在快捷栏中",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"SkillPlanFrame",
				"root/BarPos4/SkillBarElement(Clone)/Skill/Icon",
				"冒险家，这里是转职后的职业技能,你可以在15级转职后进行自由配置",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"学习新技能后，请一定要\n记得进行<color=#fcff21>技能配置</color>喔~"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SkillTreeFrame",
				"Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TALK_DIALOG, null, new object[]
			{
				23020
			}));
		}

		// Token: 0x06009D19 RID: 40217 RVA: 0x001EDF74 File Offset: 0x001EC374
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				5
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2203
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
