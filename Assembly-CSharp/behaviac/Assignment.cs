using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004857 RID: 18519
	public class Assignment : BehaviorNode
	{
		// Token: 0x0601AA2F RID: 109103 RVA: 0x005FAE30 File Offset: 0x005F9230
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "CastRight")
				{
					this.m_bCast = (property_t.value == "true");
				}
				else if (property_t.name == "Opl")
				{
					this.m_opl = AgentMeta.ParseProperty(property_t.value, null);
				}
				else if (property_t.name == "Opr")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
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

		// Token: 0x0601AA30 RID: 109104 RVA: 0x005FAF1B File Offset: 0x005F931B
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Assignment && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA31 RID: 109105 RVA: 0x005FAF37 File Offset: 0x005F9337
		protected override BehaviorTask createTask()
		{
			return new Assignment.AssignmentTask();
		}

		// Token: 0x040129CF RID: 76239
		protected IInstanceMember m_opl;

		// Token: 0x040129D0 RID: 76240
		protected IInstanceMember m_opr;

		// Token: 0x040129D1 RID: 76241
		protected bool m_bCast;

		// Token: 0x02004858 RID: 18520
		private class AssignmentTask : LeafTask
		{
			// Token: 0x0601AA33 RID: 109107 RVA: 0x005FAF46 File Offset: 0x005F9346
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AA34 RID: 109108 RVA: 0x005FAF4F File Offset: 0x005F934F
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AA35 RID: 109109 RVA: 0x005FAF58 File Offset: 0x005F9358
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA36 RID: 109110 RVA: 0x005FAF61 File Offset: 0x005F9361
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA37 RID: 109111 RVA: 0x005FAF64 File Offset: 0x005F9364
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA38 RID: 109112 RVA: 0x005FAF68 File Offset: 0x005F9368
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Assignment assignment = (Assignment)base.GetNode();
				EBTStatus result = EBTStatus.BT_SUCCESS;
				if (assignment.m_opl != null)
				{
					if (assignment.m_bCast)
					{
						assignment.m_opl.SetValueAs(pAgent, assignment.m_opr);
					}
					else
					{
						assignment.m_opl.SetValue(pAgent, assignment.m_opr);
					}
				}
				else
				{
					result = assignment.update_impl(pAgent, childStatus);
				}
				return result;
			}
		}
	}
}
