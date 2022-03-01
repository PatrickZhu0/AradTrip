using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200160A RID: 5642
	public class GuildDungeonAuctionFrame : ClientFrame
	{
		// Token: 0x0600DD10 RID: 56592 RVA: 0x0037F272 File Offset: 0x0037D672
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonAuction";
		}

		// Token: 0x0600DD11 RID: 56593 RVA: 0x0037F27C File Offset: 0x0037D67C
		protected override void _OnOpenFrame()
		{
			this.bToggleInit = true;
			this.itemDataList = null;
			this.InitItems();
			this.BindUIEvent();
			GuildDungeonAuctionFrame.FrameType frameType = GuildDungeonAuctionFrame.FrameType.GuildAuction;
			if (this.userData != null && this.userData is GuildDungeonAuctionFrame.FrameType)
			{
				frameType = (GuildDungeonAuctionFrame.FrameType)this.userData;
			}
			if (frameType == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				this.togGuildAuctionItems.SafeSetToggleOnState(true);
				this.togWorldAuctionItems.SafeSetToggleOnState(false);
			}
			else if (frameType == GuildDungeonAuctionFrame.FrameType.WorldAuction)
			{
				this.togGuildAuctionItems.SafeSetToggleOnState(false);
				this.togWorldAuctionItems.SafeSetToggleOnState(true);
			}
			this.requestGuildAuctionInfoObj = new object();
			object target = this.requestGuildAuctionInfoObj;
			float fDelayTime = 0f;
			float fIntervalTime = 3f;
			float maxValue = float.MaxValue;
			UnityAction onBegin = null;
			if (GuildDungeonAuctionFrame.<>f__mg$cache0 == null)
			{
				GuildDungeonAuctionFrame.<>f__mg$cache0 = new UnityAction(GuildDungeonAuctionFrame.RequestGuildAuctionItem);
			}
			InvokeMethod.InvokeInterval(target, fDelayTime, fIntervalTime, maxValue, onBegin, GuildDungeonAuctionFrame.<>f__mg$cache0, null);
			GuildDungeonAuctionFrame.RequestGuildAuctionItem();
			this.bToggleInit = false;
		}

		// Token: 0x0600DD12 RID: 56594 RVA: 0x0037F35E File Offset: 0x0037D75E
		protected override void _OnCloseFrame()
		{
			this.bToggleInit = true;
			this.itemDataList = null;
			GuildDungeonAuctionFrame.frameType = GuildDungeonAuctionFrame.FrameType.GuildAuction;
			this.UnBindUIEvent();
			InvokeMethod.RmoveInvokeIntervalCall(this.requestGuildAuctionInfoObj);
			this.requestGuildAuctionInfoObj = null;
		}

		// Token: 0x0600DD13 RID: 56595 RVA: 0x0037F38C File Offset: 0x0037D78C
		protected override void _bindExUI()
		{
			this.itemList = this.mBind.GetCom<ComUIListScript>("itemList");
			this.textTitle = this.mBind.GetCom<Text>("textTitle");
			this.textDesc = this.mBind.GetCom<Text>("textDesc");
			this.Help1 = this.mBind.GetGameObject("Help1");
			this.Help2 = this.mBind.GetGameObject("Help2");
			this.Close = this.mBind.GetCom<Button>("Close");
			this.Close.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<GuildDungeonAuctionFrame>(this, false);
			});
			this.togGuildAuctionItems = this.mBind.GetCom<Toggle>("togGuildAuctionItems");
			this.togGuildAuctionItems.SafeAddOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.SetFrameType(GuildDungeonAuctionFrame.FrameType.GuildAuction);
				}
			});
			this.togWorldAuctionItems = this.mBind.GetCom<Toggle>("togWorldAuctionItems");
			this.togWorldAuctionItems.SafeAddOnValueChangedListener(delegate(bool bValue)
			{
				if (bValue)
				{
					this.SetFrameType(GuildDungeonAuctionFrame.FrameType.WorldAuction);
				}
			});
			this.worldAuctionRedPoint = this.mBind.GetGameObject("worldAuctionRedPoint");
			this.guildAuctionRedPoint = this.mBind.GetGameObject("guildAuctionRedPoint");
		}

		// Token: 0x0600DD14 RID: 56596 RVA: 0x0037F4BC File Offset: 0x0037D8BC
		protected override void _unbindExUI()
		{
			this.itemList = null;
			this.textTitle = null;
			this.Help1 = null;
			this.Help2 = null;
			this.textDesc = null;
			this.Close = null;
			this.togGuildAuctionItems = null;
			this.togWorldAuctionItems = null;
			this.worldAuctionRedPoint = null;
			this.guildAuctionRedPoint = null;
		}

		// Token: 0x0600DD15 RID: 56597 RVA: 0x0037F50F File Offset: 0x0037D90F
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonAuctionItemsUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateItems));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonAuctionAddNewItem, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionAddNewItem));
		}

		// Token: 0x0600DD16 RID: 56598 RVA: 0x0037F547 File Offset: 0x0037D947
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonAuctionItemsUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateItems));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonAuctionAddNewItem, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionAddNewItem));
		}

		// Token: 0x0600DD17 RID: 56599 RVA: 0x0037F57F File Offset: 0x0037D97F
		public static void RequestGuildAuctionItem()
		{
			if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionItemReq(GuildAuctionType.G_AUCTION_GUILD);
			}
			else if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.WorldAuction)
			{
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionItemReq(GuildAuctionType.G_AUCTION_WORLD);
			}
		}

		// Token: 0x0600DD18 RID: 56600 RVA: 0x0037F5B1 File Offset: 0x0037D9B1
		public static GuildDungeonAuctionFrame.FrameType GetAuctionFrameType()
		{
			return GuildDungeonAuctionFrame.frameType;
		}

		// Token: 0x0600DD19 RID: 56601 RVA: 0x0037F5B8 File Offset: 0x0037D9B8
		private void SetFrameType(GuildDungeonAuctionFrame.FrameType eType)
		{
			GuildDungeonAuctionFrame.frameType = eType;
			this.InitTitleAndHelp();
			this.UpdateItems();
			GuildDungeonAuctionFrame.RequestGuildAuctionItem();
			if (eType == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				if (!this.bToggleInit)
				{
					DataManager<GuildDataManager>.GetInstance().HaveNewGuildAuctonItem = false;
				}
			}
			else if (eType == GuildDungeonAuctionFrame.FrameType.WorldAuction && !this.bToggleInit)
			{
				DataManager<GuildDataManager>.GetInstance().HaveNewWorldAuctonItem = false;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGuildDungeonAuctionAddNewItem, null, null, null, null);
		}

		// Token: 0x0600DD1A RID: 56602 RVA: 0x0037F630 File Offset: 0x0037DA30
		private void InitItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.itemList.Initialize();
			this.itemList.onBindItem = delegate(GameObject go)
			{
				GuildDungeonAuctionItem result = null;
				if (go)
				{
					result = go.GetComponent<GuildDungeonAuctionItem>();
				}
				return result;
			};
			this.itemList.onItemVisiable = delegate(ComUIListElementScript var1)
			{
				this.UpdateAuctionItem(var1);
			};
			this.itemList.OnItemUpdate = delegate(ComUIListElementScript var1)
			{
				this.UpdateAuctionItem(var1);
			};
		}

		// Token: 0x0600DD1B RID: 56603 RVA: 0x0037F6B0 File Offset: 0x0037DAB0
		private void UpdateAuctionItem(ComUIListElementScript var1)
		{
			if (var1 == null)
			{
				return;
			}
			int index = var1.m_index;
			if (index >= 0 && this.itemDataList != null && index < this.itemDataList.Count)
			{
				GuildDungeonAuctionItem guildDungeonAuctionItem = var1.gameObjectBindScript as GuildDungeonAuctionItem;
				if (guildDungeonAuctionItem != null)
				{
					guildDungeonAuctionItem.SetUp(this.itemDataList[index]);
				}
			}
		}

		// Token: 0x0600DD1C RID: 56604 RVA: 0x0037F720 File Offset: 0x0037DB20
		private void InitTitleAndHelp()
		{
			if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				this.Help1.CustomActive(true);
				this.Help2.CustomActive(false);
				this.textDesc.SafeSetText(TR.Value("auction_guild_desc"));
			}
			else if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.WorldAuction)
			{
				this.Help1.CustomActive(false);
				this.Help2.CustomActive(true);
				this.textDesc.SafeSetText(TR.Value("auction_world_desc"));
			}
		}

		// Token: 0x0600DD1D RID: 56605 RVA: 0x0037F7A4 File Offset: 0x0037DBA4
		private void CalItemDataList()
		{
			this.itemDataList = null;
			if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				this.itemDataList = DataManager<GuildDataManager>.GetInstance().GetGuildAuctionItemDatasForGuildAuction();
			}
			else if (GuildDungeonAuctionFrame.frameType == GuildDungeonAuctionFrame.FrameType.WorldAuction)
			{
				this.itemDataList = DataManager<GuildDataManager>.GetInstance().GetGuildAuctionItemDatasForWorldAuction();
			}
		}

		// Token: 0x0600DD1E RID: 56606 RVA: 0x0037F7F2 File Offset: 0x0037DBF2
		private void UpdateItems()
		{
			if (this.itemList == null)
			{
				return;
			}
			this.CalItemDataList();
			if (this.itemDataList != null)
			{
				this.itemList.UpdateElementAmount(this.itemDataList.Count);
			}
		}

		// Token: 0x0600DD1F RID: 56607 RVA: 0x0037F830 File Offset: 0x0037DC30
		private void _OnUpdateItems(UIEvent uiEvent)
		{
			if (uiEvent.Param1 == null || !(uiEvent.Param1 is GuildAuctionType))
			{
				return;
			}
			GuildAuctionType guildAuctionType = (GuildAuctionType)uiEvent.Param1;
			if ((guildAuctionType == GuildAuctionType.G_AUCTION_GUILD && GuildDungeonAuctionFrame.GetAuctionFrameType() == GuildDungeonAuctionFrame.FrameType.GuildAuction) || (guildAuctionType == GuildAuctionType.G_AUCTION_WORLD && GuildDungeonAuctionFrame.GetAuctionFrameType() == GuildDungeonAuctionFrame.FrameType.WorldAuction))
			{
				this.UpdateItems();
			}
		}

		// Token: 0x0600DD20 RID: 56608 RVA: 0x0037F88E File Offset: 0x0037DC8E
		private void _OnGuildDungeonAuctionAddNewItem(UIEvent uiEvent)
		{
			this.guildAuctionRedPoint.CustomActive(DataManager<GuildDataManager>.GetInstance().HaveNewGuildAuctonItem);
			this.worldAuctionRedPoint.CustomActive(DataManager<GuildDataManager>.GetInstance().HaveNewWorldAuctonItem);
		}

		// Token: 0x04008292 RID: 33426
		private List<GuildDataManager.GuildAuctionItemData> itemDataList;

		// Token: 0x04008293 RID: 33427
		private static GuildDungeonAuctionFrame.FrameType frameType;

		// Token: 0x04008294 RID: 33428
		private object requestGuildAuctionInfoObj;

		// Token: 0x04008295 RID: 33429
		private const float requestInterval = 3f;

		// Token: 0x04008296 RID: 33430
		private bool bToggleInit = true;

		// Token: 0x04008297 RID: 33431
		private ComUIListScript itemList;

		// Token: 0x04008298 RID: 33432
		private Text textTitle;

		// Token: 0x04008299 RID: 33433
		private Text textDesc;

		// Token: 0x0400829A RID: 33434
		private GameObject Help1;

		// Token: 0x0400829B RID: 33435
		private GameObject Help2;

		// Token: 0x0400829C RID: 33436
		private new Button Close;

		// Token: 0x0400829D RID: 33437
		private Toggle togGuildAuctionItems;

		// Token: 0x0400829E RID: 33438
		private Toggle togWorldAuctionItems;

		// Token: 0x0400829F RID: 33439
		private GameObject worldAuctionRedPoint;

		// Token: 0x040082A0 RID: 33440
		private GameObject guildAuctionRedPoint;

		// Token: 0x040082A1 RID: 33441
		[CompilerGenerated]
		private static UnityAction <>f__mg$cache0;

		// Token: 0x0200160B RID: 5643
		public enum FrameType
		{
			// Token: 0x040082A4 RID: 33444
			GuildAuction,
			// Token: 0x040082A5 RID: 33445
			WorldAuction
		}
	}
}
