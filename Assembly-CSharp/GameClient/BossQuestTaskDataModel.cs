using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CDF RID: 7391
	public class BossQuestTaskDataModel : ILimitTimeActivityTaskDataModel
	{
		// Token: 0x0601223B RID: 74299 RVA: 0x0054CCC8 File Offset: 0x0054B0C8
		public BossQuestTaskDataModel(ActiveTable tableData)
		{
			this.DataId = (uint)tableData.ID;
			SceneNotifyActiveTaskStatus bossTaskStatusData = DataManager<ActivityDataManager>.GetInstance().GetBossTaskStatusData(this.DataId);
			if (bossTaskStatusData == null)
			{
				return;
			}
			switch (bossTaskStatusData.status)
			{
			case 0:
				this.State = OpActTaskState.OATS_INIT;
				break;
			case 1:
				this.State = OpActTaskState.OATS_UNFINISH;
				break;
			case 2:
				this.State = OpActTaskState.OATS_FINISHED;
				break;
			case 3:
				this.State = OpActTaskState.OATS_FAILED;
				break;
			case 4:
				this.State = OpActTaskState.OATS_SUBMITTING;
				break;
			case 5:
				this.State = OpActTaskState.OATS_OVER;
				break;
			}
			this.Desc = string.Format(TR.Value("activity_charge_rebate_task_desc"), tableData.Param1);
			string[] array = tableData.Awards.Split(new char[]
			{
				','
			});
			this.AwardDataList = new List<OpTaskReward>();
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				OpTaskReward item = new OpTaskReward
				{
					id = uint.Parse(array2[0]),
					num = uint.Parse(array2[1])
				};
				this.AwardDataList.Add(item);
			}
		}

		// Token: 0x17001E34 RID: 7732
		// (get) Token: 0x0601223C RID: 74300 RVA: 0x0054CE14 File Offset: 0x0054B214
		// (set) Token: 0x0601223D RID: 74301 RVA: 0x0054CE1C File Offset: 0x0054B21C
		public uint DataId { get; private set; }

		// Token: 0x17001E35 RID: 7733
		// (get) Token: 0x0601223E RID: 74302 RVA: 0x0054CE25 File Offset: 0x0054B225
		// (set) Token: 0x0601223F RID: 74303 RVA: 0x0054CE2D File Offset: 0x0054B22D
		public OpActTaskState State { get; private set; }

		// Token: 0x17001E36 RID: 7734
		// (get) Token: 0x06012240 RID: 74304 RVA: 0x0054CE36 File Offset: 0x0054B236
		// (set) Token: 0x06012241 RID: 74305 RVA: 0x0054CE3E File Offset: 0x0054B23E
		public string Desc { get; private set; }

		// Token: 0x17001E37 RID: 7735
		// (get) Token: 0x06012242 RID: 74306 RVA: 0x0054CE47 File Offset: 0x0054B247
		// (set) Token: 0x06012243 RID: 74307 RVA: 0x0054CE4F File Offset: 0x0054B24F
		public uint DoneNum { get; private set; }

		// Token: 0x17001E38 RID: 7736
		// (get) Token: 0x06012244 RID: 74308 RVA: 0x0054CE58 File Offset: 0x0054B258
		// (set) Token: 0x06012245 RID: 74309 RVA: 0x0054CE60 File Offset: 0x0054B260
		public uint TotalNum { get; private set; }

		// Token: 0x17001E39 RID: 7737
		// (get) Token: 0x06012246 RID: 74310 RVA: 0x0054CE69 File Offset: 0x0054B269
		// (set) Token: 0x06012247 RID: 74311 RVA: 0x0054CE71 File Offset: 0x0054B271
		public List<uint> ParamNums { get; private set; }

		// Token: 0x17001E3A RID: 7738
		// (get) Token: 0x06012248 RID: 74312 RVA: 0x0054CE7A File Offset: 0x0054B27A
		// (set) Token: 0x06012249 RID: 74313 RVA: 0x0054CE82 File Offset: 0x0054B282
		public List<uint> ParamNums2 { get; private set; }

		// Token: 0x17001E3B RID: 7739
		// (get) Token: 0x0601224A RID: 74314 RVA: 0x0054CE8B File Offset: 0x0054B28B
		// (set) Token: 0x0601224B RID: 74315 RVA: 0x0054CE93 File Offset: 0x0054B293
		public List<CounterItem> CountParamNums { get; private set; }

		// Token: 0x17001E3C RID: 7740
		// (get) Token: 0x0601224C RID: 74316 RVA: 0x0054CE9C File Offset: 0x0054B29C
		// (set) Token: 0x0601224D RID: 74317 RVA: 0x0054CEA4 File Offset: 0x0054B2A4
		public List<OpTaskReward> AwardDataList { get; private set; }

		// Token: 0x17001E3D RID: 7741
		// (get) Token: 0x0601224E RID: 74318 RVA: 0x0054CEAD File Offset: 0x0054B2AD
		// (set) Token: 0x0601224F RID: 74319 RVA: 0x0054CEB5 File Offset: 0x0054B2B5
		public string taskName { get; private set; }

		// Token: 0x17001E3E RID: 7742
		// (get) Token: 0x06012250 RID: 74320 RVA: 0x0054CEBE File Offset: 0x0054B2BE
		// (set) Token: 0x06012251 RID: 74321 RVA: 0x0054CEC6 File Offset: 0x0054B2C6
		public List<string> ParamProgress { get; private set; }

		// Token: 0x17001E3F RID: 7743
		// (get) Token: 0x06012252 RID: 74322 RVA: 0x0054CECF File Offset: 0x0054B2CF
		// (set) Token: 0x06012253 RID: 74323 RVA: 0x0054CED7 File Offset: 0x0054B2D7
		public List<OpActTaskParam> ParamProgressList { get; private set; }

		// Token: 0x17001E40 RID: 7744
		// (get) Token: 0x06012254 RID: 74324 RVA: 0x0054CEE0 File Offset: 0x0054B2E0
		// (set) Token: 0x06012255 RID: 74325 RVA: 0x0054CEE8 File Offset: 0x0054B2E8
		public ushort PlayerLevelLimit { get; private set; }

		// Token: 0x17001E41 RID: 7745
		// (get) Token: 0x06012256 RID: 74326 RVA: 0x0054CEF1 File Offset: 0x0054B2F1
		// (set) Token: 0x06012257 RID: 74327 RVA: 0x0054CEF9 File Offset: 0x0054B2F9
		public int AccountDailySubmitLimit { get; private set; }

		// Token: 0x17001E42 RID: 7746
		// (get) Token: 0x06012258 RID: 74328 RVA: 0x0054CF02 File Offset: 0x0054B302
		// (set) Token: 0x06012259 RID: 74329 RVA: 0x0054CF0A File Offset: 0x0054B30A
		public int AccountTotalSubmitLimit { get; private set; }

		// Token: 0x17001E43 RID: 7747
		// (get) Token: 0x0601225A RID: 74330 RVA: 0x0054CF13 File Offset: 0x0054B313
		// (set) Token: 0x0601225B RID: 74331 RVA: 0x0054CF1B File Offset: 0x0054B31B
		public int AccountWeeklySubmitLimit { get; private set; }

		// Token: 0x17001E44 RID: 7748
		// (get) Token: 0x0601225C RID: 74332 RVA: 0x0054CF24 File Offset: 0x0054B324
		// (set) Token: 0x0601225D RID: 74333 RVA: 0x0054CF2C File Offset: 0x0054B32C
		public int CantAccept { get; private set; }

		// Token: 0x17001E45 RID: 7749
		// (get) Token: 0x0601225E RID: 74334 RVA: 0x0054CF35 File Offset: 0x0054B335
		// (set) Token: 0x0601225F RID: 74335 RVA: 0x0054CF3D File Offset: 0x0054B33D
		public int EventType { get; private set; }

		// Token: 0x17001E46 RID: 7750
		// (get) Token: 0x06012260 RID: 74336 RVA: 0x0054CF46 File Offset: 0x0054B346
		// (set) Token: 0x06012261 RID: 74337 RVA: 0x0054CF4E File Offset: 0x0054B34E
		public int SubType { get; private set; }
	}
}
