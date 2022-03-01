using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104E RID: 4174
	public class NewbieQuickEquipGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D0B RID: 40203 RVA: 0x001ED4FC File Offset: 0x001EB8FC
		public NewbieQuickEquipGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D0C RID: 40204 RVA: 0x001ED508 File Offset: 0x001EB908
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
				"又有新装备了，快去换上吧",
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
				"ItemListView/Viewport/Content/ItemRoot_{0}/{1}/ItemGroup/Icon",
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
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ItemGroupFrame",
				"BG/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009D0D RID: 40205 RVA: 0x001ED6F0 File Offset: 0x001EBAF0
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				3
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2202
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
		}
	}
}
