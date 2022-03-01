using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001050 RID: 4176
	public class NewbieReturnToTownGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D11 RID: 40209 RVA: 0x001ED8E3 File Offset: 0x001EBCE3
		public NewbieReturnToTownGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D12 RID: 40210 RVA: 0x001ED8EC File Offset: 0x001EBCEC
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"DungeonMenuFrame",
				"ButtonRoot/Root/MissionRoot",
				"点击回到主城",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, -300f, 0f),
				eNewbieGuideAgrsName.SaveBoot,
				eNewbieGuideAgrsName.None
			}));
		}

		// Token: 0x06009D13 RID: 40211 RVA: 0x001ED964 File Offset: 0x001EBD64
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				1
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneBattle, null, null));
		}
	}
}
