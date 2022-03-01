using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452D RID: 17709
	public class DungeonProcess : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A60 RID: 100960 RVA: 0x007B1757 File Offset: 0x007AFB57
		public FrameCommandID GetID()
		{
			return FrameCommandID.TeamCopyBimsProgress;
		}

		// Token: 0x06018A61 RID: 100961 RVA: 0x007B175B File Offset: 0x007AFB5B
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A62 RID: 100962 RVA: 0x007B1764 File Offset: 0x007AFB64
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			RaidBattle raidBattle = this.battle as RaidBattle;
			if (raidBattle != null && this.dungeonID != -1)
			{
				raidBattle.SetDungeonRecoverProcess(this.dungeonID, this.process);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A63 RID: 100963 RVA: 0x007B17D0 File Offset: 0x007AFBD0
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 26U,
				data2 = (uint)this.process,
				data3 = (uint)this.dungeonID
			};
		}

		// Token: 0x06018A64 RID: 100964 RVA: 0x007B1806 File Offset: 0x007AFC06
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.process = (int)data.data2;
			this.dungeonID = (int)data.data3;
		}

		// Token: 0x06018A65 RID: 100965 RVA: 0x007B1830 File Offset: 0x007AFC30
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} DungeonProcess dungeonID:{2} process:{3}", new object[]
			{
				this.frame,
				this.seat,
				this.dungeonID,
				this.process
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A66 RID: 100966 RVA: 0x007B18A6 File Offset: 0x007AFCA6
		public void Reset()
		{
			base.BaseReset();
			this.dungeonID = -1;
			this.process = 0;
		}

		// Token: 0x04011C2C RID: 72748
		public int dungeonID = -1;

		// Token: 0x04011C2D RID: 72749
		public int process;
	}
}
