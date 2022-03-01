using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200451F RID: 17695
	public class RebornFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189F0 RID: 100848 RVA: 0x007AFDF5 File Offset: 0x007AE1F5
		public FrameCommandID GetID()
		{
			return FrameCommandID.Reborn;
		}

		// Token: 0x060189F1 RID: 100849 RVA: 0x007AFDF8 File Offset: 0x007AE1F8
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189F2 RID: 100850 RVA: 0x007AFE00 File Offset: 0x007AE200
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.targetSeat);
			if (actorBySeat != null)
			{
				if (actorBySeat != null && actorBySeat.IsProcessRecord())
				{
					base.Record(actorBySeat, this.GetString());
				}
				if (!actorBySeat.IsDead())
				{
					Logger.LogErrorFormat("cmd:reborn frame:{0} targetSeat:{1} actor is not dead!", new object[]
					{
						this.frame,
						this.targetSeat
					});
				}
				IOnExecCommand battle = this.battle;
				if (battle != null)
				{
					battle.AfterExecFrameCommand(this.seat, this);
				}
				actorBySeat.Reborn();
				if (this.seat != this.targetSeat)
				{
					BattlePlayer mainPlayer = this.battle.dungeonPlayerManager.GetMainPlayer();
					BattlePlayer playerBySeat = this.battle.dungeonPlayerManager.GetPlayerBySeat(this.seat);
					BattlePlayer playerBySeat2 = this.battle.dungeonPlayerManager.GetPlayerBySeat(this.targetSeat);
					if (playerBySeat2.playerInfo.seat == mainPlayer.playerInfo.seat)
					{
						SystemNotifyManager.SystemNotify(8101, playerBySeat.playerInfo.name);
					}
					else if (playerBySeat.playerInfo.seat == mainPlayer.playerInfo.seat)
					{
						SystemNotifyManager.SystemNotify(8102, playerBySeat2.playerInfo.name);
					}
					else
					{
						SystemNotifyManager.SystemNotify(8103, new object[]
						{
							playerBySeat.playerInfo.name,
							playerBySeat2.playerInfo.name
						});
					}
				}
			}
			else
			{
				Logger.LogErrorFormat("cmd:reborn frame:{0} targetSeat:{1} actor is null!", new object[]
				{
					this.frame,
					this.targetSeat
				});
			}
		}

		// Token: 0x060189F3 RID: 100851 RVA: 0x007AFFB0 File Offset: 0x007AE3B0
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 5U,
				data2 = (uint)this.targetSeat,
				data3 = 0U
			};
		}

		// Token: 0x060189F4 RID: 100852 RVA: 0x007AFFE0 File Offset: 0x007AE3E0
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.targetSeat = (byte)data.data2;
		}

		// Token: 0x060189F5 RID: 100853 RVA: 0x007B0000 File Offset: 0x007AE400
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Reborn targetSeat:{2}", this.frame, this.seat, this.targetSeat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189F6 RID: 100854 RVA: 0x007B0059 File Offset: 0x007AE459
		public void Reset()
		{
			base.BaseReset();
			this.targetSeat = 0;
		}

		// Token: 0x04011C12 RID: 72722
		public byte targetSeat;
	}
}
