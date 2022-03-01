using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200197C RID: 6524
	public class PetItemTipsData
	{
		// Token: 0x0600FDA6 RID: 64934 RVA: 0x004600E2 File Offset: 0x0045E4E2
		public void ClearData()
		{
			this.petTipsType = PetTipsType.PetItemTip;
			this.petinfo = null;
			this.PlayerJobID = 0;
			this.bFunc = false;
		}

		// Token: 0x04009FA0 RID: 40864
		public PetTipsType petTipsType;

		// Token: 0x04009FA1 RID: 40865
		public PetInfo petinfo;

		// Token: 0x04009FA2 RID: 40866
		public int PlayerJobID;

		// Token: 0x04009FA3 RID: 40867
		public bool bFunc;
	}
}
