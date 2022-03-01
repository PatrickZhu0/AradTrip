using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200451C RID: 17692
	public class StopFrameCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189D8 RID: 100824 RVA: 0x007AF2C4 File Offset: 0x007AD6C4
		public FrameCommandID GetID()
		{
			return FrameCommandID.Stop;
		}

		// Token: 0x060189D9 RID: 100825 RVA: 0x007AF2C7 File Offset: 0x007AD6C7
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189DA RID: 100826 RVA: 0x007AF2D0 File Offset: 0x007AD6D0
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null)
			{
				if (actorBySeat != null && actorBySeat.IsProcessRecord())
				{
					base.Record(actorBySeat, this.GetString());
				}
				actorBySeat.ModifyMoveDirection(false, 0);
				actorBySeat.RecordPressCount();
			}
		}

		// Token: 0x060189DB RID: 100827 RVA: 0x007AF31C File Offset: 0x007AD71C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 2U,
				data2 = 0U,
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189DC RID: 100828 RVA: 0x007AF353 File Offset: 0x007AD753
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x060189DD RID: 100829 RVA: 0x007AF364 File Offset: 0x007AD764
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} StopMove", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189DE RID: 100830 RVA: 0x007AF3B2 File Offset: 0x007AD7B2
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
