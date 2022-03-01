using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CDD RID: 7389
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct BossExchangeTaskModel
	{
		// Token: 0x0601221D RID: 74269 RVA: 0x0054C934 File Offset: 0x0054AD34
		public BossExchangeTaskModel(ActiveTable tableData)
		{
			this = default(BossExchangeTaskModel);
			if (tableData == null)
			{
				return;
			}
			SceneNotifyActiveTaskVar bossTaskData = DataManager<ActivityDataManager>.GetInstance().GetBossTaskData((uint)tableData.ID);
			SceneNotifyActiveTaskStatus bossTaskStatusData = DataManager<ActivityDataManager>.GetInstance().GetBossTaskStatusData((uint)tableData.ID);
			if (bossTaskData == null || bossTaskStatusData == null)
			{
				return;
			}
			string[] array = tableData.ConsumeItems.Split(new char[]
			{
				','
			});
			string[] array2 = tableData.Awards.Split(new char[]
			{
				','
			});
			this.Id = (int)bossTaskData.taskId;
			this.RemainCount = tableData.TaskCycleCount - int.Parse(bossTaskData.val);
			this.Status = (TaskStatus)bossTaskStatusData.status;
			this.TaskCycleCount = tableData.TaskCycleCount;
			this.AccountTotalSubmitLimit = tableData.AccountTotalSubmitLimit;
			this.NeedItems = new Dictionary<int, int>(array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				string[] array3 = array[i].Split(new char[]
				{
					'_'
				});
				this.NeedItems.Add(int.Parse(array3[0]), int.Parse(array3[1]));
			}
			this.ExchangeItems = new Dictionary<int, int>(array2.Length);
			for (int j = 0; j < array2.Length; j++)
			{
				string[] array4 = array2[j].Split(new char[]
				{
					'_'
				});
				this.ExchangeItems.Add(int.Parse(array4[0]), int.Parse(array4[1]));
			}
		}

		// Token: 0x17001E27 RID: 7719
		// (get) Token: 0x0601221E RID: 74270 RVA: 0x0054CAA6 File Offset: 0x0054AEA6
		// (set) Token: 0x0601221F RID: 74271 RVA: 0x0054CAAE File Offset: 0x0054AEAE
		public int Id { get; private set; }

		// Token: 0x17001E28 RID: 7720
		// (get) Token: 0x06012220 RID: 74272 RVA: 0x0054CAB7 File Offset: 0x0054AEB7
		// (set) Token: 0x06012221 RID: 74273 RVA: 0x0054CABF File Offset: 0x0054AEBF
		public Dictionary<int, int> NeedItems { get; private set; }

		// Token: 0x17001E29 RID: 7721
		// (get) Token: 0x06012222 RID: 74274 RVA: 0x0054CAC8 File Offset: 0x0054AEC8
		// (set) Token: 0x06012223 RID: 74275 RVA: 0x0054CAD0 File Offset: 0x0054AED0
		public Dictionary<int, int> ExchangeItems { get; private set; }

		// Token: 0x17001E2A RID: 7722
		// (get) Token: 0x06012224 RID: 74276 RVA: 0x0054CAD9 File Offset: 0x0054AED9
		// (set) Token: 0x06012225 RID: 74277 RVA: 0x0054CAE1 File Offset: 0x0054AEE1
		public int RemainCount { get; private set; }

		// Token: 0x17001E2B RID: 7723
		// (get) Token: 0x06012226 RID: 74278 RVA: 0x0054CAEA File Offset: 0x0054AEEA
		// (set) Token: 0x06012227 RID: 74279 RVA: 0x0054CAF2 File Offset: 0x0054AEF2
		public TaskStatus Status { get; private set; }

		// Token: 0x17001E2C RID: 7724
		// (get) Token: 0x06012228 RID: 74280 RVA: 0x0054CAFB File Offset: 0x0054AEFB
		// (set) Token: 0x06012229 RID: 74281 RVA: 0x0054CB03 File Offset: 0x0054AF03
		public int TaskCycleCount { get; private set; }

		// Token: 0x17001E2D RID: 7725
		// (get) Token: 0x0601222A RID: 74282 RVA: 0x0054CB0C File Offset: 0x0054AF0C
		// (set) Token: 0x0601222B RID: 74283 RVA: 0x0054CB14 File Offset: 0x0054AF14
		public int AccountTotalSubmitLimit { get; private set; }
	}
}
