using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CE8 RID: 7400
	public interface ILimitTimeActivityTaskDataModel
	{
		// Token: 0x17001E90 RID: 7824
		// (get) Token: 0x060122C5 RID: 74437
		uint DataId { get; }

		// Token: 0x17001E91 RID: 7825
		// (get) Token: 0x060122C6 RID: 74438
		OpActTaskState State { get; }

		// Token: 0x17001E92 RID: 7826
		// (get) Token: 0x060122C7 RID: 74439
		string Desc { get; }

		// Token: 0x17001E93 RID: 7827
		// (get) Token: 0x060122C8 RID: 74440
		uint DoneNum { get; }

		// Token: 0x17001E94 RID: 7828
		// (get) Token: 0x060122C9 RID: 74441
		uint TotalNum { get; }

		// Token: 0x17001E95 RID: 7829
		// (get) Token: 0x060122CA RID: 74442
		List<uint> ParamNums { get; }

		// Token: 0x17001E96 RID: 7830
		// (get) Token: 0x060122CB RID: 74443
		List<uint> ParamNums2 { get; }

		// Token: 0x17001E97 RID: 7831
		// (get) Token: 0x060122CC RID: 74444
		List<CounterItem> CountParamNums { get; }

		// Token: 0x17001E98 RID: 7832
		// (get) Token: 0x060122CD RID: 74445
		List<OpTaskReward> AwardDataList { get; }

		// Token: 0x17001E99 RID: 7833
		// (get) Token: 0x060122CE RID: 74446
		string taskName { get; }

		// Token: 0x17001E9A RID: 7834
		// (get) Token: 0x060122CF RID: 74447
		List<string> ParamProgress { get; }

		// Token: 0x17001E9B RID: 7835
		// (get) Token: 0x060122D0 RID: 74448
		List<OpActTaskParam> ParamProgressList { get; }

		// Token: 0x17001E9C RID: 7836
		// (get) Token: 0x060122D1 RID: 74449
		ushort PlayerLevelLimit { get; }

		// Token: 0x17001E9D RID: 7837
		// (get) Token: 0x060122D2 RID: 74450
		int AccountDailySubmitLimit { get; }

		// Token: 0x17001E9E RID: 7838
		// (get) Token: 0x060122D3 RID: 74451
		int AccountTotalSubmitLimit { get; }

		// Token: 0x17001E9F RID: 7839
		// (get) Token: 0x060122D4 RID: 74452
		int AccountWeeklySubmitLimit { get; }

		// Token: 0x17001EA0 RID: 7840
		// (get) Token: 0x060122D5 RID: 74453
		int CantAccept { get; }

		// Token: 0x17001EA1 RID: 7841
		// (get) Token: 0x060122D6 RID: 74454
		int EventType { get; }

		// Token: 0x17001EA2 RID: 7842
		// (get) Token: 0x060122D7 RID: 74455
		int SubType { get; }
	}
}
