using System;

namespace GameClient
{
	// Token: 0x02001B55 RID: 6997
	public class InscriptionExtractResultData
	{
		// Token: 0x06011268 RID: 70248 RVA: 0x004ECB65 File Offset: 0x004EAF65
		public InscriptionExtractResultData(bool isSuccessed, ItemData itemData)
		{
			this.IsSuccessed = isSuccessed;
			this.InscriptionItemData = itemData;
		}

		// Token: 0x0400B113 RID: 45331
		public bool IsSuccessed;

		// Token: 0x0400B114 RID: 45332
		public ItemData InscriptionItemData;
	}
}
