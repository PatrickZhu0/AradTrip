using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B3E RID: 6974
	internal class GuidanceMainItemList
	{
		// Token: 0x060111C7 RID: 70087 RVA: 0x004E8BDC File Offset: 0x004E6FDC
		private ComGuidanceMainItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComGuidanceMainItem>();
		}

		// Token: 0x060111C8 RID: 70088 RVA: 0x004E8BE4 File Offset: 0x004E6FE4
		public void Initialize(ClientFrame clientFrame, GameObject gameObject)
		{
			this.clientFrame = clientFrame;
			this.gameObject = gameObject;
			this.comUIListScript = this.gameObject.GetComponent<ComUIListScript>();
			this.comUIListScript.Initialize();
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			this.bInitialized = true;
		}

		// Token: 0x060111C9 RID: 70089 RVA: 0x004E8C70 File Offset: 0x004E7070
		private List<GuidanceMainItemTable> _OnFilter()
		{
			List<GuidanceMainItemTable> list = new List<GuidanceMainItemTable>();
			GuidanceMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceMainTable>(this.iFilterId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.LinkItems.Count; i++)
				{
					GuidanceMainItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<GuidanceMainItemTable>(tableItem.LinkItems[i], string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						if (tableItem2.recommandLv > 0)
						{
							FunctionUnLock tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(tableItem2.FunctionId, string.Empty, string.Empty);
							if (tableItem3 == null || tableItem3.FinishLevel <= (int)DataManager<PlayerBaseData>.GetInstance().Level)
							{
								list.Add(tableItem2);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x060111CA RID: 70090 RVA: 0x004E8D43 File Offset: 0x004E7143
		public void RefreshDatas(int iFilterId)
		{
			this.iFilterId = iFilterId;
			if (this.bInitialized)
			{
				this.realValues = this._OnFilter();
				this.comUIListScript.SetElementAmount(this.realValues.Count);
			}
		}

		// Token: 0x060111CB RID: 70091 RVA: 0x004E8D7C File Offset: 0x004E717C
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			if (item != null && item.m_index >= 0 && item.m_index < this.realValues.Count)
			{
				ComGuidanceMainItem comGuidanceMainItem = item.gameObjectBindScript as ComGuidanceMainItem;
				if (comGuidanceMainItem != null)
				{
					comGuidanceMainItem.OnVisible(this.realValues[item.m_index], this.clientFrame as DevelopGuidanceMainFrame);
				}
			}
		}

		// Token: 0x060111CC RID: 70092 RVA: 0x004E8DF4 File Offset: 0x004E71F4
		public void UnInitialize()
		{
			this.bInitialized = false;
			ComUIListScript comUIListScript = this.comUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.comUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			this.comUIListScript = null;
			this.clientFrame = null;
			this.gameObject = null;
		}

		// Token: 0x0400B060 RID: 45152
		private ClientFrame clientFrame;

		// Token: 0x0400B061 RID: 45153
		private GameObject gameObject;

		// Token: 0x0400B062 RID: 45154
		private ComUIListScript comUIListScript;

		// Token: 0x0400B063 RID: 45155
		private List<GuidanceMainItemTable> realValues = new List<GuidanceMainItemTable>();

		// Token: 0x0400B064 RID: 45156
		private int iFilterId = 1;

		// Token: 0x0400B065 RID: 45157
		private bool bInitialized;
	}
}
