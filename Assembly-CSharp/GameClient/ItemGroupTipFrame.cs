using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016D5 RID: 5845
	internal class ItemGroupTipFrame : ClientFrame
	{
		// Token: 0x0600E52E RID: 58670 RVA: 0x003B8D89 File Offset: 0x003B7189
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/ItemGroupTip";
		}

		// Token: 0x0600E52F RID: 58671 RVA: 0x003B8D90 File Offset: 0x003B7190
		protected override void _OnOpenFrame()
		{
			this.m_packItem = (this.userData as ItemData);
			this.m_arrItems = new List<ItemData>();
			GiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(this.m_packItem.PackID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.Items.Count; i++)
				{
					GiftTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(tableItem.Items[i], string.Empty, string.Empty);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableItem2.ItemID, 100, 0);
					itemData.Count = tableItem2.ItemCount;
					this.m_arrItems.Add(itemData);
				}
			}
			this.m_comItemList.Initialize();
			this.m_comItemList.onBindItem = ((GameObject var) => base.CreateComItem(Utility.FindGameObject(var, "Item", true)));
			this.m_comItemList.onItemVisiable = delegate(ComUIListElementScript var)
			{
				if (this.m_arrItems != null && var.m_index >= 0 && var.m_index < this.m_arrItems.Count)
				{
					ComItem comItem = var.gameObjectBindScript as ComItem;
					comItem.Setup(this.m_arrItems[var.m_index], delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
					Utility.GetComponetInChild<Text>(var.gameObject, "Name").text = this.m_arrItems[var.m_index].GetColorName(string.Empty, false);
				}
			};
			if (this.m_packItem != null)
			{
				this.m_labName.text = this.m_packItem.Name;
			}
			else
			{
				this.m_labName.text = string.Empty;
			}
			if (this.m_arrItems != null)
			{
				this.m_comItemList.SetElementAmount(this.m_arrItems.Count);
			}
			else
			{
				this.m_comItemList.SetElementAmount(0);
			}
		}

		// Token: 0x0600E530 RID: 58672 RVA: 0x003B8EE4 File Offset: 0x003B72E4
		protected override void _OnCloseFrame()
		{
			this.m_packItem = null;
			this.m_arrItems.Clear();
		}

		// Token: 0x04008AAB RID: 35499
		[UIControl("Name", null, 0)]
		private Text m_labName;

		// Token: 0x04008AAC RID: 35500
		[UIControl("Items", null, 0)]
		private ComUIListScript m_comItemList;

		// Token: 0x04008AAD RID: 35501
		private ItemData m_packItem;

		// Token: 0x04008AAE RID: 35502
		private List<ItemData> m_arrItems = new List<ItemData>();
	}
}
