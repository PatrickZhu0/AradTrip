using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103F RID: 4159
	public class NewbieEntourageGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CDE RID: 40158 RVA: 0x001EB54C File Offset: 0x001E994C
		public NewbieEntourageGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CDF RID: 40159 RVA: 0x001EB558 File Offset: 0x001E9958
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.EntourageID
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"想拥有一个帅气的伙伴吗？<color=#ff0000ff>随从</color>你值得拥有！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"Tabs/Tab1",
				"选择图鉴",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/RetinueTable/ViewPort/Content/1000/button",
				"解锁新的随从吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				default(Vector3),
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				"RetinueInfo/RetinueTable/ViewPort/Content/1000/Progress"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.6f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.PASS_THROUGH, null, new object[]
			{
				"RetinueResultFrame",
				"Close"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"Tabs/Tab0",
				"选择上阵随从",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/Operate/MainRetinue/bg/back",
				"选择出战槽位",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.8f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/Operate/List/ViewPort/Content/1000",
				"选择随从进行出战~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/Operate/Desc/top",
				"这里可以看到该随从的<color=#ff0000ff>助战技</color>~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Left,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"你的冒险并不孤单，有了<color=#ff0000ff>随从</color>\n的陪伴，既可以在危机关头通\n过<color=#ff0000ff>助战技</color>帮你渡过难关，还可\n以提升技能的等级！"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueFrame",
				"ComWnd/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
		}

		// Token: 0x06009CE0 RID: 40160 RVA: 0x001EB864 File Offset: 0x001E9C64
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				11
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2209
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
