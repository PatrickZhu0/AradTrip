using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A85 RID: 6789
	public class ShopNewMoneyItem : MonoBehaviour
	{
		// Token: 0x06010A7D RID: 68221 RVA: 0x004B7379 File Offset: 0x004B5779
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06010A7E RID: 68222 RVA: 0x004B7384 File Offset: 0x004B5784
		private void BindUiEventSystem()
		{
			if (this.itemTipButton != null)
			{
				this.itemTipButton.onClick.RemoveAllListeners();
				this.itemTipButton.onClick.AddListener(new UnityAction(this.OnItemTipButtonClick));
			}
			if (this.itemComeLink != null)
			{
				ItemComeLink itemComeLink = this.itemComeLink;
				itemComeLink.onClick = (ComLinkFrame.OnClick)Delegate.Combine(itemComeLink.onClick, new ComLinkFrame.OnClick(this.OnItemLinkClick));
			}
		}

		// Token: 0x06010A7F RID: 68223 RVA: 0x004B7408 File Offset: 0x004B5808
		private void OnEnable()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010A80 RID: 68224 RVA: 0x004B74B0 File Offset: 0x004B58B0
		private void OnDisable()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		}

		// Token: 0x06010A81 RID: 68225 RVA: 0x004B7555 File Offset: 0x004B5955
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x06010A82 RID: 68226 RVA: 0x004B7560 File Offset: 0x004B5960
		private void UnBindUiEventSystem()
		{
			if (this.itemTipButton != null)
			{
				this.itemTipButton.onClick.RemoveAllListeners();
			}
			if (this.itemComeLink != null)
			{
				ItemComeLink itemComeLink = this.itemComeLink;
				itemComeLink.onClick = (ComLinkFrame.OnClick)Delegate.Remove(itemComeLink.onClick, new ComLinkFrame.OnClick(this.OnItemLinkClick));
			}
		}

		// Token: 0x06010A83 RID: 68227 RVA: 0x004B75C6 File Offset: 0x004B59C6
		public void InitMoneyItem(int moneyId)
		{
			this._itemId = moneyId;
			this.InitMoneyItemView();
		}

		// Token: 0x06010A84 RID: 68228 RVA: 0x004B75D8 File Offset: 0x004B59D8
		private void InitMoneyItemView()
		{
			this._itemData = ItemDataManager.CreateItemDataFromTable(this._itemId, 100, 0);
			if (this._itemData == null)
			{
				Logger.LogErrorFormat("InitMoneyItemView itemData is null and itemId is {0}", new object[]
				{
					this._itemId
				});
				base.gameObject.CustomActive(false);
				return;
			}
			if (!DataManager<ShopNewDataManager>.GetInstance().IsMoneyItemShowName(this._itemId))
			{
				this.itemIcon.gameObject.CustomActive(true);
				ETCImageLoader.LoadSprite(ref this.itemIcon, this._itemData.Icon, true);
				this.itemNameText.gameObject.CustomActive(false);
			}
			else
			{
				this.itemIcon.gameObject.CustomActive(false);
				this.itemNameText.gameObject.CustomActive(true);
				this.itemNameText.text = this._itemData.Name;
			}
			this.UpdateItemCount();
			this.itemComeLink.bNotEnough = false;
			this.itemComeLink.iItemLinkID = this._itemId;
		}

		// Token: 0x06010A85 RID: 68229 RVA: 0x004B76E0 File Offset: 0x004B5AE0
		private void OnItemTipButtonClick()
		{
			if (this._itemData == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			DataManager<ItemTipManager>.GetInstance().ShowTip(this._itemData, null, 4, true, false, true);
		}

		// Token: 0x06010A86 RID: 68230 RVA: 0x004B770D File Offset: 0x004B5B0D
		private void OnItemLinkClick()
		{
		}

		// Token: 0x06010A87 RID: 68231 RVA: 0x004B7710 File Offset: 0x004B5B10
		private void OnAddNewItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.TableID == this._itemId)
				{
					this.UpdateItemCount();
					break;
				}
			}
		}

		// Token: 0x06010A88 RID: 68232 RVA: 0x004B776D File Offset: 0x004B5B6D
		private void OnRemoveItem(ItemData data)
		{
			if (data != null && data.TableID == this._itemId)
			{
				this.UpdateItemCount();
			}
		}

		// Token: 0x06010A89 RID: 68233 RVA: 0x004B778C File Offset: 0x004B5B8C
		private void OnUpdateItem(List<Item> items)
		{
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.TableID == this._itemId)
				{
					this.UpdateItemCount();
					break;
				}
			}
		}

		// Token: 0x06010A8A RID: 68234 RVA: 0x004B77E9 File Offset: 0x004B5BE9
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateItemCount();
		}

		// Token: 0x06010A8B RID: 68235 RVA: 0x004B77F4 File Offset: 0x004B5BF4
		private void UpdateItemCount()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._itemId, false);
			if (this.itemCountText != null)
			{
				this.itemCountText.text = ownedItemCount.ToString();
				this.itemCountText.text = Utility.ToThousandsSeparator((ulong)((long)ownedItemCount));
			}
		}

		// Token: 0x0400AA2E RID: 43566
		private int _itemId;

		// Token: 0x0400AA2F RID: 43567
		private ItemData _itemData;

		// Token: 0x0400AA30 RID: 43568
		[SerializeField]
		private Image itemIcon;

		// Token: 0x0400AA31 RID: 43569
		[SerializeField]
		private Text itemNameText;

		// Token: 0x0400AA32 RID: 43570
		[SerializeField]
		private Text itemCountText;

		// Token: 0x0400AA33 RID: 43571
		[SerializeField]
		private Button itemTipButton;

		// Token: 0x0400AA34 RID: 43572
		[SerializeField]
		private ItemComeLink itemComeLink;
	}
}
