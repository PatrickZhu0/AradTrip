using System;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015EF RID: 5615
	internal class GuildBattleFrame : ClientFrame
	{
		// Token: 0x0600DBE4 RID: 56292 RVA: 0x00377513 File Offset: 0x00375913
		public override void Init()
		{
		}

		// Token: 0x0600DBE5 RID: 56293 RVA: 0x00377515 File Offset: 0x00375915
		public override void Clear()
		{
		}

		// Token: 0x0600DBE6 RID: 56294 RVA: 0x00377517 File Offset: 0x00375917
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildBattle";
		}

		// Token: 0x0600DBE7 RID: 56295 RVA: 0x00377520 File Offset: 0x00375920
		protected override void _OnOpenFrame()
		{
			this._InitUI();
			this._RegisterUIEvent();
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam != null)
			{
				DataManager<TeamDataManager>.GetInstance().QuitTeam(DataManager<PlayerBaseData>.GetInstance().RoleID);
			}
		}

		// Token: 0x0600DBE8 RID: 56296 RVA: 0x0037755E File Offset: 0x0037595E
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OutPkWaitingScene, null, null, null, null);
			if (this.mComTalk != null)
			{
				ComTalk.Recycle();
				this.mComTalk = null;
			}
			this._ClearUI();
			this._UnRegisterUIEvent();
		}

		// Token: 0x0600DBE9 RID: 56297 RVA: 0x0037759C File Offset: 0x0037599C
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleRewardGetSuccess, new ClientEventSystem.UIEventHandler(this._OnRewardGetSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStartMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStopMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleRecordSync, new ClientEventSystem.UIEventHandler(this._OnBattleRecordSync));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildSelfRankChanged, new ClientEventSystem.UIEventHandler(this._OnSelfRankChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildBattleRanklistChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleRanklistChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataGuildUpdated));
		}

		// Token: 0x0600DBEA RID: 56298 RVA: 0x0037769C File Offset: 0x00375A9C
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleRewardGetSuccess, new ClientEventSystem.UIEventHandler(this._OnRewardGetSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleStateChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStateUpdated));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStartMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnGuildBattleStopMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleRecordSync, new ClientEventSystem.UIEventHandler(this._OnBattleRecordSync));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildSelfRankChanged, new ClientEventSystem.UIEventHandler(this._OnSelfRankChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildBattleRanklistChanged, new ClientEventSystem.UIEventHandler(this._OnGuildBattleRanklistChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildInspireSuccess, new ClientEventSystem.UIEventHandler(this._OnInspireSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerDataGuildUpdated, new ClientEventSystem.UIEventHandler(this._OnPlayerDataGuildUpdated));
		}

		// Token: 0x0600DBEB RID: 56299 RVA: 0x0037779C File Offset: 0x00375B9C
		private void _InitUI()
		{
			this.m_objRewardPreviewTemplate.SetActive(false);
			this.m_objRewardPreviewTemplate.transform.SetParent(this.frame.transform, false);
			this.m_objBattleCostTemplate.SetActive(false);
			this.m_objBattleCostTemplate.transform.SetParent(this.frame.transform, false);
			this.mGuild.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_CROSS);
			this.mBtMenu.CustomActive(DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() != GuildBattleType.GBT_CROSS);
			this.mComTalk = ComTalk.Create(this.m_objTalkRoot);
			this._InitRewardInfo();
			this._UpdateReward();
			this._HideRewardPreview();
			this._UpdateBattleStart(false);
			this._UpdateFreeTime();
			this._UpdateTitle();
			this._UpdateGuildRankList(null);
			this._UpdateLeftShowInfo();
			this.m_repeatCall = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(10000, delegate
			{
				DataManager<GuildDataManager>.GetInstance().RequestSelfRanklist();
			}, 9999999, true);
			this.m_repeatCallBattleTime = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(1000, delegate
			{
				this._UpdateBattleTime();
			}, 9999999, true);
			this.m_repeatCallSyncGuildRank = Singleton<ClientSystemManager>.GetInstance().delayCaller.RepeatCall(10000, delegate
			{
				DataManager<GuildDataManager>.GetInstance().RequestRanklist(SortListType.SORTLIST_GUILD_BATTLE_SCORE, 0, 3);
			}, 9999999, true);
		}

		// Token: 0x0600DBEC RID: 56300 RVA: 0x00377918 File Offset: 0x00375D18
		private void _ClearUI()
		{
			this.m_arrRewardInfos.Clear();
			this.m_arrIdleComItems.Clear();
			this.m_arrUseComItems.Clear();
			this.m_arrBattleCostObjs.Clear();
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCall);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallBattleTime);
			Singleton<ClientSystemManager>.GetInstance().delayCaller.StopItem(this.m_repeatCallSyncGuildRank);
			this._UpdateBattleStart(false);
			this.m_bSimplifyDotweenPlayForward = false;
			this.m_bGuildRankDotweenPlayForward = false;
		}

		// Token: 0x0600DBED RID: 56301 RVA: 0x003779A8 File Offset: 0x00375DA8
		private void _InitRewardInfo()
		{
			this.m_arrRewardInfos.Clear();
			for (int i = 1; i <= 5; i++)
			{
				GuildBattleFrame.RewardInfo rewardInfo = new GuildBattleFrame.RewardInfo();
				rewardInfo.nID = i;
				rewardInfo.objCanGetTip = Utility.FindGameObject(this.frame, string.Format("Reward/Box{0}/ClickGet", i), true);
				rewardInfo.objCanGetEffect = Utility.FindGameObject(this.frame, string.Format("Reward/Box{0}/CanGetEffect", i), true);
				rewardInfo.objAlreadyGot = Utility.FindGameObject(this.frame, string.Format("Reward/Box{0}/AlreadyGot", i), true);
				rewardInfo.comBtnExFunc = Utility.GetComponetInChild<ComButtonEx>(this.frame, string.Format("Reward/Box{0}/Icon", i));
				rewardInfo.comGray = Utility.GetComponetInChild<UIGray>(this.frame, string.Format("Reward/Box{0}/Icon", i));
				rewardInfo.dotween = Utility.GetComponetInChild<DOTweenAnimation>(this.frame, string.Format("Reward/Box{0}/Icon", i));
				rewardInfo.labLimitScore = Utility.GetComponetInChild<Text>(this.frame, string.Format("Reward/Box{0}/Score", i));
				rewardInfo.imgBox = Utility.GetComponetInChild<Image>(this.frame, string.Format("Reward/Box{0}/Icon", i));
				GuildRewardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildRewardTable>(i, string.Empty, string.Empty);
				rewardInfo.nLimitScore = tableItem.TargetScore;
				rewardInfo.arrItems = new List<ItemData>();
				for (int j = 0; j < tableItem.ItemReward.Count; j++)
				{
					string[] array = tableItem.ItemReward[j].Split(new char[]
					{
						'_'
					});
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(int.Parse(array[0]), 100, 0);
					itemData.Count = int.Parse(array[1]);
					rewardInfo.arrItems.Add(itemData);
				}
				if (rewardInfo.nLimitScore <= DataManager<PlayerBaseData>.GetInstance().guildBattleScore)
				{
					if (DataManager<PlayerBaseData>.GetInstance().guildBattleRewardMask.CheckMask((uint)rewardInfo.nID))
					{
						rewardInfo.state = GuildBattleFrame.RewardInfo.EState.Got;
					}
					else
					{
						rewardInfo.state = GuildBattleFrame.RewardInfo.EState.CanGet;
					}
				}
				else
				{
					rewardInfo.state = GuildBattleFrame.RewardInfo.EState.CanotGet;
				}
				rewardInfo.bDirty = true;
				this.m_arrRewardInfos.Add(rewardInfo);
			}
		}

		// Token: 0x0600DBEE RID: 56302 RVA: 0x00377BE4 File Offset: 0x00375FE4
		private void _UpdateLeftShowInfo()
		{
			EGuildBattleState guildBattleState = DataManager<GuildDataManager>.GetInstance().GetGuildBattleState();
			if (guildBattleState >= EGuildBattleState.Firing && guildBattleState <= EGuildBattleState.LuckyDraw)
			{
				this.mBattleInfo.CustomActive(true);
				this.mInspireInfo.CustomActive(false);
				this._UpdateSimplifyBattleInfo();
			}
			else
			{
				this.mBattleInfo.CustomActive(false);
				this.mInspireInfo.CustomActive(true);
				this._UpdateInspireInfo();
			}
		}

		// Token: 0x0600DBEF RID: 56303 RVA: 0x00377C4C File Offset: 0x0037604C
		private void _UpdateInspireInfo()
		{
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireCostIcon, ref this.mInspireCost, ref this.mEnableInspire, GuildBattleOpenType.GBOT_GUILD_SCENE_MAIN);
		}

		// Token: 0x0600DBF0 RID: 56304 RVA: 0x00377C90 File Offset: 0x00376090
		private void _UpdateReward()
		{
			for (int i = 0; i < this.m_arrRewardInfos.Count; i++)
			{
				GuildBattleFrame.RewardInfo info = this.m_arrRewardInfos[i];
				if (info.bDirty)
				{
					info.bDirty = false;
					info.comBtnExFunc.onClick.RemoveAllListeners();
					info.comBtnExFunc.onMouseDown.RemoveAllListeners();
					info.comBtnExFunc.onMouseUp.RemoveAllListeners();
					info.objCanGetTip.SetActive(false);
					info.objCanGetEffect.SetActive(false);
					info.objAlreadyGot.SetActive(false);
					info.comGray.Restore();
					info.dotween.DORewind();
					info.labLimitScore.text = info.nLimitScore.ToString();
					if (info.state == GuildBattleFrame.RewardInfo.EState.CanGet)
					{
						info.objCanGetTip.SetActive(true);
						info.objCanGetEffect.SetActive(true);
						info.dotween.DORestart(false);
						info.comBtnExFunc.onClick.AddListener(delegate()
						{
							DataManager<GuildDataManager>.GetInstance().RequestGetBattleReward(info.nID);
						});
					}
					else if (info.state == GuildBattleFrame.RewardInfo.EState.Got)
					{
						info.comGray.SetGray();
						info.objAlreadyGot.SetActive(true);
					}
					else
					{
						info.comBtnExFunc.onMouseDown.AddListener(delegate(PointerEventData var)
						{
							this._ShowRewardPreview(info);
						});
						info.comBtnExFunc.onMouseUp.AddListener(delegate(PointerEventData var)
						{
							this._HideRewardPreview();
						});
					}
				}
			}
			float num = 0f;
			for (int j = 0; j < this.m_arrRewardInfos.Count; j++)
			{
				GuildBattleFrame.RewardInfo rewardInfo = this.m_arrRewardInfos[j];
				if (rewardInfo.state == GuildBattleFrame.RewardInfo.EState.CanotGet)
				{
					int num2 = 0;
					if (j > 0)
					{
						num2 = this.m_arrRewardInfos[j - 1].nLimitScore;
					}
					num += (float)(DataManager<PlayerBaseData>.GetInstance().guildBattleScore - num2) / (float)(rewardInfo.nLimitScore - num2);
					break;
				}
				if (rewardInfo.state == GuildBattleFrame.RewardInfo.EState.Got || rewardInfo.state == GuildBattleFrame.RewardInfo.EState.CanGet)
				{
					num += 1f;
				}
			}
			this.m_sliProgress.value = num / (float)this.m_arrRewardInfos.Count;
		}

		// Token: 0x0600DBF1 RID: 56305 RVA: 0x00377F48 File Offset: 0x00376348
		private void _RefreshGray()
		{
			for (int i = 0; i < this.m_arrRewardInfos.Count; i++)
			{
				GuildBattleFrame.RewardInfo rewardInfo = this.m_arrRewardInfos[i];
				UIGray.Refresh(rewardInfo.comGray);
			}
		}

		// Token: 0x0600DBF2 RID: 56306 RVA: 0x00377F8C File Offset: 0x0037638C
		private void _ShowRewardPreview(GuildBattleFrame.RewardInfo a_info)
		{
			this.m_objRewardPreview.SetActive(true);
			this.m_labRewardPreviewTitle.text = TR.Value("guild_battle_reward_preview_title", a_info.nLimitScore);
			for (int i = 0; i < a_info.arrItems.Count; i++)
			{
				ComItem comItem;
				if (this.m_arrIdleComItems.Count > 0)
				{
					comItem = this.m_arrIdleComItems[0];
					comItem.transform.parent.gameObject.SetActive(true);
					this.m_arrIdleComItems.RemoveAt(0);
				}
				else
				{
					GameObject gameObject = Object.Instantiate<GameObject>(this.m_objRewardPreviewTemplate);
					gameObject.transform.SetParent(this.m_objRewardPreviewRoot.transform, false);
					gameObject.SetActive(true);
					comItem = base.CreateComItem(gameObject);
				}
				comItem.Setup(a_info.arrItems[i], delegate(GameObject a_obj, ItemData a_item)
				{
					DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
				});
				this.m_arrUseComItems.Add(comItem);
			}
		}

		// Token: 0x0600DBF3 RID: 56307 RVA: 0x00378094 File Offset: 0x00376494
		private void _HideRewardPreview()
		{
			this.m_objRewardPreview.SetActive(false);
			for (int i = 0; i < this.m_arrUseComItems.Count; i++)
			{
				this.m_arrUseComItems[i].transform.parent.gameObject.SetActive(false);
			}
			this.m_arrIdleComItems.AddRange(this.m_arrUseComItems);
			this.m_arrUseComItems.Clear();
		}

		// Token: 0x0600DBF4 RID: 56308 RVA: 0x00378108 File Offset: 0x00376508
		private void _UpdateBattleStart(bool a_bMatching)
		{
			bool flag = DataManager<GuildDataManager>.GetInstance().HasTargetManor() && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Firing;
			if (flag && a_bMatching)
			{
				this.m_bMatching = true;
				this.m_labStart.text = "取消决斗";
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkSeekWaiting>(FrameLayer.Middle, null, string.Empty);
			}
			else
			{
				this.m_bMatching = false;
				this.m_labStart.text = "开始决斗";
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkSeekWaiting>(null, false);
			}
		}

		// Token: 0x0600DBF5 RID: 56309 RVA: 0x00378194 File Offset: 0x00376594
		private void _UpdateFreeTime()
		{
			GuildTerritoryTable tableItem;
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID, string.Empty, string.Empty);
			}
			else
			{
				tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID, string.Empty, string.Empty);
			}
			if (tableItem == null)
			{
				this.m_labRemainFreeTime.gameObject.SetActive(false);
				this.m_objBattleCostRoot.SetActive(false);
				return;
			}
			int guildBattleTimes = DataManager<PlayerBaseData>.GetInstance().guildBattleTimes;
			if (guildBattleTimes < 0)
			{
				Logger.LogErrorFormat("公会战次数非法，当前次数{0}", new object[]
				{
					guildBattleTimes
				});
			}
			else
			{
				int num = guildBattleTimes;
				if (num >= tableItem.MatchIConsume.Count)
				{
					num = tableItem.MatchIConsume.Count - 1;
				}
				string text = tableItem.MatchIConsume[num];
				if (!string.IsNullOrEmpty(text))
				{
					this.m_labRemainFreeTime.gameObject.SetActive(false);
					this.m_objBattleCostRoot.SetActive(true);
					for (int i = 0; i < this.m_arrBattleCostObjs.Count; i++)
					{
						this.m_arrBattleCostObjs[i].SetActive(false);
					}
					string[] array = text.Split(new char[]
					{
						','
					});
					for (int j = 0; j < array.Length; j++)
					{
						string[] array2 = array[j].Split(new char[]
						{
							'_'
						});
						ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(int.Parse(array2[0]));
						GameObject gameObject;
						if (j >= this.m_arrBattleCostObjs.Count)
						{
							gameObject = Object.Instantiate<GameObject>(this.m_objBattleCostTemplate);
							gameObject.transform.SetParent(this.m_objBattleCostRoot.transform, false);
						}
						else
						{
							gameObject = this.m_arrBattleCostObjs[j];
						}
						gameObject.SetActive(true);
						int num2 = int.Parse(array2[1]);
						if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(commonItemTableDataByID.TableID, true) < num2)
						{
							Utility.GetComponetInChild<Text>(gameObject, "Count").text = TR.Value("color_red", array2[1]);
						}
						else
						{
							Utility.GetComponetInChild<Text>(gameObject, "Count").text = array2[1];
						}
						Image componetInChild = Utility.GetComponetInChild<Image>(gameObject, "Icon");
						ETCImageLoader.LoadSprite(ref componetInChild, commonItemTableDataByID.Icon, true);
					}
				}
				else
				{
					int num3 = 0;
					for (int k = num; k < tableItem.MatchIConsume.Count; k++)
					{
						if (!string.IsNullOrEmpty(tableItem.MatchIConsume[k]))
						{
							break;
						}
						num3++;
					}
					this.m_labRemainFreeTime.gameObject.SetActive(true);
					this.m_labRemainFreeTime.text = TR.Value("guild_battle_remain_free_time", num3, num3 + num);
					this.m_objBattleCostRoot.SetActive(false);
				}
			}
			this._RefreshGray();
		}

		// Token: 0x0600DBF6 RID: 56310 RVA: 0x0037849C File Offset: 0x0037689C
		private void _UpdateSimplifyBattleInfo()
		{
			this.m_labSelfRecord.text = TR.Value("guild_battle_simply_record", DataManager<GuildDataManager>.GetInstance().GetGuildBattleWinTimes(), DataManager<GuildDataManager>.GetInstance().GetGuildBattleFailTimes());
			this.m_labSelfScore.text = DataManager<PlayerBaseData>.GetInstance().guildBattleScore.ToString();
		}

		// Token: 0x0600DBF7 RID: 56311 RVA: 0x003784FC File Offset: 0x003768FC
		private void _UpdateBattleTime()
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Firing)
			{
				uint num = DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime() - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num > 0U)
				{
					uint num2 = num % 60U;
					uint num3 = num / 60U;
					this.m_labBattleTime.text = TR.Value("guild_battle_remain_time", num3, num2);
					this.m_imgBattleTimeBG.gameObject.SetActive(true);
					if (num > 600U)
					{
						ETCImageLoader.LoadSprite(ref this.m_imgBattleTimeBG, "UIFlatten/Image/Packed/pck_UI_Guild.png:UI_Gonghui_Lvse_Tiao_Di", true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.m_imgBattleTimeBG, "UIFlatten/Image/Packed/pck_UI_Guild.png:UI_Gonghui_Hongse_Tiao_Di", true);
					}
				}
				else
				{
					this.m_imgBattleTimeBG.gameObject.SetActive(false);
				}
			}
			else
			{
				uint num4 = DataManager<GuildDataManager>.GetInstance().GetGuildBattleStateEndTime() - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num4 > 0U && num4 < 3600U && DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() == EGuildBattleState.Preparing)
				{
					uint num5 = num4 % 60U;
					uint num6 = num4 / 60U;
					this.m_labBattleTime.text = TR.Value("guild_battle_start_time", num6, num5);
					this.m_imgBattleTimeBG.gameObject.SetActive(true);
					ETCImageLoader.LoadSprite(ref this.m_imgBattleTimeBG, "UIFlatten/Image/Packed/pck_UI_Guild.png:UI_Gonghui_Huangse_Tiao_Di", true);
				}
				else
				{
					this.m_imgBattleTimeBG.gameObject.SetActive(false);
				}
			}
			this._RefreshGray();
		}

		// Token: 0x0600DBF8 RID: 56312 RVA: 0x00378674 File Offset: 0x00376A74
		private void _UpdateTitle()
		{
			int id = DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID;
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				id = DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID;
			}
			GuildTerritoryTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
				{
					this.m_labTitle.text = TR.Value("guild_battle_title", tableItem.Name);
				}
				else if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
				{
					this.m_labTitle.text = TR.Value("guild_battle_title", tableItem.Name);
				}
				else
				{
					this.m_labTitle.text = TR.Value("guild_AttackCity_title", tableItem.Name);
				}
			}
			else
			{
				this.m_labTitle.text = TR.Value("guild_battle_title_default");
			}
		}

		// Token: 0x0600DBF9 RID: 56313 RVA: 0x00378764 File Offset: 0x00376B64
		private void _UpdateGuildRankList(BaseSortList a_sortlist)
		{
			if (a_sortlist == null)
			{
				this.m_labGuildRankFirstName.text = TR.Value("guild_battle_guild_rank_sync");
				this.m_labGuildRankSecondName.text = TR.Value("guild_battle_guild_rank_sync");
				this.m_labGuildRankThirdName.text = TR.Value("guild_battle_guild_rank_sync");
				this.m_labGuildRankFirstScore.text = string.Empty;
				this.m_labGuildRankSecondScore.text = string.Empty;
				this.m_labGuildRankThirdScore.text = string.Empty;
			}
			else if (a_sortlist.type == SortListType.SORTLIST_GUILD_BATTLE_SCORE)
			{
				this.m_labGuildRankFirstName.text = TR.Value("guild_battle_guild_rank_none");
				this.m_labGuildRankSecondName.text = TR.Value("guild_battle_guild_rank_none");
				this.m_labGuildRankThirdName.text = TR.Value("guild_battle_guild_rank_none");
				this.m_labGuildRankFirstScore.text = string.Empty;
				this.m_labGuildRankSecondScore.text = string.Empty;
				this.m_labGuildRankThirdScore.text = string.Empty;
				if (a_sortlist.entries != null)
				{
					if (a_sortlist.entries.Count > 0)
					{
						GuildBattleScore guildBattleScore = a_sortlist.entries[0] as GuildBattleScore;
						this.m_labGuildRankFirstName.text = guildBattleScore.name;
						this.m_labGuildRankFirstScore.text = TR.Value("guild_battle_guild_rank_format", guildBattleScore.score);
					}
					if (a_sortlist.entries.Count > 1)
					{
						GuildBattleScore guildBattleScore2 = a_sortlist.entries[1] as GuildBattleScore;
						this.m_labGuildRankSecondName.text = guildBattleScore2.name;
						this.m_labGuildRankSecondScore.text = TR.Value("guild_battle_guild_rank_format", guildBattleScore2.score);
					}
					if (a_sortlist.entries.Count > 2)
					{
						GuildBattleScore guildBattleScore3 = a_sortlist.entries[2] as GuildBattleScore;
						this.m_labGuildRankThirdName.text = guildBattleScore3.name;
						this.m_labGuildRankThirdScore.text = TR.Value("guild_battle_guild_rank_format", guildBattleScore3.score);
					}
				}
			}
		}

		// Token: 0x0600DBFA RID: 56314 RVA: 0x00378970 File Offset: 0x00376D70
		private void _OnRewardGetSuccess(UIEvent a_event)
		{
			int num = (int)((byte)a_event.Param1);
			for (int i = 0; i < this.m_arrRewardInfos.Count; i++)
			{
				if (this.m_arrRewardInfos[i].nID == num)
				{
					this.m_arrRewardInfos[i].state = GuildBattleFrame.RewardInfo.EState.Got;
					this.m_arrRewardInfos[i].bDirty = true;
					this._UpdateReward();
					break;
				}
			}
		}

		// Token: 0x0600DBFB RID: 56315 RVA: 0x003789EC File Offset: 0x00376DEC
		private void _OnGuildBattleStateUpdated(UIEvent a_event)
		{
			this._UpdateBattleStart(this.m_bMatching);
			this._UpdateLeftShowInfo();
			EGuildBattleState eguildBattleState = (EGuildBattleState)a_event.Param1;
			EGuildBattleState eguildBattleState2 = (EGuildBattleState)a_event.Param2;
			if (eguildBattleState == EGuildBattleState.Firing && eguildBattleState2 == EGuildBattleState.Invalid)
			{
				if (this.m_bMatching)
				{
					DataManager<GuildDataManager>.GetInstance().CancelStartBattle();
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleResultFrame>(FrameLayer.Middle, a_event.Param3, string.Empty);
			}
		}

		// Token: 0x0600DBFC RID: 56316 RVA: 0x00378A5C File Offset: 0x00376E5C
		private void _OnGuildBattleStartMatch(UIEvent a_event)
		{
			this._UpdateBattleStart(true);
		}

		// Token: 0x0600DBFD RID: 56317 RVA: 0x00378A65 File Offset: 0x00376E65
		private void _OnGuildBattleStopMatch(UIEvent a_event)
		{
			this._UpdateBattleStart(false);
		}

		// Token: 0x0600DBFE RID: 56318 RVA: 0x00378A6E File Offset: 0x00376E6E
		private void _OnBattleRecordSync(UIEvent a_event)
		{
			this._UpdateLeftShowInfo();
		}

		// Token: 0x0600DBFF RID: 56319 RVA: 0x00378A76 File Offset: 0x00376E76
		private void _OnSelfRankChanged(UIEvent a_event)
		{
			this.m_labSelfRank.text = a_event.Param1.ToString();
			this.m_labGuildRank.text = a_event.Param2.ToString();
		}

		// Token: 0x0600DC00 RID: 56320 RVA: 0x00378AA4 File Offset: 0x00376EA4
		private void _OnGuildBattleRanklistChanged(UIEvent a_event)
		{
			this._UpdateGuildRankList(a_event.Param1 as BaseSortList);
		}

		// Token: 0x0600DC01 RID: 56321 RVA: 0x00378AB8 File Offset: 0x00376EB8
		private void _OnInspireSuccess(UIEvent a_event)
		{
			DataManager<GuildDataManager>.GetInstance().UpdateInspireInfo(ref this.mInspireLevel, ref this.mCurAttr, ref this.mInspireMax, ref this.mInspire, ref this.mInspireCostIcon, ref this.mInspireCost, ref this.mEnableInspire, GuildBattleOpenType.GBOT_GUILD_SCENE_MAIN);
		}

		// Token: 0x0600DC02 RID: 56322 RVA: 0x00378AFC File Offset: 0x00376EFC
		private void _OnPlayerDataGuildUpdated(UIEvent a_event)
		{
			SceneObjectAttr sceneObjectAttr = (SceneObjectAttr)a_event.Param1;
			if (sceneObjectAttr == SceneObjectAttr.SOA_GUILD_BATTLE_NUMBER)
			{
				this._UpdateFreeTime();
			}
		}

		// Token: 0x0600DC03 RID: 56323 RVA: 0x00378B23 File Offset: 0x00376F23
		private void _OnSceneChangedFinish(UIEvent a_event)
		{
		}

		// Token: 0x0600DC04 RID: 56324 RVA: 0x00378B25 File Offset: 0x00376F25
		private void _OnPKMatched(UIEvent a_event)
		{
		}

		// Token: 0x0600DC05 RID: 56325 RVA: 0x00378B28 File Offset: 0x00376F28
		[UIEventHandle("btClose")]
		private void _OnCloseClicked()
		{
			if (this.m_bMatching)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_battle_cannot_operate"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildBattleFrame>(this, false);
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
				if (clientSystemTown != null)
				{
					clientSystemTown.ChangeScene(0, 0, 0, 0, delegate
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
						if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenCrossManorFrame, null, null, null, null);
						}
						else
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildOpenManorFrame, null, null, null, null);
						}
					});
				}
			}
		}

		// Token: 0x0600DC06 RID: 56326 RVA: 0x00378B9E File Offset: 0x00376F9E
		[UIEventHandle("SimplifyBattleInfo/middle/RankDetail")]
		private void _OnRankDetailClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleRanklistFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DC07 RID: 56327 RVA: 0x00378BB2 File Offset: 0x00376FB2
		[UIEventHandle("SimplifyBattleInfo/middle/BattleRecord")]
		private void _OnBattleRecordClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DC08 RID: 56328 RVA: 0x00378BC8 File Offset: 0x00376FC8
		[UIEventHandle("StartBattle/Start")]
		private void _OnStartBattleClicked()
		{
			if (!DataManager<GuildDataManager>.GetInstance().HasTargetManor() || DataManager<GuildDataManager>.GetInstance().GetGuildBattleState() != EGuildBattleState.Firing)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("guild_battle_cannot_start"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (!this.m_bMatching)
			{
				int guildBattleTimes = DataManager<PlayerBaseData>.GetInstance().guildBattleTimes;
				if (guildBattleTimes < 0)
				{
					Logger.LogErrorFormat("公会战次数非法，当前次数{0}", new object[]
					{
						guildBattleTimes
					});
				}
				else
				{
					GuildTerritoryTable tableItem;
					if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
					{
						tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetCrossManorID, string.Empty, string.Empty);
					}
					else
					{
						tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildTerritoryTable>(DataManager<GuildDataManager>.GetInstance().myGuild.nTargetManorID, string.Empty, string.Empty);
					}
					if (tableItem == null)
					{
						Logger.LogErrorFormat("GuildTerritoryTable tableData is null in [_OnStartBattleClicked], GuildBattleType == {0}", new object[]
						{
							DataManager<GuildDataManager>.GetInstance().GetGuildBattleType()
						});
						return;
					}
					int num = guildBattleTimes;
					if (num >= tableItem.MatchIConsume.Count)
					{
						num = tableItem.MatchIConsume.Count - 1;
					}
					string text = tableItem.MatchIConsume[num];
					if (!string.IsNullOrEmpty(text))
					{
						string[] array = text.Split(new char[]
						{
							','
						});
						List<CostItemManager.CostInfo> costInfos = new List<CostItemManager.CostInfo>();
						for (int i = 0; i < array.Length; i++)
						{
							string[] array2 = array[i].Split(new char[]
							{
								'_'
							});
							CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
							costInfo.nMoneyID = int.Parse(array2[0]);
							costInfo.nCount = int.Parse(array2[1]);
							costInfos.Add(costInfo);
						}
						bool flag = false;
						if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
						{
							flag = DataManager<GuildDataManager>.GetInstance().IsJumpTipWhenStartGuildBattle;
						}
						else if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
						{
							flag = DataManager<GuildDataManager>.GetInstance().IsJumpTipWhenStartGuildBattleCorssServer;
						}
						if (flag)
						{
							DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(costInfos, delegate
							{
								DataManager<GuildDataManager>.GetInstance().StartBattle();
							}, null, "common_money_cost");
						}
						else
						{
							SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(new CommonMsgBoxOkCancelNewParamData
							{
								ContentLabel = TR.Value("guild_battle_consume_ask", DataManager<CostItemManager>.GetInstance().GetCostMoneiesDesc(costInfos.ToArray())),
								IsShowNotify = true,
								OnCommonMsgBoxToggleClick = new OnCommonMsgBoxToggleClick(this.onToggleClick),
								LeftButtonText = TR.Value("GuildBattle_OK_Cancle_Lable"),
								RightButtonText = TR.Value("GuildBattle_OK_Buy_Lable"),
								OnRightButtonClickCallBack = delegate()
								{
									DataManager<CostItemManager>.GetInstance().TryCostMoneiesDefault(costInfos, delegate
									{
										DataManager<GuildDataManager>.GetInstance().StartBattle();
									}, null, "common_money_cost");
								}
							});
						}
					}
					else
					{
						DataManager<GuildDataManager>.GetInstance().StartBattle();
					}
				}
			}
			else
			{
				DataManager<GuildDataManager>.GetInstance().CancelStartBattle();
			}
		}

		// Token: 0x0600DC09 RID: 56329 RVA: 0x00378EBA File Offset: 0x003772BA
		private void onToggleClick(bool value)
		{
			if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_NORMAL)
			{
				DataManager<GuildDataManager>.GetInstance().IsJumpTipWhenStartGuildBattle = value;
			}
			else if (DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS)
			{
				DataManager<GuildDataManager>.GetInstance().IsJumpTipWhenStartGuildBattleCorssServer = value;
			}
		}

		// Token: 0x0600DC0A RID: 56330 RVA: 0x00378EF7 File Offset: 0x003772F7
		[UIEventHandle("SimplifyBattleInfo/btOpen")]
		private void _OnOpenCloseSimplifyClicked()
		{
			if (!this.m_bSimplifyDotweenPlayForward)
			{
				this.m_simplifyDotween.DOPlayForward();
				this.m_bSimplifyDotweenPlayForward = true;
			}
			else
			{
				this.m_simplifyDotween.DOPlayBackwards();
				this.m_bSimplifyDotweenPlayForward = false;
			}
		}

		// Token: 0x0600DC0B RID: 56331 RVA: 0x00378F2D File Offset: 0x0037732D
		[UIEventHandle("btMenu")]
		private void _OnMenuClicked()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DC0C RID: 56332 RVA: 0x00378F41 File Offset: 0x00377341
		[UIEventHandle("GuildRank/btOpen")]
		private void _OnOpenCloseGuildRankClicked()
		{
			if (!this.m_bGuildRankDotweenPlayForward)
			{
				this.m_guildRankDotween.DOPlayForward();
				this.m_bGuildRankDotweenPlayForward = true;
			}
			else
			{
				this.m_guildRankDotween.DOPlayBackwards();
				this.m_bGuildRankDotweenPlayForward = false;
			}
		}

		// Token: 0x0600DC0D RID: 56333 RVA: 0x00378F77 File Offset: 0x00377377
		[UIEventHandle("guild")]
		private void _OnReturnToGuildClicked()
		{
			this.frameMgr.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DC0E RID: 56334 RVA: 0x00378F8C File Offset: 0x0037738C
		protected override void _bindExUI()
		{
			this.mBattleInfo = this.mBind.GetGameObject("BattleInfo");
			this.mInspireInfo = this.mBind.GetGameObject("InspireInfo");
			this.mInspireLevel = this.mBind.GetCom<Text>("InspireLevel");
			this.mInspireDetail = this.mBind.GetCom<Button>("InspireDetail");
			this.mInspireDetail.onClick.AddListener(new UnityAction(this._onInspireDetailButtonClick));
			this.mCurAttr = this.mBind.GetCom<Text>("CurAttr");
			this.mInspire = this.mBind.GetCom<Button>("Inspire");
			this.mInspire.onClick.AddListener(new UnityAction(this._onInspireButtonClick));
			this.mInspireCostIcon = this.mBind.GetCom<Image>("InspireCostIcon");
			this.mInspireCost = this.mBind.GetCom<Text>("InspireCost");
			this.mInspireMax = this.mBind.GetGameObject("InspireMax");
			this.mEnableInspire = this.mBind.GetCom<ComButtonEnbale>("EnableInspire");
			this.mGuild = this.mBind.GetGameObject("guild");
			this.mBtMenu = this.mBind.GetGameObject("btMenu");
		}

		// Token: 0x0600DC0F RID: 56335 RVA: 0x003790DC File Offset: 0x003774DC
		protected override void _unbindExUI()
		{
			this.mBattleInfo = null;
			this.mInspireInfo = null;
			this.mInspireLevel = null;
			this.mInspireDetail.onClick.RemoveListener(new UnityAction(this._onInspireDetailButtonClick));
			this.mInspireDetail = null;
			this.mCurAttr = null;
			this.mInspire.onClick.RemoveListener(new UnityAction(this._onInspireButtonClick));
			this.mInspire = null;
			this.mInspireCostIcon = null;
			this.mInspireCost = null;
			this.mInspireMax = null;
			this.mEnableInspire = null;
			this.mGuild = null;
			this.mBtMenu = null;
		}

		// Token: 0x0600DC10 RID: 56336 RVA: 0x00379175 File Offset: 0x00377575
		private void _onInspireDetailButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildInspireDetailFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DC11 RID: 56337 RVA: 0x00379189 File Offset: 0x00377589
		private void _onInspireButtonClick()
		{
			DataManager<GuildDataManager>.GetInstance().SendInspire();
		}

		// Token: 0x0400819E RID: 33182
		[UIControl("Reward/Progress", null, 0)]
		private Slider m_sliProgress;

		// Token: 0x0400819F RID: 33183
		[UIControl("Reward/Preview/Title", null, 0)]
		private Text m_labRewardPreviewTitle;

		// Token: 0x040081A0 RID: 33184
		[UIObject("Reward/Preview/Items")]
		private GameObject m_objRewardPreviewRoot;

		// Token: 0x040081A1 RID: 33185
		[UIObject("Reward/Preview/Items/Template")]
		private GameObject m_objRewardPreviewTemplate;

		// Token: 0x040081A2 RID: 33186
		[UIObject("Reward/Preview")]
		private GameObject m_objRewardPreview;

		// Token: 0x040081A3 RID: 33187
		[UIControl("StartBattle/RemainFreeTime", null, 0)]
		private Text m_labRemainFreeTime;

		// Token: 0x040081A4 RID: 33188
		[UIObject("StartBattle/Cost")]
		private GameObject m_objBattleCostRoot;

		// Token: 0x040081A5 RID: 33189
		[UIObject("StartBattle/Cost/Item")]
		private GameObject m_objBattleCostTemplate;

		// Token: 0x040081A6 RID: 33190
		[UIControl("SimplifyBattleInfo/middle/SelfRecord/Text", null, 0)]
		private Text m_labSelfRecord;

		// Token: 0x040081A7 RID: 33191
		[UIControl("SimplifyBattleInfo/middle/SelfRank/Text", null, 0)]
		private Text m_labSelfRank;

		// Token: 0x040081A8 RID: 33192
		[UIControl("SimplifyBattleInfo/middle/GuildRank/Text", null, 0)]
		private Text m_labGuildRank;

		// Token: 0x040081A9 RID: 33193
		[UIControl("SimplifyBattleInfo/middle/SelfScore/Text", null, 0)]
		private Text m_labSelfScore;

		// Token: 0x040081AA RID: 33194
		[UIControl("title", null, 0)]
		private Text m_labTitle;

		// Token: 0x040081AB RID: 33195
		[UIControl("StartBattle/Start/Text", null, 0)]
		private Text m_labStart;

		// Token: 0x040081AC RID: 33196
		[UIControl("Time/Text", null, 0)]
		private Text m_labBattleTime;

		// Token: 0x040081AD RID: 33197
		[UIControl("Time", null, 0)]
		private Image m_imgBattleTimeBG;

		// Token: 0x040081AE RID: 33198
		[UIControl("SimplifyBattleInfo", null, 0)]
		private DOTweenAnimation m_simplifyDotween;

		// Token: 0x040081AF RID: 33199
		[UIObject("talk")]
		private GameObject m_objTalkRoot;

		// Token: 0x040081B0 RID: 33200
		[UIControl("GuildRank/Content/First/Name", null, 0)]
		private Text m_labGuildRankFirstName;

		// Token: 0x040081B1 RID: 33201
		[UIControl("GuildRank/Content/Second/Name", null, 0)]
		private Text m_labGuildRankSecondName;

		// Token: 0x040081B2 RID: 33202
		[UIControl("GuildRank/Content/Third/Name", null, 0)]
		private Text m_labGuildRankThirdName;

		// Token: 0x040081B3 RID: 33203
		[UIControl("GuildRank/Content/First/Score", null, 0)]
		private Text m_labGuildRankFirstScore;

		// Token: 0x040081B4 RID: 33204
		[UIControl("GuildRank/Content/Second/Score", null, 0)]
		private Text m_labGuildRankSecondScore;

		// Token: 0x040081B5 RID: 33205
		[UIControl("GuildRank/Content/Third/Score", null, 0)]
		private Text m_labGuildRankThirdScore;

		// Token: 0x040081B6 RID: 33206
		[UIControl("GuildRank", null, 0)]
		private DOTweenAnimation m_guildRankDotween;

		// Token: 0x040081B7 RID: 33207
		private List<GuildBattleFrame.RewardInfo> m_arrRewardInfos = new List<GuildBattleFrame.RewardInfo>();

		// Token: 0x040081B8 RID: 33208
		private List<ComItem> m_arrIdleComItems = new List<ComItem>();

		// Token: 0x040081B9 RID: 33209
		private List<ComItem> m_arrUseComItems = new List<ComItem>();

		// Token: 0x040081BA RID: 33210
		private List<GameObject> m_arrBattleCostObjs = new List<GameObject>();

		// Token: 0x040081BB RID: 33211
		private string[] m_arrOpenedBoxIcon = new string[]
		{
			"UI/Image/Icon/Icon_Item/TubiaoXiangzi_MuzhiGuan.png:TubiaoXiangzi_MuzhiGuan",
			"UI/Image/Icon/Icon_Item/TubiaoXiangzi_MuzhiGuan.png:TubiaoXiangzi_MuzhiGuan",
			"UI/Image/Icon/Icon_Item/TubiaoXiangzi_QingtongGuan.png:TubiaoXiangzi_QingtongGuan",
			"UI/Image/Icon/Icon_Item/TubiaoXiangzi_QingtongGuan.png:TubiaoXiangzi_QingtongGuan",
			"UI/Image/Icon/Icon_Item/TubiaoXiangzi_ZhizunGuan.png:TubiaoXiangzi_ZhizunGuan"
		};

		// Token: 0x040081BC RID: 33212
		private bool m_bMatching;

		// Token: 0x040081BD RID: 33213
		private DelayCallUnitHandle m_repeatCall;

		// Token: 0x040081BE RID: 33214
		private DelayCallUnitHandle m_repeatCallBattleTime;

		// Token: 0x040081BF RID: 33215
		private DelayCallUnitHandle m_repeatCallSyncGuildRank;

		// Token: 0x040081C0 RID: 33216
		private bool m_bSimplifyDotweenPlayForward;

		// Token: 0x040081C1 RID: 33217
		private bool m_bGuildRankDotweenPlayForward;

		// Token: 0x040081C2 RID: 33218
		private ComTalk mComTalk;

		// Token: 0x040081C3 RID: 33219
		private GameObject mBattleInfo;

		// Token: 0x040081C4 RID: 33220
		private GameObject mInspireInfo;

		// Token: 0x040081C5 RID: 33221
		private Text mInspireLevel;

		// Token: 0x040081C6 RID: 33222
		private Button mInspireDetail;

		// Token: 0x040081C7 RID: 33223
		private Text mCurAttr;

		// Token: 0x040081C8 RID: 33224
		private Button mInspire;

		// Token: 0x040081C9 RID: 33225
		private Image mInspireCostIcon;

		// Token: 0x040081CA RID: 33226
		private Text mInspireCost;

		// Token: 0x040081CB RID: 33227
		private GameObject mInspireMax;

		// Token: 0x040081CC RID: 33228
		private ComButtonEnbale mEnableInspire;

		// Token: 0x040081CD RID: 33229
		private GameObject mGuild;

		// Token: 0x040081CE RID: 33230
		private GameObject mBtMenu;

		// Token: 0x020015F0 RID: 5616
		private class RewardInfo
		{
			// Token: 0x040081D4 RID: 33236
			public bool bDirty;

			// Token: 0x040081D5 RID: 33237
			public int nID;

			// Token: 0x040081D6 RID: 33238
			public GuildBattleFrame.RewardInfo.EState state;

			// Token: 0x040081D7 RID: 33239
			public int nLimitScore;

			// Token: 0x040081D8 RID: 33240
			public List<ItemData> arrItems;

			// Token: 0x040081D9 RID: 33241
			public GameObject objCanGetTip;

			// Token: 0x040081DA RID: 33242
			public GameObject objCanGetEffect;

			// Token: 0x040081DB RID: 33243
			public GameObject objAlreadyGot;

			// Token: 0x040081DC RID: 33244
			public ComButtonEx comBtnExFunc;

			// Token: 0x040081DD RID: 33245
			public UIGray comGray;

			// Token: 0x040081DE RID: 33246
			public DOTweenAnimation dotween;

			// Token: 0x040081DF RID: 33247
			public Image imgBox;

			// Token: 0x040081E0 RID: 33248
			public Text labLimitScore;

			// Token: 0x020015F1 RID: 5617
			public enum EState
			{
				// Token: 0x040081E2 RID: 33250
				Got,
				// Token: 0x040081E3 RID: 33251
				CanGet,
				// Token: 0x040081E4 RID: 33252
				CanotGet
			}
		}
	}
}
