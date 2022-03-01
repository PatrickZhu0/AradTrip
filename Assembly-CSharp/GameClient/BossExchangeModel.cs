using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CDC RID: 7388
	public class BossExchangeModel : BossExchangeModelBase
	{
		// Token: 0x06012219 RID: 74265 RVA: 0x0054C7E8 File Offset: 0x0054ABE8
		public BossExchangeModel(ActivityInfo msg) : base(msg)
		{
			if (msg == null)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)msg.id, string.Empty, string.Empty) == null)
			{
				return;
			}
			this.ExchangeTasks = new Dictionary<int, BossExchangeTaskModel>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActiveTable activeTable = keyValuePair.Value as ActiveTable;
				if (activeTable != null && (long)activeTable.TemplateID == (long)((ulong)msg.id))
				{
					this.ExchangeTasks.Add(activeTable.ID, new BossExchangeTaskModel(activeTable));
				}
			}
		}

		// Token: 0x17001E26 RID: 7718
		// (get) Token: 0x0601221A RID: 74266 RVA: 0x0054C8C0 File Offset: 0x0054ACC0
		// (set) Token: 0x0601221B RID: 74267 RVA: 0x0054C8C8 File Offset: 0x0054ACC8
		public Dictionary<int, BossExchangeTaskModel> ExchangeTasks { get; private set; }

		// Token: 0x0601221C RID: 74268 RVA: 0x0054C8D4 File Offset: 0x0054ACD4
		public void UpdateTask(int taskId)
		{
			if (this.ExchangeTasks == null)
			{
				this.ExchangeTasks = new Dictionary<int, BossExchangeTaskModel>();
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			if (table != null && table.ContainsKey(taskId))
			{
				this.ExchangeTasks[taskId] = new BossExchangeTaskModel(table[taskId] as ActiveTable);
			}
		}
	}
}
