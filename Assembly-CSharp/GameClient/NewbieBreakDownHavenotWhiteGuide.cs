using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001033 RID: 4147
	public class NewbieBreakDownHavenotWhiteGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CB9 RID: 40121 RVA: 0x001EA282 File Offset: 0x001E8682
		public NewbieBreakDownHavenotWhiteGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CBA RID: 40122 RVA: 0x001EA28C File Offset: 0x001E868C
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"多余的装备，可以进行一键分解获取水晶哦！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"PackageNewFrame",
				"Content/Bottom/Ctrl/QuickDecompose",
				"点击一键分解按钮。",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 80f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"选择相应品质的装备后，就可以一键分解啦。"
			}));
		}

		// Token: 0x06009CBB RID: 40123 RVA: 0x001EA370 File Offset: 0x001E8770
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2213
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
