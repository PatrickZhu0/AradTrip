using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B15 RID: 6933
	public class ExpendBeadItemView : MonoBehaviour
	{
		// Token: 0x06011065 RID: 69733 RVA: 0x004DFA8C File Offset: 0x004DDE8C
		public void Initialize(ClientFrame clientFrame, List<ExpendBeadItemData> datas, ExpendBeadItemView.OnItemSelected onItemSelected)
		{
			this.clientFrame = clientFrame;
			this.mItemSimpleDatas = datas;
			this.onItemSelected = onItemSelected;
			this.mComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			ComUIListScript comUIListScript3 = this.mComUIListScript;
			comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Combine(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
			ComUIListScript comUIListScript4 = this.mComUIListScript;
			comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Combine(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
			this.mComUIListScript.SetElementAmount(this.mItemSimpleDatas.Count);
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(delegate()
			{
				(this.clientFrame as ExpendBeadItemFrame).Close(false);
			});
		}

		// Token: 0x06011066 RID: 69734 RVA: 0x004DFB98 File Offset: 0x004DDF98
		private ExpendBeadItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ExpendBeadItem>();
		}

		// Token: 0x06011067 RID: 69735 RVA: 0x004DFBB0 File Offset: 0x004DDFB0
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ExpendBeadItem expendBeadItem = item.gameObjectBindScript as ExpendBeadItem;
			if (expendBeadItem != null && item.m_index >= 0 && item.m_index < this.mItemSimpleDatas.Count)
			{
				expendBeadItem.OnItemVisible(this.mItemSimpleDatas[item.m_index]);
			}
		}

		// Token: 0x06011068 RID: 69736 RVA: 0x004DFC10 File Offset: 0x004DE010
		private void _OnItemSelectedDelegate(ComUIListElementScript item)
		{
			ExpendBeadItem expendBeadItem = item.gameObjectBindScript as ExpendBeadItem;
			ExpendBeadItemData itemData = (!(expendBeadItem == null)) ? expendBeadItem.SimpleData : null;
			if (this.onItemSelected != null)
			{
				this.onItemSelected(itemData);
			}
		}

		// Token: 0x06011069 RID: 69737 RVA: 0x004DFC5C File Offset: 0x004DE05C
		private void _OnItemChangeDisplayDelegate(ComUIListElementScript item, bool bSelected)
		{
			ExpendBeadItem expendBeadItem = item.gameObjectBindScript as ExpendBeadItem;
			if (expendBeadItem != null)
			{
				expendBeadItem.OnItemChangeDisplay(bSelected);
			}
		}

		// Token: 0x0601106A RID: 69738 RVA: 0x004DFC88 File Offset: 0x004DE088
		public void UnInitialize()
		{
			if (this.mComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				ComUIListScript comUIListScript3 = this.mComUIListScript;
				comUIListScript3.onItemSelected = (ComUIListScript.OnItemSelectedDelegate)Delegate.Remove(comUIListScript3.onItemSelected, new ComUIListScript.OnItemSelectedDelegate(this._OnItemSelectedDelegate));
				ComUIListScript comUIListScript4 = this.mComUIListScript;
				comUIListScript4.onItemChageDisplay = (ComUIListScript.OnItemChangeDisplayDelegate)Delegate.Remove(comUIListScript4.onItemChageDisplay, new ComUIListScript.OnItemChangeDisplayDelegate(this._OnItemChangeDisplayDelegate));
				this.mComUIListScript = null;
			}
			this.onItemSelected = (ExpendBeadItemView.OnItemSelected)Delegate.Remove(this.onItemSelected, this.onItemSelected);
			this.mItemSimpleDatas.Clear();
			this.clientFrame = null;
			this.mCloseBtn.onClick.RemoveAllListeners();
		}

		// Token: 0x0400AF44 RID: 44868
		[SerializeField]
		private ComUIListScript mComUIListScript;

		// Token: 0x0400AF45 RID: 44869
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400AF46 RID: 44870
		private List<ExpendBeadItemData> mItemSimpleDatas;

		// Token: 0x0400AF47 RID: 44871
		public ExpendBeadItemView.OnItemSelected onItemSelected;

		// Token: 0x0400AF48 RID: 44872
		private ClientFrame clientFrame;

		// Token: 0x02001B16 RID: 6934
		// (Invoke) Token: 0x0601106D RID: 69741
		public delegate void OnItemSelected(ExpendBeadItemData itemData);
	}
}
