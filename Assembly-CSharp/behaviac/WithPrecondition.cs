using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200487D RID: 18557
	public class WithPrecondition : BehaviorNode
	{
		// Token: 0x0601AB00 RID: 109312 RVA: 0x0083A50D File Offset: 0x0083890D
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB01 RID: 109313 RVA: 0x0083A518 File Offset: 0x00838918
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is WithPrecondition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB02 RID: 109314 RVA: 0x0083A534 File Offset: 0x00838934
		protected override BehaviorTask createTask()
		{
			return new WithPreconditionTask();
		}
	}
}
