using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001038 RID: 4152
	public class NewbieDegeneratorGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CC8 RID: 40136 RVA: 0x001EA85E File Offset: 0x001E8C5E
		public NewbieDegeneratorGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CC9 RID: 40137 RVA: 0x001EA868 File Offset: 0x001E8C68
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"为了对抗<color=#ff0000ff>黑龙王</color>，必须用能量石激发体内的<color=#ff0000ff>次元石</color>",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"DegeneratorFrame",
				"StoneRoot/stone3",
				"达到对应等级后可开启蕴藏在体内的<color=#ff0000ff>次元石</color>",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"CommonMsgBoxOKCancel",
				"Back/Panel/btOK",
				"确认开启",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"DegeneratorFrame",
				"StoneRoot/stone3",
				"接下来我们进行充能吧！选择刚开启的<color=#ff0000ff>次元石</color>",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-500f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"WarpStoneLvUpFrame",
				"midddle_back/rock1/btCharge",
				"可以点击充能，也可以<color=#ff0000ff>长按</color>进行连续充能",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"升级次元石可以提升角色的<color=#ff0000ff>属性</color>，\n快快收集<color=#ff0000ff>能量石</color>提升自己能力吧~"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"WarpStoneLvUpFrame",
				"midddle_back/btClose",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"DegeneratorFrame",
				"btClose",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
		}

		// Token: 0x06009CCA RID: 40138 RVA: 0x001EAA90 File Offset: 0x001E8E90
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				19
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2220
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
