using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x020045BB RID: 17851
	public class PVP3V3Battle : BaseMatchPVPBattle
	{
		// Token: 0x060190B1 RID: 102577 RVA: 0x007E6734 File Offset: 0x007E4B34
		public PVP3V3Battle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x17002097 RID: 8343
		// (get) Token: 0x060190B2 RID: 102578 RVA: 0x007E6784 File Offset: 0x007E4B84
		// (set) Token: 0x060190B3 RID: 102579 RVA: 0x007E678C File Offset: 0x007E4B8C
		private PVP3V3Battle.ePVP3V3ProcessStatus curPVP3V3ProcessStatus
		{
			get
			{
				return this.mCurPVP3V3ProcessStatus;
			}
			set
			{
				this.mCurPVP3V3ProcessStatus = value;
			}
		}

		// Token: 0x060190B4 RID: 102580 RVA: 0x007E6798 File Offset: 0x007E4B98
		public override void Update(int delta)
		{
			base.Update(delta);
			PVP3V3Battle.ePVP3V3ProcessStatus curPVP3V3ProcessStatus = this.curPVP3V3ProcessStatus;
			if (curPVP3V3ProcessStatus == PVP3V3Battle.ePVP3V3ProcessStatus.WaitFirstVoteVSFlag || curPVP3V3ProcessStatus == PVP3V3Battle.ePVP3V3ProcessStatus.LodingRoundStart)
			{
				if (!this.mHasGCCollect)
				{
					this.mHasGCCollect = true;
					if (base._getMatchRoundIndex() > 0)
					{
						MonoSingleton<AssetGabageCollector>.instance.ClearUnusedAsset(null, false);
					}
				}
				this.mDuringLoadingCnt++;
				if (this.mDuringLoadingCnt >= 6 && !this.mHasPreloadFlag)
				{
					this.mHasPreloadFlag = true;
					MonoSingleton<CResPreloader>.instance.Clear(false);
					PreloadManager.ClearCache();
					BattlePlayer currentTeamFightingPlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
					BeActionFrameMgr frameMgr = null;
					SkillFileListCache fileCache = null;
					if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
					{
						frameMgr = this.mDungeonManager.GetBeScene().ActionFrameMgr;
						fileCache = this.mDungeonManager.GetBeScene().SkillFileCache;
					}
					if (BattlePlayer.IsDataValidBattlePlayer(currentTeamFightingPlayer))
					{
						PreloadManager.PreloadActor(currentTeamFightingPlayer.playerActor, frameMgr, fileCache, false);
					}
					BattlePlayer currentTeamFightingPlayer2 = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
					if (BattlePlayer.IsDataValidBattlePlayer(currentTeamFightingPlayer2))
					{
						PreloadManager.PreloadActor(currentTeamFightingPlayer2.playerActor, frameMgr, fileCache, false);
					}
					MonoSingleton<CResPreloader>.instance.DoPreLoadAsync(false, true);
				}
			}
		}

		// Token: 0x060190B5 RID: 102581 RVA: 0x007E68D0 File Offset: 0x007E4CD0
		public override void FrameUpdate(int delta)
		{
			switch (this.curPVP3V3ProcessStatus)
			{
			case PVP3V3Battle.ePVP3V3ProcessStatus.FirstVote:
				if (!this._isTimeUp(delta))
				{
					if (this._isRaceEnd())
					{
						this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRaceEndResult;
						this._closePVP3V3LoadingFrame();
						break;
					}
					this.mNextBlueTeamFighingPlayer = this._pickNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
					this.mNextRedTeamFighingPlayer = this._pickNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
					if (!this._showUpFightingCharactor())
					{
						Logger.LogErrorFormat("[战斗] [3v3] 创建下一场玩家失败 本伦比赛直接结束", new object[0]);
						this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRaceEndResult;
					}
					else
					{
						this.mTickTime = 4200;
						this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitFirstVote;
					}
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3FinishVoteForFight, null, null, null, null);
				}
				base.dungeonStatistics.SetMatchPlayerVoteTimeLeft(this.mTickTime);
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.WaitFirstVote:
				if (!this._isTimeUp(delta))
				{
					this.mTickTime = 3800;
					this.mHasPreloadFlag = false;
					this.mHasGCCollect = true;
					this.mDuringLoadingCnt = 6;
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitFirstVoteVSFlag;
				}
				base.dungeonStatistics.SetMatchPlayerVoteTimeLeft(0);
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.WaitFirstVoteVSFlag:
				if (!this._isTimeUp(delta))
				{
					this._closePVP3V3LoadingFrame();
					this.mTickTime = 0;
					this._setDeadBattlePlayerRemoveTime2Zero();
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.LodingRoundStart;
				}
				base.dungeonStatistics.SetMatchPlayerVoteTimeLeft(0);
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.PrepareRoundStart:
				base._sceneEntityRemoveAll();
				if (!this._showUpFightingCharactor())
				{
					Logger.LogErrorFormat("[战斗] [3v3] 创建第 {0} 轮玩家失败 本伦比赛直接结束", new object[]
					{
						base._getMatchRoundIndex()
					});
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRaceEndResult;
				}
				else
				{
					this.mTickTime = 4200;
					this._setDungeonReadyFightFrame(true);
					this._setDeadBattlePlayerRemoveTime2Zero();
					this.mDuringLoadingCnt = 0;
					this.mHasPreloadFlag = false;
					this.mHasGCCollect = false;
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.DuringLoadingRoundStart;
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.DuringLoadingRoundStart:
				if (!this._isTimeUp(delta))
				{
					this.mTickTime = 3800;
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.LodingRoundStart;
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.LodingRoundStart:
				if (!this._isTimeUp(delta))
				{
					this._resetAllCharactorVoteStatus();
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3StartRedyFightCount, null, null, null, null);
					this._setDungeonReadyFightFrame(false);
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.RoundStart;
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.RoundStart:
			{
				this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitFight;
				this.mMatchPlayerEndType = ePVPBattleEndType.onNone;
				this.mRedTeamPKResult = PKResult.INVALID;
				this.mBlueTeamPKResult = PKResult.INVALID;
				int num = (base.PkRaceType != 6) ? 240 : 180;
				this.mTickTime = num * 1000;
				base._startRoundReadyFight(3, num, true);
				this.SwitchRoundAddInvincibleBuff(this.mNextRedTeamFighingPlayer, true);
				this.SwitchRoundAddInvincibleBuff(this.mNextBlueTeamFighingPlayer, true);
				break;
			}
			case PVP3V3Battle.ePVP3V3ProcessStatus.Fight:
				if (!this._isTimeUp(delta))
				{
					this.mMatchPlayerEndType = ePVPBattleEndType.onTimeOut;
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRoundEndResult;
					this._getPKResultInCurrentRound();
					this._killTeamPlayerInCurrentRoundWithTimeOut();
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.GetRoundEndResult:
				this.mTickTime = 2000;
				this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitRoundEndResult;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3GetRoundEndResult, null, null, null, null);
				this.mNextRedTeamFighingPlayer = this._pickNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
				this.mNextBlueTeamFighingPlayer = this._pickNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
				this.SwitchRoundAddInvincibleBuff(this.mNextRedTeamFighingPlayer, false);
				this.SwitchRoundAddInvincibleBuff(this.mNextBlueTeamFighingPlayer, false);
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.WaitRoundEndResult:
				if (!this._isTimeUp(delta))
				{
					this.mTickTime = 2000;
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitTipRoundEndResult;
					this._hiddenBattleResult();
					if (!this._isRaceEnd())
					{
						this._showTipRoundEndResult();
					}
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.WaitTipRoundEndResult:
				if (!this._isTimeUp(delta))
				{
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.RoundEnd;
					this._hiddenTipRoundEndResult();
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.RoundEnd:
				if (this._isRaceEnd())
				{
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRaceEndResult;
				}
				else
				{
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.PrepareRoundStart;
					base._nextMatchRoundIndex();
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.GetRaceEndResult:
				this.mTickTime = 2000;
				this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.WaitRaceEndResult;
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.WaitRaceEndResult:
				if (!this._isTimeUp(delta))
				{
					this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.RaceEnd;
				}
				break;
			case PVP3V3Battle.ePVP3V3ProcessStatus.RaceEnd:
				base._sendRelaySvrEndGameReq();
				this.mDungeonManager.FinishFight();
				Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
				this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.Finish;
				break;
			}
		}

		// Token: 0x060190B6 RID: 102582 RVA: 0x007E6D10 File Offset: 0x007E5110
		private void _setDeadBattlePlayerRemoveTime2Zero()
		{
			for (int i = 0; i < this.mDeadFightingPlayers.Count; i++)
			{
				if (this.mDeadFightingPlayers[i] != null && this.mDeadFightingPlayers[i].playerActor != null)
				{
					this.mDeadFightingPlayers[i].playerActor.m_iRemoveTime = 0;
					this.mDeadFightingPlayers[i].playerActor.isLocalActor = false;
				}
			}
			this.mDeadFightingPlayers.Clear();
		}

		// Token: 0x060190B7 RID: 102583 RVA: 0x007E6D9C File Offset: 0x007E519C
		private void _showTipRoundEndResult()
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				return;
			}
			BattlePlayer battlePlayer = this._getNextTeamFightPlayer(mainPlayer.teamType);
			if (!BattlePlayer.IsDataValidBattlePlayer(battlePlayer))
			{
				return;
			}
			if (!battlePlayer.isFighting && battlePlayer.GetPlayerSeat() == mainPlayer.GetPlayerSeat())
			{
				base._showMainPlayerIsNextPlayer();
			}
		}

		// Token: 0x060190B8 RID: 102584 RVA: 0x007E6DFC File Offset: 0x007E51FC
		private void _hiddenTipRoundEndResult()
		{
			base._hiddenMainPlayerIsNextPlayer();
		}

		// Token: 0x060190B9 RID: 102585 RVA: 0x007E6E04 File Offset: 0x007E5204
		private void _resetAllCharactorVoteStatus()
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				allPlayers[i].isVote = false;
			}
		}

		// Token: 0x060190BA RID: 102586 RVA: 0x007E6E44 File Offset: 0x007E5244
		private void _setDungeonReadyFightFrame(bool isOpen)
		{
			if (isOpen)
			{
				byte currentTeamFightingPlayerSeat = this.mDungeonPlayers.GetCurrentTeamFightingPlayerSeat(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
				byte currentTeamFightingPlayerSeat2 = this.mDungeonPlayers.GetCurrentTeamFightingPlayerSeat(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
				base._openDungeonReadyFightFrame(currentTeamFightingPlayerSeat, currentTeamFightingPlayerSeat2);
			}
			else
			{
				base._closeDungeonReadyFightFrame();
			}
		}

		// Token: 0x060190BB RID: 102587 RVA: 0x007E6E84 File Offset: 0x007E5284
		private void _getPKResultInCurrentRound()
		{
			this.mRedTeamPKResult = this._getOnePKResult(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			this.mBlueTeamPKResult = this._getOnePKResult(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
		}

		// Token: 0x060190BC RID: 102588 RVA: 0x007E6EA0 File Offset: 0x007E52A0
		protected PKResult _getOnePKResult(BattlePlayer.eDungeonPlayerTeamType teamType)
		{
			BattlePlayer currentTeamFightingPlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(teamType);
			if (currentTeamFightingPlayer == null)
			{
				return PKResult.INVALID;
			}
			return base._getMatchPVPResult(currentTeamFightingPlayer.playerInfo.seat, this.mMatchPlayerEndType);
		}

		// Token: 0x060190BD RID: 102589 RVA: 0x007E6EDC File Offset: 0x007E52DC
		public BeActor GetWinActor()
		{
			PKResult pkresult = this._getOnePKResult(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			if (pkresult == PKResult.DRAW)
			{
				return null;
			}
			if (pkresult == PKResult.LOSE)
			{
				BattlePlayer currentTeamFightingPlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
				if (currentTeamFightingPlayer != null)
				{
					return currentTeamFightingPlayer.playerActor;
				}
				return null;
			}
			else
			{
				if (pkresult != PKResult.WIN)
				{
					if (pkresult == PKResult.INVALID)
					{
						pkresult = this._getOnePKResult(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
						if (pkresult == PKResult.DRAW)
						{
							return null;
						}
						if (pkresult == PKResult.WIN)
						{
							BattlePlayer currentTeamFightingPlayer2 = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
							if (currentTeamFightingPlayer2 != null)
							{
								return currentTeamFightingPlayer2.playerActor;
							}
							return null;
						}
					}
					return null;
				}
				BattlePlayer currentTeamFightingPlayer3 = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
				if (currentTeamFightingPlayer3 != null)
				{
					return currentTeamFightingPlayer3.playerActor;
				}
				return null;
			}
		}

		// Token: 0x060190BE RID: 102590 RVA: 0x007E6F7C File Offset: 0x007E537C
		private bool _isRaceEnd()
		{
			bool flag = this.mDungeonPlayers.IsTeamPlayerAllFighted(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			return this.mDungeonPlayers.IsTeamPlayerAllFighted(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue) || flag;
		}

		// Token: 0x060190BF RID: 102591 RVA: 0x007E6FAD File Offset: 0x007E53AD
		private bool _showUpFightingCharactor()
		{
			if (this._isRaceEnd())
			{
				return false;
			}
			this._pickOneFightingCharactor2Battle(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			this._pickOneFightingCharactor2Battle(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			this._adjustBalanceForOneFightingCharactor(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			this._adjustBalanceForOneFightingCharactor(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			this.mNextBlueTeamFighingPlayer = null;
			this.mNextRedTeamFighingPlayer = null;
			return true;
		}

		// Token: 0x060190C0 RID: 102592 RVA: 0x007E6FEC File Offset: 0x007E53EC
		private bool _pickOneFightingCharactor2Battle(BattlePlayer.eDungeonPlayerTeamType type)
		{
			BattlePlayer battlePlayer = this._getNextTeamFightPlayer(type);
			if (battlePlayer == null)
			{
				return false;
			}
			if (!battlePlayer.isFighting)
			{
				base._createMatchPlayer(battlePlayer);
				if (battlePlayer.IsLocalPlayer())
				{
					base._fireDoublePressConfigFrame();
					base._createInput();
				}
				if (battlePlayer.playerActor != null)
				{
					battlePlayer.playerActor.SetAttackButtonState(ButtonState.RELEASE, true);
				}
			}
			else
			{
				base._setCharactorAtBirthPosition(battlePlayer);
				base._resetCharactorStatus(battlePlayer);
				base._limitCharactorRestrainZone(battlePlayer);
			}
			return true;
		}

		// Token: 0x060190C1 RID: 102593 RVA: 0x007E7069 File Offset: 0x007E5469
		private BattlePlayer _getNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (type == BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
			{
				return this.mNextBlueTeamFighingPlayer;
			}
			if (type != BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
			{
				return null;
			}
			return this.mNextRedTeamFighingPlayer;
		}

		// Token: 0x060190C2 RID: 102594 RVA: 0x007E708C File Offset: 0x007E548C
		private BattlePlayer _pickNextTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType type)
		{
			BattlePlayer battlePlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(type);
			if (battlePlayer == null)
			{
				battlePlayer = this._pickNewTeamFightPlayer(type);
			}
			return battlePlayer;
		}

		// Token: 0x060190C3 RID: 102595 RVA: 0x007E70B8 File Offset: 0x007E54B8
		private BattlePlayer _pickNewTeamFightPlayer(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> list = this._getClearCurrentPendingFightPlayers(type);
			if (!this.mDungeonPlayers.GetTeamVotePlayers(list, type))
			{
				return null;
			}
			if (list.Count > 0)
			{
				return this._randPendingFightPlayers2Fight(list);
			}
			if (!this.mDungeonPlayers.GetTeamNotVotePlayers(list, type))
			{
				return null;
			}
			if (list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

		// Token: 0x060190C4 RID: 102596 RVA: 0x007E7120 File Offset: 0x007E5520
		private BattlePlayer _randPendingFightPlayers2Fight(List<BattlePlayer> pendingPlayers)
		{
			if (pendingPlayers == null || pendingPlayers.Count <= 0)
			{
				return null;
			}
			int index = 0;
			int count = pendingPlayers.Count;
			if (base.FrameRandom != null)
			{
				index = (int)base.FrameRandom.Random((uint)count) % count;
			}
			return pendingPlayers[index];
		}

		// Token: 0x060190C5 RID: 102597 RVA: 0x007E716C File Offset: 0x007E556C
		private List<BattlePlayer> _getClearCurrentPendingFightPlayers(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> list = null;
			if (type != BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
			{
				if (type == BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
				{
					list = this.mCurrentRedTeamPendingFightPlayers;
				}
			}
			else
			{
				list = this.mCurrentBlueTeamPendingFightPlayers;
			}
			if (list == null)
			{
				list = new List<BattlePlayer>();
			}
			list.Clear();
			return list;
		}

		// Token: 0x060190C6 RID: 102598 RVA: 0x007E71B8 File Offset: 0x007E55B8
		private bool _adjustBalanceForOneFightingCharactor(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (this._isRaceEnd())
			{
				return false;
			}
			BattlePlayer currentTeamFightingPlayer = this.mDungeonPlayers.GetCurrentTeamFightingPlayer(type);
			return BattlePlayer.IsDataValidBattlePlayer(currentTeamFightingPlayer) && currentTeamFightingPlayer.GetLastPKResult() == PKResult.INVALID && base._adjustBalanceMatchPlayer(currentTeamFightingPlayer);
		}

		// Token: 0x060190C7 RID: 102599 RVA: 0x007E7201 File Offset: 0x007E5601
		private void _closePVP3V3LoadingFrame()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<Dungeon3v3LoadingFrame>(null, false);
		}

		// Token: 0x060190C8 RID: 102600 RVA: 0x007E7210 File Offset: 0x007E5610
		private bool _killTeamPlayerInCurrentRoundWithTimeOut()
		{
			if (this.mMatchPlayerEndType != ePVPBattleEndType.onTimeOut)
			{
				Logger.LogErrorFormat("[战斗] 错误比赛结束状态 {0}", new object[]
				{
					this.mMatchPlayerEndType
				});
				return false;
			}
			if (this._isPkResultCanKillPlayerWithTimeOut(this.mRedTeamPKResult))
			{
				base._killOneTeamPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			}
			if (this._isPkResultCanKillPlayerWithTimeOut(this.mBlueTeamPKResult))
			{
				base._killOneTeamPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			}
			return true;
		}

		// Token: 0x060190C9 RID: 102601 RVA: 0x007E727C File Offset: 0x007E567C
		private bool _isPkResultCanKillPlayerWithTimeOut(PKResult result)
		{
			return result == PKResult.DRAW || result == PKResult.LOSE;
		}

		// Token: 0x060190CA RID: 102602 RVA: 0x007E7291 File Offset: 0x007E5691
		private bool _isTimeUp(int delta)
		{
			this.mTickTime -= delta;
			return !this._isTickTimeUp();
		}

		// Token: 0x060190CB RID: 102603 RVA: 0x007E72AA File Offset: 0x007E56AA
		private bool _isTickTimeUp()
		{
			return this.mTickTime <= 0;
		}

		// Token: 0x060190CC RID: 102604 RVA: 0x007E72B8 File Offset: 0x007E56B8
		protected override void _onGameStartFrame(BattlePlayer player)
		{
			base._hiddenAllInput();
			this.mTickTime = 10000;
			this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.FirstVote;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3StartVoteForFight, null, null, null, null);
		}

		// Token: 0x060190CD RID: 102605 RVA: 0x007E72E5 File Offset: 0x007E56E5
		protected override void _onMatchBattlePlayerReady2Fight()
		{
			this.mTickTime = ((base.PkRaceType != 6) ? 240000 : 180000);
			this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.Fight;
		}

		// Token: 0x060190CE RID: 102606 RVA: 0x007E7310 File Offset: 0x007E5710
		protected override void _onMatchBattlePlayerDead(BattlePlayer player)
		{
			ePVPBattleEndType ePVPBattleEndType = this.mMatchPlayerEndType;
			if (ePVPBattleEndType != ePVPBattleEndType.onNone)
			{
				if (ePVPBattleEndType != ePVPBattleEndType.onTimeOut)
				{
					if (ePVPBattleEndType != ePVPBattleEndType.onAllEnemyDied)
					{
					}
				}
			}
			else
			{
				this.mMatchPlayerEndType = ePVPBattleEndType.onAllEnemyDied;
				this.curPVP3V3ProcessStatus = PVP3V3Battle.ePVP3V3ProcessStatus.GetRoundEndResult;
				this._getPKResultInCurrentRound();
			}
			this._showBattleResult();
			this.mDeadFightingPlayers.Add(player);
			if (player != null && player.playerActor != null)
			{
				player.playerActor.SetAttackButtonState(ButtonState.RELEASE, true);
			}
			if (player.IsLocalPlayer())
			{
				base._unloadInputManger();
			}
		}

		// Token: 0x060190CF RID: 102607 RVA: 0x007E73A4 File Offset: 0x007E57A4
		private void _showBattleResult()
		{
			BattlePlayer.eDungeonPlayerTeamType teamType = this.mDungeonPlayers.GetMainPlayer().teamType;
			if (teamType != BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
			{
				if (teamType == BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
				{
					base._showMatchResult(this.mRedTeamPKResult);
				}
			}
			else
			{
				base._showMatchResult(this.mBlueTeamPKResult);
			}
		}

		// Token: 0x060190D0 RID: 102608 RVA: 0x007E73F6 File Offset: 0x007E57F6
		private void _hiddenBattleResult()
		{
			base._hiddenMatchResult();
		}

		// Token: 0x060190D1 RID: 102609 RVA: 0x007E73FE File Offset: 0x007E57FE
		protected override void _onMatchRoundVote(BattlePlayer player)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PK3V3VoteForFightStatusChanged, null, null, null, null);
			this._allPlayerApplyBattleTips();
		}

		// Token: 0x060190D2 RID: 102610 RVA: 0x007E741C File Offset: 0x007E581C
		private void _allPlayerApplyBattleTips()
		{
			if (this.curPVP3V3ProcessStatus == PVP3V3Battle.ePVP3V3ProcessStatus.FirstVote)
			{
				return;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (!BattlePlayer.IsDataValidBattlePlayer(mainPlayer))
			{
				return;
			}
			this.mCacheRoundVotePlayers.Clear();
			this.mDungeonPlayers.GetTeamNotVotePlayers(this.mCacheRoundVotePlayers, mainPlayer.teamType);
			if (this.mCacheRoundVotePlayers.Count > 0)
			{
				return;
			}
			this.mDungeonPlayers.GetTeamVotePlayers(this.mCacheRoundVotePlayers, mainPlayer.teamType);
			for (int i = 0; i < this.mCacheRoundVotePlayers.Count; i++)
			{
				if (this.mCacheRoundVotePlayers[i].GetPlayerSeat() == mainPlayer.GetPlayerSeat())
				{
					SystemNotifyManager.SystemNotify(9219, string.Empty);
					return;
				}
			}
		}

		// Token: 0x060190D3 RID: 102611 RVA: 0x007E74E3 File Offset: 0x007E58E3
		protected override void _onStart()
		{
			this._bindNetMessage();
		}

		// Token: 0x060190D4 RID: 102612 RVA: 0x007E74EB File Offset: 0x007E58EB
		protected override void _onEnd()
		{
			this._unbindNetMessage();
		}

		// Token: 0x060190D5 RID: 102613 RVA: 0x007E74F3 File Offset: 0x007E58F3
		private void _bindNetMessage()
		{
			NetProcess.AddMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x060190D6 RID: 102614 RVA: 0x007E750B File Offset: 0x007E590B
		private void _unbindNetMessage()
		{
			NetProcess.RemoveMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x060190D7 RID: 102615 RVA: 0x007E7524 File Offset: 0x007E5924
		private void _onSceneRoomMatchPkRaceEnd(MsgDATA data)
		{
			SceneRoomMatchPkRaceEnd sceneRoomMatchPkRaceEnd = new SceneRoomMatchPkRaceEnd();
			sceneRoomMatchPkRaceEnd.decode(data.bytes);
			this._convert2BattlePlayer(sceneRoomMatchPkRaceEnd);
			this._openDungeonMatchRaceResult(sceneRoomMatchPkRaceEnd);
			this._openDungeon3v3FinishFrame(sceneRoomMatchPkRaceEnd);
		}

		// Token: 0x060190D8 RID: 102616 RVA: 0x007E7558 File Offset: 0x007E5958
		private void _openDungeon3v3FinishFrame(SceneRoomMatchPkRaceEnd res)
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_RACE_ID_CHECK))
				{
					if (ClientApplication.playerinfo != null && res.raceId != 0UL && res.raceId == ClientApplication.playerinfo.session)
					{
						Singleton<ClientSystemManager>.instance.OpenFrame<Dungeon3v3FinishFrame>(FrameLayer.Middle, null, string.Empty);
					}
				}
				else
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<Dungeon3v3FinishFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
		}

		// Token: 0x060190D9 RID: 102617 RVA: 0x007E75E4 File Offset: 0x007E59E4
		private void _openDungeonMatchRaceResult(SceneRoomMatchPkRaceEnd pkEndData)
		{
		}

		// Token: 0x060190DA RID: 102618 RVA: 0x007E75E8 File Offset: 0x007E59E8
		private void _convert2BattlePlayer(SceneRoomMatchPkRaceEnd res)
		{
			if (res == null)
			{
				Logger.LogErrorFormat("[战斗] [3v3] raceEnd 为空", new object[0]);
				return;
			}
			for (int i = 0; i < res.slotInfos.Length; i++)
			{
				RoomSlotBattleEndInfo roomSlotBattleEndInfo = res.slotInfos[i];
				if (roomSlotBattleEndInfo != null)
				{
					BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(roomSlotBattleEndInfo.seat);
					if (playerBySeat != null)
					{
						if (playerBySeat.IsLocalPlayer())
						{
							playerBySeat.ConvertSceneRoomMatchPkRaceEnd2LocalBattlePlayer(res);
						}
						playerBySeat.ConvertRoomSlotBattleEndInfo2BattlePlayer(roomSlotBattleEndInfo);
					}
				}
			}
		}

		// Token: 0x060190DB RID: 102619 RVA: 0x007E7674 File Offset: 0x007E5A74
		private void SwitchRoundAddInvincibleBuff(BattlePlayer player, bool isRestore = false)
		{
			if (player == null)
			{
				return;
			}
			if (player.playerActor == null || player.playerActor.IsDead())
			{
				return;
			}
			if (isRestore)
			{
				player.playerActor.buffController.RemoveBuff(38, 0, 0);
			}
			else
			{
				player.playerActor.buffController.TryAddBuff(38, GlobalLogic.VALUE_10000, 1);
			}
		}

		// Token: 0x04011F70 RID: 73584
		private const int kFirstVoteTime = 10000;

		// Token: 0x04011F71 RID: 73585
		private const int kWaitFirstVoteTime = 4200;

		// Token: 0x04011F72 RID: 73586
		private const int kWaitFirstVoteVSTime = 3800;

		// Token: 0x04011F73 RID: 73587
		private const int kWaitPkLoadingTime = 4200;

		// Token: 0x04011F74 RID: 73588
		private const int kWaitVSPkLoadingTime = 3800;

		// Token: 0x04011F75 RID: 73589
		private const int kFightTimeInSec = 240;

		// Token: 0x04011F76 RID: 73590
		private const int kFightTime = 240000;

		// Token: 0x04011F77 RID: 73591
		private const int scoreWarFightTime = 180;

		// Token: 0x04011F78 RID: 73592
		private const int kRoundResultTime = 2000;

		// Token: 0x04011F79 RID: 73593
		private const int kTipRoundEndResultTime = 2000;

		// Token: 0x04011F7A RID: 73594
		private const int kEndResultTime = 2000;

		// Token: 0x04011F7B RID: 73595
		private const int kWaitForFightTimeInSec = 3;

		// Token: 0x04011F7C RID: 73596
		private PVP3V3Battle.ePVP3V3ProcessStatus mCurPVP3V3ProcessStatus;

		// Token: 0x04011F7D RID: 73597
		private int mTickTime;

		// Token: 0x04011F7E RID: 73598
		private ePVPBattleEndType mMatchPlayerEndType;

		// Token: 0x04011F7F RID: 73599
		private PKResult mRedTeamPKResult = PKResult.INVALID;

		// Token: 0x04011F80 RID: 73600
		private PKResult mBlueTeamPKResult = PKResult.INVALID;

		// Token: 0x04011F81 RID: 73601
		private List<BattlePlayer> mCurrentRedTeamPendingFightPlayers = new List<BattlePlayer>();

		// Token: 0x04011F82 RID: 73602
		private List<BattlePlayer> mCurrentBlueTeamPendingFightPlayers = new List<BattlePlayer>();

		// Token: 0x04011F83 RID: 73603
		private BattlePlayer mNextRedTeamFighingPlayer;

		// Token: 0x04011F84 RID: 73604
		private BattlePlayer mNextBlueTeamFighingPlayer;

		// Token: 0x04011F85 RID: 73605
		private List<BattlePlayer> mDeadFightingPlayers = new List<BattlePlayer>();

		// Token: 0x04011F86 RID: 73606
		private int mDuringLoadingCnt;

		// Token: 0x04011F87 RID: 73607
		private bool mHasPreloadFlag;

		// Token: 0x04011F88 RID: 73608
		private bool mHasGCCollect;

		// Token: 0x04011F89 RID: 73609
		private List<BattlePlayer> mCacheRoundVotePlayers = new List<BattlePlayer>();

		// Token: 0x020045BC RID: 17852
		private enum ePVP3V3ProcessStatus
		{
			// Token: 0x04011F8B RID: 73611
			None,
			// Token: 0x04011F8C RID: 73612
			FirstVote,
			// Token: 0x04011F8D RID: 73613
			WaitFirstVote,
			// Token: 0x04011F8E RID: 73614
			WaitFirstVoteVSFlag,
			// Token: 0x04011F8F RID: 73615
			PrepareRoundStart,
			// Token: 0x04011F90 RID: 73616
			DuringLoadingRoundStart,
			// Token: 0x04011F91 RID: 73617
			LodingRoundStart,
			// Token: 0x04011F92 RID: 73618
			RoundStart,
			// Token: 0x04011F93 RID: 73619
			WaitFight,
			// Token: 0x04011F94 RID: 73620
			Fight,
			// Token: 0x04011F95 RID: 73621
			GetRoundEndResult,
			// Token: 0x04011F96 RID: 73622
			WaitRoundEndResult,
			// Token: 0x04011F97 RID: 73623
			WaitTipRoundEndResult,
			// Token: 0x04011F98 RID: 73624
			RoundEnd,
			// Token: 0x04011F99 RID: 73625
			GetRaceEndResult,
			// Token: 0x04011F9A RID: 73626
			WaitRaceEndResult,
			// Token: 0x04011F9B RID: 73627
			RaceEnd,
			// Token: 0x04011F9C RID: 73628
			Finish
		}
	}
}
