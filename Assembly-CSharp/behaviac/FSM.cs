using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048AC RID: 18604
	public class FSM : BehaviorNode
	{
		// Token: 0x0601ABED RID: 109549 RVA: 0x0083BA08 File Offset: 0x00839E08
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "initialid")
				{
					this.m_initialid = Convert.ToInt32(property_t.value);
				}
			}
		}

		// Token: 0x0601ABEE RID: 109550 RVA: 0x0083BA65 File Offset: 0x00839E65
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is FSM && base.IsValid(pAgent, pTask);
		}

		// Token: 0x1700229B RID: 8859
		// (get) Token: 0x0601ABEF RID: 109551 RVA: 0x0083BA81 File Offset: 0x00839E81
		// (set) Token: 0x0601ABF0 RID: 109552 RVA: 0x0083BA89 File Offset: 0x00839E89
		public int InitialId
		{
			get
			{
				return this.m_initialid;
			}
			set
			{
				this.m_initialid = value;
			}
		}

		// Token: 0x0601ABF1 RID: 109553 RVA: 0x0083BA92 File Offset: 0x00839E92
		protected override BehaviorTask createTask()
		{
			return new FSM.FSMTask();
		}

		// Token: 0x04012A17 RID: 76311
		private int m_initialid = -1;

		// Token: 0x020048AD RID: 18605
		public class FSMTask : CompositeTask
		{
			// Token: 0x0601ABF3 RID: 109555 RVA: 0x0083BAA8 File Offset: 0x00839EA8
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601ABF4 RID: 109556 RVA: 0x0083BAB1 File Offset: 0x00839EB1
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601ABF5 RID: 109557 RVA: 0x0083BABA File Offset: 0x00839EBA
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601ABF6 RID: 109558 RVA: 0x0083BAC4 File Offset: 0x00839EC4
			protected override bool onenter(Agent pAgent)
			{
				FSM fsm = (FSM)this.m_node;
				this.m_activeChildIndex = 0;
				this.m_currentNodeId = fsm.InitialId;
				return true;
			}

			// Token: 0x0601ABF7 RID: 109559 RVA: 0x0083BAF1 File Offset: 0x00839EF1
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				this.m_currentNodeId = -1;
				base.onexit(pAgent, s);
			}

			// Token: 0x0601ABF8 RID: 109560 RVA: 0x0083BB04 File Offset: 0x00839F04
			private EBTStatus UpdateFSM(Agent pAgent, EBTStatus childStatus)
			{
				bool flag = true;
				while (flag)
				{
					int num = -1;
					BehaviorTask childById = base.GetChildById(this.m_currentNodeId);
					if (childById != null)
					{
						childById.exec(pAgent);
						if (childById is State.StateTask)
						{
							State.StateTask stateTask = (State.StateTask)childById;
							if (stateTask != null && stateTask.IsEndState)
							{
								return EBTStatus.BT_SUCCESS;
							}
						}
						num = childById.GetNextStateId();
					}
					if (num < 0)
					{
						flag = false;
					}
					else
					{
						this.m_currentNodeId = num;
					}
				}
				return childStatus;
			}

			// Token: 0x0601ABF9 RID: 109561 RVA: 0x0083BB84 File Offset: 0x00839F84
			protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
			{
				return this.update(pAgent, childStatus);
			}

			// Token: 0x0601ABFA RID: 109562 RVA: 0x0083BB9C File Offset: 0x00839F9C
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				return this.UpdateFSM(pAgent, childStatus);
			}

			// Token: 0x04012A18 RID: 76312
			private int m_currentNodeId = -1;
		}
	}
}
