using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CE5 RID: 7397
	public interface ILimitTimeActivityModel : ILimitTimeNote
	{
		// Token: 0x17001E71 RID: 7793
		// (get) Token: 0x0601228C RID: 74380
		uint Id { get; }

		// Token: 0x17001E72 RID: 7794
		// (get) Token: 0x0601228D RID: 74381
		string Desc { get; }

		// Token: 0x17001E73 RID: 7795
		// (get) Token: 0x0601228E RID: 74382
		string ItemPath { get; }

		// Token: 0x17001E74 RID: 7796
		// (get) Token: 0x0601228F RID: 74383
		string ActivityPrefafPath { get; }

		// Token: 0x17001E75 RID: 7797
		// (get) Token: 0x06012290 RID: 74384
		OpActivityState State { get; }

		// Token: 0x17001E76 RID: 7798
		// (get) Token: 0x06012291 RID: 74385
		string Name { get; }

		// Token: 0x17001E77 RID: 7799
		// (get) Token: 0x06012292 RID: 74386
		uint Param { get; }

		// Token: 0x17001E78 RID: 7800
		// (get) Token: 0x06012293 RID: 74387
		uint[] ParamArray { get; }

		// Token: 0x17001E79 RID: 7801
		// (get) Token: 0x06012294 RID: 74388
		uint[] ParamArray2 { get; }

		// Token: 0x17001E7A RID: 7802
		// (get) Token: 0x06012295 RID: 74389
		string CountParam { get; }

		// Token: 0x17001E7B RID: 7803
		// (get) Token: 0x06012296 RID: 74390
		string[] StrParam { get; }

		// Token: 0x17001E7C RID: 7804
		// (get) Token: 0x06012297 RID: 74391
		List<ILimitTimeActivityTaskDataModel> TaskDatas { get; }

		// Token: 0x06012298 RID: 74392
		void UpdateTask(int taskId);

		// Token: 0x06012299 RID: 74393
		void SortTaskByState();
	}
}
