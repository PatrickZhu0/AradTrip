using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CEE RID: 7406
	public sealed class LevelFightShowActivityDataModel : LimitTimeActivityModelBase, ILimitTimeActivityModel, ILimitTimeNote
	{
		// Token: 0x06012306 RID: 74502 RVA: 0x0054DAB0 File Offset: 0x0054BEB0
		public LevelFightShowActivityDataModel(OpActivityData msg, string itemPath, BaseSortList records, string logoPath = null, string noteBgPath = null, string notePrefabPath = null) : base(msg, itemPath, logoPath, noteBgPath, notePrefabPath)
		{
			if (msg != null && msg.tasks != null)
			{
				string[] array = msg.taskDesc.Split(new char[]
				{
					'|'
				});
				for (int i = 0; i < msg.tasks.Length; i++)
				{
					string desc = string.Empty;
					if (i < array.Length)
					{
						desc = array[i];
					}
					base.TaskDatas.Add(new LevelFightActivityRankDataModel((OpActivityTmpType)msg.tmpType, msg.tasks[i], null, desc, string.Empty, 0U));
				}
			}
		}

		// Token: 0x06012307 RID: 74503 RVA: 0x0054DB45 File Offset: 0x0054BF45
		public void UpdateTask(int taskId)
		{
		}

		// Token: 0x06012308 RID: 74504 RVA: 0x0054DB48 File Offset: 0x0054BF48
		public void UpdateRecords(BaseSortList records)
		{
			if (base.TaskDatas == null)
			{
				return;
			}
			for (int i = 0; i < records.entries.Count; i++)
			{
				if (i >= base.TaskDatas.Count)
				{
					return;
				}
				((LevelFightActivityRankDataModel)base.TaskDatas[i]).UpdateData(records.entries[i].name, (uint)records.entries[i].ranking);
			}
		}
	}
}
