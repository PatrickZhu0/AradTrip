using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CE7 RID: 7399
	public class LimitTimeActivityModel : LimitTimeActivityModelBase, ILimitTimeActivityModel, ILimitTimeNote
	{
		// Token: 0x060122C3 RID: 74435 RVA: 0x0054D2B4 File Offset: 0x0054B6B4
		public LimitTimeActivityModel(OpActivityData msg, string itemPath, string logoPath = null, string noteBgPath = null, string notePrefabPath = null) : base(msg, itemPath, logoPath, noteBgPath, notePrefabPath)
		{
			if (msg == null)
			{
				return;
			}
			string[] array = msg.taskDesc.Split(new char[]
			{
				'|'
			});
			for (int i = 0; i < msg.tasks.Length; i++)
			{
				OpActTaskData opActTaskData = msg.tasks[i];
				if (opActTaskData != null)
				{
					OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
					string desc = string.Empty;
					if (i < array.Length)
					{
						desc = array[i];
					}
					base.TaskDatas.Add(new LimitTimeActivityTaskDataModel((OpActivityTmpType)msg.tmpType, msg.tasks[i], limitTimeTaskData, desc));
				}
			}
			this.mData = msg;
		}

		// Token: 0x060122C4 RID: 74436 RVA: 0x0054D368 File Offset: 0x0054B768
		public void UpdateTask(int taskId)
		{
			if (this.mData == null)
			{
				return;
			}
			bool flag = false;
			OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData((uint)taskId);
			OpActTaskData taskData = new OpActTaskData();
			for (int i = 0; i < this.mData.tasks.Length; i++)
			{
				if ((ulong)this.mData.tasks[i].dataid == (ulong)((long)taskId))
				{
					taskData = this.mData.tasks[i];
				}
			}
			for (int j = 0; j < base.TaskDatas.Count; j++)
			{
				if ((ulong)base.TaskDatas[j].DataId == (ulong)((long)taskId))
				{
					if (limitTimeTaskData != null)
					{
						base.TaskDatas[j] = new LimitTimeActivityTaskDataModel((OpActivityTmpType)this.mData.tmpType, taskData, limitTimeTaskData, base.TaskDatas[j].Desc);
					}
					else
					{
						base.TaskDatas.RemoveAt(j);
					}
					flag = true;
					break;
				}
			}
			if (!flag && this.mData != null && this.mData.tasks != null)
			{
				string[] array = this.mData.taskDesc.Split(new char[]
				{
					'|'
				});
				for (int k = 0; k < this.mData.tasks.Length; k++)
				{
					if ((ulong)this.mData.tasks[k].dataid == (ulong)((long)taskId))
					{
						string desc = string.Empty;
						if (k < array.Length)
						{
							desc = array[k];
						}
						base.TaskDatas.Add(new LimitTimeActivityTaskDataModel((OpActivityTmpType)this.mData.tmpType, this.mData.tasks[k], limitTimeTaskData, desc));
						break;
					}
				}
			}
			if (this.mIsSortByState)
			{
				base.SortTaskByState();
			}
		}

		// Token: 0x0400BD39 RID: 48441
		private OpActivityData mData;
	}
}
