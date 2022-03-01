using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200485B RID: 18523
	public class End : BehaviorNode
	{
		// Token: 0x0601AA45 RID: 109125 RVA: 0x00838D5C File Offset: 0x0083715C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "EndStatus")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_endStatus = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_endStatus = AgentMeta.ParseMethod(property_t.value);
					}
				}
				else if (property_t.name == "EndOutside")
				{
					this.m_endOutside = (property_t.value == "true");
				}
			}
		}

		// Token: 0x0601AA46 RID: 109126 RVA: 0x00838E19 File Offset: 0x00837219
		protected virtual EBTStatus GetStatus(Agent pAgent)
		{
			return (this.m_endStatus == null) ? EBTStatus.BT_SUCCESS : ((CInstanceMember<EBTStatus>)this.m_endStatus).GetValue(pAgent);
		}

		// Token: 0x0601AA47 RID: 109127 RVA: 0x00838E3D File Offset: 0x0083723D
		protected bool GetEndOutside()
		{
			return this.m_endOutside;
		}

		// Token: 0x0601AA48 RID: 109128 RVA: 0x00838E48 File Offset: 0x00837248
		protected override BehaviorTask createTask()
		{
			return new End.EndTask();
		}

		// Token: 0x040129D6 RID: 76246
		protected IInstanceMember m_endStatus;

		// Token: 0x040129D7 RID: 76247
		protected bool m_endOutside;

		// Token: 0x0200485C RID: 18524
		private class EndTask : LeafTask
		{
			// Token: 0x0601AA4A RID: 109130 RVA: 0x00838E64 File Offset: 0x00837264
			private EBTStatus GetStatus(Agent pAgent)
			{
				End end = base.GetNode() as End;
				return (end == null) ? EBTStatus.BT_SUCCESS : end.GetStatus(pAgent);
			}

			// Token: 0x0601AA4B RID: 109131 RVA: 0x00838E94 File Offset: 0x00837294
			private bool GetEndOutside()
			{
				End end = base.GetNode() as End;
				return end != null && end.GetEndOutside();
			}

			// Token: 0x0601AA4C RID: 109132 RVA: 0x00838EBF File Offset: 0x008372BF
			protected override bool onenter(Agent pAgent)
			{
				return true;
			}

			// Token: 0x0601AA4D RID: 109133 RVA: 0x00838EC2 File Offset: 0x008372C2
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA4E RID: 109134 RVA: 0x00838EC4 File Offset: 0x008372C4
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				BehaviorTreeTask behaviorTreeTask = null;
				if (!this.GetEndOutside())
				{
					behaviorTreeTask = base.RootTask;
				}
				else if (pAgent != null)
				{
					behaviorTreeTask = pAgent.CurrentTreeTask;
				}
				if (behaviorTreeTask != null)
				{
					behaviorTreeTask.setEndStatus(this.GetStatus(pAgent));
				}
				return EBTStatus.BT_RUNNING;
			}
		}
	}
}
