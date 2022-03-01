using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020016D3 RID: 5843
	internal class ItemDoubleCheckData
	{
		// Token: 0x17001CB5 RID: 7349
		// (get) Token: 0x0600E51D RID: 58653 RVA: 0x003B8928 File Offset: 0x003B6D28
		// (set) Token: 0x0600E51E RID: 58654 RVA: 0x003B8930 File Offset: 0x003B6D30
		public UnityAction<bool> mCallBack { get; set; }

		// Token: 0x17001CB6 RID: 7350
		// (get) Token: 0x0600E51F RID: 58655 RVA: 0x003B8939 File Offset: 0x003B6D39
		// (set) Token: 0x0600E520 RID: 58656 RVA: 0x003B8941 File Offset: 0x003B6D41
		public string Desc { get; set; }

		// Token: 0x17001CB7 RID: 7351
		// (get) Token: 0x0600E521 RID: 58657 RVA: 0x003B894A File Offset: 0x003B6D4A
		// (set) Token: 0x0600E522 RID: 58658 RVA: 0x003B8952 File Offset: 0x003B6D52
		public ItemData itemData { get; set; }
	}
}
