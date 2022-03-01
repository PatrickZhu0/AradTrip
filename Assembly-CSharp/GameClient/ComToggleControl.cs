using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F2D RID: 3885
	public class ComToggleControl : MonoBehaviour
	{
		// Token: 0x0600977A RID: 38778 RVA: 0x001D03B0 File Offset: 0x001CE7B0
		private void Awake()
		{
			if (this.comToggleItemList != null)
			{
				this.comToggleItemList.Initialize();
				ComUIListScript comUIListScript = this.comToggleItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnComToggleItemVisible));
				ComUIListScript comUIListScript2 = this.comToggleItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnComToggleItemRecycle));
			}
		}

		// Token: 0x0600977B RID: 38779 RVA: 0x001D0428 File Offset: 0x001CE828
		private void OnDestroy()
		{
			if (this.comToggleItemList != null)
			{
				ComUIListScript comUIListScript = this.comToggleItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnComToggleItemVisible));
				ComUIListScript comUIListScript2 = this.comToggleItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnComToggleItemRecycle));
			}
			this.ClearData();
		}

		// Token: 0x0600977C RID: 38780 RVA: 0x001D049A File Offset: 0x001CE89A
		private void ClearData()
		{
			this._comToggleDataList = null;
			this._onComToggleClick = null;
		}

		// Token: 0x0600977D RID: 38781 RVA: 0x001D04AC File Offset: 0x001CE8AC
		public void InitComToggleControl(List<ComControlData> comToggleDataList, OnComToggleClick onComToggleClick = null)
		{
			if (this.comToggleItemList == null)
			{
				Logger.LogErrorFormat("comToggleItemList is null", new object[0]);
				return;
			}
			if (comToggleDataList == null || comToggleDataList.Count <= 0)
			{
				Logger.LogErrorFormat("comToggleControl comToggleDataList is null", new object[0]);
				return;
			}
			this._comToggleDataList = comToggleDataList;
			this._onComToggleClick = onComToggleClick;
			if (this.comToggleItemList != null)
			{
				this.comToggleItemList.SetElementAmount(this._comToggleDataList.Count);
			}
		}

		// Token: 0x0600977E RID: 38782 RVA: 0x001D0534 File Offset: 0x001CE934
		public void SetComToggleIsOnByIndex(int index)
		{
			if (this.comToggleItemList == null)
			{
				return;
			}
			ComUIListElementScript elemenet = this.comToggleItemList.GetElemenet(index);
			if (elemenet == null)
			{
				return;
			}
			ComToggleItem component = elemenet.GetComponent<ComToggleItem>();
			if (component == null)
			{
				return;
			}
			component.SetToggleOn();
		}

		// Token: 0x0600977F RID: 38783 RVA: 0x001D0588 File Offset: 0x001CE988
		private void OnComToggleItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._comToggleDataList == null || item.m_index >= this._comToggleDataList.Count)
			{
				return;
			}
			ComControlData comControlData = this._comToggleDataList[item.m_index];
			ComToggleItem component = item.GetComponent<ComToggleItem>();
			if (component != null && comControlData != null)
			{
				component.InitItem(comControlData, this._onComToggleClick);
			}
		}

		// Token: 0x06009780 RID: 38784 RVA: 0x001D05FC File Offset: 0x001CE9FC
		private void OnComToggleItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComToggleItem component = item.GetComponent<ComToggleItem>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x06009781 RID: 38785 RVA: 0x001D0630 File Offset: 0x001CEA30
		public void UpdateComTogglePosition()
		{
			int count = this._comToggleDataList.Count;
			int num = 0;
			for (int i = 0; i < this._comToggleDataList.Count; i++)
			{
				ComControlData comControlData = this._comToggleDataList[i];
				if (comControlData != null)
				{
					if (comControlData.IsSelected)
					{
						num = i;
						break;
					}
				}
			}
			if (this.comToggleItemList != null)
			{
				if (num <= 1)
				{
					this.comToggleItemList.MoveElementInScrollArea(0, true);
				}
				else if (num >= count - 2)
				{
					this.comToggleItemList.MoveElementInScrollArea(count - 1, true);
				}
				else
				{
					this.comToggleItemList.MoveElementInScrollArea(num + 1, true);
				}
			}
		}

		// Token: 0x04004E23 RID: 20003
		[Space(5f)]
		[Header("ComToggleControl")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScript comToggleItemList;

		// Token: 0x04004E24 RID: 20004
		private List<ComControlData> _comToggleDataList;

		// Token: 0x04004E25 RID: 20005
		private OnComToggleClick _onComToggleClick;
	}
}
