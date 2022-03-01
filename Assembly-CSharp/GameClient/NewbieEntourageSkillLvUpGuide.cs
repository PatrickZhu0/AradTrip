using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001041 RID: 4161
	public class NewbieEntourageSkillLvUpGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CE4 RID: 40164 RVA: 0x001EB979 File Offset: 0x001E9D79
		public NewbieEntourageSkillLvUpGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CE5 RID: 40165 RVA: 0x001EB984 File Offset: 0x001E9D84
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.EntourageID
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"随从也可以<color=#ff0000ff>升级</color>喔！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"Tabs/Tab1",
				"选择随从列表",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"RetinueFrame",
				"RetinueInfo/RetinueTable/ViewPort/Content/1000/Toggle",
				"选择要升级的随从",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 0f, 0f),
				eNewbieGuideAgrsName.None,
				eNewbieGuideAgrsName.None,
				"RetinueInfo/RetinueTable/ViewPort/Content/1000"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueFrame",
				"RetinueBodyFrame/BodyUnlocked/MainSkill/BtnUpGrade",
				"点击升级",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-400f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.5f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueUpFrame",
				"ButtonUpGrade",
				"升级随从技能需要消耗<color=#ff0000ff>勇者之魂</color>哦,点击升级吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"如果不满意随从的加成效\n果，还可以随时进行<color=#ff0000ff>洗练</color>~"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueUpFrame",
				"Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-300f, 50f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"RetinueFrame",
				"ComWnd/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
		}

		// Token: 0x06009CE6 RID: 40166 RVA: 0x001EBC8C File Offset: 0x001EA08C
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				12
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2211
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
