using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001979 RID: 6521
	public struct InitPetData
	{
		// Token: 0x0600FD60 RID: 64864 RVA: 0x0045C814 File Offset: 0x0045AC14
		public void ClearData()
		{
			this.PetTabType = PetInfoTabType.Pet_UpLevel;
			this.petinfo = null;
		}

		// Token: 0x04009F41 RID: 40769
		public PetInfoTabType PetTabType;

		// Token: 0x04009F42 RID: 40770
		public PetInfo petinfo;
	}
}
