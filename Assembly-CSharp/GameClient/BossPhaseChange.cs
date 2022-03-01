using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452A RID: 17706
	public class BossPhaseChange : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A48 RID: 100936 RVA: 0x007B13D5 File Offset: 0x007AF7D5
		public FrameCommandID GetID()
		{
			return FrameCommandID.BossPhaseChange;
		}

		// Token: 0x06018A49 RID: 100937 RVA: 0x007B13D9 File Offset: 0x007AF7D9
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A4A RID: 100938 RVA: 0x007B13E4 File Offset: 0x007AF7E4
		public void ExecCommand()
		{
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

		// Token: 0x06018A4B RID: 100939 RVA: 0x007B1420 File Offset: 0x007AF820
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 23U,
				data2 = (uint)this.phase,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A4C RID: 100940 RVA: 0x007B1456 File Offset: 0x007AF856
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.phase = (int)data.data2;
		}

		// Token: 0x06018A4D RID: 100941 RVA: 0x007B1474 File Offset: 0x007AF874
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} BossPhaseChange phase:{2}", this.frame, this.seat, this.phase);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A4E RID: 100942 RVA: 0x007B14CD File Offset: 0x007AF8CD
		public void Reset()
		{
			base.BaseReset();
			this.phase = -1;
		}

		// Token: 0x04011C29 RID: 72745
		public int phase = -1;
	}
}
