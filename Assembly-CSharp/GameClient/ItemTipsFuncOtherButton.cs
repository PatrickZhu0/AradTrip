using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020016EC RID: 5868
	public class ItemTipsFuncOtherButton : MonoBehaviour
	{
		// Token: 0x0600E5E2 RID: 58850 RVA: 0x003BEB23 File Offset: 0x003BCF23
		private void Awake()
		{
			this.InitFuncItemUIList();
		}

		// Token: 0x0600E5E3 RID: 58851 RVA: 0x003BEB2C File Offset: 0x003BCF2C
		public void Initialize(ItemData item, List<TipFuncButon> funcInfos, int nTipIndex)
		{
			this.mItem = item;
			this.mFuncInfos = new List<TipFuncButon>();
			this.mFuncInfos = funcInfos;
			this.mTipIndex = nTipIndex;
			if (this.mFuncItemUIList != null)
			{
				this.mFuncItemUIList.SetElementAmount(this.mFuncInfos.Count);
			}
		}

		// Token: 0x0600E5E4 RID: 58852 RVA: 0x003BEB80 File Offset: 0x003BCF80
		public void SetTabItemRoot()
		{
			this.mTabItemRoot.CustomActive(!this.mTabItemRoot.activeSelf);
			if (!this.mTabItemRoot.activeSelf)
			{
				this.mDesc.text = this.mStrPackUp;
				this.mUpArrow.CustomActive(true);
				this.mDownArrow.CustomActive(false);
			}
			else
			{
				this.mDesc.text = this.mStrMore;
				this.mUpArrow.CustomActive(false);
				this.mDownArrow.CustomActive(true);
			}
		}

		// Token: 0x0600E5E5 RID: 58853 RVA: 0x003BEC10 File Offset: 0x003BD010
		private void InitFuncItemUIList()
		{
			if (this.mFuncItemUIList != null)
			{
				this.mFuncItemUIList.Initialize();
				ComUIListScript comUIListScript = this.mFuncItemUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mFuncItemUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600E5E6 RID: 58854 RVA: 0x003BEC88 File Offset: 0x003BD088
		private void UnInitFuncItemUIList()
		{
			if (this.mFuncItemUIList != null)
			{
				ComUIListScript comUIListScript = this.mFuncItemUIList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mFuncItemUIList = null;
		}

		// Token: 0x0600E5E7 RID: 58855 RVA: 0x003BECD4 File Offset: 0x003BD0D4
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600E5E8 RID: 58856 RVA: 0x003BECDC File Offset: 0x003BD0DC
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind == null)
			{
				return;
			}
			if (item.m_index >= 0 && item.m_index < this.mFuncInfos.Count)
			{
				TipFuncButon tipFuncBtn = this.mFuncInfos[item.m_index];
				Text com = comCommonBind.GetCom<Text>("name");
				Button com2 = comCommonBind.GetCom<Button>("TabItemBtn");
				if (com != null)
				{
					com.text = tipFuncBtn.text;
				}
				if (com2 != null)
				{
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						tipFuncBtn.callback(this.mItem, this.mTipIndex);
					});
				}
			}
		}

		// Token: 0x0600E5E9 RID: 58857 RVA: 0x003BEDAB File Offset: 0x003BD1AB
		private void OnDestroy()
		{
			this.mFuncInfos = null;
			this.mItem = null;
			this.mTipIndex = 0;
			this.UnInitFuncItemUIList();
		}

		// Token: 0x04008B32 RID: 35634
		[SerializeField]
		private ComUIListScript mFuncItemUIList;

		// Token: 0x04008B33 RID: 35635
		[SerializeField]
		private GameObject mTabItemRoot;

		// Token: 0x04008B34 RID: 35636
		[SerializeField]
		private GameObject mDownArrow;

		// Token: 0x04008B35 RID: 35637
		[SerializeField]
		private GameObject mUpArrow;

		// Token: 0x04008B36 RID: 35638
		[SerializeField]
		private Text mDesc;

		// Token: 0x04008B37 RID: 35639
		[SerializeField]
		private string mStrMore = "更多";

		// Token: 0x04008B38 RID: 35640
		[SerializeField]
		private string mStrPackUp = "收起";

		// Token: 0x04008B39 RID: 35641
		private List<TipFuncButon> mFuncInfos;

		// Token: 0x04008B3A RID: 35642
		private ItemData mItem;

		// Token: 0x04008B3B RID: 35643
		private int mTipIndex;
	}
}
