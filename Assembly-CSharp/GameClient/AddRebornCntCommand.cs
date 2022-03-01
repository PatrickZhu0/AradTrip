using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452E RID: 17710
	public class AddRebornCntCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A68 RID: 100968 RVA: 0x007B18C4 File Offset: 0x007AFCC4
		public FrameCommandID GetID()
		{
			return FrameCommandID.TeamCopyDungeonReviveCnt;
		}

		// Token: 0x06018A69 RID: 100969 RVA: 0x007B18C8 File Offset: 0x007AFCC8
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A6A RID: 100970 RVA: 0x007B18D0 File Offset: 0x007AFCD0
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			RaidBattle raidBattle = this.battle as RaidBattle;
			if (raidBattle != null && this.cnt != 0 && this.battle.IsRebornCountLimit())
			{
				this.battle.AddMaxRebornCount(this.cnt);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A6B RID: 100971 RVA: 0x007B1948 File Offset: 0x007AFD48
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 26U,
				data2 = (uint)this.cnt
			};
		}

		// Token: 0x06018A6C RID: 100972 RVA: 0x007B1972 File Offset: 0x007AFD72
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.cnt = (int)data.data2;
		}

		// Token: 0x06018A6D RID: 100973 RVA: 0x007B1990 File Offset: 0x007AFD90
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} AddRebornCntCommand : AddCount:{2}", this.frame, this.seat, this.cnt);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A6E RID: 100974 RVA: 0x007B19E9 File Offset: 0x007AFDE9
		public void Reset()
		{
			base.BaseReset();
			this.cnt = 0;
		}

		// Token: 0x04011C2E RID: 72750
		public int cnt;
	}
}
