using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200489A RID: 18586
	public class DecoratorLog : DecoratorNode
	{
		// Token: 0x0601AB92 RID: 109458 RVA: 0x0083AEF0 File Offset: 0x008392F0
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Log")
				{
					this.m_message = property_t.value;
				}
			}
		}

		// Token: 0x0601AB93 RID: 109459 RVA: 0x0083AF48 File Offset: 0x00839348
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorLog && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB94 RID: 109460 RVA: 0x0083AF64 File Offset: 0x00839364
		protected override BehaviorTask createTask()
		{
			return new DecoratorLog.DecoratorLogTask();
		}

		// Token: 0x04012A08 RID: 76296
		protected string m_message;

		// Token: 0x0200489B RID: 18587
		private class DecoratorLogTask : DecoratorTask
		{
			// Token: 0x0601AB96 RID: 109462 RVA: 0x0083AF80 File Offset: 0x00839380
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB97 RID: 109463 RVA: 0x0083AF89 File Offset: 0x00839389
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB98 RID: 109464 RVA: 0x0083AF92 File Offset: 0x00839392
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB99 RID: 109465 RVA: 0x0083AF9C File Offset: 0x0083939C
			protected override EBTStatus decorate(EBTStatus status)
			{
				DecoratorLog decoratorLog = (DecoratorLog)base.GetNode();
				return status;
			}
		}
	}
}
