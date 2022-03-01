using System;
using System.Collections;
using ActivityLimitTime;
using DG.Tweening;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010A6 RID: 4262
	public class DungeonFinishFrame : ClientFrame
	{
		// Token: 0x0600A0B9 RID: 41145 RVA: 0x0020704D File Offset: 0x0020544D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonNormalFinish";
		}

		// Token: 0x0600A0BA RID: 41146 RVA: 0x00207054 File Offset: 0x00205454
		protected override bool _isLoadFromPool()
		{
			return true;
		}

		// Token: 0x0600A0BB RID: 41147 RVA: 0x00207058 File Offset: 0x00205458
		protected override void _bindExUI()
		{
			this.mFinishScore = this.mBind.GetCom<ComDungeonFinishScore>("FinishScore");
			this.mFiledNameList = this.mBind.GetCom<ComItemList>("FiledNameList");
			this.mAudioProxy = this.mBind.GetCom<UIAudioProxy>("AudioProxy");
			this.mDt[0] = this.mBind.GetCom<DOTweenAnimation>("dt0");
			this.mDt[1] = this.mBind.GetCom<DOTweenAnimation>("dt1");
			this.mDt[2] = this.mBind.GetCom<DOTweenAnimation>("dt2");
			this.mDt[3] = this.mBind.GetCom<DOTweenAnimation>("dt3");
			this.mDt[4] = this.mBind.GetCom<DOTweenAnimation>("dt4");
			this.mDt[5] = this.mBind.GetCom<DOTweenAnimation>("dt5");
			this.mDt[6] = this.mBind.GetCom<DOTweenAnimation>("dt6");
			this.mDt[7] = this.mBind.GetCom<DOTweenAnimation>("dt7");
			this.mDt[8] = this.mBind.GetCom<DOTweenAnimation>("dt8");
			this.mDt[9] = this.mBind.GetCom<DOTweenAnimation>("dt9");
			this.mDt[10] = this.mBind.GetCom<DOTweenAnimation>("dt10");
			this.mDt[11] = this.mBind.GetCom<DOTweenAnimation>("dt11");
			this.mDt[12] = this.mBind.GetCom<DOTweenAnimation>("dt12");
			this.mDt[13] = this.mBind.GetCom<DOTweenAnimation>("dt13");
			this.mDt[14] = this.mBind.GetCom<DOTweenAnimation>("dt14");
			this.mDt[15] = this.mBind.GetCom<DOTweenAnimation>("dt15");
			this.mDt[16] = this.mBind.GetCom<DOTweenAnimation>("dt16");
			this.mDt[17] = this.mBind.GetCom<DOTweenAnimation>("dt17");
			this.mDt[18] = this.mBind.GetCom<DOTweenAnimation>("dt18");
			this.mDt[19] = this.mBind.GetCom<DOTweenAnimation>("dt19");
			this.mDt[20] = this.mBind.GetCom<DOTweenAnimation>("dt20");
			this.mDt[21] = this.mBind.GetCom<DOTweenAnimation>("dt21");
			this.mDt[22] = this.mBind.GetCom<DOTweenAnimation>("dt22");
			this.mDt[23] = this.mBind.GetCom<DOTweenAnimation>("dt23");
			this.mFatigueCombustionRoot = this.mBind.GetGameObject("FatigueCombustionRoot");
		}

		// Token: 0x0600A0BC RID: 41148 RVA: 0x0020730C File Offset: 0x0020570C
		protected override void _unbindExUI()
		{
			this.mFinishScore = null;
			this.mFiledNameList = null;
			this.mAudioProxy = null;
			this.mDt[0] = null;
			this.mDt[1] = null;
			this.mDt[2] = null;
			this.mDt[3] = null;
			this.mDt[4] = null;
			this.mDt[5] = null;
			this.mDt[6] = null;
			this.mDt[7] = null;
			this.mDt[8] = null;
			this.mDt[9] = null;
			this.mDt[10] = null;
			this.mDt[11] = null;
			this.mDt[12] = null;
			this.mDt[13] = null;
			this.mDt[14] = null;
			this.mDt[15] = null;
			this.mDt[16] = null;
			this.mDt[17] = null;
			this.mDt[18] = null;
			this.mDt[19] = null;
			this.mDt[20] = null;
			this.mDt[21] = null;
			this.mDt[22] = null;
			this.mDt[23] = null;
			this.mFatigueCombustionRoot = null;
		}

		// Token: 0x0600A0BD RID: 41149 RVA: 0x0020741C File Offset: 0x0020581C
		protected override void _OnOpenFrame()
		{
			if (BattleMain.battleType == BattleType.GuildPVE)
			{
				GuildPVEBattle guildPVEBattle = null;
				if (BattleMain.instance != null)
				{
					guildPVEBattle = (BattleMain.instance.GetBattle() as GuildPVEBattle);
				}
				if (this.mFinishScore != null)
				{
					for (int i = 0; i < this.mFinishScore.infos.Length; i++)
					{
						if (!(this.mFinishScore.infos[i] == null))
						{
							if (guildPVEBattle != null && guildPVEBattle.ValidTable != null)
							{
								if (guildPVEBattle.ValidTable.dungeonLvl > 1)
								{
									this.mFinishScore.infos[i].mScoreType = ComDungeonScoreInfo.eScoreType.StandardDamage;
									if (i == 0)
									{
										this.mFinishScore.infos[i].scoreStandard = guildPVEBattle.ValidTable.oneStarDamage;
										this.mFinishScore.infos[i].scoreLevel = 3;
									}
									else if (i == 1)
									{
										this.mFinishScore.infos[i].scoreStandard = guildPVEBattle.ValidTable.twoStarDamage;
										this.mFinishScore.infos[i].scoreLevel = 4;
									}
									else if (i == 2)
									{
										this.mFinishScore.infos[i].scoreStandard = guildPVEBattle.ValidTable.threeStarDamage;
										this.mFinishScore.infos[i].scoreLevel = 5;
									}
									this.mFinishScore.infos[i].Init();
								}
								else
								{
									if (i == 0)
									{
										this.mFinishScore.infos[0].mScoreType = ComDungeonScoreInfo.eScoreType.HitCount;
										this.mFinishScore.infos[0].Init();
									}
									if (i == 1)
									{
										this.mFinishScore.infos[1].mScoreType = ComDungeonScoreInfo.eScoreType.FightTime;
										this.mFinishScore.infos[1].Init();
									}
									if (i == 2)
									{
										this.mFinishScore.infos[2].mScoreType = ComDungeonScoreInfo.eScoreType.ReborCount;
										this.mFinishScore.infos[2].Init();
									}
								}
							}
						}
					}
				}
			}
			else if (this.mFinishScore != null)
			{
				if (this.mFinishScore.infos[0] != null)
				{
					this.mFinishScore.infos[0].mScoreType = ComDungeonScoreInfo.eScoreType.HitCount;
					this.mFinishScore.infos[0].Init();
				}
				if (this.mFinishScore.infos[1] != null)
				{
					this.mFinishScore.infos[1].mScoreType = ComDungeonScoreInfo.eScoreType.FightTime;
					this.mFinishScore.infos[1].Init();
				}
				if (this.mFinishScore.infos[2])
				{
					this.mFinishScore.infos[2].mScoreType = ComDungeonScoreInfo.eScoreType.ReborCount;
					this.mFinishScore.infos[2].Init();
				}
			}
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._addCallback());
			this._playAnimate();
			this._playBgm();
		}

		// Token: 0x0600A0BE RID: 41150 RVA: 0x00207708 File Offset: 0x00205B08
		private void _playAnimate()
		{
			for (int i = 0; i < this.mDt.Length; i++)
			{
				if (null != this.mDt[i] && this.mDt[i].isActive)
				{
					this.mDt[i].DOPlay();
				}
			}
		}

		// Token: 0x0600A0BF RID: 41151 RVA: 0x00207760 File Offset: 0x00205B60
		private void _playBgm()
		{
			if (null != this.mAudioProxy)
			{
				this.mAudioProxy.TriggerAudio(1);
			}
		}

		// Token: 0x0600A0C0 RID: 41152 RVA: 0x00207780 File Offset: 0x00205B80
		protected override void _OnCloseFrame()
		{
			if (null != this.mFinishScore)
			{
				this.mFinishScore.Uninit();
				this.mFinishScore = null;
			}
			if (BattleMain.instance == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager() == null)
			{
				return;
			}
			if (BattleMain.instance.GetDungeonManager().GetDungeonDataManager() == null)
			{
				return;
			}
			Singleton<GameStatisticManager>.instance.DoStatInBattleEx(StatInBattleType.CLICK_RESULT, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().id.dungeonID, BattleMain.instance.GetDungeonManager().GetDungeonDataManager().CurrentAreaID(), string.Empty);
		}

		// Token: 0x0600A0C1 RID: 41153 RVA: 0x00207820 File Offset: 0x00205C20
		private IEnumerator _addCallback()
		{
			yield return Yielders.GetWaitForSeconds(5f);
			this.frameMgr.CloseFrame<DungeonFinishFrame>(this, false);
			yield break;
		}

		// Token: 0x0600A0C2 RID: 41154 RVA: 0x0020783C File Offset: 0x00205C3C
		public void SetData(SceneDungeonRaceEndRes res)
		{
			int killMonsterTotalExp = (int)res.killMonsterTotalExp;
			int raceEndExp = (int)res.raceEndExp;
			int monthCardGold = (int)(res.monthcartGoldReward + res.goldTitleGoldReward);
			uint[] addition = res.addition.addition;
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.fatigueBurnType = (int)res.fatigueBurnType;
			}
			DataManager<GuildDataManager>.GetInstance().chestDoubleFlag = res.chestDoubleFlag;
			DungeonScore score = (DungeonScore)res.score;
			int sumExp = killMonsterTotalExp + raceEndExp;
			this.mFinishScore.Init(sumExp, score);
			int num = Enum.GetNames(typeof(DungeonAdditionType)).Length;
			if (addition.Length >= num)
			{
				int num2 = (int)addition[0];
				int num3 = (int)addition[2];
				int num4 = (int)addition[3];
				int num5 = (int)addition[1];
				int num6 = (int)addition[6];
				int num7 = (int)addition[7];
				int baseExp;
				if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_NEW_RACE_END_EXP))
				{
					baseExp = (int)addition[9];
				}
				else
				{
					baseExp = raceEndExp - num2 - num3 - num4 - num5 - num6 - num7;
				}
				int vipgold = (int)addition[5];
				this.mFinishScore.SetExpSplit(baseExp, num2, num3, num4, num5, vipgold, monthCardGold, num6, num7);
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				this.mFatigueCombustionRoot.CustomActive(DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.fatigueBurnType == 1 || DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.fatigueBurnType == 2);
			}
		}

		// Token: 0x0600A0C3 RID: 41155 RVA: 0x00207998 File Offset: 0x00205D98
		public void SetDrops(ComItemList.Items[] drops)
		{
			this.mFiledNameList.SetItems(drops);
		}

		// Token: 0x0600A0C4 RID: 41156 RVA: 0x002079A6 File Offset: 0x00205DA6
		private void _onHandle()
		{
			this.frameMgr.CloseFrame<DungeonFinishFrame>(this, false);
		}

		// Token: 0x04005943 RID: 22851
		private const string kOpenFrameSoundPath = "Sound/SE/result_list";

		// Token: 0x04005944 RID: 22852
		protected GameObject mEffect;

		// Token: 0x04005945 RID: 22853
		private ComDungeonFinishScore mFinishScore;

		// Token: 0x04005946 RID: 22854
		private ComItemList mFiledNameList;

		// Token: 0x04005947 RID: 22855
		private UIAudioProxy mAudioProxy;

		// Token: 0x04005948 RID: 22856
		private DOTweenAnimation[] mDt = new DOTweenAnimation[24];

		// Token: 0x04005949 RID: 22857
		private GameObject mFatigueCombustionRoot;
	}
}
