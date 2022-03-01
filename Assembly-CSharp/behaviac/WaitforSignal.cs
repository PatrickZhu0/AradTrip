using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004861 RID: 18529
	public class WaitforSignal : BehaviorNode
	{
		// Token: 0x0601AA69 RID: 109161 RVA: 0x0083930F File Offset: 0x0083770F
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AA6A RID: 109162 RVA: 0x0083931A File Offset: 0x0083771A
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is WaitforSignal && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA6B RID: 109163 RVA: 0x00839338 File Offset: 0x00837738
		public bool CheckIfSignaled(Agent pAgent)
		{
			return base.EvaluteCustomCondition(pAgent);
		}

		// Token: 0x0601AA6C RID: 109164 RVA: 0x00839350 File Offset: 0x00837750
		protected override BehaviorTask createTask()
		{
			return new WaitforSignalTask();
		}
	}
}
