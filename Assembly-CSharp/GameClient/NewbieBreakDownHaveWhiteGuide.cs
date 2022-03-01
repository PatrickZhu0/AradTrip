using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001032 RID: 4146
	public class NewbieBreakDownHaveWhiteGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CB6 RID: 40118 RVA: 0x001EA068 File Offset: 0x001E8468
		public NewbieBreakDownHaveWhiteGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CB7 RID: 40119 RVA: 0x001EA074 File Offset: 0x001E8474
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"多余的装备，可以进行一键分解获取水晶哦！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f),
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
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"PackageNewFrame",
				"Content/DecomposeRoot/DecomposeGroup(Clone)/SelectGroup/Toggle1",
				"选择白色页签。",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"PackageNewFrame",
				"Content/DecomposeRoot/DecomposeGroup(Clone)/Confirm",
				"点击开始分解吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"CommonMsgBoxOKCancel",
				"normal/Back/Panel/btOK",
				"点击确定按钮吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 30f, 0f)
			}));
		}

		// Token: 0x06009CB8 RID: 40120 RVA: 0x001EA247 File Offset: 0x001E8647
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2213
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.HaveWhiteEquipment, null, null));
		}
	}
}
