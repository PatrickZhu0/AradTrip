using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200488B RID: 18571
	public class DecoratorIterator : DecoratorNode
	{
		// Token: 0x0601AB47 RID: 109383 RVA: 0x0083A8B4 File Offset: 0x00838CB4
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

		// Token: 0x0601AB48 RID: 109384 RVA: 0x0083A988 File Offset: 0x00838D88
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is DecoratorIterator && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AB49 RID: 109385 RVA: 0x0083A9A4 File Offset: 0x00838DA4
		public bool IterateIt(Agent pAgent, int index, ref int count)
		{
			if (this.m_opl != null && this.m_opr != null)
			{
				count = this.m_opr.GetCount(pAgent);
				if (index >= 0 && index < count)
				{
					this.m_opl.SetValue(pAgent, this.m_opr, index);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0601AB4A RID: 109386 RVA: 0x0083A9FF File Offset: 0x00838DFF
		protected override BehaviorTask createTask()
		{
			return null;
		}

		// Token: 0x04012A00 RID: 76288
		protected IInstanceMember m_opl;

		// Token: 0x04012A01 RID: 76289
		protected IInstanceMember m_opr;
	}
}
