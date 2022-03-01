using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200112A RID: 4394
	public class ComChijiSpecialItem : MonoBehaviour
	{
		// Token: 0x0600A6EA RID: 42730 RVA: 0x0022C0CC File Offset: 0x0022A4CC
		private void Start()
		{
			this._BindUIEvent();
			if (this.ItemID == 0)
			{
				Logger.LogError("[ComChijiSpecialItem] 脚本未绑定 ItemID，请检查预制体 : ChijiMainFrame");
			}
			this.num = DataManager<ItemDataManager>.GetInstance().GetItemCount(this.ItemID);
			if (this.NumText != null)
			{
				this.NumText.text = this.num.ToString();
			}
			if (this.btItem != null)
			{
				this.btItem.onClick.RemoveAllListeners();
				this.btItem.onClick.AddListener(new UnityAction(this._OnClickItem));
			}
		}

		// Token: 0x0600A6EB RID: 42731 RVA: 0x0022C174 File Offset: 0x0022A574
		private void OnDestroy()
		{
			this._UnBindUIEvent();
			this.ItemID = 0;
			this.num = 0;
			if (this.btItem != null)
			{
				this.btItem.onClick.RemoveAllListeners();
				this.btItem = null;
			}
			if (this.NumText != null)
			{
				this.NumText = null;
			}
			this.isUseItem = false;
			this.timer = 0f;
			this.CD = 0;
		}

		// Token: 0x0600A6EC RID: 42732 RVA: 0x0022C1F0 File Offset: 0x0022A5F0
		private void _BindUIEvent()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.OnItemUseSuccess));
		}

		// Token: 0x0600A6ED RID: 42733 RVA: 0x0022C28C File Offset: 0x0022A68C
		private void _UnBindUIEvent()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.OnItemUseSuccess));
		}

		// Token: 0x0600A6EE RID: 42734 RVA: 0x0022C328 File Offset: 0x0022A728
		private void _OnAddNewItem(List<Item> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				if ((ulong)items[i].tableID == (ulong)((long)this.ItemID))
				{
					this.num += (int)items[i].num;
					flag = true;
				}
			}
			if (flag && this.NumText != null)
			{
				this.NumText.text = this.num.ToString();
			}
		}

		// Token: 0x0600A6EF RID: 42735 RVA: 0x0022C3BC File Offset: 0x0022A7BC
		private void _OnRemoveItem(ItemData data)
		{
			if (data.TableID != this.ItemID)
			{
				return;
			}
			this.num -= data.Count;
			if (this.NumText != null)
			{
				this.NumText.text = this.num.ToString();
			}
		}

		// Token: 0x0600A6F0 RID: 42736 RVA: 0x0022C41C File Offset: 0x0022A81C
		private void _OnUpdateItem(List<Item> items)
		{
			bool flag = false;
			for (int i = 0; i < items.Count; i++)
			{
				if ((ulong)items[i].tableID == (ulong)((long)this.ItemID))
				{
					this.num = (int)items[i].num;
					flag = true;
				}
			}
			if (flag && this.NumText != null)
			{
				this.NumText.text = this.num.ToString();
			}
		}

		// Token: 0x0600A6F1 RID: 42737 RVA: 0x0022C4A8 File Offset: 0x0022A8A8
		private void OnItemUseSuccess(UIEvent uiEvent)
		{
			object param = uiEvent.Param1;
			if (param is ItemData)
			{
				ChijiItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>((param as ItemData).TableID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.Type == ChijiItemTable.eType.EXPENDABLE && tableItem.SubType == ChijiItemTable.eSubType.ChijiHp)
				{
					ChijiItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>(this.ItemID, string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.Type == ChijiItemTable.eType.EXPENDABLE && tableItem2.SubType == ChijiItemTable.eSubType.ChijiHp)
					{
						this._GetCD(this.ItemID);
					}
				}
			}
			else if (param is int && (int)param == this.ItemID)
			{
				this._GetCD(this.ItemID);
			}
		}

		// Token: 0x0600A6F2 RID: 42738 RVA: 0x0022C57C File Offset: 0x0022A97C
		private void _GetCD(int itemID)
		{
			ChijiItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>(this.ItemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.CD = tableItem.CoolTime;
			}
			this.timer = 0f;
			this._SetTime(true, this.CD);
			this.isUseItem = true;
		}

		// Token: 0x0600A6F3 RID: 42739 RVA: 0x0022C5D8 File Offset: 0x0022A9D8
		private void _SetTime(bool isFlag, int time)
		{
			if (this.mMaskRoot != null)
			{
				this.mMaskRoot.CustomActive(isFlag);
			}
			if (this.mTime != null)
			{
				this.mTime.text = string.Format("{0}s", time);
			}
		}

		// Token: 0x0600A6F4 RID: 42740 RVA: 0x0022C630 File Offset: 0x0022AA30
		private void _OnClickItem()
		{
			if (this.isUseItem)
			{
				SystemNotifyManager.SysNotifyTextAnimation("该道具在CD中", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (this.ItemID == 0)
			{
				return;
			}
			if (this.num <= 0)
			{
				return;
			}
			ItemData itemByTableID = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(this.ItemID, true, true);
			if (itemByTableID == null)
			{
				return;
			}
			ChijiItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChijiItemTable>(this.ItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.ThirdType == ChijiItemTable.eThirdType.UseToSelf)
			{
				if (DataManager<PlayerBaseData>.GetInstance().Chiji_HP_Percent >= 1f)
				{
					SystemNotifyManager.SysNotifyFloatingEffect("你的血量已满，无需补充！", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<ChijiDataManager>.GetInstance().CurrentUseDrugId = this.ItemID;
				DataManager<ItemDataManager>.GetInstance().UseItem(itemByTableID, false, 0, 0);
			}
			else if (tableItem.ThirdType == ChijiItemTable.eThirdType.UseToOther)
			{
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle == null || clientSystemGameBattle.MainPlayer == null)
				{
					return;
				}
				if (tableItem.SubType == ChijiItemTable.eSubType.ST_CHIJI_TRAP)
				{
					clientSystemGameBattle.DoTrap(itemByTableID.GUID, 1U);
				}
				else
				{
					ulong num = clientSystemGameBattle.MainPlayer.FindNearestPlayer();
					if (num != 0UL)
					{
						DataManager<ChijiDataManager>.GetInstance().CreateBullet(itemByTableID.GUID, this.ItemID, num);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ItemUseSuccess, this.ItemID, null, null, null);
					}
					else
					{
						SystemNotifyManager.SysNotifyFloatingEffect("附近没有可投掷的敌人!", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					}
				}
			}
		}

		// Token: 0x0600A6F5 RID: 42741 RVA: 0x0022C7A8 File Offset: 0x0022ABA8
		private void Update()
		{
			if (this.isUseItem)
			{
				this.timer += Time.deltaTime;
				if (this.timer >= 1f)
				{
					this.timer = 0f;
					this.CD--;
					this._SetTime(true, this.CD);
					if (this.CD <= 0)
					{
						this.isUseItem = false;
						this._SetTime(false, this.CD);
					}
				}
			}
		}

		// Token: 0x04005D71 RID: 23921
		public int ItemID;

		// Token: 0x04005D72 RID: 23922
		public Button btItem;

		// Token: 0x04005D73 RID: 23923
		public Text NumText;

		// Token: 0x04005D74 RID: 23924
		[SerializeField]
		private GameObject mMaskRoot;

		// Token: 0x04005D75 RID: 23925
		[SerializeField]
		private Text mTime;

		// Token: 0x04005D76 RID: 23926
		private int num;

		// Token: 0x04005D77 RID: 23927
		private bool isUseItem;

		// Token: 0x04005D78 RID: 23928
		private float timer;

		// Token: 0x04005D79 RID: 23929
		private int CD;
	}
}
