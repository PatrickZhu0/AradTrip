using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02004514 RID: 17684
	public class MatchRoundVote : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x17002014 RID: 8212
		// (get) Token: 0x06018997 RID: 100759 RVA: 0x007AE881 File Offset: 0x007ACC81
		// (set) Token: 0x06018996 RID: 100758 RVA: 0x007AE878 File Offset: 0x007ACC78
		public bool isVote { get; set; }

		// Token: 0x06018998 RID: 100760 RVA: 0x007AE88C File Offset: 0x007ACC8C
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			if (base.isValid())
			{
				IDungeonPlayerDataManager dungeonPlayerManager = this.battle.dungeonPlayerManager;
				if (dungeonPlayerManager != null)
				{
					dungeonPlayerManager.SetPlayerVoteFightState(this.seat, this.isVote);
				}
				else
				{
					Logger.LogErrorFormat("[MatchRoundVote] 出战投票 无法找到玩家数据管理 {0} {1}", new object[]
					{
						this.seat,
						this.isVote
					});
				}
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018999 RID: 100761 RVA: 0x007AE926 File Offset: 0x007ACD26
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x0601899A RID: 100762 RVA: 0x007AE92E File Offset: 0x007ACD2E
		public FrameCommandID GetID()
		{
			return FrameCommandID.MatchRoundVote;
		}

		// Token: 0x0601899B RID: 100763 RVA: 0x007AE934 File Offset: 0x007ACD34
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 19U,
				data2 = ((!this.isVote) ? 0U : 1U),
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x0601899C RID: 100764 RVA: 0x007AE97D File Offset: 0x007ACD7D
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.isVote = (data.data2 != 0U);
		}

		// Token: 0x0601899D RID: 100765 RVA: 0x007AE99F File Offset: 0x007ACD9F
		public string GetString()
		{
			return string.Format("[MatchRoundVote] {0} {1}", this.seat, this.isVote);
		}

		// Token: 0x0601899E RID: 100766 RVA: 0x007AE9C1 File Offset: 0x007ACDC1
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
