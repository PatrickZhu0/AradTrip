using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200102D RID: 4141
	public class NewbieArmorMasterGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CA7 RID: 40103 RVA: 0x001E9BDB File Offset: 0x001E7FDB
		public NewbieArmorMasterGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CA8 RID: 40104 RVA: 0x001E9BE4 File Offset: 0x001E7FE4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"恭喜转职成功，来看看有什么不同吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ActorShowFrame",
				"Title/Funcs/EquipMaster/Btn",
				"进阶职业穿戴对应护甲有加成哦，打开护甲精通界面",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				"Title/Funcs/EquipMaster"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"EquipMasterFrame",
				"Content/State",
				"每穿戴1件装备，就会有相应属性加成",
				ComNewbieGuideBase.eNewbieGuideAnchor.Buttom,
				TextTipType.TextTipType_Two
			}));
		}

		// Token: 0x06009CA9 RID: 40105 RVA: 0x001E9CFA File Offset: 0x001E80FA
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				15
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
