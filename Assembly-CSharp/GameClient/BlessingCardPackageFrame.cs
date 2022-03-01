using System;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200192F RID: 6447
	public class BlessingCardPackageFrame : ClientFrame
	{
		// Token: 0x0600FABF RID: 64191 RVA: 0x0044AFC8 File Offset: 0x004493C8
		protected override void _bindExUI()
		{
			this.mUIList = this.mBind.GetCom<ComUIListScript>("UIList");
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mCoinCount = this.mBind.GetCom<Text>("CoinCount");
		}

		// Token: 0x0600FAC0 RID: 64192 RVA: 0x0044B033 File Offset: 0x00449433
		protected override void _unbindExUI()
		{
			this.mUIList = null;
			this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose = null;
			this.mCoinCount = null;
		}

		// Token: 0x0600FAC1 RID: 64193 RVA: 0x0044B066 File Offset: 0x00449466
		private void _onBtnCloseButtonClick()
		{
			this.frameMgr.CloseFrame<BlessingCardPackageFrame>(this, false);
		}

		// Token: 0x0600FAC2 RID: 64194 RVA: 0x0044B075 File Offset: 0x00449475
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/BlessingCardPackageFrame";
		}

		// Token: 0x0600FAC3 RID: 64195 RVA: 0x0044B07C File Offset: 0x0044947C
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBlessingCardChanged, new ClientEventSystem.UIEventHandler(this.OnBlessingCardChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this.OnZillionaireGameInfoChanged));
			this.RefreshCoinCount();
			this.InitUIList();
			this.OnSetElementAmount();
		}

		// Token: 0x0600FAC4 RID: 64196 RVA: 0x0044B0D1 File Offset: 0x004494D1
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBlessingCardChanged, new ClientEventSystem.UIEventHandler(this.OnBlessingCardChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this.OnZillionaireGameInfoChanged));
			this.UnInitUIList();
		}

		// Token: 0x0600FAC5 RID: 64197 RVA: 0x0044B10F File Offset: 0x0044950F
		private void RefreshCoinCount()
		{
			if (this.mCoinCount != null)
			{
				this.mCoinCount.text = string.Format("x{0}", DataManager<ZillionaireGameDataManager>.GetInstance().CoinCount);
			}
		}

		// Token: 0x0600FAC6 RID: 64198 RVA: 0x0044B148 File Offset: 0x00449548
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

		// Token: 0x0600FAC7 RID: 64199 RVA: 0x0044B1C0 File Offset: 0x004495C0
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

		// Token: 0x0600FAC8 RID: 64200 RVA: 0x0044B22C File Offset: 0x0044962C
		private BlessingCardPackageItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<BlessingCardPackageItem>();
		}

		// Token: 0x0600FAC9 RID: 64201 RVA: 0x0044B234 File Offset: 0x00449634
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			BlessingCardPackageItem blessingCardPackageItem = item.gameObjectBindScript as BlessingCardPackageItem;
			if (blessingCardPackageItem != null && item.m_index >= 0 && item.m_index < DataManager<ZillionaireGameDataManager>.GetInstance().monpolyCardList.Count)
			{
				MonpolyCard monpolyCard = DataManager<ZillionaireGameDataManager>.GetInstance().monpolyCardList[item.m_index];
				blessingCardPackageItem.OnItemVisiable(monpolyCard);
			}
		}

		// Token: 0x0600FACA RID: 64202 RVA: 0x0044B29C File Offset: 0x0044969C
		private void OnSetElementAmount()
		{
			if (this.mUIList != null)
			{
				this.mUIList.SetElementAmount(DataManager<ZillionaireGameDataManager>.GetInstance().monpolyCardList.Count);
			}
		}

		// Token: 0x0600FACB RID: 64203 RVA: 0x0044B2C9 File Offset: 0x004496C9
		private void OnBlessingCardChanged(UIEvent uIEvent)
		{
			this.OnSetElementAmount();
		}

		// Token: 0x0600FACC RID: 64204 RVA: 0x0044B2D1 File Offset: 0x004496D1
		private void OnZillionaireGameInfoChanged(UIEvent uiEvent)
		{
			this.RefreshCoinCount();
		}

		// Token: 0x04009CAD RID: 40109
		private ComUIListScript mUIList;

		// Token: 0x04009CAE RID: 40110
		private Button mBtnClose;

		// Token: 0x04009CAF RID: 40111
		private Text mCoinCount;
	}
}
