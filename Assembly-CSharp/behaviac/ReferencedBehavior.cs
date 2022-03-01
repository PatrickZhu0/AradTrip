using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x0200486F RID: 18543
	public class ReferencedBehavior : BehaviorNode
	{
		// Token: 0x0601AAA3 RID: 109219 RVA: 0x00839984 File Offset: 0x00837D84
		protected override void load(int version, string agentType, List<property_t> properties)
		{
			base.load(version, agentType, properties);
			for (int i = 0; i < properties.Count; i++)
			{
				property_t property_t = properties[i];
				if (property_t.name == "ReferenceBehavior")
				{
					int num = property_t.value.IndexOf('(');
					if (num == -1)
					{
						this.m_referencedBehaviorPath = AgentMeta.ParseProperty(property_t.value, null);
					}
					else
					{
						this.m_referencedBehaviorPath = AgentMeta.ParseMethod(property_t.value);
					}
					string referencedTree = this.GetReferencedTree(null);
					bool flag = true;
					if (!string.IsNullOrEmpty(referencedTree))
					{
						if (Config.PreloadBehaviors)
						{
							BehaviorTree behaviorTree = Workspace.Instance.LoadBehaviorTree(referencedTree);
							if (behaviorTree != null)
							{
								flag = behaviorTree.HasEvents();
							}
						}
						this.m_bHasEvents = (this.m_bHasEvents || flag);
					}
				}
				else if (property_t.name == "Task")
				{
					this.m_taskMethod = AgentMeta.ParseMethod(property_t.value);
				}
			}
		}

		// Token: 0x0601AAA4 RID: 109220 RVA: 0x00839A88 File Offset: 0x00837E88
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

		// Token: 0x0601AAA5 RID: 109221 RVA: 0x00839AD1 File Offset: 0x00837ED1
		public override bool IsValid(Agent pAgent, BehaviorTask pTask)
		{
			return pTask.GetNode() is ReferencedBehavior && base.IsValid(pAgent, pTask);
		}

		// Token: 0x0601AAA6 RID: 109222 RVA: 0x00839AF0 File Offset: 0x00837EF0
		protected override BehaviorTask createTask()
		{
			return new ReferencedBehavior.ReferencedBehaviorTask();
		}

		// Token: 0x0601AAA7 RID: 109223 RVA: 0x00839B04 File Offset: 0x00837F04
		public virtual string GetReferencedTree(Agent pAgent)
		{
			if (this.m_referencedBehaviorPath != null)
			{
				return ((CInstanceMember<string>)this.m_referencedBehaviorPath).GetValue(pAgent);
			}
			return string.Empty;
		}

		// Token: 0x0601AAA8 RID: 109224 RVA: 0x00839B28 File Offset: 0x00837F28
		public void SetTaskParams(Agent agent, BehaviorTreeTask treeTask)
		{
			if (this.m_taskMethod != null)
			{
				this.m_taskMethod.SetTaskParams(agent, treeTask);
			}
		}

		// Token: 0x0601AAA9 RID: 109225 RVA: 0x00839B44 File Offset: 0x00837F44
		public Task RootTaskNode(Agent pAgent)
		{
			if (this.m_taskNode == null)
			{
				string referencedTree = this.GetReferencedTree(pAgent);
				BehaviorTree behaviorTree = Workspace.Instance.LoadBehaviorTree(referencedTree);
				if (behaviorTree != null && behaviorTree.GetChildrenCount() == 1)
				{
					BehaviorNode child = behaviorTree.GetChild(0);
					this.m_taskNode = (child as Task);
				}
			}
			return this.m_taskNode;
		}

		// Token: 0x040129F3 RID: 76275
		protected List<Transition> m_transitions;

		// Token: 0x040129F4 RID: 76276
		protected IInstanceMember m_referencedBehaviorPath;

		// Token: 0x040129F5 RID: 76277
		protected IMethod m_taskMethod;

		// Token: 0x040129F6 RID: 76278
		private Task m_taskNode;

		// Token: 0x02004870 RID: 18544
		public class ReferencedBehaviorTask : SingeChildTask
		{
			// Token: 0x0601AAAB RID: 109227 RVA: 0x00839BAC File Offset: 0x00837FAC
			protected override bool CheckPreconditions(Agent pAgent, bool bIsAlive)
			{
				return base.CheckPreconditions(pAgent, bIsAlive);
			}

			// Token: 0x0601AAAC RID: 109228 RVA: 0x00839BC3 File Offset: 0x00837FC3
			public override int GetNextStateId()
			{
				return this.m_nextStateId;
			}

			// Token: 0x0601AAAD RID: 109229 RVA: 0x00839BCB File Offset: 0x00837FCB
			public override bool onevent(Agent pAgent, string eventName, Dictionary<uint, IInstantiatedVariable> eventPrams)
			{
				return this.m_status != EBTStatus.BT_RUNNING || !this.m_node.HasEvents() || this.m_subTree.onevent(pAgent, eventName, eventPrams);
			}

			// Token: 0x0601AAAE RID: 109230 RVA: 0x00839C00 File Offset: 0x00838000
			protected override bool onenter(Agent pAgent)
			{
				ReferencedBehavior referencedBehavior = base.GetNode() as ReferencedBehavior;
				if (referencedBehavior != null)
				{
					this.m_nextStateId = -1;
					string referencedTree = referencedBehavior.GetReferencedTree(pAgent);
					if (this.m_subTree == null || referencedTree != this.m_subTree.GetName())
					{
						if (this.m_subTree != null)
						{
							Workspace.Instance.DestroyBehaviorTreeTask(this.m_subTree, pAgent);
						}
						this.m_subTree = Workspace.Instance.CreateBehaviorTreeTask(referencedTree);
						referencedBehavior.SetTaskParams(pAgent, this.m_subTree);
					}
					else if (this.m_subTree != null)
					{
						this.m_subTree.reset(pAgent);
					}
					referencedBehavior.SetTaskParams(pAgent, this.m_subTree);
					return true;
				}
				return false;
			}

			// Token: 0x0601AAAF RID: 109231 RVA: 0x00839CB5 File Offset: 0x008380B5
			protected override void onexit(Agent pAgent, EBTStatus s)
			{
				base.onexit(pAgent, s);
			}

			// Token: 0x0601AAB0 RID: 109232 RVA: 0x00839CC0 File Offset: 0x008380C0
			protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
			{
				ReferencedBehavior referencedBehavior = base.GetNode() as ReferencedBehavior;
				if (referencedBehavior != null)
				{
					EBTStatus ebtstatus = this.m_subTree.exec(pAgent);
					bool flag = State.UpdateTransitions(pAgent, referencedBehavior, referencedBehavior.m_transitions, ref this.m_nextStateId, ebtstatus);
					if (flag)
					{
						if (ebtstatus == EBTStatus.BT_RUNNING)
						{
							this.m_subTree.abort(pAgent);
						}
						ebtstatus = EBTStatus.BT_SUCCESS;
					}
					return ebtstatus;
				}
				return EBTStatus.BT_INVALID;
			}

			// Token: 0x040129F7 RID: 76279
			private int m_nextStateId = -1;

			// Token: 0x040129F8 RID: 76280
			private BehaviorTreeTask m_subTree;
		}
	}
}
