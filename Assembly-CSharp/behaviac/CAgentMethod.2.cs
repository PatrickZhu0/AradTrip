using System;

namespace behaviac
{
	// Token: 0x02004783 RID: 18307
	public class CAgentMethod<T, P1> : CAgentMethodBase<T>
	{
		// Token: 0x0601A503 RID: 107779 RVA: 0x00826EEB File Offset: 0x008252EB
		public CAgentMethod(CAgentMethod<T, P1>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A504 RID: 107780 RVA: 0x00826EFA File Offset: 0x008252FA
		public CAgentMethod(CAgentMethod<T, P1> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
		}

		// Token: 0x0601A505 RID: 107781 RVA: 0x00826F1B File Offset: 0x0082531B
		public override IMethod Clone()
		{
			return new CAgentMethod<T, P1>(this);
		}

		// Token: 0x0601A506 RID: 107782 RVA: 0x00826F23 File Offset: 0x00825323
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
		}

		// Token: 0x0601A507 RID: 107783 RVA: 0x00826F3C File Offset: 0x0082533C
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0601A508 RID: 107784 RVA: 0x00826F80 File Offset: 0x00825380
		public override IValue GetIValue(Agent self, IInstanceMember firstParam)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._returnValue.value = this._fp(parentAgent, ((CInstanceMember<P1>)firstParam).GetValue(self));
			return this._returnValue;
		}

		// Token: 0x0601A509 RID: 107785 RVA: 0x00826FC4 File Offset: 0x008253C4
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x04012724 RID: 75556
		private CAgentMethod<T, P1>.FunctionPointer _fp;

		// Token: 0x04012725 RID: 75557
		private IInstanceMember _p1;

		// Token: 0x02004784 RID: 18308
		// (Invoke) Token: 0x0601A50B RID: 107787
		public delegate T FunctionPointer(Agent a, P1 p1);
	}
}
