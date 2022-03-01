using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048B2 RID: 18610
	public class WaitState : State
	{
		// Token: 0x0601AC1A RID: 109594 RVA: 0x0083BE34 File Offset: 0x0083A234
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

		// Token: 0x0601AC1B RID: 109595 RVA: 0x0083BEC0 File Offset: 0x0083A2C0
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

		// Token: 0x0601AC1C RID: 109596 RVA: 0x0083BF58 File Offset: 0x0083A358
		protected virtual int GetIntTime(Agent pAgent)
		{
			int result = 0;
			if (this.m_time != null && this.m_time is CInstanceMember<int>)
			{
				result = ((CInstanceMember<int>)this.m_time).GetValue(pAgent);
			}
			return result;
		}

		// Token: 0x0601AC1D RID: 109597 RVA: 0x0083BF98 File Offset: 0x0083A398
		protected override BehaviorTask createTask()
		{
			return new WaitState.WaitStateTask();
		}

		// Token: 0x04012A1F RID: 76319
		protected IInstanceMember m_time;

		// Token: 0x020048B3 RID: 18611
		private class WaitStateTask : State.StateTask
		{
			// Token: 0x0601AC1F RID: 109599 RVA: 0x0083BFB4 File Offset: 0x0083A3B4
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				WaitState.WaitStateTask waitStateTask = (WaitState.WaitStateTask)target;
				waitStateTask.m_start = this.m_start;
				waitStateTask.m_time = this.m_time;
				waitStateTask.m_intStart = this.m_intStart;
				waitStateTask.m_intTime = this.m_intTime;
			}

			// Token: 0x0601AC20 RID: 109600 RVA: 0x0083C000 File Offset: 0x0083A400
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

			// Token: 0x0601AC21 RID: 109601 RVA: 0x0083C078 File Offset: 0x0083A478
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AC22 RID: 109602 RVA: 0x0083C084 File Offset: 0x0083A484
			private double GetTime(Agent pAgent)
			{
				WaitState waitState = base.GetNode() as WaitState;
				return (waitState == null) ? 0.0 : waitState.GetTime(pAgent);
			}

			// Token: 0x0601AC23 RID: 109603 RVA: 0x0083C0B8 File Offset: 0x0083A4B8
			private int GetIntTime(Agent pAgent)
			{
				WaitState waitState = base.GetNode() as WaitState;
				return (waitState == null) ? 0 : waitState.GetIntTime(pAgent);
			}

			// Token: 0x0601AC24 RID: 109604 RVA: 0x0083C0E4 File Offset: 0x0083A4E4
			protected override bool onenter(Agent pAgent)
			{
				this.m_nextStateId = -1;
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

			// Token: 0x0601AC25 RID: 109605 RVA: 0x0083C162 File Offset: 0x0083A562
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AC26 RID: 109606 RVA: 0x0083C164 File Offset: 0x0083A564
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				WaitState waitState = (WaitState)this.m_node;
				if (Workspace.Instance.UseIntValue)
				{
					if (Workspace.Instance.IntValueSinceStartup - this.m_intStart >= (long)this.m_intTime)
					{
						waitState.Update(pAgent, out this.m_nextStateId);
						return EBTStatus.BT_SUCCESS;
					}
				}
				else if (Workspace.Instance.DoubleValueSinceStartup - this.m_start >= this.m_time)
				{
					waitState.Update(pAgent, out this.m_nextStateId);
					return EBTStatus.BT_SUCCESS;
				}
				return EBTStatus.BT_RUNNING;
			}

			// Token: 0x04012A20 RID: 76320
			private double m_start;

			// Token: 0x04012A21 RID: 76321
			private double m_time;

			// Token: 0x04012A22 RID: 76322
			private long m_intStart;

			// Token: 0x04012A23 RID: 76323
			private int m_intTime;
		}
	}
}
