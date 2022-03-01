using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020045AA RID: 17834
	public class BaseNewbieGuideBattle : PVEBattle
	{
		// Token: 0x06018F1D RID: 102173 RVA: 0x007D52E0 File Offset: 0x007D36E0
		public BaseNewbieGuideBattle(BattleType type, eDungeonMode mode, int id) : base(type, eDungeonMode.Test, id)
		{
			base.FrameRandom.ResetSeed(20006229U);
		}

		// Token: 0x06018F1E RID: 102174 RVA: 0x007D5374 File Offset: 0x007D3774
		private IEnumerator _save()
		{
			yield break;
		}

		// Token: 0x06018F1F RID: 102175 RVA: 0x007D5388 File Offset: 0x007D3788
		private IEnumerator _closeFrame(Type type)
		{
			while (!Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				yield return Yielders.EndOfFrame;
			}
			Singleton<ClientSystemManager>.instance.CloseFrameByType(type, true);
			yield break;
		}

		// Token: 0x06018F20 RID: 102176 RVA: 0x007D53A4 File Offset: 0x007D37A4
		protected IEnumerator _GuideShowSkill(GameObject obj, float timelen)
		{
			timelen = 0.15f;
			RectTransform rect = obj.transform.GetComponent<RectTransform>();
			TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => rect.localScale, delegate(Vector3 value)
			{
				rect.localScale = value;
			}, Vector3.one, timelen), this.skillButtonShow);
			yield return Yielders.GetWaitForSeconds(timelen);
			yield break;
		}

		// Token: 0x06018F21 RID: 102177 RVA: 0x007D53D0 File Offset: 0x007D37D0
		protected IEnumerator _DoStateNewbieGuideBegin()
		{
			this.step = 0;
			if (this.mDungeonPlayers == null)
			{
				yield break;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			if (mainPlayer != null)
			{
				BeActor playerActor = this.mDungeonPlayers.GetMainPlayer().playerActor;
				if (playerActor != null)
				{
					if (playerActor.m_pkGeActor != null && playerActor.m_pkGeActor.titleComponent != null)
					{
						playerActor.m_pkGeActor.titleComponent.SetPKEnable(false);
					}
					int num = 1112;
					if (num > 0)
					{
						playerActor.buffController.TryAddBuff(num, -1, 1);
					}
				}
			}
			yield break;
		}

		// Token: 0x06018F22 RID: 102178 RVA: 0x007D53EC File Offset: 0x007D37EC
		protected IEnumerator _DoStateNewbieGuideIter(string key)
		{
			this._DoStateNewbieGuideFunc(key);
			yield break;
		}

		// Token: 0x06018F23 RID: 102179 RVA: 0x007D540E File Offset: 0x007D380E
		protected void _DoStateNewbieGuideFunc(string key)
		{
			Singleton<GameStatisticManager>.GetInstance().DoStatNewBieGuide(key, -1);
			this.step++;
		}

		// Token: 0x06018F24 RID: 102180 RVA: 0x007D542A File Offset: 0x007D382A
		protected override void _onStartResourceLoaded()
		{
		}

		// Token: 0x06018F25 RID: 102181 RVA: 0x007D542C File Offset: 0x007D382C
		protected override void _onEnd()
		{
			if (this.mCoroutine != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCoroutine);
				this.mCoroutine = null;
			}
			this.mBossActor = null;
			this.mEliteMonster = null;
		}

		// Token: 0x06018F26 RID: 102182 RVA: 0x007D5460 File Offset: 0x007D3860
		protected override void _onPlayerUseSkill(BattlePlayer player, int skill)
		{
			byte seat = player.playerInfo.seat;
			if (seat == ClientApplication.playerinfo.seat)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonPlayerUseSkill, skill, null, null, null);
			}
		}

		// Token: 0x06018F27 RID: 102183 RVA: 0x007D54A4 File Offset: 0x007D38A4
		protected override void _onPlayerDead(BattlePlayer player)
		{
			RebornFrameCommand rebornFrameCommand = new RebornFrameCommand();
			rebornFrameCommand.frame = 0U;
			rebornFrameCommand.seat = player.playerInfo.seat;
			rebornFrameCommand.targetSeat = player.playerInfo.seat;
			FrameSync.instance.FireFrameCommand(rebornFrameCommand, false);
		}

		// Token: 0x06018F28 RID: 102184 RVA: 0x007D54EC File Offset: 0x007D38EC
		protected void _createMonsterExceptType(int type, bool revert = false)
		{
			BeScene beScene = this.mDungeonManager.GetBeScene();
			DungeonDataManager dungeonDataManager = this.mDungeonManager.GetDungeonDataManager();
			List<DungeonMonster> list = dungeonDataManager.CurrentMonsters();
			List<DungeonMonster> list2 = new List<DungeonMonster>(list.ToArray());
			list2.RemoveAll(delegate(DungeonMonster x)
			{
				if (revert)
				{
					return type != x.typeId % 100 / 10;
				}
				return type == x.typeId % 100 / 10;
			});
			beScene.CreateMonsterList(list2, dungeonDataManager.IsBossArea(), dungeonDataManager.GetBirthPosition(), true);
		}

		// Token: 0x06018F29 RID: 102185 RVA: 0x007D5563 File Offset: 0x007D3963
		protected override void _createMonsters()
		{
			base._createMonsters();
		}

		// Token: 0x06018F2A RID: 102186 RVA: 0x007D556B File Offset: 0x007D396B
		protected void Log(string str, params object[] args)
		{
		}

		// Token: 0x06018F2B RID: 102187 RVA: 0x007D5570 File Offset: 0x007D3970
		protected void DungeonPause(bool bPause)
		{
			if (bPause)
			{
				this.Log("PauseFight", new object[0]);
				this.mDungeonManager.PauseFight(true, string.Empty, false);
			}
			else
			{
				this.Log("ResumeFight", new object[0]);
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
		}

		// Token: 0x06018F2C RID: 102188 RVA: 0x007D55D0 File Offset: 0x007D39D0
		protected IEnumerator _waitForTime(float time, bool isPause = false)
		{
			this.Log("_waitForTime Begin {0} Pause {1}", new object[]
			{
				time,
				isPause
			});
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			if (isPause)
			{
				this.mDungeonManager.PauseFight(true, string.Empty, false);
			}
			yield return Yielders.GetWaitForSeconds(time);
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			if (isPause)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
			this.Log("_waitForTime End", new object[0]);
			yield break;
		}

		// Token: 0x06018F2D RID: 102189 RVA: 0x007D55FC File Offset: 0x007D39FC
		protected IEnumerator _startEliteIntroduce(int skillID, float time)
		{
			BeActor mons = this._findNoneBossActor();
			yield return Yielders.EndOfFrame;
			if (mons != null)
			{
				bool flag = false;
				mons.RegisterEvent(BeEventType.onHurt, delegate(object[] args)
				{
					if (!flag && mons.GetEntityData().GetHP() <= 0)
					{
						flag = true;
						this._createMonsterExceptType(3, true);
						this.mDungeonManager.GetBeScene().state = BeSceneState.onFight;
						this.mEliteMonster = null;
					}
				});
			}
			yield return Yielders.EndOfFrame;
			mons.hasAI = false;
			yield return Yielders.EndOfFrame;
			mons.UseSkill(skillID, true);
			yield return this._waitForTime(time, false);
			mons.hasAI = true;
			yield break;
		}

		// Token: 0x06018F2E RID: 102190 RVA: 0x007D5628 File Offset: 0x007D3A28
		protected IEnumerator _waitForBossBrith()
		{
			while (this.mEliteMonster != null)
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06018F2F RID: 102191 RVA: 0x007D5644 File Offset: 0x007D3A44
		protected IEnumerator _DoLogic(UnityAction logic)
		{
			this.Log("_DoLogic   {0} ", new object[]
			{
				logic
			});
			if (logic != null)
			{
				logic.Invoke();
			}
			yield break;
		}

		// Token: 0x06018F30 RID: 102192 RVA: 0x007D5668 File Offset: 0x007D3A68
		protected IEnumerator _startBossIntroduce(float time)
		{
			yield return Yielders.EndOfFrame;
			this.mInputManager.SetVisible(false);
			this.mDungeonManager.GetBeScene().state = BeSceneState.onFight;
			this._createMonsterExceptType(3, true);
			yield return Yielders.EndOfFrame;
			BeActor boss = this._findBossActor();
			boss.Reset();
			boss.hasAI = false;
			boss.SetCanBeAttacked(false);
			boss.m_pkGeActor.ChangeAction("Anim_Chuchang", 1f, false, true, false);
			boss.m_pkGeActor.SetMaterial(string.Empty);
			boss.needHitShader = true;
			boss.m_pkGeActor.SetHeadInfoVisible(false);
			boss.m_pkGeActor.SetFootIndicatorVisible(false);
			this.mBossHurtHandler = boss.RegisterEvent(BeEventType.onHurt, new BeEventHandle.Del(this._onBossHurt));
			yield return this._waitForTime(time, false);
			this.mInputManager.SetVisible(true);
			boss.hasAI = true;
			boss.Reset();
			boss.StartAI(null, true);
			boss.SetCanBeAttacked(true);
			yield break;
		}

		// Token: 0x06018F31 RID: 102193 RVA: 0x007D568C File Offset: 0x007D3A8C
		protected override void _onAreaClear(object[] args)
		{
			this.mDungeonManager.GetBeScene().SetTransportDoorEnable(TransportDoorType.Left, false);
			this.mDungeonManager.GetBeScene().SetTransportDoorEnable(TransportDoorType.Right, false);
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				this.mDungeonManager.FinishFight();
			}
		}

		// Token: 0x06018F32 RID: 102194 RVA: 0x007D56E2 File Offset: 0x007D3AE2
		protected override void _onPostStart()
		{
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._save());
			this.mCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._startGuide());
			base.FrameRandom.ResetSeed(20006229U);
			CameraAspectAdjust.MarkDirty();
		}

		// Token: 0x06018F33 RID: 102195 RVA: 0x007D5720 File Offset: 0x007D3B20
		protected IEnumerator _waitForDialog(int id)
		{
			this.Log("_waitForDialog {0}", new object[]
			{
				id
			});
			this._DoStateNewbieGuideFunc("Dialog " + id + "Begin");
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			bool isFinish = false;
			TaskDialogFrame.OnDialogOver task = new TaskDialogFrame.OnDialogOver();
			task.AddListener(delegate
			{
				isFinish = true;
			});
			DataManager<MissionManager>.GetInstance().CreateDialogFrame(id, 0, task);
			while (!isFinish)
			{
				yield return Yielders.EndOfFrame;
			}
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.ResumeFight(true, string.Empty, false);
			this._DoStateNewbieGuideFunc("Dialog " + id + "End");
			yield break;
		}

		// Token: 0x06018F34 RID: 102196 RVA: 0x007D5744 File Offset: 0x007D3B44
		protected IEnumerator _waitForState(BeSceneState state)
		{
			this.Log("wait for state {0} begin", new object[]
			{
				state
			});
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			while (this.mDungeonManager.GetBeScene() != null && this.mDungeonManager.GetBeScene().state != state)
			{
				yield return Yielders.EndOfFrame;
				if (this.mDungeonManager == null)
				{
					yield break;
				}
			}
			this.Log("wait for state {0} end", new object[]
			{
				state
			});
			yield break;
		}

		// Token: 0x06018F35 RID: 102197 RVA: 0x007D5768 File Offset: 0x007D3B68
		protected IEnumerator _waitForStateEX(BeSceneState state)
		{
			while (this.mDungeonManager.GetBeScene() != null && this.mDungeonManager.GetBeScene().state < state)
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06018F36 RID: 102198 RVA: 0x007D578C File Offset: 0x007D3B8C
		protected IEnumerator _waitForBossRoom()
		{
			while (!this.mDungeonManager.GetDungeonDataManager().CurrentDataConnect().IsBoss())
			{
				yield return Yielders.EndOfFrame;
			}
			yield break;
		}

		// Token: 0x06018F37 RID: 102199 RVA: 0x007D57A8 File Offset: 0x007D3BA8
		protected IEnumerator _openFrame(Type type, bool isPause = false)
		{
			if (isPause)
			{
				this.mDungeonManager.PauseFight(true, string.Empty, false);
			}
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame(type, FrameLayer.Middle, null, string.Empty);
			}
			if (isPause)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x06018F38 RID: 102200 RVA: 0x007D57D4 File Offset: 0x007D3BD4
		protected IEnumerator _waitFrameClose(Type type)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				Singleton<ClientSystemManager>.instance.OpenFrame(type, FrameLayer.Middle, null, string.Empty);
			}
			while (Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				yield return Yielders.EndOfFrame;
			}
			if (this.mDungeonManager != null)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
			yield break;
		}

		// Token: 0x06018F39 RID: 102201 RVA: 0x007D57F8 File Offset: 0x007D3BF8
		protected IEnumerator _waitFrame(Type type, float delay, bool pauseGame = true)
		{
			if (pauseGame)
			{
				this.mDungeonManager.PauseFight(true, string.Empty, false);
			}
			Singleton<ClientSystemManager>.instance.OpenFrame(type, FrameLayer.Middle, null, string.Empty);
			yield return Yielders.GetWaitForSeconds(delay);
			Singleton<ClientSystemManager>.instance.CloseFrameByType(type, false);
			if (pauseGame)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
			yield break;
		}

		// Token: 0x06018F3A RID: 102202 RVA: 0x007D5828 File Offset: 0x007D3C28
		protected IEnumerator _waitTips(string msg, float delay)
		{
			NewbieGuideMsgTipsFrame frame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuideMsgTipsFrame>(FrameLayer.Middle, null, string.Empty) as NewbieGuideMsgTipsFrame;
			frame.SetMessage(msg);
			yield return Yielders.GetWaitForSeconds(delay);
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideMsgTipsFrame>(null, false);
			yield break;
		}

		// Token: 0x06018F3B RID: 102203 RVA: 0x007D584C File Offset: 0x007D3C4C
		protected IEnumerator _waitPlayerLowHp(float rate)
		{
			BattlePlayer player = this.mDungeonPlayers.GetMainPlayer();
			BeEntityData data = player.playerActor.GetEntityData();
			while (data.GetHPRate().single >= rate)
			{
				yield return Yielders.EndOfFrame;
			}
			yield return Yielders.EndOfFrame;
			player.playerActor.DoHPChange((int)((float)data.GetMaxHP() * rate), false);
			yield return Yielders.EndOfFrame;
			player.playerActor.Reset();
			yield break;
		}

		// Token: 0x06018F3C RID: 102204 RVA: 0x007D5870 File Offset: 0x007D3C70
		protected IEnumerator _setPlayerHp(float rate)
		{
			BattlePlayer player = this.mDungeonPlayers.GetMainPlayer();
			BeEntityData data = player.playerActor.GetEntityData();
			yield return Yielders.EndOfFrame;
			if (data.GetHPRate().single <= rate)
			{
				player.playerActor.DoHPChange((int)((float)data.GetMaxHP() * rate), false);
			}
			yield return Yielders.EndOfFrame;
			player.playerActor.Reset();
			yield break;
		}

		// Token: 0x06018F3D RID: 102205 RVA: 0x007D5894 File Offset: 0x007D3C94
		private BeActor _findBossActor()
		{
			if (this.mBossActor == null)
			{
				List<BeActor> list = ListPool<BeActor>.Get();
				this.mDungeonManager.GetBeScene().FindBoss(list);
				if (list.Count > 0)
				{
					this.mBossActor = list[0];
				}
				ListPool<BeActor>.Release(list);
			}
			return this.mBossActor;
		}

		// Token: 0x06018F3E RID: 102206 RVA: 0x007D58EC File Offset: 0x007D3CEC
		private BeActor _findNoneBossActor()
		{
			if (this.mEliteMonster == null)
			{
				List<BeEntity> fullEntities = this.mDungeonManager.GetBeScene().GetFullEntities();
				for (int i = 0; i < fullEntities.Count; i++)
				{
					BeActor beActor = fullEntities[i] as BeActor;
					if (beActor.m_iCamp != 0 && (beActor.GetEntityData().type == 2 || beActor.GetEntityData().type == 1))
					{
						this.mEliteMonster = beActor;
					}
				}
			}
			return this.mEliteMonster;
		}

		// Token: 0x06018F3F RID: 102207 RVA: 0x007D5974 File Offset: 0x007D3D74
		protected IEnumerator _waitBossFinalSkill(int skill, float time, float skilltime, int dialogId)
		{
			BeActor boss = this._findBossActor();
			yield return Yielders.GetWaitForSeconds(time);
			if (boss != null)
			{
				boss.hasAI = false;
				boss.Reset();
				yield return Yielders.EndOfFrame;
				if (!boss.UseSkill(skill, true))
				{
					Logger.LogErrorFormat("[middle] wait for boss skill {0} faild", new object[]
					{
						skill
					});
				}
				yield return Yielders.EndOfFrame;
				yield return this._waitForDialog(dialogId);
				boss.hasAI = true;
			}
			else
			{
				Logger.LogError("boss is nil");
			}
			yield return Yielders.GetWaitForSeconds(skilltime);
			yield break;
		}

		// Token: 0x06018F40 RID: 102208 RVA: 0x007D59AC File Offset: 0x007D3DAC
		private void _onBossHurt(object[] args)
		{
			BeActor beActor = this._findBossActor();
			if (beActor.GetEntityData().GetHPRate().single < 0.3f)
			{
				beActor.DoHeal((int)args[0], true);
			}
		}

		// Token: 0x06018F41 RID: 102209 RVA: 0x007D59EC File Offset: 0x007D3DEC
		protected IEnumerator _waitBossIntroduce(float time)
		{
			BeActor boss = this._findBossActor();
			if (boss != null)
			{
				yield return Yielders.GetWaitForSeconds(time);
				boss.hasAI = true;
				boss.Reset();
			}
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x06018F42 RID: 102210 RVA: 0x007D5A10 File Offset: 0x007D3E10
		protected IEnumerator _waitBossDead(float time)
		{
			int cnt = 20;
			BeActor boss = this._findBossActor();
			int hurthp = boss.GetEntityData().GetHP() / cnt + 1;
			if (this.mBossHurtHandler != null)
			{
				boss.RemoveEvent(this.mBossHurtHandler);
				this.mBossHurtHandler = null;
			}
			for (int i = 0; i < cnt; i++)
			{
				boss.DoHurt(hurthp, null, HitTextType.NORMAL, null, HitTextType.NORMAL, false);
				yield return Yielders.GetWaitForSeconds(0.1f);
			}
			yield return Yielders.GetWaitForSeconds(time);
			yield break;
		}

		// Token: 0x06018F43 RID: 102211 RVA: 0x007D5A34 File Offset: 0x007D3E34
		protected IEnumerator _returnToTown()
		{
			this.Log("_returnToTown", new object[0]);
			IClientSystem currentSystem = Singleton<ClientSystemManager>.instance.GetCurrentSystem();
			if (currentSystem != null && currentSystem != typeof(ClientSystemTown))
			{
				Singleton<ClientSystemManager>.instance.SwitchSystem<ClientSystemTown>(null, null, false);
			}
			yield break;
		}

		// Token: 0x06018F44 RID: 102212 RVA: 0x007D5A50 File Offset: 0x007D3E50
		protected IEnumerator _setVisibleInputmanager(bool isShow)
		{
			yield return Yielders.EndOfFrame;
			if (this.mInputManager != null)
			{
				this.mInputManager.SetVisible(isShow);
			}
			yield break;
		}

		// Token: 0x06018F45 RID: 102213 RVA: 0x007D5A74 File Offset: 0x007D3E74
		protected IEnumerator _setPlayerFrameCommand(bool enable)
		{
			this.Log("EnablePlayerFrameCommand {0}", new object[]
			{
				enable
			});
			InputManager.instance.isLock = !enable;
			FrameSync.instance.isFire = enable;
			yield break;
		}

		// Token: 0x06018F46 RID: 102214 RVA: 0x007D5A98 File Offset: 0x007D3E98
		protected void _initExSkill(int[] skills)
		{
			SkillBarGrid[] collection = DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(false, SkillSystemSourceType.None).ToArray();
			List<SkillBarGrid> list = new List<SkillBarGrid>();
			for (int i = 0; i < skills.Length; i++)
			{
				list.Add(new SkillBarGrid
				{
					id = (ushort)skills[i],
					slot = (byte)(i + 1)
				});
			}
			DataManager<SkillDataManager>.GetInstance().SetPvePage1SkillBar(list);
			base._reLoadSkillButton();
			base._hiddenInputManagerJump();
			if (this.mDungeonPlayers == null)
			{
				return;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			for (int j = 0; j < skills.Length; j++)
			{
				if (!mainPlayer.playerActor.HasSkill(skills[j]))
				{
					mainPlayer.playerActor.LoadOneSkill(skills[j], this._getSkillLevel());
				}
			}
			foreach (KeyValuePair<int, BeSkill> keyValuePair in mainPlayer.playerActor.GetSkills())
			{
				keyValuePair.Value.level = this._getSkillLevel();
				keyValuePair.Value.cdReduceRate = new VRate(this._getSkillCDReduceRate());
			}
			DataManager<SkillDataManager>.GetInstance().SetPvePage1SkillBar(new List<SkillBarGrid>(collection));
		}

		// Token: 0x06018F47 RID: 102215 RVA: 0x007D5BF0 File Offset: 0x007D3FF0
		protected void _hideExSkill(int[] skills, int start, int end)
		{
			if (this.mInputManager == null)
			{
				return;
			}
			int num = start;
			while (num <= end && num < skills.Length)
			{
				this.mInputManager.GetETCButton(skills[num]).gameObject.transform.localScale = Vector3.zero;
				num++;
			}
		}

		// Token: 0x06018F48 RID: 102216 RVA: 0x007D5C48 File Offset: 0x007D4048
		protected IEnumerator _addExSkillEx(int[] skills, int start, int end)
		{
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			List<GameObject> objList = new List<GameObject>();
			yield return Yielders.EndOfFrame;
			if (this.mInputManager == null)
			{
				yield break;
			}
			for (int i = start; i <= end; i++)
			{
				yield return this._GuideShowSkill(this.mInputManager.GetETCButton(skills[i]).gameObject, 0.1f);
				yield return Yielders.GetWaitForSeconds(0.05f);
			}
			yield return Yielders.GetWaitForSeconds(0f);
			for (int j = 0; j < objList.Count; j++)
			{
				Object.Destroy(objList[j]);
			}
			objList.Clear();
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.ResumeFight(true, string.Empty, false);
			yield break;
		}

		// Token: 0x06018F49 RID: 102217 RVA: 0x007D5C78 File Offset: 0x007D4078
		protected virtual int _getSkillLevel()
		{
			return 1;
		}

		// Token: 0x06018F4A RID: 102218 RVA: 0x007D5C7B File Offset: 0x007D407B
		protected virtual float _getSkillCDReduceRate()
		{
			return 0f;
		}

		// Token: 0x06018F4B RID: 102219 RVA: 0x007D5C84 File Offset: 0x007D4084
		protected IEnumerator _addExSkill(int[] skills, float wait = 2f, bool isHidden = false)
		{
			this.Log("_addExSkill {0} {1} {2}", new object[]
			{
				skills,
				wait,
				isHidden
			});
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			SkillBarGrid[] bklist = DataManager<SkillDataManager>.GetInstance().GetCurSkillBar(false, SkillSystemSourceType.None).ToArray();
			List<SkillBarGrid> list = new List<SkillBarGrid>();
			for (int j = 0; j < skills.Length; j++)
			{
				list.Add(new SkillBarGrid
				{
					id = (ushort)skills[j],
					slot = (byte)(j + 1)
				});
			}
			DataManager<SkillDataManager>.GetInstance().SetPvePage1SkillBar(list);
			base._reLoadSkillButton();
			base._hiddenInputManagerJump();
			if (this.mInputManager != null)
			{
				for (int k = 0; k < skills.Length; k++)
				{
					this.mInputManager.GetETCButton(skills[k]).gameObject.transform.localScale = Vector3.zero;
				}
				if (isHidden)
				{
					this.mInputManager.SetVisible(false);
				}
			}
			yield return Yielders.EndOfFrame;
			if (this.mDungeonPlayers == null)
			{
				yield break;
			}
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			for (int l = 0; l < skills.Length; l++)
			{
				if (!mainPlayer.playerActor.HasSkill(skills[l]))
				{
					mainPlayer.playerActor.LoadOneSkill(skills[l], this._getSkillLevel());
				}
			}
			foreach (KeyValuePair<int, BeSkill> keyValuePair in mainPlayer.playerActor.GetSkills())
			{
				keyValuePair.Value.level = this._getSkillLevel();
				keyValuePair.Value.cdReduceRate = new VRate(this._getSkillCDReduceRate());
			}
			yield return Yielders.EndOfFrame;
			DataManager<SkillDataManager>.GetInstance().SetPvePage1SkillBar(new List<SkillBarGrid>(bklist));
			List<GameObject> objList = new List<GameObject>();
			if (this.mInputManager != null)
			{
				for (int i = 0; i < skills.Length; i++)
				{
					yield return this._GuideShowSkill(this.mInputManager.GetETCButton(skills[i]).gameObject, 0.1f);
					yield return Yielders.GetWaitForSeconds(0.05f);
				}
			}
			yield return Yielders.GetWaitForSeconds(0f);
			for (int m = 0; m < objList.Count; m++)
			{
				Object.Destroy(objList[m]);
			}
			objList.Clear();
			this.mDungeonManager.ResumeFight(true, string.Empty, false);
			yield break;
		}

		// Token: 0x06018F4C RID: 102220 RVA: 0x007D5CB4 File Offset: 0x007D40B4
		private void _createSkillFrameCommand(int skillID, int value)
		{
			SkillFrameCommand skillFrameCommand = new SkillFrameCommand();
			skillFrameCommand.frame = 0U;
			skillFrameCommand.skillSolt = (uint)skillID;
			skillFrameCommand.skillSlotUp = (uint)value;
			FrameSync.instance.FireFrameCommand(skillFrameCommand, false);
		}

		// Token: 0x06018F4D RID: 102221 RVA: 0x007D5CE8 File Offset: 0x007D40E8
		protected IEnumerator _useFinalSkill(int skill, float time, ActorOccupation newJob)
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			GeActorEx geActor = mainPlayer.playerActor.m_pkGeActor;
			yield return Yielders.EndOfFrame;
			mainPlayer.playerActor.LoadOneSkill(skill, 35);
			yield return Yielders.EndOfFrame;
			this.mDungeonManager.PauseFight(true, string.Empty, false);
			Type type = typeof(NewbieGuideFinalSkillTipsFrame);
			if (!Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				NewbieGuideFinalSkillTipsFrame newbieGuideFinalSkillTipsFrame = Singleton<ClientSystemManager>.instance.OpenFrame(type, FrameLayer.Middle, null, string.Empty) as NewbieGuideFinalSkillTipsFrame;
				newbieGuideFinalSkillTipsFrame.SetSkill(skill);
			}
			while (Singleton<ClientSystemManager>.instance.IsFrameOpen(type))
			{
				yield return Yielders.EndOfFrame;
			}
			this.mDungeonManager.ResumeFight(true, string.Empty, false);
			yield return Yielders.EndOfFrame;
			List<BeEntity> elist = this.mDungeonManager.GetBeScene().GetFullEntities();
			for (int i = 0; i < elist.Count; i++)
			{
				elist[i].Reset();
				if (elist[i].m_iCamp == 1)
				{
					elist[i].hasAI = false;
				}
			}
			yield return Yielders.EndOfFrame;
			mainPlayer.playerActor.Reset();
			yield return Yielders.EndOfFrame;
			mainPlayer.playerActor.buffController.TryAddBuff(2, (int)(time * 1000f), 1);
			yield return Yielders.EndOfFrame;
			this._createSkillFrameCommand(skill, 0);
			yield return Yielders.EndOfFrame;
			this._createSkillFrameCommand(skill, 1);
			yield return Yielders.GetWaitForSeconds(time);
			yield break;
		}

		// Token: 0x06018F4E RID: 102222 RVA: 0x007D5D14 File Offset: 0x007D4114
		protected IEnumerator _createAPC(int id, int level, int skillID)
		{
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			AccompanyData data;
			data.id = id;
			data.level = level;
			data.skillID = skillID;
			mainPlayer.playerActor.SummonHelp(data);
			yield break;
		}

		// Token: 0x06018F4F RID: 102223 RVA: 0x007D5D44 File Offset: 0x007D4144
		protected IEnumerator _resetCamera(float time)
		{
			this.Log("_resetCamera time{0}", new object[]
			{
				time
			});
			yield return this._moveCameraTo(-this.mMoveX, time, 1);
			yield break;
		}

		// Token: 0x06018F50 RID: 102224 RVA: 0x007D5D68 File Offset: 0x007D4168
		protected IEnumerator _moveCameraTo(float x, float time, Ease type = 1)
		{
			this.Log("_moveCameraTo x{0} time {1} type {2}", new object[]
			{
				x,
				time,
				type
			});
			this.mMoveX += x;
			if (this.mDungeonManager == null)
			{
				yield break;
			}
			GeSceneEx scene = this.mDungeonManager.GetBeScene().currentGeScene;
			GeCamera camera = scene.GetCamera();
			GameObject obj = camera.GetCamera().gameObject;
			Vector3 originPos = obj.transform.localPosition;
			Vector3 toPos = new Vector3(originPos.x + x, originPos.y, originPos.z);
			if (time <= 0f)
			{
				obj.transform.localPosition = toPos;
				yield break;
			}
			yield return null;
			TweenerCore<Vector3, Vector3, VectorOptions> dt = TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => originPos, delegate(Vector3 r)
			{
				obj.transform.localPosition = r;
			}, toPos, time), type);
			yield return Yielders.GetWaitForSeconds(time);
			yield break;
		}

		// Token: 0x06018F51 RID: 102225 RVA: 0x007D5D98 File Offset: 0x007D4198
		protected IEnumerator _waitSpriteTips(string path, float delay, bool pauseGame)
		{
			if (pauseGame)
			{
				this.mDungeonManager.PauseFight(true, string.Empty, false);
			}
			NewbieGuideImageTips frame = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuideImageTips>(FrameLayer.Middle, null, string.Empty) as NewbieGuideImageTips;
			frame.SetSprite(path);
			while (delay > 0f && Singleton<ClientSystemManager>.instance.IsFrameOpen(typeof(NewbieGuideImageTips)))
			{
				delay -= Time.deltaTime;
				yield return Yielders.EndOfFrame;
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuideImageTips>(null, false);
			if (pauseGame)
			{
				this.mDungeonManager.ResumeFight(true, string.Empty, false);
			}
			yield break;
		}

		// Token: 0x06018F52 RID: 102226 RVA: 0x007D5DC8 File Offset: 0x007D41C8
		public GameObject LoadUIEffect(GameObject parent, string path, bool bKeep = true)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (bKeep)
			{
				Utility.AttachTo(gameObject, parent, false);
			}
			else
			{
				Utility.AttachTo(gameObject, parent.transform.parent.gameObject, false);
				RectTransform component = parent.GetComponent<RectTransform>();
				RectTransform component2 = gameObject.GetComponent<RectTransform>();
				component2.position = component.position;
			}
			gameObject.transform.SetAsLastSibling();
			return gameObject;
		}

		// Token: 0x06018F53 RID: 102227 RVA: 0x007D5E34 File Offset: 0x007D4234
		protected IEnumerator _addComboSkillTips(string path, BaseNewbieGuideBattle.ComboSkillUnit[] skills)
		{
			this.mInputManager.SetEnable(true);
			BattlePlayer mainPlayers = this.mDungeonPlayers.GetMainPlayer();
			yield return Yielders.EndOfFrame;
			for (int i = 0; i < skills.Length; i++)
			{
				SkillTable table = Singleton<TableManager>.instance.GetTableItem<SkillTable>(skills[i].skill, string.Empty, string.Empty);
				if (table != null)
				{
					ETCButton etcbutton = null;
					if (table.SkillCategory == 1)
					{
						etcbutton = this.mInputManager.GetSpecialETCButton(SpecialSkillID.NORMAL_ATTACK);
					}
					else
					{
						etcbutton = this.mInputManager.GetETCButton(skills[i].skill);
					}
					if (etcbutton != null)
					{
						this.mDungeonManager.PauseFight(true, string.Empty, false);
						yield return Yielders.EndOfFrame;
						NewbieGuideUseSkillFrame useskill = Singleton<ClientSystemManager>.instance.OpenFrame<NewbieGuideUseSkillFrame>(FrameLayer.Middle, null, string.Empty) as NewbieGuideUseSkillFrame;
						Vector3 pos = Vector3.zero;
						pos = etcbutton.transform.position;
						GameObject useskillShow = this.LoadUIEffect(etcbutton.gameObject, "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle", true);
						useskill.SetSkill(skills[i].skill, pos, etcbutton.GetComponent<RectTransform>().sizeDelta);
						while (Singleton<ClientSystemManager>.instance.IsFrameOpen(typeof(NewbieGuideUseSkillFrame)))
						{
							yield return Yielders.EndOfFrame;
						}
						Object.Destroy(useskillShow);
						useskillShow = null;
						this.mDungeonManager.ResumeFight(true, string.Empty, false);
						yield return Yielders.EndOfFrame;
						Singleton<ClientSystemManager>.instance.CloseFrame<NewbieGuidTipsFrame>(null, false);
						BeSkill skill = mainPlayers.playerActor.GetSkill(skills[i].skill);
						skill.ResetCoolDown();
						yield return Yielders.EndOfFrame;
						mainPlayers.playerActor.UseSkill(skills[i].skill, true);
						yield return Yielders.GetWaitForSeconds(skills[i].time);
					}
				}
			}
			yield break;
		}

		// Token: 0x06018F54 RID: 102228 RVA: 0x007D5E58 File Offset: 0x007D4258
		protected IEnumerator _removeComboSkillTips()
		{
			BattlePlayer mainPlayers = this.mDungeonPlayers.GetMainPlayer();
			mainPlayers.playerActor.m_pkGeActor.RemoveComboTips();
			yield return Yielders.EndOfFrame;
			yield break;
		}

		// Token: 0x06018F55 RID: 102229 RVA: 0x007D5E73 File Offset: 0x007D4273
		protected virtual IEnumerator _startGuide()
		{
			return null;
		}

		// Token: 0x04011EEF RID: 73455
		private Coroutine mCoroutine;

		// Token: 0x04011EF0 RID: 73456
		private AnimationCurve skillButtonShow = new AnimationCurve(new Keyframe[]
		{
			new Keyframe(0f, 0f),
			new Keyframe(0.75f, 1.5f),
			new Keyframe(1f, 1f)
		});

		// Token: 0x04011EF1 RID: 73457
		private int step;

		// Token: 0x04011EF2 RID: 73458
		private VFactor mBackupZDimFactor = VFactor.one;

		// Token: 0x04011EF3 RID: 73459
		private bool mBackupBossCamera;

		// Token: 0x04011EF4 RID: 73460
		protected BeActor mBossActor;

		// Token: 0x04011EF5 RID: 73461
		protected BeActor mEliteMonster;

		// Token: 0x04011EF6 RID: 73462
		private BeEventHandle mBossHurtHandler;

		// Token: 0x04011EF7 RID: 73463
		public const float waitTime = 0f;

		// Token: 0x04011EF8 RID: 73464
		protected float mMoveX;

		// Token: 0x04011EF9 RID: 73465
		public const string fingerPath = "UIFlatten/Prefabs/NewbieGuide/FingerMove";

		// Token: 0x04011EFA RID: 73466
		public const string fingerDoublePath = "UIFlatten/Prefabs/NewbieGuide/FingerDoubleMove";

		// Token: 0x04011EFB RID: 73467
		public const string buttonTips = "UIFlatten/Prefabs/NewbieGuide/ButtonTipsNoButton_newbiebattle";

		// Token: 0x020045AB RID: 17835
		protected class ComboSkillUnit
		{
			// Token: 0x06018F56 RID: 102230 RVA: 0x007D5E76 File Offset: 0x007D4276
			public ComboSkillUnit(int skill, float time, string text = "")
			{
				this.skill = skill;
				this.time = time;
				this.text = text;
			}

			// Token: 0x04011EFC RID: 73468
			public int skill = 1;

			// Token: 0x04011EFD RID: 73469
			public float time = 0.5f;

			// Token: 0x04011EFE RID: 73470
			public string text;
		}
	}
}
