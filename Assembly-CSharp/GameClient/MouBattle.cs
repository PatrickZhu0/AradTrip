using System;
using System.Collections;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045B6 RID: 17846
	public class MouBattle : ActivityBattle
	{
		// Token: 0x06018FE7 RID: 102375 RVA: 0x007DC00C File Offset: 0x007DA40C
		public MouBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018FE8 RID: 102376 RVA: 0x007DC017 File Offset: 0x007DA417
		protected override void _onCreateScene(object[] args)
		{
			base._onCreateScene(args);
			if (!this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
			}
		}

		// Token: 0x06018FE9 RID: 102377 RVA: 0x007DC038 File Offset: 0x007DA438
		protected override void _onAreaClear(object[] args)
		{
			if (this.mDungeonManager.GetDungeonDataManager().IsBossArea())
			{
				base._sendDungeonKillMonsterReq();
				base._sendDungeonRewardReq();
				base._sendDungeonBossRewardReq();
				this.mDungeonManager.FinishFight();
				if (this.mCurCoroutin == null)
				{
					this.mCurCoroutin = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._successEnd());
				}
			}
		}

		// Token: 0x06018FEA RID: 102378 RVA: 0x007DC098 File Offset: 0x007DA498
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.mCurCoroutin == null)
			{
				this.mCurCoroutin = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._failEnd());
			}
		}

		// Token: 0x06018FEB RID: 102379 RVA: 0x007DC0D8 File Offset: 0x007DA4D8
		protected IEnumerator _failEnd()
		{
			base.PveBattleResult = BattleResult.Fail;
			base._openFinishFrame<DungeonCommonFailFrame>();
			base._setFinish(false);
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
			yield return Yielders.EndOfFrame;
			if (base._isNeedSendNet())
			{
				SceneDungeonRaceEndReq req = this._getDungeonRaceEndReq();
				SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
				MessageEvents msg = new MessageEvents();
				yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f, 3, 3);
				if (msg.IsAllMessageReceived())
				{
					base._setExp((ulong)(res.killMonsterTotalExp + res.raceEndExp));
					base._setDrop(null);
				}
			}
			else
			{
				base._setExp(10UL);
				base._setExp(1000UL);
				base._setDrop(null);
			}
			yield break;
		}

		// Token: 0x06018FEC RID: 102380 RVA: 0x007DC0F3 File Offset: 0x007DA4F3
		protected override void _onEnd()
		{
			base._onEnd();
			if (this.mCurCoroutin != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCurCoroutin);
				this.mCurCoroutin = null;
			}
		}

		// Token: 0x06018FED RID: 102381 RVA: 0x007DC120 File Offset: 0x007DA520
		protected IEnumerator _successEnd()
		{
			base.PveBattleResult = BattleResult.Success;
			base._openFinishFrame<DungeonGoldRushFinishFrame>();
			base._setFinish(true);
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
			yield return Yielders.EndOfFrame;
			if (base._isNeedSendNet())
			{
				SceneDungeonRaceEndReq req = this._getDungeonRaceEndReq();
				SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
				MessageEvents msg = new MessageEvents();
				yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f, 3, 3);
				if (msg.IsAllMessageReceived())
				{
					if (res.hasRaceEndDrop != 0)
					{
						yield return base._requestRaceEndDrops((int)res.raceEndDropBaseMulti);
					}
					base._setExp((ulong)(res.killMonsterTotalExp + res.raceEndExp));
					base._setDrop(base._getAllRewardItems(res).ToArray());
				}
			}
			else
			{
				base._setExp(10UL);
				base._setExp(1000UL);
				base._setDrop(null);
			}
			yield break;
		}

		// Token: 0x04011F3A RID: 73530
		private Coroutine mCurCoroutin;
	}
}
