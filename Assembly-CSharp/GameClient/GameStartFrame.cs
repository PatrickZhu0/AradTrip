using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004517 RID: 17687
	public class GameStartFrame : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189B0 RID: 100784 RVA: 0x007AEBAD File Offset: 0x007ACFAD
		public FrameCommandID GetID()
		{
			return FrameCommandID.GameStart;
		}

		// Token: 0x060189B1 RID: 100785 RVA: 0x007AEBB0 File Offset: 0x007ACFB0
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189B2 RID: 100786 RVA: 0x007AEBB8 File Offset: 0x007ACFB8
		public void ExecCommand()
		{
			int num = (int)((this.seat < byte.MaxValue) ? this.seat : 0);
			BeActor actorBySeat = base.GetActorBySeat((byte)num);
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, "[GAMESTART]" + this.GetString());
			}
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			FrameSync.instance.OnRelayGameStart(this.startTime);
			base._callRandomWithHpMp();
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
			if (this.battle != null)
			{
				this.battle.InitLevelManager();
			}
		}

		// Token: 0x060189B3 RID: 100787 RVA: 0x007AEC6C File Offset: 0x007AD06C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 0U,
				data2 = this.startTime,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189B4 RID: 100788 RVA: 0x007AECA1 File Offset: 0x007AD0A1
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.startTime = data.data2;
		}

		// Token: 0x060189B5 RID: 100789 RVA: 0x007AECC0 File Offset: 0x007AD0C0
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} StartTime:{2}", this.frame, this.seat, this.startTime);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189B6 RID: 100790 RVA: 0x007AED19 File Offset: 0x007AD119
		public void Reset()
		{
			base.BaseReset();
			this.startTime = 0U;
		}

		// Token: 0x04011C09 RID: 72713
		public uint startTime;
	}
}
