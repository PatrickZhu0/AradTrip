using System;
using System.Text;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02004518 RID: 17688
	public class PlayerQuitCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189B8 RID: 100792 RVA: 0x007AED30 File Offset: 0x007AD130
		public FrameCommandID GetID()
		{
			return FrameCommandID.PlayerQuit;
		}

		// Token: 0x060189B9 RID: 100793 RVA: 0x007AED34 File Offset: 0x007AD134
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189BA RID: 100794 RVA: 0x007AED3C File Offset: 0x007AD13C
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (SwitchFunctionUtility.IsOpen(10) && actorBySeat != null && this.battle != null && this.battle.GetBattleType() == BattleType.Hell)
			{
				actorBySeat.SetAutoFight(true);
				if (this.battle.dungeonPlayerManager != null)
				{
					BattlePlayer playerBySeat = this.battle.dungeonPlayerManager.GetPlayerBySeat(this.seat);
					if (playerBySeat != null && playerBySeat.playerInfo != null)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("hell_player_quit", playerBySeat.playerInfo.name), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
			}
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, "[PlayerQuit]" + this.GetString());
			}
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x060189BB RID: 100795 RVA: 0x007AEE38 File Offset: 0x007AD238
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 12U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189BC RID: 100796 RVA: 0x007AEE62 File Offset: 0x007AD262
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x060189BD RID: 100797 RVA: 0x007AEE74 File Offset: 0x007AD274
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} PlayerQuit !!", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189BE RID: 100798 RVA: 0x007AEEC2 File Offset: 0x007AD2C2
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
