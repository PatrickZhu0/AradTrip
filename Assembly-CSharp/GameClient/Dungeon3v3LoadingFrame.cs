using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using UnityEngine;
using UnityEngine.UI;
using VoiceSDK;

namespace GameClient
{
	// Token: 0x0200109F RID: 4255
	internal class Dungeon3v3LoadingFrame : Dungeon3V3BaseLoadFrame
	{
		// Token: 0x0600A05F RID: 41055 RVA: 0x00204480 File Offset: 0x00202880
		protected override void _onApplyBtnButtonClickEvent()
		{
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer == null)
			{
				return;
			}
			if (Singleton<ReplayServer>.instance.IsReplay())
			{
				this.mJoinFightRoot.CustomActive(false);
				this.mCancelFightRoot.CustomActive(false);
				this.mLeftTimeRoot.CustomActive(false);
			}
			else
			{
				MatchRoundVote matchRoundVote = new MatchRoundVote
				{
					isVote = !mainPlayer.isVote
				};
				FrameSync.instance.FireFrameCommand(matchRoundVote, false);
				this.mJoinFightRoot.CustomActive(!matchRoundVote.isVote);
				this.mCancelFightRoot.CustomActive(matchRoundVote.isVote);
				this.mLeftTimeRoot.CustomActive(!matchRoundVote.isVote);
			}
		}

		// Token: 0x0600A060 RID: 41056 RVA: 0x00204538 File Offset: 0x00202938
		protected override bool _IsLoadingFrame()
		{
			return true;
		}

		// Token: 0x0600A061 RID: 41057 RVA: 0x0020453C File Offset: 0x0020293C
		public override IEnumerator LoadingOpenPost()
		{
			float maxTime = 0f;
			if (this.mAllTypeAnimation != null)
			{
				for (int i = 0; i < this.mAllTypeAnimation.Count; i++)
				{
					if (this.mAllTypeAnimation[i] != null && this.mAllTypeAnimation[i].Count > 0)
					{
						maxTime = Mathf.Max(maxTime, this.mAllTypeAnimation[i][0].duration + this.mAllTypeAnimation[i][0].delay);
					}
				}
			}
			yield return Yielders.GetWaitForSeconds(maxTime);
			yield break;
		}

		// Token: 0x0600A062 RID: 41058 RVA: 0x00204558 File Offset: 0x00202958
		protected override void _OnOpenFrame()
		{
			this._UpdateSpeed = Global.Settings.loadingProgressStep;
			this.mApplyLimitButton.ResetCount();
			Object.DontDestroyOnLoad(this.frame);
			this._targetProgress = 0;
			this._currentProgress = -1;
			base.StartCoroutine(this.UpdateProgress());
			base._initBoards();
			base._initPlayers();
			this._updateAllPlayersStatus();
			this.mLoadingStatus = Dungeon3v3LoadingFrame.eLoadingStatus.Loading;
			this._updateWithLoadingStatus();
			for (int i = 0; i < 6; i++)
			{
				base._playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType.eIn, (byte)i);
			}
			this.InitVoiceDeviceBtnsState(false);
			this._bindEvent();
			if (DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_3V3_Melee)
			{
				this.SetFightTitle();
			}
		}

		// Token: 0x0600A063 RID: 41059 RVA: 0x00204604 File Offset: 0x00202A04
		private void SetFightTitle()
		{
			Image component = this.mPerpareRoot.GetComponent<Image>();
			ETCImageLoader.LoadSprite(ref component, "UI/Image/Packed/p_UI_3V3PK.png:UI_3v3_Beizhan_Wenzi_Duizhan", true);
		}

		// Token: 0x0600A064 RID: 41060 RVA: 0x0020462B File Offset: 0x00202A2B
		private new bool _checkBattlePlayerIsValid(BattlePlayer player)
		{
			return BattlePlayer.IsDataValidBattlePlayer(player) && null != base._findBoardBySeat(player.playerInfo.seat);
		}

		// Token: 0x0600A065 RID: 41061 RVA: 0x00204654 File Offset: 0x00202A54
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3StartVoteForFight, new ClientEventSystem.UIEventHandler(this._onPK3V3StartVoteForFight));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK3V3FinishVoteForFight, new ClientEventSystem.UIEventHandler(this._onPK3V3FinishVoteForFight));
			Singleton<SDKVoiceManager>.GetInstance().AddRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0600A066 RID: 41062 RVA: 0x002046EC File Offset: 0x00202AEC
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3VoteForFightStatusChanged, new ClientEventSystem.UIEventHandler(this._onPK3V3VoteForFightStatusChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3StartVoteForFight, new ClientEventSystem.UIEventHandler(this._onPK3V3StartVoteForFight));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK3V3FinishVoteForFight, new ClientEventSystem.UIEventHandler(this._onPK3V3FinishVoteForFight));
			Singleton<SDKVoiceManager>.GetInstance().RemoveRealVoiceHandler(new SDKVoiceInterface.OnJoinChannelSuccess(this.OnJoinChannelSucc), new SDKVoiceInterface.OnVoiceMicOn(this.OnVoiceSDKMicOn), new SDKVoiceInterface.OnVoicePlayerOn(this.OnVoiceSDKPlayerOn), null, null, null, null, null, null, null, null, null, null);
		}

		// Token: 0x0600A067 RID: 41063 RVA: 0x00204782 File Offset: 0x00202B82
		private void _onPK3V3FinishVoteForFight(UIEvent ui)
		{
			this.mLoadingStatus = Dungeon3v3LoadingFrame.eLoadingStatus.VsAnimate;
			this._updateWithLoadingStatus();
		}

		// Token: 0x0600A068 RID: 41064 RVA: 0x00204791 File Offset: 0x00202B91
		private void _onPK3V3StartVoteForFight(UIEvent ui)
		{
			this.mLoadingStatus = Dungeon3v3LoadingFrame.eLoadingStatus.Vote;
			this._updateWithLoadingStatus();
		}

		// Token: 0x0600A069 RID: 41065 RVA: 0x002047A0 File Offset: 0x00202BA0
		private void _updateWithLoadingStatus()
		{
			this.mApplyBtn.gameObject.CustomActive(false);
			this.mFightVS.gameObject.CustomActive(false);
			this.mCountDownRoot.CustomActive(false);
			this.mLeftTimeRoot.CustomActive(false);
			this.mFightTips.CustomActive(false);
			this.mNextRoundRoot.CustomActive(false);
			this._setUnitLoadingBarVisible(false);
			Dungeon3v3LoadingFrame.eLoadingStatus eLoadingStatus = this.mLoadingStatus;
			if (eLoadingStatus != Dungeon3v3LoadingFrame.eLoadingStatus.Loading)
			{
				if (eLoadingStatus != Dungeon3v3LoadingFrame.eLoadingStatus.Vote)
				{
					if (eLoadingStatus == Dungeon3v3LoadingFrame.eLoadingStatus.VsAnimate)
					{
						if (DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_3V3_Melee)
						{
							GameObject gameObject = this.mBind.GetGameObject("3v3Tips2");
							if (gameObject != null)
							{
								gameObject.gameObject.CustomActive(true);
							}
							GameObject gameObject2 = this.mBind.GetGameObject("VS2");
							if (gameObject2 != null)
							{
								gameObject2.gameObject.CustomActive(true);
							}
						}
						else
						{
							DOTween.Play(this.mPerpareRoot);
							this.mFightVS.gameObject.CustomActive(true);
							this.mNextRoundRoot.CustomActive(true);
							this._doVSAnimate();
							BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
							if (BattlePlayer.IsDataValidBattlePlayer(mainPlayer) && mainPlayer.isFighting)
							{
								this.mFightTips.CustomActive(true);
							}
						}
					}
				}
				else
				{
					this.mCountDownRoot.CustomActive(true);
					if (!Singleton<ReplayServer>.instance.IsReplay())
					{
						this.mApplyBtn.gameObject.CustomActive(true);
					}
				}
			}
			else
			{
				this._setUnitLoadingBarVisible(true);
			}
		}

		// Token: 0x0600A06A RID: 41066 RVA: 0x00204930 File Offset: 0x00202D30
		private void _setUnitLoadingBarVisible(bool isVisible)
		{
			for (int i = 0; i < this.mBoards.Length; i++)
			{
				ComCommonBind unit = this.mBoards[i].unit;
				if (!(null == unit))
				{
					GameObject gameObject = unit.GetGameObject("progressRoot");
					if (!(null == gameObject))
					{
						gameObject.CustomActive(isVisible);
					}
				}
			}
		}

		// Token: 0x0600A06B RID: 41067 RVA: 0x00204999 File Offset: 0x00202D99
		private void _doVSAnimate()
		{
			this._doTeamVSAnimate(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			this._doTeamVSAnimate(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
		}

		// Token: 0x0600A06C RID: 41068 RVA: 0x002049AC File Offset: 0x00202DAC
		private void _doTeamVSAnimate(BattlePlayer.eDungeonPlayerTeamType type)
		{
			BattlePlayer currentTeamFightingPlayer = BattleMain.instance.GetPlayerManager().GetCurrentTeamFightingPlayer(type);
			if (!BattlePlayer.IsDataValidBattlePlayer(currentTeamFightingPlayer))
			{
				return;
			}
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].teamType == currentTeamFightingPlayer.teamType)
				{
					if (allPlayers[i].playerInfo.seat != currentTeamFightingPlayer.playerInfo.seat)
					{
						this._doOnePlayerVSAnimate((int)allPlayers[i].playerInfo.seat);
						base._playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType.eOut, allPlayers[i].playerInfo.seat);
					}
					else
					{
						base._playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType.eSelected, allPlayers[i].playerInfo.seat);
					}
				}
			}
		}

		// Token: 0x0600A06D RID: 41069 RVA: 0x00204A84 File Offset: 0x00202E84
		private void _doOnePlayerVSAnimate(int seat)
		{
			Dungeon3V3BaseLoadFrame.MatchUnit matchUnit = base._findBoardBySeat((byte)seat);
			if (matchUnit == null)
			{
				return;
			}
			if (null == matchUnit.unit)
			{
				return;
			}
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat((byte)seat);
			if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
			{
				return;
			}
			ComCommonBind unit = matchUnit.unit;
			Image com = unit.GetCom<Image>("battleImage");
			Image com2 = unit.GetCom<Image>("appliedImage");
			com2.gameObject.CustomActive(false);
			com.gameObject.SetActive(playerBySeat.isFighting);
		}

		// Token: 0x0600A06E RID: 41070 RVA: 0x00204B0F File Offset: 0x00202F0F
		private void _onPK3V3VoteForFightStatusChanged(UIEvent ui)
		{
			this._updateAllPlayersStatus();
		}

		// Token: 0x0600A06F RID: 41071 RVA: 0x00204B18 File Offset: 0x00202F18
		private void _updateAllPlayersStatus()
		{
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				this._updateOnePlayerStatus(allPlayers[i]);
			}
		}

		// Token: 0x0600A070 RID: 41072 RVA: 0x00204B5C File Offset: 0x00202F5C
		private void _updateOnePlayerStatus(BattlePlayer player)
		{
			if (!this._checkBattlePlayerIsValid(player))
			{
				return;
			}
			Dungeon3V3BaseLoadFrame.MatchUnit matchUnit = base._findBoardBySeat(player.playerInfo.seat);
			if (matchUnit == null)
			{
				return;
			}
			ComCommonBind unit = matchUnit.unit;
			if (null == unit)
			{
				return;
			}
			Image com = unit.GetCom<Image>("battleImage");
			Image com2 = unit.GetCom<Image>("appliedImage");
			com.gameObject.CustomActive(false);
			bool bActive = false;
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				bActive = (player.teamType == mainPlayer.teamType && player.isVote);
			}
			com2.gameObject.CustomActive(bActive);
		}

		// Token: 0x0600A071 RID: 41073 RVA: 0x00204C16 File Offset: 0x00203016
		protected override void _OnCloseFrame()
		{
			base._uninitBoards();
			this._unbindEvent();
		}

		// Token: 0x0600A072 RID: 41074 RVA: 0x00204C24 File Offset: 0x00203024
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A073 RID: 41075 RVA: 0x00204C28 File Offset: 0x00203028
		protected override void _OnUpdate(float delta)
		{
			if (this.mLoadingStatus == Dungeon3v3LoadingFrame.eLoadingStatus.Vote)
			{
				this.mLocalTickTime += delta;
				if (this.mLocalTickTime > 1f)
				{
					int num = BattleMain.instance.GetDungeonStatistics().GetMatchPlayerVoteTimeLeft() / 1000 + 1;
					if (num >= 9)
					{
						num = 9;
					}
					if (this.mLastLeftTime != num)
					{
						this.mCountEffect.TriggerAudio(12);
						this.mCountDownNum.SetTextNumber(num);
						this.mLastLeftTime = num;
					}
					this.mLocalTickTime -= 1f;
				}
			}
		}

		// Token: 0x0600A074 RID: 41076 RVA: 0x00204CC0 File Offset: 0x002030C0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Loading/PVPLoading/DungeonPVPLoadingFrame";
		}

		// Token: 0x0600A075 RID: 41077 RVA: 0x00204CC8 File Offset: 0x002030C8
		public IEnumerator UpdateProgress()
		{
			while (this._targetProgress <= 100)
			{
				while (this._currentProgress < this._targetProgress)
				{
					this._currentProgress += this._UpdateSpeed;
					if (this._currentProgress > this._targetProgress)
					{
						this._currentProgress = this._targetProgress;
					}
					this._SetProgress(this._currentProgress);
					yield return Yielders.EndOfFrame;
				}
				if (this._targetProgress == 100)
				{
					break;
				}
				yield return Yielders.EndOfFrame;
				this._targetProgress = (int)(Singleton<ClientSystemManager>.GetInstance().SwitchProgress * 100f);
			}
			yield break;
		}

		// Token: 0x0600A076 RID: 41078 RVA: 0x00204CE3 File Offset: 0x002030E3
		protected void _SetProgress(int progress)
		{
			if (progress < 0)
			{
				progress = 0;
			}
			if (progress > 100)
			{
				progress = 100;
			}
		}

		// Token: 0x0600A077 RID: 41079 RVA: 0x00204CFB File Offset: 0x002030FB
		private void OnJoinChannelSucc()
		{
			this.InitVoiceDeviceBtnsState(true);
		}

		// Token: 0x0600A078 RID: 41080 RVA: 0x00204D04 File Offset: 0x00203104
		private void OnVoiceSDKMicOn(bool isOn)
		{
			this.ChangeMicBtnStatus(isOn);
		}

		// Token: 0x0600A079 RID: 41081 RVA: 0x00204D0D File Offset: 0x0020310D
		private void OnVoiceSDKPlayerOn(bool isOn)
		{
			this.ChangePlayerBtnStatus(isOn);
		}

		// Token: 0x0600A07A RID: 41082 RVA: 0x00204D18 File Offset: 0x00203118
		private bool GetVoiceDeviceIsOn()
		{
			bool flag = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealMicOn();
			bool flag2 = Singleton<SDKVoiceManager>.GetInstance().IsTalkRealPlayerOn();
			return flag || flag2;
		}

		// Token: 0x0600A07B RID: 41083 RVA: 0x00204D48 File Offset: 0x00203148
		private void InitVoiceDeviceBtnsState(bool isShow)
		{
			if (this.mPvp3v3PlayerBtn)
			{
				this.mPvp3v3PlayerBtn.gameObject.CustomActive(isShow);
			}
			if (Singleton<ReplayServer>.instance.IsReplay())
			{
				if (this.mPvp3v3MicRoomBtn)
				{
					this.mPvp3v3MicRoomBtn.gameObject.CustomActive(false);
				}
			}
			else if (this.mPvp3v3MicRoomBtn)
			{
				this.mPvp3v3MicRoomBtn.gameObject.CustomActive(isShow);
			}
			this.ChangePlayerBtnStatus(false);
			this.ChangeMicBtnStatus(false);
		}

		// Token: 0x0600A07C RID: 41084 RVA: 0x00204DDC File Offset: 0x002031DC
		private void ChangeMicBtnStatus(bool isMicOn)
		{
			if (this.mPvp3v3MicRoomBtnClose != null)
			{
				this.mPvp3v3MicRoomBtnClose.gameObject.CustomActive(!isMicOn);
			}
			if (this.mPvp3v3MicRoomBtnBg != null)
			{
				this.mPvp3v3MicRoomBtnBg.enabled = isMicOn;
			}
		}

		// Token: 0x0600A07D RID: 41085 RVA: 0x00204E2C File Offset: 0x0020322C
		private void ChangePlayerBtnStatus(bool isPlayerOpen)
		{
			if (this.mPvp3v3PlayerBtnClose != null)
			{
				this.mPvp3v3PlayerBtnClose.gameObject.CustomActive(!isPlayerOpen);
			}
			if (this.mPvp3v3PlayerBtnBg != null)
			{
				this.mPvp3v3PlayerBtnBg.enabled = isPlayerOpen;
			}
		}

		// Token: 0x04005916 RID: 22806
		protected Dungeon3v3LoadingFrame.eLoadingStatus mLoadingStatus;

		// Token: 0x04005917 RID: 22807
		protected int _UpdateSpeed = 10;

		// Token: 0x04005918 RID: 22808
		protected int _targetProgress;

		// Token: 0x04005919 RID: 22809
		protected int _currentProgress = -1;

		// Token: 0x0400591A RID: 22810
		private float mLocalTickTime = 1f;

		// Token: 0x0400591B RID: 22811
		private int mLastLeftTime = -1;

		// Token: 0x020010A0 RID: 4256
		protected enum eLoadingStatus
		{
			// Token: 0x0400591D RID: 22813
			Loading,
			// Token: 0x0400591E RID: 22814
			Vote,
			// Token: 0x0400591F RID: 22815
			VsAnimate
		}
	}
}
