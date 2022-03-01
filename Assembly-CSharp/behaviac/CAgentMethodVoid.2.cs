using System;

namespace behaviac
{
	// Token: 0x020047C0 RID: 18368
	public class CAgentMethodVoid<P1> : CAgentMethodVoidBase
	{
		// Token: 0x0601A642 RID: 108098 RVA: 0x0082C748 File Offset: 0x0082AB48
		public CAgentMethodVoid(CAgentMethodVoid<P1>.FunctionPointer f)
		{
			this._fp = f;
		}

		// Token: 0x0601A643 RID: 108099 RVA: 0x0082C757 File Offset: 0x0082AB57
		public CAgentMethodVoid(CAgentMethodVoid<P1> rhs) : base(rhs)
		{
			this._fp = rhs._fp;
			this._p1 = rhs._p1;
		}

		// Token: 0x0601A644 RID: 108100 RVA: 0x0082C778 File Offset: 0x0082AB78
		public override IMethod Clone()
		{
			return new CAgentMethodVoid<P1>(this);
		}

		// Token: 0x0601A645 RID: 108101 RVA: 0x0082C780 File Offset: 0x0082AB80
		public override void Load(string instance, string[] paramStrs)
		{
			this._instance = instance;
			this._p1 = AgentMeta.ParseProperty<P1>(paramStrs[0]);
		}

		// Token: 0x0601A646 RID: 108102 RVA: 0x0082C798 File Offset: 0x0082AB98
		public override void Run(Agent self)
		{
			Agent parentAgent = Utils.GetParentAgent(self, this._instance);
			this._fp(parentAgent, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x0601A647 RID: 108103 RVA: 0x0082C7D0 File Offset: 0x0082ABD0
		public override void SetTaskParams(Agent self, BehaviorTreeTask treeTask)
		{
			string variableName = string.Format("{0}{1}", "_$local_task_param_$_", 0);
			treeTask.SetVariable<P1>(variableName, ((CInstanceMember<P1>)this._p1).GetValue(self));
		}

		// Token: 0x04012815 RID: 75797
		private CAgentMethodVoid<P1>.FunctionPointer _fp;

		// Token: 0x04012816 RID: 75798
		private IInstanceMember _p1;

		// Token: 0x020047C1 RID: 18369
		// (Invoke) Token: 0x0601A649 RID: 108105
		public delegate void FunctionPointer(Agent a, P1 p1);
	}
}
