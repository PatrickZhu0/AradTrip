using System;
using System.Collections;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015AB RID: 5547
	public class DailyTodoFrame : ClientFrame
	{
		// Token: 0x0600D8DC RID: 55516 RVA: 0x00364A24 File Offset: 0x00362E24
		public static void OpenLinkFrame()
		{
			try
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DailyTodoFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<DailyTodoFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<DailyTodoFrame>(FrameLayer.Middle, null, string.Empty);
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600D8DD RID: 55517 RVA: 0x00364A88 File Offset: 0x00362E88
		public static void CloseFrame()
		{
			try
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<DailyTodoFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<DailyTodoFrame>(null, false);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600D8DE RID: 55518 RVA: 0x00364AD8 File Offset: 0x00362ED8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/DailyTodo/DailyTodoFrame";
		}

		// Token: 0x0600D8DF RID: 55519 RVA: 0x00364ADF File Offset: 0x00362EDF
		protected override void _OnOpenFrame()
		{
			this._BindUIEvent();
			DataManager<DailyTodoDataManager>.GetInstance().UpdateDailyTodoActivityList();
			this._InitView();
			DataManager<DailyTodoDataManager>.GetInstance().ReqDailyTodoFunctionState();
		}

		// Token: 0x0600D8E0 RID: 55520 RVA: 0x00364B01 File Offset: 0x00362F01
		protected override void _OnCloseFrame()
		{
			this._UnInitView();
			this._UnBindUIEvent();
			if (this.tempFunctionItemList != null)
			{
				this.tempFunctionItemList.Clear();
			}
			DataManager<DailyTodoDataManager>.GetInstance().ClearTempShowDailyTodoData();
		}

		// Token: 0x0600D8E1 RID: 55521 RVA: 0x00364B2F File Offset: 0x00362F2F
		private void _InitView()
		{
			this._InitActivityView();
			this._InitFunctionView();
		}

		// Token: 0x0600D8E2 RID: 55522 RVA: 0x00364B3D File Offset: 0x00362F3D
		private void _UnInitView()
		{
			this._UnInitActvityView();
			this._UnInitFunctionView();
		}

		// Token: 0x0600D8E3 RID: 55523 RVA: 0x00364B4C File Offset: 0x00362F4C
		private void _InitActivityView()
		{
			if (this.mActivityCarousel != null)
			{
				ComCarouselView comCarouselView = this.mActivityCarousel;
				comCarouselView.onBindItem = (ComCarouselView.OnBindItemDelegate)Delegate.Combine(comCarouselView.onBindItem, new ComCarouselView.OnBindItemDelegate(this._OnActivityItemBindView));
				ComCarouselView comCarouselView2 = this.mActivityCarousel;
				comCarouselView2.onItemCreate = (ComCarouselView.OnItemCreateDelegate)Delegate.Combine(comCarouselView2.onItemCreate, new ComCarouselView.OnItemCreateDelegate(this._OnActivityItemCreate));
				ComCarouselView comCarouselView3 = this.mActivityCarousel;
				comCarouselView3.onIndexChange = (ComCarouselView.OnItemIndexChange)Delegate.Combine(comCarouselView3.onIndexChange, new ComCarouselView.OnItemIndexChange(this._OnActivityItemIndexChange));
			}
			this._RefreshActivityItemView();
		}

		// Token: 0x0600D8E4 RID: 55524 RVA: 0x00364BE8 File Offset: 0x00362FE8
		private void _UnInitActvityView()
		{
			if (this.mActivityCarousel != null)
			{
				ComCarouselView comCarouselView = this.mActivityCarousel;
				comCarouselView.onBindItem = (ComCarouselView.OnBindItemDelegate)Delegate.Remove(comCarouselView.onBindItem, new ComCarouselView.OnBindItemDelegate(this._OnActivityItemBindView));
				ComCarouselView comCarouselView2 = this.mActivityCarousel;
				comCarouselView2.onItemCreate = (ComCarouselView.OnItemCreateDelegate)Delegate.Remove(comCarouselView2.onItemCreate, new ComCarouselView.OnItemCreateDelegate(this._OnActivityItemCreate));
				ComCarouselView comCarouselView3 = this.mActivityCarousel;
				comCarouselView3.onIndexChange = (ComCarouselView.OnItemIndexChange)Delegate.Remove(comCarouselView3.onIndexChange, new ComCarouselView.OnItemIndexChange(this._OnActivityItemIndexChange));
			}
		}

		// Token: 0x0600D8E5 RID: 55525 RVA: 0x00364C7C File Offset: 0x0036307C
		private void _RefreshActivityItemView()
		{
			List<DailyTodoActivity> showDailyTodoActivityList = DataManager<DailyTodoDataManager>.GetInstance().GetShowDailyTodoActivityList();
			if (showDailyTodoActivityList == null)
			{
				return;
			}
			if (this.mActivityCarousel != null)
			{
				this.mActivityCarousel.SetCellAmount(showDailyTodoActivityList.Count);
			}
			if (this.mScrollDots != null)
			{
				this.mScrollDots.InitDots(showDailyTodoActivityList.Count, true);
				if (this.mActivityCarousel != null)
				{
					this.mScrollDots.SetDots(this.mActivityCarousel.CurrentIndex + 1, 0);
				}
			}
		}

		// Token: 0x0600D8E6 RID: 55526 RVA: 0x00364D0C File Offset: 0x0036310C
		private ComDailyTodoActivityItem _OnActivityItemBindView(GameObject go)
		{
			if (null == go || go.transform.childCount <= 0)
			{
				return null;
			}
			Transform child = go.transform.GetChild(0);
			if (null == child)
			{
				return null;
			}
			return child.GetComponent<ComDailyTodoActivityItem>();
		}

		// Token: 0x0600D8E7 RID: 55527 RVA: 0x00364D5C File Offset: 0x0036315C
		private void _OnActivityItemCreate(ComCarouselCell item)
		{
			if (null == item)
			{
				return;
			}
			List<DailyTodoActivity> showDailyTodoActivityList = DataManager<DailyTodoDataManager>.GetInstance().GetShowDailyTodoActivityList();
			if (showDailyTodoActivityList == null || showDailyTodoActivityList.Count <= 0)
			{
				return;
			}
			int index = item.Index;
			ComDailyTodoActivityItem comDailyTodoActivityItem = item.BindScript as ComDailyTodoActivityItem;
			if (index >= 0 && index < showDailyTodoActivityList.Count)
			{
				DailyTodoActivity dailyTodoActivity = showDailyTodoActivityList[index];
				if (dailyTodoActivity == null)
				{
					return;
				}
				if (comDailyTodoActivityItem != null)
				{
					comDailyTodoActivityItem.RefreshView(dailyTodoActivity);
				}
			}
		}

		// Token: 0x0600D8E8 RID: 55528 RVA: 0x00364DDC File Offset: 0x003631DC
		private void _OnActivityItemIndexChange(int index)
		{
			if (this.mScrollDots != null)
			{
				this.mScrollDots.SetDots(index + 1, 0);
			}
		}

		// Token: 0x0600D8E9 RID: 55529 RVA: 0x00364E00 File Offset: 0x00363200
		private void _InitFunctionView()
		{
			if (this.mFuncScorllView != null)
			{
				if (this.mFuncScorllView.IsInitialised())
				{
					return;
				}
				this.mFuncScorllView.Initialize();
				ComUIListScript comUIListScript = this.mFuncScorllView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnFunctionBindItem));
				ComUIListScript comUIListScript2 = this.mFuncScorllView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnFunctionVisable));
				ComUIListScript comUIListScript3 = this.mFuncScorllView;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnFunctionItemRecycle));
			}
			this._RefreshFunctionItemView(false);
		}

		// Token: 0x0600D8EA RID: 55530 RVA: 0x00364EB8 File Offset: 0x003632B8
		private void _UnInitFunctionView()
		{
			if (this.mFuncScorllView != null)
			{
				ComUIListScript comUIListScript = this.mFuncScorllView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnFunctionBindItem));
				ComUIListScript comUIListScript2 = this.mFuncScorllView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnFunctionVisable));
				ComUIListScript comUIListScript3 = this.mFuncScorllView;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnFunctionItemRecycle));
				this.mFuncScorllView.UnInitialize();
			}
			if (this.waitToRefreshFuncViewOnAnimEnd != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToRefreshFuncViewOnAnimEnd);
				this.waitToRefreshFuncViewOnAnimEnd = null;
			}
		}

		// Token: 0x0600D8EB RID: 55531 RVA: 0x00364F78 File Offset: 0x00363378
		private void _RefreshFunctionItemView(bool needPlayAnim = true)
		{
			List<DailyTodoFunction> showDailyTodoFunctionListByCount = DataManager<DailyTodoDataManager>.GetInstance().GetShowDailyTodoFunctionListByCount(3);
			if (showDailyTodoFunctionListByCount != null && this.mFuncScorllView != null)
			{
				this.mFuncScorllView.SetElementAmount(showDailyTodoFunctionListByCount.Count);
			}
			if (needPlayAnim)
			{
				this._TryInvokeNearlyFunctionItemPlayAnim();
			}
		}

		// Token: 0x0600D8EC RID: 55532 RVA: 0x00364FC6 File Offset: 0x003633C6
		private ComDailyTodoFunctionItem _OnFunctionBindItem(GameObject go)
		{
			if (null == go)
			{
				return null;
			}
			return go.GetComponent<ComDailyTodoFunctionItem>();
		}

		// Token: 0x0600D8ED RID: 55533 RVA: 0x00364FDC File Offset: 0x003633DC
		private void _OnFunctionVisable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			List<DailyTodoFunction> showDailyTodoFunctionListByCount = DataManager<DailyTodoDataManager>.GetInstance().GetShowDailyTodoFunctionListByCount(3);
			int index = item.m_index;
			ComDailyTodoFunctionItem comDailyTodoFunctionItem = item.gameObjectBindScript as ComDailyTodoFunctionItem;
			if (index >= 0 && index < showDailyTodoFunctionListByCount.Count && comDailyTodoFunctionItem != null)
			{
				comDailyTodoFunctionItem.RefreshView(showDailyTodoFunctionListByCount[index]);
				if (this.tempFunctionItemList != null && !this.tempFunctionItemList.Contains(comDailyTodoFunctionItem))
				{
					this.tempFunctionItemList.Add(comDailyTodoFunctionItem);
				}
			}
		}

		// Token: 0x0600D8EE RID: 55534 RVA: 0x0036506C File Offset: 0x0036346C
		private void _OnFunctionItemRecycle(ComUIListElementScript item)
		{
			if (null == item)
			{
				return;
			}
			ComDailyTodoFunctionItem comDailyTodoFunctionItem = item.gameObjectBindScript as ComDailyTodoFunctionItem;
			if (null != comDailyTodoFunctionItem)
			{
				comDailyTodoFunctionItem.Recycle();
				if (this.tempFunctionItemList != null && this.tempFunctionItemList.Contains(comDailyTodoFunctionItem))
				{
					this.tempFunctionItemList.Remove(comDailyTodoFunctionItem);
				}
			}
		}

		// Token: 0x0600D8EF RID: 55535 RVA: 0x003650D0 File Offset: 0x003634D0
		private bool _TryInvokeNearlyFunctionItemPlayAnim()
		{
			if (this.tempFunctionItemList == null)
			{
				return false;
			}
			for (int i = 0; i < this.tempFunctionItemList.Count; i++)
			{
				ComDailyTodoFunctionItem comDailyTodoFunctionItem = this.tempFunctionItemList[i];
				if (!(null == comDailyTodoFunctionItem))
				{
					bool flag = comDailyTodoFunctionItem.TryPlayAnim();
					if (flag)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600D8F0 RID: 55536 RVA: 0x00365134 File Offset: 0x00363534
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDailyTodoFuncStateUpdate, new ClientEventSystem.UIEventHandler(this._OnDailyTodoFuncStateUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnDailyTodoFuncPlayAnimEnd, new ClientEventSystem.UIEventHandler(this._OnDailyTodoFuncPlayAnimEnd));
		}

		// Token: 0x0600D8F1 RID: 55537 RVA: 0x0036516C File Offset: 0x0036356C
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDailyTodoFuncStateUpdate, new ClientEventSystem.UIEventHandler(this._OnDailyTodoFuncStateUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnDailyTodoFuncPlayAnimEnd, new ClientEventSystem.UIEventHandler(this._OnDailyTodoFuncPlayAnimEnd));
		}

		// Token: 0x0600D8F2 RID: 55538 RVA: 0x003651A4 File Offset: 0x003635A4
		private void _OnDailyTodoFuncStateUpdate(UIEvent uiEvent)
		{
			this._RefreshFunctionItemView(true);
		}

		// Token: 0x0600D8F3 RID: 55539 RVA: 0x003651B0 File Offset: 0x003635B0
		private void _OnDailyTodoFuncPlayAnimEnd(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ComDailyTodoFunctionExtraAnimParam comDailyTodoFunctionExtraAnimParam = uiEvent.Param1 as ComDailyTodoFunctionExtraAnimParam;
			if (comDailyTodoFunctionExtraAnimParam == null)
			{
				return;
			}
			if (!this._TryInvokeNearlyFunctionItemPlayAnim())
			{
				if (this.waitToRefreshFuncViewOnAnimEnd != null)
				{
					MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToRefreshFuncViewOnAnimEnd);
				}
				this.waitToRefreshFuncViewOnAnimEnd = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToRefreshFuncViewOnAnimEnd(comDailyTodoFunctionExtraAnimParam.finishTagEndWaitingTime));
			}
		}

		// Token: 0x0600D8F4 RID: 55540 RVA: 0x00365224 File Offset: 0x00363624
		private IEnumerator _WaitToRefreshFuncViewOnAnimEnd(float waitTime)
		{
			yield return Yielders.GetWaitForSeconds(waitTime);
			this._RefreshFunctionItemView(true);
			yield break;
		}

		// Token: 0x0600D8F5 RID: 55541 RVA: 0x00365248 File Offset: 0x00363648
		protected override void _bindExUI()
		{
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mActivityCarousel = this.mBind.GetCom<ComCarouselView>("ActivityCarousel");
			this.mFuncScorllView = this.mBind.GetCom<ComUIListScript>("FuncScorllView");
			this.mScrollDots = this.mBind.GetCom<ComDotController>("ScrollDots");
		}

		// Token: 0x0600D8F6 RID: 55542 RVA: 0x003652DC File Offset: 0x003636DC
		protected override void _unbindExUI()
		{
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnClose = null;
			this.mActivityCarousel = null;
			this.mFuncScorllView = null;
			this.mScrollDots = null;
		}

		// Token: 0x0600D8F7 RID: 55543 RVA: 0x00365332 File Offset: 0x00363732
		private void _onBtnCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x04007F78 RID: 32632
		public static readonly string OPEN_LINK_INFO = "<type=framename value=GameClient.DailyTodoFrame>";

		// Token: 0x04007F79 RID: 32633
		private List<ComDailyTodoFunctionItem> tempFunctionItemList = new List<ComDailyTodoFunctionItem>();

		// Token: 0x04007F7A RID: 32634
		private Coroutine waitToRefreshFuncViewOnAnimEnd;

		// Token: 0x04007F7B RID: 32635
		private Button mBtnClose;

		// Token: 0x04007F7C RID: 32636
		private ComCarouselView mActivityCarousel;

		// Token: 0x04007F7D RID: 32637
		private ComUIListScript mFuncScorllView;

		// Token: 0x04007F7E RID: 32638
		private ComDotController mScrollDots;
	}
}
