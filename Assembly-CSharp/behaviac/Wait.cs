using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200485F RID: 18527
	public class Wait : BehaviorNode
	{
		// Token: 0x0601AA5B RID: 109147 RVA: 0x00838F7C File Offset: 0x0083737C
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Time")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_time = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_time = AgentMeta.ParseMethod(property_t.value);
					}
				}
			}
		}

		// Token: 0x0601AA5C RID: 109148 RVA: 0x00839008 File Offset: 0x00837408
		protected virtual double GetTime(Agent pAgent)
		{
			double result = 0.0;
			if (this.m_time != null)
			{
				if (this.m_time is CInstanceMember<double>)
				{
					result = ((CInstanceMember<double>)this.m_time).GetValue(pAgent);
				}
				else if (this.m_time is CInstanceMember<float>)
				{
					result = (double)((CInstanceMember<float>)this.m_time).GetValue(pAgent);
				}
				else if (this.m_time is CInstanceMember<int>)
				{
					result = (double)((CInstanceMember<int>)this.m_time).GetValue(pAgent);
				}
			}
			return result;
		}

		// Token: 0x0601AA5D RID: 109149 RVA: 0x008390A0 File Offset: 0x008374A0
		protected virtual int GetIntTime(Agent pAgent)
		{
			int result = 0;
			if (this.m_time != null && this.m_time is CInstanceMember<int>)
			{
				result = ((CInstanceMember<int>)this.m_time).GetValue(pAgent);
			}
			return result;
		}

		// Token: 0x0601AA5E RID: 109150 RVA: 0x008390E0 File Offset: 0x008374E0
		protected override BehaviorTask createTask()
		{
			return new Wait.WaitTask();
		}

		// Token: 0x040129D8 RID: 76248
		protected IInstanceMember m_time;

		// Token: 0x02004860 RID: 18528
		private class WaitTask : LeafTask
		{
			// Token: 0x0601AA60 RID: 109152 RVA: 0x008390FC File Offset: 0x008374FC
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				Wait.WaitTask waitTask = (Wait.WaitTask)target;
				waitTask.m_start = this.m_start;
				waitTask.m_time = this.m_time;
				waitTask.m_intStart = this.m_intStart;
				waitTask.m_intTime = this.m_intTime;
			}

			// Token: 0x0601AA61 RID: 109153 RVA: 0x00839148 File Offset: 0x00837548
			public override void save(ISerializableNode node)
			{
				base.save(node);
				CSerializationID attrId = new CSerializationID("start");
				node.setAttr<double>(attrId, this.m_start);
				CSerializationID attrId2 = new CSerializationID("time");
				node.setAttr<double>(attrId2, this.m_time);
				CSerializationID attrId3 = new CSerializationID("intstart");
				node.setAttr<long>(attrId3, this.m_intStart);
				CSerializationID attrId4 = new CSerializationID("inttime");
				node.setAttr<int>(attrId4, this.m_intTime);
			}

			// Token: 0x0601AA62 RID: 109154 RVA: 0x008391C0 File Offset: 0x008375C0
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA63 RID: 109155 RVA: 0x008391CC File Offset: 0x008375CC
			private double GetTime(Agent pAgent)
			{
				Wait wait = base.GetNode() as Wait;
				return (wait == null) ? 0.0 : wait.GetTime(pAgent);
			}

			// Token: 0x0601AA64 RID: 109156 RVA: 0x00839200 File Offset: 0x00837600
			private int GetIntTime(Agent pAgent)
			{
				Wait wait = base.GetNode() as Wait;
				return (wait == null) ? 0 : wait.GetIntTime(pAgent);
			}

			// Token: 0x0601AA65 RID: 109157 RVA: 0x0083922C File Offset: 0x0083762C
			protected override bool onenter(Agent pAgent)
			{
				if (Workspace.Instance.UseIntValue)
				{
					this.m_intStart = Workspace.Instance.IntValueSinceStartup;
					this.m_intTime = this.GetIntTime(pAgent);
					return this.m_intTime >= 0;
				}
				this.m_start = Workspace.Instance.DoubleValueSinceStartup;
				this.m_time = this.GetTime(pAgent);
				return this.m_time >= 0.0;
			}

			// Token: 0x0601AA66 RID: 109158 RVA: 0x008392A3 File Offset: 0x008376A3
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AA67 RID: 109159 RVA: 0x008392A8 File Offset: 0x008376A8
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				if (Workspace.Instance.UseIntValue)
				{
					if (Workspace.Instance.IntValueSinceStartup - this.m_intStart >= (long)this.m_intTime)
					{
						return EBTStatus.BT_SUCCESS;
					}
				}
				else if (Workspace.Instance.DoubleValueSinceStartup - this.m_start >= this.m_time)
				{
					return EBTStatus.BT_SUCCESS;
				}
				return EBTStatus.BT_RUNNING;
			}

			// Token: 0x040129D9 RID: 76249
			private double m_start;

			// Token: 0x040129DA RID: 76250
			private double m_time;

			// Token: 0x040129DB RID: 76251
			private long m_intStart;

			// Token: 0x040129DC RID: 76252
			private int m_intTime;
		}
	}
}
