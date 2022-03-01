using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001B52 RID: 6994
	public class InscriptionExtractData
	{
		// Token: 0x06011265 RID: 70245 RVA: 0x004ECB1B File Offset: 0x004EAF1B
		public InscriptionExtractData(int color, List<InscriptionConsume> consumes, string extractProbability, bool isExtract)
		{
			this.Color = color;
			this.ExtractConsumes = consumes;
			this.ExtractProbability = extractProbability;
			this.IsExtract = isExtract;
		}

		// Token: 0x0400B10A RID: 45322
		public int Color;

		// Token: 0x0400B10B RID: 45323
		public List<InscriptionConsume> ExtractConsumes;

		// Token: 0x0400B10C RID: 45324
		public string ExtractProbability;

		// Token: 0x0400B10D RID: 45325
		public bool IsExtract;
	}
}
