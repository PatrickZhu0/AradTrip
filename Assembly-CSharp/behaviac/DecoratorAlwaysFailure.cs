using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200488C RID: 18572
	public class DecoratorAlwaysFailure : DecoratorNode
	{
		// Token: 0x0601AB4C RID: 109388 RVA: 0x0083AA0A File Offset: 0x00838E0A
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB4D RID: 109389 RVA: 0x0083AA15 File Offset: 0x00838E15
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorAlwaysFailure && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB4E RID: 109390 RVA: 0x0083AA34 File Offset: 0x00838E34
		protected override BehaviorTask createTask()
		{
			return new DecoratorAlwaysFailure.DecoratorAlwaysFailureTask();
		}

		// Token: 0x0200488D RID: 18573
		private class DecoratorAlwaysFailureTask : DecoratorTask
		{
			// Token: 0x0601AB50 RID: 109392 RVA: 0x0083AA50 File Offset: 0x00838E50
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB51 RID: 109393 RVA: 0x0083AA59 File Offset: 0x00838E59
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB52 RID: 109394 RVA: 0x0083AA62 File Offset: 0x00838E62
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB53 RID: 109395 RVA: 0x0083AA6B File Offset: 0x00838E6B
			protected override EBTStatus decorate(EBTStatus status)
			{
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
