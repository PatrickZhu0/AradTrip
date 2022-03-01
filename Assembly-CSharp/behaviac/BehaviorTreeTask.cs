using System;
using System.Collections.Generic;

namespace behaviac
{
	// Token: 0x02004854 RID: 18516
	public class BehaviorTreeTask : SingeChildTask
	{
		// Token: 0x17002297 RID: 8855
		// (get) Token: 0x0601AA10 RID: 109072 RVA: 0x00838ABC File Offset: 0x00836EBC
		public Dictionary<uint, IInstantiatedVariable> LocalVars
		{
			get
			{
				return this.m_localVars;
			}
		}

		// Token: 0x0601AA11 RID: 109073 RVA: 0x00838AC4 File Offset: 0x00836EC4
		internal void SetVariable<VariableType>(string variableName, VariableType value)
		{
			uint key = Utils.MakeVariableId(variableName);
			if (this.LocalVars.ContainsKey(key))
			{
				IInstantiatedVariable instantiatedVariable = this.LocalVars[key];
				CVariable<VariableType> cvariable = (CVariable<VariableType>)instantiatedVariable;
				if (cvariable != null)
				{
					cvariable.SetValue(null, value);
					return;
				}
			}
		}

		// Token: 0x0601AA12 RID: 109074 RVA: 0x00838B0C File Offset: 0x00836F0C
		internal void AddVariables(Dictionary<uint, IInstantiatedVariable> vars)
		{
			if (vars != null)
			{
				foreach (uint key in vars.Keys)
				{
					this.LocalVars[key] = vars[key];
				}
			}
		}

		// Token: 0x0601AA13 RID: 109075 RVA: 0x00838B57 File Offset: 0x00836F57
		public override void Init(BehaviorNode node)
		{
			base.Init(node);
			if (this.m_node != null)
			{
				((BehaviorTree)this.m_node).InstantiatePars(this.LocalVars);
			}
		}

		// Token: 0x0601AA14 RID: 109076 RVA: 0x00838B81 File Offset: 0x00836F81
		public override void Clear()
		{
			this.m_root = null;
			if (this.m_node != null)
			{
				((BehaviorTree)this.m_node).UnInstantiatePars(this.LocalVars);
			}
			base.Clear();
		}

		// Token: 0x0601AA15 RID: 109077 RVA: 0x00838BB1 File Offset: 0x00836FB1
		public void SetRootTask(BehaviorTask pRoot)
		{
			this.addChild(pRoot);
		}

		// Token: 0x0601AA16 RID: 109078 RVA: 0x00838BBA File Offset: 0x00836FBA
		public void CopyTo(BehaviorTreeTask target)
		{
			this.copyto(target);
		}

		// Token: 0x0601AA17 RID: 109079 RVA: 0x00838BC3 File Offset: 0x00836FC3
		public void Save(ISerializableNode node)
		{
		}

		// Token: 0x0601AA18 RID: 109080 RVA: 0x00838BC5 File Offset: 0x00836FC5
		public void Load(ISerializableNode node)
		{
			this.load(node);
		}

		// Token: 0x0601AA19 RID: 109081 RVA: 0x00838BD0 File Offset: 0x00836FD0
		public string GetName()
		{
			BehaviorTree behaviorTree = this.m_node as BehaviorTree;
			return behaviorTree.GetName();
		}

		// Token: 0x0601AA1A RID: 109082 RVA: 0x00838BEF File Offset: 0x00836FEF
		public void setEndStatus(EBTStatus status)
		{
			this.m_endStatus = status;
		}

		// Token: 0x0601AA1B RID: 109083 RVA: 0x00838BF8 File Offset: 0x00836FF8
		public EBTStatus resume(Agent pAgent, EBTStatus status)
		{
			return base.resume_branch(pAgent, status);
		}

		// Token: 0x0601AA1C RID: 109084 RVA: 0x00838C0F File Offset: 0x0083700F
		protected override bool onenter(Agent pAgent)
		{
			pAgent.LogJumpTree(this.GetName());
			return true;
		}

		// Token: 0x0601AA1D RID: 109085 RVA: 0x00838C1E File Offset: 0x0083701E
		protected override void onexit(Agent pAgent, EBTStatus s)
		{
			pAgent.ExcutingTreeTask = this.m_excutingTreeTask;
			pAgent.LogReturnTree(this.GetName());
			base.onexit(pAgent, s);
		}

		// Token: 0x0601AA1E RID: 109086 RVA: 0x00838C40 File Offset: 0x00837040
		public BehaviorTask GetChildById(int nodeId)
		{
			if (this.m_states != null && this.m_states.Count > 0)
			{
				for (int i = 0; i < this.m_states.Count; i++)
				{
					BehaviorTask behaviorTask = this.m_states[i];
					if (behaviorTask.GetId() == nodeId)
					{
						return behaviorTask;
					}
				}
			}
			return null;
		}

		// Token: 0x0601AA1F RID: 109087 RVA: 0x00838CA4 File Offset: 0x008370A4
		protected override EBTStatus update_current(Agent pAgent, EBTStatus childStatus)
		{
			this.m_excutingTreeTask = pAgent.ExcutingTreeTask;
			pAgent.ExcutingTreeTask = this;
			BehaviorTree behaviorTree = (BehaviorTree)this.m_node;
			EBTStatus result;
			if (behaviorTree.IsFSM)
			{
				result = this.update(pAgent, childStatus);
			}
			else
			{
				result = base.update_current(pAgent, childStatus);
			}
			return result;
		}

		// Token: 0x0601AA20 RID: 109088 RVA: 0x00838CF5 File Offset: 0x008370F5
		private void end(Agent pAgent, EBTStatus status)
		{
			this.traverse(true, BehaviorTask.end_handler_, pAgent, status);
		}

		// Token: 0x0601AA21 RID: 109089 RVA: 0x00838D0C File Offset: 0x0083710C
		protected override EBTStatus update(Agent pAgent, EBTStatus childStatus)
		{
			if (childStatus != EBTStatus.BT_RUNNING)
			{
				return childStatus;
			}
			EBTStatus ebtstatus = base.update(pAgent, childStatus);
			if (ebtstatus == EBTStatus.BT_RUNNING && this.m_endStatus != EBTStatus.BT_INVALID)
			{
				this.end(pAgent, this.m_endStatus);
				return this.m_endStatus;
			}
			return ebtstatus;
		}

		// Token: 0x040129C8 RID: 76232
		private Dictionary<uint, IInstantiatedVariable> m_localVars = new Dictionary<uint, IInstantiatedVariable>();

		// Token: 0x040129C9 RID: 76233
		private BehaviorTreeTask m_excutingTreeTask;

		// Token: 0x040129CA RID: 76234
		private EBTStatus m_endStatus;

		// Token: 0x040129CB RID: 76235
		private List<BehaviorTask> m_states;
	}
}
