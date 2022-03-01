using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001827 RID: 6183
	public sealed class BossQuestActivity : LimitTimeCommonActivity
	{
		// Token: 0x0600F381 RID: 62337 RVA: 0x0041CF30 File Offset: 0x0041B330
		public override void Init(uint activityId)
		{
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(activityId);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossQuestModel(bossActivityData);
			}
		}

		// Token: 0x0600F382 RID: 62338 RVA: 0x0041CF5C File Offset: 0x0041B35C
		public override void UpdateData()
		{
			if (this.mDataModel == null)
			{
				return;
			}
			ActivityInfo bossActivityData = DataManager<ActivityDataManager>.GetInstance().GetBossActivityData(this.mDataModel.Id);
			if (bossActivityData != null)
			{
				this.mDataModel = new BossQuestModel(bossActivityData);
				if (this.mView != null)
				{
					this.mView.UpdateData(this.mDataModel);
				}
			}
		}

		// Token: 0x0600F383 RID: 62339 RVA: 0x0041CFB9 File Offset: 0x0041B3B9
		protected override void _OnItemClick(int taskId, int param, ulong param2)
		{
			DataManager<ActivityDataManager>.GetInstance().SendSubmitBossExchangeTask(taskId);
		}
	}
}
