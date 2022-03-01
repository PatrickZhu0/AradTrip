using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CDE RID: 7390
	public class BossQuestModel : BossExchangeModelBase, ILimitTimeActivityModel, ILimitTimeNote
	{
		// Token: 0x0601222C RID: 74284 RVA: 0x0054CB20 File Offset: 0x0054AF20
		public BossQuestModel(ActivityInfo msg) : base(msg)
		{
			this.TaskDatas = new List<ILimitTimeActivityTaskDataModel>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActiveTable activeTable = keyValuePair.Value as ActiveTable;
				if (activeTable != null && (long)activeTable.TemplateID == (long)((ulong)msg.id))
				{
					this.TaskDatas.Add(new BossQuestTaskDataModel(activeTable));
				}
			}
		}

		// Token: 0x17001E2E RID: 7726
		// (get) Token: 0x0601222D RID: 74285 RVA: 0x0054CBC4 File Offset: 0x0054AFC4
		// (set) Token: 0x0601222E RID: 74286 RVA: 0x0054CBCC File Offset: 0x0054AFCC
		public uint[] ParamArray { get; private set; }

		// Token: 0x17001E2F RID: 7727
		// (get) Token: 0x0601222F RID: 74287 RVA: 0x0054CBD5 File Offset: 0x0054AFD5
		// (set) Token: 0x06012230 RID: 74288 RVA: 0x0054CBDD File Offset: 0x0054AFDD
		public uint[] ParamArray2 { get; private set; }

		// Token: 0x17001E30 RID: 7728
		// (get) Token: 0x06012231 RID: 74289 RVA: 0x0054CBE6 File Offset: 0x0054AFE6
		// (set) Token: 0x06012232 RID: 74290 RVA: 0x0054CBEE File Offset: 0x0054AFEE
		public string CountParam { get; private set; }

		// Token: 0x17001E31 RID: 7729
		// (get) Token: 0x06012233 RID: 74291 RVA: 0x0054CBF7 File Offset: 0x0054AFF7
		// (set) Token: 0x06012234 RID: 74292 RVA: 0x0054CBFF File Offset: 0x0054AFFF
		public List<ILimitTimeActivityTaskDataModel> TaskDatas { get; private set; }

		// Token: 0x17001E32 RID: 7730
		// (get) Token: 0x06012235 RID: 74293 RVA: 0x0054CC08 File Offset: 0x0054B008
		// (set) Token: 0x06012236 RID: 74294 RVA: 0x0054CC10 File Offset: 0x0054B010
		public uint Param { get; private set; }

		// Token: 0x17001E33 RID: 7731
		// (get) Token: 0x06012237 RID: 74295 RVA: 0x0054CC19 File Offset: 0x0054B019
		// (set) Token: 0x06012238 RID: 74296 RVA: 0x0054CC21 File Offset: 0x0054B021
		public string ActivityPrefafPath { get; private set; }

		// Token: 0x06012239 RID: 74297 RVA: 0x0054CC2C File Offset: 0x0054B02C
		public void UpdateTask(int taskId)
		{
			if (this.TaskDatas == null)
			{
				this.TaskDatas = new List<ILimitTimeActivityTaskDataModel>();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			if (table != null && table.ContainsKey(taskId))
			{
				for (int i = 0; i < this.TaskDatas.Count; i++)
				{
					if ((ulong)this.TaskDatas[i].DataId == (ulong)((long)taskId))
					{
						this.TaskDatas[i] = new BossQuestTaskDataModel(table[taskId] as ActiveTable);
						break;
					}
				}
			}
		}

		// Token: 0x0601223A RID: 74298 RVA: 0x0054CCC3 File Offset: 0x0054B0C3
		public void SortTaskByState()
		{
		}
	}
}
