using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001056 RID: 4182
	public class NewbieTitleGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D23 RID: 40227 RVA: 0x001EE3C6 File Offset: 0x001EC7C6
		public NewbieTitleGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D24 RID: 40228 RVA: 0x001EE3D0 File Offset: 0x001EC7D0
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"恭喜你获得了一个<color=#ff0000ff>称号</color>，快来穿戴一下吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ActorShowFrame",
				"Title/Funcs/TitleBook/Btn",
				"打开称号簿",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(200f, -50f, 0f),
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				"Title/Funcs/TitleBook"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"TitleBookFrame",
				"tabs/TCT_MISSION",
				"选择任务分页",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"TitleBookFrame",
				"tittles/ScrollView/Viewport/content/130193001",
				"选择已解锁的称号",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 50f, 0f),
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				"tittles/ScrollView/Viewport/content/130193001"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"TitleBookFrame",
				"FuncControls/Equipt",
				"点击穿戴~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"TitleBookFrame",
				"tittle/close",
				"快回城镇里炫耀一下吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-550f, -50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ItemGroupFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009D25 RID: 40229 RVA: 0x001EE680 File Offset: 0x001ECA80
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				7
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2205
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
