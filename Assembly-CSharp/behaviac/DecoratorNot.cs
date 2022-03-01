using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048A0 RID: 18592
	public class DecoratorNot : DecoratorNode
	{
		// Token: 0x0601ABAE RID: 109486 RVA: 0x0083B14A File Offset: 0x0083954A
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601ABAF RID: 109487 RVA: 0x0083B155 File Offset: 0x00839555
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorNot && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601ABB0 RID: 109488 RVA: 0x0083B174 File Offset: 0x00839574
		public override bool Evaluate(Agent pAgent)
		{
			bool flag = this.m_children[0].Evaluate(pAgent);
			return !flag;
		}

		// Token: 0x0601ABB1 RID: 109489 RVA: 0x0083B198 File Offset: 0x00839598
		protected override BehaviorTask createTask()
		{
			return new DecoratorNot.DecoratorNotTask();
		}

		// Token: 0x020048A1 RID: 18593
		private class DecoratorNotTask : DecoratorTask
		{
			// Token: 0x0601ABB3 RID: 109491 RVA: 0x0083B1B4 File Offset: 0x008395B4
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABB4 RID: 109492 RVA: 0x0083B1BD File Offset: 0x008395BD
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABB5 RID: 109493 RVA: 0x0083B1C6 File Offset: 0x008395C6
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABB6 RID: 109494 RVA: 0x0083B1CF File Offset: 0x008395CF
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (status == EBTStatus.BT_FAILURE)
				{
					return EBTStatus.BT_SUCCESS;
				}
				if (status == EBTStatus.BT_SUCCESS)
				{
					return EBTStatus.BT_FAILURE;
				}
				return status;
			}
		}
	}
}
