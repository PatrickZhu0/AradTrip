using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200487B RID: 18555
	public class SequenceStochastic : CompositeStochastic
	{
		// Token: 0x0601AAF4 RID: 109300 RVA: 0x0083A3F5 File Offset: 0x008387F5
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AAF5 RID: 109301 RVA: 0x0083A400 File Offset: 0x00838800
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is SequenceStochastic && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAF6 RID: 109302 RVA: 0x0083A41C File Offset: 0x0083881C
		protected override BehaviorTask createTask()
		{
			return new SequenceStochastic.SequenceStochasticTask();
		}

		// Token: 0x0200487C RID: 18556
		private class SequenceStochasticTask : CompositeStochastic.CompositeStochasticTask
		{
			// Token: 0x0601AAF8 RID: 109304 RVA: 0x0083A438 File Offset: 0x00838838
			protected override void addChild(BehaviorTask pBehavior)
			{
				base.addChild(pBehavior);
			}

			// Token: 0x0601AAF9 RID: 109305 RVA: 0x0083A441 File Offset: 0x00838841
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AAFA RID: 109306 RVA: 0x0083A44A File Offset: 0x0083884A
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AAFB RID: 109307 RVA: 0x0083A453 File Offset: 0x00838853
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AAFC RID: 109308 RVA: 0x0083A45C File Offset: 0x0083885C
			protected override bool onenter(Agent pAgent)
			{
				base.onenter(pAgent);
				return true;
			}

			// Token: 0x0601AAFD RID: 109309 RVA: 0x0083A467 File Offset: 0x00838867
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAFE RID: 109310 RVA: 0x0083A474 File Offset: 0x00838874
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				SequenceStochastic sequenceStochastic = this.m_node as SequenceStochastic;
				EBTStatus ebtstatus = childStatus;
				for (;;)
				{
					if (ebtstatus == EBTStatus.BT_RUNNING)
					{
						int index = this.m_set[this.m_activeChildIndex];
						BehaviorTask behaviorTask = this.m_children[index];
						if (sequenceStochastic.CheckIfInterrupted(pAgent))
						{
							break;
						}
						ebtstatus = behaviorTask.exec(pAgent);
					}
					if (ebtstatus != EBTStatus.BT_SUCCESS)
					{
						return ebtstatus;
					}
					this.m_activeChildIndex++;
					if (this.m_activeChildIndex >= this.m_children.Count)
					{
						return EBTStatus.BT_SUCCESS;
					}
					ebtstatus = childStatus;
				}
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
