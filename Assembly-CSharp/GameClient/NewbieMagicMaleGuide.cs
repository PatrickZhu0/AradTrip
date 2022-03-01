using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104A RID: 4170
	public class NewbieMagicMaleGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CFF RID: 40191 RVA: 0x001ECDC8 File Offset: 0x001EB1C8
		public NewbieMagicMaleGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D00 RID: 40192 RVA: 0x001ECDD4 File Offset: 0x001EB1D4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"新的地下城开启咯~，我们就来看看去哪获得这些<color=#ff0000ff>能量石</color>吧",
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/2/toggle",
				"这里是盛产能量石的地方",
				ComNewbieGuideBase.eNewbieGuideAnchor.Left,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"可以消耗点券使奖励<color=#ff0000ff>翻倍</color>，甚至三倍哦~"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ActivityDungeonFrame",
				"R/Single/ContentR/Collect/A/GridRoot/2/right/button/go",
				"每天只有<color=#ff0000ff>3次</color>机会哦，马上开始挑战吧！",
				ComNewbieGuideBase.eNewbieGuideAnchor.Left,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 0f, 0f)
			}));
		}

		// Token: 0x06009D01 RID: 40193 RVA: 0x001ECED6 File Offset: 0x001EB2D6
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				19
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
		}
	}
}
