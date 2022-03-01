using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045B4 RID: 17844
	public class GuildPVPBattle : PVPBattle
	{
		// Token: 0x06018FE0 RID: 102368 RVA: 0x007DFCBC File Offset: 0x007DE0BC
		public GuildPVPBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018FE1 RID: 102369 RVA: 0x007DFCC8 File Offset: 0x007DE0C8
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

		// Token: 0x06018FE2 RID: 102370 RVA: 0x007DFD64 File Offset: 0x007DE164
		protected override void _createPlayers()
		{
			base._createPlayers();
			BeScene beScene = this.mDungeonManager.GetBeScene();
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			if (DataManager<GuildDataManager>.GetInstance().CurTargetCrossManorIDIsYGWZ())
			{
				for (int i = 0; i < allPlayers.Count; i++)
				{
					if (allPlayers[i] != null && allPlayers[i].playerActor != null && allPlayers[i].playerActor.m_pkGeActor != null && allPlayers[i].playerInfo != null && allPlayers[i].playerInfo.accid != ClientApplication.playerinfo.accid)
					{
						allPlayers[i].playerActor.m_pkGeActor.SetPlayerHPPKBarName(DataManager<GuildDataManager>.GetInstance().GuildPVPBattleHideName);
						allPlayers[i].playerActor.m_pkGeActor.AddTittleComponent(BattlePlayer.GetTitleID(allPlayers[i].playerInfo), DataManager<GuildDataManager>.GetInstance().GuildPVPBattleHideName, 0, string.Empty, (int)allPlayers[i].playerInfo.level, (int)allPlayers[i].playerInfo.seasonLevel, PlayerInfoColor.PK_OTHER_PLAYER, string.Empty, null, 0, 0);
					}
				}
			}
		}

		// Token: 0x06018FE3 RID: 102371 RVA: 0x007DFE9C File Offset: 0x007DE29C
		[MessageHandle(601953U, false, 0)]
		private void _OnWorldGuildBattleRaceEnd(MsgDATA msg)
		{
			WorldGuildBattleRaceEnd worldGuildBattleRaceEnd = new WorldGuildBattleRaceEnd();
			worldGuildBattleRaceEnd.decode(msg.bytes);
			this.mDungeonManager.FinishFight();
			BattleMain.instance.End();
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("GuildBattleRaceEnd");
			}
			bool flag = worldGuildBattleRaceEnd.result == 1;
			if (flag)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleWinFrame>(FrameLayer.Middle, worldGuildBattleRaceEnd, string.Empty);
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildBattleLoseFrame>(FrameLayer.Middle, worldGuildBattleRaceEnd, string.Empty);
			}
		}

		// Token: 0x04011F38 RID: 73528
		private BeEventHandle m_handler;
	}
}
