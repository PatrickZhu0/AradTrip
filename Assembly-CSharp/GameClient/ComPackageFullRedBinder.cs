using System;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x020016A2 RID: 5794
	internal class ComPackageFullRedBinder : MonoBehaviour
	{
		// Token: 0x0600E39A RID: 58266 RVA: 0x003AA6F0 File Offset: 0x003A8AF0
		public bool HasFlag(ComPackageFullRedBinder.PackageTab iFlag)
		{
			for (int i = 0; i < this.mFlags.Length; i++)
			{
				if (this.mFlags[i] == iFlag)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600E39B RID: 58267 RVA: 0x003AA728 File Offset: 0x003A8B28
		private void _CheckRedPoints()
		{
			bool flag = false;
			int num = 0;
			while (num < 4 && !flag)
			{
				if (this.HasFlag((ComPackageFullRedBinder.PackageTab)num))
				{
					switch (num)
					{
					case 0:
						flag = this._CheckEquipmentIsFull();
						break;
					case 1:
						flag = this._CheckFashionIsFull();
						break;
					case 2:
						flag = this._CheckTitleIsFull();
						break;
					case 3:
						flag = false;
						break;
					}
				}
				num++;
			}
			UnityEvent unityEvent = (!flag) ? this.onFailed : this.onSucceed;
			if (unityEvent != null)
			{
				unityEvent.Invoke();
			}
		}

		// Token: 0x0600E39C RID: 58268 RVA: 0x003AA7CC File Offset: 0x003A8BCC
		private bool _CheckEquipmentIsFull()
		{
			return this._checkIsFullByType(EPackageType.Equip);
		}

		// Token: 0x0600E39D RID: 58269 RVA: 0x003AA7D5 File Offset: 0x003A8BD5
		private bool _CheckFashionIsFull()
		{
			return this._checkIsFullByType(EPackageType.Fashion);
		}

		// Token: 0x0600E39E RID: 58270 RVA: 0x003AA7DE File Offset: 0x003A8BDE
		private bool _CheckTitleIsFull()
		{
			return this._checkIsFullByType(EPackageType.Title);
		}

		// Token: 0x0600E39F RID: 58271 RVA: 0x003AA7E8 File Offset: 0x003A8BE8
		private bool _checkIsFullByType(EPackageType type)
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(type);
			int num = 0;
			if (itemsByPackageType != null)
			{
				num = itemsByPackageType.Count;
			}
			return DataManager<PlayerBaseData>.GetInstance().PackTotalSize.Count > (int)type && DataManager<PlayerBaseData>.GetInstance().PackTotalSize[(int)type] <= num;
		}

		// Token: 0x0600E3A0 RID: 58272 RVA: 0x003AA840 File Offset: 0x003A8C40
		private void Awake()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdatePackageTabRedPoint, new ClientEventSystem.UIEventHandler(this._UpdatePackageTabRedPoint));
		}

		// Token: 0x0600E3A1 RID: 58273 RVA: 0x003AA8DA File Offset: 0x003A8CDA
		private void Start()
		{
			this._CheckRedPoints();
		}

		// Token: 0x0600E3A2 RID: 58274 RVA: 0x003AA8E2 File Offset: 0x003A8CE2
		private void _OnAddNewItem(List<Item> items)
		{
			this._CheckRedPoints();
		}

		// Token: 0x0600E3A3 RID: 58275 RVA: 0x003AA8EA File Offset: 0x003A8CEA
		private void _OnUpdateItem(List<Item> items)
		{
			this._CheckRedPoints();
		}

		// Token: 0x0600E3A4 RID: 58276 RVA: 0x003AA8F2 File Offset: 0x003A8CF2
		private void _OnRemoveItem(ItemData data)
		{
			this._CheckRedPoints();
		}

		// Token: 0x0600E3A5 RID: 58277 RVA: 0x003AA8FA File Offset: 0x003A8CFA
		private void _UpdatePackageTabRedPoint(UIEvent uiEvent)
		{
			this._CheckRedPoints();
		}

		// Token: 0x0600E3A6 RID: 58278 RVA: 0x003AA904 File Offset: 0x003A8D04
		private void OnDestroy()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this._OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this._OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this._OnRemoveItem));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdatePackageTabRedPoint, new ClientEventSystem.UIEventHandler(this._UpdatePackageTabRedPoint));
		}

		// Token: 0x04008892 RID: 34962
		public UnityEvent onSucceed;

		// Token: 0x04008893 RID: 34963
		public UnityEvent onFailed;

		// Token: 0x04008894 RID: 34964
		public ComPackageFullRedBinder.PackageTab[] mFlags = new ComPackageFullRedBinder.PackageTab[0];

		// Token: 0x020016A3 RID: 5795
		public enum PackageTab
		{
			// Token: 0x04008896 RID: 34966
			PT_EQUIPMENT,
			// Token: 0x04008897 RID: 34967
			PT_FASHION,
			// Token: 0x04008898 RID: 34968
			PT_TITLE,
			// Token: 0x04008899 RID: 34969
			PT_PET,
			// Token: 0x0400889A RID: 34970
			PT_COUNT
		}
	}
}
