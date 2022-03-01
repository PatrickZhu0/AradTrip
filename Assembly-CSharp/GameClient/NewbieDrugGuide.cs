using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103A RID: 4154
	public class NewbieDrugGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CCF RID: 40143 RVA: 0x001EABDC File Offset: 0x001E8FDC
		public NewbieDrugGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CD0 RID: 40144 RVA: 0x001EABE8 File Offset: 0x001E8FE8
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.1f,
				false,
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.PauseBattle
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.NEWICON_UNLOCK, null, new object[]
			{
				"UIFlatten/Prefabs/NewbieGuide/DrugGuideMove",
				string.Empty,
				string.Empty,
				3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ClientSystemBattle",
				"DungeonDrugTips/V/Bg/rt/child/drugSlot0",
				"这里是主药品，点击该位置进行滑动，可以打开辅助药品界面",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_One,
				new Vector3(-100f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BATTLEDRUGDRAG, null, new object[]
			{
				"ClientSystemBattle",
				"DungeonDrugTips/V/Bg/rt/child/drugSlot0/Item0",
				"进入战斗前，可以提前配置好药剂哦",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomRight,
				TextTipType.TextTipType_Two,
				new Vector3(-600f, -100f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"ClientSystemBattle",
				"DungeonDrugTips/V/Bg/rt/child/drugSlot0/Item2",
				"点击对应的药品即可使用，主药品可以直接点击使用快试试吧，冒险家~",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_One,
				new Vector3(-400f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.2f,
				false,
				eNewbieGuideAgrsName.ResumeBattle
			}));
		}

		// Token: 0x06009CD1 RID: 40145 RVA: 0x001EADAC File Offset: 0x001E91AC
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				6
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.BattleInitFinished, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.IsDungeon, null, null));
		}
	}
}
