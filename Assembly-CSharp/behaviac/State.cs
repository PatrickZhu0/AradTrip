using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x020048AF RID: 18607
	public class State : BehaviorNode
	{
		// Token: 0x0601AC04 RID: 109572 RVA: 0x0083BBBC File Offset: 0x00839FBC
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "Method")
				{
					this.m_method = AgentMeta.ParseMethod(property_t.value);
				}
				else if (property_t.name == "IsEndState")
				{
					this.m_bIsEndState = (property_t.value == "true");
				}
			}
		}

		// Token: 0x0601AC05 RID: 109573 RVA: 0x0083BC4C File Offset: 0x0083A04C
		public override void Attach(BehaviorNode pAttachment, bool bIsPrecondition, bool bIsEffector, bool bIsTransition)
		{
			if (bIsTransition)
			{
				if (this.m_transitions == null)
				{
					this.m_transitions = new List<Transition>();
				}
				Transition item = pAttachment as Transition;
				this.m_transitions.Add(item);
				return;
			}
			base.Attach(pAttachment, bIsPrecondition, bIsEffector, bIsTransition);
		}

		// Token: 0x0601AC06 RID: 109574 RVA: 0x0083BC95 File Offset: 0x0083A095
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is State && base.IsValid(pAgent, pTask);
		}

		// Token: 0x1700229D RID: 8861
		// (get) Token: 0x0601AC07 RID: 109575 RVA: 0x0083BCB1 File Offset: 0x0083A0B1
		public bool IsEndState
		{
			get
			{
				return this.m_bIsEndState;
			}
		}

		// Token: 0x0601AC08 RID: 109576 RVA: 0x0083BCBC File Offset: 0x0083A0BC
		public EBTStatus Execute(Agent pAgent)
		{
			EBTStatus result = EBTStatus.BT_RUNNING;
			if (this.m_method != null)
			{
				this.m_method.Run(pAgent);
			}
			else
			{
				result = this.update_impl(pAgent, EBTStatus.BT_RUNNING);
			}
			return result;
		}

		// Token: 0x0601AC09 RID: 109577 RVA: 0x0083BCF4 File Offset: 0x0083A0F4
		protected override BehaviorTask createTask()
		{
			return new State.StateTask();
		}

		// Token: 0x0601AC0A RID: 109578 RVA: 0x0083BD08 File Offset: 0x0083A108
		public EBTStatus Update(Agent pAgent, out int nextStateId)
		{
			nextStateId = -1;
			EBTStatus result = this.Execute(pAgent);
			if (this.m_bIsEndState)
			{
				result = EBTStatus.BT_SUCCESS;
			}
			else
			{
				bool flag = State.UpdateTransitions(pAgent, this, this.m_transitions, ref nextStateId, result);
				if (flag)
				{
					result = EBTStatus.BT_SUCCESS;
				}
			}
			return result;
		}

		// Token: 0x0601AC0B RID: 109579 RVA: 0x0083BD4C File Offset: 0x0083A14C
		public static bool UpdateTransitions(Agent pAgent, BehaviorNode node, List<Transition> transitions, ref int nextStateId, EBTStatus result)
		{
			bool result2 = false;
			if (transitions != null)
			{
				for (int i = 0; i < transitions.Count; i++)
				{
					Transition transition = transitions[i];
					if (transition.Evaluate(pAgent, result))
					{
						nextStateId = transition.TargetStateId;
						transition.ApplyEffects(pAgent, Effector.EPhase.E_BOTH);
						result2 = true;
						break;
					}
				}
			}
			return result2;
		}

		// Token: 0x04012A1B RID: 76315
		protected bool m_bIsEndState;

		// Token: 0x04012A1C RID: 76316
		protected IMethod m_method;

		// Token: 0x04012A1D RID: 76317
		protected List<Transition> m_transitions;

		// Token: 0x020048B0 RID: 18608
		public class StateTask : LeafTask
		{
			// Token: 0x0601AC0D RID: 109581 RVA: 0x0083BDB5 File Offset: 0x0083A1B5
			public override void copyto(BehaviorTask target)
			{
				base.copyto(target);
			}

			// Token: 0x0601AC0E RID: 109582 RVA: 0x0083BDBE File Offset: 0x0083A1BE
			public override void save(ISerializableNode node)
			{
				base.save(node);
			}

			// Token: 0x0601AC0F RID: 109583 RVA: 0x0083BDC7 File Offset: 0x0083A1C7
			public override void load(ISerializableNode node)
			{
				base.load(node);
			}

			// Token: 0x0601AC10 RID: 109584 RVA: 0x0083BDD0 File Offset: 0x0083A1D0
			public override int GetNextStateId()
			{
				return this.m_nextStateId;
			}

			// Token: 0x1700229E RID: 8862
			// (get) Token: 0x0601AC11 RID: 109585 RVA: 0x0083BDD8 File Offset: 0x0083A1D8
			public bool IsEndState
			{
				get
				{
					State state = (State)base.GetNode();
					return state.IsEndState;
				}
			}

			// Token: 0x0601AC12 RID: 109586 RVA: 0x0083BDF7 File Offset: 0x0083A1F7
			protected override bool onenter(Agent pAgent)
			{
				this.m_nextStateId = -1;
				return true;
			}

			// Token: 0x0601AC13 RID: 109587 RVA: 0x0083BE01 File Offset: 0x0083A201
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
			}

			// Token: 0x0601AC14 RID: 109588 RVA: 0x0083BE04 File Offset: 0x0083A204
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				State state = (State)base.GetNode();
				return state.Update(pAgent, out this.m_nextStateId);
			}

			// Token: 0x04012A1E RID: 76318
			protected int m_nextStateId = -1;
		}
	}
}
