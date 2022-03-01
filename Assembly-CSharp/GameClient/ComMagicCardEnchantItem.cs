using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001AE4 RID: 6884
	internal class ComMagicCardEnchantItem : MonoBehaviour
	{
		// Token: 0x17001D74 RID: 7540
		// (get) Token: 0x06010E5E RID: 69214 RVA: 0x004D347F File Offset: 0x004D187F
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06010E5F RID: 69215 RVA: 0x004D34A3 File Offset: 0x004D18A3
		public static int Sort(ItemData left, ItemData right)
		{
			if (left.Quality != right.Quality)
			{
				return right.Quality - left.Quality;
			}
			return right.LevelLimit - left.LevelLimit;
		}

		// Token: 0x06010E60 RID: 69216 RVA: 0x004D34D4 File Offset: 0x004D18D4
		public static ItemData _TryAddMagicCard(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25 && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage)
			{
				return item;
			}
			return null;
		}

		// Token: 0x06010E61 RID: 69217 RVA: 0x004D3528 File Offset: 0x004D1928
		public void OnSelectedItem()
		{
			if (null != this.comItem && this.comItem.ItemData != null)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnEnchantCardSelected, this.comItem.ItemData, null, null, null);
			}
		}

		// Token: 0x06010E62 RID: 69218 RVA: 0x004D3568 File Offset: 0x004D1968
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010E63 RID: 69219 RVA: 0x004D3576 File Offset: 0x004D1976
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010E64 RID: 69220 RVA: 0x004D3590 File Offset: 0x004D1990
		public void OnItemVisible(ItemData itemData)
		{
			MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(itemData.TableID, string.Empty, string.Empty);
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.checkName.text = itemData.GetColorName(string.Empty, false);
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			base.gameObject.name = itemData.TableID.ToString();
			Text text = this.magicText;
			string enchantmentCardAttributesDesc = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(itemData.TableID, itemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
			this.checkMagicText.text = enchantmentCardAttributesDesc;
			text.text = enchantmentCardAttributesDesc;
		}

		// Token: 0x06010E65 RID: 69221 RVA: 0x004D3674 File Offset: 0x004D1A74
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0400ADA2 RID: 44450
		public static ItemData ms_selected;

		// Token: 0x0400ADA3 RID: 44451
		public GameObject goItemParent;

		// Token: 0x0400ADA4 RID: 44452
		public Text Name;

		// Token: 0x0400ADA5 RID: 44453
		public Text checkName;

		// Token: 0x0400ADA6 RID: 44454
		public Text magicText;

		// Token: 0x0400ADA7 RID: 44455
		public Text checkMagicText;

		// Token: 0x0400ADA8 RID: 44456
		public GameObject goCheckMark;

		// Token: 0x0400ADA9 RID: 44457
		public Image imageItemBack;

		// Token: 0x0400ADAA RID: 44458
		private ComItem comItem;
	}
}
