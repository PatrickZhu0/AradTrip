using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001382 RID: 4994
	public class ComMonthCardRewardLockersBoard : MonoBehaviour
	{
		// Token: 0x0600C1B5 RID: 49589 RVA: 0x002E2D5B File Offset: 0x002E115B
		private void Awake()
		{
			this._InitItemGrids();
		}

		// Token: 0x0600C1B6 RID: 49590 RVA: 0x002E2D63 File Offset: 0x002E1163
		private void OnDestroy()
		{
			this._UnInitGrids();
		}

		// Token: 0x0600C1B7 RID: 49591 RVA: 0x002E2D6B File Offset: 0x002E116B
		private void OnApplicationFocus(bool bAppFocus)
		{
			if (bAppFocus)
			{
				DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqMonthCardRewardLockersItems();
			}
		}

		// Token: 0x0600C1B8 RID: 49592 RVA: 0x002E2D80 File Offset: 0x002E1180
		private void _InitItemGrids()
		{
			if (null == this.mComUIGrids)
			{
				return;
			}
			if (this.mComUIGrids.IsInitialised())
			{
				return;
			}
			this.mComUIGrids.Initialize();
			ComUIListScript comUIListScript = this.mComUIGrids;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnComUIGridsItemBind));
			ComUIListScript comUIListScript2 = this.mComUIGrids;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnComUIGridsItemVisiable));
			ComUIListScript comUIListScript3 = this.mComUIGrids;
			comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnComUIGridsItemUpdate));
			ComUIListScript comUIListScript4 = this.mComUIGrids;
			comUIListScript4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnComUIGridsItemRecycle));
			this.mComUIGrids.SetElementAmount(this.GetItemGridTotalCount());
		}

		// Token: 0x0600C1B9 RID: 49593 RVA: 0x002E2E68 File Offset: 0x002E1268
		private void _UnInitGrids()
		{
			if (null != this.mComUIGrids)
			{
				ComUIListScript comUIListScript = this.mComUIGrids;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnComUIGridsItemBind));
				ComUIListScript comUIListScript2 = this.mComUIGrids;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnComUIGridsItemVisiable));
				ComUIListScript comUIListScript3 = this.mComUIGrids;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnComUIGridsItemUpdate));
				ComUIListScript comUIListScript4 = this.mComUIGrids;
				comUIListScript4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnComUIGridsItemRecycle));
			}
		}

		// Token: 0x0600C1BA RID: 49594 RVA: 0x002E2F22 File Offset: 0x002E1322
		private ComItemGrid _OnComUIGridsItemBind(GameObject go)
		{
			if (null == go)
			{
				return null;
			}
			return go.GetComponent<ComItemGrid>();
		}

		// Token: 0x0600C1BB RID: 49595 RVA: 0x002E2F38 File Offset: 0x002E1338
		private void _OnComUIGridsItemVisiable(ComUIListElementScript item)
		{
			this._RefreshGridsItem(item);
		}

		// Token: 0x0600C1BC RID: 49596 RVA: 0x002E2F41 File Offset: 0x002E1341
		private void _OnComUIGridsItemUpdate(ComUIListElementScript item)
		{
			this._RefreshGridsItem(item);
		}

		// Token: 0x0600C1BD RID: 49597 RVA: 0x002E2F4C File Offset: 0x002E134C
		private void _RefreshGridsItem(ComUIListElementScript item)
		{
			if (null == item || this.mLockersItems == null)
			{
				return;
			}
			int index = item.m_index;
			ComItemGrid comItemGrid = item.gameObjectBindScript as ComItemGrid;
			if (index >= 0 && index < this.mLockersItems.Count)
			{
				MonthCardRewardLockersItem monthCardRewardLockersItem = this.mLockersItems[index];
				if (monthCardRewardLockersItem == null || monthCardRewardLockersItem.itemdata == null)
				{
					return;
				}
				if (comItemGrid != null)
				{
					comItemGrid.SetGridItemData(monthCardRewardLockersItem.itemdata, true, monthCardRewardLockersItem.isHignestGradeItem);
					comItemGrid.SetGridActive(true);
				}
			}
			else if (comItemGrid != null)
			{
				comItemGrid.SetGridActive(false);
			}
		}

		// Token: 0x0600C1BE RID: 49598 RVA: 0x002E2FFC File Offset: 0x002E13FC
		private void _OnComUIGridsItemRecycle(ComUIListElementScript item)
		{
			if (null == item)
			{
				return;
			}
			ComItemGrid component = item.GetComponent<ComItemGrid>();
			if (component != null)
			{
				component.SetGridActive(false);
			}
		}

		// Token: 0x0600C1BF RID: 49599 RVA: 0x002E3030 File Offset: 0x002E1430
		public void RefreshItemGrids(List<MonthCardRewardLockersItem> _lockersItems)
		{
			this.mLockersItems = _lockersItems;
			if (null != this.mComUIGrids)
			{
				this.mComUIGrids.UpdateElement();
			}
		}

		// Token: 0x0600C1C0 RID: 49600 RVA: 0x002E3055 File Offset: 0x002E1455
		public int GetItemGridTotalCount()
		{
			return DataManager<MonthCardRewardLockersDataManager>.GetInstance().MonthCardRewardLockersGridCount;
		}

		// Token: 0x04006DC0 RID: 28096
		private List<MonthCardRewardLockersItem> mLockersItems;

		// Token: 0x04006DC1 RID: 28097
		[SerializeField]
		private ComUIListScript mComUIGrids;
	}
}
