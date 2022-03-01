using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452F RID: 17711
	public class CancelRebornCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A70 RID: 100976 RVA: 0x007B1A00 File Offset: 0x007AFE00
		public FrameCommandID GetID()
		{
			return FrameCommandID.CancelReborn;
		}

		// Token: 0x06018A71 RID: 100977 RVA: 0x007B1A04 File Offset: 0x007AFE04
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A72 RID: 100978 RVA: 0x007B1A0C File Offset: 0x007AFE0C
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

		// Token: 0x06018A73 RID: 100979 RVA: 0x007B1A48 File Offset: 0x007AFE48
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 28U
			};
		}

		// Token: 0x06018A74 RID: 100980 RVA: 0x007B1A66 File Offset: 0x007AFE66
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x06018A75 RID: 100981 RVA: 0x007B1A78 File Offset: 0x007AFE78
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} CancelRebornCommand", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A76 RID: 100982 RVA: 0x007B1AC6 File Offset: 0x007AFEC6
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
