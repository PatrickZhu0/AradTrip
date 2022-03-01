using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004871 RID: 18545
	public class Selector : BehaviorNode
	{
		// Token: 0x0601AAB2 RID: 109234 RVA: 0x00839D27 File Offset: 0x00838127
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AAB3 RID: 109235 RVA: 0x00839D32 File Offset: 0x00838132
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Selector && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAB4 RID: 109236 RVA: 0x00839D50 File Offset: 0x00838150
		public override bool Evaluate(Agent pAgent)
		{
			bool flag = true;
			for (int i = 0; i < this.m_children.Count; i++)
			{
				BehaviorNode behaviorNode = this.m_children[i];
				flag = behaviorNode.Evaluate(pAgent);
				if (flag)
				{
					break;
				}
			}
			return flag;
		}

		// Token: 0x0601AAB5 RID: 109237 RVA: 0x00839D9C File Offset: 0x0083819C
		public EBTStatus SelectorUpdate(Agent pAgent, EBTStatus childStatus, ref int activeChildIndex, List<BehaviorTask> children)
		{
			EBTStatus ebtstatus = childStatus;
			for (;;)
			{
				if (ebtstatus == EBTStatus.BT_RUNNING)
				{
					BehaviorTask behaviorTask = children[activeChildIndex];
					if (this.CheckIfInterrupted(pAgent))
					{
						break;
					}
					ebtstatus = behaviorTask.exec(pAgent);
				}
				if (ebtstatus != EBTStatus.BT_FAILURE)
				{
					return ebtstatus;
				}
				activeChildIndex++;
				if (activeChildIndex >= children.Count)
				{
					return EBTStatus.BT_FAILURE;
				}
				ebtstatus = EBTStatus.BT_RUNNING;
			}
			return EBTStatus.BT_FAILURE;
		}

		// Token: 0x0601AAB6 RID: 109238 RVA: 0x00839DFC File Offset: 0x008381FC
		public bool CheckIfInterrupted(Agent pAgent)
		{
			return base.EvaluteCustomCondition(pAgent);
		}

		// Token: 0x0601AAB7 RID: 109239 RVA: 0x00839E14 File Offset: 0x00838214
		protected override BehaviorTask createTask()
		{
			return new Selector.SelectorTask();
		}

		// Token: 0x02004872 RID: 18546
		public class SelectorTask : CompositeTask
		{
			// Token: 0x0601AAB9 RID: 109241 RVA: 0x00839E30 File Offset: 0x00838230
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AABA RID: 109242 RVA: 0x00839E39 File Offset: 0x00838239
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AABB RID: 109243 RVA: 0x00839E42 File Offset: 0x00838242
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AABC RID: 109244 RVA: 0x00839E4B File Offset: 0x0083824B
			protected override bool onenter(Agent pAgent)
			{
				this.m_activeChildIndex = 0;
				return true;
			}

			// Token: 0x0601AABD RID: 109245 RVA: 0x00839E55 File Offset: 0x00838255
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AABE RID: 109246 RVA: 0x00839E60 File Offset: 0x00838260
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Selector selector = this.m_node as Selector;
				return selector.SelectorUpdate(pAgent, childStatus, ref this.m_activeChildIndex, this.m_children);
			}
		}
	}
}
