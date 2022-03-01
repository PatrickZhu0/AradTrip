using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103C RID: 4156
	public class NewbieDuelGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CD5 RID: 40149 RVA: 0x001EB03E File Offset: 0x001E943E
		public NewbieDuelGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CD6 RID: 40150 RVA: 0x001EB048 File Offset: 0x001E9448
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"欢迎来到决斗场\n与其他冒险者<color=#ff0000ff>决斗</color>可以\n提高自己的决斗段位\n赢取丰厚的决斗奖励"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"点击左侧<color=#ff0000ff>奖励查看</color>可以显示你当前战绩\n您也可以通过右侧<color=#ff0000ff>好友挑战</color>和<color=#ff0000ff>自由练习</color>\n功能进行决斗练习"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"PkWaitingRoom",
				"btBegin",
				"有兴趣的话，可以尝试匹配对手开始决斗。",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(250f, 90f, 0f)
			}));
		}

		// Token: 0x06009CD7 RID: 40151 RVA: 0x001EB0E7 File Offset: 0x001E94E7
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				10
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ScenePkWaitingRoom, null, null));
		}
	}
}
