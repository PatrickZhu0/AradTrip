using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045C6 RID: 17862
	public class TimeLimiteBattle : PVEBattle
	{
		// Token: 0x06019161 RID: 102753 RVA: 0x007EBB38 File Offset: 0x007E9F38
		public TimeLimiteBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06019162 RID: 102754 RVA: 0x007EBB8F File Offset: 0x007E9F8F
		public void SetDataInfo(int gameType, int limiteTime, string[] endCaptions, string[] endContents, int[] countLevel, bool isLessComparor, int tipId, int tipTimeLen)
		{
			this.m_DungeonFinishCaptions = endCaptions;
			this.m_DungeonFinishContents = endContents;
			this.m_CountLevel = countLevel;
			this.m_isLessComparor = isLessComparor;
			this.m_LimitTime = limiteTime;
			this.m_gameType = (TimeLimiteBattle.GameType)gameType;
			this.m_tipID = tipId;
			this.m_tipTimeLen = tipTimeLen;
		}

		// Token: 0x06019163 RID: 102755 RVA: 0x007EBBD0 File Offset: 0x007E9FD0
		protected override void _onPostStart()
		{
			base._onPostStart();
			Singleton<ClientSystemManager>.instance.OpenFrame<AnniversaryPVEFrame>(FrameLayer.Middle, null, string.Empty);
			if (this.mDungeonManager != null && this.mDungeonManager.GetBeScene() != null)
			{
				this.mDungeonManager.PauseFight(false, string.Empty, false);
			}
			GameObject gameObject = Singleton<ClientSystemManager>.instance.PlayUIEffect(FrameLayer.Top, "Effects/UI/Prefab/EffUI_Daojishi/Prefab/EffUI_3ZhounianDaojishi", 10f);
			Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnAnniversaryEnterGame, new UIEventParam
			{
				m_Int = (int)this.m_gameType,
				m_Int2 = this.m_LimitTime / 1000
			});
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattleDoubleBossTips, this.m_tipTimeLen, this.m_tipID, null, null);
		}

		// Token: 0x06019164 RID: 102756 RVA: 0x007EBC98 File Offset: 0x007EA098
		public override void AfterExecFrameCommand(byte seat, IFrameCommand cmd)
		{
			base.AfterExecFrameCommand(seat, cmd);
			if (this.m_isGameStart)
			{
				return;
			}
			FrameCommandID id = cmd.GetID();
			if (id == FrameCommandID.RacePause)
			{
				RacePuaseFrame racePuaseFrame = cmd as RacePuaseFrame;
				if (racePuaseFrame != null)
				{
					if (racePuaseFrame.isPauseLogic)
					{
						this.m_countTimeHandler = Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(5000, new DelayCaller.Del(this.onCountDownEnd), 0, 0, false);
					}
					else
					{
						Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnAnnviversaryGameStart, new UIEventParam
						{
							m_Int = this.m_LimitTime / 1000
						});
						this.m_gameTimer.SetCountdown(this.m_LimitTime / 1000);
						this.m_gameTimer.StartTimer();
						if (this.mDungeonPlayers != null)
						{
							List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
							for (int i = 0; i < allPlayers.Count; i++)
							{
								BeActor playerActor = allPlayers[i].playerActor;
								if (playerActor != null)
								{
									playerActor.StartInitCDForSkill(false);
								}
								if (playerActor != null && playerActor.aiManager != null)
								{
									if (base.recordServer != null && base.recordServer.IsProcessRecord())
									{
										base.recordServer.Mark(3091343169U);
									}
									if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
									{
										Singleton<RecordServer>.GetInstance().RecordStartFrame();
									}
								}
							}
						}
						this.mDungeonManager.GetBeScene().TriggerEvent(BeEventSceneType.onAnniversaryStart, null);
						Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnHidePauseButton, new UIEventParam
						{
							m_Bool = false
						});
						this.m_isGameStart = true;
					}
				}
			}
		}

		// Token: 0x06019165 RID: 102757 RVA: 0x007EBE4A File Offset: 0x007EA24A
		protected override void _onEnd()
		{
			base._onEnd();
			this.m_countTimeHandler.SetRemove(true);
			Singleton<ClientSystemManager>.instance.CloseFrame<AnniversaryPVEFrame>(null, false);
		}

		// Token: 0x06019166 RID: 102758 RVA: 0x007EBE6C File Offset: 0x007EA26C
		public override void FrameUpdate(int delta)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			BeScene beScene = this.mDungeonManager.GetBeScene();
			if (beScene == null || beScene.state == BeSceneState.onPause)
			{
				return;
			}
			if (this.m_gameTimer != null && this.m_gameTimer.IsCount())
			{
				this.m_gameTimer.UpdateTimer(delta);
				Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnAnniversaryTimeUpdate, new UIEventParam
				{
					m_Int = delta
				});
				if (this.m_gameTimer.IsTimeUp())
				{
					this._TimeUp();
				}
			}
		}

		// Token: 0x06019167 RID: 102759 RVA: 0x007EBF14 File Offset: 0x007EA314
		public void OnTriggerCount()
		{
			if (this.mDungeonManager != null && !this.mDungeonManager.IsFinishFight())
			{
				this.m_Counter++;
				Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnAnniversaryCounterChange, new UIEventParam
				{
					m_Int = this.m_Counter
				});
			}
		}

		// Token: 0x06019168 RID: 102760 RVA: 0x007EBF70 File Offset: 0x007EA370
		private void _TimeUp()
		{
			if (!this.mDungeonManager.IsFinishFight())
			{
				this._CheckGameEnd();
			}
		}

		// Token: 0x06019169 RID: 102761 RVA: 0x007EBF88 File Offset: 0x007EA388
		private void _CheckGameEnd()
		{
			DungeonScore score;
			if (this.m_gameType == TimeLimiteBattle.GameType.LiveTime)
			{
				score = this.GetTimeLenScore();
			}
			else
			{
				int level = -1;
				for (int i = 0; i < this.m_CountLevel.Length; i++)
				{
					if (this.m_isLessComparor)
					{
						if (this.m_Counter <= this.m_CountLevel[i])
						{
							level = i;
							break;
						}
					}
					else if (this.m_Counter >= this.m_CountLevel[i])
					{
						level = i;
						break;
					}
				}
				score = this._getScoreByLevel(level);
			}
			this._DoFinishFight(score);
		}

		// Token: 0x0601916A RID: 102762 RVA: 0x007EC01D File Offset: 0x007EA41D
		public void onCountDownEnd()
		{
			if (this.mDungeonManager != null)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
		}

		// Token: 0x0601916B RID: 102763 RVA: 0x007EC03C File Offset: 0x007EA43C
		protected override void _createPlayers()
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			VInt3 birthPosition = dungeonDataManager.GetBirthPosition();
			VInt3[] array = new VInt3[5];
			array[0] = birthPosition;
			int num = 1;
			for (int i = 1; i <= allPlayers.Count - 1; i++)
			{
				VInt3 vint = birthPosition;
				vint.x += BeAIManager.DIR_VALUE2[i - 1, 0] * VInt.one.i;
				vint.y += BeAIManager.DIR_VALUE2[i - 1, 1] * VInt.one.i;
				if (!beScene.IsInBlockPlayer(vint))
				{
					array[num++] = vint;
				}
			}
			for (int j = num; j <= allPlayers.Count - 1; j++)
			{
				array[j] = birthPosition;
			}
			for (int k = 0; k < allPlayers.Count; k++)
			{
				BattlePlayer battlePlayer = allPlayers[k];
				if (battlePlayer.playerActor == null)
				{
					RacePlayerInfo playerInfo = battlePlayer.playerInfo;
					PetData petData = BattlePlayer.GetPetData(playerInfo, false);
					bool isLocalActor = playerInfo.accid == ClientApplication.playerinfo.accid;
					bool isShowWeapon = playerInfo.avatar.isShoWeapon == 1;
					bool isAIRobot = playerInfo.robotAIType > 0;
					BeActor beActor = beScene.CreateCharacter(isLocalActor, (int)playerInfo.occupation, (int)playerInfo.level, 0, BattlePlayer.GetSkillInfo(playerInfo), BattlePlayer.GetEquips(playerInfo, false), BattlePlayer.GetBuffList(playerInfo), (int)playerInfo.seat, playerInfo.name, BattlePlayer.GetWeaponStrengthenLevel(playerInfo), BattlePlayer.GetRankBuff(playerInfo), petData, BattlePlayer.GetSideEquips(playerInfo, false), BattlePlayer.GetAvatar(playerInfo), isShowWeapon, isAIRobot);
					beActor.InitChangeEquipData(playerInfo.equips, playerInfo.equipScheme);
					beActor.SetScale(VInt.Float2VIntValue(Global.Settings.charScale));
					if (beActor.GetEntityData() != null)
					{
						beActor.GetEntityData().SetCrystalNum(BattlePlayer.GetCrsytalNum(playerInfo));
					}
					battlePlayer.playerActor = beActor;
					beActor.skillSlotMap = BattlePlayer.GetSkillSlotMap(playerInfo);
					beActor.SetPosition(dungeonDataManager.GetBirthPosition(), true, true, false);
					beActor.isMainActor = true;
					beActor.UseProtect();
					beActor.m_iRemoveTime = int.MaxValue;
					if (beActor.m_pkGeActor != null)
					{
						beActor.m_pkGeActor.AddSimpleShadow(Vector3.one);
					}
					if (playerInfo.accid == ClientApplication.playerinfo.accid)
					{
						beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.TOWN_PLAYER, playerInfo.level, null, 0f);
					}
					else
					{
						beActor.m_pkGeActor.CreateInfoBar(playerInfo.name, PlayerInfoColor.LEVEL_PLAYER, playerInfo.level, null, 0f);
					}
					beActor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(playerInfo), playerInfo.name, 0, string.Empty, (int)playerInfo.level, (int)playerInfo.seasonLevel, PlayerInfoColor.LEVEL_PLAYER, string.Empty, null, 0, 0);
					if (playerInfo.accid == ClientApplication.playerinfo.accid)
					{
						this.mDungeonManager.GetGeScene().AttachCameraTo(beActor.m_pkGeActor);
						beActor.isLocalActor = true;
						beActor.UseActorData();
						beActor.m_pkGeActor.CreateFootIndicator("Effects/Common/Sfx/Jiaodi/Prefab/Eff_jiaodidingwei_guo");
					}
					else if (Singleton<GeGraphicSetting>.instance.IsLowLevel())
					{
						GeEffectManager effectManager = beActor.m_pkGeActor.GetEffectManager();
						if (effectManager != null)
						{
							effectManager.useCube = true;
						}
					}
					beActor.RegisterEvent(BeEventType.onAfterDead, delegate(object[] arsg)
					{
						if (battlePlayer.state != BattlePlayer.EState.Dead)
						{
							this._onPlayerDead(battlePlayer);
						}
						Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.PLAYER_DEAD, this.mDungeonManager.GetDungeonDataManager().id.dungeonID, this.mDungeonManager.GetDungeonDataManager().CurrentAreaID(), string.Format("{0}, {1}", battlePlayer.playerInfo.roleId, battlePlayer.statistics.data.deadCount));
					});
					if (petData != null)
					{
						beActor.SetPetData(petData);
					}
					beActor.CreateFollowMonster();
					base.InitAutoFight(beActor);
					this.ChangeActorAttribute(beActor);
					beActor.SetForceRunMode(false);
					if (Global.Settings.isDebug && Global.Settings.playerHP > 0)
					{
						beActor.GetEntityData().SetHP(Global.Settings.playerHP);
						beActor.GetEntityData().SetMaxHP(Global.Settings.playerHP);
						beActor.m_pkGeActor.ResetHPBar();
					}
				}
				else
				{
					battlePlayer.playerActor.ResetMoveCmd();
					if (battlePlayer.playerActor.actionManager != null)
					{
						battlePlayer.playerActor.actionManager.StopAll();
					}
				}
				battlePlayer.playerActor.SetPosition(array[k], true, true, false);
				beScene.InitFriendActor(dungeonDataManager.GetBirthPosition());
			}
		}

		// Token: 0x0601916C RID: 102764 RVA: 0x007EC52E File Offset: 0x007EA92E
		private DungeonScore _getScoreByLevel(int level)
		{
			if (level == 0)
			{
				return DungeonScore.SSS;
			}
			if (level == 1)
			{
				return DungeonScore.SS;
			}
			if (level == 2)
			{
				return DungeonScore.S;
			}
			return DungeonScore.A;
		}

		// Token: 0x0601916D RID: 102765 RVA: 0x007EC54C File Offset: 0x007EA94C
		private DungeonScore GetTimeLenScore()
		{
			int level = -1;
			for (int i = 0; i < this.m_CountLevel.Length; i++)
			{
				if (this.m_CountLevel[i] <= this.m_gameTimer.Second)
				{
					level = i;
					break;
				}
			}
			return this._getScoreByLevel(level);
		}

		// Token: 0x0601916E RID: 102766 RVA: 0x007EC59A File Offset: 0x007EA99A
		protected override bool _CanFinishFight()
		{
			return this.m_CanFinishFight;
		}

		// Token: 0x0601916F RID: 102767 RVA: 0x007EC5A4 File Offset: 0x007EA9A4
		private void _DoFinishFight(DungeonScore score)
		{
			this.m_CanFinishFight = true;
			base.FrameRandom.Range100();
			if (base._isNeedSendNet())
			{
				base._sendDungeonRaceEndFail(score);
			}
			else
			{
				SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes
				{
					result = 0U,
					score = (byte)score
				};
				this._onSceneDungeonRaceEndRes(res);
			}
			this.mDungeonManager.FinishFight();
			base.ClearBgm();
			base._playDungeonFinish();
		}

		// Token: 0x06019170 RID: 102768 RVA: 0x007EC610 File Offset: 0x007EAA10
		protected override void _onPlayerDead(BattlePlayer player)
		{
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.MarkInt(24614144U, new int[]
				{
					player.playerActor.m_iID
				});
			}
			player.state = BattlePlayer.EState.Dead;
			player.statistics.Dead();
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			DungeonScore score = DungeonScore.A;
			if (this.m_gameType == TimeLimiteBattle.GameType.LiveTime)
			{
				score = this.GetTimeLenScore();
			}
			this._DoFinishFight(score);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BattlePlayerDead, null, null, null, null);
		}

		// Token: 0x06019171 RID: 102769 RVA: 0x007EC6BC File Offset: 0x007EAABC
		protected override void _onSceneDungeonRaceEndRes(SceneDungeonRaceEndRes res)
		{
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (base.recordServer != null && base.recordServer.IsProcessRecord())
			{
				base.recordServer.Mark(2990876481U);
			}
			if (res.result == 0U)
			{
				DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleEndInfo(res);
				Singleton<UIEventManager>.GetInstance().SendUIEvent(EUIEventID.OnHidePauseButton, new UIEventParam
				{
					m_Bool = true
				});
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._finishProcess(res));
				if (res.score == 0)
				{
					DataManager<DevelopGuidanceManager>.GetInstance().SignalGuidanceEntrace();
				}
			}
			else
			{
				Logger.LogErrorCode(res.result);
			}
		}

		// Token: 0x06019172 RID: 102770 RVA: 0x007EC770 File Offset: 0x007EAB70
		private IEnumerator _finishProcess(SceneDungeonRaceEndRes res)
		{
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<AnniversaryPVEFrame>(null, false);
			base.PveBattleResult = ((res.score != 0) ? BattleResult.Success : BattleResult.Fail);
			AnniversaryFinishFrame frame = Singleton<ClientSystemManager>.instance.OpenFrame<AnniversaryFinishFrame>(FrameLayer.Middle, null, string.Empty) as AnniversaryFinishFrame;
			int iCounter = this.m_Counter;
			if (this.m_gameType == TimeLimiteBattle.GameType.LiveTime && this.m_gameTimer != null)
			{
				iCounter = this.m_gameTimer.Second;
			}
			frame.SetFrameData((DungeonScore)res.score, this.m_DungeonFinishCaptions, this.m_DungeonFinishContents, this.m_CountLevel, iCounter, this.m_isLessComparor);
			yield return base._waitForFrameClose(typeof(AnniversaryFinishFrame));
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (res.hasRaceEndChest != 0)
			{
				if (BattleMain.instance == null)
				{
					yield break;
				}
				Singleton<ClientSystemManager>.instance.OpenFrame<DungeonRewardFrame>(FrameLayer.Middle, null, string.Empty);
				yield return base._waitForFrameClose(typeof(DungeonRewardFrame));
			}
			if (BattleMain.instance == null)
			{
				yield break;
			}
			if (this.mDungeonManager == null || this.mDungeonManager.GetDungeonDataManager() == null)
			{
				yield break;
			}
			int id = base.dungeonManager.GetDungeonDataManager().id.dungeonID;
			if (BattleMain.instance == null)
			{
				yield break;
			}
			Singleton<ClientSystemManager>.instance.OpenFrame<DungeonMenuFrame>(FrameLayer.Middle, null, string.Empty);
			yield return Yielders.EndOfFrame;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRewardFinish, null, null, null, null);
			yield break;
		}

		// Token: 0x04011FDE RID: 73694
		private int m_LimitTime = 999999999;

		// Token: 0x04011FDF RID: 73695
		private string[] m_DungeonFinishCaptions = new string[0];

		// Token: 0x04011FE0 RID: 73696
		private string[] m_DungeonFinishContents = new string[0];

		// Token: 0x04011FE1 RID: 73697
		private int[] m_CountLevel = new int[0];

		// Token: 0x04011FE2 RID: 73698
		private int m_Counter;

		// Token: 0x04011FE3 RID: 73699
		private bool m_isLessComparor = true;

		// Token: 0x04011FE4 RID: 73700
		private SimpleTimer2 m_gameTimer = new SimpleTimer2();

		// Token: 0x04011FE5 RID: 73701
		private TimeLimiteBattle.GameType m_gameType;

		// Token: 0x04011FE6 RID: 73702
		private bool m_isGameStart;

		// Token: 0x04011FE7 RID: 73703
		private int m_tipID;

		// Token: 0x04011FE8 RID: 73704
		private int m_tipTimeLen;

		// Token: 0x04011FE9 RID: 73705
		private DelayCallUnitHandle m_countTimeHandler;

		// Token: 0x020045C7 RID: 17863
		public enum GameType
		{
			// Token: 0x04011FEB RID: 73707
			CoinCount,
			// Token: 0x04011FEC RID: 73708
			BehitCout,
			// Token: 0x04011FED RID: 73709
			KillCount,
			// Token: 0x04011FEE RID: 73710
			LiveTime
		}
	}
}
