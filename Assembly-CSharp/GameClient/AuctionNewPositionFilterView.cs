using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001478 RID: 5240
	public class AuctionNewPositionFilterView : MonoBehaviour
	{
		// Token: 0x0600CB3D RID: 52029 RVA: 0x0031C9D4 File Offset: 0x0031ADD4
		private void Awake()
		{
			this.BindUiEvent();
		}

		// Token: 0x0600CB3E RID: 52030 RVA: 0x0031C9DC File Offset: 0x0031ADDC
		private void OnDestroy()
		{
			this.UnBindEvent();
			this.ClearData();
		}

		// Token: 0x0600CB3F RID: 52031 RVA: 0x0031C9EC File Offset: 0x0031ADEC
		private void BindUiEvent()
		{
			if (this.positionFilterItemListEx != null)
			{
				this.positionFilterItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.positionFilterItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.positionFilterItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600CB40 RID: 52032 RVA: 0x0031CA64 File Offset: 0x0031AE64
		private void UnBindEvent()
		{
			if (this.positionFilterItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.positionFilterItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.positionFilterItemListEx;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x0600CB41 RID: 52033 RVA: 0x0031CAD0 File Offset: 0x0031AED0
		private void ClearData()
		{
			this._auctionNewFilterDataList = null;
		}

		// Token: 0x0600CB42 RID: 52034 RVA: 0x0031CADC File Offset: 0x0031AEDC
		public void Init(int filterType)
		{
			if (filterType <= 0 || filterType >= 10)
			{
				return;
			}
			this._auctionNewFilterDataList = DataManager<AuctionNewDataManager>.GetInstance().GetAuctionNewFilterDataList((AuctionNewFrameTable.eFilterItemType)filterType);
			this.InitItemListEx();
		}

		// Token: 0x0600CB43 RID: 52035 RVA: 0x0031CB14 File Offset: 0x0031AF14
		private void InitItemListEx()
		{
			if (this.positionFilterItemListEx == null)
			{
				return;
			}
			int elementAmount = 0;
			if (this._auctionNewFilterDataList != null)
			{
				elementAmount = this._auctionNewFilterDataList.Count;
			}
			this.positionFilterItemListEx.SetElementAmount(elementAmount);
		}

		// Token: 0x0600CB44 RID: 52036 RVA: 0x0031CB58 File Offset: 0x0031AF58
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.positionFilterItemListEx == null)
			{
				return;
			}
			if (this._auctionNewFilterDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._auctionNewFilterDataList.Count)
			{
				return;
			}
			AuctionNewFilterData auctionNewFilterData = this._auctionNewFilterDataList[item.m_index];
			AuctionNewPositionFilterItem component = item.GetComponent<AuctionNewPositionFilterItem>();
			if (component != null && auctionNewFilterData != null)
			{
				component.InitItem(auctionNewFilterData);
			}
		}

		// Token: 0x0600CB45 RID: 52037 RVA: 0x0031CBE8 File Offset: 0x0031AFE8
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewPositionFilterItem component = item.GetComponent<AuctionNewPositionFilterItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0400760E RID: 30222
		private List<AuctionNewFilterData> _auctionNewFilterDataList;

		// Token: 0x0400760F RID: 30223
		[Space(15f)]
		[Header("positionFilterItemListEx")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx positionFilterItemListEx;
	}
}
