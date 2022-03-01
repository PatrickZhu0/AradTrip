using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200002A RID: 42
	public class ComEquipHandbookItem : MonoBehaviour
	{
		// Token: 0x060000FB RID: 251 RVA: 0x0000A2E8 File Offset: 0x000086E8
		public void SetItemId(int id)
		{
			ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(tableItem.ID);
			this._setName(commonItemTableDataByID.GetColorName(string.Empty, false), commonItemTableDataByID.LevelLimit);
			this._setBoard(ItemData.GetQualityInfo(tableItem.Color, false, false).Background);
			this._setIcon(tableItem.Icon);
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000A360 File Offset: 0x00008760
		public void SetItemState(EquipHandbookEquipItemData data)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (DataManager<EquipHandbookDataManager>.GetInstance().playerEquipData.Count <= 0)
			{
				this.carry.CustomActive(false);
			}
			for (int i = 0; i < DataManager<EquipHandbookDataManager>.GetInstance().playerEquipData.Count; i++)
			{
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(DataManager<EquipHandbookDataManager>.GetInstance().playerEquipData[i].id, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (tableItem.ID == tableItem2.ID)
					{
						this.carry.CustomActive(true);
						this.arrowState.CustomActive(false);
						return;
					}
					if (tableItem.SubType == tableItem2.SubType)
					{
						this.carry.CustomActive(false);
						this.arrowState.CustomActive(true);
						if (data.baseScore >= DataManager<EquipHandbookDataManager>.GetInstance().playerEquipData[i].baseScore)
						{
							this.bind.GetSprite("greenArrow", ref this.arrowState);
						}
						else
						{
							this.bind.GetSprite("redArrow", ref this.arrowState);
						}
						break;
					}
					this.carry.CustomActive(false);
					this.bind.GetSprite("greenArrow", ref this.arrowState);
				}
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000A4D5 File Offset: 0x000088D5
		private void _setName(string itemName, int itemLevel)
		{
			if (null == this.name)
			{
				return;
			}
			this.name.text = itemName;
			this.level.text = string.Format("Lv.{0}", itemLevel);
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000A510 File Offset: 0x00008910
		private void _setBoard(string path)
		{
			if (null == this.board)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.board, path, true);
			this.board.type = 1;
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000A53E File Offset: 0x0000893E
		private void _setIcon(string path)
		{
			if (null == this.icon)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref this.icon, path, true);
		}

		// Token: 0x040000D1 RID: 209
		public Image icon;

		// Token: 0x040000D2 RID: 210
		public Image board;

		// Token: 0x040000D3 RID: 211
		public Text name;

		// Token: 0x040000D4 RID: 212
		public Image arrowState;

		// Token: 0x040000D5 RID: 213
		public GameObject carry;

		// Token: 0x040000D6 RID: 214
		public GameObject gostate;

		// Token: 0x040000D7 RID: 215
		public ComCommonBind bind;

		// Token: 0x040000D8 RID: 216
		public Text level;
	}
}
