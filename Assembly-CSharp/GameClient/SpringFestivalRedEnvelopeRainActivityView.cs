using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018B4 RID: 6324
	public class SpringFestivalRedEnvelopeRainActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F730 RID: 63280 RVA: 0x0042DCB8 File Offset: 0x0042C0B8
		public sealed override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this.mTime.SafeSetText(string.Format("{0}~{1}", Function.GetDateTime((int)this.mModel.StartTime, true), Function.GetDateTime((int)this.mModel.EndTime, true)));
			this.mRule.SafeSetText(this.mModel.RuleDesc.Replace('|', '\n'));
			this.UpdateActiveInfo();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Combine(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
		}

		// Token: 0x0600F731 RID: 63281 RVA: 0x0042DD6D File Offset: 0x0042C16D
		private void UpdateActiveInfo()
		{
			this.mActive.SafeSetText(string.Format(this.mActiveDesc, DataManager<MissionManager>.GetInstance().Score));
		}

		// Token: 0x0600F732 RID: 63282 RVA: 0x0042DD94 File Offset: 0x0042C194
		private void OnDailyScoreChanged(int score)
		{
			this.UpdateActiveInfo();
		}

		// Token: 0x0600F733 RID: 63283 RVA: 0x0042DD9C File Offset: 0x0042C19C
		public sealed override void Dispose()
		{
			base.Dispose();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onDailyScoreChanged = (MissionManager.OnDailyScoreChanged)Delegate.Remove(instance.onDailyScoreChanged, new MissionManager.OnDailyScoreChanged(this.OnDailyScoreChanged));
		}

		// Token: 0x04009807 RID: 38919
		[SerializeField]
		private Text mTime;

		// Token: 0x04009808 RID: 38920
		[SerializeField]
		private Text mRule;

		// Token: 0x04009809 RID: 38921
		[SerializeField]
		private Text mActive;

		// Token: 0x0400980A RID: 38922
		[SerializeField]
		private string mActiveDesc = "今日活跃度:{0}";
	}
}
