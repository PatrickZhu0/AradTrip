using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200177B RID: 6011
	public class MallNewExchangeMallView : MallNewBaseView
	{
		// Token: 0x0600ED8C RID: 60812 RVA: 0x003FB459 File Offset: 0x003F9859
		private void Awake()
		{
			this.ClearData();
			this.BindUiEventSystem();
		}

		// Token: 0x0600ED8D RID: 60813 RVA: 0x003FB467 File Offset: 0x003F9867
		private void ClearData()
		{
			if (this._exchangeMallShopTableList != null)
			{
				this._exchangeMallShopTableList.Clear();
			}
		}

		// Token: 0x0600ED8E RID: 60814 RVA: 0x003FB480 File Offset: 0x003F9880
		private void BindUiEventSystem()
		{
			if (this.exchangeMallElementList != null)
			{
				this.exchangeMallElementList.Initialize();
				ComUIListScript comUIListScript = this.exchangeMallElementList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnExchangeMallItemVisible));
			}
		}

		// Token: 0x0600ED8F RID: 60815 RVA: 0x003FB4D0 File Offset: 0x003F98D0
		private void OnDestroy()
		{
			this.ClearData();
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600ED90 RID: 60816 RVA: 0x003FB4DE File Offset: 0x003F98DE
		private void UnBindUiEventSystem()
		{
			if (this.exchangeMallElementList != null)
			{
				ComUIListScript comUIListScript = this.exchangeMallElementList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnExchangeMallItemVisible));
			}
		}

		// Token: 0x0600ED91 RID: 60817 RVA: 0x003FB518 File Offset: 0x003F9918
		public override void InitData(int index, int secondIndex = 0, int thirdIndex = 0)
		{
			this.InitExchangeMallData();
			this.InitExchangeMallView();
		}

		// Token: 0x0600ED92 RID: 60818 RVA: 0x003FB528 File Offset: 0x003F9928
		private void InitExchangeMallData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ShopTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ShopTable shopTable = keyValuePair.Value as ShopTable;
					if (shopTable != null && shopTable.IsExchangeShopShow == 1)
					{
						if (!ShopNewUtility.IsActivityShop(shopTable) || ShopNewUtility.IsActivityShopInStartState(shopTable))
						{
							this._exchangeMallShopTableList.Add(shopTable);
						}
					}
				}
			}
			this._exchangeMallShopTableList.Sort((ShopTable x, ShopTable y) => x.ExchangeShopOrder.CompareTo(y.ExchangeShopOrder));
		}

		// Token: 0x0600ED93 RID: 60819 RVA: 0x003FB5D4 File Offset: 0x003F99D4
		private void InitExchangeMallView()
		{
			if (this.exchangeMallElementList != null)
			{
				this.exchangeMallElementList.SetElementAmount(this._exchangeMallShopTableList.Count);
				this.exchangeMallElementList.ResetContentPosition();
			}
		}

		// Token: 0x0600ED94 RID: 60820 RVA: 0x003FB608 File Offset: 0x003F9A08
		private void OnExchangeMallItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._exchangeMallShopTableList.Count)
			{
				return;
			}
			ShopTable shopTable = this._exchangeMallShopTableList[item.m_index];
			MallNewExchangeMallElementItem component = item.GetComponent<MallNewExchangeMallElementItem>();
			if (shopTable != null && component != null)
			{
				component.InitData(shopTable);
			}
		}

		// Token: 0x04009100 RID: 37120
		private List<ShopTable> _exchangeMallShopTableList = new List<ShopTable>();

		// Token: 0x04009101 RID: 37121
		[SerializeField]
		private ComUIListScript exchangeMallElementList;
	}
}
