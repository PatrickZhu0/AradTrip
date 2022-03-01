using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200102C RID: 4140
	public class NewbieAchievementGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CA4 RID: 40100 RVA: 0x001E99BC File Offset: 0x001E7DBC
		public NewbieAchievementGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CA5 RID: 40101 RVA: 0x001E99C8 File Offset: 0x001E7DC8
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.AchievementPos
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"left/mission",
				"<color=#ff0000ff>成就</color>达成！赶快来领取成就奖励吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"left/mission",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"MissionFrameNew",
				"Content/MissionFrame(Clone)/VerticalFilter/FFT_ACHIEVEMENT",
				"选择成就",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.2f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list, new object[]
			{
				"MissionFrameNew",
				"Content/MissionFrame(Clone)/AchievementContent/ScrollView/ViewPort/Content/{0}/BtnAward",
				"点击领取奖励",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-150f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"多多努力吧！\n更多更好的<color=#ff0000ff>成就奖励</color>还在后面呢！"
			}));
		}

		// Token: 0x06009CA6 RID: 40102 RVA: 0x001E9B70 File Offset: 0x001E7F70
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				6
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2204
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.AchievementFinished, null, null));
		}
	}
}
