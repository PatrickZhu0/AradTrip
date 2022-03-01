using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001047 RID: 4167
	public class NewbieGuanKaGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CF6 RID: 40182 RVA: 0x001ECB14 File Offset: 0x001EAF14
		public NewbieGuanKaGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CF7 RID: 40183 RVA: 0x001ECB20 File Offset: 0x001EAF20
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.4f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"这里就是<color=#ff0000ff>地下城</color>的入口，包括难\n度选择，地图信息，可能掉落，\n增益药水等信息",
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ChapterNormalFrame",
				"FKRoot/AllRoot/D/R/Start/Start/GroupStart",
				"马上开始挑战地下城",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-420f, 50f, 0f)
			}));
		}

		// Token: 0x06009CF8 RID: 40184 RVA: 0x001ECBCC File Offset: 0x001EAFCC
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ChapterChooseFrameOpen, null, null));
		}
	}
}
