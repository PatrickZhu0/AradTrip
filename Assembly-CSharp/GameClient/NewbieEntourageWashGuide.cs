using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001042 RID: 4162
	public class NewbieEntourageWashGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CE7 RID: 40167 RVA: 0x001EBCE9 File Offset: 0x001EA0E9
		public NewbieEntourageWashGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CE8 RID: 40168 RVA: 0x001EBCF4 File Offset: 0x001EA0F4
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"Tabs/Tab1",
				"选择随从列表",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(50f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/RetinueTable/ViewPort/Content/1000/Toggle",
				"选择要洗练的随从",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-250f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueFrame",
				"RetinueBodyFrame/BodyEx/HelpSkill/BtnChangeSkill",
				"点击洗练",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-400f, 50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.5f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueChangeSkillFrame",
				"BtnChangeSkill",
				"升级随从技能需要消耗勇者之魂哦,点击升级吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"多多进行洗练，配出你所需要\n的技能加成吧！"
			}));
		}

		// Token: 0x06009CE9 RID: 40169 RVA: 0x001EBEC4 File Offset: 0x001EA2C4
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				27
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
