using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E9 RID: 5609
	public class GuildActivityFrame : ClientFrame
	{
		// Token: 0x0600DB87 RID: 56199 RVA: 0x00375212 File Offset: 0x00373612
		public static void OpenGuildManorFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildManorFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DB88 RID: 56200 RVA: 0x00375226 File Offset: 0x00373626
		public static void OpenGuildCrossManorFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildCrossManorFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DB89 RID: 56201 RVA: 0x0037523A File Offset: 0x0037363A
		public static void OpenGuildDungeonHelpFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonHelpFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DB8A RID: 56202 RVA: 0x00375250 File Offset: 0x00373650
		public static bool IsGuildDungeonUnLocked()
		{
			int guildDungeonActivityGuildLvLimit = GuildDataManager.GetGuildDungeonActivityGuildLvLimit();
			int guildDungeonActivityPlayerLvLimit = GuildDataManager.GetGuildDungeonActivityPlayerLvLimit();
			return DataManager<GuildDataManager>.GetInstance().GetGuildLv() >= guildDungeonActivityGuildLvLimit && (int)DataManager<PlayerBaseData>.GetInstance().Level >= guildDungeonActivityPlayerLvLimit;
		}

		// Token: 0x0600DB8B RID: 56203 RVA: 0x0037528C File Offset: 0x0037368C
		public static string GetGuildManorStateText()
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_NORMAL)
			{
				return string.Empty;
			}
			switch (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState())
			{
			case EGuildBattleState.Signup:
				return TR.Value("guild_activity_signup_state");
			case EGuildBattleState.Preparing:
				return TR.Value("guild_activity_prepare_state");
			case EGuildBattleState.Firing:
				return TR.Value("guild_activity_firing_state");
			case EGuildBattleState.LuckyDraw:
				return TR.Value("guild_activity_lucydraw_state");
			default:
				return string.Empty;
			}
		}

		// Token: 0x0600DB8C RID: 56204 RVA: 0x00375308 File Offset: 0x00373708
		public static string GetCrossGuildManorStateText()
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_CROSS)
			{
				return string.Empty;
			}
			switch (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState())
			{
			case EGuildBattleState.Signup:
				return TR.Value("guild_activity_signup_state");
			case EGuildBattleState.Preparing:
				return TR.Value("guild_activity_prepare_state");
			case EGuildBattleState.Firing:
				return TR.Value("guild_activity_firing_state");
			case EGuildBattleState.LuckyDraw:
				return TR.Value("guild_activity_lucydraw_state");
			default:
				return string.Empty;
			}
		}

		// Token: 0x0600DB8D RID: 56205 RVA: 0x00375384 File Offset: 0x00373784
		public static string GetGuildDungeonStateText()
		{
			GuildDungeonStatus guildDungeonActivityStatus = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus();
			return string.Empty;
		}

		// Token: 0x0600DB8E RID: 56206 RVA: 0x003753A4 File Offset: 0x003737A4
		public static bool IsShowGuildManorRedPoint()
		{
			ERedPoint a_eType = ERedPoint.GuildTerrDayReward;
			return DataManager<RedPointDataManager>.GetInstance().HasRedPoint(a_eType);
		}

		// Token: 0x0600DB8F RID: 56207 RVA: 0x003753C1 File Offset: 0x003737C1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildActivity";
		}

		// Token: 0x0600DB90 RID: 56208 RVA: 0x003753C8 File Offset: 0x003737C8
		protected override void _OnOpenFrame()
		{
			this.guildActivityDatas = new List<GuildActivityFrame.GuildActivityData>();
			this.UpdateGuildActivityList();
			this.BindUIEvent();
		}

		// Token: 0x0600DB91 RID: 56209 RVA: 0x003753E1 File Offset: 0x003737E1
		protected override void _OnCloseFrame()
		{
			this.guildActivityDatas = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600DB92 RID: 56210 RVA: 0x003753F0 File Offset: 0x003737F0
		protected override void _bindExUI()
		{
			this.activitys = this.mBind.GetCom<ComUIListScript>("activitys");
		}

		// Token: 0x0600DB93 RID: 56211 RVA: 0x00375408 File Offset: 0x00373808
		protected override void _unbindExUI()
		{
			this.activitys = null;
		}

		// Token: 0x0600DB94 RID: 56212 RVA: 0x00375411 File Offset: 0x00373811
		private void BindUIEvent()
		{
		}

		// Token: 0x0600DB95 RID: 56213 RVA: 0x00375413 File Offset: 0x00373813
		private void UnBindUIEvent()
		{
		}

		// Token: 0x0600DB96 RID: 56214 RVA: 0x00375418 File Offset: 0x00373818
		private void CalcGuildActivityDatas()
		{
			this.guildActivityDatas = new List<GuildActivityFrame.GuildActivityData>();
			if (this.guildActivityDatas == null)
			{
				return;
			}
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildActivityTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildActivityTable guildActivityTable = keyValuePair.Value as GuildActivityTable;
					if (guildActivityTable != null)
					{
						GuildActivityFrame.GuildActivityData guildActivityData = new GuildActivityFrame.GuildActivityData
						{
							guildActivityTableID = guildActivityTable.ID
						};
						if (guildActivityData != null)
						{
							this.guildActivityDatas.Add(guildActivityData);
						}
					}
				}
			}
		}

		// Token: 0x0600DB97 RID: 56215 RVA: 0x003754B8 File Offset: 0x003738B8
		private void UpdateGuildActivityItem(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.guildActivityDatas == null)
			{
				return;
			}
			if (item.m_index >= this.guildActivityDatas.Count)
			{
				return;
			}
			GuildActivityItem guildActivityItem = item.gameObjectBindScript as GuildActivityItem;
			if (guildActivityItem != null && this.guildActivityDatas[item.m_index] != null)
			{
				guildActivityItem.SetUp(this.guildActivityDatas[item.m_index]);
			}
		}

		// Token: 0x0600DB98 RID: 56216 RVA: 0x0037553C File Offset: 0x0037393C
		private void UpdateGuildActivityList()
		{
			if (this.activitys == null)
			{
				return;
			}
			this.CalcGuildActivityDatas();
			if (this.guildActivityDatas == null)
			{
				return;
			}
			this.activitys.Initialize();
			this.activitys.onBindItem = delegate(GameObject item)
			{
				if (item != null)
				{
					return item.GetComponent<GuildActivityItem>();
				}
				return null;
			};
			this.activitys.onItemVisiable = delegate(ComUIListElementScript item)
			{
				this.UpdateGuildActivityItem(item);
			};
			this.activitys.OnItemUpdate = delegate(ComUIListElementScript item)
			{
				this.UpdateGuildActivityItem(item);
			};
			this.activitys.UpdateElementAmount(this.guildActivityDatas.Count);
		}

		// Token: 0x0400815C RID: 33116
		private List<GuildActivityFrame.GuildActivityData> guildActivityDatas;

		// Token: 0x0400815D RID: 33117
		private ComUIListScript activitys;

		// Token: 0x020015EA RID: 5610
		public class GuildActivityData
		{
			// Token: 0x0400815F RID: 33119
			public int guildActivityTableID;
		}
	}
}
