using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02004516 RID: 17686
	public class RacePuaseFrame : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189A8 RID: 100776 RVA: 0x007AEA80 File Offset: 0x007ACE80
		public void ExecCommand()
		{
			if (!base.isValid())
			{
				return;
			}
			BeScene beScene = this.battle.dungeonManager.GetBeScene();
			if (beScene == null)
			{
				return;
			}
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			if (this.isPauseLogic)
			{
				beScene.PauseLogic();
			}
			else
			{
				beScene.ResumeLogic();
			}
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x060189A9 RID: 100777 RVA: 0x007AEAFA File Offset: 0x007ACEFA
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189AA RID: 100778 RVA: 0x007AEB02 File Offset: 0x007ACF02
		public FrameCommandID GetID()
		{
			return FrameCommandID.RacePause;
		}

		// Token: 0x060189AB RID: 100779 RVA: 0x007AEB08 File Offset: 0x007ACF08
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 15U,
				data2 = ((!this.isPauseLogic) ? 0U : 1U),
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189AC RID: 100780 RVA: 0x007AEB4A File Offset: 0x007ACF4A
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.isPauseLogic = (data.data2 > 0U);
		}

		// Token: 0x060189AD RID: 100781 RVA: 0x007AEB69 File Offset: 0x007ACF69
		public string GetString()
		{
			return string.Format("[RacePuaseFrame] Seat {0} Frame {1} {2}", this.seat, this.frame, this.isPauseLogic);
		}

		// Token: 0x060189AE RID: 100782 RVA: 0x007AEB96 File Offset: 0x007ACF96
		public void Reset()
		{
			base.BaseReset();
			this.isPauseLogic = false;
		}

		// Token: 0x04011C08 RID: 72712
		public bool isPauseLogic;
	}
}
