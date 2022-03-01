using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004896 RID: 18582
	public class DecoratorFailureUntil : DecoratorCount
	{
		// Token: 0x0601AB7C RID: 109436 RVA: 0x0083AC38 File Offset: 0x00839038
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB7D RID: 109437 RVA: 0x0083AC43 File Offset: 0x00839043
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorFailureUntil && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB7E RID: 109438 RVA: 0x0083AC60 File Offset: 0x00839060
		protected override BehaviorTask createTask()
		{
			return new DecoratorFailureUntil.DecoratorFailureUntilTask();
		}

		// Token: 0x02004897 RID: 18583
		private class DecoratorFailureUntilTask : DecoratorCount.DecoratorCountTask
		{
			// Token: 0x0601AB80 RID: 109440 RVA: 0x0083AC7C File Offset: 0x0083907C
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB81 RID: 109441 RVA: 0x0083AC85 File Offset: 0x00839085
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB82 RID: 109442 RVA: 0x0083AC8E File Offset: 0x0083908E
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB83 RID: 109443 RVA: 0x0083AC97 File Offset: 0x00839097
			public override void onreset(Agent pAgent)
			{
				this.m_n = 0;
			}

			// Token: 0x0601AB84 RID: 109444 RVA: 0x0083ACA0 File Offset: 0x008390A0
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

			// Token: 0x0601AB85 RID: 109445 RVA: 0x0083ACD5 File Offset: 0x008390D5
			protected override EBTStatus decorate(EBTStatus status)
			{
				if (this.m_n > 0)
				{
					this.m_n--;
					if (this.m_n == 0)
					{
						return EBTStatus.BT_SUCCESS;
					}
					return EBTStatus.BT_FAILURE;
				}
				else
				{
					if (this.m_n == -1)
					{
						return EBTStatus.BT_FAILURE;
					}
					return EBTStatus.BT_SUCCESS;
				}
			}
		}
	}
}
