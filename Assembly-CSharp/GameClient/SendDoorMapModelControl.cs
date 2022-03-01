using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020017D0 RID: 6096
	public class SendDoorMapModelControl : MonoBehaviour
	{
		// Token: 0x0600F059 RID: 61529 RVA: 0x0040B11C File Offset: 0x0040951C
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600F05A RID: 61530 RVA: 0x0040B124 File Offset: 0x00409524
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600F05B RID: 61531 RVA: 0x0040B134 File Offset: 0x00409534
		private void BindEvents()
		{
			if (this.modelItemList != null)
			{
				this.modelItemList.Initialize();
				ComUIListScript comUIListScript = this.modelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnModelItemVisible));
			}
		}

		// Token: 0x0600F05C RID: 61532 RVA: 0x0040B184 File Offset: 0x00409584
		private void UnBindEvents()
		{
			if (this.modelItemList != null)
			{
				ComUIListScript comUIListScript = this.modelItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnModelItemVisible));
			}
		}

		// Token: 0x0600F05D RID: 61533 RVA: 0x0040B1BE File Offset: 0x004095BE
		private void ClearData()
		{
			this._defaultModelType = CityTeleportTable.eTabType.TabType_None;
			this._toggleDataModelList = null;
			this._onSendDoorToggleClick = null;
		}

		// Token: 0x0600F05E RID: 61534 RVA: 0x0040B1D5 File Offset: 0x004095D5
		public void InitMapModelControl(CityTeleportTable.eTabType defaultModelType, OnSendDoorMapToggleClick onSendDoorMapToggleClick)
		{
			this._defaultModelType = defaultModelType;
			this._onSendDoorToggleClick = onSendDoorMapToggleClick;
			this.InitMapModelContent();
		}

		// Token: 0x0600F05F RID: 61535 RVA: 0x0040B1EC File Offset: 0x004095EC
		private void InitToggleDataModelList()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<CityTeleportTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					CityTeleportTable cityTeleportTable = keyValuePair.Value as CityTeleportTable;
					if (cityTeleportTable != null)
					{
						int lowestLevel = cityTeleportTable.LowestLevel;
						if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= lowestLevel)
						{
							SendDoorModelData sendDoorModelData = new SendDoorModelData();
							sendDoorModelData.ModelType = cityTeleportTable.TabType;
							sendDoorModelData.ToggleName = cityTeleportTable.LabelName;
							sendDoorModelData.ModelId = cityTeleportTable.ID;
							if (this._toggleDataModelList == null)
							{
								this._toggleDataModelList = new List<SendDoorModelData>();
							}
							this._toggleDataModelList.Add(sendDoorModelData);
						}
					}
				}
			}
		}

		// Token: 0x0600F060 RID: 61536 RVA: 0x0040B2AC File Offset: 0x004096AC
		private void InitMapModelContent()
		{
			if (this._defaultModelType == CityTeleportTable.eTabType.TabType_None)
			{
				this._defaultModelType = CityTeleportTable.eTabType.AlardLand;
			}
			this.InitToggleDataModelList();
			if (this.modelItemList != null)
			{
				if (this._toggleDataModelList == null)
				{
					this.modelItemList.SetElementAmount(0);
				}
				else
				{
					this.modelItemList.SetElementAmount(this._toggleDataModelList.Count);
				}
			}
		}

		// Token: 0x0600F061 RID: 61537 RVA: 0x0040B314 File Offset: 0x00409714
		private void OnModelItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			SendDoorMapModelItem component = item.GetComponent<SendDoorMapModelItem>();
			if (component == null)
			{
				return;
			}
			if (this._toggleDataModelList != null && item.m_index >= 0 && item.m_index < this._toggleDataModelList.Count)
			{
				SendDoorModelData sendDoorModelData = this._toggleDataModelList[item.m_index];
				if (sendDoorModelData != null)
				{
					if (this._defaultModelType == sendDoorModelData.ModelType)
					{
						component.Init(sendDoorModelData, new OnSendDoorMapToggleClick(this.OnTabClicked), true);
					}
					else
					{
						component.Init(sendDoorModelData, new OnSendDoorMapToggleClick(this.OnTabClicked), false);
					}
				}
			}
		}

		// Token: 0x0600F062 RID: 61538 RVA: 0x0040B3C5 File Offset: 0x004097C5
		private void OnTabClicked(CityTeleportTable.eTabType modelType)
		{
			if (this._onSendDoorToggleClick != null)
			{
				this._onSendDoorToggleClick(modelType);
			}
		}

		// Token: 0x04009356 RID: 37718
		private CityTeleportTable.eTabType _defaultModelType;

		// Token: 0x04009357 RID: 37719
		private List<SendDoorModelData> _toggleDataModelList = new List<SendDoorModelData>();

		// Token: 0x04009358 RID: 37720
		private OnSendDoorMapToggleClick _onSendDoorToggleClick;

		// Token: 0x04009359 RID: 37721
		[SerializeField]
		private ComUIListScript modelItemList;
	}
}
