using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048A4 RID: 18596
	public class DecoratorSuccessUntil : DecoratorCount
	{
		// Token: 0x0601ABC3 RID: 109507 RVA: 0x0083B2CA File Offset: 0x008396CA
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601ABC4 RID: 109508 RVA: 0x0083B2D5 File Offset: 0x008396D5
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorSuccessUntil && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601ABC5 RID: 109509 RVA: 0x0083B2F4 File Offset: 0x008396F4
		protected override BehaviorTask createTask()
		{
			return new DecoratorSuccessUntil.DecoratorSuccessUntilTask();
		}

		// Token: 0x020048A5 RID: 18597
		private class DecoratorSuccessUntilTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601ABC7 RID: 109511 RVA: 0x0083B310 File Offset: 0x00839710
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABC8 RID: 109512 RVA: 0x0083B319 File Offset: 0x00839719
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABC9 RID: 109513 RVA: 0x0083B322 File Offset: 0x00839722
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABCA RID: 109514 RVA: 0x0083B32B File Offset: 0x0083972B
			public override void onreset(Agent pAgent)
			{
				this.m_n = 0;
			}

			// Token: 0x0601ABCB RID: 109515 RVA: 0x0083B334 File Offset: 0x00839734
			protected override bool onenter(Agent pAgent)
			{
				if (this.m_n == 0)
				{
					int count = base.GetCount(pAgent);
					if (count == 0)
					{
						return false;
					}
					this.m_n = count;
				}
				return true;
			}

			// Token: 0x0601ABCC RID: 109516 RVA: 0x0083B369 File Offset: 0x00839769
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (this.m_n > 0)
				{
					this.m_n--;
					if (this.m_n == 0)
					{
						return EBTStatus.BT_FAILURE;
					}
					return EBTStatus.BT_SUCCESS;
				}
				else
				{
					if (this.m_n == -1)
					{
						return EBTStatus.BT_SUCCESS;
					}
					return EBTStatus.BT_FAILURE;
				}
			}
		}
	}
}
