using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200118D RID: 4493
	public class BeTownNPCData : BeBaseActorData
	{
		// Token: 0x17001A51 RID: 6737
		// (get) Token: 0x0600ABF1 RID: 44017 RVA: 0x0024F501 File Offset: 0x0024D901
		// (set) Token: 0x0600ABF2 RID: 44018 RVA: 0x0024F509 File Offset: 0x0024D909
		public int ResourceID { get; set; }

		// Token: 0x17001A52 RID: 6738
		// (get) Token: 0x0600ABF3 RID: 44019 RVA: 0x0024F512 File Offset: 0x0024D912
		// (set) Token: 0x0600ABF4 RID: 44020 RVA: 0x0024F51A File Offset: 0x0024D91A
		public int NpcID { get; set; }

		// Token: 0x17001A53 RID: 6739
		// (get) Token: 0x0600ABF5 RID: 44021 RVA: 0x0024F523 File Offset: 0x0024D923
		// (set) Token: 0x0600ABF6 RID: 44022 RVA: 0x0024F52B File Offset: 0x0024D92B
		public int JobID { get; set; }

		// Token: 0x17001A54 RID: 6740
		// (get) Token: 0x0600ABF7 RID: 44023 RVA: 0x0024F534 File Offset: 0x0024D934
		// (set) Token: 0x0600ABF8 RID: 44024 RVA: 0x0024F53C File Offset: 0x0024D93C
		public string StatueName { get; set; }

		// Token: 0x04006071 RID: 24689
		public PlayerAvatar avatorInfo;

		// Token: 0x04006074 RID: 24692
		public ESceneActorType TownNpcType;
	}
}
