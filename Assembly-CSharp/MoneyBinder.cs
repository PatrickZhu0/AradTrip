using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200139E RID: 5022
internal class MoneyBinder : MonoBehaviour
{
	// Token: 0x0600C313 RID: 49939 RVA: 0x002E8E1C File Offset: 0x002E721C
	public static MoneyBinder Create(GameObject goLocal, Image image, Text text, Text name, int iTable, MoneyBinder.MoneyShowType eMoneyShowType)
	{
		ItemData itemData = ItemDataManager.CreateItemDataFromTable(iTable, 100, 0);
		if (itemData != null)
		{
			MoneyBinder moneyBinder = goLocal.GetComponent<MoneyBinder>();
			if (moneyBinder == null)
			{
				moneyBinder = goLocal.AddComponent<MoneyBinder>();
			}
			if (moneyBinder != null)
			{
				moneyBinder.m_eMoneyBinderType = PlayerBaseData.MoneyBinderType.MBT_OTHER;
				moneyBinder.iLinkItemID = iTable;
				moneyBinder.image = image;
				moneyBinder.text = text;
				moneyBinder.moneyName = name;
				moneyBinder.eMoneyShowType = eMoneyShowType;
				moneyBinder.Init();
				moneyBinder.Bind();
				return moneyBinder;
			}
		}
		return null;
	}

	// Token: 0x17001BDB RID: 7131
	// (get) Token: 0x0600C314 RID: 49940 RVA: 0x002E8E9B File Offset: 0x002E729B
	// (set) Token: 0x0600C315 RID: 49941 RVA: 0x002E8EA3 File Offset: 0x002E72A3
	public int LinkItemID
	{
		get
		{
			return this.iLinkItemID;
		}
		set
		{
			this.iLinkItemID = value;
			this.Init();
		}
	}

	// Token: 0x0600C316 RID: 49942 RVA: 0x002E8EB2 File Offset: 0x002E72B2
	private void Start()
	{
		this.Init();
		this.Bind();
	}

	// Token: 0x0600C317 RID: 49943 RVA: 0x002E8EC0 File Offset: 0x002E72C0
	private void Bind()
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

	// Token: 0x0600C318 RID: 49944 RVA: 0x002E8F68 File Offset: 0x002E7368
	private void OnAddNewItem(List<Item> items)
	{
		for (int i = 0; i < items.Count; i++)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
			if (item != null && item.TableID == this.iLinkItemID)
			{
				this.Init();
				break;
			}
		}
	}

	// Token: 0x0600C319 RID: 49945 RVA: 0x002E8FC5 File Offset: 0x002E73C5
	private void OnRemoveItem(ItemData data)
	{
		if (data != null && data.TableID == this.iLinkItemID)
		{
			this.Init();
		}
	}

	// Token: 0x0600C31A RID: 49946 RVA: 0x002E8FE4 File Offset: 0x002E73E4
	private void OnUpdateItem(List<Item> items)
	{
		for (int i = 0; i < items.Count; i++)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(items[i].uid);
			if (item != null && item.TableID == this.iLinkItemID)
			{
				this.Init();
				break;
			}
		}
	}

	// Token: 0x0600C31B RID: 49947 RVA: 0x002E9044 File Offset: 0x002E7444
	private void OnDestroy()
	{
		ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
		instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
		ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
		instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
		ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
		instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
		PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
		instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
		this.text = null;
		this.image = null;
	}

	// Token: 0x0600C31C RID: 49948 RVA: 0x002E90F7 File Offset: 0x002E74F7
	private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
	{
		if (eTarget == this.m_eMoneyBinderType || this.m_eMoneyBinderType == PlayerBaseData.MoneyBinderType.MBT_OTHER)
		{
			this.Init();
		}
	}

	// Token: 0x0600C31D RID: 49949 RVA: 0x002E9118 File Offset: 0x002E7518
	private void Init()
	{
		if (this.text != null)
		{
			if (this.m_eMoneyBinderType != PlayerBaseData.MoneyBinderType.MBT_OTHER)
			{
				switch (this.m_eMoneyBinderType)
				{
				case PlayerBaseData.MoneyBinderType.MBT_GOLD:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().Gold.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_BIND_GOLD:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().BindGold.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_POINT:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().Ticket.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_BIND_POINT:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().BindTicket.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_ALIVE_COIN:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().AliveCoin.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ResurrectionCcurrency);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_WARRIOR_SOUL:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().WarriorSoul.ToString();
					this.iLinkItemID = 0;
					break;
				case PlayerBaseData.MoneyBinderType.MBT_PKMONSETR_COIN:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().uiPkCoin.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.DUEL_COIN);
					break;
				case PlayerBaseData.MoneyBinderType.MBT_FIGHT_COIN:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().uiPkCoin.ToString();
					this.iLinkItemID = 0;
					break;
				case PlayerBaseData.MoneyBinderType.MBT_GUILD_CONTRIBUTION:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().guildContribution.ToString();
					this.iLinkItemID = 0;
					break;
				case PlayerBaseData.MoneyBinderType.MBT_GoodTeacher_Value:
					this.text.text = DataManager<PlayerBaseData>.GetInstance().GoodTeacherValue.ToString();
					this.iLinkItemID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_MASTER_GOODTEACH_VALUE);
					break;
				}
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.iLinkItemID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this.image != null)
					{
						ETCImageLoader.LoadSprite(ref this.image, tableItem.Icon, true);
						this.image.CustomActive(this.eMoneyShowType == MoneyBinder.MoneyShowType.MST_NORMAL);
					}
					if (this.moneyName != null)
					{
						this.moneyName.text = tableItem.Name;
						this.moneyName.CustomActive(this.eMoneyShowType == MoneyBinder.MoneyShowType.MST_MONEY_NAME);
					}
				}
			}
			else
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.iLinkItemID, false);
				this.text.text = ownedItemCount.ToString();
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.iLinkItemID, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					if (this.image != null)
					{
						ETCImageLoader.LoadSprite(ref this.image, tableItem2.Icon, true);
						this.image.CustomActive(this.eMoneyShowType == MoneyBinder.MoneyShowType.MST_NORMAL);
					}
					if (this.moneyName != null)
					{
						this.moneyName.text = tableItem2.Name;
						this.moneyName.CustomActive(this.eMoneyShowType == MoneyBinder.MoneyShowType.MST_MONEY_NAME);
					}
				}
			}
		}
	}

	// Token: 0x04006E74 RID: 28276
	public PlayerBaseData.MoneyBinderType m_eMoneyBinderType = PlayerBaseData.MoneyBinderType.MBT_OTHER;

	// Token: 0x04006E75 RID: 28277
	public Text text;

	// Token: 0x04006E76 RID: 28278
	public Text moneyName;

	// Token: 0x04006E77 RID: 28279
	public Image image;

	// Token: 0x04006E78 RID: 28280
	public int iLinkItemID;

	// Token: 0x04006E79 RID: 28281
	public MoneyBinder.MoneyShowType eMoneyShowType;

	// Token: 0x0200139F RID: 5023
	public enum MoneyShowType
	{
		// Token: 0x04006E7B RID: 28283
		MST_NORMAL,
		// Token: 0x04006E7C RID: 28284
		MST_MONEY_NAME
	}
}
