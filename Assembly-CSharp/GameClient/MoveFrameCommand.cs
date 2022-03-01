using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200451B RID: 17691
	public class MoveFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189D0 RID: 100816 RVA: 0x007AF135 File Offset: 0x007AD535
		public FrameCommandID GetID()
		{
			return FrameCommandID.Move;
		}

		// Token: 0x060189D1 RID: 100817 RVA: 0x007AF138 File Offset: 0x007AD538
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189D2 RID: 100818 RVA: 0x007AF140 File Offset: 0x007AD540
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null && !actorBySeat.IsDead())
			{
				if (actorBySeat != null && actorBySeat.IsProcessRecord())
				{
					base.Record(actorBySeat, this.GetString());
				}
				actorBySeat.ModifyMoveDirection(true, this.degree);
				if (this.run)
				{
					actorBySeat.ChangeRunMode(this.run);
				}
				actorBySeat.RecordPressCount();
			}
		}

		// Token: 0x060189D3 RID: 100819 RVA: 0x007AF1B4 File Offset: 0x007AD5B4
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 1U,
				data2 = (uint)this.degree,
				data3 = ((!this.run) ? 0U : 1U),
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189D4 RID: 100820 RVA: 0x007AF202 File Offset: 0x007AD602
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.degree = (short)data.data2;
			this.run = (data.data3 == 1U);
		}

		// Token: 0x060189D5 RID: 100821 RVA: 0x007AF230 File Offset: 0x007AD630
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Move Direction:{2} Run:{3}", new object[]
			{
				this.frame,
				this.seat,
				this.degree,
				this.run
			});
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189D6 RID: 100822 RVA: 0x007AF2A6 File Offset: 0x007AD6A6
		public void Reset()
		{
			base.BaseReset();
			this.degree = 0;
			this.run = false;
		}

		// Token: 0x04011C0C RID: 72716
		public short degree;

		// Token: 0x04011C0D RID: 72717
		public bool run;
	}
}
