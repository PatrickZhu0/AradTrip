using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A77 RID: 6775
	public class GoblinShopItem : MonoBehaviour
	{
		// Token: 0x06010A0C RID: 68108 RVA: 0x004B3F40 File Offset: 0x004B2340
		public void SetElementItem(AccountShopItemInfo accountShopItem, AccountShopQueryIndex accountShopQueryIndex)
		{
			if (this.itemName != null)
			{
				this.itemName.text = accountShopItem.shopItemName;
			}
			if (this.itemLimitTimes != null)
			{
				if (accountShopItem.accountLimitBuyNum == 0U)
				{
					this.itemLimitTimes.text = this.notLimitBuyDesc;
				}
				else
				{
					this.itemLimitTimes.text = string.Format(this.accountLimitBuyDesc, accountShopItem.accountRestBuyNum, accountShopItem.accountLimitBuyNum);
				}
			}
			if (this.itemRoot != null)
			{
				ComItem comItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					ComItem comItem2 = ComItemManager.Create(this.itemRoot);
					comItem = comItem2;
				}
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)accountShopItem.itemDataId, 100, 0);
				if (ItemDetailData != null)
				{
					ItemDetailData.Count = (int)accountShopItem.itemNum;
					comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
					{
						this._OnShowTips(ItemDetailData);
					});
				}
			}
			ItemTable itemTableData = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)accountShopItem.costItems[0].id, string.Empty, string.Empty);
			if (itemTableData != null)
			{
				if (this.priceIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.priceIcon, itemTableData.Icon, true);
				}
				if (this.priceValue != null)
				{
					this.priceValue.text = accountShopItem.costItems[0].num.ToString();
				}
				this.priceBtn.onClick.RemoveAllListeners();
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)accountShopItem.costItems[0].id, 100, 0);
				this.priceBtn.onClick.AddListener(delegate()
				{
					this._OnShowTips(ItemDetailData);
				});
			}
			if (this.previewButton != null)
			{
				this.previewButton.onClick.RemoveAllListeners();
				int tempItemID = (int)accountShopItem.itemDataId;
				this.previewButton.onClick.AddListener(delegate()
				{
					if (accountShopItem.needPreviewFunc == 1)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, tempItemID, string.Empty);
					}
					else if (accountShopItem.needPreviewFunc == 2)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tempItemID, string.Empty, string.Empty);
						if (tableItem == null)
						{
							return;
						}
						if (tableItem.SubType == ItemTable.eSubType.GiftPackage)
						{
							GiftPackTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GiftPackTable>(itemTableData.PackageID, string.Empty, string.Empty);
							if (tableItem2 == null)
							{
								return;
							}
							FlatBufferArray<int> items = tableItem2.Items;
							for (int i = 0; i < items.Length; i++)
							{
								GiftTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<GiftTable>(items[i], string.Empty, string.Empty);
								if (tableItem3 != null)
								{
									if (tableItem3.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
									{
										if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem3.ItemID, string.Empty, string.Empty) != null)
										{
											Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<PetTable>();
											foreach (KeyValuePair<int, object> keyValuePair in table)
											{
												PetTable petTable = keyValuePair.Value as PetTable;
												if (petTable != null && petTable.PetEggID == tempItemID)
												{
													Singleton<ClientSystemManager>.GetInstance().OpenFrame<ShowPetModelFrame>(FrameLayer.Middle, petTable.ID, string.Empty);
													break;
												}
											}
											break;
										}
									}
								}
							}
						}
					}
				});
			}
			if (accountShopItem.accountRestBuyNum <= 0U)
			{
				this.buyButtonGray.enabled = true;
			}
			else
			{
				this.buyButtonGray.enabled = false;
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(delegate()
				{
					if (accountShopItem.accountRestBuyNum <= 0U)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("goblin_shop_cannot_buy_tips_one"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else if ((long)DataManager<AccountShopDataManager>.GetInstance().GetSpecialItemNum((int)accountShopItem.costItems[0].id) < (long)((ulong)accountShopItem.costItems[0].num))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("goblin_shop_cannot_buy_tips_two"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
					else
					{
						DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemBuyReq(accountShopQueryIndex, accountShopItem.shopItemId, 1U);
					}
				});
			}
			if (accountShopItem.needPreviewFunc > 0)
			{
				this.previewButton.CustomActive(true);
			}
			else
			{
				this.previewButton.CustomActive(false);
			}
		}

		// Token: 0x06010A0D RID: 68109 RVA: 0x004B4280 File Offset: 0x004B2680
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0400A9AE RID: 43438
		[Space(5f)]
		[Header("NormalContent")]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400A9AF RID: 43439
		[SerializeField]
		private Text itemName;

		// Token: 0x0400A9B0 RID: 43440
		[SerializeField]
		private Text itemLimitTimes;

		// Token: 0x0400A9B1 RID: 43441
		[SerializeField]
		private Button buyButton;

		// Token: 0x0400A9B2 RID: 43442
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x0400A9B3 RID: 43443
		[SerializeField]
		private Button previewButton;

		// Token: 0x0400A9B4 RID: 43444
		[Space(10f)]
		[Header("PriceInfo")]
		[SerializeField]
		private GameObject priceRoot;

		// Token: 0x0400A9B5 RID: 43445
		[SerializeField]
		private Text priceName;

		// Token: 0x0400A9B6 RID: 43446
		[SerializeField]
		private Image priceIcon;

		// Token: 0x0400A9B7 RID: 43447
		[SerializeField]
		private Text priceValue;

		// Token: 0x0400A9B8 RID: 43448
		[SerializeField]
		private Button priceBtn;

		// Token: 0x0400A9B9 RID: 43449
		[SerializeField]
		private ComOldChangeNewItem comOldChangeNewItem;

		// Token: 0x0400A9BA RID: 43450
		[Space(10f)]
		[Header("OtherInfo")]
		[SerializeField]
		private Text soldOverText;

		// Token: 0x0400A9BB RID: 43451
		[SerializeField]
		private GameObject vipRoot;

		// Token: 0x0400A9BC RID: 43452
		[SerializeField]
		private Text vipText;

		// Token: 0x0400A9BD RID: 43453
		[SerializeField]
		private GameObject itemLockLimitRoot;

		// Token: 0x0400A9BE RID: 43454
		[SerializeField]
		private Button itemLockLimitButton;

		// Token: 0x0400A9BF RID: 43455
		[SerializeField]
		private Text itemLockLimitText;

		// Token: 0x0400A9C0 RID: 43456
		[SerializeField]
		private Text vipDiscountText;

		// Token: 0x0400A9C1 RID: 43457
		[SerializeField]
		private GameObject canNotBuyMask;

		// Token: 0x0400A9C2 RID: 43458
		[SerializeField]
		private string accountLimitBuyDesc = "账号限购:{0}/{1}";

		// Token: 0x0400A9C3 RID: 43459
		[SerializeField]
		private string notLimitBuyDesc = "不限购";
	}
}
