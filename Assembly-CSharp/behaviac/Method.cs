using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B8 RID: 18616
	public class Method : BehaviorNode
	{
		// Token: 0x0601AC44 RID: 109636 RVA: 0x0083C5E8 File Offset: 0x0083A9E8
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Method && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AC45 RID: 109637 RVA: 0x0083C604 File Offset: 0x0083AA04
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x0601AC46 RID: 109638 RVA: 0x0083C607 File Offset: 0x0083AA07
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}
	}
}
