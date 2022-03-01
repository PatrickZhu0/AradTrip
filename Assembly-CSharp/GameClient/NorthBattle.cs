using System;
using System.Collections;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045B8 RID: 17848
	public class NorthBattle : ActivityBattle
	{
		// Token: 0x06019051 RID: 102481 RVA: 0x007E6109 File Offset: 0x007E4509
		public NorthBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06019052 RID: 102482 RVA: 0x007E6114 File Offset: 0x007E4514
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
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._successEnd());
				}
			}
		}

		// Token: 0x06019053 RID: 102483 RVA: 0x007E616F File Offset: 0x007E456F
		protected override void _onPlayerCancelReborn(BattlePlayer player)
		{
			if (this.mDungeonManager == null || this.mDungeonManager.IsFinishFight())
			{
				return;
			}
			if (this.mCurCoroutin == null)
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._failEnd());
			}
		}

		// Token: 0x06019054 RID: 102484 RVA: 0x007E61A9 File Offset: 0x007E45A9
		protected override void _onEnd()
		{
			base._onEnd();
			if (this.mCurCoroutin != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCurCoroutin);
				this.mCurCoroutin = null;
			}
		}

		// Token: 0x06019055 RID: 102485 RVA: 0x007E61D4 File Offset: 0x007E45D4
		private IEnumerator _failEnd()
		{
			base._openFinishFrame<DungeonCommonFailFrame>();
			base._setFinish(false);
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
			if (base._isNeedSendNet())
			{
				SceneDungeonRaceEndReq req = this._getDungeonRaceEndReq();
				SceneDungeonRaceEndRes res = new SceneDungeonRaceEndRes();
				MessageEvents msg = new MessageEvents();
				yield return base._sendMsgWithResend<SceneDungeonRaceEndReq, SceneDungeonRaceEndRes>(ServerType.GATE_SERVER, msg, req, res, true, 2f, 3, 3);
				if (msg.IsAllMessageReceived())
				{
					base._setExp((ulong)(res.killMonsterTotalExp + res.raceEndExp));
					if (res.hasRaceEndDrop == 1)
					{
						base._setDrop(null);
					}
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

		// Token: 0x06019056 RID: 102486 RVA: 0x007E61F0 File Offset: 0x007E45F0
		private IEnumerator _successEnd()
		{
			base._openFinishFrame<DungeonNorthFinishFrame>();
			base._setFinish(true);
			yield return base._fireRaceEndOnLocalFrameIter();
			yield return base._sendDungeonReportDataIter(true);
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
						yield return this._endDropItemsIter(ChapterNorthFrame.sMuti);
					}
					base._setExp((ulong)(res.raceEndExp + res.killMonsterTotalExp));
				}
			}
			else
			{
				base._setDrop(new ComItemList.Items[0]);
			}
			yield break;
		}

		// Token: 0x06019057 RID: 102487 RVA: 0x007E620C File Offset: 0x007E460C
		protected IEnumerator _endDropItemsIter(int multi)
		{
			if (!base._isNeedSendNet())
			{
				base._setDrop(new ComItemList.Items[0]);
				yield break;
			}
			MessageEvents msg = new MessageEvents();
			SceneDungeonEndDropReq req = new SceneDungeonEndDropReq();
			SceneDungeonEndDropRes res = new SceneDungeonEndDropRes();
			req.multi = (byte)multi;
			yield return MessageUtility.Wait<SceneDungeonEndDropReq, SceneDungeonEndDropRes>(ServerType.GATE_SERVER, msg, req, res, true, 10f);
			if (msg.IsAllMessageReceived())
			{
				if (res.multi == 0)
				{
					Logger.LogError("fail to get the resutle drop item");
					base._setDrop(new ComItemList.Items[0]);
					yield break;
				}
				ChapterNorthFrame.sMuti = (int)res.multi;
				base._setDrop(base._convertComItemList(res.items));
			}
			yield break;
		}

		// Token: 0x04011F4C RID: 73548
		private Coroutine mCurCoroutin;
	}
}
