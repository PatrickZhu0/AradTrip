using System;

namespace GameClient
{
	// Token: 0x02001153 RID: 4435
	public sealed class BePetData : BeBaseActorData
	{
		// Token: 0x17001A24 RID: 6692
		// (get) Token: 0x0600A93A RID: 43322 RVA: 0x0023B616 File Offset: 0x00239A16
		// (set) Token: 0x0600A93B RID: 43323 RVA: 0x0023B61E File Offset: 0x00239A1E
		public int PetID { get; set; }

		// Token: 0x17001A25 RID: 6693
		// (get) Token: 0x0600A93C RID: 43324 RVA: 0x0023B627 File Offset: 0x00239A27
		// (set) Token: 0x0600A93D RID: 43325 RVA: 0x0023B62F File Offset: 0x00239A2F
		public int FollowId { get; set; }
	}
}
