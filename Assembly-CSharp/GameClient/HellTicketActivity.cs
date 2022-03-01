using System;
using UnityEngine;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001845 RID: 6213
	public sealed class HellTicketActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F40A RID: 62474 RVA: 0x0041EB89 File Offset: 0x0041CF89
		public override bool IsHaveRedPoint()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME) > 0;
		}

		// Token: 0x0600F40B RID: 62475 RVA: 0x0041EB9D File Offset: 0x0041CF9D
		public override void Init(uint activityId)
		{
			base.Init(activityId);
			if (this.mDataModel != null)
			{
				this.mDataModel.SortTaskByState();
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F40C RID: 62476 RVA: 0x0041EBD7 File Offset: 0x0041CFD7
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F40D RID: 62477 RVA: 0x0041EBFC File Offset: 0x0041CFFC
		public override void Show(Transform root)
		{
			base.Show(root);
			HellTicketActivityView hellTicketActivityView = this.mView as HellTicketActivityView;
			if (hellTicketActivityView != null)
			{
				hellTicketActivityView.OnLotteryClick = new UnityAction(this._DrawLottery);
				hellTicketActivityView.OnPreviewAwardsClick = new UnityAction(this._PreviewAwards);
			}
		}

		// Token: 0x0600F40E RID: 62478 RVA: 0x0041EC4C File Offset: 0x0041D04C
		protected override string _GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/HellTicketActivity";
		}

		// Token: 0x0600F40F RID: 62479 RVA: 0x0041EC53 File Offset: 0x0041D053
		protected override string _GetItemPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/Items/HellTicketItem";
		}

		// Token: 0x0600F410 RID: 62480 RVA: 0x0041EC5C File Offset: 0x0041D05C
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			HellTicketActivityView hellTicketActivityView = this.mView as HellTicketActivityView;
			if (hellTicketActivityView != null)
			{
				hellTicketActivityView.UpdateLotteryCount();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeUpdate, this, null, null, null);
		}

		// Token: 0x0600F411 RID: 62481 RVA: 0x0041EC9A File Offset: 0x0041D09A
		private void _PreviewAwards()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RewardShow>(FrameLayer.Middle, 10002, string.Empty);
		}

		// Token: 0x0600F412 RID: 62482 RVA: 0x0041ECB7 File Offset: 0x0041D0B7
		private void _DrawLottery()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TurnTable>(FrameLayer.Middle, 10002, string.Empty);
		}

		// Token: 0x02001846 RID: 6214
		public enum LotteryType
		{
			// Token: 0x040095FB RID: 38395
			ConsumeLottery = 10002
		}
	}
}
