using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001043 RID: 4163
	public class NewbieEquipmentGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CEA RID: 40170 RVA: 0x001EBF14 File Offset: 0x001EA314
		public NewbieEquipmentGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CEB RID: 40171 RVA: 0x001EBF20 File Offset: 0x001EA320
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.EquipInPackagePos
			});
			List<NewbieModifyData> list2 = new List<NewbieModifyData>();
			list2.Add(new NewbieModifyData
			{
				iIndex = 0,
				ModifyDataType = NewBieModifyDataType.PackageEquipTipsGuidePos
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"打开背包，查看\n获得的<color=#fcff21>新装备</color>吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				new Vector3(0f, 0f, 0f),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.5f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list, new object[]
			{
				"PackageFrame",
				"Content/ItemListView/Viewport/Content/ItemRoot_{0}/{1}/ItemGroup/Icon",
				"选择装备",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list2, new object[]
			{
				"tipItemFrame{0}",
				"Func/Special",
				"点击穿戴",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"冒险家大人，及时<color=#fcff21>更换装备</color>可以\n有效提升战力！获得新装备时请\n务必及时处理喔！"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ItemGroupFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TALK_DIALOG, null, new object[]
			{
				22030
			}));
		}

		// Token: 0x06009CEC RID: 40172 RVA: 0x001EC144 File Offset: 0x001EA544
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				2
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2302
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.EquipmentInPackage, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MagicBoxGuide, null, null));
		}
	}
}
