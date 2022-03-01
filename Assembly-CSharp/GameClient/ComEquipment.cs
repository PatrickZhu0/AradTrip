using System;
using System.Runtime.CompilerServices;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001ADB RID: 6875
	internal class ComEquipment : MonoBehaviour
	{
		// Token: 0x17001D71 RID: 7537
		// (get) Token: 0x06010E11 RID: 69137 RVA: 0x004D1888 File Offset: 0x004CFC88
		public ItemData ItemData
		{
			get
			{
				return (!(this.comItem == null)) ? this.comItem.ItemData : null;
			}
		}

		// Token: 0x06010E12 RID: 69138 RVA: 0x004D18AC File Offset: 0x004CFCAC
		public void OnItemChangeDisplay(bool bSelected)
		{
			this.goCheckMark.CustomActive(bSelected);
		}

		// Token: 0x06010E13 RID: 69139 RVA: 0x004D18BA File Offset: 0x004CFCBA
		private void OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06010E14 RID: 69140 RVA: 0x004D18D4 File Offset: 0x004CFCD4
		public void OnItemVisible(ItemData itemData)
		{
			if (this.comItem == null)
			{
				this.comItem = ComItemManager.Create(this.goItemParent);
			}
			this.comItem.Setup(itemData, new ComItem.OnItemClicked(this.OnItemClicked));
			this.Name.text = itemData.GetColorName(string.Empty, false);
			this.goCanBeSet.CustomActive(false);
			this.goHasBeenSet.CustomActive(false);
			if (itemData.mPrecEnchantmentCard != null)
			{
				MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(itemData.mPrecEnchantmentCard.iEnchantmentCardID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData itemData2 = ItemDataManager.CreateItemDataFromTable(tableItem.ID, 100, 0);
					itemData2.mPrecEnchantmentCard.iEnchantmentCardLevel = itemData.mPrecEnchantmentCard.iEnchantmentCardLevel;
					this.goHasBeenSet.CustomActive(true);
					if (this.mCardComItem == null)
					{
						this.mCardComItem = ComItemManager.Create(this.goCardParent);
					}
					ComItem comItem = this.mCardComItem;
					ItemData item = itemData2;
					if (ComEquipment.<>f__mg$cache0 == null)
					{
						ComEquipment.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, ComEquipment.<>f__mg$cache0);
					this.CardAttr.text = DataManager<EnchantmentsCardManager>.GetInstance().GetEnchantmentCardAttributesDesc(itemData.mPrecEnchantmentCard.iEnchantmentCardID, itemData.mPrecEnchantmentCard.iEnchantmentCardLevel, false);
				}
				else
				{
					this.goCanBeSet.CustomActive(true);
				}
			}
			this.equiptedMark.CustomActive(itemData.PackageType == EPackageType.WearEquip);
			base.gameObject.name = itemData.TableID.ToString();
			if (itemData.PackageType == EPackageType.WearEquip)
			{
				this.comFunctionBinder.ClearCheckFunctions();
				this.comFunctionBinder.SpecialItem = itemData;
				this.comFunctionBinder.AddCheckFunction(SmithFunctionRedBinder.SmithFunctionType.SFT_ADDMAGIC);
				ETCImageLoader.LoadSprite(ref this.redHintText, TR.Value("SMITH_CAN_ADDMAGIC"), true);
			}
			else
			{
				this.comFunctionBinder.SpecialItem = null;
				this.comFunctionBinder.ClearCheckFunctions();
			}
		}

		// Token: 0x06010E15 RID: 69141 RVA: 0x004D1AC9 File Offset: 0x004CFEC9
		private void OnDestroy()
		{
			if (this.comItem != null)
			{
				this.comItem = null;
			}
		}

		// Token: 0x0400AD50 RID: 44368
		public static ItemData ms_selected;

		// Token: 0x0400AD51 RID: 44369
		public Text Name;

		// Token: 0x0400AD52 RID: 44370
		public Text CardAttr;

		// Token: 0x0400AD53 RID: 44371
		public GameObject equiptedMark;

		// Token: 0x0400AD54 RID: 44372
		public GameObject goItemParent;

		// Token: 0x0400AD55 RID: 44373
		public GameObject goCheckMark;

		// Token: 0x0400AD56 RID: 44374
		public GameObject goCanBeSet;

		// Token: 0x0400AD57 RID: 44375
		public GameObject goHasBeenSet;

		// Token: 0x0400AD58 RID: 44376
		public GameObject goCardParent;

		// Token: 0x0400AD59 RID: 44377
		public Image redHintText;

		// Token: 0x0400AD5A RID: 44378
		public Image imageItemBack;

		// Token: 0x0400AD5B RID: 44379
		private ComItem comItem;

		// Token: 0x0400AD5C RID: 44380
		public SmithFunctionRedBinder comFunctionBinder;

		// Token: 0x0400AD5D RID: 44381
		private ComItem mCardComItem;

		// Token: 0x0400AD5E RID: 44382
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
