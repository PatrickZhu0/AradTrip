using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001334 RID: 4916
	public class TeamDuplicationGridOwnerCaptainDataModel
	{
		// Token: 0x0600BE6C RID: 48748 RVA: 0x002CBFA0 File Offset: 0x002CA3A0
		public bool IsInCdStatusWithOutMove()
		{
			if (this.CaptainStatus == 0U)
			{
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				if (this.CaptainCdEndTimeStamp > serverTime)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600BE6D RID: 48749 RVA: 0x002CBFD2 File Offset: 0x002CA3D2
		public uint GetTargetGridId()
		{
			if (this.CaptainStatus != 1U)
			{
				return 0U;
			}
			return this.TargetGridId;
		}

		// Token: 0x04006BD1 RID: 27601
		public uint CaptainId;

		// Token: 0x04006BD2 RID: 27602
		public uint CaptainStatus;

		// Token: 0x04006BD3 RID: 27603
		public uint GridId;

		// Token: 0x04006BD4 RID: 27604
		public uint TargetGridId;

		// Token: 0x04006BD5 RID: 27605
		public uint TargetMonsterId;

		// Token: 0x04006BD6 RID: 27606
		public uint CaptainCdStartTimeStamp;

		// Token: 0x04006BD7 RID: 27607
		public uint CaptainCdEndTimeStamp;

		// Token: 0x04006BD8 RID: 27608
		public uint CaptainCdTotalTimeInterval;

		// Token: 0x04006BD9 RID: 27609
		public List<uint> CaptainPathList = new List<uint>();
	}
}
