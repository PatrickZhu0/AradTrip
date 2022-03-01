using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02004513 RID: 17683
	public class BaseFrameCommand
	{
		// Token: 0x0601898E RID: 100750 RVA: 0x007AE6DC File Offset: 0x007ACADC
		public bool isValid()
		{
			return this.battle != null && this.battle.dungeonPlayerManager != null;
		}

		// Token: 0x0601898F RID: 100751 RVA: 0x007AE6FC File Offset: 0x007ACAFC
		public BeActor GetActorBySeat(byte seatData)
		{
			if (!this.isValid())
			{
				return null;
			}
			BattlePlayer battlePlayer = this.battle.dungeonPlayerManager.GetPlayerBySeat(seatData);
			if (battlePlayer == null)
			{
				battlePlayer = this.battle.dungeonPlayerManager.GetMainPlayer();
			}
			if (battlePlayer == null)
			{
				Logger.LogErrorFormat("Seat error {0}\n", new object[]
				{
					seatData
				});
				return null;
			}
			return battlePlayer.playerActor;
		}

		// Token: 0x06018990 RID: 100752 RVA: 0x007AE766 File Offset: 0x007ACB66
		public void Record(BeActor actor, string cmd)
		{
			if (actor != null && actor.IsProcessRecord())
			{
				actor.GetRecordServer().Mark(142055428U, actor.GetEntityRecordAttribute(), new string[]
				{
					actor.GetName(),
					cmd
				});
			}
		}

		// Token: 0x06018991 RID: 100753 RVA: 0x007AE7A2 File Offset: 0x007ACBA2
		public byte GetSeat()
		{
			return this.seat;
		}

		// Token: 0x06018992 RID: 100754 RVA: 0x007AE7AA File Offset: 0x007ACBAA
		public uint GetSendTime()
		{
			return this.sendTime;
		}

		// Token: 0x06018993 RID: 100755 RVA: 0x007AE7B2 File Offset: 0x007ACBB2
		protected void BaseReset()
		{
			this.frame = 0U;
			this.seat = byte.MaxValue;
			this.sendTime = 0U;
		}

		// Token: 0x06018994 RID: 100756 RVA: 0x007AE7D0 File Offset: 0x007ACBD0
		protected void _callRandomWithHpMp()
		{
			if (!this.isValid())
			{
				return;
			}
			List<BattlePlayer> allPlayers = this.battle.dungeonPlayerManager.GetAllPlayers();
			if (allPlayers == null)
			{
				return;
			}
			for (int i = 0; i < allPlayers.Count; i++)
			{
				BeActor playerActor = allPlayers[i].playerActor;
				if (playerActor != null)
				{
					BeEntityData entityData = playerActor.GetEntityData();
					if (entityData != null)
					{
						this.battle.FrameRandom.RandomCallNum((uint)(entityData.GetMP() / GlobalLogic.VALUE_100));
						this.battle.FrameRandom.RandomCallNum((uint)(entityData.GetHP() / GlobalLogic.VALUE_100));
					}
				}
			}
		}

		// Token: 0x04011C03 RID: 72707
		public uint frame;

		// Token: 0x04011C04 RID: 72708
		public byte seat = byte.MaxValue;

		// Token: 0x04011C05 RID: 72709
		public uint sendTime;

		// Token: 0x04011C06 RID: 72710
		public BaseBattle battle;
	}
}
