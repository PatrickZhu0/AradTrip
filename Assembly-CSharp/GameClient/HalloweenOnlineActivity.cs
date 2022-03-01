using System;

namespace GameClient
{
	// Token: 0x02001844 RID: 6212
	public class HalloweenOnlineActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F403 RID: 62467 RVA: 0x0041EA9B File Offset: 0x0041CE9B
		public sealed override bool IsHaveRedPoint()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_ONLINE_TIME) > 0;
		}

		// Token: 0x0600F404 RID: 62468 RVA: 0x0041EAAF File Offset: 0x0041CEAF
		public sealed override void Init(uint activityId)
		{
			base.Init(activityId);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F405 RID: 62469 RVA: 0x0041EAD3 File Offset: 0x0041CED3
		public sealed override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F406 RID: 62470 RVA: 0x0041EAF8 File Offset: 0x0041CEF8
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			HalloweenOnlineActivityView halloweenOnlineActivityView = this.mView as HalloweenOnlineActivityView;
			if (halloweenOnlineActivityView != null)
			{
				halloweenOnlineActivityView.UpdateLotteryCount();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this, null, null, null);
		}

		// Token: 0x0600F407 RID: 62471 RVA: 0x0041EB38 File Offset: 0x0041CF38
		protected sealed override string _GetPrefabPath()
		{
			string result = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/HalloweenOnlineActivity";
			if (this.mDataModel != null && !string.IsNullOrEmpty(this.mDataModel.ActivityPrefafPath))
			{
				return this.mDataModel.ActivityPrefafPath;
			}
			return result;
		}

		// Token: 0x0600F408 RID: 62472 RVA: 0x0041EB7A File Offset: 0x0041CF7A
		protected sealed override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/HalloweenOnlineItem";
		}
	}
}
