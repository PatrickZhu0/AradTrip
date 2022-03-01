using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000F33 RID: 3891
	public class ComToggleControlEx : MonoBehaviour
	{
		// Token: 0x060097A3 RID: 38819 RVA: 0x001D0C14 File Offset: 0x001CF014
		private void Awake()
		{
			if (this.comToggleItemExList != null)
			{
				this.comToggleItemExList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.comToggleItemExList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnComToggleItemExVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.comToggleItemExList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnComToggleItemExRecycle));
			}
		}

		// Token: 0x060097A4 RID: 38820 RVA: 0x001D0C8C File Offset: 0x001CF08C
		private void OnDestroy()
		{
			if (this.comToggleItemExList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.comToggleItemExList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnComToggleItemExVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.comToggleItemExList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnComToggleItemExRecycle));
			}
			this.ClearData();
		}

		// Token: 0x060097A5 RID: 38821 RVA: 0x001D0CFE File Offset: 0x001CF0FE
		private void ClearData()
		{
			this._comToggleDataExList = null;
			this._onComToggleItemExClick = null;
			this._onComToggleItemExButtonClick = null;
		}

		// Token: 0x060097A6 RID: 38822 RVA: 0x001D0D18 File Offset: 0x001CF118
		public void InitComToggleControlEx(List<ComControlDataEx> comToggleDataExList, OnComToggleItemExClick onComToggleItemExClick = null, OnComToggleItemExButtonClick onComToggleItemExButtonClick = null)
		{
			if (this.comToggleItemExList == null)
			{
				Logger.LogErrorFormat("comToggleItemList is null", new object[0]);
				return;
			}
			if (comToggleDataExList == null || comToggleDataExList.Count <= 0)
			{
				Logger.LogErrorFormat("comToggleControlEx comToggleDataExList is null", new object[0]);
				return;
			}
			this._comToggleDataExList = comToggleDataExList;
			this._onComToggleItemExClick = onComToggleItemExClick;
			this._onComToggleItemExButtonClick = onComToggleItemExButtonClick;
			if (this.comToggleItemExList != null)
			{
				this.comToggleItemExList.SetElementAmount(comToggleDataExList.Count);
			}
		}

		// Token: 0x060097A7 RID: 38823 RVA: 0x001D0DA4 File Offset: 0x001CF1A4
		private void OnComToggleItemExVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._comToggleDataExList == null || item.m_index >= this._comToggleDataExList.Count)
			{
				return;
			}
			ComControlDataEx comControlDataEx = this._comToggleDataExList[item.m_index];
			ComToggleItemEx component = item.GetComponent<ComToggleItemEx>();
			if (component != null && comControlDataEx != null)
			{
				component.InitItem(comControlDataEx, this._onComToggleItemExClick, this._onComToggleItemExButtonClick);
			}
		}

		// Token: 0x060097A8 RID: 38824 RVA: 0x001D0E20 File Offset: 0x001CF220
		private void OnComToggleItemExRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ComToggleItemEx component = item.GetComponent<ComToggleItemEx>();
			if (component != null)
			{
				component.OnItemRecycle();
			}
		}

		// Token: 0x060097A9 RID: 38825 RVA: 0x001D0E53 File Offset: 0x001CF253
		public void ResetListPosition()
		{
			if (this.comToggleItemExList != null)
			{
				this.comToggleItemExList.ResetComUiListScriptEx();
			}
		}

		// Token: 0x060097AA RID: 38826 RVA: 0x001D0E71 File Offset: 0x001CF271
		public void MoveComToggleItemExToFirstPosition(int index)
		{
			if (this.comToggleItemExList != null)
			{
				this.comToggleItemExList.MoveItemToMiddlePosition(index);
			}
		}

		// Token: 0x04004E3C RID: 20028
		[Space(5f)]
		[Header("ComToggleControlEx")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx comToggleItemExList;

		// Token: 0x04004E3D RID: 20029
		private List<ComControlDataEx> _comToggleDataExList;

		// Token: 0x04004E3E RID: 20030
		private OnComToggleItemExClick _onComToggleItemExClick;

		// Token: 0x04004E3F RID: 20031
		private OnComToggleItemExButtonClick _onComToggleItemExButtonClick;
	}
}
