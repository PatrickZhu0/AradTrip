using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001B74 RID: 7028
	public class RandomPropertiesView : MonoBehaviour
	{
		// Token: 0x06011381 RID: 70529 RVA: 0x004F4508 File Offset: 0x004F2908
		public void Initialize(ClientFrame clientFrame, List<int> datas)
		{
			this.clientFrame = clientFrame;
			this.mDatas = datas;
			this.mComUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mComUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mComUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
			this.mComUIListScript.SetElementAmount(this.mDatas.Count);
			this.mCloseBtn.onClick.RemoveAllListeners();
			this.mCloseBtn.onClick.AddListener(delegate()
			{
				(this.clientFrame as RandomPropertiesFrame).Close(false);
			});
		}

		// Token: 0x06011382 RID: 70530 RVA: 0x004F45C0 File Offset: 0x004F29C0
		private RandomPropertiesItem _OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<RandomPropertiesItem>();
		}

		// Token: 0x06011383 RID: 70531 RVA: 0x004F45D8 File Offset: 0x004F29D8
		private void _OnItemVisiableDelegate(ComUIListElementScript item)
		{
			RandomPropertiesItem randomPropertiesItem = item.gameObjectBindScript as RandomPropertiesItem;
			if (randomPropertiesItem != null && item.m_index >= 0 && item.m_index < this.mDatas.Count)
			{
				randomPropertiesItem.OnItemVisible(this.mDatas[item.m_index]);
			}
		}

		// Token: 0x06011384 RID: 70532 RVA: 0x004F4638 File Offset: 0x004F2A38
		public void UnInitialize()
		{
			if (this.mComUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mComUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mComUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnItemVisiableDelegate));
				this.mComUIListScript = null;
			}
			this.mDatas.Clear();
			this.clientFrame = null;
			this.mCloseBtn.onClick.RemoveAllListeners();
		}

		// Token: 0x0400B1CD RID: 45517
		[SerializeField]
		private ComUIListScript mComUIListScript;

		// Token: 0x0400B1CE RID: 45518
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400B1CF RID: 45519
		private List<int> mDatas;

		// Token: 0x0400B1D0 RID: 45520
		private ClientFrame clientFrame;
	}
}
