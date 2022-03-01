using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004520 RID: 17696
	public class ReconnectFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189F8 RID: 100856 RVA: 0x007B0070 File Offset: 0x007AE470
		public FrameCommandID GetID()
		{
			return FrameCommandID.ReconnectEnd;
		}

		// Token: 0x060189F9 RID: 100857 RVA: 0x007B0073 File Offset: 0x007AE473
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189FA RID: 100858 RVA: 0x007B007C File Offset: 0x007AE47C
		public void ExecCommand()
		{
			if (!base.isValid())
			{
				return;
			}
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			BattlePlayer mainPlayer = this.battle.dungeonPlayerManager.GetMainPlayer();
			BattlePlayer playerBySeat = this.battle.dungeonPlayerManager.GetPlayerBySeat(this.seat);
			if (playerBySeat != null && mainPlayer != null)
			{
				BeActor playerActor = playerBySeat.playerActor;
				if (playerActor != null && playerActor.IsProcessRecord())
				{
					base.Record(playerBySeat.playerActor, "reconnect" + this.GetString());
				}
				if (playerActor != null && playerActor.IsProcessRecord())
				{
					playerActor.GetRecordServer().MarkString(311952005U, new string[]
					{
						playerBySeat.playerInfo.name
					});
				}
				if (mainPlayer.playerInfo.seat == this.seat)
				{
					SystemNotifyManager.SystemNotify(8304, string.Empty);
				}
				else
				{
					SystemNotifyManager.SystemNotify(8302, playerBySeat.playerInfo.name);
				}
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x060189FB RID: 100859 RVA: 0x007B01A0 File Offset: 0x007AE5A0
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 7U,
				data2 = 0U,
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189FC RID: 100860 RVA: 0x007B01D7 File Offset: 0x007AE5D7
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x060189FD RID: 100861 RVA: 0x007B01E8 File Offset: 0x007AE5E8
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} reconnect", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189FE RID: 100862 RVA: 0x007B0236 File Offset: 0x007AE636
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
