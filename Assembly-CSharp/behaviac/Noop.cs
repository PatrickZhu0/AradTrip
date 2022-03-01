using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200485D RID: 18525
	public class Noop : BehaviorNode
	{
		// Token: 0x0601AA50 RID: 109136 RVA: 0x00838F13 File Offset: 0x00837313
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AA51 RID: 109137 RVA: 0x00838F1E File Offset: 0x0083731E
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Noop;
		}

		// Token: 0x0601AA52 RID: 109138 RVA: 0x00838F34 File Offset: 0x00837334
		protected override BehaviorTask createTask()
		{
			return new Noop.NoopTask();
		}

		// Token: 0x0200485E RID: 18526
		private class NoopTask : LeafTask
		{
			// Token: 0x0601AA54 RID: 109140 RVA: 0x00838F50 File Offset: 0x00837350
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AA55 RID: 109141 RVA: 0x00838F59 File Offset: 0x00837359
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AA56 RID: 109142 RVA: 0x00838F62 File Offset: 0x00837362
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA57 RID: 109143 RVA: 0x00838F6B File Offset: 0x0083736B
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA58 RID: 109144 RVA: 0x00838F6E File Offset: 0x0083736E
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA59 RID: 109145 RVA: 0x00838F70 File Offset: 0x00837370
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				return EBTStatus.BT_SUCCESS;
			}
		}
	}
}
