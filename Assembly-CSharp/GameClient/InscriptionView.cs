using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B64 RID: 7012
	public class InscriptionView : MonoBehaviour
	{
		// Token: 0x060112DE RID: 70366 RVA: 0x004EFFF1 File Offset: 0x004EE3F1
		private void Awake()
		{
			this.InitTabUIList();
		}

		// Token: 0x060112DF RID: 70367 RVA: 0x004EFFF9 File Offset: 0x004EE3F9
		private void OnDestroy()
		{
			this.UnInitTabUIList();
			InscriptionView.iCurrentSelectTabIndex = 0;
		}

		// Token: 0x060112E0 RID: 70368 RVA: 0x004F0007 File Offset: 0x004EE407
		public void InitView()
		{
			this.mTabUIList.SetElementAmount(this.mInscriptionTabModelList.Count);
		}

		// Token: 0x060112E1 RID: 70369 RVA: 0x004F0020 File Offset: 0x004EE420
		private void InitTabUIList()
		{
			if (this.mTabUIList != null)
			{
				this.mTabUIList.Initialize();
				ComUIListScript comUIListScript = this.mTabUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTabUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060112E2 RID: 70370 RVA: 0x004F0098 File Offset: 0x004EE498
		private void UnInitTabUIList()
		{
			if (this.mTabUIList != null)
			{
				ComUIListScript comUIListScript = this.mTabUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mTabUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x060112E3 RID: 70371 RVA: 0x004F0104 File Offset: 0x004EE504
		private InscriptionTabItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<InscriptionTabItem>();
		}

		// Token: 0x060112E4 RID: 70372 RVA: 0x004F010C File Offset: 0x004EE50C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			InscriptionTabItem inscriptionTabItem = item.gameObjectBindScript as InscriptionTabItem;
			if (inscriptionTabItem != null && item.m_index >= 0 && item.m_index < this.mInscriptionTabModelList.Count)
			{
				if (InscriptionView.iCurrentSelectTabIndex == this.mInscriptionTabModelList[item.m_index].Index)
				{
					inscriptionTabItem.Init(this.mInscriptionTabModelList[item.m_index], true);
				}
				else
				{
					inscriptionTabItem.Init(this.mInscriptionTabModelList[item.m_index], false);
				}
			}
		}

		// Token: 0x0400B15C RID: 45404
		[SerializeField]
		private List<InscriptionTabModel> mInscriptionTabModelList;

		// Token: 0x0400B15D RID: 45405
		[SerializeField]
		private ComUIListScript mTabUIList;

		// Token: 0x0400B15E RID: 45406
		public static int iCurrentSelectTabIndex;
	}
}
