using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001030 RID: 4144
	public class NewbieAutoTraceGuide2 : NewbieGuideDataUnit
	{
		// Token: 0x06009CB0 RID: 40112 RVA: 0x001E9EC8 File Offset: 0x001E82C8
		public NewbieAutoTraceGuide2(int tid) : base(tid)
		{
		}

		// Token: 0x06009CB1 RID: 40113 RVA: 0x001E9ED4 File Offset: 0x001E82D4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"FunctionFrame",
				"ScrollView/ViewPort/Content/Prefab(Clone)",
				"点击任务按钮，开始冒险历程",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_One,
				new Vector3(0f, -200f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
		}

		// Token: 0x06009CB2 RID: 40114 RVA: 0x001E9F44 File Offset: 0x001E8344
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.NewbieGuideID, new int[]
			{
				7
			}, null));
		}
	}
}
