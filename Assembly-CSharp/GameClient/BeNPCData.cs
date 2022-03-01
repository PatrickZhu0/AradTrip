using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001151 RID: 4433
	public sealed class BeNPCData : BeBaseActorData
	{
		// Token: 0x17001A20 RID: 6688
		// (get) Token: 0x0600A92E RID: 43310 RVA: 0x0023B346 File Offset: 0x00239746
		// (set) Token: 0x0600A92F RID: 43311 RVA: 0x0023B34E File Offset: 0x0023974E
		public int ResourceID { get; set; }

		// Token: 0x17001A21 RID: 6689
		// (get) Token: 0x0600A930 RID: 43312 RVA: 0x0023B357 File Offset: 0x00239757
		// (set) Token: 0x0600A931 RID: 43313 RVA: 0x0023B35F File Offset: 0x0023975F
		public int NpcID { get; set; }

		// Token: 0x17001A22 RID: 6690
		// (get) Token: 0x0600A932 RID: 43314 RVA: 0x0023B368 File Offset: 0x00239768
		// (set) Token: 0x0600A933 RID: 43315 RVA: 0x0023B370 File Offset: 0x00239770
		public int JobID { get; set; }

		// Token: 0x17001A23 RID: 6691
		// (get) Token: 0x0600A934 RID: 43316 RVA: 0x0023B379 File Offset: 0x00239779
		// (set) Token: 0x0600A935 RID: 43317 RVA: 0x0023B381 File Offset: 0x00239781
		public string StatueName { get; set; }

		// Token: 0x04005E7D RID: 24189
		public PlayerAvatar avatorInfo;

		// Token: 0x04005E80 RID: 24192
		public ESceneActorType TownNpcType;
	}
}
