using System;

namespace GameClient
{
	// Token: 0x020011A7 RID: 4519
	public class LimitTimeActivityTaskUpdateData
	{
		// Token: 0x0600AD59 RID: 44377 RVA: 0x0025B5B0 File Offset: 0x002599B0
		public LimitTimeActivityTaskUpdateData(int activityId, int taskId)
		{
			this.ActivityId = activityId;
			this.TaskId = taskId;
		}

		// Token: 0x17001A72 RID: 6770
		// (get) Token: 0x0600AD5A RID: 44378 RVA: 0x0025B5C6 File Offset: 0x002599C6
		// (set) Token: 0x0600AD5B RID: 44379 RVA: 0x0025B5CE File Offset: 0x002599CE
		public int ActivityId { get; private set; }

		// Token: 0x17001A73 RID: 6771
		// (get) Token: 0x0600AD5C RID: 44380 RVA: 0x0025B5D7 File Offset: 0x002599D7
		// (set) Token: 0x0600AD5D RID: 44381 RVA: 0x0025B5DF File Offset: 0x002599DF
		public int TaskId { get; private set; }
	}
}
