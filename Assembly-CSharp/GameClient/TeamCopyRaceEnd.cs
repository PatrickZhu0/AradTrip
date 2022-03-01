using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200452C RID: 17708
	public class TeamCopyRaceEnd : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A58 RID: 100952 RVA: 0x007B161B File Offset: 0x007AFA1B
		public FrameCommandID GetID()
		{
			return FrameCommandID.TeamCopyRaceEnd;
		}

		// Token: 0x06018A59 RID: 100953 RVA: 0x007B161F File Offset: 0x007AFA1F
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A5A RID: 100954 RVA: 0x007B1628 File Offset: 0x007AFA28
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().Stop(true, "TeamCopyRaceEndCmd");
			}
		}

		// Token: 0x06018A5B RID: 100955 RVA: 0x007B168C File Offset: 0x007AFA8C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 25U,
				data2 = (uint)this.reason,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A5C RID: 100956 RVA: 0x007B16C2 File Offset: 0x007AFAC2
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.reason = (int)data.data2;
		}

		// Token: 0x06018A5D RID: 100957 RVA: 0x007B16E0 File Offset: 0x007AFAE0
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} TeamCopyRaceEnd reason:{2}", this.frame, this.seat, this.reason);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A5E RID: 100958 RVA: 0x007B1739 File Offset: 0x007AFB39
		public void Reset()
		{
			base.BaseReset();
			this.reason = -1;
		}

		// Token: 0x04011C2B RID: 72747
		public int reason = -1;
	}
}
