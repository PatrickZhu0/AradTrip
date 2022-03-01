using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001057 RID: 4183
	public class NewbieWelfareGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D26 RID: 40230 RVA: 0x001EE6DC File Offset: 0x001ECADC
		public NewbieWelfareGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D27 RID: 40231 RVA: 0x001EE6E8 File Offset: 0x001ECAE8
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			NewbieModifyData item = default(NewbieModifyData);
			item.iIndex = 0;
			item.ModifyDataType = NewBieModifyDataType.WelfareID;
			NewbieModifyData item2 = default(NewbieModifyData);
			item2.iIndex = 1;
			item2.ModifyDataType = NewBieModifyDataType.SignInID;
			list.Add(item);
			list.Add(item2);
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"topright2/activeSevenDays/activeSevenDays",
				"七日活动解锁啦，一起来看看~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Three,
				new Vector3(-600f, -300f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.1f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ActiveChargeFrame9388",
				"Activities/FirstDayActive7100/Activities/DailyFuLi/ViewPort/Content/7101/UnAcquired",
				"点击领取奖励",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 35f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"精彩活动等你来领，心动不如行动，\n看到小红点记得进来领取哦"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ActiveChargeFrame9388",
				"Shopbg/tittlebg1/close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight
			}));
		}

		// Token: 0x06009D28 RID: 40232 RVA: 0x001EE85C File Offset: 0x001ECC5C
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				8
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2206
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
