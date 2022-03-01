using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004875 RID: 18549
	public class SelectorProbability : BehaviorNode
	{
		// Token: 0x0601AACE RID: 109262 RVA: 0x005FF2E4 File Offset: 0x005FD6E4
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "RandomGenerator")
				{
					this.m_method = AgentMeta.ParseMethod(property_t.value);
				}
			}
		}

		// Token: 0x0601AACF RID: 109263 RVA: 0x005FF344 File Offset: 0x005FD744
		public override void AddChild(BehaviorNode pBehavior)
		{
			DecoratorWeight decoratorWeight = (DecoratorWeight)pBehavior;
			if (decoratorWeight != null)
			{
				base.AddChild(pBehavior);
			}
		}

		// Token: 0x0601AAD0 RID: 109264 RVA: 0x005FF36A File Offset: 0x005FD76A
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is SelectorProbability && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAD1 RID: 109265 RVA: 0x005FF388 File Offset: 0x005FD788
		protected override BehaviorTask createTask()
		{
			return new SelectorProbability.SelectorProbabilityTask();
		}

		// Token: 0x040129FA RID: 76282
		protected IMethod m_method;

		// Token: 0x02004876 RID: 18550
		private class SelectorProbabilityTask : CompositeTask
		{
			// Token: 0x0601AAD3 RID: 109267 RVA: 0x005FF3AF File Offset: 0x005FD7AF
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AAD4 RID: 109268 RVA: 0x005FF3B8 File Offset: 0x005FD7B8
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AAD5 RID: 109269 RVA: 0x005FF3C1 File Offset: 0x005FD7C1
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AAD6 RID: 109270 RVA: 0x005FF3CC File Offset: 0x005FD7CC
			protected override bool onenter(Agent pAgent)
			{
				this.m_activeChildIndex = -1;
				this.m_weightingMap.Clear();
				this.m_totalSum = 0;
				for (int i = 0; i < this.m_children.Count; i++)
				{
					BehaviorTask behaviorTask = this.m_children[i];
					DecoratorWeight.DecoratorWeightTask decoratorWeightTask = (DecoratorWeight.DecoratorWeightTask)behaviorTask;
					int weight = decoratorWeightTask.GetWeight(pAgent);
					this.m_weightingMap.Add(weight);
					this.m_totalSum += weight;
				}
				return true;
			}

			// Token: 0x0601AAD7 RID: 109271 RVA: 0x005FF445 File Offset: 0x005FD845
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				this.m_activeChildIndex = -1;
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAD8 RID: 109272 RVA: 0x005FF458 File Offset: 0x005FD858
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				SelectorProbability selectorProbability = (SelectorProbability)base.GetNode();
				if (childStatus != EBTStatus.BT_RUNNING)
				{
					return childStatus;
				}
				if (this.m_activeChildIndex != -1)
				{
					BehaviorTask behaviorTask = this.m_children[this.m_activeChildIndex];
					return behaviorTask.exec(pAgent);
				}
				int randomValue = CompositeStochastic.CompositeStochasticTask.GetRandomValue(selectorProbability.m_method, pAgent);
				int num = 0;
				for (int i = 0; i < this.m_children.Count; i++)
				{
					int num2 = this.m_weightingMap[i];
					num += num2;
					if (num2 > 0 && num >= randomValue)
					{
						BehaviorTask behaviorTask2 = this.m_children[i];
						EBTStatus ebtstatus = behaviorTask2.exec(pAgent);
						if (ebtstatus == EBTStatus.BT_RUNNING)
						{
							this.m_activeChildIndex = i;
						}
						else
						{
							this.m_activeChildIndex = -1;
						}
						return ebtstatus;
					}
				}
				return EBTStatus.BT_FAILURE;
			}

			// Token: 0x040129FB RID: 76283
			private List<int> m_weightingMap = new List<int>();

			// Token: 0x040129FC RID: 76284
			private int m_totalSum;
		}
	}
}
