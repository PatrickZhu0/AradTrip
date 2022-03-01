using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452B RID: 17707
	public class DungeonDestory : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A50 RID: 100944 RVA: 0x007B14EB File Offset: 0x007AF8EB
		public FrameCommandID GetID()
		{
			return FrameCommandID.DungeonDestory;
		}

		// Token: 0x06018A51 RID: 100945 RVA: 0x007B14EF File Offset: 0x007AF8EF
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A52 RID: 100946 RVA: 0x007B14F8 File Offset: 0x007AF8F8
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
				raidBattle.DungeonDestroyNotify(this.dungeonID);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A53 RID: 100947 RVA: 0x007B155C File Offset: 0x007AF95C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 24U,
				data2 = (uint)this.dungeonID
			};
		}

		// Token: 0x06018A54 RID: 100948 RVA: 0x007B1586 File Offset: 0x007AF986
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.dungeonID = (int)data.data2;
		}

		// Token: 0x06018A55 RID: 100949 RVA: 0x007B15A4 File Offset: 0x007AF9A4
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} DungeonDestory dungeonID:{2}", this.frame, this.seat, this.dungeonID);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A56 RID: 100950 RVA: 0x007B15FD File Offset: 0x007AF9FD
		public void Reset()
		{
			base.BaseReset();
			this.dungeonID = -1;
		}

		// Token: 0x04011C2A RID: 72746
		public int dungeonID = -1;
	}
}
