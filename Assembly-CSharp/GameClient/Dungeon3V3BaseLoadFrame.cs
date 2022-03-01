using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001099 RID: 4249
	public class Dungeon3V3BaseLoadFrame : ClientFrame
	{
		// Token: 0x0600A011 RID: 40977 RVA: 0x00201A98 File Offset: 0x001FFE98
		protected override void _bindExUI()
		{
			this.mApplyBtn = this.mBind.GetCom<Button>("applyBtn");
			this.mApplyBtn.onClick.AddListener(new UnityAction(this._onApplyBtnButtonClick));
			this.mFightVS = this.mBind.GetCom<Image>("fightVS");
			this.mCountDownNum = this.mBind.GetCom<ImageNumber>("countDownNum");
			this.mCountDownRoot = this.mBind.GetGameObject("countDownRoot");
			this.mRedTeamRoot = this.mBind.GetGameObject("redTeamRoot");
			this.mCancelFightRoot = this.mBind.GetGameObject("cancelFightRoot");
			this.mJoinFightRoot = this.mBind.GetGameObject("joinFightRoot");
			this.mLeftTimeRoot = this.mBind.GetGameObject("leftTimeRoot");
			this.mSeat0 = this.mBind.GetGameObject("seat0");
			this.mSeat1 = this.mBind.GetGameObject("seat1");
			this.mSeat2 = this.mBind.GetGameObject("seat2");
			this.mSeat3 = this.mBind.GetGameObject("seat3");
			this.mSeat4 = this.mBind.GetGameObject("seat4");
			this.mSeat5 = this.mBind.GetGameObject("seat5");
			this.mFightTips = this.mBind.GetGameObject("fightTips");
			this.mCountEffect = this.mBind.GetCom<UIAudioProxy>("countEffect");
			this.mApplyLimitButton = this.mBind.GetCom<ComTimeLimitButton>("applyLimitButton");
			this.mDt03_01 = this.mBind.GetCom<DOTweenAnimation>("dt03_01");
			this.mDt03_02 = this.mBind.GetCom<DOTweenAnimation>("dt03_02");
			this.mDt03_03 = this.mBind.GetCom<DOTweenAnimation>("dt03_03");
			this.mDt03_04 = this.mBind.GetCom<DOTweenAnimation>("dt03_04");
			this.mDt03_05 = this.mBind.GetCom<DOTweenAnimation>("dt03_05");
			this.mDt02_01 = this.mBind.GetCom<DOTweenAnimation>("dt02_01");
			this.mDt02_02 = this.mBind.GetCom<DOTweenAnimation>("dt02_02");
			this.mDt02_03 = this.mBind.GetCom<DOTweenAnimation>("dt02_03");
			this.mDt02_04 = this.mBind.GetCom<DOTweenAnimation>("dt02_04");
			this.mDt02_05 = this.mBind.GetCom<DOTweenAnimation>("dt02_05");
			this.mDt01_01 = this.mBind.GetCom<DOTweenAnimation>("dt01_01");
			this.mDt01_02 = this.mBind.GetCom<DOTweenAnimation>("dt01_02");
			this.mDt01_03 = this.mBind.GetCom<DOTweenAnimation>("dt01_03");
			this.mDt01_04 = this.mBind.GetCom<DOTweenAnimation>("dt01_04");
			this.mDt01_05 = this.mBind.GetCom<DOTweenAnimation>("dt01_05");
			this.mDt06_01 = this.mBind.GetCom<DOTweenAnimation>("dt06_01");
			this.mDt06_02 = this.mBind.GetCom<DOTweenAnimation>("dt06_02");
			this.mDt06_03 = this.mBind.GetCom<DOTweenAnimation>("dt06_03");
			this.mDt06_04 = this.mBind.GetCom<DOTweenAnimation>("dt06_04");
			this.mDt06_05 = this.mBind.GetCom<DOTweenAnimation>("dt06_05");
			this.mDt05_01 = this.mBind.GetCom<DOTweenAnimation>("dt05_01");
			this.mDt05_02 = this.mBind.GetCom<DOTweenAnimation>("dt05_02");
			this.mDt05_03 = this.mBind.GetCom<DOTweenAnimation>("dt05_03");
			this.mDt05_04 = this.mBind.GetCom<DOTweenAnimation>("dt05_04");
			this.mDt05_05 = this.mBind.GetCom<DOTweenAnimation>("dt05_05");
			this.mDt04_01 = this.mBind.GetCom<DOTweenAnimation>("dt04_01");
			this.mDt04_02 = this.mBind.GetCom<DOTweenAnimation>("dt04_02");
			this.mDt04_03 = this.mBind.GetCom<DOTweenAnimation>("dt04_03");
			this.mDt04_04 = this.mBind.GetCom<DOTweenAnimation>("dt04_04");
			this.mDt04_05 = this.mBind.GetCom<DOTweenAnimation>("dt04_05");
			this.mNextRoundRoot = this.mBind.GetGameObject("nextRoundRoot");
			this.mPerpareRoot = this.mBind.GetGameObject("perpareRoot");
			this.mNextRoundImage = this.mBind.GetCom<Image>("nextRoundImage");
			this.mBlueTeamRoot = this.mBind.GetGameObject("blueTeamRoot");
			this.mPvp3v3MicRoomBtn = this.mBind.GetCom<Button>("pvp3v3MicRoomBtn");
			this.mPvp3v3MicRoomBtn.onClick.AddListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtnBg = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnBg");
			this.mPvp3v3MicRoomBtnClose = this.mBind.GetCom<Image>("pvp3v3MicRoomBtnClose");
			this.mPvp3v3PlayerBtn = this.mBind.GetCom<Button>("pvp3v3PlayerBtn");
			this.mPvp3v3PlayerBtn.onClick.AddListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtnBg = this.mBind.GetCom<Image>("pvp3v3PlayerBtnBg");
			this.mPvp3v3PlayerBtnClose = this.mBind.GetCom<Image>("pvp3v3PlayerBtnClose");
		}

		// Token: 0x0600A012 RID: 40978 RVA: 0x00201FE0 File Offset: 0x002003E0
		protected override void _unbindExUI()
		{
			this.mApplyBtn.onClick.RemoveListener(new UnityAction(this._onApplyBtnButtonClick));
			this.mApplyBtn = null;
			this.mFightVS = null;
			this.mCountDownNum = null;
			this.mCountDownRoot = null;
			this.mRedTeamRoot = null;
			this.mCancelFightRoot = null;
			this.mJoinFightRoot = null;
			this.mLeftTimeRoot = null;
			this.mSeat0 = null;
			this.mSeat1 = null;
			this.mSeat2 = null;
			this.mSeat3 = null;
			this.mSeat4 = null;
			this.mSeat5 = null;
			this.mFightTips = null;
			this.mCountEffect = null;
			this.mApplyLimitButton = null;
			this.mDt03_01 = null;
			this.mDt03_02 = null;
			this.mDt03_03 = null;
			this.mDt03_04 = null;
			this.mDt03_05 = null;
			this.mDt02_01 = null;
			this.mDt02_02 = null;
			this.mDt02_03 = null;
			this.mDt02_04 = null;
			this.mDt02_05 = null;
			this.mDt01_01 = null;
			this.mDt01_02 = null;
			this.mDt01_03 = null;
			this.mDt01_04 = null;
			this.mDt01_05 = null;
			this.mDt06_01 = null;
			this.mDt06_02 = null;
			this.mDt06_03 = null;
			this.mDt06_04 = null;
			this.mDt06_05 = null;
			this.mDt05_01 = null;
			this.mDt05_02 = null;
			this.mDt05_03 = null;
			this.mDt05_04 = null;
			this.mDt05_05 = null;
			this.mDt04_01 = null;
			this.mDt04_02 = null;
			this.mDt04_03 = null;
			this.mDt04_04 = null;
			this.mDt04_05 = null;
			this.mNextRoundRoot = null;
			this.mPerpareRoot = null;
			this.mNextRoundImage = null;
			this.mBlueTeamRoot = null;
			this.mPvp3v3MicRoomBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3MicRoomBtnButtonClick));
			this.mPvp3v3MicRoomBtn = null;
			this.mPvp3v3MicRoomBtnBg = null;
			this.mPvp3v3MicRoomBtnClose = null;
			this.mPvp3v3PlayerBtn.onClick.RemoveListener(new UnityAction(this._onPvp3v3PlayerBtnButtonClick));
			this.mPvp3v3PlayerBtn = null;
			this.mPvp3v3PlayerBtnBg = null;
			this.mPvp3v3PlayerBtnClose = null;
		}

		// Token: 0x0600A013 RID: 40979 RVA: 0x002021D0 File Offset: 0x002005D0
		private void _onApplyBtnButtonClick()
		{
			this._onApplyBtnButtonClickEvent();
		}

		// Token: 0x0600A014 RID: 40980 RVA: 0x002021D8 File Offset: 0x002005D8
		private void _onPvp3v3MicRoomBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsRecordVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_record_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVoiceMic();
		}

		// Token: 0x0600A015 RID: 40981 RVA: 0x00202204 File Offset: 0x00200604
		private void _onPvp3v3PlayerBtnButtonClick()
		{
			if (!Singleton<SDKVoiceManager>.GetInstance().IsPlayVoiceEnabled)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("voice_sdk_play_not_enabled"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			Singleton<SDKVoiceManager>.GetInstance().ControlRealVociePlayer();
		}

		// Token: 0x0600A016 RID: 40982 RVA: 0x00202230 File Offset: 0x00200630
		protected virtual void _onApplyBtnButtonClickEvent()
		{
		}

		// Token: 0x0600A017 RID: 40983 RVA: 0x00202234 File Offset: 0x00200634
		protected float _playProcessAnimateByType(Dungeon3V3BaseLoadFrame.eAnimateType type, byte seat)
		{
			float result = 0f;
			this._killAll((int)seat);
			if (type != Dungeon3V3BaseLoadFrame.eAnimateType.eIn)
			{
				if (type != Dungeon3V3BaseLoadFrame.eAnimateType.eOut)
				{
					if (type == Dungeon3V3BaseLoadFrame.eAnimateType.eSelected)
					{
						this._playAnimation(this._findPlayerIndexBySeat(seat), 1);
						this._playAnimation(this._findPlayerIndexBySeat(seat), 2);
					}
				}
				else
				{
					this._playAnimation(this._findPlayerIndexBySeat(seat), 3);
					this._playAnimation(this._findPlayerIndexBySeat(seat), 4);
				}
			}
			return result;
		}

		// Token: 0x0600A018 RID: 40984 RVA: 0x002022B3 File Offset: 0x002006B3
		private void _killAll(int seat)
		{
			if (seat < 0 || seat >= this.mBoards.Length)
			{
				return;
			}
			if (this.mBoards[seat] == null || null == this.mBoards[seat].root)
			{
				return;
			}
		}

		// Token: 0x0600A019 RID: 40985 RVA: 0x002022F4 File Offset: 0x002006F4
		private float _playAnimation(int fst, int snd)
		{
			if (fst < 0 || fst >= this.mAllTypeAnimation.Count)
			{
				return 0f;
			}
			List<DOTweenAnimation> list = this.mAllTypeAnimation[fst];
			if (list == null)
			{
				return 0f;
			}
			if (snd < 0 || snd >= list.Count)
			{
				return 0f;
			}
			DOTweenAnimation dotweenAnimation = list[snd];
			if (null == dotweenAnimation)
			{
				return 0f;
			}
			TweenExtensions.Rewind(dotweenAnimation.tween, true);
			TweenExtensions.Kill(dotweenAnimation.tween, false);
			if (dotweenAnimation.isValid)
			{
				dotweenAnimation.CreateTween();
				TweenExtensions.Play<Tween>(dotweenAnimation.tween);
			}
			if (dotweenAnimation.loops < 0)
			{
				return -1f;
			}
			return dotweenAnimation.delay + dotweenAnimation.duration * (float)dotweenAnimation.loops;
		}

		// Token: 0x0600A01A RID: 40986 RVA: 0x002023C8 File Offset: 0x002007C8
		protected Dungeon3V3BaseLoadFrame.MatchUnit _findBoardBySeat(byte seat)
		{
			int num = this._findPlayerIndexBySeat(seat);
			if (num < 0 || num >= this.mBoards.Length)
			{
				return null;
			}
			return this.mBoards[num];
		}

		// Token: 0x0600A01B RID: 40987 RVA: 0x002023FC File Offset: 0x002007FC
		protected int _findPlayerIndexBySeat(byte seat)
		{
			for (int i = 0; i < this.mBoards.Length; i++)
			{
				if (this.mBoards[i].playerSeat == seat)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600A01C RID: 40988 RVA: 0x00202438 File Offset: 0x00200838
		protected void _initBoards()
		{
			this._initBoardsArray();
			this._initDTAnimateArray();
			string prefabPath = this.mBind.GetPrefabPath("blueboardUnit");
			string prefabPath2 = this.mBind.GetPrefabPath("redboardUnit");
			this.mBind.ClearCacheBinds(prefabPath);
			this.mBind.ClearCacheBinds(prefabPath2);
			for (int i = 0; i < 6; i++)
			{
				if (i < 3)
				{
					this.mBoards[i].board = this.mBind.LoadExtraBind(prefabPath2);
				}
				else
				{
					this.mBoards[i].board = this.mBind.LoadExtraBind(prefabPath);
				}
				ComCommonBind board = this.mBoards[i].board;
				Color color;
				color..ctor(1f, 1f, 1f, this.mBoardsAlpha[i % this.mBoardsAlpha.Length]);
				Image com = board.GetCom<Image>("top");
				Image com2 = board.GetCom<Image>("bottom");
				if (null != com)
				{
					com.color *= color;
				}
				if (null != com2)
				{
					com2.color *= color;
				}
				if (null == board)
				{
					return;
				}
				Utility.AttachTo(board.gameObject, this.mBoards[i].root, false);
			}
		}

		// Token: 0x0600A01D RID: 40989 RVA: 0x00202594 File Offset: 0x00200994
		private void _initDTAnimateArray()
		{
			this.mAllTypeAnimation.Clear();
			for (int i = 0; i < 6; i++)
			{
				List<DOTweenAnimation> item = new List<DOTweenAnimation>();
				this.mAllTypeAnimation.Add(item);
			}
			this.mAllTypeAnimation[0].Clear();
			this.mAllTypeAnimation[0].Add(this.mDt01_01);
			this.mAllTypeAnimation[0].Add(this.mDt01_02);
			this.mAllTypeAnimation[0].Add(this.mDt01_03);
			this.mAllTypeAnimation[0].Add(this.mDt01_04);
			this.mAllTypeAnimation[0].Add(this.mDt01_05);
			this.mAllTypeAnimation[1].Clear();
			this.mAllTypeAnimation[1].Add(this.mDt02_01);
			this.mAllTypeAnimation[1].Add(this.mDt02_02);
			this.mAllTypeAnimation[1].Add(this.mDt02_03);
			this.mAllTypeAnimation[1].Add(this.mDt02_04);
			this.mAllTypeAnimation[1].Add(this.mDt02_05);
			this.mAllTypeAnimation[2].Clear();
			this.mAllTypeAnimation[2].Add(this.mDt03_01);
			this.mAllTypeAnimation[2].Add(this.mDt03_02);
			this.mAllTypeAnimation[2].Add(this.mDt03_03);
			this.mAllTypeAnimation[2].Add(this.mDt03_04);
			this.mAllTypeAnimation[2].Add(this.mDt03_05);
			this.mAllTypeAnimation[3].Clear();
			this.mAllTypeAnimation[3].Add(this.mDt04_01);
			this.mAllTypeAnimation[3].Add(this.mDt04_02);
			this.mAllTypeAnimation[3].Add(this.mDt04_03);
			this.mAllTypeAnimation[3].Add(this.mDt04_04);
			this.mAllTypeAnimation[3].Add(this.mDt04_05);
			this.mAllTypeAnimation[4].Clear();
			this.mAllTypeAnimation[4].Add(this.mDt05_01);
			this.mAllTypeAnimation[4].Add(this.mDt05_02);
			this.mAllTypeAnimation[4].Add(this.mDt05_03);
			this.mAllTypeAnimation[4].Add(this.mDt05_04);
			this.mAllTypeAnimation[4].Add(this.mDt05_05);
			this.mAllTypeAnimation[5].Clear();
			this.mAllTypeAnimation[5].Add(this.mDt06_01);
			this.mAllTypeAnimation[5].Add(this.mDt06_02);
			this.mAllTypeAnimation[5].Add(this.mDt06_03);
			this.mAllTypeAnimation[5].Add(this.mDt06_04);
			this.mAllTypeAnimation[5].Add(this.mDt06_05);
		}

		// Token: 0x0600A01E RID: 40990 RVA: 0x002028E8 File Offset: 0x00200CE8
		private void _initBoardsArray()
		{
			for (int i = 0; i < 6; i++)
			{
				this.mBoards[i] = new Dungeon3V3BaseLoadFrame.MatchUnit();
			}
			this.mBoards[0].root = this.mSeat0;
			this.mBoards[1].root = this.mSeat1;
			this.mBoards[2].root = this.mSeat2;
			this.mBoards[3].root = this.mSeat3;
			this.mBoards[4].root = this.mSeat4;
			this.mBoards[5].root = this.mSeat5;
			for (int j = 0; j < 6; j++)
			{
				this.mBoards[j].root.CustomActive(false);
			}
		}

		// Token: 0x0600A01F RID: 40991 RVA: 0x002029AC File Offset: 0x00200DAC
		protected void _uninitBoards()
		{
			for (int i = 0; i < this.mBoards.Length; i++)
			{
				if (this.mBoards[i] != null)
				{
					this.mBoards[i].Clear();
				}
			}
			this.mAllTypeAnimation.Clear();
		}

		// Token: 0x0600A020 RID: 40992 RVA: 0x002029F8 File Offset: 0x00200DF8
		protected void _initPlayers()
		{
			string prefabPath = this.mBind.GetPrefabPath("blueUnit");
			string prefabPath2 = this.mBind.GetPrefabPath("redUnit");
			this.mBind.ClearCacheBinds(prefabPath);
			this.mBind.ClearCacheBinds(prefabPath2);
			this._initBlueRedTeamIndex();
			this._initPlayersSeat();
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				this._initOnePlayer(allPlayers[i]);
			}
		}

		// Token: 0x0600A021 RID: 40993 RVA: 0x00202A80 File Offset: 0x00200E80
		private void _initPlayersSeat()
		{
			List<BattlePlayer> allPlayers = BattleMain.instance.GetPlayerManager().GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				int num = this._generatePlayerIndex(allPlayers[i]);
				if (num >= 0 && num < 6)
				{
					this.mBoards[num].playerSeat = allPlayers[i].GetPlayerSeat();
				}
				else
				{
					Logger.LogErrorFormat("[3v3] {0} 座位号索引超过范围", new object[]
					{
						num
					});
				}
			}
		}

		// Token: 0x0600A022 RID: 40994 RVA: 0x00202B07 File Offset: 0x00200F07
		private void _initBlueRedTeamIndex()
		{
			this.mRedTeamIndex = 0;
			this.mBlueTeamIndex = 3;
		}

		// Token: 0x0600A023 RID: 40995 RVA: 0x00202B18 File Offset: 0x00200F18
		private int _generatePlayerIndex(BattlePlayer player)
		{
			if (!BattlePlayer.IsDataValidBattlePlayer(player))
			{
				return -1;
			}
			if (player.IsTeamRed())
			{
				return this.mRedTeamIndex++;
			}
			return this.mBlueTeamIndex++;
		}

		// Token: 0x0600A024 RID: 40996 RVA: 0x00202B60 File Offset: 0x00200F60
		private void _initOnePlayer(BattlePlayer player)
		{
			string prefabPath = this.mBind.GetPrefabPath("blueUnit");
			string prefabPath2 = this.mBind.GetPrefabPath("redUnit");
			string path = (!player.IsTeamRed()) ? prefabPath : prefabPath2;
			Dungeon3V3BaseLoadFrame.MatchUnit matchUnit = this._findBoardBySeat(player.playerInfo.seat);
			if (matchUnit == null)
			{
				return;
			}
			ComCommonBind board = matchUnit.board;
			ComCommonBind comCommonBind = this.mBind.LoadExtraBind(path);
			if (null == comCommonBind)
			{
				return;
			}
			GameObject gameObject = board.GetGameObject("unitRoot");
			matchUnit.root.CustomActive(true);
			matchUnit.unit = comCommonBind;
			Utility.AttachTo(comCommonBind.gameObject, gameObject, false);
			ComDungeonPlayerLoadProgress com = comCommonBind.GetCom<ComDungeonPlayerLoadProgress>("matchPlayerLoading");
			GameObject gameObject2 = comCommonBind.GetGameObject("charactorRoot");
			Image com2 = board.GetCom<Image>("num");
			if (null != com2 && null != com2.transform.parent)
			{
				com2.transform.parent.SetAsLastSibling();
			}
			this.mBind.GetSprite(string.Format("num{0}", this._findPlayerIndexBySeat(matchUnit.playerSeat) % 3), ref com2);
			com.SetSeat(player.playerInfo.seat);
			this._loadCharactorMatchPrefab(player, gameObject2);
		}

		// Token: 0x0600A025 RID: 40997 RVA: 0x00202CB8 File Offset: 0x002010B8
		private bool _loadCharactorMatchPrefab(BattlePlayer player, GameObject parent)
		{
			if (!this._checkBattlePlayerIsValid(player))
			{
				return false;
			}
			int occupation = (int)player.playerInfo.occupation;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(occupation, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem.PKMatchShowPrefab, true, 0U);
			if (null == gameObject)
			{
				return false;
			}
			Utility.AttachTo(gameObject, parent, false);
			ComPK3V3LoadingCharactorPosition componentInChildren = gameObject.GetComponentInChildren<ComPK3V3LoadingCharactorPosition>();
			if (null == componentInChildren)
			{
				return false;
			}
			componentInChildren.SetTeamType(player.teamType);
			return true;
		}

		// Token: 0x0600A026 RID: 40998 RVA: 0x00202D48 File Offset: 0x00201148
		protected bool _checkBattlePlayerIsValid(BattlePlayer player)
		{
			return BattlePlayer.IsDataValidBattlePlayer(player) && null != this._findBoardBySeat(player.playerInfo.seat);
		}

		// Token: 0x040058AE RID: 22702
		protected const int kMaxPlayerSeatCount = 6;

		// Token: 0x040058AF RID: 22703
		protected Dungeon3V3BaseLoadFrame.MatchUnit[] mBoards = new Dungeon3V3BaseLoadFrame.MatchUnit[6];

		// Token: 0x040058B0 RID: 22704
		private float[] mBoardsAlpha = new float[]
		{
			0.88f,
			0.6f,
			0.3f
		};

		// Token: 0x040058B1 RID: 22705
		protected List<List<DOTweenAnimation>> mAllTypeAnimation = new List<List<DOTweenAnimation>>();

		// Token: 0x040058B2 RID: 22706
		protected Button mApplyBtn;

		// Token: 0x040058B3 RID: 22707
		protected Image mFightVS;

		// Token: 0x040058B4 RID: 22708
		protected ImageNumber mCountDownNum;

		// Token: 0x040058B5 RID: 22709
		protected GameObject mCountDownRoot;

		// Token: 0x040058B6 RID: 22710
		protected GameObject mRedTeamRoot;

		// Token: 0x040058B7 RID: 22711
		protected GameObject mCancelFightRoot;

		// Token: 0x040058B8 RID: 22712
		protected GameObject mJoinFightRoot;

		// Token: 0x040058B9 RID: 22713
		protected GameObject mLeftTimeRoot;

		// Token: 0x040058BA RID: 22714
		protected GameObject mSeat0;

		// Token: 0x040058BB RID: 22715
		protected GameObject mSeat1;

		// Token: 0x040058BC RID: 22716
		protected GameObject mSeat2;

		// Token: 0x040058BD RID: 22717
		protected GameObject mSeat3;

		// Token: 0x040058BE RID: 22718
		protected GameObject mSeat4;

		// Token: 0x040058BF RID: 22719
		protected GameObject mSeat5;

		// Token: 0x040058C0 RID: 22720
		protected GameObject mFightTips;

		// Token: 0x040058C1 RID: 22721
		protected UIAudioProxy mCountEffect;

		// Token: 0x040058C2 RID: 22722
		protected ComTimeLimitButton mApplyLimitButton;

		// Token: 0x040058C3 RID: 22723
		protected DOTweenAnimation mDt03_01;

		// Token: 0x040058C4 RID: 22724
		protected DOTweenAnimation mDt03_02;

		// Token: 0x040058C5 RID: 22725
		protected DOTweenAnimation mDt03_03;

		// Token: 0x040058C6 RID: 22726
		protected DOTweenAnimation mDt03_04;

		// Token: 0x040058C7 RID: 22727
		protected DOTweenAnimation mDt03_05;

		// Token: 0x040058C8 RID: 22728
		protected DOTweenAnimation mDt02_01;

		// Token: 0x040058C9 RID: 22729
		protected DOTweenAnimation mDt02_02;

		// Token: 0x040058CA RID: 22730
		protected DOTweenAnimation mDt02_03;

		// Token: 0x040058CB RID: 22731
		protected DOTweenAnimation mDt02_04;

		// Token: 0x040058CC RID: 22732
		protected DOTweenAnimation mDt02_05;

		// Token: 0x040058CD RID: 22733
		protected DOTweenAnimation mDt01_01;

		// Token: 0x040058CE RID: 22734
		protected DOTweenAnimation mDt01_02;

		// Token: 0x040058CF RID: 22735
		protected DOTweenAnimation mDt01_03;

		// Token: 0x040058D0 RID: 22736
		protected DOTweenAnimation mDt01_04;

		// Token: 0x040058D1 RID: 22737
		protected DOTweenAnimation mDt01_05;

		// Token: 0x040058D2 RID: 22738
		protected DOTweenAnimation mDt06_01;

		// Token: 0x040058D3 RID: 22739
		protected DOTweenAnimation mDt06_02;

		// Token: 0x040058D4 RID: 22740
		protected DOTweenAnimation mDt06_03;

		// Token: 0x040058D5 RID: 22741
		protected DOTweenAnimation mDt06_04;

		// Token: 0x040058D6 RID: 22742
		protected DOTweenAnimation mDt06_05;

		// Token: 0x040058D7 RID: 22743
		protected DOTweenAnimation mDt05_01;

		// Token: 0x040058D8 RID: 22744
		protected DOTweenAnimation mDt05_02;

		// Token: 0x040058D9 RID: 22745
		protected DOTweenAnimation mDt05_03;

		// Token: 0x040058DA RID: 22746
		protected DOTweenAnimation mDt05_04;

		// Token: 0x040058DB RID: 22747
		protected DOTweenAnimation mDt05_05;

		// Token: 0x040058DC RID: 22748
		protected DOTweenAnimation mDt04_01;

		// Token: 0x040058DD RID: 22749
		protected DOTweenAnimation mDt04_02;

		// Token: 0x040058DE RID: 22750
		protected DOTweenAnimation mDt04_03;

		// Token: 0x040058DF RID: 22751
		protected DOTweenAnimation mDt04_04;

		// Token: 0x040058E0 RID: 22752
		protected DOTweenAnimation mDt04_05;

		// Token: 0x040058E1 RID: 22753
		protected GameObject mNextRoundRoot;

		// Token: 0x040058E2 RID: 22754
		protected GameObject mPerpareRoot;

		// Token: 0x040058E3 RID: 22755
		protected Image mNextRoundImage;

		// Token: 0x040058E4 RID: 22756
		protected GameObject mBlueTeamRoot;

		// Token: 0x040058E5 RID: 22757
		protected Button mPvp3v3MicRoomBtn;

		// Token: 0x040058E6 RID: 22758
		protected Image mPvp3v3MicRoomBtnBg;

		// Token: 0x040058E7 RID: 22759
		protected Image mPvp3v3MicRoomBtnClose;

		// Token: 0x040058E8 RID: 22760
		protected Button mPvp3v3PlayerBtn;

		// Token: 0x040058E9 RID: 22761
		protected Image mPvp3v3PlayerBtnBg;

		// Token: 0x040058EA RID: 22762
		protected Image mPvp3v3PlayerBtnClose;

		// Token: 0x040058EB RID: 22763
		private int mRedTeamIndex;

		// Token: 0x040058EC RID: 22764
		private int mBlueTeamIndex = 3;

		// Token: 0x0200109A RID: 4250
		protected enum eAnimateType
		{
			// Token: 0x040058EE RID: 22766
			eIn,
			// Token: 0x040058EF RID: 22767
			eOut,
			// Token: 0x040058F0 RID: 22768
			eSelected
		}

		// Token: 0x0200109B RID: 4251
		protected class MatchUnit
		{
			// Token: 0x0600A028 RID: 41000 RVA: 0x00202D84 File Offset: 0x00201184
			public void Clear()
			{
				if (null != this.board)
				{
					this.board.ClearAllCacheBinds();
				}
				if (null != this.unit)
				{
					this.unit.ClearAllCacheBinds();
				}
				this.board = null;
				this.unit = null;
				this.root = null;
				this.playerSeat = byte.MaxValue;
			}

			// Token: 0x040058F1 RID: 22769
			public ComCommonBind board;

			// Token: 0x040058F2 RID: 22770
			public ComCommonBind unit;

			// Token: 0x040058F3 RID: 22771
			public GameObject root;

			// Token: 0x040058F4 RID: 22772
			public byte playerSeat = byte.MaxValue;
		}
	}
}
