using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017EC RID: 6124
	public class MoneyRewardsMainFrame : ClientFrame
	{
		// Token: 0x0600F118 RID: 61720 RVA: 0x0040EAF4 File Offset: 0x0040CEF4
		public static void CommandOpen(object argv = null)
		{
			if (!(argv is MoneyRewardsMainFrameData))
			{
				MoneyRewardsMainFrameData moneyRewardsMainFrameData = new MoneyRewardsMainFrameData();
			}
			MoneyRewardsRankFrame._RequestRanklist(35, 0, 20, false, null);
			if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MoneyRewardsMainFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsMainFrame>(FrameLayer.Bottom, argv, string.Empty);
			}
		}

		// Token: 0x0600F119 RID: 61721 RVA: 0x0040EB42 File Offset: 0x0040CF42
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MoneyRewards/MoneyRewardsMainFrame";
		}

		// Token: 0x0600F11A RID: 61722 RVA: 0x0040EB49 File Offset: 0x0040CF49
		private void _OnOnMoneyRewardsStatusChanged(UIEvent uiEvent)
		{
			this._UpdateStatus();
			this._UpdateMatchButtonStatus();
			this._UpdateBtnMatchVisible();
			this._UpdateVSPanel();
			this._UpdateVSPanelStatusDesc();
			this._UpdateVSPanelTimer();
			this._UpdateVSPanelShow();
		}

		// Token: 0x0600F11B RID: 61723 RVA: 0x0040EB75 File Offset: 0x0040CF75
		private void _OnMoneyRewardsAwardsChanged(UIEvent uiEvent)
		{
			this._UpdateAwardsText();
		}

		// Token: 0x0600F11C RID: 61724 RVA: 0x0040EB7D File Offset: 0x0040CF7D
		private void _OnMoneyRewardsPlayerCountChanged(UIEvent uiEvent)
		{
			this._UpdatePlayerCount();
		}

		// Token: 0x0600F11D RID: 61725 RVA: 0x0040EB85 File Offset: 0x0040CF85
		private void _OnMoneyRewardsTrySecondMatch(UIEvent uiEvent)
		{
			SystemNotifyManager.SystemNotify(7022, new UnityAction(this._OnConfirmSecondMatch), null, new object[]
			{
				DataManager<MoneyRewardsDataManager>.GetInstance().secondMatchCost,
				DataManager<MoneyRewardsDataManager>.GetInstance().SecondMoneyName
			});
		}

		// Token: 0x0600F11E RID: 61726 RVA: 0x0040EBC3 File Offset: 0x0040CFC3
		private void _OnMoneyRewardsAwardListChanged(UIEvent uiEvent)
		{
			this._UpdateAwardsText();
		}

		// Token: 0x0600F11F RID: 61727 RVA: 0x0040EBCB File Offset: 0x0040CFCB
		private void _OnMoneyRewardsSelfResultChanged(UIEvent uiEvent)
		{
			this._UpdateRanks();
			this._UpdateScore();
			this._UpdateRate();
			this._UpdateEachVsGetAwards();
		}

		// Token: 0x0600F120 RID: 61728 RVA: 0x0040EBE8 File Offset: 0x0040CFE8
		private void _OnRedPointChanged(UIEvent uiEvent)
		{
			ERedPoint eredPoint = (ERedPoint)uiEvent.Param1;
			if (eredPoint == ERedPoint.Skill)
			{
				this.btSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
			}
			else if (eredPoint != ERedPoint.DailyProve)
			{
				this.btPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			}
		}

		// Token: 0x0600F121 RID: 61729 RVA: 0x0040EC5C File Offset: 0x0040D05C
		private void _OnMoneyRewardsAddPartyTimesChanged(UIEvent uiEvent)
		{
			this._UpdateMatchButtonStatus();
		}

		// Token: 0x0600F122 RID: 61730 RVA: 0x0040EC64 File Offset: 0x0040D064
		private void _OnMoneyRewardsResultChanged(UIEvent uiEvent)
		{
			this._UpdateVSPanel();
			this._UpdateVSPanelTimer();
		}

		// Token: 0x0600F123 RID: 61731 RVA: 0x0040EC72 File Offset: 0x0040D072
		private void _OnMoneyRewardsBattleInfoChanged(UIEvent uiEvent)
		{
			this._UpdateVSPanel();
			this._UpdateVSPanelTimer();
		}

		// Token: 0x0600F124 RID: 61732 RVA: 0x0040EC80 File Offset: 0x0040D080
		private void _OnMoneyRewardsPoolsMoneyChanged(UIEvent uiEvent)
		{
			this._UpdatePoolMoneys();
		}

		// Token: 0x0600F125 RID: 61733 RVA: 0x0040EC88 File Offset: 0x0040D088
		private void _OnConfirmSecondMatch()
		{
			if (!DataManager<MoneyRewardsDataManager>.GetInstance().IsSecondMoneyEnough)
			{
				ItemComeLink.OnLink(DataManager<MoneyRewardsDataManager>.GetInstance().SecondMoneyID, DataManager<MoneyRewardsDataManager>.GetInstance().secondMatchCost, true, null, false, false, false, null, string.Empty);
				return;
			}
			DataManager<MoneyRewardsDataManager>.GetInstance().SendAddParty(delegate
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc14"), CommonTipsDesc.eShowMode.SI_UNIQUE);
			});
		}

		// Token: 0x17001CF6 RID: 7414
		// (get) Token: 0x0600F127 RID: 61735 RVA: 0x0040ECFF File Offset: 0x0040D0FF
		// (set) Token: 0x0600F126 RID: 61734 RVA: 0x0040ECF0 File Offset: 0x0040D0F0
		private bool bIsMatch
		{
			get
			{
				return this._isMatch;
			}
			set
			{
				this._isMatch = value;
				this._UpdateBtnMatchVisible();
			}
		}

		// Token: 0x0600F128 RID: 61736 RVA: 0x0040ED08 File Offset: 0x0040D108
		private GameObject _LoadSeekCom(GameObject goParent, string path = "UIFlatten/Prefabs/Pk/Seek")
		{
			if (goParent == null || string.IsNullOrEmpty(path))
			{
				return null;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadRes(path, typeof(GameObject), true, 0U).obj as GameObject;
			Utility.AttachTo(gameObject, goParent, false);
			this.comAudio = gameObject.GetComponent<UIAudioProxy>();
			if (null != this.comAudio)
			{
				this.comAudio.StopAudio(UIAudioProxy.AudioTigger.OnCall);
			}
			this.comCounterDown = Utility.FindComponent<MatchCounterDown>(gameObject, "CountDown", true);
			this.comCounterDown.enabled = false;
			return gameObject;
		}

		// Token: 0x0600F129 RID: 61737 RVA: 0x0040EDA0 File Offset: 0x0040D1A0
		private void _InitMatchInfos()
		{
			this.goMask = Utility.FindChild(this.frame, "FrontPage");
			this.goMask.CustomActive(false);
			this.goTimer = Utility.FindChild(this.frame, "MatchInfo");
			this.goTimer.CustomActive(false);
			this.goSeek = this._LoadSeekCom(Utility.FindChild(this.frame, "MatchInfo"), "UIFlatten/Prefabs/Pk/Seek");
			this.btnMatch = Utility.FindComponent<Button>(this.frame, "BtnStartMatch", true);
			this.btnMatch.onClick.RemoveAllListeners();
			this.btnStopMatch = Utility.FindComponent<Button>(this.frame, "BtnStopMatch", true);
			this.btnStopMatch.onClick.AddListener(new UnityAction(this._OnClickStopMatch));
			this.btnStopMatch.CustomActive(false);
			this.bIsWaiting = false;
			this.bIsMatch = false;
		}

		// Token: 0x0600F12A RID: 61738 RVA: 0x0040EE88 File Offset: 0x0040D288
		private void _OnClickMatch()
		{
			if (this.bIsMatch)
			{
				return;
			}
			if (!DataManager<MoneyRewardsDataManager>.GetInstance().CanMatch)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_match_stage_error"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				SystemNotifyManager.SystemNotify(1104, string.Empty);
				return;
			}
			if (this.bIsWaiting)
			{
				return;
			}
			this.bIsWaiting = true;
			this.bIsMatch = true;
			this._BeginMatch();
			this.goTimer.CustomActive(true);
			this.comCounterDown.enabled = true;
			if (null != this.comAudio)
			{
				this.comAudio.StopAudio(UIAudioProxy.AudioTigger.OnCall);
				this.comAudio.TriggerAudio(8888);
			}
			DataManager<MoneyRewardsDataManager>.GetInstance().SendMatchParty();
		}

		// Token: 0x0600F12B RID: 61739 RVA: 0x0040EF4F File Offset: 0x0040D34F
		private void _TrySecondMatch()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMoneyRewardsTrySecondMatch, null, null, null, null);
		}

		// Token: 0x0600F12C RID: 61740 RVA: 0x0040EF64 File Offset: 0x0040D364
		private void _OnClickStopMatch()
		{
			if (!this.bIsMatch)
			{
				return;
			}
			if (this.bIsWaiting)
			{
				return;
			}
			this.bIsWaiting = true;
			this.bIsMatch = false;
			this.btnStopMatch.CustomActive(false);
			this.goMask.CustomActive(true);
			WorldMatchCancelReq cmd = new WorldMatchCancelReq();
			NetManager.Instance().SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMatchCancelRes>(delegate(WorldMatchCancelRes msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				if (msgRet.result != 0U)
				{
					SystemNotifyManager.SystemNotify((int)msgRet.result, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelFailed, null, null, null, null);
					return;
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkMatchCancelSuccess, null, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600F12D RID: 61741 RVA: 0x0040EFF1 File Offset: 0x0040D3F1
		private void _BeginMatch()
		{
			this.btnStopMatch.CustomActive(true);
			this.goMask.CustomActive(true);
		}

		// Token: 0x0600F12E RID: 61742 RVA: 0x0040F00C File Offset: 0x0040D40C
		private void _OnActiveUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			if ((ulong)num == (ulong)((long)DataManager<MoneyRewardsDataManager>.GetInstance().ActiveID) && DataManager<ActiveManager>.GetInstance().allActivities.ContainsKey((int)num))
			{
				ActivityInfo activityInfo = DataManager<ActiveManager>.GetInstance().allActivities[(int)num];
				if (activityInfo != null && activityInfo.state == 0 && this.bIsMatch)
				{
					WorldMatchCancelReq cmd = new WorldMatchCancelReq();
					NetManager.Instance().SendCommand<WorldMatchCancelReq>(ServerType.GATE_SERVER, cmd);
				}
			}
		}

		// Token: 0x0600F12F RID: 61743 RVA: 0x0040F08C File Offset: 0x0040D48C
		private void _OnMatchOk(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = true;
			this.goMask.CustomActive(true);
		}

		// Token: 0x0600F130 RID: 61744 RVA: 0x0040F0A8 File Offset: 0x0040D4A8
		private void _OnMatchStop(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = false;
			this.goMask.CustomActive(false);
			this.btnStopMatch.CustomActive(false);
			this.goTimer.CustomActive(false);
			this.comCounterDown.enabled = false;
			if (null != this.comAudio)
			{
				this.comAudio.StopAudio(UIAudioProxy.AudioTigger.OnCall);
			}
		}

		// Token: 0x0600F131 RID: 61745 RVA: 0x0040F110 File Offset: 0x0040D510
		private void _OnMatchCancelOk(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = false;
			this.goMask.CustomActive(false);
			this.btnStopMatch.CustomActive(false);
			this.goTimer.CustomActive(false);
			this.comCounterDown.enabled = false;
			if (null != this.comAudio)
			{
				this.comAudio.StopAudio(UIAudioProxy.AudioTigger.OnCall);
			}
		}

		// Token: 0x0600F132 RID: 61746 RVA: 0x0040F178 File Offset: 0x0040D578
		private void _OnMatchCancelFailed(UIEvent uiEvent)
		{
			this.bIsWaiting = false;
			this.bIsMatch = true;
			this.goMask.CustomActive(true);
			this.btnStopMatch.CustomActive(true);
		}

		// Token: 0x0600F133 RID: 61747 RVA: 0x0040F1A0 File Offset: 0x0040D5A0
		protected sealed override void _OnOpenFrame()
		{
			this.data = (this.userData as MoneyRewardsMainFrameData);
			this.awards[0] = this.award_0;
			this.awards[1] = this.award_1;
			this.awards[2] = this.award_2;
			this.awards[3] = this.award_3;
			this.awards[4] = this.award_4;
			if (Singleton<ReplayServer>.GetInstance().IsLastPlaying())
			{
				Singleton<ReplayServer>.GetInstance().SetLastPlaying(false);
				MoneyRewardsResultFrame.CommandOpen(null);
			}
			this._UpdateAwardsText();
			this._UpdateRanks();
			this._UpdateScore();
			this._UpdateRate();
			this._UpdatePlayerCount();
			this._UpdateStatus();
			this._UpdateVSPanel();
			this._UpdateVSPanelStatusDesc();
			base._AddButton("ScorePanel/WatchRank", new UnityAction(this._OnWatchRank));
			base._AddButton("ScorePanel/WatchRecords", new UnityAction(this._OnWatchRecords));
			base._AddButton("BtnWatchResult", delegate
			{
				MoneyRewardsResultFrame.CommandOpen(null);
			});
			base._AddButton("btMenu", delegate
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkMenuFrame>(FrameLayer.Middle, null, string.Empty);
			});
			this._InitMatchInfos();
			this.InitRedPoint();
			this._UpdateMatchButtonStatus();
			this._UpdateBtnMatchVisible();
			this._UpdateVSPanelTimer();
			this._UpdateVSPanelShow();
			this._UpdateEachVSMaxAwards();
			this._UpdateEachVsGetAwards();
			this._UpdateFixedVSAwards();
			this._UpdatePoolMoneys();
			this.comTalk = ComTalk.Create(Utility.FindChild(this.frame, "TalkParent"));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActiveUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchOk));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchFailed, new ClientEventSystem.UIEventHandler(this._OnMatchStop));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchCancelOk));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PkMatchCancelFailed, new ClientEventSystem.UIEventHandler(this._OnMatchCancelFailed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAwardsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardsChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsPlayerCountChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPlayerCountChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsTrySecondMatch, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsTrySecondMatch));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardListChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsAddPartyTimesChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAddPartyTimesChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsResultChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsBattleInfoChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsBattleInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMoneyRewardsPoolsMoneyChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPoolsMoneyChanged));
			InvokeMethod.Invoke(this, 1f, new UnityAction(this._UpdateRequestMySelfRank));
		}

		// Token: 0x0600F134 RID: 61748 RVA: 0x0040F4ED File Offset: 0x0040D8ED
		private void _UpdateRequestMySelfRank()
		{
			MoneyRewardsRankFrame._RequestRanklist(35, 0, 1, false, new UnityAction(this._TryNextInvoke));
		}

		// Token: 0x0600F135 RID: 61749 RVA: 0x0040F505 File Offset: 0x0040D905
		private void _TryNextInvoke()
		{
			if (null != this.frame)
			{
				InvokeMethod.Invoke(this, 1f, new UnityAction(this._UpdateRequestMySelfRank));
			}
		}

		// Token: 0x0600F136 RID: 61750 RVA: 0x0040F52F File Offset: 0x0040D92F
		private void _OnWatchRank()
		{
			MoneyRewardsRankFrame.CommandOpen(null);
		}

		// Token: 0x0600F137 RID: 61751 RVA: 0x0040F537 File Offset: 0x0040D937
		private void _OnWatchRecords()
		{
			MoneyRewardsRecordFrame.CommandOpen(null);
		}

		// Token: 0x0600F138 RID: 61752 RVA: 0x0040F540 File Offset: 0x0040D940
		protected sealed override void _OnCloseFrame()
		{
			this.data = null;
			Array.Clear(this.awards, 0, this.awards.Length);
			this._isMatch = false;
			if (this.btnMatch != null)
			{
				this.btnMatch.onClick.RemoveAllListeners();
				this.btnMatch = null;
			}
			if (this.btnStopMatch != null)
			{
				this.btnStopMatch.onClick.RemoveAllListeners();
				this.btnStopMatch = null;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchStartSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchOk));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchFailed, new ClientEventSystem.UIEventHandler(this._OnMatchStop));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelSuccess, new ClientEventSystem.UIEventHandler(this._OnMatchCancelOk));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PkMatchCancelFailed, new ClientEventSystem.UIEventHandler(this._OnMatchCancelFailed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityUpdate, new ClientEventSystem.UIEventHandler(this._OnActiveUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsStatusChanged, new ClientEventSystem.UIEventHandler(this._OnOnMoneyRewardsStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAwardsChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardsChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsPlayerCountChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPlayerCountChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsTrySecondMatch, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsTrySecondMatch));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAwardListChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAwardListChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsSelfResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsSelfResultChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RedPointChanged, new ClientEventSystem.UIEventHandler(this._OnRedPointChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsAddPartyTimesChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsAddPartyTimesChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsResultChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsResultChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsBattleInfoChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsBattleInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMoneyRewardsPoolsMoneyChanged, new ClientEventSystem.UIEventHandler(this._OnMoneyRewardsPoolsMoneyChanged));
			if (this.comTalk != null)
			{
				ComTalk.Recycle();
				this.comTalk = null;
			}
			InvokeMethod.RemoveInvokeCall(this);
			InvokeMethod.RmoveInvokeIntervalCall(this.mVsPanelObjLock);
			InvokeMethod.RemoveInvokeCall(this.mVsPanelObjLock);
		}

		// Token: 0x0600F139 RID: 61753 RVA: 0x0040F7A8 File Offset: 0x0040DBA8
		private void _UpdateAwardsText()
		{
			for (int i = 0; i < this.awards.Length; i++)
			{
				if (null != this.awards[i])
				{
					if (i < DataManager<MoneyRewardsDataManager>.GetInstance().awardsList.Count)
					{
						this.awards[i].text = DataManager<MoneyRewardsDataManager>.GetInstance().awardsList[i].ToString();
					}
					else
					{
						this.awards[i].text = 0.ToString();
					}
				}
			}
		}

		// Token: 0x0600F13A RID: 61754 RVA: 0x0040F842 File Offset: 0x0040DC42
		private void _UpdateRanks()
		{
			if (null != this.MyRank)
			{
				this.MyRank.text = TR.Value("money_rewards_my_rank", DataManager<MoneyRewardsDataManager>.GetInstance().Rank);
			}
		}

		// Token: 0x0600F13B RID: 61755 RVA: 0x0040F87C File Offset: 0x0040DC7C
		private void _UpdateScore()
		{
			if (null != this.MyScore)
			{
				this.MyScore.text = TR.Value("money_rewards_my_current_score", DataManager<MoneyRewardsDataManager>.GetInstance().Score);
			}
			if (null != this.MaxScore)
			{
				this.MaxScore.text = TR.Value("money_rewards_my_max_score", DataManager<MoneyRewardsDataManager>.GetInstance().MaxScore);
			}
		}

		// Token: 0x0600F13C RID: 61756 RVA: 0x0040F8F4 File Offset: 0x0040DCF4
		private void _UpdateRate()
		{
			if (null != this.MyRate)
			{
				this.MyRate.text = TR.Value("money_rewards_my_rate", DataManager<MoneyRewardsDataManager>.GetInstance().WinTimes, DataManager<MoneyRewardsDataManager>.GetInstance().LoseTime);
			}
		}

		// Token: 0x0600F13D RID: 61757 RVA: 0x0040F945 File Offset: 0x0040DD45
		private void _UpdatePlayerCount()
		{
			if (null != this.playerCount)
			{
				this.playerCount.text = TR.Value("money_rewards_player_counts", DataManager<MoneyRewardsDataManager>.GetInstance().playerCount);
			}
		}

		// Token: 0x0600F13E RID: 61758 RVA: 0x0040F97C File Offset: 0x0040DD7C
		private void _UpdateStatus()
		{
			if (null != this.timer)
			{
				this.timer.Time = 0U;
				this.timer.Initialize();
			}
			if (null != this.comStatus)
			{
				MoneyRewardsStatus eMoneyRewardsStatus = DataManager<MoneyRewardsDataManager>.GetInstance().eMoneyRewardsStatus;
				switch (eMoneyRewardsStatus + 1)
				{
				case MoneyRewardsStatus.MRS_READY:
					this.comStatus.Key = "finish";
					break;
				case MoneyRewardsStatus.MRS_8_RACE:
					this.comStatus.Key = "ready";
					break;
				case MoneyRewardsStatus.MRS_PRE_4_RACE:
					this.comStatus.Key = "8level";
					break;
				case MoneyRewardsStatus.MRS_4_RACE:
					this.comStatus.Key = "4pre_level";
					break;
				case MoneyRewardsStatus.MRS_2_RACE:
					this.comStatus.Key = "4level";
					break;
				case MoneyRewardsStatus.MRS_RACE:
					this.comStatus.Key = "2level";
					break;
				case MoneyRewardsStatus.MRS_END:
					this.comStatus.Key = "1level";
					break;
				case (MoneyRewardsStatus)7:
					this.comStatus.Key = "finish";
					break;
				}
			}
			uint time = (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime < DataManager<TimeManager>.GetInstance().GetServerTime()) ? 0U : (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			this.timer.Time = time;
			this.goWatch.CustomActive(DataManager<MoneyRewardsDataManager>.GetInstance().Status > PremiumLeagueStatus.PLS_PRELIMINAY);
		}

		// Token: 0x0600F13F RID: 61759 RVA: 0x0040FAFC File Offset: 0x0040DEFC
		private void _UpdateVSPanelTimer()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				ComMoneyRewardsResultData localResultData = DataManager<MoneyRewardsDataManager>.GetInstance().GetLocalResultData();
				if (localResultData == null)
				{
					InvokeMethod.RmoveInvokeIntervalCall(this.mVsPanelObjLock);
					InvokeMethod.RemoveInvokeCall(this.mVsPanelObjLock);
					this.comMoneyRewardsDataBinder.CloseCounter();
				}
				else
				{
					int indexByRoleId = DataManager<MoneyRewardsDataManager>.GetInstance().getIndexByRoleId(localResultData.recordId);
					bool flag = false;
					ComMoneyRewardsResultData nextVsData = DataManager<MoneyRewardsDataManager>.GetInstance().GetNextVsData(indexByRoleId, DataManager<MoneyRewardsDataManager>.GetInstance().Status, ref flag);
					if (!flag)
					{
						InvokeMethod.RmoveInvokeIntervalCall(this.mVsPanelObjLock);
						InvokeMethod.RemoveInvokeCall(this.mVsPanelObjLock);
						this.comMoneyRewardsDataBinder.CloseCounter();
					}
					else
					{
						InvokeMethod.RmoveInvokeIntervalCall(this.mVsPanelObjLock);
						InvokeMethod.RemoveInvokeCall(this.mVsPanelObjLock);
						this._UpdateVSPanelTimerCallback();
						InvokeMethod.InvokeInterval(this.mVsPanelObjLock, 0f, 1f, 9999999f, null, new UnityAction(this._UpdateVSPanelTimerCallback), null);
					}
				}
			}
		}

		// Token: 0x0600F140 RID: 61760 RVA: 0x0040FBEC File Offset: 0x0040DFEC
		private void _UpdateVSPanelShow()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				if (DataManager<MoneyRewardsDataManager>.GetInstance().Status <= PremiumLeagueStatus.PLS_PRELIMINAY)
				{
					this.comMoneyRewardsDataBinder.SelectVSPanel(false);
				}
				else
				{
					this.comMoneyRewardsDataBinder.SelectVSPanel(true);
				}
			}
		}

		// Token: 0x0600F141 RID: 61761 RVA: 0x0040FC2C File Offset: 0x0040E02C
		private void _UpdateEachVSMaxAwards()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.SetVSAwardsDesc();
			}
		}

		// Token: 0x0600F142 RID: 61762 RVA: 0x0040FC4A File Offset: 0x0040E04A
		private void _UpdateFixedVSAwards()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.SetVSEachFixedGetDesc();
			}
		}

		// Token: 0x0600F143 RID: 61763 RVA: 0x0040FC68 File Offset: 0x0040E068
		private void _UpdateEachVsGetAwards()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.SetVSGetAwardsDesc();
			}
		}

		// Token: 0x0600F144 RID: 61764 RVA: 0x0040FC86 File Offset: 0x0040E086
		private void _UpdatePoolMoneys()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.SetPoolAwards();
			}
		}

		// Token: 0x0600F145 RID: 61765 RVA: 0x0040FCA4 File Offset: 0x0040E0A4
		private void _OnHideVSPanelTimer()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.CloseCounter();
			}
		}

		// Token: 0x0600F146 RID: 61766 RVA: 0x0040FCC4 File Offset: 0x0040E0C4
		private void _UpdateVSPanelTimerCallback()
		{
			uint num = (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime < DataManager<TimeManager>.GetInstance().GetServerTime()) ? 0U : (DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			if (num <= this.comMoneyRewardsDataBinder.triggerTime)
			{
				InvokeMethod.RmoveInvokeIntervalCall(this.mVsPanelObjLock);
				InvokeMethod.RemoveInvokeCall(this.mVsPanelObjLock);
				this.comMoneyRewardsDataBinder.StartCounter(num);
				InvokeMethod.Invoke(this.mVsPanelObjLock, num, new UnityAction(this._OnHideVSPanelTimer));
			}
		}

		// Token: 0x0600F147 RID: 61767 RVA: 0x0040FD54 File Offset: 0x0040E154
		private void _UpdateVSPanel()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				switch (DataManager<MoneyRewardsDataManager>.GetInstance().Status)
				{
				case PremiumLeagueStatus.PLS_INIT:
				case PremiumLeagueStatus.PLS_ENROLL:
				case PremiumLeagueStatus.PLS_PRELIMINAY:
					this.comMoneyRewardsDataBinder.SetVSEnable(false);
					this.comMoneyRewardsDataBinder.RemoveWatchListener();
					this.comMoneyRewardsDataBinder.SetWatchPlayerInfo(null);
					break;
				case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
				case PremiumLeagueStatus.PLS_FINAL_EIGHT:
				case PremiumLeagueStatus.PLS_FINAL_FOUR:
				case PremiumLeagueStatus.PLS_FINAL:
				{
					ComMoneyRewardsResultData localResultData = DataManager<MoneyRewardsDataManager>.GetInstance().GetLocalResultData();
					if (localResultData == null)
					{
						this.comMoneyRewardsDataBinder.SetVSEnable(false);
						this.comMoneyRewardsDataBinder.RemoveWatchListener();
						this.comMoneyRewardsDataBinder.SetWatchPlayerInfo(null);
					}
					else
					{
						int indexByRoleId = DataManager<MoneyRewardsDataManager>.GetInstance().getIndexByRoleId(localResultData.recordId);
						bool flag = false;
						ComMoneyRewardsResultData nextVsData = DataManager<MoneyRewardsDataManager>.GetInstance().GetNextVsData(indexByRoleId, DataManager<MoneyRewardsDataManager>.GetInstance().Status, ref flag);
						this.comMoneyRewardsDataBinder.SetVSEnable(flag);
						this.comMoneyRewardsDataBinder.RemoveWatchListener();
						this.comMoneyRewardsDataBinder.SetWatchPlayerInfo(nextVsData);
						if (flag)
						{
							this.comMoneyRewardsDataBinder.SetPlayerEnable(0, null != localResultData);
							this.comMoneyRewardsDataBinder.SetPlayerEnable(1, null != nextVsData);
							this.comMoneyRewardsDataBinder.SetPlayerData(0, localResultData);
							this.comMoneyRewardsDataBinder.SetPlayerData(1, nextVsData);
							if (nextVsData != null)
							{
								this.comMoneyRewardsDataBinder.AddWatchListener();
							}
						}
					}
					break;
				}
				case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
					this.comMoneyRewardsDataBinder.SetVSEnable(false);
					this.comMoneyRewardsDataBinder.RemoveWatchListener();
					this.comMoneyRewardsDataBinder.SetWatchPlayerInfo(null);
					break;
				}
			}
		}

		// Token: 0x0600F148 RID: 61768 RVA: 0x0040FEE0 File Offset: 0x0040E2E0
		private void _UpdateVSPanelStatusDesc()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.UpdateStatus();
			}
		}

		// Token: 0x0600F149 RID: 61769 RVA: 0x0040FF00 File Offset: 0x0040E300
		private void _UpdateMatchButtonStatus()
		{
			this.btnMatch.onClick.RemoveAllListeners();
			if (null != this.comMatchState)
			{
				switch (DataManager<MoneyRewardsDataManager>.GetInstance().Status)
				{
				case PremiumLeagueStatus.PLS_INIT:
					this.comMatchState.Key = this.mUnStart;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc4"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_ENROLL:
					this.comMatchState.Key = this.mUnStart;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc2"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_PRELIMINAY:
					if (DataManager<MoneyRewardsDataManager>.GetInstance().addPartyTimes <= 0)
					{
						this.comMatchState.Key = this.mNoRank;
						this.btnMatch.onClick.AddListener(delegate()
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc11"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						});
					}
					else if (DataManager<MoneyRewardsDataManager>.GetInstance().addPartyTimes == 1)
					{
						if (DataManager<MoneyRewardsDataManager>.GetInstance().LoseTime <= 0)
						{
							this.comMatchState.Key = this.mNormal;
							this.btnMatch.onClick.AddListener(new UnityAction(this._OnClickMatch));
						}
						else
						{
							this.comMatchState.Key = this.mOnceOver;
							this.btnMatch.onClick.AddListener(new UnityAction(this._TrySecondMatch));
						}
					}
					else if (DataManager<MoneyRewardsDataManager>.GetInstance().addPartyTimes == 2)
					{
						if (DataManager<MoneyRewardsDataManager>.GetInstance().LoseTime <= 0)
						{
							this.comMatchState.Key = this.mNormal;
							this.btnMatch.onClick.AddListener(new UnityAction(this._OnClickMatch));
						}
						else
						{
							this.comMatchState.Key = this.mTwoOver;
							this.btnMatch.onClick.AddListener(delegate()
							{
								SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc12"), CommonTipsDesc.eShowMode.SI_UNIQUE);
							});
						}
					}
					else
					{
						this.comMatchState.Key = this.mTwoOver;
						this.btnMatch.onClick.AddListener(delegate()
						{
							SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc12"), CommonTipsDesc.eShowMode.SI_UNIQUE);
						});
					}
					break;
				case PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE:
					this.comMatchState.Key = this.mClosed;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc6"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_FINAL_EIGHT:
					this.comMatchState.Key = this.mClosed;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc7"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_FINAL_FOUR:
					this.comMatchState.Key = this.mClosed;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc8"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_FINAL:
					this.comMatchState.Key = this.mClosed;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc9"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				case PremiumLeagueStatus.PLS_FINAL_WAIT_CLEAR:
					this.comMatchState.Key = this.mClosed;
					this.btnMatch.onClick.AddListener(delegate()
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("money_rewards_fixed_desc10"), CommonTipsDesc.eShowMode.SI_UNIQUE);
					});
					break;
				}
			}
		}

		// Token: 0x0600F14A RID: 61770 RVA: 0x004102E8 File Offset: 0x0040E6E8
		[UIEventHandle("btReturnToTown")]
		private void OnClickReturnToTown()
		{
			if (this.bIsMatch)
			{
				SystemNotifyManager.SystemNotify(4004, string.Empty);
				return;
			}
			if (DataManager<MoneyRewardsDataManager>.GetInstance().Status == PremiumLeagueStatus.PLS_PRELIMINAY)
			{
				string text = Utility.ToUtcTime2Local((long)((ulong)DataManager<MoneyRewardsDataManager>.GetInstance().StatusEndTime)).ToString("HH:mm", Utility.cultureInfo);
				if (DataManager<MoneyRewardsDataManager>.GetInstance().Rank <= 8)
				{
					SystemNotifyManager.SystemNotify(7028, new UnityAction(this._ConfirmToReturn), null, new object[]
					{
						DataManager<MoneyRewardsDataManager>.GetInstance().Rank,
						text
					});
					return;
				}
			}
			int indexByRoleId = DataManager<MoneyRewardsDataManager>.GetInstance().getIndexByRoleId(DataManager<PlayerBaseData>.GetInstance().RoleID);
			bool flag = false;
			DataManager<MoneyRewardsDataManager>.GetInstance().GetNextVsData(indexByRoleId, DataManager<MoneyRewardsDataManager>.GetInstance().Status, ref flag);
			if (flag)
			{
				this._DoUnLeaveHint();
				return;
			}
			this._ConfirmToReturn();
		}

		// Token: 0x0600F14B RID: 61771 RVA: 0x004103CC File Offset: 0x0040E7CC
		private void _UpdateBtnMatchVisible()
		{
			bool bActive = DataManager<MoneyRewardsDataManager>.GetInstance().Status < PremiumLeagueStatus.PLS_FINAL_EIGHT_PREPARE && !this._isMatch;
			this.btnMatch.CustomActive(bActive);
		}

		// Token: 0x0600F14C RID: 61772 RVA: 0x00410402 File Offset: 0x0040E802
		private void _DoUnLeaveHint()
		{
			if (null != this.comMoneyRewardsDataBinder)
			{
				this.comMoneyRewardsDataBinder.DoUnLeaveHint();
			}
		}

		// Token: 0x0600F14D RID: 61773 RVA: 0x00410420 File Offset: 0x0040E820
		private void _ConfirmToReturn()
		{
			if (this.data == null)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem() as ClientSystemTown;
			if (clientSystemTown == null)
			{
				Logger.LogError("Current System is not Town!!!");
				return;
			}
			if (Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty) == null)
			{
				return;
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(clientSystemTown._NetSyncChangeScene(new SceneParams
			{
				currSceneID = this.data.CurrentSceneID,
				currDoorID = 0,
				targetSceneID = this.data.TargetTownSceneID,
				targetDoorID = 0
			}, true));
			this.frameMgr.CloseFrame<MoneyRewardsMainFrame>(this, false);
		}

		// Token: 0x0600F14E RID: 61774 RVA: 0x004104D2 File Offset: 0x0040E8D2
		[UIEventHandle("btPackage")]
		private void OnPackage()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PackageNewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600F14F RID: 61775 RVA: 0x004104E6 File Offset: 0x0040E8E6
		[UIEventHandle("btSkill")]
		private void OnSkill()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<SkillTreeFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600F150 RID: 61776 RVA: 0x004104FA File Offset: 0x0040E8FA
		private void InitRedPoint()
		{
			this.btPackageRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.PackageMain));
			this.btSkillRedPoint.gameObject.SetActive(DataManager<RedPointDataManager>.GetInstance().HasRedPoint(ERedPoint.Skill));
		}

		// Token: 0x04009420 RID: 37920
		[UIControl("AwardsPanel/c0", typeof(Text), 0)]
		private Text award_0;

		// Token: 0x04009421 RID: 37921
		[UIControl("AwardsPanel/c1", typeof(Text), 0)]
		private Text award_1;

		// Token: 0x04009422 RID: 37922
		[UIControl("AwardsPanel/c2", typeof(Text), 0)]
		private Text award_2;

		// Token: 0x04009423 RID: 37923
		[UIControl("AwardsPanel/c3", typeof(Text), 0)]
		private Text award_3;

		// Token: 0x04009424 RID: 37924
		[UIControl("AwardsPanel/c4", typeof(Text), 0)]
		private Text award_4;

		// Token: 0x04009425 RID: 37925
		private Text[] awards = new Text[5];

		// Token: 0x04009426 RID: 37926
		[UIControl("PlayerCount", typeof(Text), 0)]
		private Text playerCount;

		// Token: 0x04009427 RID: 37927
		[UIControl("ScorePanel/MyRate/MyRate", typeof(Text), 0)]
		private Text MyRate;

		// Token: 0x04009428 RID: 37928
		[UIControl("ScorePanel/MyScore/MyScore", typeof(Text), 0)]
		private Text MyScore;

		// Token: 0x04009429 RID: 37929
		[UIControl("ScorePanel/MaxScore/MaxScore ", typeof(Text), 0)]
		private Text MaxScore;

		// Token: 0x0400942A RID: 37930
		[UIControl("ScorePanel/MyRank/MyRank", typeof(Text), 0)]
		private Text MyRank;

		// Token: 0x0400942B RID: 37931
		[UIControl("Status", typeof(StateController), 0)]
		private StateController comStatus;

		// Token: 0x0400942C RID: 37932
		[UIControl("Status/Layout", typeof(TimeRefresh), 0)]
		private TimeRefresh timer;

		// Token: 0x0400942D RID: 37933
		[UIObject("BtnWatchResult")]
		private GameObject goWatch;

		// Token: 0x0400942E RID: 37934
		[UIControl("BtnStartMatch", typeof(StateController), 0)]
		private StateController comMatchState;

		// Token: 0x0400942F RID: 37935
		[UIControl("", typeof(ComMoneyRewardsDataBinder), 0)]
		private ComMoneyRewardsDataBinder comMoneyRewardsDataBinder;

		// Token: 0x04009430 RID: 37936
		private string mUnStart = "unstart";

		// Token: 0x04009431 RID: 37937
		private string mNormal = "normal";

		// Token: 0x04009432 RID: 37938
		private string mClosed = "closed";

		// Token: 0x04009433 RID: 37939
		private string mNoRank = "no_rank";

		// Token: 0x04009434 RID: 37940
		private string mOnceOver = "once_over";

		// Token: 0x04009435 RID: 37941
		private string mTwoOver = "two_over";

		// Token: 0x04009436 RID: 37942
		private GameObject goMask;

		// Token: 0x04009437 RID: 37943
		private GameObject goTimer;

		// Token: 0x04009438 RID: 37944
		private bool bIsWaiting;

		// Token: 0x04009439 RID: 37945
		private bool _isMatch;

		// Token: 0x0400943A RID: 37946
		private Button btnMatch;

		// Token: 0x0400943B RID: 37947
		private Button btnStopMatch;

		// Token: 0x0400943C RID: 37948
		private MatchCounterDown comCounterDown;

		// Token: 0x0400943D RID: 37949
		private GameObject goSeek;

		// Token: 0x0400943E RID: 37950
		private UIAudioProxy comAudio;

		// Token: 0x0400943F RID: 37951
		private ComTalk comTalk;

		// Token: 0x04009440 RID: 37952
		private MoneyRewardsMainFrameData data;

		// Token: 0x04009441 RID: 37953
		private object mVsPanelObjLock = new object();

		// Token: 0x04009442 RID: 37954
		[UIControl("btPackage/RedPoint", null, 0)]
		private Image btPackageRedPoint;

		// Token: 0x04009443 RID: 37955
		[UIControl("btSkill/RedPoint", null, 0)]
		private Image btSkillRedPoint;
	}
}
