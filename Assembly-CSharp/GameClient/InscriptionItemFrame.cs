using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B4C RID: 6988
	public class InscriptionItemFrame : ClientFrame
	{
		// Token: 0x06011256 RID: 70230 RVA: 0x004EC7DD File Offset: 0x004EABDD
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/InscriptionFrame/InscriptionItemFrame";
		}

		// Token: 0x06011257 RID: 70231 RVA: 0x004EC7E4 File Offset: 0x004EABE4
		protected sealed override void _OnOpenFrame()
		{
			this.InitUIList();
			this.mDataModel = (this.userData as InscriptionItemDataModel);
			if (this.mDataModel != null)
			{
				this.mInscriptionItemDataList = DataManager<InscriptionMosaicDataManager>.GetInstance().GetCanMosaicInscription(this.mDataModel.InscriptionHoleColor);
			}
			this.mUIList.SetElementAmount(this.mInscriptionItemDataList.Count);
		}

		// Token: 0x06011258 RID: 70232 RVA: 0x004EC844 File Offset: 0x004EAC44
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitUIList();
			this.mDataModel = null;
			this.mInscriptionItemDataList.Clear();
		}

		// Token: 0x06011259 RID: 70233 RVA: 0x004EC860 File Offset: 0x004EAC60
		private void InitUIList()
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0601125A RID: 70234 RVA: 0x004EC928 File Offset: 0x004EAD28
		private void UnInitUIList()
		{
			if (this.mUIList != null)
			{
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mUIList;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this.OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mUIList;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this.OnItemChangeDisplayDelegate));
			}
		}

		// Token: 0x0601125B RID: 70235 RVA: 0x004EC9E2 File Offset: 0x004EADE2
		private InscriptionItemElement OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<InscriptionItemElement>();
		}

		// Token: 0x0601125C RID: 70236 RVA: 0x004EC9EC File Offset: 0x004EADEC
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			InscriptionItemElement inscriptionItemElement = item.gameObjectBindScript as InscriptionItemElement;
			if (inscriptionItemElement != null && item.m_index >= 0 && item.m_index < this.mInscriptionItemDataList.Count)
			{
				inscriptionItemElement.OnItemVisiable(this.mInscriptionItemDataList[item.m_index]);
			}
		}

		// Token: 0x0601125D RID: 70237 RVA: 0x004ECA4C File Offset: 0x004EAE4C
		private void OnItemSelectedDelegate(ComUIListElementScript item)
		{
			InscriptionItemElement inscriptionItemElement = item.gameObjectBindScript as InscriptionItemElement;
			if (inscriptionItemElement != null)
			{
				if (this.mDataModel.OnSelectedClick != null)
				{
					this.mDataModel.OnSelectedClick.Invoke(inscriptionItemElement.CurrentItemData);
				}
				base.Close(false);
			}
		}

		// Token: 0x0601125E RID: 70238 RVA: 0x004ECAA0 File Offset: 0x004EAEA0
		private void OnItemChangeDisplayDelegate(ComUIListElementScript item, bool isSelected)
		{
			InscriptionItemElement inscriptionItemElement = item.gameObjectBindScript as InscriptionItemElement;
			if (inscriptionItemElement != null)
			{
				inscriptionItemElement.OnItemChangeDisplay(isSelected);
			}
		}

		// Token: 0x0601125F RID: 70239 RVA: 0x004ECACC File Offset: 0x004EAECC
		protected sealed override void _bindExUI()
		{
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
		}

		// Token: 0x06011260 RID: 70240 RVA: 0x004ECAE4 File Offset: 0x004EAEE4
		protected sealed override void _unbindExUI()
		{
			this.mUIList = null;
		}

		// Token: 0x0400B0F4 RID: 45300
		private InscriptionItemDataModel mDataModel;

		// Token: 0x0400B0F5 RID: 45301
		private List<ItemData> mInscriptionItemDataList = new List<ItemData>();

		// Token: 0x0400B0F6 RID: 45302
		private ComUIListScript mUIList;
	}
}
