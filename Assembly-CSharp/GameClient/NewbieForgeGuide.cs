using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001045 RID: 4165
	public class NewbieForgeGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CF0 RID: 40176 RVA: 0x001EC2C0 File Offset: 0x001EA6C0
		public NewbieForgeGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CF1 RID: 40177 RVA: 0x001EC2CC File Offset: 0x001EA6CC
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
			List<NewbieModifyData> list3 = new List<NewbieModifyData>();
			list3.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.ChangedEquipInPackagePos
			});
			List<NewbieModifyData> list4 = new List<NewbieModifyData>();
			list4.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.ActorShowEquipPos
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightHorizon/packge",
				"赶快来穿上武器，点击打开背包界面",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.6f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list, new object[]
			{
				"PackageFrame",
				"Content/ItemListView/Viewport/Content/ItemRoot_{0}/{1}/ItemGroup/Icon",
				"选择武器",
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
				new Vector3(-100f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list3, new object[]
			{
				"PackageFrame",
				"Content/ItemListView/Viewport/Content/ItemRoot_{0}/{1}/ItemGroup/Icon",
				"然后我们来<color=#ff0000ff>分解</color>掉废旧装备",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-400f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list2, new object[]
			{
				"tipItemFrame{0}",
				"Func/Decompose",
				"点击分解",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-100f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"CommonMsgBoxOKCancel",
				"Back/Panel/btOK",
				"分解获得的材料还可以进行<color=#ff0000ff>强化</color>等操作",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-120f, 30f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				2.8f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"DecomposeResultFrame",
				"Result/Title/Close",
				"点击关闭",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list4, new object[]
			{
				"ActorShowFrame",
				"Content/ActorShow/Equips/Right/{0}/{1}/ItemGroup/Icon",
				"选择刚获得的武器",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, list2, new object[]
			{
				"tipItemFrame0",
				"Func/Strengthen",
				"点击强化",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-200f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SmithShopFrame",
				"Strengthen/Matchine/CostContent/BtnStrength",
				"开始强化~",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				2.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"锻冶屋可以强化装备，品阶调整，\n再次封装等功能，是提升<color=#ff0000ff>装备属性</color>\n的主要场所"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.PASS_THROUGH, null, new object[]
			{
				"StrengthenResultFrame",
				"ok_10down/close"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SmithShopFrame",
				"ComWnd/Title/Close",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
			}));
		}

		// Token: 0x06009CF2 RID: 40178 RVA: 0x001EC80C File Offset: 0x001EAC0C
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				9
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.FinishedMissionID, new int[]
			{
				2207
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.EquipmentInPackage, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MagicBoxGuide, null, null));
		}
	}
}
