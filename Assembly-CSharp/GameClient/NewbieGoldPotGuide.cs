using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001046 RID: 4166
	public class NewbieGoldPotGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CF3 RID: 40179 RVA: 0x001EC887 File Offset: 0x001EAC87
		public NewbieGoldPotGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CF4 RID: 40180 RVA: 0x001EC890 File Offset: 0x001EAC90
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"top/goldJar",
				"金罐解锁了,神奇的罐子蕴藏着不同的<color=#ff0000ff>装备</color>",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Three,
				new Vector3(-825f, -300f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"GoldJarFrame",
				"Content/TreeList/Viewport",
				"左侧可以选择不同的护甲类型，对应的护甲类型会有推荐标识~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Right,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"GoldJarFrame",
				"Content/TabGroup/Tabs",
				"上方还可选择不同等级~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Buttom,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"GoldJarFrame",
				"Content/TabGroup/Page/Right/Buy/Func(Clone)",
				"点击抽取",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"根据你自己的等级和护甲类型，抽取对应的装备吧！"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ShowItemsFrame",
				"Result/Return",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"GoldJarFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009CF5 RID: 40181 RVA: 0x001ECAC4 File Offset: 0x001EAEC4
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				17
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
