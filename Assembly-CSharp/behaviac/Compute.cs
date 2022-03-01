using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004859 RID: 18521
	public class Compute : BehaviorNode
	{
		// Token: 0x0601AA3A RID: 109114 RVA: 0x0068D690 File Offset: 0x0068BA90
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Opl")
				{
					this.m_opl = AgentMeta.ParseProperty(property_t.value, null);
				}
				else if (property_t.name == "Operator")
				{
					this.m_operator = OperationUtils.ParseOperatorType(property_t.value);
				}
				else if (property_t.name == "Opr1")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_opr1 = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_opr1 = AgentMeta.ParseMethod(property_t.value);
					}
				}
				else if (property_t.name == "Opr2")
				{
					int num2 = property_t.value.IndexOf('(');
					if (num2 == -1)
					{
						this.m_opr2 = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_opr2 = AgentMeta.ParseMethod(property_t.value);
					}
				}
			}
		}

		// Token: 0x0601AA3B RID: 109115 RVA: 0x0068D7D1 File Offset: 0x0068BBD1
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Compute && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA3C RID: 109116 RVA: 0x0068D7ED File Offset: 0x0068BBED
		protected override BehaviorTask createTask()
		{
			return new Compute.ComputeTask();
		}

		// Token: 0x040129D2 RID: 76242
		protected IInstanceMember m_opl;

		// Token: 0x040129D3 RID: 76243
		protected IInstanceMember m_opr1;

		// Token: 0x040129D4 RID: 76244
		protected IInstanceMember m_opr2;

		// Token: 0x040129D5 RID: 76245
		protected EOperatorType m_operator;

		// Token: 0x0200485A RID: 18522
		private class ComputeTask : LeafTask
		{
			// Token: 0x0601AA3E RID: 109118 RVA: 0x0068D7FC File Offset: 0x0068BBFC
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AA3F RID: 109119 RVA: 0x0068D805 File Offset: 0x0068BC05
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AA40 RID: 109120 RVA: 0x0068D80E File Offset: 0x0068BC0E
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA41 RID: 109121 RVA: 0x0068D817 File Offset: 0x0068BC17
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA42 RID: 109122 RVA: 0x0068D81A File Offset: 0x0068BC1A
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA43 RID: 109123 RVA: 0x0068D81C File Offset: 0x0068BC1C
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				EBTStatus result = EBTStatus.BT_SUCCESS;
				Compute compute = (Compute)base.GetNode();
				if (compute.m_opl != null)
				{
					compute.m_opl.Compute(pAgent, compute.m_opr1, compute.m_opr2, compute.m_operator);
				}
				else
				{
					result = compute.update_impl(pAgent, childStatus);
				}
				return result;
			}
		}
	}
}
