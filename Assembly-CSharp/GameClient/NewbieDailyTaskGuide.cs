using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001036 RID: 4150
	public class NewbieDailyTaskGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CC2 RID: 40130 RVA: 0x001EA594 File Offset: 0x001E8994
		public NewbieDailyTaskGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CC3 RID: 40131 RVA: 0x001EA5A0 File Offset: 0x001E89A0
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.DailyMissionPos
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/dailyroot/daily",
				"可以进行<color=#ff0000ff>每日任务</color>了，点击打开活动界面吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"这里包含了游戏内所有的活动，\n包括<color=#ff0000ff>特殊地下城</color>，决斗活动等，\n每天记得都来看一看哦"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"ActivityDungeonFrame",
				"L/Reward",
				"选择日常任务切页",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"完成任务可获得积分，积分到达一定数\n额就可领取额外宝箱哦\n注意每日任务每天6点刷新哦！\n努力完成每日任务获得任务奖励吧！"
			}));
		}

		// Token: 0x06009CC4 RID: 40132 RVA: 0x001EA6AC File Offset: 0x001E8AAC
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				13
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2212
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
