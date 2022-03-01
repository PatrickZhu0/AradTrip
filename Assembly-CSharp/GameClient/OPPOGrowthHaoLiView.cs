using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020013A4 RID: 5028
	public class OPPOGrowthHaoLiView : MonoBehaviour
	{
		// Token: 0x0600C338 RID: 49976 RVA: 0x002E9B5C File Offset: 0x002E7F5C
		private void Awake()
		{
			if (!this.bInitOppoGrowthHaoLiUIList)
			{
				if (this.mOppoGrowthHaoLiUIList != null)
				{
					this.mOppoGrowthHaoLiUIList.Initialize();
					ComUIListScript comUIListScript = this.mOppoGrowthHaoLiUIList;
					comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
					ComUIListScript comUIListScript2 = this.mOppoGrowthHaoLiUIList;
					comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				}
				this.bInitOppoGrowthHaoLiUIList = true;
			}
		}

		// Token: 0x0600C339 RID: 49977 RVA: 0x002E9BE8 File Offset: 0x002E7FE8
		private void OnDestroy()
		{
			if (this.mOppoGrowthHaoLiUIList != null)
			{
				ComUIListScript comUIListScript = this.mOppoGrowthHaoLiUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mOppoGrowthHaoLiUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.bInitOppoGrowthHaoLiUIList = false;
			this.mActivityDataList.Clear();
		}

		// Token: 0x0600C33A RID: 49978 RVA: 0x002E9C66 File Offset: 0x002E8066
		public void InitView()
		{
			this.mActivityDataList = new List<ActiveManager.ActivityData>();
			this.UpdateElementAmount();
		}

		// Token: 0x0600C33B RID: 49979 RVA: 0x002E9C7C File Offset: 0x002E807C
		public void UpdateElementAmount()
		{
			this.mActivityDataList.Clear();
			ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(this.iOPPOGrowthHaoLiActivityId);
			if (activeData != null)
			{
				this.mActivityDataList.AddRange(activeData.akChildItems);
			}
			this.SortActivityDataList();
			if (this.mOppoGrowthHaoLiUIList != null)
			{
				this.mOppoGrowthHaoLiUIList.SetElementAmount(this.mActivityDataList.Count);
			}
		}

		// Token: 0x0600C33C RID: 49980 RVA: 0x002E9CE9 File Offset: 0x002E80E9
		private OPPOGrowthHaoLiItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<OPPOGrowthHaoLiItem>();
		}

		// Token: 0x0600C33D RID: 49981 RVA: 0x002E9CF4 File Offset: 0x002E80F4
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			OPPOGrowthHaoLiItem oppogrowthHaoLiItem = item.gameObjectBindScript as OPPOGrowthHaoLiItem;
			if (oppogrowthHaoLiItem != null && item.m_index >= 0 && item.m_index < this.mActivityDataList.Count)
			{
				oppogrowthHaoLiItem.OnItemVisiable(this.mActivityDataList[item.m_index], new OnOPPOGrowthHaoLiItemClick(this.OnSendSubmitActivity));
			}
		}

		// Token: 0x0600C33E RID: 49982 RVA: 0x002E9D60 File Offset: 0x002E8160
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

		// Token: 0x0600C33F RID: 49983 RVA: 0x002E9E31 File Offset: 0x002E8231
		private void OnSendSubmitActivity(int iActivityId)
		{
			if (iActivityId == 0)
			{
				return;
			}
			DataManager<ActiveManager>.GetInstance().SendSubmitActivity(iActivityId, 0U);
		}

		// Token: 0x04006E8A RID: 28298
		[SerializeField]
		private ComUIListScript mOppoGrowthHaoLiUIList;

		// Token: 0x04006E8B RID: 28299
		[SerializeField]
		private int iOPPOGrowthHaoLiActivityId = 26000;

		// Token: 0x04006E8C RID: 28300
		private bool bInitOppoGrowthHaoLiUIList;

		// Token: 0x04006E8D RID: 28301
		private List<ActiveManager.ActivityData> mActivityDataList;
	}
}
