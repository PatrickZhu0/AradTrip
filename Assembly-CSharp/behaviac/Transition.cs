using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B1 RID: 18609
	public class Transition : StartCondition
	{
		// Token: 0x0601AC16 RID: 109590 RVA: 0x0083B864 File Offset: 0x00839C64
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AC17 RID: 109591 RVA: 0x0083B86F File Offset: 0x00839C6F
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Transition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AC18 RID: 109592 RVA: 0x0083B88B File Offset: 0x00839C8B
		protected override BehaviorTask createTask()
		{
			return null;
		}
	}
}
