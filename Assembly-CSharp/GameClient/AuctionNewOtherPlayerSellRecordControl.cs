using System;
using System.Collections.Generic;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001493 RID: 5267
	public class AuctionNewOtherPlayerSellRecordControl : MonoBehaviour
	{
		// Token: 0x0600CC3D RID: 52285 RVA: 0x00321CA9 File Offset: 0x003200A9
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC3E RID: 52286 RVA: 0x00321CB1 File Offset: 0x003200B1
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ResetData();
		}

		// Token: 0x0600CC3F RID: 52287 RVA: 0x00321CBF File Offset: 0x003200BF
		private void ResetData()
		{
			this._sellRecordDataModelList.Clear();
		}

		// Token: 0x0600CC40 RID: 52288 RVA: 0x00321CCC File Offset: 0x003200CC
		private void BindEvents()
		{
			if (this.sellRecordItemList != null)
			{
				this.sellRecordItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.sellRecordItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellRecordItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.sellRecordItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellRecordItemRecycle));
			}
		}

		// Token: 0x0600CC41 RID: 52289 RVA: 0x00321D44 File Offset: 0x00320144
		private void UnBindEvents()
		{
			if (this.sellRecordItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.sellRecordItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnSellRecordItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.sellRecordItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnSellRecordItemRecycle));
			}
		}

		// Token: 0x0600CC42 RID: 52290 RVA: 0x00321DB0 File Offset: 0x003201B0
		public void Init()
		{
			this.InitBaseView();
		}

		// Token: 0x0600CC43 RID: 52291 RVA: 0x00321DB8 File Offset: 0x003201B8
		public void OnEnableControl()
		{
			if (this.sellRecordItemList != null)
			{
				this.sellRecordItemList.ResetComUiListScriptEx();
			}
			this.UpdateSellRecordItemList();
		}

		// Token: 0x0600CC44 RID: 52292 RVA: 0x00321DDC File Offset: 0x003201DC
		private void InitBaseView()
		{
			if (this.noItemTipLabel != null)
			{
				this.noItemTipLabel.text = TR.Value("auction_new_other_not_sell_record_label");
			}
			this.UpdateSellRecordItemList();
		}

		// Token: 0x0600CC45 RID: 52293 RVA: 0x00321E0C File Offset: 0x0032020C
		public void UpdateSellRecordControl(AuctionTransaction[] auctionTransactions)
		{
			this._sellRecordDataModelList.Clear();
			if (auctionTransactions != null && auctionTransactions.Length > 0)
			{
				for (int i = 0; i < auctionTransactions.Length; i++)
				{
					if (auctionTransactions[i] != null)
					{
						this._sellRecordDataModelList.Add(auctionTransactions[i]);
					}
				}
			}
			this.UpdateSellRecordItemList();
		}

		// Token: 0x0600CC46 RID: 52294 RVA: 0x00321E64 File Offset: 0x00320264
		private void UpdateSellRecordItemList()
		{
			int elementAmount = 0;
			if (this._sellRecordDataModelList != null)
			{
				elementAmount = this._sellRecordDataModelList.Count;
			}
			if (this.sellRecordItemList != null)
			{
				this.sellRecordItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x0600CC47 RID: 52295 RVA: 0x00321EA8 File Offset: 0x003202A8
		private void OnSellRecordItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.sellRecordItemList == null)
			{
				return;
			}
			if (this._sellRecordDataModelList == null || this._sellRecordDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._sellRecordDataModelList.Count)
			{
				return;
			}
			AuctionTransaction auctionTransaction = this._sellRecordDataModelList[item.m_index];
			AuctionNewOtherPlayerSellRecordItem component = item.GetComponent<AuctionNewOtherPlayerSellRecordItem>();
			if (component != null && auctionTransaction != null)
			{
				component.InitItem(auctionTransaction);
			}
		}

		// Token: 0x0600CC48 RID: 52296 RVA: 0x00321F48 File Offset: 0x00320348
		private void OnSellRecordItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AuctionNewOtherPlayerSellRecordItem component = item.GetComponent<AuctionNewOtherPlayerSellRecordItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x040076D6 RID: 30422
		private List<AuctionTransaction> _sellRecordDataModelList = new List<AuctionTransaction>();

		// Token: 0x040076D7 RID: 30423
		[Space(15f)]
		[Header("AuctionNewSellRecord")]
		[Space(5f)]
		[SerializeField]
		private Text noItemTipLabel;

		// Token: 0x040076D8 RID: 30424
		[SerializeField]
		private ComUIListScriptEx sellRecordItemList;
	}
}
