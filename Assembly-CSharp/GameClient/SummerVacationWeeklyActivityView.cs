using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B6 RID: 6326
	public class SummerVacationWeeklyActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F739 RID: 63289 RVA: 0x0042DE02 File Offset: 0x0042C202
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			this.mData = model;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this._UpdateData();
		}

		// Token: 0x0600F73A RID: 63290 RVA: 0x0042DE34 File Offset: 0x0042C234
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.Id)
			{
				this._UpdateData();
			}
		}

		// Token: 0x0600F73B RID: 63291 RVA: 0x0042DE62 File Offset: 0x0042C262
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			base.UpdateData(data);
			this._UpdateData();
		}

		// Token: 0x0600F73C RID: 63292 RVA: 0x0042DE74 File Offset: 0x0042C274
		private void _UpdateData()
		{
			int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION, ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION);
			if (this.mData != null && this.mData.ParamArray != null && this.mData.ParamArray.Length >= 2)
			{
				this.mTotalReceiveAcountNum = (int)this.mData.ParamArray[0];
				this.mTotalReceiveRoleNum = (int)this.mData.ParamArray[1];
			}
			this.mCanReceiveAccountNum = this.mTotalReceiveAcountNum - activityConunter;
			if (this.mCanReceiveAccountNum <= 0)
			{
				this.mCanReceiveAccountNum = 0;
			}
			List<uint> haveRecivedTaskID = DataManager<ActivityDataManager>.GetInstance().GetHaveRecivedTaskID(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION);
			if (haveRecivedTaskID != null && haveRecivedTaskID.Count > 0)
			{
				this.mCanReceiveRoleNum = this.mTotalReceiveRoleNum - haveRecivedTaskID.Count;
				if (this.mCanReceiveRoleNum <= 0)
				{
					this.mCanReceiveRoleNum = 0;
				}
			}
			if (this.mCanReceiveAccountNum <= 0)
			{
				this.mCanReceiveRoleNum = 0;
			}
			if (this.mAccountTip != null)
			{
				this.mAccountTip.text = string.Format(TR.Value("limitactivity_shuqi_accounttip"), this.mCanReceiveAccountNum, this.mTotalReceiveAcountNum);
			}
			if (this.mRoleTip != null)
			{
				this.mRoleTip.text = string.Format(TR.Value("limitactivity_shuqi_roletip"), this.mCanReceiveRoleNum, this.mTotalReceiveRoleNum);
			}
		}

		// Token: 0x0600F73D RID: 63293 RVA: 0x0042DFE8 File Offset: 0x0042C3E8
		public override void Show()
		{
			base.Show();
		}

		// Token: 0x0600F73E RID: 63294 RVA: 0x0042DFF0 File Offset: 0x0042C3F0
		public override void Hide()
		{
			base.Hide();
		}

		// Token: 0x0600F73F RID: 63295 RVA: 0x0042DFF8 File Offset: 0x0042C3F8
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0400980B RID: 38923
		[SerializeField]
		private Text mRoleTip;

		// Token: 0x0400980C RID: 38924
		[SerializeField]
		private Text mAccountTip;

		// Token: 0x0400980D RID: 38925
		private int mCanReceiveAccountNum = 3;

		// Token: 0x0400980E RID: 38926
		private int mTotalReceiveAcountNum;

		// Token: 0x0400980F RID: 38927
		private int mCanReceiveRoleNum = 1;

		// Token: 0x04009810 RID: 38928
		private int mTotalReceiveRoleNum;

		// Token: 0x04009811 RID: 38929
		private ILimitTimeActivityModel mData;
	}
}
