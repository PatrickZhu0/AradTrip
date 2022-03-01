using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200488E RID: 18574
	public class DecoratorAlwaysRunning : DecoratorNode
	{
		// Token: 0x0601AB55 RID: 109397 RVA: 0x0083AA76 File Offset: 0x00838E76
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB56 RID: 109398 RVA: 0x0083AA81 File Offset: 0x00838E81
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorAlwaysRunning && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB57 RID: 109399 RVA: 0x0083AAA0 File Offset: 0x00838EA0
		protected override BehaviorTask createTask()
		{
			return new DecoratorAlwaysRunning.DecoratorAlwaysRunningTask();
		}

		// Token: 0x0200488F RID: 18575
		private class DecoratorAlwaysRunningTask : DecoratorTask
		{
			// Token: 0x0601AB59 RID: 109401 RVA: 0x0083AABC File Offset: 0x00838EBC
			protected override void addChild(BehaviorTask pBehavior)
			{
				base.addChild(pBehavior);
			}

			// Token: 0x0601AB5A RID: 109402 RVA: 0x0083AAC5 File Offset: 0x00838EC5
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB5B RID: 109403 RVA: 0x0083AACE File Offset: 0x00838ECE
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB5C RID: 109404 RVA: 0x0083AAD7 File Offset: 0x00838ED7
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB5D RID: 109405 RVA: 0x0083AAE0 File Offset: 0x00838EE0
			protected override EBTStatus decorate(EBTStatus status)
			{
				return EBTStatus.BT_RUNNING;
			}
		}
	}
}
