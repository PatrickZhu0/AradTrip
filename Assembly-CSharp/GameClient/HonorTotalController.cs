using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001670 RID: 5744
	public class HonorTotalController : MonoBehaviour
	{
		// Token: 0x0600E1E0 RID: 57824 RVA: 0x003A0B0B File Offset: 0x0039EF0B
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E1E1 RID: 57825 RVA: 0x003A0B13 File Offset: 0x0039EF13
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E1E2 RID: 57826 RVA: 0x003A0B24 File Offset: 0x0039EF24
		private void BindEvents()
		{
			if (this.totalActivityItemList != null)
			{
				this.totalActivityItemList.Initialize();
				ComUIListScript comUIListScript = this.totalActivityItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTotalActivityItemVisible));
			}
		}

		// Token: 0x0600E1E3 RID: 57827 RVA: 0x003A0B74 File Offset: 0x0039EF74
		private void UnBindEvents()
		{
			if (this.totalActivityItemList != null)
			{
				ComUIListScript comUIListScript = this.totalActivityItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTotalActivityItemVisible));
			}
		}

		// Token: 0x0600E1E4 RID: 57828 RVA: 0x003A0BAE File Offset: 0x0039EFAE
		private void ClearData()
		{
			this.totalActivityDataModelList = null;
		}

		// Token: 0x0600E1E5 RID: 57829 RVA: 0x003A0BB7 File Offset: 0x0039EFB7
		public void InitHonorTotalController()
		{
			this.InitHonorTotalActivityItemList();
		}

		// Token: 0x0600E1E6 RID: 57830 RVA: 0x003A0BC0 File Offset: 0x0039EFC0
		private void InitHonorTotalActivityItemList()
		{
			if (this.totalActivityItemList == null)
			{
				return;
			}
			int elementAmount = 0;
			this.totalActivityDataModelList = HonorSystemUtility.GetPvpNumberStaticsListByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_TOTAL);
			if (this.totalActivityDataModelList != null && this.totalActivityDataModelList.Count > 0)
			{
				elementAmount = this.totalActivityDataModelList.Count;
			}
			this.totalActivityItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x0600E1E7 RID: 57831 RVA: 0x003A0C24 File Offset: 0x0039F024
		private void OnTotalActivityItemVisible(ComUIListElementScript item)
		{
			if (this.totalActivityItemList == null)
			{
				return;
			}
			if (item == null)
			{
				return;
			}
			if (this.totalActivityDataModelList == null || this.totalActivityDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this.totalActivityDataModelList.Count)
			{
				return;
			}
			PvpNumberStatistics pvpNumberStatistics = this.totalActivityDataModelList[item.m_index];
			HonorTotalItem component = item.GetComponent<HonorTotalItem>();
			if (component != null && pvpNumberStatistics != null)
			{
				component.InitItem(pvpNumberStatistics);
			}
		}

		// Token: 0x0400872F RID: 34607
		[Space(5f)]
		[Header("TotalItemList")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScript totalActivityItemList;

		// Token: 0x04008730 RID: 34608
		private List<PvpNumberStatistics> totalActivityDataModelList;
	}
}
