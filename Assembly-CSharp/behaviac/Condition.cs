using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004881 RID: 18561
	public class Condition : ConditionBase
	{
		// Token: 0x0601AB19 RID: 109337 RVA: 0x0054F94C File Offset: 0x0054DD4C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Opl")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_opl = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_opl = AgentMeta.ParseMethod(property_t.value);
					}
				}
				else if (property_t.name == "Operator")
				{
					this.m_operator = OperationUtils.ParseOperatorType(property_t.value);
				}
				else if (property_t.name == "Opr")
				{
					int num2 = property_t.value.IndexOf('(');
					if (num2 == -1)
					{
						this.m_opr = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_opr = AgentMeta.ParseMethod(property_t.value);
					}
				}
			}
		}

		// Token: 0x0601AB1A RID: 109338 RVA: 0x0054FA5F File Offset: 0x0054DE5F
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Condition && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB1B RID: 109339 RVA: 0x0054FA7C File Offset: 0x0054DE7C
		public override bool Evaluate(Agent pAgent)
		{
			if (this.m_opl != null && this.m_opr != null)
			{
				return this.m_opl.Compare(pAgent, this.m_opr, this.m_operator);
			}
			EBTStatus childStatus = EBTStatus.BT_INVALID;
			EBTStatus ebtstatus = this.update_impl(pAgent, childStatus);
			return ebtstatus == EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0601AB1C RID: 109340 RVA: 0x0054FAC8 File Offset: 0x0054DEC8
		protected override BehaviorTask createTask()
		{
			return new Condition.ConditionTask();
		}

		// Token: 0x040129FD RID: 76285
		protected IInstanceMember m_opl;

		// Token: 0x040129FE RID: 76286
		protected IInstanceMember m_opr;

		// Token: 0x040129FF RID: 76287
		protected EOperatorType m_operator = EOperatorType.E_EQUAL;

		// Token: 0x02004882 RID: 18562
		private class ConditionTask : ConditionBaseTask
		{
			// Token: 0x0601AB1E RID: 109342 RVA: 0x005501AD File Offset: 0x0054E5AD
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AB1F RID: 109343 RVA: 0x005501B6 File Offset: 0x0054E5B6
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AB20 RID: 109344 RVA: 0x005501BF File Offset: 0x0054E5BF
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AB21 RID: 109345 RVA: 0x005501C8 File Offset: 0x0054E5C8
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AB22 RID: 109346 RVA: 0x005501CB File Offset: 0x0054E5CB
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AB23 RID: 109347 RVA: 0x005501D0 File Offset: 0x0054E5D0
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Condition condition = (Condition)base.GetNode();
				bool flag = condition.Evaluate(pAgent);
				return (!flag) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
			}
		}
	}
}
