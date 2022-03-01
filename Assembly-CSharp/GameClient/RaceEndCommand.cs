using System;
using System.Text;
using Protocol;

namespace GameClient
{
	// Token: 0x0200451A RID: 17690
	public class RaceEndCommand : BaseFrameCommand, IFrameCommand
	{
		// Token: 0x060189C8 RID: 100808 RVA: 0x007AF014 File Offset: 0x007AD414
		public FrameCommandID GetID()
		{
			return FrameCommandID.RaceEnd;
		}

		// Token: 0x060189C9 RID: 100809 RVA: 0x007AF018 File Offset: 0x007AD418
		public uint GetFrame()
		{
			return this.frame;
		}

		// Token: 0x060189CA RID: 100810 RVA: 0x007AF020 File Offset: 0x007AD420
		public void ExecCommand()
		{
			IOnExecCommand battle = this.battle;
			if (battle != null)
			{
				battle.BeforeExecFrameCommand(this.seat, this);
			}
			Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
			if (battle != null)
			{
				battle.AfterExecFrameCommand(this.seat, this);
			}
			if (Singleton<ReplayServer>.GetInstance().IsReplay())
			{
				Singleton<ReplayServer>.GetInstance().Stop(true, "RaceEndCmd");
			}
		}

		// Token: 0x060189CB RID: 100811 RVA: 0x007AF084 File Offset: 0x007AD484
		public _inputData GetInputData()
		{
			return new _inputData
			{
				data1 = 13U,
				sendTime = this.sendTime
			};
		}

		// Token: 0x060189CC RID: 100812 RVA: 0x007AF0AE File Offset: 0x007AD4AE
		public void SetValue(uint frame, byte seat, _inputData data)
		{
			this.frame = frame;
			this.seat = seat;
			this.reasonCode = data.data2;
		}

		// Token: 0x060189CD RID: 100813 RVA: 0x007AF0CC File Offset: 0x007AD4CC
		public string GetString()
		{
			StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
			MyExtensionMethods.Clear(stringBuilder);
			stringBuilder.AppendFormat("Frame:{0} Seat:{1} Code:{2} RaceEnd!!", this.frame, this.seat, this.reasonCode);
			string result = stringBuilder.ToString();
			StringBuilderCache.Release(stringBuilder);
			return result;
		}

		// Token: 0x060189CE RID: 100814 RVA: 0x007AF125 File Offset: 0x007AD525
		public void Reset()
		{
			base.BaseReset();
		}

		// Token: 0x04011C0B RID: 72715
		private uint reasonCode;
	}
}
