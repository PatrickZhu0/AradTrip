using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200109C RID: 4252
	public class Dungeon3v3FinishFrame : ClientFrame
	{
		// Token: 0x0600A02A RID: 41002 RVA: 0x00202DFC File Offset: 0x002011FC
		protected override void _bindExUI()
		{
			this.mBestPlayerName = this.mBind.GetCom<Text>("bestPlayerName");
			this.mBestPlayerIcon = this.mBind.GetGameObject("bestPlayerIcon");
			this.mTipsCanvasGroup = this.mBind.GetCom<CanvasGroup>("tipsCanvasGroup");
			this.mCount2Close = this.mBind.GetCom<ComCountScript>("count2Close");
			this.mSeat0 = this.mBind.GetGameObject("seat0");
			this.mSeat1 = this.mBind.GetGameObject("seat1");
			this.mSeat2 = this.mBind.GetGameObject("seat2");
			this.mSeat3 = this.mBind.GetGameObject("seat3");
			this.mSeat4 = this.mBind.GetGameObject("seat4");
			this.mSeat5 = this.mBind.GetGameObject("seat5");
			this.mResult = this.mBind.GetCom<Image>("result");
			this.mRankTitle = this.mBind.GetGameObject("rankTitle");
			this.scoreTitle = this.mBind.GetGameObject("scoreTitle");
			this.mBaseScoreTitle = this.mBind.GetGameObject("baseScoreTitle");
			this.mContributeTitle = this.mBind.GetGameObject("contributeTitle");
			this.mCloseButton = this.mBind.GetCom<Button>("closeButton");
			if (null != this.mCloseButton)
			{
				this.mCloseButton.onClick.AddListener(new UnityAction(this._onCloseButtonButtonClick));
			}
			this.mGloryTitle = this.mBind.GetGameObject("gloryTitle");
		}

		// Token: 0x0600A02B RID: 41003 RVA: 0x00202FAC File Offset: 0x002013AC
		protected override void _unbindExUI()
		{
			this.mBestPlayerName = null;
			this.mBestPlayerIcon = null;
			this.mTipsCanvasGroup = null;
			this.mCount2Close = null;
			this.mSeat0 = null;
			this.mSeat1 = null;
			this.mSeat2 = null;
			this.mSeat3 = null;
			this.mSeat4 = null;
			this.mSeat5 = null;
			this.mResult = null;
			this.mRankTitle = null;
			this.mBaseScoreTitle = null;
			this.mContributeTitle = null;
			this.scoreTitle = null;
			if (null != this.mCloseButton)
			{
				this.mCloseButton.onClick.RemoveListener(new UnityAction(this._onCloseButtonButtonClick));
			}
			this.mCloseButton = null;
			this.mGloryTitle = null;
		}

		// Token: 0x0600A02C RID: 41004 RVA: 0x00203060 File Offset: 0x00201460
		private void _onCloseButtonButtonClick()
		{
			if (Singleton<ReplayServer>.instance.IsReplay())
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
				return;
			}
			if (this.mCurrentRoomType == RoomType.ROOM_TYPE_THREE_MATCH)
			{
				Dungeon3v3FinishFrame.eState eState = this.mState;
				if (eState != Dungeon3v3FinishFrame.eState.eWaitClose)
				{
					if (eState != Dungeon3v3FinishFrame.eState.eClose)
					{
						Logger.LogErrorFormat("[战斗] [3v3] 其他状态 {0}", new object[]
						{
							this.mState
						});
					}
					else
					{
						Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
					}
				}
				else if (this._isSceneRoomMatchPkRaceEndRecied())
				{
					this._openDungeonMatchRaceResult(this.mSceneRoomMatchPkRaceEnd);
				}
				else
				{
					Logger.LogErrorFormat("[战斗] [3v3] 打开匹配结果界面错误哦 还没收到比赛结束消息", new object[0]);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
		}

		// Token: 0x0600A02D RID: 41005 RVA: 0x00203128 File Offset: 0x00201528
		private void _onAutoClose()
		{
			if (this.mCurrentRoomType == RoomType.ROOM_TYPE_THREE_MATCH)
			{
				Dungeon3v3FinishFrame.eState eState = this.mState;
				if (eState != Dungeon3v3FinishFrame.eState.eClose)
				{
					Logger.LogErrorFormat("[战斗] [3v3] 其他状态 {0}", new object[]
					{
						this.mState
					});
				}
				else if (this._isSceneRoomMatchPkRaceEndRecied())
				{
					this._openDungeonMatchRaceResult(this.mSceneRoomMatchPkRaceEnd);
				}
				else
				{
					Logger.LogErrorFormat("[战斗] [3v3] 打开匹配结果界面错误哦 还没收到比赛结束消息", new object[0]);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
		}

		// Token: 0x0600A02E RID: 41006 RVA: 0x002031BA File Offset: 0x002015BA
		private bool _isSceneRoomMatchPkRaceEndRecied()
		{
			return null != this.mSceneRoomMatchPkRaceEnd;
		}

		// Token: 0x0600A02F RID: 41007 RVA: 0x002031C8 File Offset: 0x002015C8
		private void _openDungeonMatchRaceResult(SceneRoomMatchPkRaceEnd pkEndData)
		{
			if (this.mCurrentRoomType != RoomType.ROOM_TYPE_THREE_MATCH)
			{
				Logger.LogErrorFormat("[战斗] [3v3] 打开匹配结果界面错误哦 当前比赛类型 {0}", new object[]
				{
					this.mCurrentRoomType
				});
				return;
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<Dungeon3v3FinishFrame>(this, false);
			Singleton<ClientSystemManager>.instance.OpenFrame<PKBattleResultFrame>(FrameLayer.Middle, this.mSceneRoomMatchPkRaceEnd, string.Empty);
		}

		// Token: 0x0600A030 RID: 41008 RVA: 0x00203223 File Offset: 0x00201623
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk3v3/Pk3v3ResultFrame";
		}

		// Token: 0x0600A031 RID: 41009 RVA: 0x0020322A File Offset: 0x0020162A
		protected override void _OnOpenFrame()
		{
			this._initFrameState();
			this._clearAllBoards();
			this._initBoardTitle();
			this._initBoards();
			this._initAllPlayersFromBattleInfo();
			this._initBestPlayer();
			this._updateResultImage();
			this._updateAllPlayersFromResultInfo();
			this._bindEvents();
			this._bindNetMessage();
		}

		// Token: 0x0600A032 RID: 41010 RVA: 0x00203268 File Offset: 0x00201668
		private void UpdateBattleResultInfo()
		{
		}

		// Token: 0x0600A033 RID: 41011 RVA: 0x0020326A File Offset: 0x0020166A
		protected override void _OnCloseFrame()
		{
			this._clearFrameState();
			this._unbindEvents();
			this._clearAllBoards();
			this._unbindNetMessage();
		}

		// Token: 0x0600A034 RID: 41012 RVA: 0x00203284 File Offset: 0x00201684
		private void _bindNetMessage()
		{
			NetProcess.AddMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x0600A035 RID: 41013 RVA: 0x0020329C File Offset: 0x0020169C
		private void _unbindNetMessage()
		{
			NetProcess.RemoveMsgHandler(507802U, new Action<MsgDATA>(this._onSceneRoomMatchPkRaceEnd));
		}

		// Token: 0x0600A036 RID: 41014 RVA: 0x002032B4 File Offset: 0x002016B4
		private void _onSceneRoomMatchPkRaceEnd(MsgDATA data)
		{
			SceneRoomMatchPkRaceEnd sceneRoomMatchPkRaceEnd = new SceneRoomMatchPkRaceEnd();
			sceneRoomMatchPkRaceEnd.decode(data.bytes);
			this.mSceneRoomMatchPkRaceEnd = sceneRoomMatchPkRaceEnd;
			if (this.mState == Dungeon3v3FinishFrame.eState.eClose)
			{
				this._openDungeonMatchRaceResult(sceneRoomMatchPkRaceEnd);
			}
		}

		// Token: 0x0600A037 RID: 41015 RVA: 0x002032ED File Offset: 0x002016ED
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PK2V2CrossScoreGetRaceEndResult, new ClientEventSystem.UIEventHandler(this._onPK2V2GetRaceEndResult));
		}

		// Token: 0x0600A038 RID: 41016 RVA: 0x0020330A File Offset: 0x0020170A
		private void _unbindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PK2V2CrossScoreGetRaceEndResult, new ClientEventSystem.UIEventHandler(this._onPK2V2GetRaceEndResult));
		}

		// Token: 0x0600A039 RID: 41017 RVA: 0x00203327 File Offset: 0x00201727
		private void _onPK3V3GetRaceEndResult(UIEvent ui)
		{
			this._updateAllPlayersFromResultInfo();
		}

		// Token: 0x0600A03A RID: 41018 RVA: 0x0020332F File Offset: 0x0020172F
		private void _onPK2V2GetRaceEndResult(UIEvent ui)
		{
			this._updateAllPlayersFromResultInfo();
		}

		// Token: 0x0600A03B RID: 41019 RVA: 0x00203338 File Offset: 0x00201738
		private void _updateResultImage()
		{
			if (null == this.mResult)
			{
				return;
			}
			BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
			if (mainPlayer == null)
			{
				this.mResult.enabled = false;
				return;
			}
			switch (this._getTeamRaceEndResult(mainPlayer.teamType))
			{
			case PKResult.WIN:
				this.mBind.GetSprite("win", ref this.mResult);
				return;
			case PKResult.LOSE:
				this.mBind.GetSprite("lose", ref this.mResult);
				return;
			case PKResult.DRAW:
				this.mBind.GetSprite("draw", ref this.mResult);
				return;
			}
			this.mResult.enabled = false;
		}

		// Token: 0x0600A03C RID: 41020 RVA: 0x00203408 File Offset: 0x00201808
		private void _updateAllPlayersFromResultInfo()
		{
			for (int i = 0; i < this.mResults.Count; i++)
			{
				BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mResults[i].seat);
				ComCommonBind bind = this.mResults[i].bind;
				if (!(null == bind) && playerBySeat != null && !this._is3v3Scuffle())
				{
					this._updateOnePlayerSeasonInfo(bind, playerBySeat.GetRaceEndResultSeasonLevel(), playerBySeat);
				}
			}
		}

		// Token: 0x0600A03D RID: 41021 RVA: 0x00203498 File Offset: 0x00201898
		private void _clearAllBoards()
		{
			for (int i = 0; i < this.mResults.Count; i++)
			{
				this.mResults[i].bind.ClearAllCacheBinds();
				this.mResults[i].bind = null;
				this.mResults[i].root = null;
				this.mResults[i].seat = byte.MaxValue;
			}
			this.mResults.Clear();
		}

		// Token: 0x0600A03E RID: 41022 RVA: 0x0020351C File Offset: 0x0020191C
		private void _initBestPlayer()
		{
			BattlePlayer battlePlayer = this._getRaceEndTopRankPlayer();
			if (battlePlayer == null)
			{
				return;
			}
			this.mBestPlayerName.text = battlePlayer.GetPlayerName();
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)battlePlayer.playerInfo.occupation, string.Empty, string.Empty);
			if (tableItem != null && tableItem.PKResultPrefab != string.Empty && tableItem.PKResultPrefab != "-")
			{
				GameObject go = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem.PKResultPrefab, true, 0U);
				Utility.AttachTo(go, this.mBestPlayerIcon, false);
			}
		}

		// Token: 0x0600A03F RID: 41023 RVA: 0x002035B8 File Offset: 0x002019B8
		private BattlePlayer _getRaceEndTopRankPlayer()
		{
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			PKResult pkresult = this._getTeamRaceEndResult(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			if (pkresult == PKResult.WIN)
			{
				return this._getRaceEndTeamTopRankPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			}
			if (pkresult == PKResult.LOSE)
			{
				return this._getRaceEndTeamTopRankPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			}
			if (pkresult == PKResult.DRAW)
			{
				if (this._is3v3Scuffle() || this._is2v2ScuffleScore())
				{
					List<BattlePlayer> allPlayers2 = BattleMain.instance.GetPlayerManager().GetAllPlayers();
					allPlayers2.Sort(new Comparison<BattlePlayer>(this._teamPlayerScoreCmp));
					return allPlayers2[0];
				}
				BattlePlayer mainPlayer = BattleMain.instance.GetPlayerManager().GetMainPlayer();
				if (mainPlayer != null)
				{
					if (mainPlayer.IsTeamRed())
					{
						return this._getRaceEndTeamTopRankPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
					}
					return this._getRaceEndTeamTopRankPlayer(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
				}
			}
			Logger.LogErrorFormat("[战斗] 战斗结果异常 {0}", new object[]
			{
				pkresult
			});
			if (allPlayers.Count > 0)
			{
				return allPlayers[0];
			}
			return null;
		}

		// Token: 0x0600A040 RID: 41024 RVA: 0x002036AC File Offset: 0x00201AAC
		public PKResult _getTeamRaceEndResult(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (this._is3v3Scuffle() || this._is2v2ScuffleScore())
			{
				if (BattleMain.instance != null && BattleMain.instance.GetBattle() != null)
				{
					PVPScuffleBattle pvpscuffleBattle = BattleMain.instance.GetBattle() as PVPScuffleBattle;
					return pvpscuffleBattle.GetRaceEndResult(type);
				}
				return PKResult.INVALID;
			}
			else
			{
				if (!BattleMain.instance.GetPlayerManager().IsTeamPlayerAllFighted(type))
				{
					return PKResult.WIN;
				}
				if (!BattleMain.instance.GetPlayerManager().IsTeamPlayerAllFighted(BattlePlayer.GetTargetTeamType(type)))
				{
					return PKResult.LOSE;
				}
				List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
				PKResult result = PKResult.INVALID;
				int num = -1;
				for (int i = 0; i < allPlayers.Count; i++)
				{
					if (allPlayers[i].teamType == type)
					{
						int lastPKRoundIndex = allPlayers[i].GetLastPKRoundIndex();
						if (lastPKRoundIndex > num)
						{
							result = allPlayers[i].GetLastPKResult();
							num = lastPKRoundIndex;
						}
					}
				}
				return result;
			}
		}

		// Token: 0x0600A041 RID: 41025 RVA: 0x002037A0 File Offset: 0x00201BA0
		public BattlePlayer _getRaceEndTeamTopRankPlayer(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> list = this._getRaceEndTeamResultsInCacheList(type);
			if (list == null || list.Count <= 0)
			{
				return null;
			}
			return list[0];
		}

		// Token: 0x0600A042 RID: 41026 RVA: 0x002037D0 File Offset: 0x00201BD0
		private List<BattlePlayer> _getRaceEndTeamResultsInCacheList(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> list = this._getTeamPlayers(type);
			if (list == null || list.Count <= 0)
			{
				return new List<BattlePlayer>();
			}
			if (!this._is3v3Score())
			{
				list.Sort(new Comparison<BattlePlayer>(this._teamPlayerScoreCmp));
			}
			else
			{
				list.Sort(new Comparison<BattlePlayer>(this._teamPlayerScoreCmp3v3Cross));
			}
			return list;
		}

		// Token: 0x0600A043 RID: 41027 RVA: 0x00203834 File Offset: 0x00201C34
		private List<BattlePlayer> _getTeamPlayers(BattlePlayer.eDungeonPlayerTeamType type)
		{
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			List<BattlePlayer> list = new List<BattlePlayer>();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i].teamType == type)
				{
					list.Add(allPlayers[i]);
				}
			}
			return list;
		}

		// Token: 0x0600A044 RID: 41028 RVA: 0x00203890 File Offset: 0x00201C90
		private int _teamPlayerScoreCmp(BattlePlayer fst, BattlePlayer snd)
		{
			int killMatchPlayerCount = fst.GetKillMatchPlayerCount();
			int killMatchPlayerCount2 = snd.GetKillMatchPlayerCount();
			if (killMatchPlayerCount > killMatchPlayerCount2)
			{
				return -1;
			}
			if (killMatchPlayerCount == killMatchPlayerCount2)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0600A045 RID: 41029 RVA: 0x002038C0 File Offset: 0x00201CC0
		private int _teamPlayerScoreCmp3v3Cross(BattlePlayer fst, BattlePlayer snd)
		{
			uint num = fst.GetRaceEndResultScoreWarBaseScore() + fst.GetRaceEndResultScoreWarContriScore();
			uint num2 = snd.GetRaceEndResultScoreWarBaseScore() + snd.GetRaceEndResultScoreWarContriScore();
			Logger.LogErrorFormat("fstScore = {0},sndScore = {1}", new object[]
			{
				num,
				num2
			});
			if (num > num2)
			{
				return -1;
			}
			if (num == num2)
			{
				return 0;
			}
			return 1;
		}

		// Token: 0x0600A046 RID: 41030 RVA: 0x00203920 File Offset: 0x00201D20
		private void _initBoardTitle()
		{
			bool flag = !this._is3v3Score();
			this.mRankTitle.CustomActive(flag);
			this.mContributeTitle.CustomActive(!flag);
			this.mBaseScoreTitle.CustomActive(!flag);
			this.mGloryTitle.CustomActive(!flag);
			this.scoreTitle.CustomActive(false);
			if (this._is2v2ScuffleScore())
			{
				this.mRankTitle.CustomActive(false);
				this.mContributeTitle.CustomActive(false);
				this.mBaseScoreTitle.CustomActive(false);
				this.scoreTitle.CustomActive(true);
				this.mGloryTitle.CustomActive(true);
			}
		}

		// Token: 0x0600A047 RID: 41031 RVA: 0x002039C4 File Offset: 0x00201DC4
		private void _initBoards()
		{
			string prefabPath = this.mBind.GetPrefabPath("unit");
			this.mBind.ClearCacheBinds(prefabPath);
			BattlePlayer[] array = this._getAllPlayerRaceEndRanks();
			for (int i = 0; i < array.Length; i++)
			{
				BattlePlayer battlePlayer = array[i];
				ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
				Dungeon3v3FinishFrame.ResultUnit resultUnit = new Dungeon3v3FinishFrame.ResultUnit();
				resultUnit.seat = battlePlayer.GetPlayerSeat();
				resultUnit.bind = comCommonBind;
				resultUnit.root = this._getBoardRoot(i);
				this.mResults.Add(resultUnit);
				Utility.AttachTo(comCommonBind.gameObject, this._getBoardRoot(i), false);
			}
		}

		// Token: 0x0600A048 RID: 41032 RVA: 0x00203A68 File Offset: 0x00201E68
		public BattlePlayer[] _getAllPlayerRaceEndRanks()
		{
			List<BattlePlayer> list = new List<BattlePlayer>();
			PKResult pkresult = this._getTeamRaceEndResult(BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			if (pkresult != PKResult.WIN)
			{
				if (pkresult != PKResult.LOSE)
				{
					if (pkresult == PKResult.DRAW)
					{
						BattlePlayer[] array = this._getRaceEndTeamResultsInCacheList(BattlePlayer.eDungeonPlayerTeamType.eTeamRed).ToArray();
						BattlePlayer[] array2 = this._getRaceEndTeamResultsInCacheList(BattlePlayer.eDungeonPlayerTeamType.eTeamBlue).ToArray();
						int i = 0;
						int j = 0;
						while (i < array.Length)
						{
							array[i].SetPKResultRank(i + 1);
							list.Add(array[i++]);
						}
						while (j < array2.Length)
						{
							array2[j].SetPKResultRank(j + 1);
							list.Add(array2[j++]);
						}
					}
				}
				else
				{
					this._getRaceEndRank(list, BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
					this._getRaceEndRank(list, BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
				}
			}
			else
			{
				this._getRaceEndRank(list, BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
				this._getRaceEndRank(list, BattlePlayer.eDungeonPlayerTeamType.eTeamBlue);
			}
			return list.ToArray();
		}

		// Token: 0x0600A049 RID: 41033 RVA: 0x00203B4C File Offset: 0x00201F4C
		private bool _getRaceEndRank(List<BattlePlayer> list, BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (list == null)
			{
				return false;
			}
			int count = list.Count;
			List<BattlePlayer> list2 = this._getRaceEndTeamResultsInCacheList(type);
			for (int i = 0; i < list2.Count; i++)
			{
				list.Add(list2[i]);
				list2[i].SetPKResultRank(count + i + 1);
			}
			return true;
		}

		// Token: 0x0600A04A RID: 41034 RVA: 0x00203BA8 File Offset: 0x00201FA8
		private GameObject _getBoardRoot(int idx)
		{
			switch (idx)
			{
			case 0:
				return this.mSeat0;
			case 1:
				return this.mSeat1;
			case 2:
				return this.mSeat2;
			case 3:
				return this.mSeat3;
			case 4:
				return this.mSeat4;
			case 5:
				return this.mSeat5;
			default:
				return null;
			}
		}

		// Token: 0x0600A04B RID: 41035 RVA: 0x00203C04 File Offset: 0x00202004
		private void _initAllPlayersFromBattleInfo()
		{
			for (int i = 0; i < this.mResults.Count; i++)
			{
				this._initOnePlayerInfoFromBattleInfo(this.mResults[i]);
			}
		}

		// Token: 0x0600A04C RID: 41036 RVA: 0x00203C40 File Offset: 0x00202040
		private bool _initOnePlayerInfoFromBattleInfo(Dungeon3v3FinishFrame.ResultUnit resultUnit)
		{
			if (resultUnit == null)
			{
				return false;
			}
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(resultUnit.seat);
			ComCommonBind bind = resultUnit.bind;
			if (!BattlePlayer.IsDataValidBattlePlayer(playerBySeat))
			{
				return false;
			}
			if (null == bind)
			{
				return false;
			}
			GameObject gameObject = bind.GetGameObject("selectObject");
			Text com = bind.GetCom<Text>("killNumber");
			Text com2 = bind.GetCom<Text>("glory");
			Text com3 = bind.GetCom<Text>("playerName");
			Image com4 = bind.GetCom<Image>("playerIcon");
			Image com5 = bind.GetCom<Image>("teamFlag");
			Image com6 = bind.GetCom<Image>("rankNumber");
			Image com7 = bind.GetCom<Image>("playerResulte");
			if (null != resultUnit.root)
			{
				DOTweenAnimation component = resultUnit.root.GetComponent<DOTweenAnimation>();
				if (null != component)
				{
					component.DOPlay();
				}
			}
			this.mBind.GetSprite(this._getTeamFlagTag(playerBySeat.teamType), ref com5);
			this.mBind.GetSprite(this._getTeamRankTag(playerBySeat.GetPKResultRank()), ref com6);
			string text = this._getTeamIconPath(playerBySeat);
			if (!string.IsNullOrEmpty(text) && "-" != text)
			{
				ETCImageLoader.LoadSprite(ref com4, text, true);
			}
			com7.gameObject.CustomActive(BattleMain.instance.GetPlayerManager().IsKillEnemyMatchPlayer(playerBySeat.GetPlayerSeat()));
			gameObject.CustomActive(playerBySeat.IsLocalPlayer());
			bind.transform.localScale = ((!playerBySeat.IsLocalPlayer()) ? Vector3.one : (Vector3.one * 1.03f));
			com3.text = playerBySeat.GetPlayerName();
			com.text = playerBySeat.GetKillMatchPlayerCount().ToString();
			if (com2 != null)
			{
				com2.text = "+" + playerBySeat.GetRaceEndResultAddGlory().ToString();
			}
			this._updateOnePlayerSeasonInfo(bind, playerBySeat.playerInfo.seasonLevel, playerBySeat);
			return true;
		}

		// Token: 0x0600A04D RID: 41037 RVA: 0x00203E54 File Offset: 0x00202254
		private string _getTeamIconPath(BattlePlayer player)
		{
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return string.Empty;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)player.playerInfo.occupation, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.PKMatchResultHeadIconPath;
			}
			return string.Empty;
		}

		// Token: 0x0600A04E RID: 41038 RVA: 0x00203EA4 File Offset: 0x002022A4
		private string _getTeamRankTag(int rank)
		{
			return string.Format("n{0}", rank);
		}

		// Token: 0x0600A04F RID: 41039 RVA: 0x00203EB6 File Offset: 0x002022B6
		private string _getTeamFlagTag(BattlePlayer.eDungeonPlayerTeamType type)
		{
			if (type == BattlePlayer.eDungeonPlayerTeamType.eTeamRed)
			{
				return "redTeamBoard";
			}
			if (type != BattlePlayer.eDungeonPlayerTeamType.eTeamBlue)
			{
				return "redTeamBoard";
			}
			return "blueTeamBoard";
		}

		// Token: 0x0600A050 RID: 41040 RVA: 0x00203EDC File Offset: 0x002022DC
		private bool _updateOnePlayerSeasonInfo(ComCommonBind bind, uint seasonLevel, BattlePlayer player)
		{
			if (null == bind)
			{
				return false;
			}
			byte playerSeat = player.GetPlayerSeat();
			Text com = bind.GetCom<Text>("rankLevelNum");
			Image com2 = bind.GetCom<Image>("rankLevelIcon");
			Image com3 = bind.GetCom<Image>("rankIconNumber");
			Text com4 = bind.GetCom<Text>("baseScoreNumber");
			Text com5 = bind.GetCom<Text>("contributeNumber");
			GameObject gameObject = bind.GetGameObject("rankLevelRoot");
			GameObject gameObject2 = bind.GetGameObject("waitScoreRoot");
			Text com6 = bind.GetCom<Text>("glory");
			bool flag = !this._is3v3Score();
			gameObject.CustomActive(flag);
			com4.CustomActive(!flag);
			com5.CustomActive(!flag);
			if (null != com6)
			{
				com6.CustomActive(!flag);
			}
			if (this._is2v2ScuffleScore())
			{
				gameObject.CustomActive(false);
				com5.CustomActive(false);
				com4.CustomActive(true);
				if (null != com6)
				{
					com6.CustomActive(true);
				}
			}
			if (!flag)
			{
				if (player.GetRaceEndResultScoreWarBaseScore() == 4294967295U || player.GetRaceEndResultScoreWarContriScore() == 4294967295U)
				{
					gameObject2.CustomActive(true);
					com4.CustomActive(false);
					com5.CustomActive(false);
					if (com6 != null)
					{
						com6.CustomActive(false);
					}
				}
				else
				{
					gameObject2.CustomActive(false);
					com4.text = player.GetRaceEndResultScoreWarBaseScore().ToString();
					com5.text = player.GetRaceEndResultScoreWarContriScore().ToString();
				}
			}
			if (this._is2v2ScuffleScore())
			{
				int num = 0;
				PKResult pkresult = this._getTeamRaceEndResult(player.teamType);
				if (pkresult == PKResult.WIN)
				{
					num = Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_2V2_SCORE_WAR_WIN_SCORE, 0);
				}
				else if (pkresult == PKResult.LOSE)
				{
					num = Utility.GetSystemValueFromTable(SystemValueTable.eType3.SVT_2V2_SCORE_WAR_LOSE_SCORE, 0);
				}
				com4.text = "+" + num.ToString();
			}
			if ((this._is2v2ScuffleScore() || this._is3v3Score()) && com6 != null)
			{
				PKResult result = this._getTeamRaceEndResult(player.teamType);
				com6.text = "+" + this._getGloryCount(result);
			}
			com.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)seasonLevel, true);
			string path = DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon((int)seasonLevel);
			ETCImageLoader.LoadSprite(ref com2, path, true);
			path = DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon((int)seasonLevel);
			ETCImageLoader.LoadSprite(ref com3, path, true);
			com3.SetNativeSize();
			return true;
		}

		// Token: 0x0600A051 RID: 41041 RVA: 0x00204172 File Offset: 0x00202572
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A052 RID: 41042 RVA: 0x00204178 File Offset: 0x00202578
		private void _initFrameState()
		{
			this.mTickTime = 5f;
			this.mState = Dungeon3v3FinishFrame.eState.eShowResult;
			this.mCloseButton.enabled = false;
			this.mTipsCanvasGroup.alpha = 0f;
			this.mSceneRoomMatchPkRaceEnd = null;
			try
			{
				this.mCurrentRoomType = (RoomType)DataManager<Pk3v3DataManager>.GetInstance().GetRoomInfo().roomSimpleInfo.roomType;
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x0600A053 RID: 41043 RVA: 0x002041F0 File Offset: 0x002025F0
		private bool _is3v3Score()
		{
			return DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.ScoreWar;
		}

		// Token: 0x0600A054 RID: 41044 RVA: 0x002041FF File Offset: 0x002025FF
		private bool _is3v3Scuffle()
		{
			return DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_3V3_Melee;
		}

		// Token: 0x0600A055 RID: 41045 RVA: 0x0020420E File Offset: 0x0020260E
		private bool _is2v2ScuffleScore()
		{
			return DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_2V2_Melee;
		}

		// Token: 0x0600A056 RID: 41046 RVA: 0x0020421E File Offset: 0x0020261E
		private void _clearFrameState()
		{
			this.mState = Dungeon3v3FinishFrame.eState.eNone;
		}

		// Token: 0x0600A057 RID: 41047 RVA: 0x00204228 File Offset: 0x00202628
		protected override void _OnUpdate(float delta)
		{
			Dungeon3v3FinishFrame.eState eState = this.mState;
			if (eState != Dungeon3v3FinishFrame.eState.eShowResult)
			{
				if (eState != Dungeon3v3FinishFrame.eState.eWaitClose)
				{
					if (eState != Dungeon3v3FinishFrame.eState.eClose)
					{
					}
				}
				else if (this._isTickTimeEnd(delta))
				{
					this.mState = Dungeon3v3FinishFrame.eState.eClose;
					this._onAutoClose();
				}
			}
			else if (this._isTickTimeEnd(delta))
			{
				this.mTickTime = 10f;
				this.mState = Dungeon3v3FinishFrame.eState.eWaitClose;
				this.mCloseButton.enabled = true;
				TweenSettingsExtensions.SetEase<TweenerCore<float, float, FloatOptions>>(DOTween.To(() => 0f, delegate(float x)
				{
					if (null != this.mTipsCanvasGroup)
					{
						this.mTipsCanvasGroup.alpha = x;
					}
				}, 1f, 2f), 5);
				this.mCount2Close.StartCount(null, 10);
			}
		}

		// Token: 0x0600A058 RID: 41048 RVA: 0x002042FA File Offset: 0x002026FA
		private bool _isTickTimeEnd(float delta)
		{
			this.mTickTime -= delta;
			return this.mTickTime <= 0f;
		}

		// Token: 0x0600A059 RID: 41049 RVA: 0x0020431C File Offset: 0x0020271C
		private int _getGloryCount(PKResult result)
		{
			int result2 = 0;
			HonorRewardTable honorRewardTable = this._getHonorRewardTable();
			if (honorRewardTable != null)
			{
				if (result == PKResult.WIN)
				{
					result2 = honorRewardTable.VictoryReward;
				}
				else if (result == PKResult.LOSE)
				{
					result2 = honorRewardTable.LostReward;
				}
				else if (result == PKResult.DRAW)
				{
					result2 = honorRewardTable.LostReward;
				}
			}
			return result2;
		}

		// Token: 0x0600A05A RID: 41050 RVA: 0x00204370 File Offset: 0x00202770
		private HonorRewardTable _getHonorRewardTable()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<HonorRewardTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				HonorRewardTable honorRewardTable = keyValuePair.Value as HonorRewardTable;
				if (this._is2v2ScuffleScore() && honorRewardTable.PvpType == 15)
				{
					return honorRewardTable;
				}
				if (this._is3v3Score() && honorRewardTable.PvpType == 9)
				{
					return honorRewardTable;
				}
			}
			return null;
		}

		// Token: 0x040058F5 RID: 22773
		private List<Dungeon3v3FinishFrame.ResultUnit> mResults = new List<Dungeon3v3FinishFrame.ResultUnit>();

		// Token: 0x040058F6 RID: 22774
		private Dungeon3v3FinishFrame.eState mState;

		// Token: 0x040058F7 RID: 22775
		private const float kShowResultTime = 5f;

		// Token: 0x040058F8 RID: 22776
		private const float kWaitCloseTime = 10f;

		// Token: 0x040058F9 RID: 22777
		private float mTickTime;

		// Token: 0x040058FA RID: 22778
		private RoomType mCurrentRoomType;

		// Token: 0x040058FB RID: 22779
		private SceneRoomMatchPkRaceEnd mSceneRoomMatchPkRaceEnd;

		// Token: 0x040058FC RID: 22780
		private Text mBestPlayerName;

		// Token: 0x040058FD RID: 22781
		private GameObject mBestPlayerIcon;

		// Token: 0x040058FE RID: 22782
		private CanvasGroup mTipsCanvasGroup;

		// Token: 0x040058FF RID: 22783
		private ComCountScript mCount2Close;

		// Token: 0x04005900 RID: 22784
		private GameObject mSeat0;

		// Token: 0x04005901 RID: 22785
		private GameObject mSeat1;

		// Token: 0x04005902 RID: 22786
		private GameObject mSeat2;

		// Token: 0x04005903 RID: 22787
		private GameObject mSeat3;

		// Token: 0x04005904 RID: 22788
		private GameObject mSeat4;

		// Token: 0x04005905 RID: 22789
		private GameObject mSeat5;

		// Token: 0x04005906 RID: 22790
		private Image mResult;

		// Token: 0x04005907 RID: 22791
		private GameObject mRankTitle;

		// Token: 0x04005908 RID: 22792
		private GameObject mBaseScoreTitle;

		// Token: 0x04005909 RID: 22793
		private GameObject mContributeTitle;

		// Token: 0x0400590A RID: 22794
		private GameObject scoreTitle;

		// Token: 0x0400590B RID: 22795
		private GameObject mGloryTitle;

		// Token: 0x0400590C RID: 22796
		private Button mCloseButton;

		// Token: 0x0200109D RID: 4253
		private class ResultUnit
		{
			// Token: 0x0400590E RID: 22798
			public byte seat = byte.MaxValue;

			// Token: 0x0400590F RID: 22799
			public ComCommonBind bind;

			// Token: 0x04005910 RID: 22800
			public GameObject root;
		}

		// Token: 0x0200109E RID: 4254
		private enum eState
		{
			// Token: 0x04005912 RID: 22802
			eNone,
			// Token: 0x04005913 RID: 22803
			eShowResult,
			// Token: 0x04005914 RID: 22804
			eWaitClose,
			// Token: 0x04005915 RID: 22805
			eClose
		}
	}
}
