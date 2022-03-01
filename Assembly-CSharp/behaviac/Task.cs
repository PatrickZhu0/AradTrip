using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B9 RID: 18617
	public class Task : BehaviorNode
	{
		// Token: 0x170022A0 RID: 8864
		// (get) Token: 0x0601AC48 RID: 109640 RVA: 0x0083C61A File Offset: 0x0083AA1A
		public bool IsHTN
		{
			get
			{
				return this.m_bHTN;
			}
		}

		// Token: 0x0601AC49 RID: 109641 RVA: 0x0083C624 File Offset: 0x0083AA24
		public int FindMethodIndex(Method method)
		{
			for (int i = 0; i < base.GetChildrenCount(); i++)
			{
				BehaviorNode child = base.GetChild(i);
				if (child == method)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0601AC4A RID: 109642 RVA: 0x0083C65A File Offset: 0x0083AA5A
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Task && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AC4B RID: 109643 RVA: 0x0083C678 File Offset: 0x0083AA78
		protected override BehaviorTask createTask()
		{
			return new TaskTask();
		}

		// Token: 0x0601AC4C RID: 109644 RVA: 0x0083C68C File Offset: 0x0083AA8C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Prototype")
				{
					this.m_task = AgentMeta.ParseMethod(property_t.value);
				}
				else if (property_t.name == "IsHTN")
				{
					this.m_bHTN = (property_t.value == "true");
				}
			}
		}

		// Token: 0x04012A28 RID: 76328
		public const string LOCAL_TASK_PARAM_PRE = "_$local_task_param_$_";

		// Token: 0x04012A29 RID: 76329
		protected IMethod m_task;

		// Token: 0x04012A2A RID: 76330
		protected bool m_bHTN;
	}
}
