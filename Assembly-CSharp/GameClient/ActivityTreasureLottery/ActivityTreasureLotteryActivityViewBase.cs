using System;
using DataModel;
using Scripts.UI;
using UnityEngine;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013EA RID: 5098
	public abstract class ActivityTreasureLotteryActivityViewBase<T> : MonoBehaviour, IActivityTreasureLotteryActivityViewBase, IDisposable where T : IActivityTreasureLotteryModelBase
	{
		// Token: 0x17001BEA RID: 7146
		// (get) Token: 0x0600C5A4 RID: 50596 RVA: 0x002F6DE3 File Offset: 0x002F51E3
		public int SelectId
		{
			get
			{
				return this.mSelectId;
			}
		}

		// Token: 0x0600C5A5 RID: 50597 RVA: 0x002F6DEB File Offset: 0x002F51EB
		public void Dispose()
		{
			this.UnBindEvents();
			base.gameObject.CustomActive(false);
			this.mSelectId = 0;
			this.mSelectLotteryId = -1;
			if (this.mSelectedItem != null)
			{
				this.mSelectedItem = null;
			}
			this.OnDispose();
		}

		// Token: 0x0600C5A6 RID: 50598 RVA: 0x002F6E28 File Offset: 0x002F5228
		public void Init(IActivityTreasureLotteryDataMananger dataManager, string itemPrefabPath, ComUIListScript scrollList)
		{
			this.mScrollList = scrollList;
			this.mDataManager = dataManager;
			this.BindEvents();
			if (this.mScrollList != null)
			{
				this.mScrollList.InitialLizeWithExternalElement(itemPrefabPath);
				this.mScrollList.SetElementAmount(0);
				this.mScrollList.ResetContentPosition();
				this.mScrollList.SelectElement(-1, true);
			}
			this.OnInit();
			this.UpdateData();
		}

		// Token: 0x0600C5A7 RID: 50599 RVA: 0x002F6E98 File Offset: 0x002F5298
		public virtual void UpdateData()
		{
			if (this.mSelectLotteryId != -1 && this.mDataManager != null)
			{
				this.mSelectId = this.mDataManager.GetModelIndexByLotteryId<T>(this.mSelectLotteryId);
			}
			if (this.mScrollList != null && this.mDataManager != null)
			{
				int modelAmount = this.mDataManager.GetModelAmount<T>();
				this.mScrollList.UpdateElementAmount(modelAmount);
				if (modelAmount > 0)
				{
					this.mScrollList.SelectElement(this.mSelectId, true);
				}
			}
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600C5A8 RID: 50600 RVA: 0x002F6F2C File Offset: 0x002F532C
		protected virtual void OnInit()
		{
		}

		// Token: 0x0600C5A9 RID: 50601 RVA: 0x002F6F2E File Offset: 0x002F532E
		protected virtual void OnDispose()
		{
		}

		// Token: 0x0600C5AA RID: 50602
		protected abstract void OnSelectItem(T data);

		// Token: 0x0600C5AB RID: 50603 RVA: 0x002F6F30 File Offset: 0x002F5330
		protected virtual void BindEvents()
		{
			if (this.mScrollList != null)
			{
				ComUIListScript comUIListScript = this.mScrollList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
				ComUIListScript comUIListScript2 = this.mScrollList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript3 = this.mScrollList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript4 = this.mScrollList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0600C5AC RID: 50604 RVA: 0x002F6FF0 File Offset: 0x002F53F0
		protected virtual void UnBindEvents()
		{
			if (this.mScrollList != null)
			{
				ComUIListScript comUIListScript = this.mScrollList;
				comUIListScript.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelected));
				ComUIListScript comUIListScript2 = this.mScrollList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript3 = this.mScrollList;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemVisiable));
				ComUIListScript comUIListScript4 = this.mScrollList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0600C5AD RID: 50605 RVA: 0x002F70B0 File Offset: 0x002F54B0
		protected virtual void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			if (item == null)
			{
				return;
			}
			if (this.mDataManager != null)
			{
				IActivityTreasureLotteryItem component = item.GetComponent<IActivityTreasureLotteryItem>();
				if (component != null)
				{
					component.OnSelect(bSelected);
				}
			}
		}

		// Token: 0x0600C5AE RID: 50606 RVA: 0x002F70EC File Offset: 0x002F54EC
		protected virtual void OnItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mDataManager != null)
			{
				IActivityTreasureLotteryItem component = item.GetComponent<IActivityTreasureLotteryItem>();
				T model = this.mDataManager.GetModel<T>(item.m_index);
				if (component != null)
				{
					component.Init<T>(model, this.mSelectId == item.m_index);
				}
			}
		}

		// Token: 0x0600C5AF RID: 50607 RVA: 0x002F7148 File Offset: 0x002F5548
		protected virtual void OnItemSelected(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mSelectedItem != null && this.mSelectedItem != item.GetComponent<IActivityTreasureLotteryItem>())
			{
				this.mSelectedItem.OnSelect(false);
			}
			this.mSelectId = item.m_index;
			if (this.mDataManager != null)
			{
				this.OnSelectItem(this.mDataManager.GetModel<T>(item.m_index));
				this.mSelectedItem = item.GetComponent<IActivityTreasureLotteryItem>();
				if (this.mSelectedItem != null)
				{
					this.mSelectedItem.OnSelect(true);
				}
			}
		}

		// Token: 0x040070F0 RID: 28912
		protected int mSelectId;

		// Token: 0x040070F1 RID: 28913
		protected int mSelectLotteryId = -1;

		// Token: 0x040070F2 RID: 28914
		protected ComUIListScript mScrollList;

		// Token: 0x040070F3 RID: 28915
		protected IActivityTreasureLotteryDataMananger mDataManager;

		// Token: 0x040070F4 RID: 28916
		protected IActivityTreasureLotteryItem mSelectedItem;
	}
}
