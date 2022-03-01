using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015ED RID: 5613
	internal class GuildArenaFrame : ClientFrame
	{
		// Token: 0x0600DBA7 RID: 56231 RVA: 0x00375977 File Offset: 0x00373D77
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildArenaFrame";
		}

		// Token: 0x0600DBA8 RID: 56232 RVA: 0x00375980 File Offset: 0x00373D80
		protected sealed override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.guildArenaData = (this.userData as GuildArenaData);
			this.InitComTalk();
			this._OnUpdateActivityData(null);
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && guildDungeonActivityData.nActivityState != 0U && GuildDataManager.CheckActivityLimit())
			{
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonInfoReq();
				DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonCopyReq();
			}
			DataManager<GuildDataManager>.GetInstance().SendWorldGuildDungeonStatueReq();
			InvokeMethod.InvokeInterval(this, 5f, 5f, 100000000f, null, delegate
			{
			}, null);
			this._OnShowFireworks(null);
			this._OnGuildDungeonAuctionStateUpdate(null);
			this.TryOpenGuildDungeonBossKillRankListFrame();
		}

		// Token: 0x0600DBA9 RID: 56233 RVA: 0x00375A40 File Offset: 0x00373E40
		protected IEnumerator OpenTeamMainFrame()
		{
			yield return Yielders.EndOfFrame;
			yield return Yielders.EndOfFrame;
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMainFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainFrame)).GetFrame().CustomActive(true);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMainMenuFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainMenuFrame)).GetFrame().CustomActive(true);
			}
			yield break;
		}

		// Token: 0x0600DBAA RID: 56234 RVA: 0x00375A54 File Offset: 0x00373E54
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildOpenGuildDungeonTreasureChests, new ClientEventSystem.UIEventHandler(this._OnOpenGuildDungeonTreasureChests));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GuildDungeonShowFireworks, new ClientEventSystem.UIEventHandler(this._OnShowFireworks));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnGuildDungeonAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionStateUpdate));
		}

		// Token: 0x0600DBAB RID: 56235 RVA: 0x00375AE8 File Offset: 0x00373EE8
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonUpdateActivityData, new ClientEventSystem.UIEventHandler(this._OnUpdateActivityData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildOpenGuildDungeonTreasureChests, new ClientEventSystem.UIEventHandler(this._OnOpenGuildDungeonTreasureChests));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonSyncActivityState, new ClientEventSystem.UIEventHandler(this._OnSyncActivityState));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GuildDungeonShowFireworks, new ClientEventSystem.UIEventHandler(this._OnShowFireworks));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnGuildDungeonAuctionStateUpdate, new ClientEventSystem.UIEventHandler(this._OnGuildDungeonAuctionStateUpdate));
		}

		// Token: 0x0600DBAC RID: 56236 RVA: 0x00375B7C File Offset: 0x00373F7C
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DBAD RID: 56237 RVA: 0x00375B80 File Offset: 0x00373F80
		protected override void _OnUpdate(float timeElapsed)
		{
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamMainFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMainFrame>(FrameLayer.Bottom, null, string.Empty);
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainFrame)).GetFrame().CustomActive(true);
				}
				else if (Singleton<ClientSystemManager>.GetInstance().IsFrameHidden(typeof(TeamMainFrame)))
				{
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainFrame)).GetFrame().CustomActive(true);
				}
			}
			else if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamMainMenuFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamMainMenuFrame>(FrameLayer.Bottom, null, string.Empty);
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainMenuFrame)).GetFrame().CustomActive(true);
			}
			else if (Singleton<ClientSystemManager>.GetInstance().IsFrameHidden(typeof(TeamMainMenuFrame)))
			{
				Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainMenuFrame)).GetFrame().CustomActive(true);
			}
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamMainMenuFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainMenuFrame)).GetFrame().CustomActive(guildDungeonActivityData.nActivityState != 0U);
				}
				else if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(typeof(TeamMainFrame)))
				{
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainFrame)).GetFrame().CustomActive(guildDungeonActivityData.nActivityState != 0U);
				}
			}
			if (!GuildDataManager.CheckActivityLimit())
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamMainMenuFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainMenuFrame)).GetFrame().CustomActive(false);
				}
				else if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(typeof(TeamMainFrame)))
				{
					Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(TeamMainFrame)).GetFrame().CustomActive(false);
				}
			}
			this.UpdateStateInfo();
		}

		// Token: 0x0600DBAE RID: 56238 RVA: 0x00375DAC File Offset: 0x003741AC
		protected sealed override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMission, null, null, null, null);
			InvokeMethod.RmoveInvokeIntervalCall(this);
			InvokeMethod.RemoveInvokeCall(this);
			this.UnBindUIEvent();
			if (this.m_miniTalk != null)
			{
				ComTalk.Recycle();
				this.m_miniTalk = null;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ClientSystemTownFrame>(null))
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				clientSystemTownFrame.SetForbidFadeIn(false);
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildDungeonBossKillRankListFrame>(null, false);
		}

		// Token: 0x0600DBAF RID: 56239 RVA: 0x00375E38 File Offset: 0x00374238
		private void _RegisterUIEvent()
		{
		}

		// Token: 0x0600DBB0 RID: 56240 RVA: 0x00375E3A File Offset: 0x0037423A
		private void _UnRegisterUIEvent()
		{
		}

		// Token: 0x0600DBB1 RID: 56241 RVA: 0x00375E3C File Offset: 0x0037423C
		private void _OnUpdateActivityData(UIEvent uiEvent)
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && guildDungeonActivityData.nActivityState == 0U)
			{
				this.ShowAcitivityUIs(false);
				return;
			}
			if (!GuildDataManager.CheckActivityLimit())
			{
				this.ShowAcitivityUIs(false);
				return;
			}
			this.ShowAcitivityUIs(true);
			this.UpdateKillInfo();
			this.UpdateStateInfo();
		}

		// Token: 0x0600DBB2 RID: 56242 RVA: 0x00375E94 File Offset: 0x00374294
		private void _OnSyncActivityState(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			uint num2 = (uint)uiEvent.Param2;
			if (num2 == 2U || num2 == 3U)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonBossKillRankListFrame>(FrameLayer.Bottom, null, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildDungeonBossKillRankListFrame>(null, false);
			}
			if (num == 2U || num2 == 3U)
			{
				InvokeMethod.Invoke(this, 1800f, delegate()
				{
					this.ShowAcitivityUIs(false);
				});
			}
			if (num2 == 0U)
			{
				this.ShowAcitivityUIs(false);
			}
			else
			{
				this.ShowAcitivityUIs(true);
			}
			if (!GuildDataManager.CheckActivityLimit())
			{
				this.ShowAcitivityUIs(false);
				return;
			}
		}

		// Token: 0x0600DBB3 RID: 56243 RVA: 0x00375F3C File Offset: 0x0037433C
		private void _OnOpenGuildDungeonTreasureChests(UIEvent uiEvent)
		{
			List<GuildDungeonActivityChestItem> list = uiEvent.Param1 as List<GuildDungeonActivityChestItem>;
			if (list == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowGuildDungeonChestItemsFrame>(FrameLayer.Middle, list, string.Empty);
		}

		// Token: 0x0600DBB4 RID: 56244 RVA: 0x00375F6E File Offset: 0x0037436E
		private void InitComTalk()
		{
			this.m_miniTalk = ComTalk.Create(this.mTalkParent);
		}

		// Token: 0x0600DBB5 RID: 56245 RVA: 0x00375F84 File Offset: 0x00374384
		protected override void _bindExUI()
		{
			this.mTalkParent = this.mBind.GetGameObject("TalkParent");
			this.mSkill = this.mBind.GetCom<Button>("skill");
			if (null != this.mSkill)
			{
				this.mSkill.onClick.AddListener(new UnityAction(this._onSkillButtonClick));
			}
			this.mPackge = this.mBind.GetCom<Button>("packge");
			if (null != this.mPackge)
			{
				this.mPackge.onClick.AddListener(new UnityAction(this._onPackgeButtonClick));
			}
			this.mGuild = this.mBind.GetCom<Button>("guild");
			if (null != this.mGuild)
			{
				this.mGuild.onClick.AddListener(new UnityAction(this._onGuildButtonClick));
			}
			this.mFriend = this.mBind.GetCom<Button>("friend");
			if (null != this.mFriend)
			{
				this.mFriend.onClick.AddListener(new UnityAction(this._onFriendButtonClick));
			}
			this.mBtReturnToTown = this.mBind.GetCom<Button>("btReturnToTown");
			if (null != this.mBtReturnToTown)
			{
				this.mBtReturnToTown.onClick.AddListener(new UnityAction(this._onBtReturnToTownButtonClick));
			}
			this.Rank_Award = this.mBind.GetGameObject("Rank_Award");
			this.btRank = this.mBind.GetCom<Button>("btRank");
			if (this.btRank != null)
			{
				this.btRank.onClick.RemoveAllListeners();
				this.btRank.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonDamageRankListFrame>(FrameLayer.Middle, null, string.Empty);
				});
			}
			this.btAward = this.mBind.GetCom<Button>("btAward");
			if (this.btAward != null)
			{
				this.btAward.onClick.RemoveAllListeners();
				this.btAward.onClick.AddListener(delegate()
				{
				});
			}
			this.txtKillInfo = this.mBind.GetCom<Text>("txtKillInfo");
			this.process = this.mBind.GetCom<Slider>("process");
			this.txtStateInfo = this.mBind.GetCom<Text>("txtStateInfo");
			this.btEnter = this.mBind.GetCom<Button>("btEnter");
			if (this.btEnter != null)
			{
				this.btEnter.onClick.RemoveAllListeners();
				this.btEnter.onClick.AddListener(delegate()
				{
				});
			}
			this.btOpen = this.mBind.GetCom<Button>("btOpen");
			if (this.btOpen != null)
			{
				this.btOpen.onClick.RemoveAllListeners();
				this.btOpen.onClick.AddListener(delegate()
				{
					DataManager<GuildDataManager>.GetInstance().TryGetGuildDungeonActivityChestAward();
				});
			}
			this.stateInfo = this.mBind.GetGameObject("stateInfo");
			this.bossKillInfo = this.mBind.GetGameObject("bossKillInfo");
			this.mediumBossKillInfo = this.mBind.GetGameObject("mediumBossKillInfo");
			this.btnbossKillInfo = this.mBind.GetCom<Button>("btnbossKillInfo");
			if (this.btnbossKillInfo != null)
			{
				this.btnbossKillInfo.onClick.RemoveAllListeners();
				this.btnbossKillInfo.onClick.AddListener(delegate()
				{
					this.MoveToGuildDungeonGate();
				});
			}
			this.btnMediumBossKillInfo = this.mBind.GetCom<Button>("btnMediumBossKillInfo");
			if (this.btnMediumBossKillInfo != null)
			{
				this.btnMediumBossKillInfo.onClick.RemoveAllListeners();
				this.btnMediumBossKillInfo.onClick.AddListener(delegate()
				{
					this.MoveToGuildDungeonGate();
				});
			}
			this.yanhuaRoot = this.mBind.GetGameObject("yanhuaRoot");
			this.Medium0 = this.mBind.GetCom<MediumGuildDungeonMini>("Medium0");
			this.Medium1 = this.mBind.GetCom<MediumGuildDungeonMini>("Medium1");
			this.Medium2 = this.mBind.GetCom<MediumGuildDungeonMini>("Medium2");
			this.verifyBlood = this.mBind.GetCom<Image>("verifyBlood");
			this.guildDungeonAuction = this.mBind.GetCom<Button>("guildDungeonAuction");
			this.guildDungeonAuction.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonAuctionFrame>(FrameLayer.Middle, GuildDungeonAuctionFrame.FrameType.GuildAuction, string.Empty);
			});
		}

		// Token: 0x0600DBB6 RID: 56246 RVA: 0x00376474 File Offset: 0x00374874
		protected override void _unbindExUI()
		{
			this.mTalkParent = null;
			if (null != this.mSkill)
			{
				this.mSkill.onClick.RemoveListener(new UnityAction(this._onSkillButtonClick));
			}
			this.mSkill = null;
			if (null != this.mPackge)
			{
				this.mPackge.onClick.RemoveListener(new UnityAction(this._onPackgeButtonClick));
			}
			this.mPackge = null;
			if (null != this.mGuild)
			{
				this.mGuild.onClick.RemoveListener(new UnityAction(this._onGuildButtonClick));
			}
			this.mGuild = null;
			if (null != this.mFriend)
			{
				this.mFriend.onClick.RemoveListener(new UnityAction(this._onFriendButtonClick));
			}
			this.mFriend = null;
			if (null != this.mBtReturnToTown)
			{
				this.mBtReturnToTown.onClick.RemoveListener(new UnityAction(this._onBtReturnToTownButtonClick));
			}
			this.mBtReturnToTown = null;
			this.Rank_Award = null;
			this.btRank = null;
			this.btAward = null;
			this.txtKillInfo = null;
			this.process = null;
			this.txtStateInfo = null;
			this.btEnter = null;
			this.stateInfo = null;
			this.bossKillInfo = null;
			this.btnbossKillInfo = null;
			this.yanhuaRoot = null;
			this.mediumBossKillInfo = null;
			this.btnMediumBossKillInfo = null;
			this.Medium0 = null;
			this.Medium1 = null;
			this.Medium2 = null;
			this.verifyBlood = null;
			this.guildDungeonAuction = null;
		}

		// Token: 0x0600DBB7 RID: 56247 RVA: 0x0037660A File Offset: 0x00374A0A
		private void _onBtReturnToTownButtonClick()
		{
			this.SwitchSceneToTown();
		}

		// Token: 0x0600DBB8 RID: 56248 RVA: 0x00376612 File Offset: 0x00374A12
		private void _onSkillButtonClick()
		{
			this.frameMgr.OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DBB9 RID: 56249 RVA: 0x00376627 File Offset: 0x00374A27
		private void _onPackgeButtonClick()
		{
			this.frameMgr.OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DBBA RID: 56250 RVA: 0x0037663C File Offset: 0x00374A3C
		private void _onGuildButtonClick()
		{
			this.frameMgr.OpenFrame<GuildMyMainFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600DBBB RID: 56251 RVA: 0x00376651 File Offset: 0x00374A51
		private void _onFriendButtonClick()
		{
			RelationFrameNew.CommandOpen(null);
		}

		// Token: 0x0600DBBC RID: 56252 RVA: 0x0037665C File Offset: 0x00374A5C
		private void MoveToGuildDungeonGate()
		{
			if (GuildDataManager.CheckActivityLimit() && DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus() == GuildDungeonStatus.GUILD_DUNGEON_START)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown != null && clientSystemTown.MainPlayer != null)
				{
					clientSystemTown.MainPlayer.CommandMoveToScene(6031);
					return;
				}
			}
		}

		// Token: 0x0600DBBD RID: 56253 RVA: 0x003766B8 File Offset: 0x00374AB8
		private void UpdateKillInfo()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				if (this.txtKillInfo != null)
				{
					this.txtKillInfo.text = string.Format("{0}/{1}", guildDungeonActivityData.nBossOddHp, guildDungeonActivityData.nBossMaxHp);
				}
				if (this.process != null && guildDungeonActivityData.nBossMaxHp > 0UL)
				{
					this.process.value = guildDungeonActivityData.nBossOddHp / guildDungeonActivityData.nBossMaxHp;
				}
				if (this.verifyBlood != null && guildDungeonActivityData.nBossMaxHp > 0UL)
				{
					this.verifyBlood.fillAmount = guildDungeonActivityData.nVerifyBlood / guildDungeonActivityData.nBossMaxHp;
				}
			}
			List<MediumGuildDungeonMini> list = new List<MediumGuildDungeonMini>();
			list.Add(this.Medium0);
			list.Add(this.Medium1);
			list.Add(this.Medium2);
			for (int i = 0; i < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; i++)
			{
				if (i < list.Count)
				{
					MediumGuildDungeonMini mediumGuildDungeonMini = list[i];
					if (mediumGuildDungeonMini != null)
					{
						mediumGuildDungeonMini.SetUp(guildDungeonActivityData.mediumDungeonDamgeInfos[i]);
					}
				}
			}
		}

		// Token: 0x0600DBBE RID: 56254 RVA: 0x00376800 File Offset: 0x00374C00
		private void GetLeftTime(uint nEndTime, uint nNowTime, ref int nLeftDay, ref int nLeftHour, ref int nLeftMin, ref int nLeftSec)
		{
			nLeftDay = 0;
			nLeftHour = 0;
			nLeftMin = 0;
			nLeftSec = 0;
			if (nEndTime <= nNowTime)
			{
				return;
			}
			uint num = nEndTime - nNowTime;
			uint num2 = num / 86400U;
			num -= num2 * 24U * 60U * 60U;
			uint num3 = num / 3600U;
			num -= num3 * 60U * 60U;
			uint num4 = num / 60U;
			num -= num4 * 60U;
			uint num5 = num;
			nLeftDay = (int)num2;
			nLeftHour = (int)num3;
			nLeftMin = (int)num4;
			nLeftSec = (int)num5;
		}

		// Token: 0x0600DBBF RID: 56255 RVA: 0x00376870 File Offset: 0x00374C70
		private void ShowAcitivityUIs(bool bShow)
		{
			this.Rank_Award.CustomActive(bShow);
			this.stateInfo.CustomActive(bShow);
			this.bossKillInfo.CustomActive(bShow);
			this.mediumBossKillInfo.CustomActive(bShow);
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && bShow)
			{
				bool flag = true;
				for (int i = 0; i < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; i++)
				{
					if (guildDungeonActivityData.mediumDungeonDamgeInfos[i].nOddHp > 0UL)
					{
						flag = false;
						break;
					}
				}
				this.bossKillInfo.CustomActive(flag);
				this.mediumBossKillInfo.CustomActive(!flag);
				if (guildDungeonActivityData.nActivityState == 1U)
				{
					this.bossKillInfo.CustomActive(false);
					this.mediumBossKillInfo.CustomActive(false);
					this.Rank_Award.CustomActive(false);
				}
			}
			if (bShow)
			{
			}
		}

		// Token: 0x0600DBC0 RID: 56256 RVA: 0x00376958 File Offset: 0x00374D58
		private void _OnShowFireworks(UIEvent uiEvent)
		{
			if (DataManager<GuildDataManager>.GetInstance().IsShowFireworks)
			{
				DataManager<GuildDataManager>.GetInstance().IsShowFireworks = false;
				GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
				if (guildDungeonActivityData != null && GuildDataManager.CheckActivityLimit() && guildDungeonActivityData.nActivityState != 0U)
				{
					this.yanhuaRoot.CustomActive(true);
					InvokeMethod.Invoke(this, 30f, delegate()
					{
						this.yanhuaRoot.CustomActive(false);
					});
				}
			}
			else
			{
				this.yanhuaRoot.CustomActive(false);
			}
		}

		// Token: 0x0600DBC1 RID: 56257 RVA: 0x003769DC File Offset: 0x00374DDC
		private void UpdateStateInfo()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null && this.txtStateInfo != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				int num4 = 0;
				this.GetLeftTime(guildDungeonActivityData.nActivityStateEndTime, DataManager<TimeManager>.GetInstance().GetServerTime(), ref num, ref num2, ref num3, ref num4);
				if (guildDungeonActivityData.nActivityState == 0U)
				{
					this.txtStateInfo.text = string.Format("地下城已关闭", new object[0]);
				}
				else if (guildDungeonActivityData.nActivityState == 1U)
				{
					this.txtStateInfo.text = string.Format("地下城即将开启: {0}:{1}:{2}", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
				}
				else if (guildDungeonActivityData.nActivityState == 2U)
				{
					this.txtStateInfo.text = string.Format("地下城持续时间: {0}:{1}:{2}", string.Format("{0:00}", num2), string.Format("{0:00}", num3), string.Format("{0:00}", num4));
					if (guildDungeonActivityData.nBossOddHp == 0UL)
					{
						this.txtStateInfo.text = "Boss已被击杀";
					}
				}
				else if (guildDungeonActivityData.nActivityState == 3U)
				{
					this.txtStateInfo.text = string.Format("地下城已关闭", new object[0]);
				}
			}
		}

		// Token: 0x0600DBC2 RID: 56258 RVA: 0x00376B4F File Offset: 0x00374F4F
		private void _OnGuildDungeonAuctionStateUpdate(UIEvent uiEvent)
		{
			this.guildDungeonAuction.CustomActive(DataManager<GuildDataManager>.GetInstance().IsGuildAuctionOpen);
		}

		// Token: 0x0600DBC3 RID: 56259 RVA: 0x00376B68 File Offset: 0x00374F68
		private void SwitchSceneToTown()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.guildArenaData.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.guildArenaData.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<GuildArenaFrame>(this, false);
		}

		// Token: 0x0600DBC4 RID: 56260 RVA: 0x00376BE4 File Offset: 0x00374FE4
		private void TryOpenGuildDungeonBossKillRankListFrame()
		{
			GuildDungeonStatus guildDungeonActivityStatus = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus();
			if (GuildDataManager.CheckActivityLimit() && (guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_START || guildDungeonActivityStatus == GuildDungeonStatus.GUILD_DUNGEON_REWARD))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildDungeonBossKillRankListFrame>(FrameLayer.Bottom, null, string.Empty);
			}
		}

		// Token: 0x0400816D RID: 33133
		private ComTalk m_miniTalk;

		// Token: 0x0400816E RID: 33134
		private GuildArenaData guildArenaData = new GuildArenaData();

		// Token: 0x0400816F RID: 33135
		private const int activityUICloseDelaySecond = 1800;

		// Token: 0x04008170 RID: 33136
		private const float fReqGuildActivityDataInterval = 5f;

		// Token: 0x04008171 RID: 33137
		private const float fireworksTime = 30f;

		// Token: 0x04008172 RID: 33138
		private GameObject mTalkParent;

		// Token: 0x04008173 RID: 33139
		private Button mSkill;

		// Token: 0x04008174 RID: 33140
		private Button mPackge;

		// Token: 0x04008175 RID: 33141
		private Button mGuild;

		// Token: 0x04008176 RID: 33142
		private Button mFriend;

		// Token: 0x04008177 RID: 33143
		private Button mBtReturnToTown;

		// Token: 0x04008178 RID: 33144
		private GameObject Rank_Award;

		// Token: 0x04008179 RID: 33145
		private Button btRank;

		// Token: 0x0400817A RID: 33146
		private Button btAward;

		// Token: 0x0400817B RID: 33147
		private Text txtKillInfo;

		// Token: 0x0400817C RID: 33148
		private Slider process;

		// Token: 0x0400817D RID: 33149
		private Text txtStateInfo;

		// Token: 0x0400817E RID: 33150
		private Button btEnter;

		// Token: 0x0400817F RID: 33151
		private Button btOpen;

		// Token: 0x04008180 RID: 33152
		private GameObject stateInfo;

		// Token: 0x04008181 RID: 33153
		private GameObject bossKillInfo;

		// Token: 0x04008182 RID: 33154
		private Button btnbossKillInfo;

		// Token: 0x04008183 RID: 33155
		private GameObject yanhuaRoot;

		// Token: 0x04008184 RID: 33156
		private GameObject mediumBossKillInfo;

		// Token: 0x04008185 RID: 33157
		private Button btnMediumBossKillInfo;

		// Token: 0x04008186 RID: 33158
		private Image verifyBlood;

		// Token: 0x04008187 RID: 33159
		private Button guildDungeonAuction;

		// Token: 0x04008188 RID: 33160
		private MediumGuildDungeonMini Medium0;

		// Token: 0x04008189 RID: 33161
		private MediumGuildDungeonMini Medium1;

		// Token: 0x0400818A RID: 33162
		private MediumGuildDungeonMini Medium2;
	}
}
