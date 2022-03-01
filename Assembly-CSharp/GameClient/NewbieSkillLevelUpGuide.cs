using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001053 RID: 4179
	public class NewbieSkillLevelUpGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D1A RID: 40218 RVA: 0x001EDFD0 File Offset: 0x001EC3D0
		public NewbieSkillLevelUpGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D1B RID: 40219 RVA: 0x001EDFDC File Offset: 0x001EC3DC
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.JobID
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"可以进行技能升级啦！",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/skill",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, list, new object[]
			{
				"SkillTreeFrame",
				"left/root/JobSkillTree(Clone)/ScrollView/Viewport/Content/ActiveSkillPanel2/Pos10/SkillTreeElement(Clone)/icon",
				"选择技能",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(50f, -100f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SkillTreeFrame",
				"right/down/btLvUp",
				"升级技能需要消耗<color=#ff0000ff>技能点</color>，点击这里升级吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-450f, 60f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"技能升级是提升<color=#ff0000ff>战斗能力</color>的重要手\n段，看到红点记得进行技能升级，丰\n富多样的技能可以自由搭配，千万\n不要忘记配置哦~!"
			}));
		}

		// Token: 0x06009D1C RID: 40220 RVA: 0x001EE17C File Offset: 0x001EC57C
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				7
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
