using System;

namespace GameClient
{
	// Token: 0x02000F59 RID: 3929
	internal class ItemConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098AE RID: 39086 RVA: 0x001D594E File Offset: 0x001D3D4E
		public ItemConsume(int id, ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mItemID = id;
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.ItemTakeSuccess,
				EUIEventID.ItemCountChanged
			};
		}

		// Token: 0x060098AF RID: 39087 RVA: 0x001D597A File Offset: 0x001D3D7A
		public void OnChange()
		{
			base.cnt = (ulong)((long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mItemID, false));
		}

		// Token: 0x060098B0 RID: 39088 RVA: 0x001D5994 File Offset: 0x001D3D94
		public void OnAdd()
		{
			ItemComeLink.OnLink(this.mItemID, 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}

		// Token: 0x04004EB7 RID: 20151
		protected int mItemID;
	}
}
