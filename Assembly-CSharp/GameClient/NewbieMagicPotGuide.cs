using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104B RID: 4171
	public class NewbieMagicPotGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D02 RID: 40194 RVA: 0x001ECEFE File Offset: 0x001EB2FE
		public NewbieMagicPotGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D03 RID: 40195 RVA: 0x001ECF08 File Offset: 0x001EB308
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.5f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"topright/jar",
				"魔罐解锁了,神奇的罐子蕴藏着不同的<color=#ff0000ff>宝物</color>",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Three,
				new Vector3(-825f, -300f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"JarsSelectFrame",
				"Type/magicJar",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"MagicJarFrame",
				"Content/Right/Buy/Func(Clone)",
				"赶快来抽一个吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"充满魔力的罐子，也许下\n一秒好运就会降临在你的\n身上，多多抽取吧"
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
				"MagicJarFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009D04 RID: 40196 RVA: 0x001ED104 File Offset: 0x001EB504
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				17
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2217
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
