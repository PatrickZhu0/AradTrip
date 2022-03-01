using System;

namespace GameClient
{
	// Token: 0x02001B54 RID: 6996
	public class InscriptionProbabilityData
	{
		// Token: 0x06011267 RID: 70247 RVA: 0x004ECB48 File Offset: 0x004EAF48
		public InscriptionProbabilityData(int minProbability, int maxProbability, string successName)
		{
			this.MinProbability = minProbability;
			this.MaxProbability = maxProbability;
			this.SuccessName = successName;
		}

		// Token: 0x0400B110 RID: 45328
		public int MinProbability;

		// Token: 0x0400B111 RID: 45329
		public int MaxProbability;

		// Token: 0x0400B112 RID: 45330
		public string SuccessName;
	}
}
