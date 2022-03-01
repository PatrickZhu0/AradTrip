using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02004515 RID: 17685
	public class SceneChangeArea : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189A0 RID: 100768 RVA: 0x007AE9D4 File Offset: 0x007ACDD4
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			base._callRandomWithHpMp();
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
		}

		// Token: 0x060189A1 RID: 100769 RVA: 0x007AEA14 File Offset: 0x007ACE14
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189A2 RID: 100770 RVA: 0x007AEA1C File Offset: 0x007ACE1C
		public FrameCommandID GetID()
		{
			return FrameCommandID.SceneChangeArea;
		}

		// Token: 0x060189A3 RID: 100771 RVA: 0x007AEA20 File Offset: 0x007ACE20
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 16U,
				data2 = 0U,
				data3 = 0U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189A4 RID: 100772 RVA: 0x007AEA58 File Offset: 0x007ACE58
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
		}

		// Token: 0x060189A5 RID: 100773 RVA: 0x007AEA68 File Offset: 0x007ACE68
		public string GetString()
		{
			return "[SceneChangeArea]";
		}

		// Token: 0x060189A6 RID: 100774 RVA: 0x007AEA6F File Offset: 0x007ACE6F
		public void Reset()
		{
			base.BaseReset();
		}
	}
}
