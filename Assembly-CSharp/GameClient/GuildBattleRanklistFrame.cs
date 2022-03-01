using System;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015F3 RID: 5619
	internal class GuildBattleRanklistFrame : ClientFrame
	{
		// Token: 0x0600DC26 RID: 56358 RVA: 0x003796A3 File Offset: 0x00377AA3
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattleRanklist";
		}

		// Token: 0x0600DC27 RID: 56359 RVA: 0x003796AA File Offset: 0x00377AAA
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
		}

		// Token: 0x0600DC28 RID: 56360 RVA: 0x003796B8 File Offset: 0x00377AB8
		protected override void _OnCloseFrame()
		{
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DC29 RID: 56361 RVA: 0x003796C6 File Offset: 0x00377AC6
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleRanklistChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleRanklistChanged));
		}

		// Token: 0x0600DC2A RID: 56362 RVA: 0x003796E3 File Offset: 0x00377AE3
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleRanklistChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleRanklistChanged));
		}

		// Token: 0x0600DC2B RID: 56363 RVA: 0x00379700 File Offset: 0x00377B00
		private void _InitUI()
		{
			this._InitTabs();
			this._InitRanklists();
			this._SetupCurrentRanklist();
		}

		// Token: 0x0600DC2C RID: 56364 RVA: 0x00379714 File Offset: 0x00377B14
		private void _ClearUI()
		{
			this._ClearTabs();
			this._ClearRankLists();
		}

		// Token: 0x0600DC2D RID: 56365 RVA: 0x00379724 File Offset: 0x00377B24
		private void _InitTabs()
		{
			this.m_toggleSelf.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				this.m_comScrollRank42.SetElementAmount(0);
				this.m_objSelfRank42.SetActive(false);
				if (a_bChecked)
				{
					this.m_eCurrentRanklist = SortListType.SORTLIST_GUILD_BATTLE_MEMBER;
					DataManager<GuildDataManager>.GetInstance().RequestRanklist(this.m_eCurrentRanklist, 0, 100);
				}
			});
			this.m_toggleGuild.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				this.m_comScrollRank41.SetElementAmount(0);
				this.m_objSelfRank41.SetActive(false);
				if (a_bChecked)
				{
					this.m_eCurrentRanklist = SortListType.SORTLIST_GUILD_BATTLE_SCORE;
					DataManager<GuildDataManager>.GetInstance().RequestRanklist(this.m_eCurrentRanklist, 0, 100);
				}
			});
			this.m_toggleDetail.onValueChanged.AddListener(delegate(bool a_bChecked)
			{
				this.m_comScrollRank43.SetElementAmount(0);
				this.m_objSelfRank43.SetActive(false);
				if (a_bChecked)
				{
					this.m_eCurrentRanklist = SortListType.SORTLIST_GUILD_MEMBER_SCORE;
					DataManager<GuildDataManager>.GetInstance().RequestRanklist(this.m_eCurrentRanklist, 0, 100);
				}
			});
			this.m_Server.gameObject.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS);
		}

		// Token: 0x0600DC2E RID: 56366 RVA: 0x003797A2 File Offset: 0x00377BA2
		private void _ClearTabs()
		{
		}

		// Token: 0x0600DC2F RID: 56367 RVA: 0x003797A4 File Offset: 0x00377BA4
		private void _InitRanklists()
		{
			this.m_comScrollRank42.Initialize();
			this.m_comScrollRank42.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.m_ranklistData.entries.Count)
				{
					GuildBattleMemberScore guildBattleMemberScore = this.m_ranklistData.entries[item.m_index] as GuildBattleMemberScore;
					Utility.GetComponetInChild<Text>(item.gameObject, "Rank").text = guildBattleMemberScore.ranking.ToString();
					Utility.GetComponetInChild<Text>(item.gameObject, "Name").text = guildBattleMemberScore.name;
					Utility.GetComponetInChild<Text>(item.gameObject, "Score").text = guildBattleMemberScore.score.ToString();
					Utility.GetComponetInChild<Text>(item.gameObject, "GuildName").text = guildBattleMemberScore.guildName;
				}
			};
			this.m_comScrollRank41.Initialize();
			this.m_comScrollRank41.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.m_ranklistData.entries.Count)
				{
					GuildBattleScore guildBattleScore = this.m_ranklistData.entries[item.m_index] as GuildBattleScore;
					Utility.GetComponetInChild<Text>(item.gameObject, "Rank").text = guildBattleScore.ranking.ToString();
					Utility.GetComponetInChild<Text>(item.gameObject, "Name").text = guildBattleScore.name;
					Utility.GetComponetInChild<Text>(item.gameObject, "Score").text = guildBattleScore.score.ToString();
					Text[] componentsInChildren = item.gameObject.GetComponentsInChildren<Text>(true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i].name == "Server")
						{
							if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
							{
								componentsInChildren[i].text = guildBattleScore.serverName;
							}
							componentsInChildren[i].gameObject.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS);
							break;
						}
					}
				}
			};
			this.m_comScrollRank43.Initialize();
			this.m_comScrollRank43.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0 && item.m_index < this.m_ranklistData.entries.Count)
				{
					GuildBattleMemberScore guildBattleMemberScore = this.m_ranklistData.entries[item.m_index] as GuildBattleMemberScore;
					Utility.GetComponetInChild<Text>(item.gameObject, "Rank").text = guildBattleMemberScore.ranking.ToString();
					Utility.GetComponetInChild<Text>(item.gameObject, "Name").text = guildBattleMemberScore.name;
					Utility.GetComponetInChild<Text>(item.gameObject, "Score").text = guildBattleMemberScore.score.ToString();
				}
			};
			this.m_repeatCall = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(10000, delegate
			{
				DataManager<GuildDataManager>.GetInstance().RequestRanklist(this.m_eCurrentRanklist, 0, 100);
			}, 9999999, false);
		}

		// Token: 0x0600DC30 RID: 56368 RVA: 0x00379844 File Offset: 0x00377C44
		private void _UpdateRankLists(BaseSortList a_ranklist)
		{
			if (a_ranklist.type != this.m_eCurrentRanklist)
			{
				return;
			}
			this.m_ranklistData = a_ranklist;
			SortListType type = this.m_ranklistData.type;
			if (type != SortListType.SORTLIST_GUILD_BATTLE_MEMBER)
			{
				if (type != SortListType.SORTLIST_GUILD_BATTLE_SCORE)
				{
					if (type == SortListType.SORTLIST_GUILD_MEMBER_SCORE)
					{
						this.m_comScrollRank43.SetElementAmount(this.m_ranklistData.entries.Count);
						this.m_objSelfRank43.SetActive(true);
						GuildBattleMemberScore guildBattleMemberScore = this.m_ranklistData.selfEntry as GuildBattleMemberScore;
						Utility.GetComponetInChild<Text>(this.m_objSelfRank43, "Rank").text = ((guildBattleMemberScore.ranking > 0) ? guildBattleMemberScore.ranking.ToString() : TR.Value("guild_battle_no_rank"));
						Utility.GetComponetInChild<Text>(this.m_objSelfRank43, "Name").text = DataManager<PlayerBaseData>.GetInstance().Name;
						Utility.GetComponetInChild<Text>(this.m_objSelfRank43, "Score").text = guildBattleMemberScore.score.ToString();
					}
				}
				else
				{
					this.m_comScrollRank41.SetElementAmount(this.m_ranklistData.entries.Count);
					this.m_objSelfRank41.SetActive(true);
					GuildBattleScore guildBattleScore = this.m_ranklistData.selfEntry as GuildBattleScore;
					Utility.GetComponetInChild<Text>(this.m_objSelfRank41, "Rank").text = ((guildBattleScore.ranking > 0) ? guildBattleScore.ranking.ToString() : TR.Value("guild_battle_no_rank"));
					Utility.GetComponetInChild<Text>(this.m_objSelfRank41, "Name").text = DataManager<GuildDataManager>.GetInstance().GetMyGuildName();
					Utility.GetComponetInChild<Text>(this.m_objSelfRank41, "Score").text = guildBattleScore.score.ToString();
					Text[] componentsInChildren = this.m_objSelfRank41.GetComponentsInChildren<Text>(true);
					for (int i = 0; i < componentsInChildren.Length; i++)
					{
						if (componentsInChildren[i].name == "Server")
						{
							if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
							{
								componentsInChildren[i].text = guildBattleScore.serverName;
							}
							componentsInChildren[i].gameObject.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS);
							break;
						}
					}
				}
			}
			else
			{
				this.m_comScrollRank42.SetElementAmount(this.m_ranklistData.entries.Count);
				this.m_objSelfRank42.SetActive(true);
				GuildBattleMemberScore guildBattleMemberScore2 = this.m_ranklistData.selfEntry as GuildBattleMemberScore;
				Utility.GetComponetInChild<Text>(this.m_objSelfRank42, "Rank").text = ((guildBattleMemberScore2.ranking > 0) ? guildBattleMemberScore2.ranking.ToString() : TR.Value("guild_battle_no_rank"));
				Utility.GetComponetInChild<Text>(this.m_objSelfRank42, "Name").text = DataManager<PlayerBaseData>.GetInstance().Name;
				Utility.GetComponetInChild<Text>(this.m_objSelfRank42, "Score").text = guildBattleMemberScore2.score.ToString();
				Utility.GetComponetInChild<Text>(this.m_objSelfRank42, "GuildName").text = DataManager<GuildDataManager>.GetInstance().GetMyGuildName();
			}
		}

		// Token: 0x0600DC31 RID: 56369 RVA: 0x00379B7B File Offset: 0x00377F7B
		private void _ClearRankLists()
		{
			this.m_ranklistData = null;
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCall);
		}

		// Token: 0x0600DC32 RID: 56370 RVA: 0x00379B99 File Offset: 0x00377F99
		private void _SetupCurrentRanklist()
		{
			this.m_toggleSelf.isOn = true;
		}

		// Token: 0x0600DC33 RID: 56371 RVA: 0x00379BA7 File Offset: 0x00377FA7
		private void _OnGuildBattleRanklistChanged(UIEvent a_event)
		{
			this._UpdateRankLists(a_event.Param1 as BaseSortList);
		}

		// Token: 0x0600DC34 RID: 56372 RVA: 0x00379BBA File Offset: 0x00377FBA
		[UIEventHandle("Content/Close")]
		private void _OnCloseClicked()
		{
			this.frameMgr.CloseFrame<GuildBattleRanklistFrame>(this, false);
		}

		// Token: 0x040081EF RID: 33263
		[UIControl("Content/Tabs/Self", typeof(Toggle), 0)]
		private Toggle m_toggleSelf;

		// Token: 0x040081F0 RID: 33264
		[UIControl("Content/ScrollGroup/ScrollView42", typeof(ComUIListScript), 0)]
		private ComUIListScript m_comScrollRank42;

		// Token: 0x040081F1 RID: 33265
		[UIObject("Content/SelfGroup/Self42")]
		private GameObject m_objSelfRank42;

		// Token: 0x040081F2 RID: 33266
		[UIControl("Content/Tabs/Guild", typeof(Toggle), 0)]
		private Toggle m_toggleGuild;

		// Token: 0x040081F3 RID: 33267
		[UIControl("Content/ScrollGroup/ScrollView41", typeof(ComUIListScript), 0)]
		private ComUIListScript m_comScrollRank41;

		// Token: 0x040081F4 RID: 33268
		[UIObject("Content/SelfGroup/Self41")]
		private GameObject m_objSelfRank41;

		// Token: 0x040081F5 RID: 33269
		[UIControl("Content/Tabs/Detail", typeof(Toggle), 0)]
		private Toggle m_toggleDetail;

		// Token: 0x040081F6 RID: 33270
		[UIControl("Content/ScrollGroup/ScrollView43", typeof(ComUIListScript), 0)]
		private ComUIListScript m_comScrollRank43;

		// Token: 0x040081F7 RID: 33271
		[UIObject("Content/SelfGroup/Self43")]
		private GameObject m_objSelfRank43;

		// Token: 0x040081F8 RID: 33272
		[UIControl("Content/TitleGroup/Title41/Server", typeof(Text), 0)]
		private Text m_Server;

		// Token: 0x040081F9 RID: 33273
		private SortListType m_eCurrentRanklist = SortListType.SORTLIST_GUILD_BATTLE_MEMBER;

		// Token: 0x040081FA RID: 33274
		private BaseSortList m_ranklistData;

		// Token: 0x040081FB RID: 33275
		private DelayCallUnitHandle m_repeatCall;
	}
}
