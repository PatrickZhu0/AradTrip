using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104C RID: 4172
	public class NewbieMakeEquipGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D05 RID: 40197 RVA: 0x001ED161 File Offset: 0x001EB561
		public NewbieMakeEquipGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D06 RID: 40198 RVA: 0x001ED16C File Offset: 0x001EB56C
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.5f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"打造开启啦，赶快来看一看打造吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong/children/EquipForge",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"收集材料，打造装备，你也可以全身神装！"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"EquipForgeFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009D07 RID: 40199 RVA: 0x001ED2B0 File Offset: 0x001EB6B0
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				20
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2295
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
