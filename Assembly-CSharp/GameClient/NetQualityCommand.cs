using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004519 RID: 17689
	public class NetQualityCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189C0 RID: 100800 RVA: 0x007AEED2 File Offset: 0x007AD2D2
		public FrameCommandID GetID()
		{
			return FrameCommandID.NetQuality;
		}

		// Token: 0x060189C1 RID: 100801 RVA: 0x007AEED6 File Offset: 0x007AD2D6
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189C2 RID: 100802 RVA: 0x007AEEE0 File Offset: 0x007AD2E0
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, "[NetQuality update]" + this.GetString());
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

		// Token: 0x060189C3 RID: 100803 RVA: 0x007AEF50 File Offset: 0x007AD350
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 14U,
				data2 = this.quality,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189C4 RID: 100804 RVA: 0x007AEF86 File Offset: 0x007AD386
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.quality = data.data2;
		}

		// Token: 0x060189C5 RID: 100805 RVA: 0x007AEFA4 File Offset: 0x007AD3A4
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Quality Change To {2} !!", this.frame, this.seat, this.quality);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189C6 RID: 100806 RVA: 0x007AEFFD File Offset: 0x007AD3FD
		public void Reset()
		{
			base.BaseReset();
			this.quality = 0U;
		}

		// Token: 0x04011C0A RID: 72714
		public uint quality;
	}
}
