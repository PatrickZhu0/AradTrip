using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045B5 RID: 17845
	public class MoneyRewardsPVPBattle : PVPBattle
	{
		// Token: 0x06018FE4 RID: 102372 RVA: 0x007DFF28 File Offset: 0x007DE328
		public MoneyRewardsPVPBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018FE5 RID: 102373 RVA: 0x007DFF34 File Offset: 0x007DE334
		public override void _postCreatePlayer()
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					BeEntityData entityData = allPlayers[i].playerActor.GetEntityData();
					float num = allPlayers[i].playerInfo.remainHp / (float)GlobalLogic.VALUE_1000;
					num = Mathf.Clamp01(num);
					entityData.SetHP(IntMath.Float2Int(num * (float)entityData.GetMaxHP()));
					playerActor.m_pkGeActor.SetHPValue(num);
				}
			}
		}

		// Token: 0x06018FE6 RID: 102374 RVA: 0x007DFFD0 File Offset: 0x007DE3D0
		[MessageHandle(607712U, false, 0)]
		private void OnRecvWorldPremiumLeagueRaceEnd(MsgDATA msg)
		{
			WorldPremiumLeagueRaceEnd worldPremiumLeagueRaceEnd = new WorldPremiumLeagueRaceEnd();
			worldPremiumLeagueRaceEnd.decode(msg.bytes);
			this.mDungeonManager.FinishFight();
			BattleMain.instance.End();
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("LeagueRaceEnd");
			}
			bool flag = worldPremiumLeagueRaceEnd.result == 1;
			if (flag)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsWinFrame>(FrameLayer.Middle, worldPremiumLeagueRaceEnd, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MoneyRewardsLoseFrame>(FrameLayer.Middle, worldPremiumLeagueRaceEnd, string.Empty);
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().EndReplay(true, "LeagueRaceEnd Replay");
			}
		}

		// Token: 0x04011F39 RID: 73529
		private BeEventHandle m_handler;
	}
}
