using System;

namespace GameClient
{
	// Token: 0x02001336 RID: 4918
	public class TeamDuplicationGridOtherCaptainDataModel
	{
		// Token: 0x0600BE70 RID: 48752 RVA: 0x002CC003 File Offset: 0x002CA403
		public uint GetTargetGridId()
		{
			if (this.CaptainStatus != 1U)
			{
				return 0U;
			}
			if (!this.IsExist)
			{
				return 0U;
			}
			return this.TargetGridId;
		}

		// Token: 0x04006BDD RID: 27613
		public uint CaptainId;

		// Token: 0x04006BDE RID: 27614
		public uint CaptainStatus;

		// Token: 0x04006BDF RID: 27615
		public uint GridId;

		// Token: 0x04006BE0 RID: 27616
		public uint TargetGridId;

		// Token: 0x04006BE1 RID: 27617
		public uint PlayerNumber;

		// Token: 0x04006BE2 RID: 27618
		public bool IsExist;
	}
}
