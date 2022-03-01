using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200102F RID: 4143
	public class NewbieAutoTraceGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CAD RID: 40109 RVA: 0x001E9DE4 File Offset: 0x001E81E4
		public NewbieAutoTraceGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CAE RID: 40110 RVA: 0x001E9DF0 File Offset: 0x001E81F0
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.OPEN_EYES, null, new object[0]));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TALK_DIALOG, null, new object[]
			{
				13010
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"FunctionFrame",
				"ScrollView/ViewPort/Content/Prefab(Clone)",
				"点击<color=#ff0000ff>任务追踪</color>可以自动前往任务地点",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_One,
				new Vector3(0f, -200f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
		}

		// Token: 0x06009CAF RID: 40111 RVA: 0x001E9E93 File Offset: 0x001E8293
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
