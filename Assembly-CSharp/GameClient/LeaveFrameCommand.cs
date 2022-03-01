using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004522 RID: 17698
	public class LeaveFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A08 RID: 100872 RVA: 0x007B0374 File Offset: 0x007AE774
		public FrameCommandID GetID()
		{
			return FrameCommandID.Leave;
		}

		// Token: 0x06018A09 RID: 100873 RVA: 0x007B0377 File Offset: 0x007AE777
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A0A RID: 100874 RVA: 0x007B0380 File Offset: 0x007AE780
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			if (this.battle == null || this.battle.dungeonPlayerManager == null)
			{
				return;
			}
			BattlePlayer mainPlayer = this.battle.dungeonPlayerManager.GetMainPlayer();
			BattlePlayer playerBySeat = this.battle.dungeonPlayerManager.GetPlayerBySeat(this.seat);
			if (playerBySeat != null && mainPlayer != null)
			{
				BeActor playerActor = playerBySeat.playerActor;
				if (playerActor != null && playerActor.IsProcessRecord())
				{
					base.Record(playerBySeat.playerActor, this.GetString());
				}
				if (playerActor != null && playerActor.IsProcessRecord())
				{
					playerActor.GetRecordServer().MarkString(125278210U, new string[]
					{
						playerBySeat.playerInfo.name
					});
				}
				if (mainPlayer.playerInfo.seat != this.seat)
				{
					SystemNotifyManager.SystemNotify(8301, playerBySeat.playerInfo.name);
				}
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A0B RID: 100875 RVA: 0x007B049C File Offset: 0x007AE89C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 4U,
				data2 = 0U,
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A0C RID: 100876 RVA: 0x007B04D3 File Offset: 0x007AE8D3
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x06018A0D RID: 100877 RVA: 0x007B04E4 File Offset: 0x007AE8E4
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Leave", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A0E RID: 100878 RVA: 0x007B0532 File Offset: 0x007AE932
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
