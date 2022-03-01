using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103B RID: 4155
	public class NewbieDrugSetGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CD2 RID: 40146 RVA: 0x001EADFB File Offset: 0x001E91FB
		public NewbieDrugSetGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CD3 RID: 40147 RVA: 0x001EAE04 File Offset: 0x001E9204
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"进入战斗前，可以提前配置好药剂哦",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"PackageNewFrame",
				"Content/ItemListTabs/Title3",
				"点击消耗品页签",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"PackageNewFrame",
				"Content/Bottom/Ctrl/ChapterPotionSet",
				"选择药品配置",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(ComNewbieData.New<ComNewbieGuideDragSkill>(null, new object[]
			{
				"ChapterBattlePotionSetFrame",
				"board/drugs/drugItems/Content/ChapterBattlePotionUnit(Clone)",
				"请拖动药品进行配置",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(400f, 220f, 0f),
				"ChapterBattlePotionSetFrame",
				"board/setDrugs/rt/setParent/BattlePotionSet(Clone)/sets/slotMain/drugSlot0",
				"将药品拖拽进快捷药品栏",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomRight,
				TextTipType.TextTipType_Two,
				new Vector3(130f, 70f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"在副本内携带多种药品，可长按滑动使用药品哦~"
			}));
		}

		// Token: 0x06009CD4 RID: 40148 RVA: 0x001EB004 File Offset: 0x001E9404
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2204
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
