using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004867 RID: 18535
	public class IfElse : BehaviorNode
	{
		// Token: 0x0601AA8C RID: 109196 RVA: 0x0083985A File Offset: 0x00837C5A
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AA8D RID: 109197 RVA: 0x00839865 File Offset: 0x00837C65
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is IfElse && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AA8E RID: 109198 RVA: 0x00839884 File Offset: 0x00837C84
		protected override BehaviorTask createTask()
		{
			return new IfElse.IfElseTask();
		}

		// Token: 0x02004868 RID: 18536
		private class IfElseTask : CompositeTask
		{
			// Token: 0x0601AA90 RID: 109200 RVA: 0x008398A0 File Offset: 0x00837CA0
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AA91 RID: 109201 RVA: 0x008398A9 File Offset: 0x00837CA9
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AA92 RID: 109202 RVA: 0x008398B2 File Offset: 0x00837CB2
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AA93 RID: 109203 RVA: 0x008398BB File Offset: 0x00837CBB
			protected override bool onenter(Agent pAgent)
			{
				this.m_activeChildIndex = -1;
				return this.m_children.Count == 3;
			}

			// Token: 0x0601AA94 RID: 109204 RVA: 0x008398D8 File Offset: 0x00837CD8
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AA95 RID: 109205 RVA: 0x008398E4 File Offset: 0x00837CE4
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				EBTStatus ebtstatus = EBTStatus.BT_INVALID;
				if (childStatus == EBTStatus.BT_SUCCESS || childStatus == EBTStatus.BT_FAILURE)
				{
					ebtstatus = childStatus;
				}
				if (this.m_activeChildIndex != -1)
				{
					return childStatus;
				}
				BehaviorTask behaviorTask = this.m_children[0];
				if (ebtstatus == EBTStatus.BT_INVALID)
				{
					ebtstatus = behaviorTask.exec(pAgent);
				}
				if (ebtstatus == EBTStatus.BT_SUCCESS)
				{
					this.m_activeChildIndex = 1;
				}
				else if (ebtstatus == EBTStatus.BT_FAILURE)
				{
					this.m_activeChildIndex = 2;
				}
				if (this.m_activeChildIndex != -1)
				{
					BehaviorTask behaviorTask2 = this.m_children[this.m_activeChildIndex];
					return behaviorTask2.exec(pAgent);
				}
				return EBTStatus.BT_RUNNING;
			}
		}
	}
}
