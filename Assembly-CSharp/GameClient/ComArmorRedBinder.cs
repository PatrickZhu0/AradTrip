using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x0200001D RID: 29
	internal class ComArmorRedBinder : MonoBehaviour
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000816C File Offset: 0x0000656C
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00008174 File Offset: 0x00006574
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

		// Token: 0x060000A7 RID: 167 RVA: 0x0000819C File Offset: 0x0000659C
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

		// Token: 0x060000A8 RID: 168 RVA: 0x0000823D File Offset: 0x0000663D
		private void _OnAddNewItem(List<Item> items)
		{
			this.Dirty = true;
		}

		// Token: 0x060000A9 RID: 169 RVA: 0x00008246 File Offset: 0x00006646
		private void _OnRemoveItem(ItemData data)
		{
			this.Dirty = true;
		}

		// Token: 0x060000AA RID: 170 RVA: 0x0000824F File Offset: 0x0000664F
		private void _OnUpdateItem(List<Item> items)
		{
			this.Dirty = true;
		}

		// Token: 0x060000AB RID: 171 RVA: 0x00008258 File Offset: 0x00006658
		private void Start()
		{
			this.Dirty = true;
		}

		// Token: 0x060000AC RID: 172 RVA: 0x00008264 File Offset: 0x00006664
		private bool _CheckLogic()
		{
			bool result = false;
			if (!DataManager<EquipMasterDataManager>.GetInstance().HasMasterRedPointHinted)
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.WearEquip);
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
					if (item != null)
					{
						int masterPriority = DataManager<EquipMasterDataManager>.GetInstance().GetMasterPriority(DataManager<PlayerBaseData>.GetInstance().JobTableID, (int)item.Quality, (int)item.EquipWearSlotType, (int)item.ThirdType);
						if (masterPriority == 2)
						{
							result = true;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060000AD RID: 173 RVA: 0x000082FC File Offset: 0x000066FC
		private void _Check()
		{
			UnityEvent unityEvent = (!this._CheckLogic()) ? this.onFailed : this.onOK;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x060000AE RID: 174 RVA: 0x00008332 File Offset: 0x00006732
		public void OnClickCancelHint()
		{
			if (this._CheckLogic())
			{
				DataManager<EquipMasterDataManager>.GetInstance().HasMasterRedPointHinted = true;
				this.Dirty = true;
			}
		}

		// Token: 0x060000AF RID: 175 RVA: 0x00008351 File Offset: 0x00006751
		private void _OnItemUseSeccess(UIEvent uiEvent)
		{
			this.Dirty = true;
		}

		// Token: 0x060000B0 RID: 176 RVA: 0x0000835C File Offset: 0x0000675C
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

		// Token: 0x04000071 RID: 113
		public UnityEvent onOK;

		// Token: 0x04000072 RID: 114
		public UnityEvent onFailed;

		// Token: 0x04000073 RID: 115
		private bool bDirty;
	}
}
