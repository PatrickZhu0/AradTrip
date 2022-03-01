using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001676 RID: 5750
	public class HonorSystemPreviewView : MonoBehaviour
	{
		// Token: 0x0600E20D RID: 57869 RVA: 0x003A1587 File Offset: 0x0039F987
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E20E RID: 57870 RVA: 0x003A158F File Offset: 0x0039F98F
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E20F RID: 57871 RVA: 0x003A15A0 File Offset: 0x0039F9A0
		private void ClearData()
		{
			if (this._previewLevelItemDataModelList != null)
			{
				for (int i = 0; i < this._previewLevelItemDataModelList.Count; i++)
				{
					PreviewLevelItemDataModel previewLevelItemDataModel = this._previewLevelItemDataModelList[i];
					if (previewLevelItemDataModel != null && previewLevelItemDataModel.UnLockShopItemList != null && previewLevelItemDataModel.UnLockShopItemList.Count > 0)
					{
						previewLevelItemDataModel.UnLockShopItemList.Clear();
					}
				}
				this._previewLevelItemDataModelList.Clear();
				this._previewLevelItemDataModelList = null;
			}
		}

		// Token: 0x0600E210 RID: 57872 RVA: 0x003A1628 File Offset: 0x0039FA28
		private void BindEvents()
		{
			if (this.previewLevelItemList != null)
			{
				this.previewLevelItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.previewLevelItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPreviewLevelItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.previewLevelItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPreviewLevelItemRecycle));
			}
		}

		// Token: 0x0600E211 RID: 57873 RVA: 0x003A16A0 File Offset: 0x0039FAA0
		private void UnBindEvents()
		{
			if (this.previewLevelItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.previewLevelItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnPreviewLevelItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.previewLevelItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnPreviewLevelItemRecycle));
			}
		}

		// Token: 0x0600E212 RID: 57874 RVA: 0x003A170C File Offset: 0x0039FB0C
		private void OnPreviewLevelItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._previewLevelItemDataModelList == null || this._previewLevelItemDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._previewLevelItemDataModelList.Count)
			{
				return;
			}
			PreviewLevelItemDataModel previewLevelItemDataModel = this._previewLevelItemDataModelList[item.m_index];
			HonorSystemPreviewItem component = item.GetComponent<HonorSystemPreviewItem>();
			if (component != null && previewLevelItemDataModel != null)
			{
				component.InitPreviewItem(previewLevelItemDataModel);
			}
		}

		// Token: 0x0600E213 RID: 57875 RVA: 0x003A1798 File Offset: 0x0039FB98
		private void OnPreviewLevelItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			HonorSystemPreviewItem component = item.GetComponent<HonorSystemPreviewItem>();
			if (component != null)
			{
				component.OnRecycleItem();
			}
		}

		// Token: 0x0600E214 RID: 57876 RVA: 0x003A17CB File Offset: 0x0039FBCB
		public void InitView()
		{
			this.InitPreviewLevelData();
			this.InitPreviewLevelItemList();
		}

		// Token: 0x0600E215 RID: 57877 RVA: 0x003A17D9 File Offset: 0x0039FBD9
		private void InitPreviewLevelData()
		{
			this._previewLevelItemDataModelList = HonorSystemUtility.GetPreviewLevelItemDataModelList();
		}

		// Token: 0x0600E216 RID: 57878 RVA: 0x003A17E8 File Offset: 0x0039FBE8
		private void InitPreviewLevelItemList()
		{
			if (this.previewLevelItemList == null)
			{
				return;
			}
			int elementAmount = 0;
			if (this._previewLevelItemDataModelList != null)
			{
				elementAmount = this._previewLevelItemDataModelList.Count;
			}
			this.previewLevelItemList.SetElementAmount(elementAmount);
			int playerHonorLevel = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel;
			this.previewLevelItemList.MoveItemToFirstPosition(playerHonorLevel);
		}

		// Token: 0x0400874E RID: 34638
		private List<PreviewLevelItemDataModel> _previewLevelItemDataModelList;

		// Token: 0x0400874F RID: 34639
		[Space(10f)]
		[Header("PreviewLevelItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx previewLevelItemList;
	}
}
