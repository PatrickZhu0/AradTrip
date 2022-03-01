using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200104D RID: 4173
	public class NewbieMarketGuide : NewbieGuideDataUnit
	{
		// Token: 0x06009D08 RID: 40200 RVA: 0x001ED30D File Offset: 0x001EB70D
		public NewbieMarketGuide(int tid) : base(tid)
		{
		}

		// Token: 0x06009D09 RID: 40201 RVA: 0x001ED318 File Offset: 0x001EB718
		public override void InitContent()
		{
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"ClientSystemTownFrame",
				"topright/itemmarket",
				"拍卖行开张啦~去看看吧~",
				ComNewbieGuideBase.eNewbieGuideAnchor.Buttom,
				TextTipType.TextTipType_Three,
				default(Vector3),
				eNewbieGuideAgrsName.SaveBoot
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"AuctionFrame",
				"Type",
				"这里是使用金票购买物品的地方，可以按照类型查看商品进行购买",
				ComNewbieGuideBase.eNewbieGuideAnchor.Top,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"AuctionFrame",
				"btSearch",
				"也可以直接全局精确搜索",
				ComNewbieGuideBase.eNewbieGuideAnchor.Top,
				TextTipType.TextTipType_Two
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.INTRODUCTION, null, new object[]
			{
				"AuctionFrame",
				"MyAuction",
				"上架和下架商品可以点击我的拍卖，注意最多上架5件物品哦",
				ComNewbieGuideBase.eNewbieGuideAnchor.TopLeft,
				TextTipType.TextTipType_Two,
				new Vector3(300f, 20f, 0f)
			}));
			base.AddContent(new ComNewbieData(NewbieGuideComType.BUTTON, null, new object[]
			{
				"AuctionFrame",
				"btClose",
				"继续挑战关卡吧~",
				ComNewbieGuideBase.eNewbieGuideAnchor.ButtomLeft,
				TextTipType.TextTipType_Two,
				new Vector3(-50f, 80f, 0f)
			}));
		}

		// Token: 0x06009D0A RID: 40202 RVA: 0x001ED4AC File Offset: 0x001EB8AC
		public override void InitCondition()
		{
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.Level, new int[]
			{
				12
			}, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.SceneTown, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.ClientSystemTownFrameOpen, null, null));
			base.AddCondition(new NewbieConditionData(eNewbieGuideCondition.MainFrameMutex, null, null));
		}
	}
}
