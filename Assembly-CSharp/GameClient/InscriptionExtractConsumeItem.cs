using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B43 RID: 6979
	public class InscriptionExtractConsumeItem : MonoBehaviour
	{
		// Token: 0x06011209 RID: 70153 RVA: 0x004EA3E4 File Offset: 0x004E87E4
		private void Awake()
		{
			if (this.mItemComLinkBtn != null)
			{
				this.mItemComLinkBtn.onClick.RemoveAllListeners();
				this.mItemComLinkBtn.onClick.AddListener(new UnityAction(this.OnItemComLinkClick));
			}
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance3 = DataManager<PlayerBaseData>.GetInstance();
			instance3.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance3.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
		}

		// Token: 0x0601120A RID: 70154 RVA: 0x004EA4A0 File Offset: 0x004E88A0
		private void OnDestroy()
		{
			this.mInscriptionConsume = null;
			this.mComItem = null;
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			PlayerBaseData instance3 = DataManager<PlayerBaseData>.GetInstance();
			instance3.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance3.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this._OnMoneyChanged));
		}

		// Token: 0x0601120B RID: 70155 RVA: 0x004EA530 File Offset: 0x004E8930
		public void OnItemVisiable(InscriptionConsume consume)
		{
			this.mInscriptionConsume = consume;
			if (this.mInscriptionConsume == null)
			{
				return;
			}
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mItemParent);
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(consume.itemId, 100, 0);
			if (itemData != null)
			{
				ComItem comItem = this.mComItem;
				ItemData item = itemData;
				if (InscriptionExtractConsumeItem.<>f__mg$cache0 == null)
				{
					InscriptionExtractConsumeItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, InscriptionExtractConsumeItem.<>f__mg$cache0);
			}
			this.UpdateConsumNumber();
		}

		// Token: 0x0601120C RID: 70156 RVA: 0x004EA5B8 File Offset: 0x004E89B8
		private void UpdateConsumNumber()
		{
			int num = 0;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mInscriptionConsume.itemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == ItemTable.eSubType.GOLD || tableItem.SubType == ItemTable.eSubType.BindGOLD)
				{
					num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.mInscriptionConsume.itemId, false);
				}
				else
				{
					num = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(this.mInscriptionConsume.itemId);
				}
			}
			int count = this.mInscriptionConsume.count;
			if (num >= count)
			{
				this.mOwnNum.color = Color.green;
				this.mExpendNum.color = Color.white;
				this.mItemComLink.CustomActive(false);
			}
			else
			{
				this.mOwnNum.color = Color.red;
				this.mExpendNum.color = Color.red;
				this.mItemComLink.CustomActive(true);
			}
			this.mOwnNum.text = num.ToString();
			this.mExpendNum.text = count.ToString();
			this.mComItem.SetShowNotEnoughState(this.mItemComLink.activeSelf);
		}

		// Token: 0x0601120D RID: 70157 RVA: 0x004EA6F0 File Offset: 0x004E8AF0
		private void OnItemComLinkClick()
		{
			ItemComeLink.OnLink(this.mInscriptionConsume.itemId, 0, true, null, false, false, false, null, string.Empty);
		}

		// Token: 0x0601120E RID: 70158 RVA: 0x004EA719 File Offset: 0x004E8B19
		private void _OnAddNewItem(List<Item> items)
		{
			this.UpdateConsumNumber();
		}

		// Token: 0x0601120F RID: 70159 RVA: 0x004EA721 File Offset: 0x004E8B21
		private void _OnRemoveItem(ItemData itemData)
		{
			this.UpdateConsumNumber();
		}

		// Token: 0x06011210 RID: 70160 RVA: 0x004EA729 File Offset: 0x004E8B29
		private void _OnMoneyChanged(PlayerBaseData.MoneyBinderType eMoneyBinderType)
		{
			this.UpdateConsumNumber();
		}

		// Token: 0x0400B093 RID: 45203
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x0400B094 RID: 45204
		[SerializeField]
		private GameObject mItemComLink;

		// Token: 0x0400B095 RID: 45205
		[SerializeField]
		private Text mOwnNum;

		// Token: 0x0400B096 RID: 45206
		[SerializeField]
		private Text mExpendNum;

		// Token: 0x0400B097 RID: 45207
		[SerializeField]
		private Button mItemComLinkBtn;

		// Token: 0x0400B098 RID: 45208
		private InscriptionConsume mInscriptionConsume;

		// Token: 0x0400B099 RID: 45209
		private ComItem mComItem;

		// Token: 0x0400B09A RID: 45210
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
