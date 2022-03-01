using System;
using DataModel;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013DF RID: 5087
	public sealed class ActivityTreasureLotteryDrawFrame : ClientFrame
	{
		// Token: 0x0600C53F RID: 50495 RVA: 0x002F8310 File Offset: 0x002F6710
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ActivityTreasureLottery/ActivityTreasureLotteryDrawFrame";
		}

		// Token: 0x0600C540 RID: 50496 RVA: 0x002F8318 File Offset: 0x002F6718
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			IActivityTreasureLotteryDrawModel activityTreasureLotteryDrawModel = DataManager<ActivityTreasureLotteryDataManager>.GetInstance().DequeueDrawLottery();
			if (this.mView == null || activityTreasureLotteryDrawModel == null)
			{
				return;
			}
			this.mView.Init(activityTreasureLotteryDrawModel, activityTreasureLotteryDrawModel.TopFiveInvestPlayers.Length > 1);
		}

		// Token: 0x0600C541 RID: 50497 RVA: 0x002F8365 File Offset: 0x002F6765
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			if (this.mView == null)
			{
				return;
			}
			this.mView.Dispose();
		}

		// Token: 0x0600C542 RID: 50498 RVA: 0x002F838C File Offset: 0x002F678C
		protected override void _bindExUI()
		{
			this.mButtonRecord = this.mBind.GetCom<Button>("ButtonRecord");
			this.mButtonRecord.SafeAddOnClickListener(new UnityAction(this._onButtonRecordButtonClick));
			this.mView = this.mBind.GetCom<ActivityTreasureLotteryDrawView>("View");
			this.mButtonClose = this.mBind.GetCom<Button>("ButtonClose");
			this.mButtonClose.SafeAddOnClickListener(new UnityAction(this._onButtonCloseButtonClick));
		}

		// Token: 0x0600C543 RID: 50499 RVA: 0x002F840C File Offset: 0x002F680C
		protected override void _unbindExUI()
		{
			this.mButtonRecord.SafeRemoveOnClickListener(new UnityAction(this._onButtonRecordButtonClick));
			this.mButtonRecord = null;
			this.mView = null;
			this.mButtonClose.SafeRemoveOnClickListener(new UnityAction(this._onButtonCloseButtonClick));
			this.mButtonClose = null;
		}

		// Token: 0x0600C544 RID: 50500 RVA: 0x002F845C File Offset: 0x002F685C
		private void _onButtonRecordButtonClick()
		{
			if (DataManager<ActivityTreasureLotteryDataManager>.GetInstance().GetState() == ETreasureLotterState.Open)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityTreasureLotteryFrame>(FrameLayer.Middle, EActivityTreasureLotteryView.HistoryView, string.Empty);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotteryShowActivity, null, null, null, null);
			}
			else
			{
				SystemNotifyManager.SystemNotify(9062, string.Empty);
			}
			base.Close(false);
		}

		// Token: 0x0600C545 RID: 50501 RVA: 0x002F84BE File Offset: 0x002F68BE
		private void _onButtonCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0400709A RID: 28826
		private Button mButtonRecord;

		// Token: 0x0400709B RID: 28827
		private ActivityTreasureLotteryDrawView mView;

		// Token: 0x0400709C RID: 28828
		private Button mButtonClose;
	}
}
