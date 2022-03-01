using System;

namespace behaviac
{
	// Token: 0x02004785 RID: 18309
	public class CAgentMethod<T, P1, P2> : CAgentMethodBase<T>
	{
		// Token: 0x0601A50E RID: 107790 RVA: 0x00826FFF File Offset: 0x008253FF
		public CAgentMethod(CAgentMethod<T, P1, P2>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A50F RID: 107791 RVA: 0x0082700E File Offset: 0x0082540E
		public CAgentMethod(CAgentMethod<T, P1, P2> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
			this._p2 = rhs._p2;
		}

		// Token: 0x0601A510 RID: 107792 RVA: 0x0082703B File Offset: 0x0082543B
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1, P2>(this);
		}

		// Token: 0x0601A511 RID: 107793 RVA: 0x00827043 File Offset: 0x00825443
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
			this._p2 = AgentMeta.ParseProperty<P2>(paramStrs[1]);
		}

		// Token: 0x0601A512 RID: 107794 RVA: 0x00827068 File Offset: 0x00825468
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self), ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x0601A513 RID: 107795 RVA: 0x008270BC File Offset: 0x008254BC
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
			variableName = string.Format("{0}{1}", "_$local_task_param_$_", 1);
			treeTask.SetVariable<P2>(variableName, ((CInstanceMember<P2>)this._p2).GetValue(self));
		}

		// Token: 0x04012726 RID: 75558
		private CAgentMethod<T, P1, P2>.FunctionPointer _fp;

		// Token: 0x04012727 RID: 75559
		private IInstanceMember _p1;

		// Token: 0x04012728 RID: 75560
		private IInstanceMember _p2;

		// Token: 0x02004786 RID: 18310
		// (Invoke) Token: 0x0601A515 RID: 107797
		public delegate T FunctionPointer(Agent a, P1 p1, P2 p2);
	}
}
