using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048A8 RID: 18600
	public class DecoratorWeight : DecoratorNode
	{
		// Token: 0x0601ABDB RID: 109531 RVA: 0x005FF55C File Offset: 0x005FD95C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Weight")
				{
					this.m_weight = AgentMeta.ParseProperty(property_t.value, null);
				}
			}
		}

		// Token: 0x0601ABDC RID: 109532 RVA: 0x005FF5BA File Offset: 0x005FD9BA
		protected virtual int GetWeight(Agent pAgent)
		{
			if (this.m_weight != null)
			{
				return ((CInstanceMember<int>)this.m_weight).GetValue(pAgent);
			}
			return 0;
		}

		// Token: 0x0601ABDD RID: 109533 RVA: 0x005FF5DA File Offset: 0x005FD9DA
		public override bool IsManagingChildrenAsSubTrees()
		{
			return false;
		}

		// Token: 0x0601ABDE RID: 109534 RVA: 0x005FF5E0 File Offset: 0x005FD9E0
		protected override BehaviorTask createTask()
		{
			return new DecoratorWeight.DecoratorWeightTask();
		}

		// Token: 0x04012A10 RID: 76304
		protected IInstanceMember m_weight;

		// Token: 0x020048A9 RID: 18601
		public class DecoratorWeightTask : DecoratorTask
		{
			// Token: 0x0601ABE0 RID: 109536 RVA: 0x005FF5FC File Offset: 0x005FD9FC
			public int GetWeight(Agent pAgent)
			{
				DecoratorWeight decoratorWeight = (DecoratorWeight)base.GetNode();
				return (decoratorWeight == null) ? 0 : decoratorWeight.GetWeight(pAgent);
			}

			// Token: 0x0601ABE1 RID: 109537 RVA: 0x005FF628 File Offset: 0x005FDA28
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABE2 RID: 109538 RVA: 0x005FF631 File Offset: 0x005FDA31
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABE3 RID: 109539 RVA: 0x005FF63A File Offset: 0x005FDA3A
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABE4 RID: 109540 RVA: 0x005FF643 File Offset: 0x005FDA43
			protected override EBTStatus decorate(EBTStatus status)
			{
				return status;
			}
		}
	}
}
