using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200487F RID: 18559
	public class And : ConditionBase
	{
		// Token: 0x0601AB0F RID: 109327 RVA: 0x0083A5E5 File Offset: 0x008389E5
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB10 RID: 109328 RVA: 0x0083A5F0 File Offset: 0x008389F0
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is And && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB11 RID: 109329 RVA: 0x0083A60C File Offset: 0x00838A0C
		public override bool Evaluate(Agent pAgent)
		{
			bool flag = true;
			for (int i = 0; i < this.m_children.Count; i++)
			{
				BehaviorNode behaviorNode = this.m_children[i];
				flag = behaviorNode.Evaluate(pAgent);
				if (!flag)
				{
					break;
				}
			}
			return flag;
		}

		// Token: 0x0601AB12 RID: 109330 RVA: 0x0083A658 File Offset: 0x00838A58
		protected override BehaviorTask createTask()
		{
			return new AndTask();
		}
	}
}
