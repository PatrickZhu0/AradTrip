using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004521 RID: 17697
	public class LevelChangeCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A00 RID: 100864 RVA: 0x007B0246 File Offset: 0x007AE646
		public FrameCommandID GetID()
		{
			return FrameCommandID.LevelChange;
		}

		// Token: 0x06018A01 RID: 100865 RVA: 0x007B024A File Offset: 0x007AE64A
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A02 RID: 100866 RVA: 0x007B0254 File Offset: 0x007AE654
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat == null || actorBySeat.IsDead())
			{
				return;
			}
			if (Singleton<RecordServer>.GetInstance().IsProcessRecord())
			{
				base.Record(actorBySeat, this.GetString());
			}
			actorBySeat.LevelUpTo(this.newLevel);
		}

		// Token: 0x06018A03 RID: 100867 RVA: 0x007B02A8 File Offset: 0x007AE6A8
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 9U,
				data2 = (uint)this.newLevel,
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A04 RID: 100868 RVA: 0x007B02E5 File Offset: 0x007AE6E5
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.newLevel = (int)data.data2;
		}

		// Token: 0x06018A05 RID: 100869 RVA: 0x007B0304 File Offset: 0x007AE704
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} level change=>{2}", this.frame, this.seat, this.newLevel);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A06 RID: 100870 RVA: 0x007B035D File Offset: 0x007AE75D
		public void Reset()
		{
			base.BaseReset();
			this.newLevel = 0;
		}

		// Token: 0x04011C13 RID: 72723
		public int newLevel;
	}
}
