using System;

namespace GameClient
{
	// Token: 0x020010F1 RID: 4337
	public class MissionTraceTargetCmd : IClientFrameStackCmd
	{
		// Token: 0x0600A44E RID: 42062 RVA: 0x0021C89E File Offset: 0x0021AC9E
		public MissionTraceTargetCmd(int missionId)
		{
			this.mMissionId = missionId;
		}

		// Token: 0x0600A44F RID: 42063 RVA: 0x0021C8AD File Offset: 0x0021ACAD
		public eClientFrameStackCmd CmdType()
		{
			return eClientFrameStackCmd.MissionTraceTarget;
		}

		// Token: 0x0600A450 RID: 42064 RVA: 0x0021C8B0 File Offset: 0x0021ACB0
		public bool Do()
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				DataManager<MissionManager>.GetInstance().AutoTraceTask(this.mMissionId, null, null, false);
			}
			return true;
		}

		// Token: 0x04005BDB RID: 23515
		protected int mMissionId;
	}
}
