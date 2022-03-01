using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E0D RID: 3597
	public class CommonMoneyControl : MonoBehaviour
	{
		// Token: 0x0600900B RID: 36875 RVA: 0x001A9FD1 File Offset: 0x001A83D1
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600900C RID: 36876 RVA: 0x001A9FDC File Offset: 0x001A83DC
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

		// Token: 0x0600900D RID: 36877 RVA: 0x001AA060 File Offset: 0x001A8460
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
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
		}

		// Token: 0x0600900E RID: 36878 RVA: 0x001AA120 File Offset: 0x001A8520
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
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
		}

		// Token: 0x0600900F RID: 36879 RVA: 0x001AA1E0 File Offset: 0x001A85E0
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this._itemId = 0;
			this._itemTable = null;
		}

		// Token: 0x06009010 RID: 36880 RVA: 0x001AA1F8 File Offset: 0x001A85F8
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

		// Token: 0x06009011 RID: 36881 RVA: 0x001AA25E File Offset: 0x001A865E
		public void InitMoneyItem(int moneyId, bool isCounter = false, string itemIdStr = "")
		{
			this._itemId = moneyId;
			this._isCounter = isCounter;
			this._itemIdStr = itemIdStr;
			this.InitMoneyItemView();
		}

		// Token: 0x06009012 RID: 36882 RVA: 0x001AA27C File Offset: 0x001A867C
		private void InitMoneyItemView()
		{
			this._itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemId, string.Empty, string.Empty);
			if (this._itemTable == null)
			{
				Logger.LogErrorFormat("InitMoneyItemView itemTable is null and itemId is {0}", new object[]
				{
					this._itemId
				});
				base.gameObject.CustomActive(false);
				return;
			}
			if (this.itemIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.itemIcon, this._itemTable.Icon, true);
			}
			if (this.itemComeLink != null)
			{
				this.itemComeLink.bNotEnough = false;
				this.itemComeLink.iItemLinkID = this._itemId;
			}
			if (this._isCounter)
			{
				this.UpdateItemValueByCounter();
			}
			else
			{
				this.UpdateItemValue();
			}
		}

		// Token: 0x06009013 RID: 36883 RVA: 0x001AA354 File Offset: 0x001A8754
		private void OnItemTipButtonClick()
		{
			if (this._itemTable == null)
			{
				return;
			}
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(this._itemId, 100, 0);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x06009014 RID: 36884 RVA: 0x001AA396 File Offset: 0x001A8796
		private void OnItemLinkClick()
		{
		}

		// Token: 0x06009015 RID: 36885 RVA: 0x001AA398 File Offset: 0x001A8798
		private void OnAddNewItem(List<Item> items)
		{
			if (this._isCounter)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.TableID == this._itemId)
				{
					this.UpdateItemValue();
					break;
				}
			}
		}

		// Token: 0x06009016 RID: 36886 RVA: 0x001AA401 File Offset: 0x001A8801
		private void OnRemoveItem(ItemData data)
		{
			if (this._isCounter)
			{
				return;
			}
			if (data != null && data.TableID == this._itemId)
			{
				this.UpdateItemValue();
			}
		}

		// Token: 0x06009017 RID: 36887 RVA: 0x001AA42C File Offset: 0x001A882C
		private void OnUpdateItem(List<Item> items)
		{
			if (this._isCounter)
			{
				return;
			}
			for (int i = 0; i < items.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
				if (item != null && item.TableID == this._itemId)
				{
					this.UpdateItemValue();
					break;
				}
			}
		}

		// Token: 0x06009018 RID: 36888 RVA: 0x001AA495 File Offset: 0x001A8895
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			if (this._isCounter)
			{
				return;
			}
			this.UpdateItemValue();
		}

		// Token: 0x06009019 RID: 36889 RVA: 0x001AA4AC File Offset: 0x001A88AC
		private void UpdateItemValue()
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._itemId, false);
			if (this.itemCountText != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)ownedItemCount));
				this.itemCountText.text = text;
			}
		}

		// Token: 0x0600901A RID: 36890 RVA: 0x001AA4F0 File Offset: 0x001A88F0
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this._itemIdStr))
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (!string.Equals(a, this._itemIdStr))
			{
				return;
			}
			this.UpdateItemValueByCounter();
		}

		// Token: 0x0600901B RID: 36891 RVA: 0x001AA544 File Offset: 0x001A8944
		private void UpdateItemValueByCounter()
		{
			int counterValueByCounterStr = CommonUtility.GetCounterValueByCounterStr(this._itemIdStr);
			if (this.itemCountText != null)
			{
				string text = Utility.ToThousandsSeparator((ulong)((long)counterValueByCounterStr));
				this.itemCountText.text = text;
			}
		}

		// Token: 0x04004793 RID: 18323
		private int _itemId;

		// Token: 0x04004794 RID: 18324
		private ItemTable _itemTable;

		// Token: 0x04004795 RID: 18325
		private bool _isCounter;

		// Token: 0x04004796 RID: 18326
		private string _itemIdStr;

		// Token: 0x04004797 RID: 18327
		[SerializeField]
		private Image itemIcon;

		// Token: 0x04004798 RID: 18328
		[SerializeField]
		private Text itemCountText;

		// Token: 0x04004799 RID: 18329
		[SerializeField]
		private Button itemTipButton;

		// Token: 0x0400479A RID: 18330
		[SerializeField]
		private ItemComeLink itemComeLink;
	}
}
