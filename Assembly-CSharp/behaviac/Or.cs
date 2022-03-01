using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004887 RID: 18567
	public class Or : ConditionBase
	{
		// Token: 0x0601AB34 RID: 109364 RVA: 0x0083A74A File Offset: 0x00838B4A
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AB35 RID: 109365 RVA: 0x0083A755 File Offset: 0x00838B55
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Or && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB36 RID: 109366 RVA: 0x0083A774 File Offset: 0x00838B74
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

		// Token: 0x0601AB37 RID: 109367 RVA: 0x0083A7C0 File Offset: 0x00838BC0
		protected override BehaviorTask createTask()
		{
			return new Or.OrTask();
		}

		// Token: 0x02004888 RID: 18568
		private class OrTask : Selector.SelectorTask
		{
			// Token: 0x0601AB39 RID: 109369 RVA: 0x0083A7DC File Offset: 0x00838BDC
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB3A RID: 109370 RVA: 0x0083A7E5 File Offset: 0x00838BE5
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB3B RID: 109371 RVA: 0x0083A7EE File Offset: 0x00838BEE
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB3C RID: 109372 RVA: 0x0083A7F8 File Offset: 0x00838BF8
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				for (int i = 0; i < this.m_children.Count; i++)
				{
					BehaviorTask behaviorTask = this.m_children[i];
					EBTStatus ebtstatus = behaviorTask.exec(pAgent);
					if (ebtstatus == EBTStatus.BT_SUCCESS)
					{
						return ebtstatus;
					}
				}
				return EBTStatus.BT_FAILURE;
			}
		}
	}
}
