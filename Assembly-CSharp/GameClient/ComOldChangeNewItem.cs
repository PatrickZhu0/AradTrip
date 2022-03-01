using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000047 RID: 71
	public class ComOldChangeNewItem : MonoBehaviour
	{
		// Token: 0x060001B1 RID: 433 RVA: 0x0000F380 File Offset: 0x0000D780
		public void SetItemId(int id)
		{
			ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				DataManager<ShopDataManager>.GetInstance()._GetOldChangeNewItem(tableItem, this.oldChangeNewItem);
				for (int i = 0; i < this.oldChangeNewItem.Count; i++)
				{
					ItemData oldChangeNewItemData = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.oldChangeNewItem[i].ID);
					oldChangeNewItemData.Count = this.oldChangeNewItem[i].Num;
					this.iconBtn.onClick.RemoveAllListeners();
					this.iconBtn.onClick.AddListener(delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(oldChangeNewItemData, null, 4, true, false, true);
					});
					this._setBoard(oldChangeNewItemData.Quality);
					this._setIcon(oldChangeNewItemData.Icon);
					bool flag = DataManager<ShopDataManager>.GetInstance()._IsCanOldChangeNew(oldChangeNewItemData, EPackageType.Equip) || DataManager<ShopDataManager>.GetInstance()._IsCanOldChangeNew(oldChangeNewItemData, EPackageType.WearEquip);
					if (flag)
					{
						this.count.text = TR.Value("oldchangeNewGreen");
					}
					else
					{
						this.count.text = TR.Value("oldchangeNewRed");
					}
				}
			}
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x0000F4C8 File Offset: 0x0000D8C8
		private void _setBoard(ItemTable.eColor color)
		{
			if (null == this.board)
			{
				return;
			}
			if (color == ItemTable.eColor.GREEN)
			{
				Color color2;
				color2..ctor(0.039215688f, 0.39215687f, 0.039215688f, 1f);
				this.board.color = color2;
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x0000F515 File Offset: 0x0000D915
		private void _setIcon(string path)
		{
			if (null == this.icon)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.icon, path, true);
		}

		// Token: 0x0400019B RID: 411
		public Image icon;

		// Token: 0x0400019C RID: 412
		public Image board;

		// Token: 0x0400019D RID: 413
		public Text count;

		// Token: 0x0400019E RID: 414
		public Button iconBtn;

		// Token: 0x0400019F RID: 415
		private List<AwardItemData> oldChangeNewItem = new List<AwardItemData>();
	}
}
