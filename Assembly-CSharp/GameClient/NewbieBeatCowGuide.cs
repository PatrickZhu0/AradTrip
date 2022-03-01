using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001031 RID: 4145
	public class NewbieBeatCowGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CB3 RID: 40115 RVA: 0x001E9FAB File Offset: 0x001E83AB
		public NewbieBeatCowGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CB4 RID: 40116 RVA: 0x001E9FB4 File Offset: 0x001E83B4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"<color=#ff0000ff>国际斗牛节</color>开赛咯~",
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/1/toggle",
				"每天可以挑战<color=#ff0000ff>2次</color>，赶快来试试吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.Top,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 50f, 0f)
			}));
		}

		// Token: 0x06009CB5 RID: 40117 RVA: 0x001EA040 File Offset: 0x001E8440
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				23
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
		}
	}
}
