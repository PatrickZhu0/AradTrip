using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200001C RID: 28
	internal class ComArmorCtrlRedBinder : MonoBehaviour
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00007EF8 File Offset: 0x000062F8
		// (set) Token: 0x06000099 RID: 153 RVA: 0x00007F00 File Offset: 0x00006300
		private bool Dirty
		{
			get
			{
				return this.bDirty;
			}
			set
			{
				this.bDirty = value;
				InvokeMethod.RemoveInvokeCall(this);
				InvokeMethod.Invoke(this, 0f, delegate()
				{
					this._Check();
				});
			}
		}

		// Token: 0x0600009A RID: 154 RVA: 0x00007F28 File Offset: 0x00006328
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnItemUseSeccess));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			this.Dirty = true;
		}

		// Token: 0x0600009B RID: 155 RVA: 0x00007FC9 File Offset: 0x000063C9
		private void _OnAddNewItem(List<Item> items)
		{
			this.Dirty = true;
		}

		// Token: 0x0600009C RID: 156 RVA: 0x00007FD2 File Offset: 0x000063D2
		private void _OnRemoveItem(ItemData data)
		{
			this.Dirty = true;
		}

		// Token: 0x0600009D RID: 157 RVA: 0x00007FDB File Offset: 0x000063DB
		private void _OnUpdateItem(List<Item> items)
		{
			this.Dirty = true;
		}

		// Token: 0x0600009E RID: 158 RVA: 0x00007FE4 File Offset: 0x000063E4
		private void Start()
		{
			this.Dirty = true;
		}

		// Token: 0x0600009F RID: 159 RVA: 0x00007FED File Offset: 0x000063ED
		public void OnClickOpenLowArmyHintFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<LowArmyHintFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x060000A0 RID: 160 RVA: 0x00008004 File Offset: 0x00006404
		private void _Check()
		{
			bool flag = false;
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
				if (item != null)
				{
					int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
					if (masterPriority == 2)
					{
						flag = true;
						break;
					}
				}
			}
			UnityEvent unityEvent = (!flag) ? this.onFailed : this.onOK;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x000080B1 File Offset: 0x000064B1
		private void _OnItemUseSeccess(UIEvent uiEvent)
		{
			this.Dirty = true;
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x000080BC File Offset: 0x000064BC
		private void OnDestroy()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this._OnItemUseSeccess));
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance2.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance3.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			InvokeMethod.RemoveInvokeCall(this);
		}

		// Token: 0x0400006E RID: 110
		public UnityEvent onOK;

		// Token: 0x0400006F RID: 111
		public UnityEvent onFailed;

		// Token: 0x04000070 RID: 112
		private bool bDirty;
	}
}
