using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020045AD RID: 17837
	public class ChiJiPVPBattle : PVPBattle
	{
		// Token: 0x06018F68 RID: 102248 RVA: 0x007DAB99 File Offset: 0x007D8F99
		public ChiJiPVPBattle(BattleType type, eDungeonMode mode, int id) : base(type, mode, id)
		{
		}

		// Token: 0x06018F69 RID: 102249 RVA: 0x007DABA4 File Offset: 0x007D8FA4
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
					if (base.recordServer != null && base.recordServer.IsProcessRecord())
					{
						base.recordServer.MarkInt(125269880U, new int[]
						{
							allPlayers[i].playerActor.GetPID(),
							entityData.GetHP(),
							(int)(num * 10000f),
							entityData.GetMaxHP()
						});
					}
				}
			}
		}

		// Token: 0x06018F6A RID: 102250 RVA: 0x007DACA4 File Offset: 0x007D90A4
		[MessageHandle(506705U, false, 0)]
		private void _OnReceiveChijiPkEndData(MsgDATA msg)
		{
			SceneMatchPkRaceEnd sceneMatchPkRaceEnd = new SceneMatchPkRaceEnd();
			sceneMatchPkRaceEnd.decode(msg.bytes);
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().RecordResult(sceneMatchPkRaceEnd);
			}
			BattleMain.instance.End();
			if (Singleton<RecordServer>.GetInstance().IsReplayRecord(false))
			{
				Singleton<RecordServer>.GetInstance().EndRecord("PkEnd");
			}
			DataManager<ChijiDataManager>.GetInstance().PkEndData = sceneMatchPkRaceEnd;
			if (Singleton<ClientSystemManager>.instance.TargetSystem != null)
			{
				DataManager<ChijiDataManager>.GetInstance().GuardForPkEndData = true;
				return;
			}
			DataManager<ChijiDataManager>.GetInstance().ResponseBattleEnd();
		}
	}
}
