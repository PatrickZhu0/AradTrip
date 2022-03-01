using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013BF RID: 5055
	public class CompleteQuestPlayerLlistFrame : ClientFrame
	{
		// Token: 0x0600C42A RID: 50218 RVA: 0x002F1230 File Offset: 0x002EF630
		protected sealed override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
		}

		// Token: 0x0600C42B RID: 50219 RVA: 0x002F1285 File Offset: 0x002EF685
		protected sealed override void _unbindExUI()
		{
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mUIList = null;
		}

		// Token: 0x0600C42C RID: 50220 RVA: 0x002F12B1 File Offset: 0x002EF6B1
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<CompleteQuestPlayerLlistFrame>(this, false);
		}

		// Token: 0x0600C42D RID: 50221 RVA: 0x002F12C0 File Offset: 0x002EF6C0
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/WarriorRecruit/CompleteQuestPlayerLlistFrame";
		}

		// Token: 0x0600C42E RID: 50222 RVA: 0x002F12C7 File Offset: 0x002EF6C7
		protected sealed override void _OnOpenFrame()
		{
			this.InitUIList();
			this.recruitPlayerInfoList = (this.userData as List<string>);
			this.mUIList.SetElementAmount(this.recruitPlayerInfoList.Count);
		}

		// Token: 0x0600C42F RID: 50223 RVA: 0x002F12F6 File Offset: 0x002EF6F6
		protected sealed override void _OnCloseFrame()
		{
			this.UnInitUIList();
			this.recruitPlayerInfoList.Clear();
		}

		// Token: 0x0600C430 RID: 50224 RVA: 0x002F130C File Offset: 0x002EF70C
		private void InitUIList()
		{
			if (this.mUIList != null)
			{
				this.mUIList.Initialize();
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600C431 RID: 50225 RVA: 0x002F1384 File Offset: 0x002EF784
		private void UnInitUIList()
		{
			if (this.mUIList != null)
			{
				ComUIListScript comUIListScript = this.mUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600C432 RID: 50226 RVA: 0x002F13F0 File Offset: 0x002EF7F0
		private ComCommonBind OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<ComCommonBind>();
		}

		// Token: 0x0600C433 RID: 50227 RVA: 0x002F13F8 File Offset: 0x002EF7F8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			ComCommonBind comCommonBind = item.gameObjectBindScript as ComCommonBind;
			if (comCommonBind != null && item.m_index >= 0 && item.m_index < this.recruitPlayerInfoList.Count)
			{
				Text com = comCommonBind.GetCom<Text>("name");
				string text = this.recruitPlayerInfoList[item.m_index];
				if (com != null)
				{
					com.text = text;
				}
			}
		}

		// Token: 0x04006FAC RID: 28588
		private Button mBtClose;

		// Token: 0x04006FAD RID: 28589
		private ComUIListScript mUIList;

		// Token: 0x04006FAE RID: 28590
		private List<string> recruitPlayerInfoList = new List<string>();
	}
}
