using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200139C RID: 5020
	public class AmberPrivilegeView : MonoBehaviour
	{
		// Token: 0x0600C2FB RID: 49915 RVA: 0x002E86E8 File Offset: 0x002E6AE8
		private void Awake()
		{
			if (!this.InitAmberPrivilegeComUIList)
			{
				if (this.mAmberPrivilegeUIList != null)
				{
					this.mAmberPrivilegeUIList.Initialize();
					ComUIListScript comUIListScript = this.mAmberPrivilegeUIList;
					comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
					ComUIListScript comUIListScript2 = this.mAmberPrivilegeUIList;
					comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				}
				this.InitAmberPrivilegeComUIList = true;
			}
		}

		// Token: 0x0600C2FC RID: 49916 RVA: 0x002E8774 File Offset: 0x002E6B74
		private void OnDestroy()
		{
			if (this.mAmberPrivilegeUIList != null)
			{
				ComUIListScript comUIListScript = this.mAmberPrivilegeUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mAmberPrivilegeUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.InitAmberPrivilegeComUIList = false;
			this.mActivityDataList.Clear();
		}

		// Token: 0x0600C2FD RID: 49917 RVA: 0x002E87F2 File Offset: 0x002E6BF2
		public void InitView()
		{
			this.mActivityDataList = new List<ActiveManager.ActivityData>();
			if (this.mCureentAmberLevelDesc != null)
			{
				this.mCureentAmberLevelDesc.text = DataManager<OPPOPrivilegeDataManager>.GetInstance().GetAmberLevel();
			}
			this.UpdateElementAmount();
		}

		// Token: 0x0600C2FE RID: 49918 RVA: 0x002E882C File Offset: 0x002E6C2C
		public void UpdateElementAmount()
		{
			this.mActivityDataList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iAmberPreivilegeActivityId);
			if (activeData != null)
			{
				this.mActivityDataList.AddRange(activeData.akChildItems);
			}
			this.SortActivityDataList();
			if (this.mAmberPrivilegeUIList != null)
			{
				this.mAmberPrivilegeUIList.SetElementAmount(this.mActivityDataList.Count);
			}
		}

		// Token: 0x0600C2FF RID: 49919 RVA: 0x002E889C File Offset: 0x002E6C9C
		private void SortActivityDataList()
		{
			List<ActiveManager.ActivityData> list = new List<ActiveManager.ActivityData>();
			List<ActiveManager.ActivityData> list2 = new List<ActiveManager.ActivityData>();
			List<ActiveManager.ActivityData> list3 = new List<ActiveManager.ActivityData>();
			int i = 0;
			while (i < this.mActivityDataList.Count)
			{
				ActiveManager.ActivityData activityData = this.mActivityDataList[i];
				switch (activityData.status)
				{
				case 0:
				case 1:
					list2.Add(activityData);
					break;
				case 2:
					list.Add(activityData);
					break;
				case 4:
				case 5:
					list3.Add(activityData);
					break;
				}
				IL_80:
				i++;
				continue;
				goto IL_80;
			}
			this.mActivityDataList.Clear();
			this.mActivityDataList.AddRange(list);
			this.mActivityDataList.AddRange(list2);
			this.mActivityDataList.AddRange(list3);
		}

		// Token: 0x0600C300 RID: 49920 RVA: 0x002E896D File Offset: 0x002E6D6D
		private AmberPrivilegeItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<AmberPrivilegeItem>();
		}

		// Token: 0x0600C301 RID: 49921 RVA: 0x002E8978 File Offset: 0x002E6D78
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			AmberPrivilegeItem amberPrivilegeItem = item.gameObjectBindScript as AmberPrivilegeItem;
			if (amberPrivilegeItem != null && item.m_index >= 0 && item.m_index < this.mActivityDataList.Count)
			{
				amberPrivilegeItem.OnItemVisiable(this.mActivityDataList[item.m_index], new OnAmberPrivilegeItemClick(this.OnSendSubmitActivity));
			}
		}

		// Token: 0x0600C302 RID: 49922 RVA: 0x002E89E2 File Offset: 0x002E6DE2
		private void OnSendSubmitActivity(int iActivityId)
		{
			if (iActivityId == 0)
			{
				return;
			}
			DataManager<ActiveManager>.GetInstance().SendSubmitActivity(iActivityId, 0U);
		}

		// Token: 0x04006E61 RID: 28257
		[SerializeField]
		private Text mCureentAmberLevelDesc;

		// Token: 0x04006E62 RID: 28258
		[SerializeField]
		private ComUIListScript mAmberPrivilegeUIList;

		// Token: 0x04006E63 RID: 28259
		[SerializeField]
		private int iAmberPreivilegeActivityId = 27000;

		// Token: 0x04006E64 RID: 28260
		private bool InitAmberPrivilegeComUIList;

		// Token: 0x04006E65 RID: 28261
		private List<ActiveManager.ActivityData> mActivityDataList;
	}
}
