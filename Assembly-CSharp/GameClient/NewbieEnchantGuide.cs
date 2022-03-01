using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200103E RID: 4158
	public class NewbieEnchantGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009CDB RID: 40155 RVA: 0x001EB1C4 File Offset: 0x001E95C4
		public NewbieEnchantGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009CDC RID: 40156 RVA: 0x001EB1D0 File Offset: 0x001E95D0
		public override void InitContent()
		{
			List<NewbieModifyData> list = new List<NewbieModifyData>();
			list.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.EnchantID
			});
			List<NewbieModifyData> list2 = new List<NewbieModifyData>();
			list2.Add(new NewbieModifyData
			{
				iIndex = 1,
				ModifyDataType = NewBieModifyDataType.EnchantMagicCardID
			});
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong",
				"可以对装备进行<color=#ff0000ff>附魔</color>咯~前往锻冶屋看看吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"bottomrightVertical/bestrongroot/beStrong/children/forge",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"附魔可以使用材料对装备进行\n<color=#ff0000ff>属性</color>添加，另外同品质的附魔\n卡还可以进行<color=#ff0000ff>合成</color>!"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"SmithShopFrame",
				"VerticalFilter/FT_ADDMAGIC",
				"选择附魔切页",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				0.3f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"SmithShopFrame",
				"ScrollView/ViewPort/Content",
				"选择装备之后，会显示可以进行附魔的材料",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.TOGGLE, null, new object[]
			{
				"SmithShopFrame",
				"Magic/AddMagic/Right/ScrollView/ViewPort/Content/210000901",
				"再选择一个附魔效果",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(-450f, 0f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"SmithShopFrame",
				"Magic/AddMagic/Left/BtnAddMagic",
				"开始进行附魔吧",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.WAIT, null, new object[]
			{
				1f
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION2, null, new object[]
			{
				"装备附魔是提升装备属性\n的重要一环，而且可随时\n更换，非常实用~"
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"EnchantResultFrame",
				"OK",
				string.Empty,
				ComNewbieGuideBase.eNewbieGuideAnchor.TopRight,
				TextTipType.TextTipType_Two,
				new Vector3(0f, 0f, 0f)
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

		// Token: 0x06009CDD RID: 40157 RVA: 0x001EB4FC File Offset: 0x001E98FC
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				21
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
