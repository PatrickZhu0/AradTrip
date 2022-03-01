using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x02004529 RID: 17705
	public class PassDoorCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x06018A40 RID: 100928 RVA: 0x007B12D0 File Offset: 0x007AF6D0
		public FrameCommandID GetID()
		{
			return FrameCommandID.PassDoor;
		}

		// Token: 0x06018A41 RID: 100929 RVA: 0x007B12D4 File Offset: 0x007AF6D4
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x06018A42 RID: 100930 RVA: 0x007B12DC File Offset: 0x007AF6DC
		public void ExecCommand()
		{
			BeActor actorBySeat = base.GetActorBySeat(this.seat);
			if (actorBySeat == null || actorBySeat.IsDead())
			{
				return;
			}
			if (actorBySeat != null && actorBySeat.IsProcessRecord())
			{
				base.Record(actorBySeat, this.GetString());
			}
			actorBySeat.Reset();
			actorBySeat.SetAttackButtonState(ButtonState.RELEASE, true);
		}

		// Token: 0x06018A43 RID: 100931 RVA: 0x007B1334 File Offset: 0x007AF734
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 20U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x06018A44 RID: 100932 RVA: 0x007B135E File Offset: 0x007AF75E
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x06018A45 RID: 100933 RVA: 0x007B1370 File Offset: 0x007AF770
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} PassDoor !!", this.frame, this.seat);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x06018A46 RID: 100934 RVA: 0x007B13BE File Offset: 0x007AF7BE
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
