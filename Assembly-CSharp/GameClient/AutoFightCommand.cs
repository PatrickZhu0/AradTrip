using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004527 RID: 17703
	public class AutoFightCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A30 RID: 100912 RVA: 0x007B0FE9 File Offset: 0x007AF3E9
		public FrameCommandID GetID()
		{
			return FrameCommandID.AutoFight;
		}

		// Token: 0x06018A31 RID: 100913 RVA: 0x007B0FED File Offset: 0x007AF3ED
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A32 RID: 100914 RVA: 0x007B0FF8 File Offset: 0x007AF3F8
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat != null && !actorBySeat.IsDead())
			{
				actorBySeat.SetAutoFight(this.openAutoFight);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A33 RID: 100915 RVA: 0x007B105C File Offset: 0x007AF45C
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 10U,
				data2 = ((!this.openAutoFight) ? 0U : 1U),
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A34 RID: 100916 RVA: 0x007B10A5 File Offset: 0x007AF4A5
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.openAutoFight = (data.data2 != 0U);
		}

		// Token: 0x06018A35 RID: 100917 RVA: 0x007B10D0 File Offset: 0x007AF4D0
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} autofight:{2}", this.frame, this.seat, this.openAutoFight);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A36 RID: 100918 RVA: 0x007B1129 File Offset: 0x007AF529
		public void Reset()
		{
			base.BaseReset();
			this.openAutoFight = false;
		}

		// Token: 0x04011C26 RID: 72742
		public bool openAutoFight;
	}
}
