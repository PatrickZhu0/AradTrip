using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004879 RID: 18553
	public class Sequence : BehaviorNode
	{
		// Token: 0x0601AAE6 RID: 109286 RVA: 0x0083A299 File Offset: 0x00838699
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
		}

		// Token: 0x0601AAE7 RID: 109287 RVA: 0x0083A2A4 File Offset: 0x008386A4
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is Sequence && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAE8 RID: 109288 RVA: 0x0083A2C0 File Offset: 0x008386C0
		public override bool Evaluate(Agent pAgent)
		{
			bool flag = true;
			for (int i = 0; i < this.m_children.Count; i++)
			{
				BehaviorNode behaviorNode = this.m_children[i];
				flag = behaviorNode.Evaluate(pAgent);
				if (!flag)
				{
					break;
				}
			}
			return flag;
		}

		// Token: 0x0601AAE9 RID: 109289 RVA: 0x0083A30C File Offset: 0x0083870C
		public EBTStatus SequenceUpdate(Agent pAgent, EBTStatus childStatus, ref int activeChildIndex, List<BehaviorTask> children)
		{
			EBTStatus ebtstatus = childStatus;
			for (;;)
			{
				if (ebtstatus == EBTStatus.BT_RUNNING)
				{
					BehaviorTask behaviorTask = children[activeChildIndex];
					if (this.CheckIfInterrupted(pAgent))
					{
						break;
					}
					ebtstatus = behaviorTask.exec(pAgent);
				}
				if (ebtstatus != EBTStatus.BT_SUCCESS)
				{
					return ebtstatus;
				}
				activeChildIndex++;
				if (activeChildIndex >= children.Count)
				{
					return EBTStatus.BT_SUCCESS;
				}
				ebtstatus = EBTStatus.BT_RUNNING;
			}
			return EBTStatus.BT_FAILURE;
		}

		// Token: 0x0601AAEA RID: 109290 RVA: 0x0083A36C File Offset: 0x0083876C
		public bool CheckIfInterrupted(Agent pAgent)
		{
			return base.EvaluteCustomCondition(pAgent);
		}

		// Token: 0x0601AAEB RID: 109291 RVA: 0x0083A382 File Offset: 0x00838782
		protected override BehaviorTask createTask()
		{
			return new Sequence.SequenceTask();
		}

		// Token: 0x0200487A RID: 18554
		public class SequenceTask : CompositeTask
		{
			// Token: 0x0601AAED RID: 109293 RVA: 0x0083A391 File Offset: 0x00838791
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AAEE RID: 109294 RVA: 0x0083A39A File Offset: 0x0083879A
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AAEF RID: 109295 RVA: 0x0083A3A3 File Offset: 0x008387A3
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AAF0 RID: 109296 RVA: 0x0083A3AC File Offset: 0x008387AC
			protected override bool onenter(Agent pAgent)
			{
				this.m_activeChildIndex = 0;
				return true;
			}

			// Token: 0x0601AAF1 RID: 109297 RVA: 0x0083A3B6 File Offset: 0x008387B6
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAF2 RID: 109298 RVA: 0x0083A3C0 File Offset: 0x008387C0
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				Sequence sequence = this.m_node as Sequence;
				return sequence.SequenceUpdate(pAgent, childStatus, ref this.m_activeChildIndex, this.m_children);
			}
		}
	}
}
