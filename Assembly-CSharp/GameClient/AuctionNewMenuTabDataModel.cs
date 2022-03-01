using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011EC RID: 4588
	public class AuctionNewMenuTabDataModel
	{
		// Token: 0x0600B07C RID: 45180 RVA: 0x0026D4F4 File Offset: 0x0026B8F4
		public AuctionNewMenuTabDataModel(int id, int layer, int sort, AuctionNewFrameTable auctionNewFrameTable)
		{
			this.Id = id;
			this.Layer = layer;
			this.Sort = sort;
			this.AuctionNewFrameTable = auctionNewFrameTable;
			this.SetOwnerChildrenFlag();
		}

		// Token: 0x0600B07D RID: 45181 RVA: 0x0026D520 File Offset: 0x0026B920
		public void SetOwnerChildrenFlag()
		{
			this.IsOwnerChildren = true;
			if (this.AuctionNewFrameTable.LayerRelation == null || this.AuctionNewFrameTable.LayerRelation.Count == 0 || (this.AuctionNewFrameTable.LayerRelation.Count == 1 && this.AuctionNewFrameTable.LayerRelation[0] == 0))
			{
				this.IsOwnerChildren = false;
			}
		}

		// Token: 0x040062B0 RID: 25264
		public int Id;

		// Token: 0x040062B1 RID: 25265
		public int Layer;

		// Token: 0x040062B2 RID: 25266
		public int Sort;

		// Token: 0x040062B3 RID: 25267
		public AuctionNewFrameTable AuctionNewFrameTable;

		// Token: 0x040062B4 RID: 25268
		public bool IsOwnerChildren;
	}
}
