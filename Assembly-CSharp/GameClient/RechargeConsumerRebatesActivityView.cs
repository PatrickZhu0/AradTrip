using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018AC RID: 6316
	public class RechargeConsumerRebatesActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F6F9 RID: 63225 RVA: 0x0042CAB8 File Offset: 0x0042AEB8
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
			this.OnSceneOpActivityGetCounterReq();
		}

		// Token: 0x0600F6FA RID: 63226 RVA: 0x0042CAE3 File Offset: 0x0042AEE3
		public override void Close()
		{
			base.Close();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this.OnCounterChanged));
		}

		// Token: 0x0600F6FB RID: 63227 RVA: 0x0042CB06 File Offset: 0x0042AF06
		public override void Show()
		{
			base.Show();
			this.OnSceneOpActivityGetCounterReq();
		}

		// Token: 0x0600F6FC RID: 63228 RVA: 0x0042CB14 File Offset: 0x0042AF14
		private void RefreshMoneyNumber()
		{
			int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mModel.Id, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_MONEY_CONSUME_COUNT);
			if (this.mCount != null)
			{
				this.mCount.text = activityConunter.ToString();
			}
		}

		// Token: 0x0600F6FD RID: 63229 RVA: 0x0042CB65 File Offset: 0x0042AF65
		private void OnCounterChanged(UIEvent uiEvent)
		{
			if (uiEvent != null && (uint)uiEvent.Param1 == this.mModel.Id)
			{
				this.RefreshMoneyNumber();
			}
		}

		// Token: 0x0600F6FE RID: 63230 RVA: 0x0042CB8E File Offset: 0x0042AF8E
		private void OnSceneOpActivityGetCounterReq()
		{
			DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType.OAT_RECHARGECONSUMERREBATES, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_MONEY_CONSUME_COUNT);
		}

		// Token: 0x040097E2 RID: 38882
		[SerializeField]
		private Text mCount;
	}
}
