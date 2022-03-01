using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B4 RID: 18612
	internal class WaitTransition : Transition
	{
		// Token: 0x0601AC28 RID: 109608 RVA: 0x0083C1F3 File Offset: 0x0083A5F3
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AC29 RID: 109609 RVA: 0x0083C1FE File Offset: 0x0083A5FE
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is WaitTransition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AC2A RID: 109610 RVA: 0x0083C21A File Offset: 0x0083A61A
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x0601AC2B RID: 109611 RVA: 0x0083C21D File Offset: 0x0083A61D
		public override bool Evaluate(Agent pAgent, EBTStatus status)
		{
			return true;
		}
	}
}
