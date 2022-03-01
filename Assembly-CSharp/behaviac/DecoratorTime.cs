using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048A6 RID: 18598
	public class DecoratorTime : DecoratorNode
	{
		// Token: 0x0601ABCE RID: 109518 RVA: 0x0083B3AC File Offset: 0x008397AC
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

		// Token: 0x0601ABCF RID: 109519 RVA: 0x0083B438 File Offset: 0x00839838
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

		// Token: 0x0601ABD0 RID: 109520 RVA: 0x0083B4D0 File Offset: 0x008398D0
		protected virtual int GetIntTime(Agent pAgent)
		{
			int result = 0;
			if (this.m_time != null && this.m_time is CInstanceMember<int>)
			{
				result = ((CInstanceMember<int>)this.m_time).GetValue(pAgent);
			}
			return result;
		}

		// Token: 0x0601ABD1 RID: 109521 RVA: 0x0083B510 File Offset: 0x00839910
		protected override BehaviorTask createTask()
		{
			return new DecoratorTime.DecoratorTimeTask();
		}

		// Token: 0x04012A0B RID: 76299
		protected IInstanceMember m_time;

		// Token: 0x020048A7 RID: 18599
		private class DecoratorTimeTask : DecoratorTask
		{
			// Token: 0x0601ABD3 RID: 109523 RVA: 0x0083B52C File Offset: 0x0083992C
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
				DecoratorTime.DecoratorTimeTask decoratorTimeTask = (DecoratorTime.DecoratorTimeTask)target;
				decoratorTimeTask.m_start = this.m_start;
				decoratorTimeTask.m_time = this.m_time;
				decoratorTimeTask.m_intStart = this.m_intStart;
				decoratorTimeTask.m_intTime = this.m_intTime;
			}

			// Token: 0x0601ABD4 RID: 109524 RVA: 0x0083B578 File Offset: 0x00839978
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

			// Token: 0x0601ABD5 RID: 109525 RVA: 0x0083B5F0 File Offset: 0x008399F0
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABD6 RID: 109526 RVA: 0x0083B5FC File Offset: 0x008399FC
			private double GetTime(Agent pAgent)
			{
				DecoratorTime decoratorTime = (DecoratorTime)base.GetNode();
				return (decoratorTime == null) ? 0.0 : decoratorTime.GetTime(pAgent);
			}

			// Token: 0x0601ABD7 RID: 109527 RVA: 0x0083B630 File Offset: 0x00839A30
			private int GetIntTime(Agent pAgent)
			{
				DecoratorTime decoratorTime = (DecoratorTime)base.GetNode();
				return (decoratorTime == null) ? 0 : decoratorTime.GetIntTime(pAgent);
			}

			// Token: 0x0601ABD8 RID: 109528 RVA: 0x0083B65C File Offset: 0x00839A5C
			protected override bool onenter(Agent pAgent)
			{
				base.onenter(pAgent);
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

			// Token: 0x0601ABD9 RID: 109529 RVA: 0x0083B6DC File Offset: 0x00839ADC
			protected override EBTStatus decorate(EBTStatus status)
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

			// Token: 0x04012A0C RID: 76300
			private double m_start;

			// Token: 0x04012A0D RID: 76301
			private double m_time;

			// Token: 0x04012A0E RID: 76302
			private long m_intStart;

			// Token: 0x04012A0F RID: 76303
			private int m_intTime;
		}
	}
}
