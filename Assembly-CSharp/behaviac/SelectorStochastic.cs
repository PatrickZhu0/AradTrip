using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004877 RID: 18551
	public class SelectorStochastic : CompositeStochastic
	{
		// Token: 0x0601AADA RID: 109274 RVA: 0x0083A177 File Offset: 0x00838577
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AADB RID: 109275 RVA: 0x0083A182 File Offset: 0x00838582
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is SelectorStochastic && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AADC RID: 109276 RVA: 0x0083A1A0 File Offset: 0x008385A0
		protected override BehaviorTask createTask()
		{
			return new SelectorStochastic.SelectorStochasticTask();
		}

		// Token: 0x02004878 RID: 18552
		private class SelectorStochasticTask : CompositeStochastic.CompositeStochasticTask
		{
			// Token: 0x0601AADE RID: 109278 RVA: 0x0083A1BC File Offset: 0x008385BC
			protected override void addChild(BehaviorTask pBehavior)
			{
				base.addChild(pBehavior);
			}

			// Token: 0x0601AADF RID: 109279 RVA: 0x0083A1C5 File Offset: 0x008385C5
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AAE0 RID: 109280 RVA: 0x0083A1CE File Offset: 0x008385CE
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AAE1 RID: 109281 RVA: 0x0083A1D7 File Offset: 0x008385D7
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AAE2 RID: 109282 RVA: 0x0083A1E0 File Offset: 0x008385E0
			protected override bool onenter(Agent pAgent)
			{
				base.onenter(pAgent);
				return true;
			}

			// Token: 0x0601AAE3 RID: 109283 RVA: 0x0083A1EB File Offset: 0x008385EB
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAE4 RID: 109284 RVA: 0x0083A200 File Offset: 0x00838600
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				EBTStatus ebtstatus = childStatus;
				SelectorStochastic selectorStochastic = this.m_node as SelectorStochastic;
				for (;;)
				{
					if (ebtstatus == EBTStatus.BT_RUNNING)
					{
						int index = this.m_set[this.m_activeChildIndex];
						BehaviorTask behaviorTask = this.m_children[index];
						if (selectorStochastic.CheckIfInterrupted(pAgent))
						{
							break;
						}
						ebtstatus = behaviorTask.exec(pAgent);
					}
					if (ebtstatus != EBTStatus.BT_FAILURE)
					{
						return ebtstatus;
					}
					this.m_activeChildIndex++;
					if (this.m_activeChildIndex >= this.m_children.Count)
					{
						return EBTStatus.BT_FAILURE;
					}
					ebtstatus = EBTStatus.BT_RUNNING;
				}
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
