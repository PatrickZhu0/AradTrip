using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200165E RID: 5726
	internal class GuildHouseItem : CachedNormalObject<GuildHouseItemData>
	{
		// Token: 0x0600E13E RID: 57662 RVA: 0x0039B6B5 File Offset: 0x00399AB5
		public override void Initialize()
		{
			this.goBack = Utility.FindChild(this.goLocal, "BG");
			this.goItemParent = Utility.FindChild(this.goLocal, "ItemParent");
		}

		// Token: 0x0600E13F RID: 57663 RVA: 0x0039B6E4 File Offset: 0x00399AE4
		public override void OnUpdate()
		{
			if (base.Value != null)
			{
				if (base.Value.itemData != null)
				{
					this.goBack.CustomActive(false);
					this.goItemParent.CustomActive(true);
					if (null == this.comItem)
					{
						this.comItem = ComItemManager.Create(this.goItemParent);
					}
					if (null != this.comItem)
					{
						this.comItem.Setup(base.Value.itemData, delegate(GameObject obj, ItemData item)
						{
							if (item != null)
							{
								if (item.Type == ItemTable.eType.EQUIP)
								{
									WorldWatchGuildStorageItemReq worldWatchGuildStorageItemReq = new WorldWatchGuildStorageItemReq();
									worldWatchGuildStorageItemReq.uid = item.GUID;
									NetManager.Instance().SendCommand<WorldWatchGuildStorageItemReq>(ServerType.GATE_SERVER, worldWatchGuildStorageItemReq);
								}
								else
								{
									DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
								}
							}
						});
					}
				}
				else
				{
					this.goBack.CustomActive(true);
					this.goItemParent.CustomActive(false);
				}
			}
		}

		// Token: 0x0600E140 RID: 57664 RVA: 0x0039B7A7 File Offset: 0x00399BA7
		public override void UnInitialize()
		{
			this.goBack = null;
			this.goItemParent = null;
			if (null != this.comItem)
			{
				ComItemManager.Destroy(this.comItem);
				this.comItem = null;
			}
		}

		// Token: 0x04008604 RID: 34308
		private GameObject goBack;

		// Token: 0x04008605 RID: 34309
		private GameObject goItemParent;

		// Token: 0x04008606 RID: 34310
		private ComItem comItem;
	}
}
