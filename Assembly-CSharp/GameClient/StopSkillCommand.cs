using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004524 RID: 17700
	public class StopSkillCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A18 RID: 100888 RVA: 0x007B09CC File Offset: 0x007AEDCC
		public FrameCommandID GetID()
		{
			return FrameCommandID.StopSkill;
		}

		// Token: 0x06018A19 RID: 100889 RVA: 0x007B09D0 File Offset: 0x007AEDD0
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A1A RID: 100890 RVA: 0x007B09D8 File Offset: 0x007AEDD8
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (this.skillID != 0 && actorBySeat != null && !actorBySeat.IsDead())
			{
				actorBySeat.CancelSkill(this.skillID, true);
				actorBySeat.Locomote(new BeStateData(0, 0), false);
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x06018A1B RID: 100891 RVA: 0x007B0A58 File Offset: 0x007AEE58
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 17U,
				data2 = (uint)this.skillID,
				data3 = 0U
			};
		}

		// Token: 0x06018A1C RID: 100892 RVA: 0x007B0A89 File Offset: 0x007AEE89
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.skillID = (int)data.data2;
		}

		// Token: 0x06018A1D RID: 100893 RVA: 0x007B0AA8 File Offset: 0x007AEEA8
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} stop skillid:{2}", this.frame, this.seat, this.skillID);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A1E RID: 100894 RVA: 0x007B0B01 File Offset: 0x007AEF01
		public void Reset()
		{
			base.BaseReset();
			this.skillID = 0;
		}

		// Token: 0x04011C1F RID: 72735
		public int skillID;
	}
}
