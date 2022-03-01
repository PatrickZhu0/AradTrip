using System;
using System.Collections;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020045AC RID: 17836
	internal class ChampionMatchBattle : ActivityBattle
	{
		// Token: 0x06018F57 RID: 102231 RVA: 0x007D8FBE File Offset: 0x007D73BE
		public ChampionMatchBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018F58 RID: 102232 RVA: 0x007D8FC9 File Offset: 0x007D73C9
		protected override void _onCreateScene(object[] args)
		{
		}

		// Token: 0x06018F59 RID: 102233 RVA: 0x007D8FCB File Offset: 0x007D73CB
		protected override void _onPostStart()
		{
			this._setMatchName();
			ChampionMatchFrame.inited = false;
			Singleton<ClientSystemManager>.instance.OpenFrame<ChampionMatchFrame>(FrameLayer.Top, null, string.Empty);
			this.mDungeonManager.PauseFight(true, string.Empty, false);
		}

		// Token: 0x06018F5A RID: 102234 RVA: 0x007D9000 File Offset: 0x007D7400
		private void _setMatchName()
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				DungeonID id = this.mDungeonManager.GetDungeonDataManager().id;
				string arg = (id.prestoryID <= 0) ? ChapterUtility.GetHardString(id.diffID) : string.Empty;
				string championMatchName = string.Format("<color=#14c5ff>{0}</color>{1}", arg, this.mDungeonManager.GetDungeonDataManager().asset.GetName());
				clientSystemBattle.SetChampionMatchName(championMatchName);
			}
		}

		// Token: 0x06018F5B RID: 102235 RVA: 0x007D907E File Offset: 0x007D747E
		protected override void _onAreaClear(object[] arg)
		{
			if (!this.mIsProcessAreaClear)
			{
				this.mIsProcessAreaClear = true;
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._processAreaClear());
			}
		}

		// Token: 0x06018F5C RID: 102236 RVA: 0x007D90A4 File Offset: 0x007D74A4
		private IEnumerator _processAreaClear()
		{
			yield return base._sendDungeonReportDataIter(false);
			this.mIsProcessAreaClear = false;
			BeScene mCurBeScene = this.mDungeonManager.GetBeScene();
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			mCurBeScene.ForcePickUpDropItem(mainPlayer.playerActor);
			this._showWinEffect();
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				base._CheckFightEnd();
			}
			else
			{
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(1500, delegate
				{
					this.FireSceneChangeAreaCmd();
				}, 0, 0, false);
			}
			yield break;
		}

		// Token: 0x06018F5D RID: 102237 RVA: 0x007D90C0 File Offset: 0x007D74C0
		private void _showWinEffect()
		{
			BattlePvpFrame system = BattleUIHelper.GetBattleUIFrame<BattlePvpFrame>() as BattlePvpFrame;
			if (system != null)
			{
				system.ShowPkResult(PKResult.WIN);
				MonoSingleton<AudioManager>.instance.PlaySound(19);
				Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(2000, delegate
				{
					system.HiddenPkResult();
				}, 0, 0, false);
			}
		}

		// Token: 0x06018F5E RID: 102238 RVA: 0x007D912C File Offset: 0x007D752C
		public void FireSceneChangeAreaCmd()
		{
			SceneChangeArea cmd = new SceneChangeArea();
			FrameSync.instance.FireFrameCommand(cmd, false);
		}

		// Token: 0x06018F5F RID: 102239 RVA: 0x007D914B File Offset: 0x007D754B
		public void ResumeGameCmd()
		{
			if (this.mDungeonManager != null)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
		}

		// Token: 0x06018F60 RID: 102240 RVA: 0x007D916A File Offset: 0x007D756A
		protected override void _onSceneAreaChange()
		{
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this.mDungeonManager.FinishFight();
				base._resetPlayerActor(false);
			}
			else
			{
				this._changeAreaByIdx();
			}
		}

		// Token: 0x06018F61 RID: 102241 RVA: 0x007D91A0 File Offset: 0x007D75A0
		protected override void _createPlayers()
		{
			base._createPlayers();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				allPlayers[i].playerActor.SetPosition(dungeonDataManager.CurrentBirthPosition(), false, true, false);
			}
			this.mDungeonManager.GetBeScene().InitFriendActor(dungeonDataManager.CurrentBirthPosition());
		}

		// Token: 0x06018F62 RID: 102242 RVA: 0x007D9212 File Offset: 0x007D7612
		protected override void _onStart()
		{
			base._hiddenDungeonMap(true);
			this.currentIndex = this.mDungeonManager.GetDungeonDataManager().CurrentIndex();
		}

		// Token: 0x06018F63 RID: 102243 RVA: 0x007D9231 File Offset: 0x007D7631
		protected override void _createDoors()
		{
		}

		// Token: 0x06018F64 RID: 102244 RVA: 0x007D9233 File Offset: 0x007D7633
		protected override void _onDoorStateChange(object[] arg)
		{
		}

		// Token: 0x06018F65 RID: 102245 RVA: 0x007D9235 File Offset: 0x007D7635
		private void _changeAreaByIdx()
		{
			base._changeAreaFade(600U, 300U, delegate
			{
				if (this.mDungeonManager.GetDungeonDataManager().NextAreaByIndexBaseOnServerData(this.currentIndex + 1))
				{
					this.currentIndex++;
					base._createBase();
					this._createEntitys();
					base.PreloadMonster();
					this._onSceneStart();
					this.mDungeonManager.StartFight(false);
					base._sendSceneDungeonEnterNextAreaReq(this.mDungeonManager.GetDungeonDataManager().CurrentAreaID());
					base._sendDungeonRewardReq();
				}
			}, delegate
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<ChampionMatchFrame>(FrameLayer.Top, null, string.Empty);
				if (this.mDungeonManager != null)
				{
					BeScene beScene = this.mDungeonManager.GetBeScene();
					if (beScene != null)
					{
						beScene.Pause(true);
						beScene.PauseLogic();
					}
				}
			});
		}

		// Token: 0x04011EFF RID: 73471
		private int currentIndex;

		// Token: 0x04011F00 RID: 73472
		private bool mIsProcessAreaClear;
	}
}
